using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PostalCodeService.Models;
using System.Linq;
using System.Text;

namespace PostalCodeService.Services
{
    public class ImportExelService : IImportExelService
    {
        public ImportExelService()
        {

        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if(cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
        public async Task<List<PostalCode>> ImportCSVProccess(IFormFile file)
        {
            List<PostalCode> postalCodes = new List<PostalCode>();
            try {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    

                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(ms, false))
                    {
                        WorkbookPart workbookPart = doc.WorkbookPart;
                        IEnumerable<Sheet> sheets = doc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                        foreach (Sheet sheet in sheets)
                        {
                            string relationshipId = sheet.Id.Value;
                            WorksheetPart worksheetPart = (WorksheetPart)doc.WorkbookPart.GetPartById(relationshipId);
                            Worksheet workSheet = worksheetPart.Worksheet;
                            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                            IEnumerable<Row> rows = sheetData.Descendants<Row>();
                            //foreach (Cell cell in rows.ElementAt(0))
                            //{
                            //    string test = GetCellValue(doc, cell);
                            //    Console.Write(test);
                            //}
                            bool headers = false;
                            //this will also include your header row...
                            foreach (Row row in rows)
                            {
                                //if(headers)
                                //for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                                //{
                                //    string test = GetCellValue(doc, row.Descendants<Cell>().ElementAt(i));
                                //    Console.Write(test);
                                //}
                                if (headers)
                                {
                                    PostalCode postalCode = new PostalCode();

                                    postalCode.Code = GetCellValue(doc, row.Descendants<Cell>().ElementAt(0));
                                    postalCode.Name_State = GetCellValue(doc, row.Descendants<Cell>().ElementAt(4));
                                    postalCode.Name_City = GetCellValue(doc, row.Descendants<Cell>().ElementAt(5));
                                    postalCode.Name_Municipality = GetCellValue(doc, row.Descendants<Cell>().ElementAt(3));
                                    postalCode.ZipCode = GetCellValue(doc, row.Descendants<Cell>().ElementAt(6));
                                    postalCode.Settlement = GetCellValue(doc, row.Descendants<Cell>().ElementAt(1));
                                    postalCode.SettlementType = GetCellValue(doc, row.Descendants<Cell>().ElementAt(2));
                                    postalCodes.Add(postalCode);
                                }

                                headers = true;


                            }
                        }
                    }


                }
               

                return postalCodes;
            }catch(Exception ex) {
                throw new Exception($"Import only {postalCodes.Count()}");
            }
            
        }
    }
}

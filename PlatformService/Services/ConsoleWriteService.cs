using System;

namespace PlatformService.Services
{
    public static class ConsoleWriteService {
        public static void WriteLine(string arg) {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("-->  " + arg);
                Console.ResetColor();
        }
    }
}
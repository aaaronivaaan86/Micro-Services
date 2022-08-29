Ô
TC:\poo\netcore\Micro-Services\PlatformService\AsyncDataServices\IMessageBusClient.cs
	namespace 	
PlatformService
 
. 
AsyncDataServices +
{ 
public 

	interface 
IMessageBusClient &
{ 
public 
void 
PublishNewPlatform &
(& ' 
PlatformPublishedDto' ; 
platformPublishedDto< P
)P Q
;Q R
} 
}		 ì-
SC:\poo\netcore\Micro-Services\PlatformService\AsyncDataServices\MessageBusClient.cs
	namespace 	
PlatformService
 
. 
AsyncDataServices +
{ 
public 

class 
MessageBusClient !
:" #
IMessageBusClient$ 5
{ 
private 
readonly 
IConfiguration '
configuration( 5
;5 6
private 
readonly 
IConnection $

connection% /
;/ 0
private 
readonly 
IModel 
channel  '
;' (
public 
MessageBusClient 
(  
IConfiguration  .
configuration/ <
)< =
{ 	
this 
. 
configuration 
=  
configuration! .
;. /
ConnectionFactory 
factory %
=& '
new( +
ConnectionFactory, =
(= >
)> ?
{ 
HostName 
= 
this 
.  
configuration  -
[- .
RabbitMqEnum. :
.: ;
RabbitMQHost; G
]G H
,H I
Port 
= 
int 
. 
Parse  
(  !
this! %
.% &
configuration& 3
[3 4
RabbitMqEnum4 @
.@ A
RabbitMQPortA M
]M N
)N O
} 
; 
try 
{ 
this 
. 

connection 
=  !
factory" )
.) *
CreateConnection* :
(: ;
); <
;< =
this   
.   
channel   
=   

connection   )
.  ) *
CreateModel  * 5
(  5 6
)  6 7
;  7 8
this!! 
.!! 
channel!! 
.!! 
ExchangeDeclare!! ,
(!!, -
RabbitMqEnum!!- 9
.!!9 :
TriggerExchange!!: I
,!!I J
type!!K O
:!!O P
ExchangeType!!Q ]
.!!] ^
Fanout!!^ d
)!!d e
;!!e f
this"" 
."" 

connection"" 
.""  
ConnectionShutdown""  2
+=""3 5&
RabbitMQConnectionShutDown""6 P
;""P Q
Console## 
.## 
	WriteLine## !
(##! "
$str##" >
)##> ?
;##? @
}%% 
catch&& 
(&& 
	Exception&& 
ex&& 
)&&  
{'' 
Console(( 
.(( 
	WriteLine(( !
(((! "
$"((" $
$str(($ G
{((G H
ex((H J
.((J K
Message((K R
}((R S
"((S T
)((T U
;((U V
})) 
}** 	
public,, 
void,, 
PublishNewPlatform,, &
(,,& ' 
PlatformPublishedDto,,' ; 
platformPublishedDto,,< P
),,P Q
{-- 	
var.. 
message.. 
=.. 
JsonSerializer.. (
...( )
	Serialize..) 2
(..2 3 
platformPublishedDto..3 G
)..G H
;..H I
if// 
(// 
this// 
.// 

connection// 
.//  
IsOpen//  &
)//& '
{00 
Console11 
.11 
	WriteLine11 !
(11! "
$str11" Q
)11Q R
;11R S
}33 
else44 
{55 
Console66 
.66 
	WriteLine66 !
(66! "
$str66" A
)66A B
;66B C
}77 
}99 	
private;; 
void;; 
SendMessage;;  
(;;  !
string;;! '
message;;( /
);;/ 0
{<< 	
var== 
body== 
=== 
Encoding== 
.==  
UTF8==  $
.==$ %
GetBytes==% -
(==- .
message==. 5
)==5 6
;==6 7
this>> 
.>> 
channel>> 
.>> 
BasicPublish>> %
(>>% &
RabbitMqEnum>>& 2
.>>2 3
TriggerExchange>>3 B
,>>B C

routingKey?? 
:?? 
$str?? 
,?? 
basicProperties@@ 
:@@  
null@@! %
,@@% &
bodyAA 
:AA 
bodyAA 
)AA 
;AA 
ConsoleBB 
.BB 
	WriteLineBB 
(BB 
$"BB  
$strBB  2
{BB2 3
messageBB3 :
}BB: ;
"BB; <
)BB< =
;BB= >
}CC 	
publicEE 
voidEE 
DisposeEE 
(EE 
)EE 
{FF 	
ifGG 
(GG 
thisGG 
.GG 
channelGG 
.GG 
IsOpenGG #
)GG# $
{HH 
thisII 
.II 
channelII 
.II 
CloseII "
(II" #
)II# $
;II$ %
thisJJ 
.JJ 

connectionJJ 
.JJ  
CloseJJ  %
(JJ% &
)JJ& '
;JJ' (
}LL 
}MM 	
privateQQ 
voidQQ &
RabbitMQConnectionShutDownQQ /
(QQ/ 0
objectQQ0 6
senderQQ7 =
,QQ= >
ShutdownEventArgsQQ? P
argsQQQ U
)QQU V
{RR 	
ConsoleSS 
.SS 
	WriteLineSS 
(SS 
$strSS B
)SSB C
;SSC D
}TT 	
}XX 
}YY µ
SC:\poo\netcore\Micro-Services\PlatformService\AutoMapperProfile\PlatformsProfile.cs
	namespace 	
PlatformService
 
. 
Profiles "
{ 
public 

class 
PlatformsProfile !
:" #
Profile$ +
{ 
public		 
PlatformsProfile		 
(		  
)		  !
{

 	
	CreateMap 
< 
Platform 
, 
PlatformReadDto  /
>/ 0
(0 1
)1 2
;2 3
	CreateMap 
< 
PlatformCreateDto '
,' (
Platform) 1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< 
PlatformReadDto %
,% & 
PlatformPublishedDto' ;
>; <
(< =
)= >
;> ?
} 	
} 
} Ã;
PC:\poo\netcore\Micro-Services\PlatformService\Controllers\PlatformsController.cs
	namespace 	
PlatformService
 
. 
Controllers %
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
PlatformsController $
:% &
ControllerBase' 5
{ 
private 
readonly 
IPlatformRepo &

repository' 1
;1 2
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
ICommandDataClient +
commandDataClient, =
;= >
private 
readonly 
IMessageBusClient *
messageBusClient+ ;
;; <
public 
PlatformsController "
(" #
IPlatformRepo 

repository $
,$ %
IMapper 
mapper 
, 
ICommandDataClient 
commandDataClient 0
,0 1
IMessageBusClient 
messageBusClient .
)/ 0
{ 	
this 
. 

repository 
= 

repository (
;( )
this   
.   
mapper   
=   
mapper    
;    !
this!! 
.!! 
commandDataClient!! "
=!!# $
commandDataClient!!% 6
;!!6 7
this"" 
."" 
messageBusClient"" !
=""" #
messageBusClient""$ 4
;""4 5
}## 	
[%% 	
HttpGet%%	 
]%% 
public&& 
ActionResult&& 
<&& 
IEnumerable&& '
<&&' (
PlatformReadDto&&( 7
>&&7 8
>&&8 9
GetPlatforms&&: F
(&&F G
)&&G H
{'' 	
ConsoleWriteService)) 
.))  
	WriteLine))  )
())) *
$str))* D
)))D E
;))E F
var** 
	platforms** 
=** 
this**  
.**  !

repository**! +
.**+ ,
GetAllPlatforms**, ;
(**; <
)**< =
;**= >
return++ 
Ok++ 
(++ 
this++ 
.++ 
mapper++ !
.++! "
Map++" %
<++% &
IEnumerable++& 1
<++1 2
PlatformReadDto++2 A
>++A B
>++B C
(++C D
	platforms++D M
)++M N
)++N O
;++O P
},, 	
[.. 	
HttpGet..	 
(.. 
$str.. 
,.. 
Name.. 
=.. 
$str..  1
)..1 2
]..2 3
public// 
ActionResult// 
<// 
PlatformReadDto// +
>//+ ,
GetPlatformById//- <
(//< =
int//= @
id//A C
)//C D
{00 	
var11 
platformItem11 
=11 
this11 #
.11# $

repository11$ .
.11. /
GetPlatformById11/ >
(11> ?
id11? A
)11A B
;11B C
if22 
(22 
platformItem22 
!=22 
null22  $
)22$ %
{33 
return44 
Ok44 
(44 
this44 
.44 
mapper44 %
.44% &
Map44& )
<44) *
PlatformReadDto44* 9
>449 :
(44: ;
platformItem44; G
)44G H
)44H I
;44I J
}55 
return77 
NotFound77 
(77 
)77 
;77 
}88 	
[:: 	
HttpPost::	 
]:: 
public;; 
async;; 
Task;; 
<;; 
ActionResult;; &
<;;& '
PlatformReadDto;;' 6
>;;6 7
>;;7 8
CreatePlatform;;9 G
(;;G H
PlatformCreateDto;;H Y
platformCreateDto;;Z k
);;k l
{<< 	
ConsoleWriteService>> 
.>>  
	WriteLine>>  )
(>>) *
$str>>* B
)>>B C
;>>C D
var?? 
platformModel?? 
=?? 
this??  $
.??$ %
mapper??% +
.??+ ,
Map??, /
<??/ 0
Platform??0 8
>??8 9
(??9 :
platformCreateDto??: K
)??K L
;??L M
this@@ 
.@@ 

repository@@ 
.@@ 
CreatePlatform@@ *
(@@* +
platformModel@@+ 8
)@@8 9
;@@9 :
thisAA 
.AA 

repositoryAA 
.AA 
SaveChangesAA '
(AA' (
)AA( )
;AA) *
varCC 
platformReadDtoCC 
=CC  !
thisCC" &
.CC& '
mapperCC' -
.CC- .
MapCC. 1
<CC1 2
PlatformReadDtoCC2 A
>CCA B
(CCB C
platformModelCCC P
)CCP Q
;CCQ R
tryFF 
{GG 
awaitHH 
thisHH 
.HH 
commandDataClientHH ,
.HH, -!
SendPlatformToCommandHH- B
(HHB C
platformReadDtoHHC R
)HHR S
;HHS T
}II 
catchJJ 
(JJ 
	ExceptionJJ 
exJJ 
)JJ  
{KK 
ConsoleLL 
.LL 
	WriteLineLL !
(LL! "
$"LL" $
$strLL$ F
{LLF G
exLLG I
.LLI J
MessageLLJ Q
}LLQ R
"LLR S
)LLS T
;LLT U
}MM 
SendAsyncMessagePP 
(PP 
platformReadDtoPP ,
)PP, -
;PP- .
ConsoleWriteServiceRR 
.RR  
	WriteLineRR  )
(RR) *
$strRR* A
)RRA B
;RRB C
returnSS 
CreatedAtRouteSS !
(SS! "
nameofSS" (
(SS( )
GetPlatformByIdSS) 8
)SS8 9
,SS9 :
newSS; >
{SS? @
IdSSA C
=SSD E
platformReadDtoSSF U
.SSU V
IdSSV X
}SSY Z
,SSZ [
platformReadDtoSS\ k
)SSk l
;SSl m
}TT 	
privateVV 
voidVV 
SendAsyncMessageVV %
(VV% &
PlatformReadDtoVV& 5
platformReadDtoVV6 E
)VVE F
{WW 	
tryXX 
{YY 
varZZ  
platformPublishedDtoZZ (
=ZZ) *
thisZZ+ /
.ZZ/ 0
mapperZZ0 6
.ZZ6 7
MapZZ7 :
<ZZ: ; 
PlatformPublishedDtoZZ; O
>ZZO P
(ZZP Q
platformReadDtoZZQ `
)ZZ` a
;ZZa b 
platformPublishedDto[[ $
.[[$ %
Event[[% *
=[[+ ,
$str[[- A
;[[A B
this\\ 
.\\ 
messageBusClient\\ %
.\\% &
PublishNewPlatform\\& 8
(\\8 9 
platformPublishedDto\\9 M
)\\M N
;\\N O
}]] 
catch^^ 
(^^ 
	Exception^^ 
ex^^ 
)^^  
{__ 
Console`` 
.`` 
	WriteLine`` !
(``! "
$"``" $
$str``$ G
{``G H
ex``H J
.``J K
Message``K R
}``R S
"``S T
)``T U
;``U V
}aa 
}bb 	
}cc 
}dd ß
BC:\poo\netcore\Micro-Services\PlatformService\Data\AppDbContext.cs
	namespace 	
PlatformService
 
. 
Data 
{ 
public 

class 
AppDbContext 
: 
	DbContext  )
{ 
public 
AppDbContext 
( 
DbContextOptions ,
<, -
AppDbContext- 9
>9 :
opt; >
)> ?
:@ A
baseB F
(F G
optG J
)J K
{		 	
} 	
public 
DbSet 
< 
Platform 
> 
	Platforms (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ·
HC:\poo\netcore\Micro-Services\PlatformService\Data\enums\RabbitMqEnum.cs
	namespace 	
PlatformService
 
. 
Data 
. 
enums $
{ 
public 

static 
class 
RabbitMqEnum $
{		 
public

 
static

 
string

 
RabbitMQHost

 )
=

* +
$str

, :
;

: ;
public 
static 
string 
RabbitMQPort )
=* +
$str, :
;: ;
public 
static 
string 
TriggerExchange ,
=- .
$str/ 8
;8 9
} 
} ü
?C:\poo\netcore\Micro-Services\PlatformService\Data\PrepareDb.cs
	namespace		 	
PlatformService		
 
.		 
Data		 
{

 
public 

static 
class 
PrepDb 
{ 
public 
static 
void 
PrepPopulation )
() *
IApplicationBuilder* =
app> A
,A B
boolC G
isProdH N
)N O
{ 	
using 
( 
var 
serviceScope #
=$ %
app& )
.) *
ApplicationServices* =
.= >
CreateScope> I
(I J
)J K
)K L
{ 
SeedData 
( 
serviceScope %
.% &
ServiceProvider& 5
.5 6

GetService6 @
<@ A
AppDbContextA M
>M N
(N O
)O P
,P Q
isProdR X
)X Y
;Y Z
} 
} 	
private 
static 
void 
SeedData $
($ %
AppDbContext% 1
context2 9
,9 :
bool; ?
isProd@ F
)F G
{ 	
if 
( 
isProd 
) 
{ 
ConsoleWriteService #
.# $
	WriteLine$ -
(- .
$str. Q
)R S
;S T
try 
{ 
context 
. 
Database $
.$ %
Migrate% ,
(, -
)- .
;. /
} 
catch 
( 
	Exception 
ex  "
)" #
{ 
ConsoleWriteService   '
.  ' (
	WriteLine  ( 1
(  1 2
$str  2 N
+  O P
ex  Q S
.  S T
Message  T [
)  [ \
;  \ ]
}!! 
}"" 
if$$ 
($$ 
!$$ 
context$$ 
.$$ 
	Platforms$$ !
.$$! "
Any$$" %
($$% &
)$$& '
)$$' (
{%% 
ConsoleWriteService&& #
.&&# $
	WriteLine&&$ -
(&&- .
$str&&. ?
)&&? @
;&&@ A
context(( 
.(( 
	Platforms(( !
.((! "
AddRange((" *
(((* +
new)) 
Platform))  
())  !
)))! "
{))# $
Name))$ (
=))( )
$str))) 2
,))2 3
	Publisher))4 =
=))= >
$str))> I
,))I J
Cost))K O
=))O P
$str))P V
}))V W
,))W X
new** 
Platform**  
(**  !
)**! "
{**# $
Name**$ (
=**( )
$str**) =
,**= >
	Publisher**? H
=**H I
$str**I T
,**T U
Cost**W [
=**[ \
$str**\ b
}**b c
,**c d
new++ 
Platform++  
(++  !
)++! "
{++# $
Name++$ (
=++( )
$str++) 5
,++5 6
	Publisher++7 @
=++@ A
$str++A d
,++d e
Cost++g k
=++k l
$str++l r
}++r s
),, 
;,, 
context.. 
... 
SaveChanges.. #
(..# $
)..$ %
;..% &
}// 
else00 
{11 
ConsoleWriteService22 #
.22# $
	WriteLine22$ -
(22- .
$str22. D
)22D E
;22E F
}33 
}44 	
}55 
}66 Ç
FC:\poo\netcore\Micro-Services\PlatformService\Dto\PlatformCreateDto.cs
	namespace 	
PlatformService
 
. 
Dtos 
{ 
public 

class 
PlatformCreateDto "
{ 
[ 	
Required	 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[

 	
Required

	 
]

 
public 
string 
	Publisher 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
public 
string 
Cost 
{ 
get  
;  !
set" %
;% &
}' (
} 
} „
IC:\poo\netcore\Micro-Services\PlatformService\Dto\PlatformPublishedDto.cs
	namespace 	
PlatformService
 
. 
Dtos 
{ 
public 

class  
PlatformPublishedDto %
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Event 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 ı
DC:\poo\netcore\Micro-Services\PlatformService\Dto\PlatformReadDto.cs
	namespace 	
PlatformService
 
. 
Dtos 
{ 
public 

class 
PlatformReadDto  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
string		 
	Publisher		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public 
string 
Cost 
{ 
get  
;  !
set" %
;% &
}' (
} 
} Ω
XC:\poo\netcore\Micro-Services\PlatformService\Migrations\20220504205143_InitialCreate.cs
	namespace 	
PlatformService
 
. 

Migrations $
{ 
public 

partial 
class 
InitialCreate &
:' (
	Migration) 2
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
CreateTable		 (
(		( )
name

 
:

 
$str

 !
,

! "
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
int& )
>) *
(* +
type+ /
:/ 0
$str1 6
,6 7
nullable8 @
:@ A
falseB G
)G H
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
nullableG O
:O P
falseQ V
)V W
,W X
	Publisher 
= 
table  %
.% &
Column& ,
<, -
string- 3
>3 4
(4 5
type5 9
:9 :
$str; J
,J K
nullableL T
:T U
falseV [
)[ \
,\ ]
Cost 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
nullableG O
:O P
falseQ V
)V W
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 3
,3 4
x5 6
=>7 9
x: ;
.; <
Id< >
)> ?
;? @
} 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str !
)! "
;" #
} 	
} 
} Î
@C:\poo\netcore\Micro-Services\PlatformService\Modles\Platform.cs
	namespace 	
PlatformService
 
. 
Models  
{ 
public 
class 
Platform 
{ 
[ 	
Key	 
] 
[		 	
Required			 
]		 
public

 
int

 
Id

 
{

 
get

 
;

 
set

  
;

  !
}

" #
[ 	
Required	 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
] 
public 
string 
	Publisher 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
public 
string 
Cost 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ï

8C:\poo\netcore\Micro-Services\PlatformService\Program.cs
	namespace

 	
PlatformService


 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ô
SC:\poo\netcore\Micro-Services\PlatformService\Repositorie\Platform\IPlatformRepo.cs
	namespace 	
PlatformService
 
. 
Data 
{ 
public 

	interface 
IPlatformRepo "
{ 
bool		 
SaveChanges		 
(		 
)		 
;		 
IEnumerable 
< 
Platform 
> 
GetAllPlatforms -
(- .
). /
;/ 0
Platform 
GetPlatformById  
(  !
int! $
id% '
)' (
;( )
void 
CreatePlatform 
( 
Platform $
plat% )
)) *
;* +
} 
} ‹
RC:\poo\netcore\Micro-Services\PlatformService\Repositorie\Platform\PlatformRepo.cs
	namespace 	
PlatformService
 
. 
Data 
{ 
public 

class 
PlatformRepo 
: 
IPlatformRepo  -
{		 
private

 
readonly

 
AppDbContext

 %
_context

& .
;

. /
public 
PlatformRepo 
( 
AppDbContext (
context) 0
)0 1
{ 	
_context 
= 
context 
; 
} 	
public 
void 
CreatePlatform "
(" #
Platform# +
plat, 0
)0 1
{ 	
if 
( 
plat 
== 
null 
) 
{ 
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
plat7 ;
); <
)< =
;= >
} 
_context 
. 
	Platforms 
. 
Add "
(" #
plat# '
)' (
;( )
} 	
public 
IEnumerable 
< 
Platform #
># $
GetAllPlatforms% 4
(4 5
)5 6
{ 	
return 
_context 
. 
	Platforms %
.% &
ToList& ,
(, -
)- .
;. /
} 	
public   
Platform   
GetPlatformById   '
(  ' (
int  ( +
id  , .
)  . /
{!! 	
return"" 
_context"" 
."" 
	Platforms"" %
.""% &
FirstOrDefault""& 4
(""4 5
p""5 6
=>""7 9
p"": ;
.""; <
Id""< >
==""? A
id""B D
)""D E
;""E F
}## 	
public%% 
bool%% 
SaveChanges%% 
(%%  
)%%  !
{&& 	
return'' 
('' 
_context'' 
.'' 
SaveChanges'' (
(''( )
)'') *
>=''+ -
$num''. /
)''/ 0
;''0 1
}(( 	
})) 
}** ê
MC:\poo\netcore\Micro-Services\PlatformService\Services\ConsoleWriteService.cs
	namespace 	
PlatformService
 
. 
Services "
{ 
public 

static 
class 
ConsoleWriteService +
{, -
public 
static 
void 
	WriteLine $
($ %
string% +
arg, /
)/ 0
{1 2
Console 
. 
ForegroundColor '
=( )
ConsoleColor* 6
.6 7
DarkMagenta7 B
;B C
Console 
. 
	WriteLine !
(! "
$str" )
+* +
arg, /
)/ 0
;0 1
Console		 
.		 

ResetColor		 "
(		" #
)		# $
;		$ %
}

 	
} 
} Ã!
8C:\poo\netcore\Micro-Services\PlatformService\Startup.cs
	namespace 	
PlatformService
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{   	
services!! 
.!! 
AddDbContext!! !
<!!! "
AppDbContext!!" .
>!!. /
(!!/ 0
opt!!0 3
=>!!3 5
opt!!6 9
.!!9 :
UseInMemoryDatabase!!: M
(!!M N
$str!!N U
)!!U V
)!!V W
;!!W X
services&& 
.&& 
	AddScoped&& 
<&& 
IPlatformRepo&& ,
,&&, -
PlatformRepo&&. :
>&&: ;
(&&; <
)&&< =
;&&= >
services(( 
.(( 
AddHttpClient(( "
<((" #
ICommandDataClient((# 5
,((5 6
CommandDataClient((7 H
>((H I
(((I J
)((J K
;((K L
services)) 
.)) 
AddSingleton)) !
<))! "
IMessageBusClient))" 3
,))3 4
MessageBusClient))5 E
>))E F
())F G
)))G H
;))H I
services-- 
.-- 
AddControllers-- #
(--# $
)--$ %
;--% &
services.. 
... 
AddAutoMapper.. "
(.." #
	AppDomain..# ,
..., -
CurrentDomain..- :
...: ;
GetAssemblies..; H
(..H I
)..I J
)..J K
;..K L
services22 
.22 
AddSwaggerGen22 "
(22" #
c22# $
=>22% '
{33 
c44 
.44 

SwaggerDoc44 
(44 
$str44 !
,44! "
new44# &
OpenApiInfo44' 2
{443 4
Title445 :
=44; <
$str44= N
,44N O
Version44P W
=44X Y
$str44Z ^
}44_ `
)44` a
;44a b
}55 
)55 
;55 
}66 	
public99 
void99 
	Configure99 
(99 
IApplicationBuilder99 1
app992 5
,995 6
IWebHostEnvironment997 J
env99K N
)99N O
{:: 	
if;; 
(;; 
env;; 
.;; 
IsDevelopment;; !
(;;! "
);;" #
);;# $
{<< 
app== 
.== %
UseDeveloperExceptionPage== -
(==- .
)==. /
;==/ 0
app>> 
.>> 

UseSwagger>> 
(>> 
)>>  
;>>  !
app?? 
.?? 
UseSwaggerUI??  
(??  !
c??! "
=>??# %
c??& '
.??' (
SwaggerEndpoint??( 7
(??7 8
$str??8 R
,??R S
$str??T h
)??h i
)??i j
;??j k
}@@ 
appBB 
.BB 
UseHttpsRedirectionBB #
(BB# $
)BB$ %
;BB% &
appDD 
.DD 

UseRoutingDD 
(DD 
)DD 
;DD 
appFF 
.FF 
UseAuthorizationFF  
(FF  !
)FF! "
;FF" #
appHH 
.HH 
UseEndpointsHH 
(HH 
	endpointsHH &
=>HH' )
{II 
	endpointsJJ 
.JJ 
MapControllersJJ (
(JJ( )
)JJ) *
;JJ* +
}KK 
)KK 
;KK 
PrepDbMM 
.MM 
PrepPopulationMM !
(MM! "
appMM" %
,MM% &
envMM' *
.MM* +
IsProductionMM+ 7
(MM7 8
)MM8 9
)MM9 :
;MM: ;
}OO 	
}PP 
}QQ –
XC:\poo\netcore\Micro-Services\PlatformService\SyncDataServices\Http\CommandDataClient.cs
	namespace

 	
PlatformService


 
.

 
SyncDataServices

 *
.

* +
Http

+ /
{ 
public 

class 
CommandDataClient "
:# $
ICommandDataClient% 7
{ 
private 
readonly 

HttpClient #

httpClient$ .
;. /
private 
readonly 
IConfiguration '
configuration( 5
;5 6
public 
CommandDataClient  
(  !

HttpClient! +

httpClient, 6
,6 7
IConfiguration8 F
configurationG T
)T U
{ 	
this 
. 

httpClient 
= 

httpClient (
;( )
this 
. 
configuration 
=  
configuration! .
;. /
} 	
public 
async 
Task !
SendPlatformToCommand /
(/ 0
PlatformReadDto0 ?
plat@ D
)D E
{ 	
var 
httpContent 
= 
new !
StringContent" /
(/ 0
JsonSerializer 
. 
	Serialize (
(( )
plat) -
)- .
,. /
Encoding 
. 
UTF8 
, 
$str "
)" #
;# $
var 
response 
= 
await  
this! %
.% &

httpClient& 0
.0 1
	PostAsync1 :
(: ;
this; ?
.? @
configuration@ M
[M N
$strN ^
]^ _
,_ `
httpContenta l
)l m
;m n
if!! 
(!! 
response!! 
.!! 
IsSuccessStatusCode!! ,
)!!, -
{"" 
Console## 
.## 
	WriteLine## !
(##! "
$str##" K
)##K L
;##L M
}$$ 
else%% 
{&& 
Console'' 
.'' 
	WriteLine'' !
(''! "
this''" &
.''& '
configuration''' 4
[''4 5
$str''5 E
]''E F
)''F G
;''G H
Console(( 
.(( 
	WriteLine(( !
(((! "
$str((" O
)((O P
;((P Q
})) 
}** 	
}-- 
}.. Ô
YC:\poo\netcore\Micro-Services\PlatformService\SyncDataServices\Http\ICommandDataClient.cs
	namespace 	
PlatformService
 
. 
SyncDataServices *
.* +
Http+ /
{ 
public 
	interface 
ICommandDataClient (
{ 
Task		 !
SendPlatformToCommand		 "
(		" #
PlatformReadDto		# 2
plat		3 7
)		7 8
;		8 9
}

 
} 
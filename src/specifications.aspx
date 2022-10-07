<html xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:w="urn:schemas-microsoft-com:office:word"
xmlns="http://www.w3.org/TR/REC-html40">

<head>
<meta http-equiv=Content-Type content="text/html; charset=utf-8">
<meta name=ProgId content=Word.Document>
<meta name=Generator content="Microsoft Word 11">
<meta name=Originator content="Microsoft Word 11">
<link rel=File-List href="specifications_files/filelist.xml">
<title>Stand-Alone Mail Server</title>
<!--[if gte mso 9]><xml>
 <o:DocumentProperties>
  <o:Author>alireza</o:Author>
  <o:LastAuthor>alireza</o:LastAuthor>
  <o:Revision>5</o:Revision>
  <o:TotalTime>4</o:TotalTime>
  <o:LastPrinted>2005-04-29T21:57:00Z</o:LastPrinted>
  <o:Created>2005-04-29T21:35:00Z</o:Created>
  <o:LastSaved>2005-04-29T22:01:00Z</o:LastSaved>
  <o:Pages>1</o:Pages>
  <o:Words>2328</o:Words>
  <o:Characters>13276</o:Characters>
  <o:Company>networking</o:Company>
  <o:Lines>110</o:Lines>
  <o:Paragraphs>31</o:Paragraphs>
  <o:CharactersWithSpaces>15573</o:CharactersWithSpaces>
  <o:Version>11.5606</o:Version>
 </o:DocumentProperties>
 <o:OfficeDocumentSettings>
  <o:RelyOnVML/>
  <o:AllowPNG/>
 </o:OfficeDocumentSettings>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <w:WordDocument>
  <w:PunctuationKerning/>
  <w:ValidateAgainstSchemas/>
  <w:SaveIfXMLInvalid>false</w:SaveIfXMLInvalid>
  <w:IgnoreMixedContent>false</w:IgnoreMixedContent>
  <w:AlwaysShowPlaceholderText>false</w:AlwaysShowPlaceholderText>
  <w:Compatibility>
   <w:BreakWrappedTables/>
   <w:SnapToGridInCell/>
   <w:WrapTextWithPunct/>
   <w:UseAsianBreakRules/>
   <w:DontGrowAutofit/>
  </w:Compatibility>
  <w:BrowserLevel>MicrosoftInternetExplorer4</w:BrowserLevel>
 </w:WordDocument>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <w:LatentStyles DefLockedState="false" LatentStyleCount="156">
 </w:LatentStyles>
</xml><![endif]-->
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:Tahoma;
	panose-1:2 11 6 4 3 5 4 4 2 4;
	mso-font-charset:0;
	mso-generic-font-family:swiss;
	mso-font-pitch:variable;
	mso-font-signature:1627421319 -2147483648 8 0 66047 0;}
@font-face
	{font-family:Verdana;
	panose-1:2 11 6 4 3 5 4 4 2 4;
	mso-font-charset:0;
	mso-generic-font-family:swiss;
	mso-font-pitch:variable;
	mso-font-signature:536871559 0 0 0 415 0;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{mso-style-parent:"";
	margin:0in;
	margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";
	color:windowtext;}
a:link, span.MsoHyperlink
	{color:blue;
	text-decoration:underline;
	text-underline:single;}
a:visited, span.MsoHyperlinkFollowed
	{color:purple;
	text-decoration:underline;
	text-underline:single;}
p
	{mso-margin-top-alt:auto;
	margin-right:0in;
	mso-margin-bottom-alt:auto;
	margin-left:0in;
	mso-pagination:widow-orphan;
	font-size:7.5pt;
	font-family:Verdana;
	mso-fareast-font-family:"Times New Roman";
	mso-bidi-font-family:"Times New Roman";
	color:#333333;}
@page Section1
	{size:8.5in 11.0in;
	margin:1.0in 1.25in 1.0in 1.25in;
	mso-header-margin:.5in;
	mso-footer-margin:.5in;
	mso-paper-source:0;}
div.Section1
	{page:Section1;}
-->
</style>
<!--[if gte mso 10]>
<style>
 /* Style Definitions */
 table.MsoNormalTable
	{mso-style-name:"Table Normal";
	mso-tstyle-rowband-size:0;
	mso-tstyle-colband-size:0;
	mso-style-noshow:yes;
	mso-style-parent:"";
	mso-padding-alt:0in 5.4pt 0in 5.4pt;
	mso-para-margin:0in;
	mso-para-margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:"Times New Roman";
	mso-ansi-language:#0400;
	mso-fareast-language:#0400;
	mso-bidi-language:#0400;}
</style>
<![endif]-->
</head>

<body lang=EN-US link=blue vlink=purple style='tab-interval:.5in'>

<div class=Section1>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
style='mso-spacerun:yes'> </span>Stand-Alone Mail Server</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span><span style='mso-spacerun:yes'>       </span><span
style='mso-spacerun:yes'>             </span></span></b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'>(<a href="../specifications.pdf">فرمت
<span lang=EN-US dir=LTR>pdf</span></a><span dir=RTL></span><span dir=RTL></span>)</span><b><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>هدف از
طراحی این بخش فراهم نمودن یک سیستم پست الکترونیکی مدرن است که هم اکنون بخش اعظم
آن طراحی شده است و دارای ویژگی های منحصر به فردی است که آن را از میل سرور های
تجاری همانند </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Microsoft Exchange Server 2003, IMail</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و
</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MDaemon</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>کاملا متمایز می سازد. در بخش زیر سعی می شود تا به
طور تفصیل بخش هایی از این سیستم پیشرفته مورد بررسی قرار گیرد. این سیستم پست الکترونیکی
بر اساس آخرین تکنولوژی های روز نظیر </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Microsoft .NET Framework 1.1,
Visual C#.NET, Visual C++.NET, ASP.NET 1.1, MSSQL2000</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و
</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Oracle</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> بنا نهاده شده است. با توجه به </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>multi-platform</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> بودن </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Microsoft .NET</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>، هم اکنون این سرویس پست
الکترونیکی قابلیت نصب برروی سیستم عامل هایی همانند </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Microsoft Windows Server 2003 </span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'> </span>و </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>SUSE &amp; RedHat Linux</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>را دارا می باشد. <o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>ویژگی
های سرویس پست الکترونیک<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>a </span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Available Protocols Support</span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>سیستم چهار
پروتکل اساسی را برای شکل گرفتن یک معماری جامع پست الکترونیکی در بردارد :</span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP</span><span
dir=LTR style='font-size:11.0pt;font-family:Tahoma;mso-bidi-language:FA'> </span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Simple
Mail Transport Protocol)</span><span dir=LTR style='font-size:11.0pt;
font-family:Tahoma;mso-bidi-language:FA'>, </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>POP3</span><span dir=LTR
style='font-size:11.0pt;font-family:Tahoma;mso-bidi-language:FA'> </span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Post
Office Protocol)</span><span dir=LTR style='font-size:11.0pt;font-family:Tahoma;
mso-bidi-language:FA'><span style='mso-spacerun:yes'>   </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>IMAP4</span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Internet
Message Access Protocol)</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>و </span></span><span
dir=LTR></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=LTR></span><span style='mso-spacerun:yes'>     </span></span><span dir=LTR><span
style='mso-spacerun:yes'> </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>MIME </span><span dir=LTR style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'>(Multipurpose Internet Mail</span><span
dir=LTR style='font-size:11.0pt;font-family:Tahoma;mso-bidi-language:FA'> </span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>Extensions)</span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>تمامی این
پروتکل ها با توجه به تجربیاتمان در دنیای شبکه های کامپیوتری، مفاهیم پیشرفته<span
style='mso-spacerun:yes'>  </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Multi Thread &amp; Fiber Processing</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'>  </span>موجود در سیستم های عامل امروزی و </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Low-Level Socket API
Programming</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>به جهت بالا بردن کیفیت
کل سیستم و استفاده بهینه از منبع سیستم عامل، طراحی</span></span><span dir=LTR></span><span
lang=FA dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>
</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span><span style='mso-spacerun:yes'> </span>و پیاده سازی
شده اند. یک </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>SMTP Server</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>برای دریافت پست
الکترونیکی طراحی شده است. این سرویس می تواند در دو </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>mode</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
کار کند: 1) </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Normal Mode</span><span dir=RTL></span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'>     </span>2) </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Rely Mode</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
.<span style='mso-spacerun:yes'>   </span>در </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Normal Mode</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> ، سرور </span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>SMTP</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>می تواند به دو
روش اجرا شود: الف) می تواند پست های الکترونیکی دریافت شده از سرور های </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>دیگر همانند </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>yahoo</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>را دریافت کرده و بعد از شناسایی </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>spam</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>بودن یا نبودن آن، آن را در </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Inbox</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>یا </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Bulk</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> کاربر مورد نظر قرار دهد. ب) در حالت
دوم سرور </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>می تواند به سرور امن </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>ESMTP</span><span dir=LTR
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Extended
Simple Mail Transport Protocol)</span><span dir=RTL></span><span
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
</span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>مبدل شده و
از این ویژگی بر خوردار خواهد بود که فرستنده پست الکترونیکی بایستی خود را به
سرور </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>ESMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>ما بشناسند و یا به اصطلاح عمل </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Authentication</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> را انجام دهد و اگر سرور </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>ESMTP</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> او را
مجاز یا </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Authorized</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>بشناسد، فرستنده ایمیل میتواند بدنه پست الکترونیکی
خود را ارسال کند، شایان ذکر است که این مکانیزم با رد و بدل کردن </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>username</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>password</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>میان فرستنده و دریافت
کننده پست الکترونیک رخ می دهد.</span></span><span dir=LTR></span><span lang=FA
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>از این روش معمولا در شبکه
هایی که می خواهند دارای امنیت بالا بوده و فقط زیر سازمان های آن شرکت یا شبکه از
سیستم پست الکترونیکی خود استفاده کنند، استفاده می شود.<span
style='mso-spacerun:yes'>  </span>در </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Rely Mode</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
سرور </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP/ESMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>می تواند به عنوان یک واسط یا </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Transparent Proxy</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>فقط حامل و انتقال دهنده پست های الکترونیکی سرورهای</span></span><span
dir=LTR></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=LTR></span> SMTP/ESMTP</span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>دیگر باشد. از این </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>mode</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>معمو لا در شبکه های عظیم مگا یا گیگا بیتی که ستون فقرات (</span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Backbone</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span>)</span><span dir=LTR></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=LTR></span><span
style='mso-spacerun:yes'>  </span></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>اینترنت را می سازند و خدمات بسیار گسترده ایی را به زیر
شبکه های خود می دهند، استفاده می شود. بنا به اینکه کاربران سیستم پست الکترونیکی
ممکن است از نرم افزارهای تجاری همانند </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Microsoft Office Outlook</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>برای مدیریت کردن و خواندن صندوق های پست الکترونیکی خود استفاده کنند، برای
سیستم دو سرور </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>POP3</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> و </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>IMAP4</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>طراحی شده است و تمامی مقوله های امنیتی در طراحی و پیاده سازی این سرویس
های حساس برای برقراری امنیت تمامی صندوق های پستی کاربران اتخاذ شده است. سرور
های یاد شده به گونه ایی طراحی شده اند تا در صورت اجرا شدن آنها بر روی پردازنده
های </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>dual</span><span dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span> <span lang=FA>امروزی، بتوان بهترین کارایی را از منابع
سیستم عامل از جمله </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>memory</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>cpu cycle</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>برد. شایان ذکر است که تمامی سرویس های بیان شده در
بالا قابلیت اجرا بر روی لایه امنیتی </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>SSL3</span><span dir=LTR
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Secure Socket
Layer)</span><span dir=RTL></span><span style='font-size:10.0pt;font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> </span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'>را دارا می باشند تا بدین طریق امنیت
کامل سیستم بر آورده شود.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>b</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Multiple Domain Support</span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
این ایده که این بسته نرم افزاری می تواند برای یک </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Hosting Solution</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>مورد استفاده قرار گیرد بنابراین پشتیبانی این سیستم
پست الکترونیکی از دامین های چند گانه بدیهی به نظر می رسد. بنابر اینکه یک شرکت
هاستینگ به چه تعداد دارای مشتری بوده و برای آنها دامین ثبت کرده است می تواند در
این سیستم برای کاربران خود به طور نامحدود </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Email Account </span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'> </span><span lang=FA>ایجاد کند.
(مثلا </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>user@example.com</span><span dir=RTL></span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span>)<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>c</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>SQL-Based Log System<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>این سیستم
پست الکترونیکی دارای یک سیستم پیشرفته بر اساس پایگاه داده هایی همانند </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MSSQL 2000, MySql</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Oracle</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>می باشد که می تواند رخداد
های کل سیستم را به مدیر هاستینگ یا شبکه اطلاع دهد. بر اساس </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SQL</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>بودن سیستم </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Log</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>می تواند اطلاعات آماری و بسیار مفیدی را با استفاده از دستورات پیچیده </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SQL</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>برای مدیر سیستم فراهم نماید.</span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>d</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>FTP Support<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>یکی از ویژگی
های منحصر به فرد این سیستم برخورداری آن از </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>FTP</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>به جای </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>POP3</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>یا </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>IMAP4</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>خواهد بود، در این سیستم پست الکترونیکی بعد از
طراحی و پیاده سازی سرور </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>FTP</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>که در بخش های
قبل مورد بررسی قرار گرفت، کاربران سیستم قادر خواهند بود از طریق </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>FTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>و هر سیستم عاملی بدون استفاده از نرم افزارهای
جانبی همانند </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Microsoft Office Outlook</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>به مدیریت
صندوق پستی خود بپردازند. در واقع شبیه ساز نرم افزاری، طراحی خواهد شد که میان </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>client</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>MSSQL 2000</span><span dir=RTL></span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'>  </span>(که اطلاعات صندوق پستی کاربران را ذخیره می
کند) قرار گرفته و محتویات ذخیره شده در صندوق های پستی کاربران را به صورت فایل
سیستم شبیه سازی خواهد کرد تا از طریق </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>FTP</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>کاربران بتوانند پست های الکترونیکی خود را مدیریت کنند. همچنین برای بالا
بردن امنیت این سیستم از </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>FTPS</span><span dir=LTR style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'>(Secure File Transport Protocol)</span><span
dir=RTL></span><span lang=FA style='font-size:10.0pt;font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span><span style='mso-spacerun:yes'> 
</span></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>که بر
روی لایه </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SSL3</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>اجرا می شود، استفاده خواهد شد. چنین ویژگی هایی هم
اکنون در هیچ یک از سرویسی های پست الکترونیکی تجاری دیده نمی شود.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>e</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Reverse Look Up Technology </span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>برای بالا
بردن امنیت ایمیل های دریافتی و اینکه آیا فرستندگان آنها معتبر هستند از ساختار
زیر استفاده می شود : همانطوریکه در پروتکل </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>SMTP/ESMTP</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>بیان می شود، قبل از ارسال پست الکترونیکی فرستنده مجبور است یکی از
عبارات </span></span><span dir=LTR style='font-size:11.0pt;font-family:Tahoma;
mso-bidi-language:FA'>HELO/EHLO domain</span><span dir=RTL></span><span
style='font-size:11.0pt;font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
</span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>را به سرور
</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>دریافت کننده پست الکترونیکی اعلام کند، همچنین بعد
از اعلام چنین عبارتی فرستنده بایستی به طرف مقابل خود بیان کند که این ایمیل از چه
کسی می آید این اعلان با استفاده از دستور زیر مشخص می شود </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MAIL FROM:
&lt;user@domain.com&gt;</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> ، در هر
دو حالت سیستم به گونه ایی هوشمند از طریق </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>DNS</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> به دنبال
آدرس</span><span dir=LTR></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=LTR></span> IP</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>میل سرور<span style='mso-spacerun:yes'>  </span>بخش </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>domain</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>می گردد(یافتن آدرس </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>IP</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>میل سرور فرستنده پست الکترونیکی از طریق پرس و جوی رکورد های </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MX</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>از طریق </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>DNS</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>انجام می شود)،
بعد از یافتن این آدرس </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>IP</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>سیستم با سرور </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SMTP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>فرستنده پست الکترونیکی تماس گرفته و صحت وجود </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>domain</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>user</span><span dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span> <span lang=FA>ُمورد بررسی قرار می گیرد. اگر صحت
اطلاعات نشان دهد که فرستنده فرد واقعی است سیستم متوجه می شود که ایمیل در حال
دریافت از سوی یک </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>spammer</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>نیست و آن را در صندوق پستی کاربر مورد نظر قرار می دهد، در غیر این صورت
سیستم ارتباط را قطع کرده و هیچ ایمیلی از فرستنده در یافت نخواهد شد و فرد </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>spammer</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> ناکام خواهد ماند.</span><span dir=LTR></span><span lang=FA
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>f</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Task and Mail Scheduler System<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>این سیستم
دارای این قابلیت خواهد بود که کاربران بتوانند با تنظیمات خاصی در سیستم و با
زمان بندی دلخواه ایمیل هایی را که از قبل در صندوق پستی خود ذخیره کرده اند، بر
اساس جدول زمان بندی شده توسط کاربران واکشی کرده و آنها را به آدرس های ایمیل
دریافت کنندگان ارسال کند.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>g</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Mailing List and Address Book <o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>این سیستم
دارای یک دفترچه آدرس پیشرفته می باشد که این امکان را به کاربران می هد تا آدرس
های ایمیل اشخاص یا شرکت های مورد نیاز خود را با جزئیات کامل در آن وارد کرده و بتوانند
در سیستم پست الکترونیکی خود به طور مناسبی از آن بهره مند شوند.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>h</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Multi-Database Support </span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
اینکه این سیستم پست الکترونیکی به گونه ایی طراحی شده است که می تواند بر روی
تمام سیستم های عامل موجود نصب و راه اندازی شود، برای بالا بردن انعطاف پذیری این
سیستم، آن را به گونه ایی طراحی کرده ایم تا حداقل از سه پایگاه داده جهانی </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MSSQL 2000, MySql</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Oracle</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>پشتیبانی نماید.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>i</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Web-Mail <o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
اینکه ممکن است بسیاری از کاربران فاقد نرم افزار هایی همانند </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Microsoft Office
Outlook</span><span dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span> <span lang=FA>باشند و یا اینکه این کاربران در شبکه های
</span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>LAN</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>محلی قرار داشته باشند که بنابر سیاست های آن شبکه
با توجه به پراکسی و فایروال های موجود در آن شبکه ها، دسترسی مستقیم </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>TCP/IP</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>کاربران برای استفاده از سرویس هایی همانند </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>POP3, IMAP4</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>FTP</span><span dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span> <span lang=FA>منع شده است، بنابراین یک طراحی پیشرفته
رابط سمت وب بر اساس تکنولوژی </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>ASP.NET</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> صورت گرفت
تا تمامی کاربران بتوانند از طریق وب به مدیریت و خواندن پست های الکترونیکی خود
بپردازند. شایان ذکر است که این رابط سمت وب بر اساس </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>HTTPS</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و
</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SSL3</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>بنا نهاده شده است تا امنیت صندوق های پستی تمام
کاربران بر آورده شود.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>j</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Instant Messenger <o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>برای بالا
بردن قابلیت اطلاع رسانی به کاربران سیستم پست الکترونیکی از اینکه پست الکترونیکی
جدیدی به صندوق پستی آنها وارد شده است، نرم افزاری با تکنولوژی </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>VC++.NET</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>طراحی خواهد شد تا با قرار گرفتن در </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Windows Taskbar</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>بتواند کاربر را از رسیدن پست الکترونیک جدید آگاه ساخته
و او را به سمت صندوق پستی خود راهنمایی سازد. قبل از اجرای برنامه از کاربر </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>username</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> و </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>password</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>او پرسیده خواهد شد و تمامی
اطلاعات با استفاده از پروتکل </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>SSL3</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> به سمت
سرور ارسال خواهد کرد تا </span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>privacy</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>و امنیت کاربران حفظ شود. با توجه به اینکه این نرم افزار بر اساس </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>WIN32/ WIN64 APIs</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>طراحی خواهد شد، قابلیت نصب به صورت یک </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>InstallShield Package</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>را بر روی تمامی سیستم های عامل ویندوز 32 و</span></span><span
dir=LTR></span><span lang=FA dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=LTR></span> </span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'> </span>64</span><span dir=LTR></span><span lang=FA
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'> </span>بیتی را خواهد داشت.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>k</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Multi-Language Support <o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>از ابتدا این
این سیستم با این نگرش طراحی شد که باستی تمامی زبان های رایج دنیا را پشتیبانی
کند. بنابراین کل سیستم پست الکترونیکی بر اساس معماری<span
style='mso-spacerun:yes'>    </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Unicode(Universal Encoding)</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
از جمله </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>UTF-7,
UTF-8</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> و </span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span><span
style='mso-spacerun:yes'>  </span>UTF-32</span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'>طراحی گردید. در حال حاضر سیستم به طور ذاتی و پیش
فرض از دو زبان انگلیسی و فارسی حمایت می کند و می توان به راحتی زبان های دیگری
نیز به ساختار سیستم افزود.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>l</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Easy to Backup and Restore <o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با این ایده
که این سیستم پست الکترونیکی قرار است بر روی سکوهایی </span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>(Platform)</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'>  </span>نصب و اجرا شود که خدمات
را به مشتریان خود ارائه خواهند کرد و نیز با توجه به اینکه ممکن است سیستم های
عامل دچار مشکلاتی شده و تمامی اطلاعات کاربران و تنظیمات سیستمی<span
style='mso-spacerun:yes'>  </span>آنها ممکن است از بین رود، بنابراین به جای ذخیره
این اطلاعات در </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Windows Registry</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>، تمامی آنها در پایگاه
داده ذخیره می شوند تا اعمال </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>backup</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>restore</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>با امنیت و اطمینان بیشتری صورت گیرند.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>m</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span dir=LTR></span><b><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>
Architecture </span></b><span dir=RTL></span><b><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'> </span></span></b><b><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Distributed Systems<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>هدف اصلی
از طراحی این سیستم پست الکترونیکی در بدو امر توزیع پذیری آن بود تا بتوان آن را
بر روی شبکه های بسیار بزرگی که در آن<span style='mso-spacerun:yes'> 
</span>سازمان های وابسته به آن که حتی می توانند قاره ها از هم فاصله داشته باشند
، نصب و مدیریت کرد.</span><span dir=LTR></span><span lang=FA dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'> </span>با توجه به تجربیات منحصر
به فرد تیم طراحی کننده سیستم در زمینه معماری سیستم های توزیع شده </span><span
dir=LTR></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=LTR></span>(Distributed Systems)</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>و پردازش موازی</span></span><span dir=LTR></span><span lang=FA dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span><span style='mso-spacerun:yes'> </span></span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>(Parallel
Processing)</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> </span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span><span
style='mso-spacerun:yes'> </span></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>در شبکه های کامپیوتری توزیع شده از تکنولوژی های </span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>XML,
SOAP, Web Services, Distributed DNS,</span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'> </span><span dir=LTR style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'>Distributed Databases, Distributed
Memory, Distributed Web &amp; Mail Servers</span><span dir=RTL></span><span
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
</span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>و</span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>Distributed
Message Queue &amp; Manager Servers</span><span dir=RTL></span><span
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
</span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>برای بالا
بردن کارایی سیستم بهره برده شد و این قابلیت تا حدی است که این سیستم می تواند با
سیستم های عظیمی همانند </span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Yahoo</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MSN</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>رقابت کند.</span></span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span><span
style='mso-spacerun:yes'>  </span></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>بنابراین با توجه به توضیحات بیان شده این بسته نرم افزاری
پست الکترونیکی می تواند با مشورت و مشاوره گروه طراحی کننده آن برای سازمان های
بسیار بزرگی نظیر ارگان های دولتی و وزارتخانه ها بسیار مفید باشد، چرا که این
سیستم پست الکترونیکی برای مثال می تواند یک سازمان وسیع را در سطح یک کشور، قاره
و حتی در سطح بین المللی پوشش دهد. چنین ویژگی هم اکنون در هیچ یک از سرویسی های
پست الکترونیکی تجاری دیده نمی شود.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>n</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>High-Performance Memory Management<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
تجربیات ارزشمند گروه طراحی کننده سیستم در زمینه ساختمان داده های پیشرفته و مدیریت
بهینه حافظه سیستم های عامل، سیستم به گونه ایی طراحی شده است تا بتواند مدیریت
کاملی بر روی حافظه سیستمی داشته باشد. شایان ذکر است که این سیستم به گونه ایی
نیز طراحی شده است که می تواند بر روی نسل جدید </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>CPU</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
ها که از نوع </span><span dir=LTR></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=LTR></span>64 </span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'> </span><span lang=FA>بیتی هستند (همانند </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>AMD Athlon 64 bit</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span>) و فضای آدرس آن ها می تواند ترا بایت ها (حداکثر
18446744073709551616 آدرس) باشد، اجرا شده و بهترین کارایی از سیستم حاصل شود.</span><span
dir=LTR></span><span lang=FA dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=LTR></span> </span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>o</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><span dir=LTR></span><b><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>64 and 32
bit Package Installers<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
تجربیات استثنایی گروه طراحی کننده سیستم در زمینه کار با سیستم های عامل 64 بیتی
از جمله </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>SUSE
9.2<span style='mso-spacerun:yes'>  </span>Linux Enterprise Edition</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>و </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>Microsoft Windows Server 2003 64 bit Edition</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>و نیز برنامه نویسی های جدید پردازنده های </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>AMD Athlon 64 bit</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> با استفاده از </span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Microsoft VC++.NET</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>بر روی سکو های ویندوزی و </span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>GCC</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>بر روی سکوهای یونیکس و لینوکسی، سیستم پست الکترونیکی طراحی شده به طور ذاتی
و جداگانه بر اساس هر یک از سکو های 32 و 64 بیتی طراحی و کامپایل شده است و قابلیت
نصب به هر دو صورت 32 و 64 بیتی را بااستفاده از </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>InstallShield Package Installer</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>دارا می باشد. کل سیستم بر روی اولین نسخه رسمی
ویندوز سرور آوریل 2005 از سوی مایکروسافت و </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>SUSE 9.2 Linux Enterprise
Edition</span><span dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span> <span lang=FA>آزمایش شده و </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>stability</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>آن تایید شده است. تیم طراحی کننده دارای بیش از دو
سال تجربه بر روی سیستم های 64 بیتی است. می توان این نرم افزار را از دسته اول نرم
افزارهای تولید شده تجاری 64 بیتی در جهان دانست.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>p</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Microsoft Outlook and Mozila-Firefox for Linux Support</span></b><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>کاربران سیستم
پست الکترونیکی</span><span dir=LTR></span><span lang=FA dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>می توانند از نرم
افزارهای </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>outlook,
mozila</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> و </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>firefox</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'>  </span>برای مدیریت صندوق های پست الکترونیکی خود توسط
پروتکل های </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>POP3</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> و </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>IMAP4</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>بر روی سیستم های عامل ویندوز و لینوکس بهره مند شوند.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>q</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Compose Messages in RichText or HTML Format<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>سیستم های
پست الکترونیکی در اوایل ظهور تنها اجازه انتقال متون خالص </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>ASCII</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>را به کاربران خود می دادند پس از پیدایش پروتکل </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>MIME1</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>، تکنولوژی های پست الکترونیک متحول شدند. این
سیستم نیز از </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>MIME </span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span><span
style='mso-spacerun:yes'> </span><span lang=FA>در ساختار خود بهره می جوید به
طوریکه کاربران می توانند با استفاده از محیط پیشرفته ویرایش گر سیستم که همانند </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Microsoft FrontPage</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>می باشد به طراحی و ویرایش پست های الکترونیکی خود
با استفاده </span></span><span dir=LTR></span><span lang=FA dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span><span
style='mso-spacerun:yes'> </span></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>فرمت </span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>HTML</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>نمایند. شایان
ذکر است </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>attachment</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>های مربوط به پست
الکترونیکی نیز با استفاده از پروتکل </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>MIME</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>کد شده و ارسال می شوند. سیستم طراحی شده دارای یک<span
style='mso-spacerun:yes'>  </span></span></span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>component</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>پیچیده است که به طور کامل و بهینه پروتکل </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>MIME</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>را پیاده سازی می کند و در طراحی آن از اصول پیشرفته ساختمان های داده در زمینه
ساختار درخت هایی که می توانند دارای گره هایی با </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>n</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>یال خروجی باشند، استفاده شده است.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>r</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Anti-Spam Technology<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>از علوم
شبکه های عصبی (</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Neural Networks</span><span dir=RTL></span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span>) و هوش مصنوعی<span
style='mso-spacerun:yes'>                      </span>(</span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Intellectual</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>Intelligence</span><span dir=RTL></span><span lang=FA style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span>)<span
style='mso-spacerun:yes'>  </span>برای طراحی یک سیستم کاملا هوشمند<span
style='mso-spacerun:yes'>  </span>برای مقابله با </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>spammer</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>ها که سالانه با انتشار صد ها میلیون </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>spam</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>در شبکه های انتقال پست الکترونیکی، زیان های هنگفتی را بر شرکت ها و
جامعه اینترنت تحمیل میکنند، استفاده شده است. از االگوریتم های موجود و نیز </span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>DNS Queries</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>در سیستم های </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>DNSBL</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
همانند </span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>www.spamhaus.org</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>نیز استفاده شده است</span></span><span dir=LTR></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>s</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>) </span></b><b><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>Storing Emails in XML Files</span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>این سیستم
دارای این قابلیت است که می تواند تمامی اطلاعات سیستم و صندوقهای پستی کاربران را
بر روی فایل ها و اسناد ساخت یافته</span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>XML </span><span dir=LTR style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'>(Extensible Markup Language) </span><span
dir=RTL></span><span style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span><span style='mso-spacerun:yes'> </span></span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>ذخیره و
بازیابی نماید. این امر سبب بالا رفتن </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>portability</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>سیستم حتی به پروتکل هایی مانند </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>WAP</span><span dir=RTL></span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span>
خواهد شد.</span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>t</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>WAP
and WML Support<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
اینکه امروزه استفاده از تلفن های همراه و </span><span dir=LTR style='font-family:
Tahoma;mso-bidi-language:FA'>pocket pc</span><span dir=RTL></span><span
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span
lang=FA>ها رونق روز افزون می یابند، تصمیم داریم تا با توجه به تجربیاتمان در این
زمینه و اینکه<span style='mso-spacerun:yes'>  </span></span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Microsoft .NET</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>به طور ذاتی </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Mobile Devices</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>را پشتیبانی می کند، این زمینه را فراهم سازیم تا کاربران
بتوانند از طریق موبایل های خود که مرورگرهای </span></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>WML</span><span dir=LTR
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Wireless
Markup Language)</span><span dir=RTL></span><span style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>و پروتکل ارتباطی سیار </span><span
dir=LTR></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=LTR></span><span style='mso-spacerun:yes'> </span>WAP</span><span dir=LTR
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Wireless
Application Protocol)</span><span lang=FA style='font-size:10.0pt;font-family:
Tahoma;mso-bidi-language:FA'>را </span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'>پشتیبانی می کنند، بتوانند پست های الکترونیکی خود را خوانده
یا به ارسال پست الکترونیکی متنی جدید بپردازند.<b> </b>چنین قابلیتی در هیچ یک از
محصولات پست الکترونیکی تجاری امروزی وجود ندارد.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>u</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Multi-Layer
System Architecture<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>با توجه به
تجربیات ارزشمند تیم طراح در زمینه معماری و ساختارهای طراحی چند لایه، این سیستم
بر اساس این معماری بنیان نهاده شده است. به همین علت ساختار سیستم قابلیت بسیار
بالایی برای بروز رسانی و توسعه را دارا می باشد. علت موفقیت این سیستم در معماری
چند لایه بر این واقعیت استوار است که تمامی سیستم بر اساس ساختار<span
style='mso-spacerun:yes'>  </span></span><span dir=LTR style='font-family:Tahoma;
mso-bidi-language:FA'>XML</span><span dir=RTL></span><span style='font-family:
Tahoma;mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>توسعه یافته
است.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>v</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>DCOM
&amp; CORBA Architectures<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>در طراحی این
سیستم پست الکترونیکی با توجه به ماهیت توزیع پذیری آن از مفاهیم </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>CORBA</span><span
dir=LTR style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Common
Object Broker Architecture)</span><span dir=RTL></span><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> و </span><span
dir=LTR></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=LTR></span><span style='mso-spacerun:yes'> </span>DCOM</span><span dir=LTR
style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'>(Distributed
Component Object Model)</span><span dir=RTL></span><span style='font-size:10.0pt;
font-family:Tahoma;mso-bidi-language:FA'><span dir=RTL></span> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>استفاده شده است.</span><span
lang=FA style='font-size:10.0pt;font-family:Tahoma;mso-bidi-language:FA'> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>ولی این سیستم به هیچ
وجه بر اساس هیچکدام از این دو معماری بنیان نهاده نشده است.<o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>w</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Various
Email File Size Support<o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>سیستم دارای
این قابلیت می باشد که می تواند این امکان را برای مدیر سیستم فراهم کند تا بتواند
حجم سایز پست الکترونیکی که به صندوق کاربران انداخته می شود یا حجم پست الکترونیکی
که هر کاربر می تواند در هر جلسه ارسال پست الکترونیکی جدید ارسال نماید، تنظیم
کند. <o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>x</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Word
Suggestion &amp; Spell Checking Technologies</span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>برای سیستم
پست الکترونیکی یک تکنولوژی اصلاح </span><span dir=LTR></span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span>(Spell
Checking)</span><span dir=RTL></span><span style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> <span lang=FA>و پیشنهاد (</span></span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Suggestion</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span>) لغت با استفاده از ساختمان های داده و به ویژه </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Trie</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>طراحی شده است.<o:p></o:p></span></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>y</span></b><span
dir=RTL></span><b><span lang=FA style='font-family:Tahoma;mso-bidi-language:
FA'><span dir=RTL></span>)</span></b><span lang=FA style='mso-bidi-language:
FA'> </span><b><span dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Resistant
against DDOS and Stack Overflow Hacking Attacks</span></b><b><span lang=FA
style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></b></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'>سیستم پست
الکترونیکی به گونه ایی طراحی شده است که در برابر حملات امنیتی از سوی افراد </span><span
dir=LTR style='font-family:Tahoma;mso-bidi-language:FA'>Hacker</span><span
dir=RTL></span><span style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> <span lang=FA>مقاوم می باشد. از جمله اینگونه حملات میتوان به
حملات </span></span><span dir=LTR style='font-family:Tahoma;mso-bidi-language:
FA'>DDOS</span><span dir=RTL></span><span lang=FA style='font-family:Tahoma;
mso-bidi-language:FA'><span dir=RTL></span> و حملات </span><span dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'>Stack Overflow Hacking</span><span
dir=RTL></span><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><span
dir=RTL></span> اشاره کرد.</span><span dir=LTR></span><span lang=FA dir=LTR
style='font-family:Tahoma;mso-bidi-language:FA'><span dir=LTR></span> </span><span
lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p></o:p></span></p>

<p class=MsoNormal dir=RTL style='text-align:justify;direction:rtl;unicode-bidi:
embed'><span lang=FA style='font-family:Tahoma;mso-bidi-language:FA'><o:p>&nbsp;</o:p></span></p>

<p align=center style='text-align:center'><span dir=LTR></span><b><span
style='font-size:9.0pt'><span dir=LTR></span>©&nbsp;Copyright 2005 PMail. All
rights reserved.<o:p></o:p></span></b></p>

<p class=MsoNormal><o:p>&nbsp;</o:p></p>

</div>

</body>

</html>

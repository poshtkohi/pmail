<%@ Page language="c#" Codebehind="Result.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.Result" %>
<HTML>
	<HEAD>
		<title>Results about your message.</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="JavaScript">
<!--
function FP_preloadImgs() {//v1.0
 var d=document,a=arguments; if(!d.FP_imgs) d.FP_imgs=new Array();
 for(var i=0; i<a.length; i++) { d.FP_imgs[i]=new Image; d.FP_imgs[i].src=a[i]; }
}

function FP_swapImg() {//v1.0
 var doc=document,args=arguments,elm,n; doc.$imgSwaps=new Array(); for(n=2; n<args.length;
 n+=2) { elm=FP_getObjectByID(args[n]); if(elm) { doc.$imgSwaps[doc.$imgSwaps.length]=elm;
 elm.$src=elm.src; elm.src=args[n+1]; } }
}

function FP_getObjectByID(id,o) {//v1.0
 var c,el,els,f,m,n; if(!o)o=document; if(o.getElementById) el=o.getElementById(id);
 else if(o.layers) c=o.layers; else if(o.all) el=o.all[id]; if(el) return el;
 if(o.id==id || o.name==id) return o; if(o.childNodes) c=o.childNodes; if(c)
 for(n=0; n<c.length; n++) { el=FP_getObjectByID(id,c[n]); if(el) return el; }
 f=o.forms; if(f) for(n=0; n<f.length; n++) { els=f[n].elements;
 for(m=0; m<els.length; m++){ el=FP_getObjectByID(id,els[n]); if(el) return el; } }
 return null;
}
// -->
		</script>
		<style type="text/css">
		.attachBtn { BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; WIDTH: 200px; BORDER-BOTTOM: #000000 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #cccccc }
	.copy { FONT-WEIGHT: 900; FONT-SIZE: 9px; COLOR: #f4fcdd; FONT-FAMILY: Tahoma }
	.boxes1 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.boxes2 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.boxes3 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.boxes31 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.boxes21 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.boxes4 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	A { COLOR: #039; TEXT-DECORATION: none }
	A:visited { COLOR: #039; TEXT-DECORATION: none }
	A:hover { TEXT-DECORATION: underline }
	BODY { MARGIN: 0px }
	.boxes { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.copyright { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.footer { FONT-WEIGHT: bold; FONT-SIZE: x-small; COLOR: #ffffff }
	.folders { FONT-WEIGHT: bolder; FONT-SIZE: small; COLOR: #660000; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
	.EE { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
	.tasks { FONT-SIZE: x-small; FONT-FAMILY: Tahoma }
	.visited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
	.Unvisited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
	.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
	.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
	.DnsError { FONT-SIZE: x-small; COLOR: #ff0000; FONT-FAMILY: Tahoma }
	.boxes311 {MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
        </style>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" onload="FP_preloadImgs(/*url*/'images/button23.gif', /*url*/'images/button24.gif', /*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button29.gif', /*url*/'images/button2A.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif')"
		marginwidth="0" marginheight="0">
		<!-- ImageReady Slices (email.psd) -->
		<table id="Table_01" height="558" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<!--DWLayoutTable-->
			<tr>
				<td vAlign="top" align="left" colSpan="3" height="27"><font face="Arial">welcome&nbsp; <%=this.Session["username"]%> </font> </td>
				<td vAlign="middle" align="right" colSpan="2"><div align="center"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></div></td>
				<td vAlign="middle" align="right" colSpan="2"><div align="left">
					<a href="/about.aspx"><font face="Arial" size="2">About 
					PMail</font></a><font face="Arial" size="2"> | Help</font></div></td>
			<td align="right" vAlign="middle" bgcolor="#C1E0FF"><div align="center"><span class="folders"><a href="/email/fa/Result.aspx">FA</a></span></div></td>
			</tr>
			<tr>
				<td align="left" colSpan="2" height="29"><IMG height="89" alt="PMail Service" src="/images/arm1.jpg" width="279"></td>
				<td vAlign="top" colSpan="4"><!--DWLayoutEmptyCell-->&nbsp; 
				</td>
				<td colSpan="2" align="right" vAlign="top"><a href="?i=signout"><IMG src="images/email_06.gif" alt="" width="85" height="29" border="0"></a></td>
			</tr>
			<tr>
				<td width="99" height="26" bgcolor="#FFFFE5"><!--DWLayoutEmptyCell-->&nbsp; </td>
				<td colSpan="7" align="right" vAlign="bottom" bgcolor="#FFFFE5">&nbsp; <a href="Compose.aspx">
						<IMG onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button23.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button24.gif')"
							id="img1" onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button23.gif')"
							onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button22.gif')" height="22"
							alt="Compose" src="images/button22.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"
							fp-title="Compose"></a> <a href="ShowAddressBook.aspx"><IMG onmouseup="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button26.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button27.gif')"
							id="img4" onmouseover="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button26.gif')" onmouseout="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button25.gif')"
							height="22" alt="Address book" src="images/button25.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"
							fp-title="Address book"></a>
				</td>
			</tr>
			<tr>
				<td rowSpan="5" vAlign="top">
					<table width="100%" border="0" cellPadding="0" cellSpacing="0" bgcolor="#c1e0ff">
						<!--DWLayoutTable-->
						<tr>
							<td vAlign="top" width="95" bgColor="#c1e0ff" height="23"><span class="folders" title="Available Foldrs">Folders</span>
							</td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><!--DWLayoutEmptyCell-->&nbsp; </td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><span class="boxes"><IMG height="12" src="images/inbox.gif" width="15">&nbsp;<A title="Inbox Folder" href="/email/?ShowFolder=Inbox" target="_self">Inbox</A></span></td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><span class="boxes1"><IMG height="12" src="images/draft.gif" width="15">&nbsp;<A title="Draft Folder" href="/email/?ShowFolder=Draft" target="_self">Draft</A></span></td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><span class="boxes4"><IMG height="12" src="images/sent.gif" width="15">&nbsp;<A title="Sent Folder" href="/email/?ShowFolder=Sent">Sent</A></span></td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><span class="boxes21"><IMG height="12" src="images/bulk.gif" width="15">&nbsp;<A title="Bulk Folder" href="/email/?ShowFolder=Bulk" target="_self">Bulk</A></span></td>
						</tr>
						<tr>
							<td vAlign="top" height="19"><span class="boxes311"><IMG height="12" src="images/trash.gif" width="13">&nbsp;<A href="?ShowFolder=Trash" title="Trash Folder">Trash</A> (<a href="?EmptyTrash=1">Empty</a>)</span></td>
						</tr>
						<tr>
							<td height="253" background="#c1e0ff">&nbsp;</td>
						</tr>
					</table>
				</td>
				<td height="20" colSpan="3" vAlign="top" bgColor="#ffffe5"><!--DWLayoutEmptyCell-->&nbsp; 
					
				</td>
				<td vAlign="top" align="right" bgColor="#ffffe5" colSpan="4"><font face="Arial" color="#808000" size="2">You 
						are used 8% of your Mailbox storage </font>
				</td>
			</tr>
			<tr>
				<td width="97" height="139" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="124" bordercolor="#ffffff" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="55" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="251" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="134" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="196" bgcolor="#dbeaf5">&nbsp;</td>
				<td width="28" bgcolor="#dbeaf5">&nbsp;</td>
			</tr>
			<tr>
				<td height="18" bgcolor="#dbeaf5"></td>
				<td colspan="5" align="center" valign="top" bgcolor="#FFFFE5"><span class="ColumnText"><span class="DnsError"> Your message had be sent to queue of <strong>&reg;</strong>Cyber Mail Server for sending your email to destination clients. </span>
					</span></td>
				<td bgcolor="#dbeaf5"></td>
			</tr>
			<tr>
				<td height="188" bgcolor="#dbeaf5"></td>
				<td bgcolor="#dbeaf5">&nbsp;</td>
				<td bgcolor="#dbeaf5"></td>
				<td bgcolor="#dbeaf5"></td>
				<td bgcolor="#dbeaf5"></td>
				<td bgcolor="#dbeaf5"></td>
				<td bgcolor="#dbeaf5"></td>
			</tr>
			<tr>
				<td height="25" colSpan="7" vAlign="top" bgColor="#ffffe5"><!--DWLayoutEmptyCell-->&nbsp; 
					
				</td>
			</tr>
			<tr>
				<td height="28">&nbsp;</td>
				<td colSpan="2">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" colSpan="9" height="22">
				<span class="copy"><font face="Arial" color="#808000">&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © Copyright 2005 
				PMail. All rights reserved.</b></font></span><b><font face="Arial" color="#808000">
				  </font></b>
			    </td>
			</tr>
			<tr>
				<td height="46">&nbsp;</td>
				<td colSpan="2">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
				<td vAlign="top" bgColor="#ffffff">&nbsp;</td>
			</tr>
		</table>
	</body>
</HTML>

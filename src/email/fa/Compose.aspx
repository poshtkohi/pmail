<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page language="c#" Codebehind="Compose.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.fa.Compose" validaterequest="false" Trace="false" %>
<HTML>
	<HEAD>
		<title>ارسال پیام جدید</title>
		<meta http-equiv="Content-Language" content="fa">
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
	.txtbox { BORDER-RIGHT: 0px ridge; BORDER-TOP: 0px ridge; FONT-SIZE: x-small; BORDER-LEFT: 0px ridge; WIDTH: 550px; BORDER-BOTTOM: 0px ridge; FONT-FAMILY: Tahoma; HEIGHT: 20px }
	.ListBox { WIDTH: 200px; HEIGHT: 200px }
	.copy { FONT-WEIGHT: 900; FONT-SIZE: 9px; COLOR: #f4fcdd; FONT-FAMILY: Tahoma }
	.style8 { FONT-WEIGHT: 900; FONT-SIZE: 9px; COLOR: #000066; FONT-FAMILY: Tahoma }
	.style9 { COLOR: #000033 }
	.boxes { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	.copyright { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.folders { FONT-WEIGHT: bolder; FONT-SIZE: small; COLOR: #660000; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
	.EE { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
	.tasks { FONT-SIZE: x-small; FONT-FAMILY: Tahoma }
	.visited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
	.Unvisited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
	.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
	.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
	A { COLOR: #039; TEXT-DECORATION: none }
	A:visited { COLOR: #039; TEXT-DECORATION: none }
	A:hover { TEXT-DECORATION: underline }
	.style10 { FONT-FAMILY: Tahoma }
	.to { FONT-WEIGHT: bolder; FONT-SIZE: x-small; COLOR: #6600ff; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
	</style>
	<script language="JavaScript" src="../spell.js" type="text/javascript"></script>
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"
		onload="FP_preloadImgs(/*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif', /*url*/'images/button4.jpg', /*url*/'images/button5.jpg', /*url*/'images/buttonA.jpg', /*url*/'images/buttonB.jpg')">
		<form runat="server" method="post">
			<table id="Table_01" width="100%" height="599" border="0" cellpadding="0" cellspacing="0">
				<!-- MSTableType="layout" -->
				<tr>
					<td height="32" colspan="3" align="left" valign="top">
					<p align="left" dir="rtl">
					<font face="Tahoma" style="FONT-SIZE: 8pt"> 
					<a href="/about.aspx" target="_blank" style="color: #039; text-decoration: none">
								درباره <span lang="en-us">PMail</span> </a>
							&nbsp;|
											<span lang="en-us">
								&nbsp;</span><a target="_blank" href="/specifications.aspx" style="color: #039; text-decoration: none">مشخصات 
					سیستم پست الکترونیک <span lang="en-us">PMai</span></a><span lang="en-us">l</span></font></p>
				  </td>
					<td colspan="2" align="right" valign="middle"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></td>
					<td colspan="4" align="right" valign="middle">
						<p align="center"><font face="Arial">welcome&nbsp;
								<%=this.Session["username"]%>
							</font>
						</p>
					</td>
					<td width="42" bgcolor="#ADCDFC"><div align="center"><span class="folders"><a href="/email/Compose.aspx">En</a></span></div></td>
				</tr>
				<tr>
					<td width="237" height="35" align="right">
						<a href="?i=signout"><img src="images/email_06.gif" alt="خروج" width="85" height="29" border="0"></a></td>
					<td colspan="5" valign="top" align="right">
					</td>
					<td valign="top" rowspan="3" colspan="4">
						<p align="right">
							<img src="/images/arm1.jpg" alt="PMail Service" border="0"></p>
					</td>
				</tr>
				<tr>
					<td height="38" colspan="2" valign="top">
					<p align="right" dir="rtl"><font face="Tahoma" color="#000066"> <span style="FONT-SIZE: 8pt"> اولین سیستم<span lang="en-us">
					</span>جامع فارسی زبان پست الکترونیکی</span></font></p>
				  </td>
					<td colspan="4" align="left" valign="bottom">
						<p align="right" dir="rtl">&nbsp; <img border="0" id="img1" src="images/button3.jpg" height="22" width="110" alt="ارسال ايميل جديد"
									onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button4.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button3.jpg')"
									onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button5.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button4.jpg')"
									fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="ارسال ايميل جديد">
							<a href="ShowAddressBook.aspx"><img border="0" id="img5" src="images/button9.jpg" height="22" width="95" alt="تنظيمات"
									onmouseover="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonA.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/button9.jpg')"
									onmousedown="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonB.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/buttonA.jpg')"
									fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="تنظيمات"></a></p>
					</td>
				</tr>
				<tr>
					<td height="22" colspan="4" valign="top" bgcolor="#caeeff">
						<span class="style9">
							<font face="Arial" size="2">You are used 8% of your Mailbox storage </font>
						</span>
					</td>
					<td colspan="2" align="left" valign="top" bgcolor="#caeeff"><FONT style="BACKGROUND-COLOR: #ffffff"></FONT>
					</td>
				</tr>
				<tr>
					<td height="47" colspan="7" valign="bottom" bgcolor="#caeeff">
						<p align="right">&nbsp;&nbsp;</p>
					</td>
					<td width="6">&nbsp;</td>
					<td colspan="2" rowspan="4" align="right" valign="top">
						<table width="222" height="399" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#caeeff"
							bordercolordark="#a4e1ff">
							<!-- MSTableType="layout" -->
							<tr>
								<td height="21" colspan="2" align="right" valign="top" bgcolor="#a4e1ff" dir="rtl">
									<p align="right"><b> <a href="/email/fa/?ShowFolder=Inbox">
												<span lang="fa">
													<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هاي دريافت شده </font></span></a></b>
									<span lang="en-us">
									<font face="Tahoma" size="1">(Inbox)</font></span></p>
								</td>
							</tr>
							<tr>
								<td height="21" colspan="2" align="right" valign="top" dir="rtl">
									<b><a href="/email/fa/?ShowFolder=Sent">
											<span lang="fa">
												<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هاي فرستاده شده </font></span></a></b><font face="Tahoma" size="1"><span lang="en-us">(Sent)</span></font></td>
							</tr>
							<tr>
								<td height="21" colspan="2" align="right" valign="top" dir="rtl"><b> <a href="/email/fa/?ShowFolder=Draft">
											<font face="Tahoma" style="FONT-SIZE: 8pt">
												<span lang="fa">نامه هاي نيمه كاره كه ذخيره 
													شده</span><span lang="en-us"></span><span lang="fa">اند</span></font></a></b><font face="Tahoma" style="FONT-SIZE:9px"><span lang="en-us">(Draft)</span></font></td>
							</tr>
							<tr>
								<td height="23" colspan="2" align="right" valign="top" dir="rtl">
									<b><a href="/email/fa/?ShowFolder=Trash">
											<span lang="fa">
												<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هايي كه پاك كرده ايد</font></span></a><font face="Tahoma" style="FONT-SIZE: 8pt"><span lang="en-us">
												<a href="?EmptyTrash=1">(حذف)</a>
											</span></font></b><font face="Tahoma" style="FONT-SIZE: 8pt">
										<span lang="en-us">(Trash)</span></font></td>
							</tr>
							<tr>
								<td height="21" colspan="2" align="right" valign="top" dir="rtl">
									<b><a href="/email/fa/?ShowFolder=Bulk">
											<span lang="fa">
												<font face="Tahoma" style="FONT-SIZE: 8pt">هرز نامه هاي فرستاده شده به شما</font></span></a></b><font face="Tahoma" size="1"><span lang="en-us">(Bulk)</span></font></td>
							</tr>
							<tr>
								<td height="21" colspan="2" align="right" valign="top" dir="rtl">
									<a href="/email/fa/?ShowFolder=Inbox&Show=all">
										<span lang="fa">
											<b><font face="Tahoma" style="FONT-SIZE: 8pt">تمامي ايميل هاي دريافت شده</font></b></span></a></td>
							</tr>
							<tr>
								<td height="19" colspan="2" align="right" valign="top" bgcolor="#a4e1ff" dir="rtl"><!--DWLayoutEmptyCell-->&nbsp; 
									
								</td>
							</tr>
							<tr>
								<td width="1" height="1"></td>
								<td width="216"></td>
							</tr>
							<tr>
								<td height="433"></td>
								<td valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
										<!--DWLayoutTable-->
										<tr>
											<td width="219" height="301" valign="top"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<!--DWLayoutTable-->
													<tr>
														<td width="152" height="278" valign="top"><asp:panel id="Panel1" runat="server" Height="264px" BorderWidth="0px">
																<TABLE id="Table3" borderColor="#ffffff" height="256" cellSpacing="1" cellPadding="1" width="141"
																	bgColor="#caeeff" border="0">
																	<TR>
																		<TD class="ColumnText" height="23">اضافه کردن فایل</TD>
																	</TR>
																	<TR>
																		<TD bgColor="#caeeff" height="190">
																			<asp:ListBox id="ListBoxAttachments" runat="server" SelectionMode="single" CssClass="ListBox"
																				Width="132px"></asp:ListBox></TD>
																	</TR>
																	<TR>
																		<TD>
																			<TABLE id="Table4" height="27" cellSpacing="1" cellPadding="1" width="132" border="0">
																				<TR>
																					<TD>
																						<asp:Button id="deattach" runat="server" Width="46px" Font-Names="Tahoma" Text="حذف" ToolTip="Delete the selected attachment."></asp:Button></TD>
																					<TD>
																						<asp:button id="attach" runat="server" Font-Names="Tahoma" Text="اضافه" ToolTip="Attach new attachment."></asp:button></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</asp:panel></td>
													</tr>
												</table>
											</td>
											<td width="1"></td>
										</tr>
										<tr>
											<td height="132">&nbsp;</td>
											<td></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="504" colspan="7" valign="top" bgcolor="#a4e1ff">
						<table cellSpacing="0" cellPadding="0" border="0" height="100%">
							<!--DWLayoutTable-->
							<tr>
								<td height="478" vAlign="top" bgColor="#a4e1ff">
									<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#a4e1ff" border="0">
										<!--DWLayoutTable-->
										<tr>
											<td class="to" vAlign="top" width="52" bgColor="#c1e0ff" height="22">To:</td>
											<td width="440" vAlign="top"><asp:textbox id="to" runat="server" CssClass="txtbox" MaxLength="200" ToolTip="To"></asp:textbox></td>
										</tr>
										<tr>
											<td class="to" vAlign="top" bgColor="#c1e0ff" height="22">Cc:</td>
											<td vAlign="top"><asp:textbox id="cc" runat="server" CssClass="txtbox" MaxLength="200" ToolTip="Cc"></asp:textbox></td>
										</tr>
										<tr>
											<td class="to" vAlign="top" bgColor="#c1e0ff" height="22">Bcc:</td>
											<td vAlign="top"><asp:textbox id="bcc" runat="server" CssClass="txtbox" MaxLength="200" ToolTip="Bcc"></asp:textbox></td>
										</tr>
										<tr>
											<td class="to" vAlign="top" bgColor="#c1e0ff" height="22">Subject:</td>
											<td vAlign="top"><asp:textbox id="subject" runat="server" CssClass="txtbox" MaxLength="500" ToolTip="Subject"></asp:textbox></td>
										</tr>
										<tr>
											<td height="390" colSpan="2" vAlign="top">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<!--DWLayoutTable-->
													<tr>
														<td vAlign="top" width="504" height="346"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<!--DWLayoutTable-->
																<tr>
																	<td width="505" height="346"><FTB:FREETEXTBOX id="message" runat="Server"><TOOLBARS>
																				<FTB:TOOLBAR runat="server">
																					<FTB:TOOLBARBUTTON title="SpellCheck" runat="server" ButtonImage="spellcheck" FunctionName="FTB_SpellCheck">function 
                              FTB_SpellCheck(ftbName) { 
                              checkSpellingById(ftbName + "_Editor"); } 
                              </FTB:TOOLBARBUTTON>
																				</FTB:TOOLBAR>
																			</TOOLBARS>
																		</FTB:FREETEXTBOX></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td height="20"><asp:checkbox id="IsSave" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Bold="True"
																Font-Names="Tahoma" Text="ذخیره این ایمیل به پوشه ایمیل های ارسال شده" ToolTip="Save this composition to your Sent box."></asp:checkbox></td>
													</tr>
												</table>
												<asp:button id="send" runat="server" Text="ارسال" ToolTip="Send this composition by Cyber Mail Server."
													Font-Names="Tahoma"></asp:button>
												<asp:button id="cancel" runat="server" Text="انصراف" ToolTip="Cancel this composition." Font-Names="Tahoma"></asp:button></td>
										</tr>
									</table>
								</td>
								<td width="131" vAlign="top" bgColor="#a4e1ff">
									<table cellSpacing="0" cellPadding="0" bgColor="#a4e1ff" border="0">
										<!--DWLayoutTable-->
										<tr>
											<td width="131" height="112" vAlign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
													<!--DWLayoutTable-->
													<tr>
														<td width="194" height="23" valign="top"><asp:Label id="ToError" runat="server" Font-Names="Arial" Font-Bold="True" ForeColor="Red"
																Width="150px" BackColor="Yellow" Font-Size="XX-Small" BorderWidth="1px" Visible="False" BorderColor="Black"></asp:Label></td>
													</tr>
													<tr>
														<td height="21" valign="top">
															<asp:Label id="CcError" runat="server" Font-Names="Arial" Font-Bold="True" Font-Size="XX-Small"
																ForeColor="Red" BorderWidth="1px" Width="150px" Visible="False" BackColor="Yellow" BorderColor="Black"></asp:Label></td>
													</tr>
													<tr>
														<td height="22" valign="top">
															<asp:Label id="BccError" runat="server" Font-Names="Arial" Font-Bold="True" Font-Size="XX-Small"
																ForeColor="Red" BorderWidth="1px" Width="150px" Visible="False" BackColor="Yellow" BorderColor="Black"></asp:Label></td>
													</tr>
													<tr>
														<td height="23" valign="top">
															<asp:Label id="SubjectError" runat="server" Font-Names="Arial" Font-Bold="True" Font-Size="XX-Small"
																ForeColor="Red" BorderWidth="1px" Width="150px" Visible="False" BackColor="Yellow" BorderColor="Black"></asp:Label></td>
													</tr>
													<tr>
														<td height="23">
															<asp:Label id="MessageError" runat="server" Font-Names="Arial" Font-Bold="True" Font-Size="XX-Small"
																ForeColor="Red" BorderWidth="1px" Width="150px" Visible="False" BackColor="Yellow" BorderColor="Black"></asp:Label></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="366" bgcolor="#a4e1ff">&nbsp;</td>
										</tr>
									</table>
								</td>
								<td colspan="2" vAlign="top"><!--DWLayoutEmptyCell-->&nbsp; 
								</td>
								<td width="135">&nbsp;</td>
							</tr>
							<tr bgcolor="#a4e1ff">
								<td height="25" colspan="3" vAlign="top"><!--DWLayoutEmptyCell-->&nbsp; 
								</td>
								<td width="9"></td>
								<td></td>
							</tr>
							<tr bgcolor="#a4e1ff">
								<td height="1"></td>
								<td></td>
								<td width="24"></td>
								<td></td>
								<td></td>
							</tr>
						</table>
					</td>
					<td bgcolor="#ffffff">&nbsp;</td>
				</tr>
				<tr>
					<td height="33" colspan="7" valign="top" bgcolor="#caeeff" dir="rtl">
						<div align="right">
						</div>
					</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td height="5"></td>
					<td width="72"></td>
					<td width="74"></td>
					<td width="5"></td>
					<td width="224"></td>
					<td width="124"></td>
					<td width="68"></td>
					<td></td>
				</tr>
				<tr>
					<td height="20">&nbsp;</td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td width="180">&nbsp;</td>
					<td></td>
				</tr>
				<tr>
					<td height="34" colspan="10" valign="top">
						<p align="center" class="style9">
							You are used 8% of your mailbox storage</p>
					</td>
				</tr>
				<tr>
					<td height="38" colspan="10" align="center" valign="top">
					<span class="style8"><font size="2">©&nbsp;Copyright 2005
					<span lang="en-us">PMail</span>. All rights reserved.</font>
                    </span> </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

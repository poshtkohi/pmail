<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page language="c#" Codebehind="Compose.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.Compose" validaterequest="false" Trace="false" %>
<HTML>
	<HEAD>
		<title>Compose new message.</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<style type="text/css">
	.txtbox { BORDER-RIGHT: 0px ridge; BORDER-TOP: 0px ridge; FONT-SIZE: x-small; BORDER-LEFT: 0px ridge; WIDTH: 550px; BORDER-BOTTOM: 0px ridge; FONT-FAMILY: Tahoma; HEIGHT: 20px }
	.ListBox { WIDTH: 200px; HEIGHT: 200px }
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
	.style4 { COLOR: #660000 }
	.style5 { FONT-SIZE: x-small; COLOR: #660000; FONT-FAMILY: Tahoma }
	.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
	.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
	.style2 { COLOR: #0033ff; FONT-FAMILY: Tahoma }
	.style3 { FONT-SIZE: xx-small }
	.to { FONT-WEIGHT: bolder; FONT-SIZE: x-small; COLOR: #6600ff; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
	.style4 { FONT-SIZE: xx-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
	.boxes311 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
	</style>
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
		<script language="JavaScript" src="spell.js" type="text/javascript"></script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		onload="FP_preloadImgs(/*url*/'images/button23.gif', /*url*/'images/button24.gif', /*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button29.gif', /*url*/'images/button2A.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif')">
		<table height="558" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<!--DWLayoutTable-->
			<tr>
				<td height="24" colspan="4" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
						<!--DWLayoutTable-->
						<tr>
							<td width="368" height="24" valign="top"><font face="Arial">welcome&nbsp;
									<%=this.Session["username"]%>
								</font>
							</td>
							<td width="336" valign="top"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></td>
							<td width="353" valign="top"><div align="left">
								<a href="/about.aspx">
								<font face="Arial" size="2">About PMail</font></a><font face="Arial" size="2"> | Help</font></div>
							</td>
							<td width="33" valign="top" bgcolor="#c1e0ff"><div align="center"><span class="folders"><a href="/email/fa/Compose.aspx">FA</a></span></div>
							</td>
						</tr>
						<tr>
							<td height="0"></td>
							<td></td>
							<td colspan="2"></td>
						</tr>
					</table>
				</td>
				<td width="1"></td>
			</tr>
			<tr>
				<td height="29" colspan="2" valign="top"><IMG height="89" alt="PMail Service" src="/images/arm1.jpg" width="279"></td>
				<td width="100%" valign="top"><!--DWLayoutEmptyCell-->&nbsp; 
			  </td>
				<td width="226" valign="top"><div align="right"><a href="?i=signout"><IMG src="images/email_06.gif" alt="" width="85" height="29" border="0"></a></div>
				</td>
				<td></td>
			</tr>
			<tr>
				<td width="90" height="27" valign="top" bgcolor="#ffffe6"><!--DWLayoutEmptyCell-->&nbsp; 
					
				</td>
				<td colspan="3" valign="top" bgcolor="#ffffe6"><div align="right"><img onMouseUp="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button23.gif')" onMouseDown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button24.gif')"
							id="img1" onMouseOver="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button23.gif')" onMouseOut="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button22.gif')"
							height="22" alt="Compose" src="images/button22.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"
							fp-title="Compose"> <a href="ShowAddressBook.aspx"><IMG onmouseup="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button26.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button27.gif')"
								id="img4" onmouseover="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button26.gif')" onmouseout="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button25.gif')"
								height="22" alt="Address book" src="images/button25.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"
								fp-title="Address book"></a></div>
				</td>
				<td></td>
			</tr>
			<tr>
				<td rowspan="2" valign="top" bgcolor="#c1e0ff"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<!--DWLayoutTable-->
						<tr>
							<td vAlign="top" width="95" bgColor="#c1e0ff" height="23"><span class="folders" title="Available Foldrs">Folders</span>
							</td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><!--DWLayoutEmptyCell-->&nbsp; 
							</td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes"><IMG height="12" src="images/inbox.gif" width="15">&nbsp;<A title="Inbox Folder" href="/email/?ShowFolder=Inbox" target="_self">Inbox</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes1"><IMG height="12" src="images/draft.gif" width="15">&nbsp;<A title="Draft Folder" href="/email/?ShowFolder=Draft" target="_self">Draft</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes4"><IMG height="12" src="images/sent.gif" width="15">&nbsp;<A title="Sent Folder" href="/email/?ShowFolder=Sent">Sent</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes21"><IMG height="12" src="images/bulk.gif" width="15">&nbsp;<A title="Bulk Folder" href="/email/?ShowFolder=Bulk" target="_self">Bulk</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes311"><IMG height="12" src="images/trash.gif" width="13">&nbsp;<A href="/email/?ShowFolder=Trash" title="Trash Folder">Trash</A> (<a href="?EmptyTrash=1">Empty</a>)</span></td>
						</tr>
						<tr>
							<td height="403" bgcolor="#c1e0ff">&nbsp;</td>
						</tr>
					</table>
				</td>
				<td height="22" colspan="3" valign="top" bgcolor="#ffffe6"><div align="right"><font face="Arial" color="#808000" size="2">You 
							are used 8% of your Mailbox storage </font>
					</div>
				</td>
				<td></td>
			</tr>
			<tr>
				<td height="518" colspan="3" valign="top">
					<form runat="server" method="post">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
							<!--DWLayoutTable-->
							<tr>
								<td vAlign="top" width="599" bgColor="#c1e0ff" height="454">
									<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#c1e0ff" border="0">
										<!--DWLayoutTable-->
										<tr>
											<td class="to" vAlign="top" width="52" bgColor="#c1e0ff" height="22">To:</td>
											<td vAlign="top" width="300"><asp:textbox id="to" runat="server" CssClass="txtbox" MaxLength="200" ToolTip="To"></asp:textbox></td>
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
											<td vAlign="top" colSpan="3" height="366">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<!--DWLayoutTable-->
													<tr>
														<td vAlign="top" width="504" height="346"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<!--DWLayoutTable-->
																<tr>
																	<td width="505" height="346"><FTB:FREETEXTBOX id="message" runat="Server"><TOOLBARS>
																				<FTB:TOOLBAR runat="server">
																					<FTB:TOOLBARBUTTON title="SpellCheck" runat="server" FunctionName="FTB_SpellCheck" ButtonImage="spellcheck">function 
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
																Font-Names="Tahoma" Text="Save to your Sent box." ToolTip="Save this composition to your Sent box."></asp:checkbox></td>
													</tr>
												</table>
												<asp:button id="send" runat="server" Text="Send" ToolTip="Send this composition by Cyber Mail Server."></asp:button><asp:button id="cancel" runat="server" Text="Cansel" ToolTip="Cancel this composition."></asp:button></td>
										</tr>
									</table>
								</td>
								<td vAlign="top" width="397" bgColor="#c1e0ff">
									<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#c1e0ff" border="0">
										<!--DWLayoutTable-->
										<tr>
											<td width="194" height="110" vAlign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
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
											<td width="200" vAlign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
													<!--DWLayoutTable-->
													<tr>
														<td width="200" height="110">&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="346" colspan="2" vAlign="top">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<!--DWLayoutTable-->
													<tr bgcolor="#ffffe5">
														<td height="40" colspan="3" align="center" valign="top"><span class="style4">*You can only type a mail address in left fields meaning To,Cc,Bcc.</span><span class="style3"><br>
																<span class="style2">*For deleting an attachment, after selection related item, click Delete.<br>
                        *For adding attachments in to your mail, click Attach button. </span>
															</span></td>
													</tr>
													<tr>
														<td width="80" height="28">&nbsp;</td>
														<td width="222">&nbsp;</td>
														<td width="92">&nbsp;</td>
													</tr>
													<tr>
														<td height="278">&nbsp;</td>
														<td vAlign="top">
															<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<!--DWLayoutTable-->
																<tr>
																	<td width="152" height="278" valign="top"><asp:panel id="Panel1" runat="server" Height="264px" BorderWidth="0px">
																			<TABLE id="Table3" borderColor="#ffffff" height="256" cellSpacing="1" cellPadding="1" width="141"
																				bgColor="#c1e0ff" border="0">
																				<TR>
																					<TD class="ColumnText" height="23">Your Attachments</TD>
																				</TR>
																				<TR>
																					<TD height="190">
																						<asp:ListBox id="ListBoxAttachments" runat="server" CssClass="ListBox" Width="132px" SelectionMode="single"></asp:ListBox></TD>
																				</TR>
																				<TR>
																					<TD>
																						<TABLE id="Table4" height="27" cellSpacing="1" cellPadding="1" width="132" border="0">
																							<TR>
																								<TD>
																									<asp:Button id="deattach" runat="server" ToolTip="Delete the selected attachment." Text="Delete"
																										Width="46px"></asp:Button></TD>
																								<TD>
																									<asp:button id="attach" runat="server" ToolTip="Attach new attachment." Text="Attach"></asp:button></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																			</TABLE>
																		</asp:panel></td>
																</tr>
															</table>
														</td>
														<td>&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="15" bgcolor="#c1e0ff"></td>
								<td bgcolor="#c1e0ff"></td>
							</tr>
							<tr bgcolor="#ffffe6">
								<td height="25" colspan="2" valign="top"><!--DWLayoutEmptyCell-->&nbsp; 
								</td>
							</tr>
						</table>
					</form>
				</td>
				<td></td>
			</tr>
			<tr>
				<td height="26" colspan="4" valign="top"><div align="center"><font color="#808000">You are 
							used 8% of your mailbox storage </font>
					</div>
				</td>
				<td></td>
			</tr>
			<tr>
				<td height="32" colspan="4" valign="top"><div align="center">
					<span class="copy"><font face="Arial" color="#808000">&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>
					<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © Copyright 2005 
					PMail. All rights reserved.</b></font></span><b><font face="Arial" color="#808000">
				  </font></b>
			    </div>
				</td>
				<td></td>
			</tr>
			<tr>
				<td height="24">&nbsp;</td>
				<td width="100%">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td height="1"><img src="images/spacert.gif" alt="" width="90" height="1"></td>
				<td></td>
				<td></td>
				<td><img src="images/spacert.gif" alt="" width="226" height="1"></td>
				<td><img src="images/spacert.gif" alt="" width="1" height="1"></td>
			</tr>
		</table>
	</body>
</HTML>

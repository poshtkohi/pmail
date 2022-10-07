<%@ Page language="c#" Codebehind="SignUp.aspx.cs" AutoEventWireup="false" Inherits="pmail.SignUp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>سیستم جامع پست الکترونیکی دانشگاه آزاد آسلامی قزوین</TITLE>
		<meta http-equiv="Content-Language" content="en-us">
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="images/waqua.css" type="text/css" rel="STYLESHEET">
			<style type="text/css">.txtBox { WIDTH: 200px }
	</style>
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<CENTER>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="725" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" noWrap align="left" colSpan="4"><p dir="rtl" align="center">
												<font face="Tahoma">امنیت پست الکترونیکی شما هم اکنون با استفاده از SSL3 برقرار 
													است.(Secure Socket Layer Version3 used by HTTPS)</font></p>
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" noWrap align="left" height="18"><IMG height="1" alt=" " src="images/spacer.gif" width="4" border="0"></TD>
										<TD colSpan="3"><IMG height="1" alt=" " src="images/spacer.gif" width="9" border="0"></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="4" height="3"><IMG height="5" alt=" " src="images/spacer.gif" width="1" border="0"></TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE height="643" cellSpacing="0" cellPadding="0" width="736" align="center" border="0">
				<!--DWLayoutTable-->
				<tr>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD height="28"></TD>
				</tr>
				<tr>
					<TD vAlign="top" align="right" background="images/frameleft.gif"><IMG height="10" alt="" src="images/frame_upleft.gif" width="112" border="0"></TD>
					<TD vAlign="top" align="left" background="images/frame_topbg.gif"></TD>
					<TD vAlign="top" align="left" background="images/frameright.gif"><IMG height="10" alt="" src="images/frame_upright.gif" width="72" border="0"></TD>
					<TD height="18"></TD>
				</tr>
				<tr>
					<TD vAlign="top" align="right" width="112" background="images/frameleft.gif" rowSpan="3"><IMG height="175" alt="" src="images/frameleft.gif" width="112" border="0"></TD>
					<TD vAlign="top" align="left">
						<div align="center"><a href="/"><IMG src="/images/arm1.jpg" alt="اولین سیستم جامع فارسی زبان پست الکترونیکی"
									width="279" height="89" border="0"></a></div>
					</TD>
					<TD vAlign="top" align="left" width="72" background="images/frameright.gif" rowSpan="3"><IMG height="17" alt="" src="/images/lock.gif" width="72" border="0"><BR>
						<IMG height="158" alt="" src="images/frameright.gif" width="72" border="0"></TD>
					<td height="89"></td>
				</tr>
				<tr>
					<TD vAlign="top">
						<form runat="server">
							<table id="main" borderColor="#000000" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff"
								border="0">
								<!--DWLayoutTable-->
								<tr>
									<td vAlign="top" borderColor="#f2f2f2" width="342" bgColor="#ffffff" height="440">
										<table height="460" cellSpacing="0" cellPadding="0" width="478" bgColor="#ffffff" border="0">
											<!--DWLayoutTable-->
											<tr>
												<td vAlign="top" colSpan="6" height="32">
													<P align="justify" dir="rtl">
														<font color="#ff0000" style="FONT-SIZE: 11pt"><b>&nbsp; لطفا فرم زیر را با دقت پر کنید.</b></font></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="EmailError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="email" runat="server" ToolTip="Email" MaxLength="50" CssClass="txtbox"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="22"><asp:label id="UsernameError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="username" runat="server" ToolTip="Username" MaxLength="50" CssClass="txtbox"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="PasswordError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="password" runat="server" ToolTip="Password" MaxLength="50" CssClass="txtbox"
															TextMode="Password"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="6" height="32">
													<p align="right" dir="rtl">
														<font size="2" face="Tahoma"><font color="#ff0000">*</font>تعداد حروف کلمه عبور 
															باید حداقل شش حرف باشد.</font></p>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="22"><span class="disclaimer"><asp:label id="ConfirmPasswordError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
															BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label>
													</span></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="ConfirmPassword" runat="server" ToolTip="Confirm Password" MaxLength="50" CssClass="txtbox"
															TextMode="Password"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><!--DWLayoutEmptyCell-->&nbsp; 
												</td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:radiobutton id="male" runat="server" ToolTip="Male" Font-Names="Tahoma" Text="مرد" GroupName="sex"
															Checked="True" TextAlign="Left"></asp:radiobutton><asp:radiobutton id="female" runat="server" ToolTip="Female" Font-Names="Tahoma" Text="زن" GroupName="sex"
															TextAlign="Left"></asp:radiobutton></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="CountryError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:dropdownlist id="country" runat="server" Width="192px" Font-Names="Tahoma">
															<asp:ListItem Value="none">انتخاب کنید</asp:ListItem>
															<asp:ListItem Value="australia">استرالیا</asp:ListItem>
															<asp:ListItem Value="canada">کانادا</asp:ListItem>
															<asp:ListItem Value="france">فرانسه</asp:ListItem>
															<asp:ListItem Value="germany">آلمان</asp:ListItem>
															<asp:ListItem Value="holland">هلند</asp:ListItem>
															<asp:ListItem Value="iran">ایران</asp:ListItem>
															<asp:ListItem Value="peru">پرو</asp:ListItem>
															<asp:ListItem Value="spain">اسپانیا</asp:ListItem>
															<asp:ListItem Value="uk">بریتانیا</asp:ListItem>
															<asp:ListItem Value="usa">ایالات متحده آمریکا</asp:ListItem>
															<asp:ListItem Value="other">دیگر</asp:ListItem>
														</asp:dropdownlist></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="ZipCodeError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="ZipCode" runat="server" ToolTip="Zip Code" MaxLength="50" CssClass="txtbox"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td width="106" height="24" vAlign="top">&nbsp;
												</td>
												<td width="12" vAlign="top">&nbsp;</td>
												<td vAlign="top" colSpan="4">
													<P align="right"><asp:dropdownlist id="SecurityQuestion" runat="server" Width="200px" Font-Names="Tahoma">
															<asp:ListItem Value="0" Selected="True">نام مدرسه ابتداییتان چیست؟</asp:ListItem>
															<asp:ListItem Value="1">نام حیوان مورد علاقه تان چیست؟</asp:ListItem>
															<asp:ListItem Value="2">نام پدر بزرگتان چیست؟</asp:ListItem>
															<asp:ListItem Value="3">نام دوستتان چیست؟</asp:ListItem>
														</asp:dropdownlist></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="6" height="32">
													<p dir="rtl"><span style="FONT-SIZE: x-small"><font color="#ff0000">*</font><font face="Tahoma">این 
																گزینه برای بازیابی کلمه عبور فراموش شده به کار خواهد رفت.</font></span></p>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="AnswerError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="answer" runat="server" ToolTip="Answer" CssClass="txtbox"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td height="24" vAlign="top">
													<div align="right">
														<asp:label id="BirthDateError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
															BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label>
													</div>
												</td>
												<td colSpan="3" vAlign="top">
													<div align="right">
														<asp:dropdownlist id="year" runat="server" CssClass="txtBoxStyleLogin" Width="120px" Font-Names="Tahoma">
															<asp:ListItem Value="none" Selected="True">انتخاب کنید</asp:ListItem>
															<asp:ListItem Value="2000">2000</asp:ListItem>
															<asp:ListItem Value="1999">1999</asp:ListItem>
															<asp:ListItem Value="1998">1998</asp:ListItem>
															<asp:ListItem Value="1997">1997</asp:ListItem>
															<asp:ListItem Value="1996">1996</asp:ListItem>
															<asp:ListItem Value="1995">1995</asp:ListItem>
															<asp:ListItem Value="1994">1994</asp:ListItem>
															<asp:ListItem Value="1993">1993</asp:ListItem>
															<asp:ListItem Value="1992">1992</asp:ListItem>
															<asp:ListItem Value="1991">1991</asp:ListItem>
															<asp:ListItem Value="1990">1990</asp:ListItem>
															<asp:ListItem Value="1989">1989</asp:ListItem>
															<asp:ListItem Value="1988">1988</asp:ListItem>
															<asp:ListItem Value="1987">1987</asp:ListItem>
															<asp:ListItem Value="1986">1986</asp:ListItem>
															<asp:ListItem Value="1985">1985</asp:ListItem>
															<asp:ListItem Value="1984">1984</asp:ListItem>
															<asp:ListItem Value="1983">1983</asp:ListItem>
															<asp:ListItem Value="1982">1982</asp:ListItem>
															<asp:ListItem Value="1981">1981</asp:ListItem>
															<asp:ListItem Value="1980">1980</asp:ListItem>
															<asp:ListItem Value="1979">1979</asp:ListItem>
															<asp:ListItem Value="1978">1978</asp:ListItem>
															<asp:ListItem Value="1976">1976</asp:ListItem>
															<asp:ListItem Value="1975">1975</asp:ListItem>
															<asp:ListItem Value="1974">1974</asp:ListItem>
															<asp:ListItem Value="1973">1973</asp:ListItem>
															<asp:ListItem Value="1972">1972</asp:ListItem>
															<asp:ListItem Value="1971">1971</asp:ListItem>
															<asp:ListItem Value="1970">1970</asp:ListItem>
															<asp:ListItem Value="1969">1969</asp:ListItem>
															<asp:ListItem Value="1968">1968</asp:ListItem>
															<asp:ListItem Value="1967">1967</asp:ListItem>
															<asp:ListItem Value="1966">1966</asp:ListItem>
															<asp:ListItem Value="1965">1965</asp:ListItem>
															<asp:ListItem Value="1964">1964</asp:ListItem>
															<asp:ListItem Value="1963">1963</asp:ListItem>
															<asp:ListItem Value="1962">1962</asp:ListItem>
															<asp:ListItem Value="1961">1961</asp:ListItem>
															<asp:ListItem Value="1960">1960</asp:ListItem>
															<asp:ListItem Value="1959">1959</asp:ListItem>
															<asp:ListItem Value="1958">1958</asp:ListItem>
															<asp:ListItem Value="1957">1957</asp:ListItem>
															<asp:ListItem Value="1956">1956</asp:ListItem>
															<asp:ListItem Value="1955">1955</asp:ListItem>
															<asp:ListItem Value="1954">1954</asp:ListItem>
															<asp:ListItem Value="1953">1953</asp:ListItem>
															<asp:ListItem Value="1954">1954</asp:ListItem>
															<asp:ListItem Value="1953">1953</asp:ListItem>
															<asp:ListItem Value="1952">1952</asp:ListItem>
															<asp:ListItem Value="1951">1951</asp:ListItem>
															<asp:ListItem Value="1950">1950</asp:ListItem>
															<asp:ListItem Value="1949">1949</asp:ListItem>
															<asp:ListItem Value="1948">1948</asp:ListItem>
															<asp:ListItem Value="1947">1947</asp:ListItem>
															<asp:ListItem Value="1946">1946</asp:ListItem>
															<asp:ListItem Value="1945">1945</asp:ListItem>
															<asp:ListItem Value="1944">1944</asp:ListItem>
															<asp:ListItem Value="1943">1943</asp:ListItem>
															<asp:ListItem Value="1942">1942</asp:ListItem>
															<asp:ListItem Value="1941">1941</asp:ListItem>
															<asp:ListItem Value="1940">1940</asp:ListItem>
															<asp:ListItem Value="1939">1939</asp:ListItem>
															<asp:ListItem Value="1938">1938</asp:ListItem>
															<asp:ListItem Value="1937">1937</asp:ListItem>
															<asp:ListItem Value="1936">1936</asp:ListItem>
															<asp:ListItem Value="1935">1935</asp:ListItem>
															<asp:ListItem Value="1934">1934</asp:ListItem>
															<asp:ListItem Value="1933">1933</asp:ListItem>
															<asp:ListItem Value="1932">1932</asp:ListItem>
															<asp:ListItem Value="1931">1931</asp:ListItem>
															<asp:ListItem Value="1930">1930</asp:ListItem>
															<asp:ListItem Value="1929">1929</asp:ListItem>
															<asp:ListItem Value="1928">1928</asp:ListItem>
															<asp:ListItem Value="1927">1927</asp:ListItem>
															<asp:ListItem Value="1926">1926</asp:ListItem>
															<asp:ListItem Value="1925">1925</asp:ListItem>
															<asp:ListItem Value="1924">1924</asp:ListItem>
															<asp:ListItem Value="1923">1923</asp:ListItem>
															<asp:ListItem Value="1922">1922</asp:ListItem>
															<asp:ListItem Value="1921">1921</asp:ListItem>
															<asp:ListItem Value="1920">1920</asp:ListItem>
															<asp:ListItem Value="1919">1919</asp:ListItem>
															<asp:ListItem Value="1918">1918</asp:ListItem>
															<asp:ListItem Value="1917">1917</asp:ListItem>
															<asp:ListItem Value="1916">1916</asp:ListItem>
															<asp:ListItem Value="1915">1915</asp:ListItem>
															<asp:ListItem Value="1914">1914</asp:ListItem>
															<asp:ListItem Value="1913">1913</asp:ListItem>
															<asp:ListItem Value="1912">1912</asp:ListItem>
															<asp:ListItem Value="1911">1911</asp:ListItem>
															<asp:ListItem Value="1910">1910</asp:ListItem>
															<asp:ListItem Value="1909">1909</asp:ListItem>
															<asp:ListItem Value="1908">1908</asp:ListItem>
															<asp:ListItem Value="1907">1907</asp:ListItem>
															<asp:ListItem Value="1906">1906</asp:ListItem>
															<asp:ListItem Value="1905">1905</asp:ListItem>
															<asp:ListItem Value="1904">1904</asp:ListItem>
															<asp:ListItem Value="1903">1903</asp:ListItem>
															<asp:ListItem Value="1902">1902</asp:ListItem>
															<asp:ListItem Value="1901">1901</asp:ListItem>
															<asp:ListItem Value="1900">1900</asp:ListItem>
														</asp:dropdownlist>
													</div>
												</td>
												<td vAlign="top" width="70">
													<div align="right">
														<asp:dropdownlist id="day" runat="server" Width="70px" Font-Names="Tahoma">
															<asp:ListItem Value="none" Selected="True">انتخاب کنید</asp:ListItem>
															<asp:ListItem Value="1">1</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9">9</asp:ListItem>
															<asp:ListItem Value="10">10</asp:ListItem>
															<asp:ListItem Value="11">11</asp:ListItem>
															<asp:ListItem Value="12">12</asp:ListItem>
															<asp:ListItem Value="13">13</asp:ListItem>
															<asp:ListItem Value="14">14</asp:ListItem>
															<asp:ListItem Value="15">15</asp:ListItem>
															<asp:ListItem Value="16">16</asp:ListItem>
															<asp:ListItem Value="17">17</asp:ListItem>
															<asp:ListItem Value="18">18</asp:ListItem>
															<asp:ListItem Value="19">19</asp:ListItem>
															<asp:ListItem Value="20">20</asp:ListItem>
															<asp:ListItem Value="21">21</asp:ListItem>
															<asp:ListItem Value="22">22</asp:ListItem>
															<asp:ListItem Value="23">23</asp:ListItem>
															<asp:ListItem Value="24">24</asp:ListItem>
															<asp:ListItem Value="25">25</asp:ListItem>
															<asp:ListItem Value="26">26</asp:ListItem>
															<asp:ListItem Value="27">27</asp:ListItem>
															<asp:ListItem Value="28">28</asp:ListItem>
															<asp:ListItem Value="29">29</asp:ListItem>
															<asp:ListItem Value="30">30</asp:ListItem>
															<asp:ListItem Value="31">31</asp:ListItem>
														</asp:dropdownlist>
													</div>
												</td>
												<td vAlign="top" width="60">
													<div align="right">
														<asp:dropdownlist id="month" runat="server" Width="60" Font-Names="Tahoma">
															<asp:ListItem Value="none" Selected="True">.انتخاب کنید</asp:ListItem>
															<asp:ListItem Value="1">January</asp:ListItem>
															<asp:ListItem Value="2">February</asp:ListItem>
															<asp:ListItem Value="3">March</asp:ListItem>
															<asp:ListItem Value="4">April</asp:ListItem>
															<asp:ListItem Value="5">May</asp:ListItem>
															<asp:ListItem Value="6">June</asp:ListItem>
															<asp:ListItem Value="7">July</asp:ListItem>
															<asp:ListItem Value="8">August</asp:ListItem>
															<asp:ListItem Value="9">September</asp:ListItem>
															<asp:ListItem Value="10">October</asp:ListItem>
															<asp:ListItem Value="11">November</asp:ListItem>
															<asp:ListItem Value="12">December</asp:ListItem>
														</asp:dropdownlist>
													</div>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="6" height="24">
													<div align="right"><span style="FONT-SIZE: x-small">(YY/DD/MM)</span></div>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><asp:label id="PhoneError" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Red"
														BackColor="#FFFF80" Width="232px" Font-Names="Tahoma"></asp:label></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:textbox id="phone" runat="server" ToolTip="Phone Number" MaxLength="50" CssClass="txtbox"></asp:textbox></P>
												</td>
											</tr>
											<tr>
												<td vAlign="top" colSpan="3" height="24"><font face="Tahoma" size="1"></font></td>
												<td vAlign="top" colSpan="3">
													<P align="right"><asp:dropdownlist id="profession" runat="server" CssClass="txtBoxStyleLogin" Width="200px" Font-Names="Tahoma">
															<asp:ListItem Value="none" Selected="True">انتخاب کنید</asp:ListItem>
															<asp:ListItem Value="electronics">الکترونیک</asp:ListItem>
															<asp:ListItem Value="public">عمومی</asp:ListItem>
															<asp:ListItem Value="computer">کامپیوتر</asp:ListItem>
															<asp:ListItem Value="medical">پزشکی</asp:ListItem>
															<asp:ListItem Value="merchant">تاجر</asp:ListItem>
															<asp:ListItem Value="engineering">مهندسی</asp:ListItem>
															<asp:ListItem Value="networking">شبکه های کامپیوتری</asp:ListItem>
															<asp:ListItem Value="web">وب</asp:ListItem>
															<asp:ListItem Value="other">دیگر</asp:ListItem>
														</asp:dropdownlist></P>
												</td>
											</tr>
											<tr>
												<td height="35">&nbsp;</td>
												<td colSpan="5" align="center" vAlign="middle">
													<asp:button id="submit" runat="server" Width="79px" Font-Names="Tahoma" Text="ثبت نام"></asp:button>
													<div align="center"></div>
												</td>
											</tr>
											<tr>
												<td height="20">&nbsp;</td>
												<td>&nbsp;</td>
												<td width="32">&nbsp;</td>
												<td width="76">&nbsp;</td>
												<td>&nbsp;</td>
												<td>&nbsp;</td>
											</tr>
										</table>
									</td>
									<td vAlign="top" width="100">
										<table cellSpacing="0" cellPadding="0" width="70" border="0">
											<!--DWLayoutTable-->
											<tr>
												<td vAlign="top" width="70" height="30">&nbsp;
												</td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24">
													<p dir="ltr"><font face="Tahoma" size="2">&nbsp;ایمیل </font>
													</p>
												</td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="25"><font face="Tahoma" size="2">نام کاربری<font color="#ff0000">*</font></font></td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="25"><font face="Tahoma" size="2">کلمه عبور<font color="#ff0000">*</font></font></td>
											</tr>
											<tr>
												<td vAlign="top" height="28">&nbsp;
												</td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24">
													<p dir="rtl"><b><font face="Tahoma"><font color="#ff0000">*</font>تکرار کلمه عبور</font></b></p>
												</td>
											</tr>
											<tr>
												<td vAlign="top" height="23"><font face="Tahoma" size="2">جنسیت<font color="#ff0000">*</font></font></td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="25"><font face="Tahoma" size="2">کشور<font color="#ff0000">*</font></font></td>
											</tr>
											<tr>
												<td height="1"></td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24">
													<p dir="rtl" align="left"><font face="Tahoma" size="2"><font color="#ff0000">*</font>کد 
															پستی</font></p>
												</td>
											</tr>
											<tr>
												<td vAlign="top" height="22"><b><font face="Tahoma" size="1">سوال امنیتی<font color="#ff0000">*</font></font></b></td>
											</tr>
											<tr>
												<td vAlign="top" height="32">&nbsp;
												</td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24"><font face="Tahoma" size="2">پاسخ<font color="#ff0000">*</font></font></td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24"><font size="2">&nbsp;</font><font face="Tahoma" size="2">تولد<font color="#ff0000">*</font></font><font color="#ff0000">
													</font>
												</td>
											</tr>
											<tr>
												<td vAlign="top" height="24">&nbsp;
												</td>
											</tr>
											<tr>
												<td vAlign="top" bgColor="#ffffff" height="24"><font face="Tahoma" size="2">تلفن</font>
												</td>
											</tr>
											<tr>
												<td vAlign="top" height="25"><font face="Tahoma" size="2">حرفه</font>
												</td>
											</tr>
											<tr>
												<td vAlign="top" height="55">&nbsp;
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</form>
					</TD>
					<td height="479"></td>
				</tr>
				<tr>
					<TD width="548">
						<div align="center"><IMG height="13" alt="" src="images/frame_hr.gif" width="275" vspace="8" border="0"></div>
					</TD>
					<td width="4" height="29"></td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TBODY>
					<TR>
						<TD class="disclaimer" align="center" width="600"><a href="/about.aspx">About 
						PMail</a></TD>
					</TR>
				</TBODY>
			</TABLE>
			<!-- END CONTENT -->
			<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
				<TBODY>
					<TR>
						<TD class="disclaimer" align="center" width="600">
							<p dir="ltr">©&nbsp;Copyright 2005 PMail. All rights reserved.<BR>
							</p>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</CENTER>
	</BODY>
</HTML>

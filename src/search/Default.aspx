<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Search._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Search</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </head>
<body>
<form id=Default method=post runat="server">
<p><asp:label id=lblQuery runat="server" Width="100px">Query:</asp:label><asp:textbox id=txtQuery accessKey=Q runat="server" Width="300px"></asp:textbox><asp:RequiredFieldValidator id=reqValQuery runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" ControlToValidate="txtQuery">You must specify a query.</asp:RequiredFieldValidator><br><asp:label id=lblQueryType runat="server" Width="100px">Query Type:</asp:label><asp:dropdownlist id=cboQueryType accessKey=T runat="server" Width="300px">
<asp:ListItem Value="All" Selected="True">All Words</asp:ListItem>
<asp:ListItem Value="Any">Any Words</asp:ListItem>
<asp:ListItem Value="Boolean">Boolean Expression</asp:ListItem>
<asp:ListItem Value="Exact">Exact Expression</asp:ListItem>
<asp:ListItem Value="Natural">Natural Language</asp:ListItem>
</asp:dropdownlist><br><asp:label id=lblDirectory runat="server" Width="100px">Directory:</asp:label><asp:dropdownlist id=cboDirectory accessKey=D runat="server" Width="300px">
<asp:ListItem Value="/" Selected="True">Entire Site</asp:ListItem>
<asp:ListItem Value="/Products">Products</asp:ListItem>
<asp:ListItem Value="/Products/App1">Products: App1</asp:ListItem>
<asp:ListItem Value="/Products/App2">Products: App2</asp:ListItem>
<asp:ListItem Value="/Services">Services</asp:ListItem>
<asp:ListItem Value="/Help">Help</asp:ListItem>
</asp:dropdownlist><br><asp:label id=lblSortOrder runat="server" Width="100px">Sort Order:</asp:label><asp:dropdownlist id=cboSortBy accessKey=S runat="server" Width="135px">
<asp:ListItem Value="Rank" Selected="True">Search Rank</asp:ListItem>
<asp:ListItem Value="DocTitle">Document Title</asp:ListItem>
<asp:ListItem Value="Write">Last Modified</asp:ListItem>
</asp:dropdownlist><asp:dropdownlist id=cboSortOrder runat="server" Width="100px">
<asp:ListItem Value="ASC" Selected="True">Ascending</asp:ListItem>
<asp:ListItem Value="DESC">Descending</asp:ListItem>
</asp:dropdownlist><asp:button id=btnSearch runat="server" Text="Search"></asp:button></p>
<p><asp:label id=lblResultCount runat="server" Font-Italic="True" visible="False">X documents were found:</asp:label></p>
<p><asp:datagrid id=dgResultsGrid runat="server" PageSize="25" AllowPaging="True" AutoGenerateColumns="False" Visible="False" GridLines="None">
<itemstyle horizontalalign="Left" verticalalign="Top">
</ItemStyle>

<headerstyle font-bold="True">
</HeaderStyle>

<columns>
<asp:TemplateColumn HeaderText="Rank">
<headerstyle width="60px">
</HeaderStyle>

<itemtemplate>
<asp:Label id=Label1 runat="server" Text='<%# ((int)DataBinder.Eval(Container, "DataSetIndex")) + 1 %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Document Information">
<itemstyle horizontalalign="Left" verticalalign="Top">
</ItemStyle>

<itemtemplate>
<p><asp:hyperlink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "VPath")%>'><%# GetTitle(Container.DataItem)%></asp:hyperlink><br>
<asp:label runat="server"><%# GetCharacterization(Container.DataItem)%></asp:label><br>
<i><asp:hyperlink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "VPath")%>'>http://<%# Request.ServerVariables["SERVER_NAME"]%><%# DataBinder.Eval(Container.DataItem, "VPath")%></asp:hyperlink>
- Last Modified: <asp:label runat="server"><%# DataBinder.Eval(Container.DataItem, "Write")%></asp:label></i></p>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<pagerstyle mode="NumericPages">
</PagerStyle>
</asp:datagrid></p></form>
	
  </body>
</html>

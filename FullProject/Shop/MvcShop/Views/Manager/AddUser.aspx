<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<h2>Add User</h2>
<table>
<%=Html.ValidationSummary() %>
<%using (Html.BeginForm())
  { %>
  <tr>
<th>Acount data</th>
</tr>
<tr>
<td><%=Html.Label("Login") %></td>
<td><%=Html.TextBox("login", "")%></td></tr>
<tr>
<td><%=Html.Label("Password") %></td><td><%=Html.TextBox("password", "")%></td>
</tr>
<tr>
<th>Persenal data</th>
</tr>
<tr>
<td><%=Html.Label("First name") %></td><td><%=Html.TextBox("first", "")%></td>
</tr>
<tr>
<td><%=Html.Label("Last name") %></td><td><%=Html.TextBox("last", "")%></td></tr>
<tr>
<td><%=Html.Label("Address") %></td><td><%=Html.TextBox("address", "")%></td></tr>
<tr>
<td><%=Html.Label("Phone") %></td><td><%=Html.TextBox("phone", "")%></td>
</tr>
</table>
<p>Roles</p>
<%foreach(string name in Roles.GetAllRoles()){ %>
<%=Html.CheckBox(name,true) %><%=name%>
<%}%><br/>
<input type="submit" value="Save"/>

<%} %>
</asp:Content>

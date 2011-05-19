<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.ShippingDetails>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Resources.Global.CheckOut %>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2><%= Resources.Global.CheckOut %></h2>
<%= Resources.Global.PleaseEnter %>

<%= Html.ValidationSummary() %>
<% using (Html.BeginForm()) { %>
<table>
<tr>
<td colspan="2"><%=Resources.Global.ShipTo%> </td>
</tr>
<tr>
<td><%=Resources.Global.FirstName%></td>
<td> <%= Html.TextBox("Name",Profile["first"]) %> </td>
</tr>
<tr>
<td><%=Resources.Global.Phone%></td><td><%= Html.TextBox("NumberPhone",Profile["phone"]) %></td>
</tr>
<tr><td><%=Resources.Global.Address%></td><td><%= Html.TextBox("Address",Profile["address"]) %></td>
</tr>
<tr><td colspan="2"> <%=Resources.Global.PleaseDate%></td></tr>
<tr><td><%=Resources.Global.DateTime %></td> <td><%= Html.TextBox("OnDateTime", "",new { @class = "datepicker"} ) %></td></tr>
<tr><td colspan="2"><input type="submit" value="<%=Resources.Global.Complete%>" /></td></tr>
</table>
<% } %>

</asp:Content>

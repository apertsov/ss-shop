<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.ShippingDetails>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CheckOut   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Check Out Now</h2>
Please enter your details

<%= Html.ValidationSummary() %>
<% using (Html.BeginForm()) { %>
<table>
<tr>
<td colspan="2">Ship to </td>
</tr>
<tr>
<td>Name</td>
<td> <%= Html.TextBox("Name","") %> </td>
</tr>
<tr>
<td>Number phone</td><td><%= Html.TextBox("NumberPhone","") %></td>
</tr>
<tr><td>Address</td><td><%= Html.TextBox("Address","") %></td>
</tr>
<tr><td colspan="2"> If you want order by date and/or time please input data</td></tr>
<tr><td>Date & Time</td> <td><%= Html.TextBox("OnDateTime", "",new { @class = "datepicker"} ) %></td></tr>
<tr><td colspan="2"><input type="submit" value="Complete order" /></td></tr>
</table>
<% } %>

</asp:Content>

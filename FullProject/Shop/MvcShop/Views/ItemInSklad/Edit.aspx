<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.ItemInSklad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit Item In Sklad</h2>

<% var list = (ShopModel.Entities.ItemInSklad)ViewData["itemInSklad"]; %>

<table>
<tr>
<td><b>Id</b></td>
<td><b>Ingridient</b></td>
<td><b>PriceByKgOrOne</b></td>
<td><b>MinQuantity</b></td>
<td><b>Quantity</b></td>
<td></td>
</tr>
    <%using (Html.BeginForm("Edit", "ItemInSklad")) %>
    <% { %>
        <tr>
            <td><%= list.Id %>
                <%= Html.TextBox("Id",             list.Id,                        new { @style = "width: 1px; visibility:hidden;" }) %></td>
            <td><%= list.Ingridient.IngridientName %>
                <%= Html.TextBox("ing",            list.Ingridient.Id,             new { @style = "width: 1px; visibility:hidden;" }) %></td>
            <td><%= Html.TextBox("PriceByKgOrOne", list.PriceByKgOrOne,            new { @style = "width: 100px;" }) %></td>
            <td><%= Html.TextBox("MinQuantity",    list.MinQuantity,               new { @style = "width: 100px;" }) %></td>
            <td><%= Html.TextBox("Quantity",       list.Quantity,                  new { @style = "width: 100px;" }) %></td>
            <td><input type="submit" value="edit" name="ledit"/></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td>Add quantity:</td>
            <td><%= Html.TextBox("countAdd", "", new { @style = "width: 100px;" }) %></td>
            <td><input type="submit" value="add" name="add"/></td>
        </tr>
    <%} %>
</table>


</asp:Content>

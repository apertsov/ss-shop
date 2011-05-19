<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IngredientsEnd
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>IngredientsEnd</h2>

<% var list = (ShopModel.Entities.ItemInSklad[])ViewData["itemInSklad"]; %>
<table>
<tr>
<td><b>Id</b></td>
<td><b>Ingridient</b></td>
<td><b>PriceByKgOrOne</b></td>
<td><b>MinQuantity</b></td>
<td><b>Quantity</b></td>
<td><b>Difference</b></td>
</tr>
<% for (var i = 0; i < list.Length; i++) %>
<% { %>
  <% if (list[i].Quantity <= list[i].MinQuantity /* * 1.1 */)  %>
  <% { %>
    <tr>
            <td><%= list[i].Id%></td>
            <td><%= list[i].Ingridient.IngridientName%></td>
            <td><%= list[i].PriceByKgOrOne%></td>
            <td><%= list[i].MinQuantity%></td>
            <td><%= list[i].Quantity%></td>
            <td><%= list[i].Quantity - list[i].MinQuantity%></td>
    </tr>
  <% } %>
<%} %>
</table>


</asp:Content>

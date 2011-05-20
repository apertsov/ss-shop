﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GetAllOrder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>SearchByUser</h2>

<% var list = (ShopModel.Entities.Order[])ViewData["orders"]; %>

<table>
<tr bgcolor="fbd9d9">
<td><b>#</b></td>
<td><b>Name</b></td>
<td><b>Phone</b></td>
<td><b>Address</b></td>
<td><b>Ordered</b></td>
<td><b>Do On time</b></td>
<td><b>Status</b></td>
</tr>
<% for (int i = 0; i < list.Length; i++) %>
<% { %>
    <% string color = i % 2 == 0 ? "ebe6fd" : "f0fdec"; %>
    <% if ((list[i].OnDateTime - new DateTime()).Hours <= 2) color = "fbd9d9";%>
    <tr bgcolor="<%= color %>">
        <%using (Html.BeginForm("Confirm", "Cashier")) %>
        <% { %>
            <td><%= list[i].Id %>
                <%= Html.TextBox("Id", list[i].Id, new { @style = "width: 1px; visibility:hidden;" })%></td>
            <td><%= list[i].Name       %></td>
            <td><%= list[i].Phone      %></td>
            <td><%= list[i].Address    %></td>
            <td><%= list[i].Start      %></td>
            <td><%= list[i].OnDateTime %></td>
            <td><%= list[i].OrderStatus %></td>
        <%} %>
    </tr>
    <tr bgcolor="<%= color %>">
    <td></td>
    <td><b><i>Order List:</i></b></td>
    <td><b>Recept</b></td>
    <td><b>Count</b></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>

    <tr bgcolor="<%= color %>" valign="top">
    <td></td>
    <td></td>
    <td>
    <% for (var j = 0; j < list[i].OrderLines.Count; j++) %>
    <% { %>
        <%= list[i].OrderLines[j].Recept.NameRecept %><br/>
    <% } %>
    </td>
    <td>
    <% for (var j = 0; j < list[i].OrderLines.Count; j++) %>
    <% { %>
        <%= list[i].OrderLines[j].Quantity %><br/>
    <% } %>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
<% } %>
</table>


</asp:Content>
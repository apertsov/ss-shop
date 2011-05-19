<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Ingridient>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Ingredients</h2>

<%using (Html.BeginForm("Add", "Ingridient")) %>
<% { %>
    NAME = <%= Html.TextBox("IngridientName")%>
    <input type="submit" value="Add" name="add"/>
<%} %>
<br/>

<% var list = (ShopModel.Entities.Ingridient[]) ViewData["ingradients"]; %>

<table>
<tr>
<td><b>Id</b></td>
<td><b>IngridientName</b></td>
<td></td>
<td></td>
</tr>
<% for (var i = 0; i < list.Length; i++) %>
<% { %>
    <tr>
        <%using (Html.BeginForm("Edit", "Ingridient")) %>
        <% { %>
            <td><%= list[i].Id %>
                <%= Html.TextBox("Id", list[i].Id, new { @style = "width: 1px; visibility:hidden;" })%></td>
            <td><%= Html.TextBox("IngridientName", list[i].IngridientName) %></td>
            <td><input type="submit" value="edit" name="edit"/></td>
        <%} %>

        <td><%using (Html.BeginForm("Delete", "Ingridient")) %>
            <% { %>
            <%= Html.Hidden("Id", list[i].Id) %>
            <input type="submit" value="delete" name="delete"/>
            <%} %>
        </td>
    </tr>
<% } %>
</table>

</asp:Content>

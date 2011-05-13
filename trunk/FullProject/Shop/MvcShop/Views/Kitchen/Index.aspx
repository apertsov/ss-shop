<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Order</h2>

<% ShopModel.Entities.Order[]  list = (ShopModel.Entities.Order[])ViewData["orders"]; %>
<h3>Taken</h3>
<table>
    <tr bgcolor="fbd9d9">
    <td>#</td>
    <td><b><i>Order List:</i></b></td>
    <td><b>Recept</b></td>
    <td><b>Count</b></td>
    <td>Confirm</td>
    </tr>
    <% for (int i = 0; i < list.Length; i++) %>
    <% { %>
        <% string color = ""; %>
        <% if (i % 2 == 0) color = "ebe6fd"; else color = "f0fdec"; %>
        <tr bgcolor="<%= color %>" valign="top">
            <%using (Html.BeginForm("Confirm", "Kitchen")) %>
            <% { %>
                <td><%= list[i].Id %>
                    <%= Html.TextBox("Id", list[i].Id, new { @style = "width: 1px; visibility:hidden;" })%></td>
                <td></td>
                <td>
                    <% for (int j = 0; j < list[i].OrderLines.Count; j++) %>
                    <% { %>
                        <%= list[i].OrderLines[j].Recept.NameRecept %><br/>
                    <% } %>
                </td>
                <td>
                    <% for (int j = 0; j < list[i].OrderLines.Count; j++) %>
                    <% { %>
                        <%= list[i].OrderLines[j].Quantity %><br/>
                    <% } %>
                </td>
                <td><input type="submit" value="confirm" name="confirm" style="width: 200px;"/></td>
            <%} %>
        </tr>
    <% } %>
</table>


</asp:Content>

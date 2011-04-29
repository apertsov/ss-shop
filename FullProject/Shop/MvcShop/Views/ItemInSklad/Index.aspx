<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.ItemInSklad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Item In Sklad</h2>

<%using (Html.BeginForm("Add", "ItemInSklad")) %>
<% { %>
    <table>
       <tr>
        <td>Ingridient<br/>                                                                                                     
        <%=Html.DropDownList("ing", (SelectList)ViewData["IngridientID"])%> (<%= Html.ActionLink("new Indradient", "Index", "Ingridient") %>)<br/>
        </td>

        <td>
        PriceByKgOrOne<br/>
        <%= Html.TextBox("PriceByKgOrOne")%><br/>
        </td>
        <td>
        </td>
        <td>
        </td>
       </tr>

       <tr>
        <td>
        MinQuantity<br/>
        <%= Html.TextBox("MinQuantity")%><br/>
        </td>
        <td>
        Quantity<br/>
        <%= Html.TextBox("Quantity")%><br/>
        </td>
        <td>
        <input type="submit" value="  Add  " name="add"/>
        </td>
        <td>
        <%= Html.ActionLink("Ingredients that end", "IngredientsEnd", "ItemInSklad")%>
        </td>
       </tr>
    </table>
<%} %>
<br/>


<% ShopModel.Entities.ItemInSklad[] list = (ShopModel.Entities.ItemInSklad[])ViewData["itemInSklad"]; %>
<table>
<tr>
<td><b>Id</b></td>
<td><b>Ingridient</b></td>
<td><b>PriceByKgOrOne</b></td>
<td><b>MinQuantity</b></td>
<td><b>Quantity</b></td>
<td></td>
<td></td>
</tr>
<% for (int i = 0; i < list.Length; i++) %>
<% { %>
    <tr>
        <%using (Html.BeginForm("Edit", "ItemInSklad")) %>
        <% { %>
            <td><%= list[i].Id %>
                <%= Html.TextBox("Id",             list[i].Id,                        new { @style = "width: 1px; visibility:hidden;" }) %></td>
            <td><%= list[i].Ingridient.IngridientName %>
                <%= Html.TextBox("ing",            list[i].Ingridient.Id,             new { @style = "width: 1px; visibility:hidden;" }) %></td>
            <td><%= Html.TextBox("PriceByKgOrOne", list[i].PriceByKgOrOne,            new { @style = "width: 100px;" }) %></td>
            <td><%= Html.TextBox("MinQuantity",    list[i].MinQuantity,               new { @style = "width: 100px;" }) %></td>
            <td><%= Html.TextBox("Quantity",       list[i].Quantity,                  new { @style = "width: 100px;" }) %></td>
            <td><input type="submit" value="edit" name="edit"/></td>
        <%} %>
        <td><%using (Html.BeginForm("Delete", "ItemInSklad")) %>
            <% { %>
            <%= Html.Hidden("Id", list[i].Id) %>
            <input type="submit" value="delete" name="delete"/>
            <%} %>
        </td>
</tr>
<%} %>
</table>


</asp:Content>

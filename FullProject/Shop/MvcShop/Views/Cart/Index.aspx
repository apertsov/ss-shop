<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Cart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>cart</h2>
<% if ((Model != null) && (Model.Lines.Count>0)) { %>
<table width="90%">
<thead><tr>
            <th>Quantity</th>
            <th>Item</th>
            <th>Price</th>
            <th>SubTotal</th>
            <th></th>
       </tr>
</thead>
<tbody>
    <%
       foreach (var cartLine in Model.Lines)
       {%>
        <tr>
            <td> <%=cartLine.Quantity%></td>
            <td> <%=cartLine.Recept.NameRecept%></td>
            <td> <%=cartLine.Recept.Price%></td>
            <td> <%=cartLine.Recept.Price*cartLine.Quantity%></td>
            <td>
            <% using (Html.BeginForm("RemoveFromCart", "Cart")) { %>
            <%= Html.Hidden("receptId",cartLine.Recept.Id) %>
            <%= Html.Hidden("returnUrl",ViewData["returnUrl"]) %>
            <input type="submit" value="remove" />
            <% } %>
            </td>
        </tr>
    <%
       }%>
</tbody>
<tfoot>
<tr>
<td colspan="3" align="right">Total</td>
<td><%=Model.ComputeTotalValue().ToString()%></td>
<td></td>
</tr>
</tfoot>
</table>
<% } %>
<div class="actionButtons">
    <a href="<%= Html.Encode(ViewData["returnUrl"])%>">Continue shopping</a>
    <%= Html.ActionLink("CheckOut Now", "CheckOut","Cart") %>
</div>
</asp:Content>

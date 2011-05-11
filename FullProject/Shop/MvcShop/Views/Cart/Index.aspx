<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Cart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>cart</h2>
<table width="90%" id="tableCart">
<% if ((Model != null) && (Model.Lines.Count > 0))
   { %>

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
            <td> 
                 <a href="#" id="<%= cartLine.Recept.Id %>" class="addItemCart"><img src="../../images/plus.png" alt="add"/></a>
                 <%=cartLine.Quantity%>
                 <a href="#" id="<%= cartLine.Recept.Id %>" class="minusItemCart"><img src="../../images/minus.png" alt="minus"/></a>
            </td>
            <td> <%=cartLine.Recept.NameRecept%></td>
            <td> <%=cartLine.Recept.Price.ToString("N")%></td>
            <td> <%= (cartLine.Recept.Price * cartLine.Quantity).ToString("N")%></td>
            <td>
                <a href="#" id="<%= cartLine.Recept.Id %>" class="removeItemCart"><img src="../../images/remove.png" alt="remove"/></a>
            </td>
        </tr>
    <%
       }%>
</tbody>
<tfoot>
<tr>
<td colspan="3" align="right">Total</td>
<td><%=Model.ComputeTotalValue().ToString("N")%></td>
<td></td>
</tr>
</tfoot>
<% } else {%>
<tr><td>Your cart is empty</td></tr>
<% } %>
</table>
<div class="actionButtons">
    <a href="<%= Html.Encode(ViewData["returnUrl"])%>">Continue shopping</a>
    <%= Html.ActionLink("CheckOut Now", "CheckOut","Cart") %>
</div>
</asp:Content>

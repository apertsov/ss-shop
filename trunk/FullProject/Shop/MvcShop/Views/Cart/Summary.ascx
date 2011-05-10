<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Cart>" %>

<a href="#" id="triggerCart" class="trigger cart">Shopping cart<br/>Items:<%= Model.Lines.Sum(x => x.Quantity) %><br/>Total:<%= Model.ComputeTotalValue().ToString("N") %></a>
<div id="jCartPanel" class="panel cart">
<center>Your shopping cart:</center><br/><br/>
        <table width="90%" id="tableCart">
        <% if ((Model != null) && (Model.Lines.Count > 0)) { %>
        <thead>
            <tr><td><b>Quantity</b></td><td><b>Item</b></td><td><b>Price</b></td><td><b>SubTotal</b></td><td></td></tr>
        </thead>
        <tbody>
        <% foreach (var cartLine in Model.Lines) { %>
        <tr>
            <td> <%=cartLine.Quantity%></td>
            <td> <%=cartLine.Recept.NameRecept%></td>
            <td> <%=cartLine.Recept.Price.ToString("N")%></td>
            <td> <%=(cartLine.Recept.Price * cartLine.Quantity).ToString("N")%></td>
            <td>
                <button type='button' id='<%= cartLine.Recept.Id %>' class='removeItemCart'>remove</button>
            </td>
        </tr>
        <% } %>
        </tbody>
        <tfoot>
        <tr>
            <td colspan="3" align="right">Total</td><td><%=Model.ComputeTotalValue().ToString()%></td>
            <td></td>
        </tr>
        </tfoot>
        
<% } else { %>
       <tr><td>Your cart is empty</td></tr>
<% } %>
</table>
    <%= Html.ActionLink("Check out","Index","Cart", new {returnUrl=Request.Url.PathAndQuery}, null) %>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="clearCart" href="#">Clear cart</a>
</div>


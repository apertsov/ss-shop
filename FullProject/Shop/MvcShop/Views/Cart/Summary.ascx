<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Cart>" %>
<div id="cart">
    <table id="tableCart" align="center">
                    <tr><th colspan="2">Cart</th></tr>
                    <tr><td>Items</td><td><%= Model.Lines.Sum(x => x.Quantity) %></td></tr>
                    <tr><td>Total</td><td><%= Model.ComputeTotalValue() %></td></tr>
    </table>
    <%= Html.ActionLink("Check out","Index","Cart", new {returnUrl=Request.Url.PathAndQuery}, null) %>
</div>

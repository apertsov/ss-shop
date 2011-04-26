<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Cart>" %>
<div id="cart">
    <span class="caption">
    Cart:<%= Model.Lines.Sum(x => x.Quantity) %> items
    <%= Model.ComputeTotalValue() %>
    <%= Html.ActionLink("Check out","Index","Cart", new {returnUrl=Request.Url.PathAndQuery}, null) %>
    </span>
</div>

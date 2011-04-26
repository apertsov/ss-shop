<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
    <h3><%= Model.NameRecept %></h3>
    <%= Model.Description %>
    <h4><%= Model.Price %></h4>
    <% using (Html.BeginForm("AddToCart", "Cart")) { %>
    <%= Html.Hidden("receptId", Model.Id) %>
    <%= Html.Hidden("returnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
    <input type="submit" value="Add"/>
    <% } %>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
    <h3><%= Model.NameRecept %></h3>
    <%= Model.Description %>
    <h4><%= Model.Id %></h4>
</div>

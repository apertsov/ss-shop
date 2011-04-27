<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.IngridientInRecept>" %>
<div class="Recept">
<%=Model.Ingridient.IngridientName%>
    <% using (Html.BeginForm()) { %>
    <%= Html.Hidden("receptId", Model.Id) %>
    <%= Html.Hidden("returnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
  
    <% } %>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
<p>
<table width=99% border="0">
    <tr>
        <td width=20%><h4><%= Model.NameRecept %></h4></td>
        
    </tr>
    <tr>
        <td><IMG src=<%=Model.PathToImage %>></td>
     
      <td><%= Model.Description %></td></tr>
   
    <%//foreach (ShopModel.Entities.IngridientInRecept ingr in Model.Ingridients) Html.RenderPartial("IngrInRecept", ingr); %></td></tr>   
        
     

<% using (Html.BeginForm("AddToCart", "Cart")) { %>
    <%= Html.Hidden("receptId", Model.Id) %>
    <%= Html.Hidden("returnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
   <tr>
   <td>price <%=Model.Price %></td>
   <td align=right>kilkist <input type="text" name="quantity" value="1"/>
   <input type="submit" value="Add" /></td></tr> 
    </table>
   
</p>
<% } %>
</div>

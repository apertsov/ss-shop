<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
<p>
<table width=99% border="0">
    <tr>
        <td width=80%><h4><%= Model.NameRecept %></h4></td>
        <td align=right>price <%=Model.Price %></td>
    </tr>
    <tr>
        <td><IMG src=<%=Model.PathToImage %> width=250 height=250 hspace=20> <%= Model.Description %></td>
      
        <td align=left>ingridients
        <ol> <%foreach (ShopModel.Entities.IngridientInRecept ingr in Model.Ingridients) Html.RenderPartial("IngridientsInRecept", ingr); %>
         </ol></td>
    </tr> 
<% using (Html.BeginForm("AddToCart", "Cart")) { %>
    <%= Html.Hidden("receptId", Model.Id) %>
    <%= Html.Hidden("returnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
   <tr>
   <td align=right>k-st <input type="text" name="quantity" value="1"/></td>
   <td align=center ><input type="submit" value="Add" /></td></tr> 
   </table>
</p>
<% } %>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
<table width="99%" border="0">
    <tr>
        <td width="80%"><h4><%= Model.NameRecept %></h4></td>
        <td align="right">price <%=Model.Price %></td>
    </tr>
    <tr>
        <td><img src="<%= Model.PathToImage %>" width="250" height="250" hspace="20" alt="pizza image"/> <%= Model.Description %></td>
      
        <td align="left">ingridients
        <ol> <%foreach (var ingr in Model.Ingridients) {%>
        <li> <%= ingr.Ingridient.IngridientName %></li>
        <% } %>
         </ol></td>
    </tr> 
    <tr>
        <td align="right">k-st <input type="text" id="receptQuantity<%= Model.Id %>" name="quantity" value="1"/></td>
        <td align="center" ><button id="<%= Model.Id %>" class="receptToCart" type="button">Add to cart(dynamic)</button></td>
   </tr> 
   </table>

</div>

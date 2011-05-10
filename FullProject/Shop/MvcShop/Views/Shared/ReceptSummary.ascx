<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
<table width="99%" border="0">
    <tr>
        <td width="20%"><h4><%= Model.NameRecept %></h4></td>
        
    </tr>
    <tr>
        <td><img src="<%= Model.PathToImage %>" alt="<%= Model.NameRecept %>"/></td>
         <td><%= Model.Description %></td>
    </tr>
   <tr>
   <td><%= Model.Price.ToString("N") %></td>
   <td align="right"> <input type="text" name="quantity" value="1" id="receptQuantity<%= Model.Id %>"/>
   <input class="receptToCart" id="<%= Model.Id %>" type="submit" value="Add" /></td></tr> 
    </table>
</div>

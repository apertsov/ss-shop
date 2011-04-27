<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<div class="Recept">
<table width=99% border="0">
    <tr><td><h4><%= Model.NameRecept %></h4></td>
    <td align=right>vartist <%=Model.Price %></td></tr>
    <tr><td><IMG src=<%=Model.PathToImage %> width=250 height=250 hspace=20>  <%= Model.Description %>
    </td>
</tr> 
<% using (Html.BeginForm("AddToCart", "Cart")) { %>
    <%= Html.Hidden("receptId", Model.Id) %>
    <%= Html.Hidden("returnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
   <tr><td></td>
   <td align=right>k-st <input type="text" name="quantity"/></td>
   <td align=left><input type="submit" value="Add"/></td></tr> 
   </table>

    <% } %>
</div>

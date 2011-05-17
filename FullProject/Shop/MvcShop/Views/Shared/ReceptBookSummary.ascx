<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Recept>" %>
<hr>
<table width="99%">
    <tr>
        <td width="20%">
            <h4>
                <%= Model.NameRecept %></h4>
        </td>
        <td align="right">
            price
            <%=Model.Price %>
        </td>
    </tr>
    <tr>
        <td>
            <img src="<%=Model.PathToImage %>" />
        </td>
        <td>
            <%=Model.Description %>
        </td>
     <tr>
        <td>
            ingridients
            <%foreach (ShopModel.Entities.IngridientInRecept ingr in Model.Ingridients)
              {%>
            <ol>
                <%=ingr.Ingridient.IngridientName%>
                <%=ingr.Quantity%>
            </ol>
            <%} %>
        </td>
    </tr>
       <tr>
            <td align =right >
                <%using (Html.BeginForm("Edit", "CookBook")) %>
                <% { %>
                <%= Html.Hidden("Id", Model.Id) %>
                <input type="submit" value="Edit" name="Edit" />
                <%} %>
             </td>
             <td>   <%using (Html.BeginForm("Delete", "CookBook")) %>
                <% { %>
                <%= Html.Hidden("id", Model.Id) %>
                <input type="submit" value="delete" name="delete" />
                <%} %>
            </td>
        </tr>
    
</table>
<hr>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Recept>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditRecept
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        EditRecept</h2>
    
    
    <%using (Html.BeginForm("Edit", "CookBook"))
      { %>
      <hr />
     Загальні дані
     <hr />
    <table>
        <tr>
            <td>
                Назва:
            </td>
            <td>
                <%= Html.TextBox("NameRecept", ViewData["name"])%>
                <%= Html.TextBox("NameRecept1", ViewData["nameru"])%>
                <%= Html.TextBox("NameRecept2", ViewData["nameua"])%>
            </td>
        </tr>
        <tr>
            <td>
                Опис:
            </td>
            <td>
                <%= Html.TextBox("description", ViewData["dname"])%>
                <%= Html.TextBox("description1", ViewData["dnameru"])%>
                <%= Html.TextBox("description2", ViewData["dnameua"])%>
             </td>
        </tr>
        <tr>
            <td>
                Картинка:
            </td>
            <td>
                <input type="file" name="img" value="<%= Model.PathToImage %>" /><img src="<%=Model.PathToImage%>" alt="image"/>
            </td>
        </tr>
        <tr>
            <td>
                Ціна:
            </td>
            <td>
                <%= Html.TextBox("Price",Model.Price)%>
            </td>
        </tr>
        <tr>
            <td>
                Час приготування:
            </td>
            <td>
                <%= Html.TextBox("TimeCooking",Model.TimeCooking)%>
            </td>
        </tr>
    </table>
    <br />
    <%=Html.Hidden("Id", Model.Id)%>
    <input type="submit" name="update" value="edit" />
    <%} %>
    <hr />
    Інгридієнти
<hr/>
<%if (Model.Ingridients!=null) %>
    <table>
        <%foreach (ShopModel.Entities.IngridientInRecept ingr in Model.Ingridients)
          {%>
        <tr>
            <td>
                <%= Html.Label("Ingridient.IngridientName", ingr.Ingridient.IngridientName)%>
            </td>
            <td>
                <%using (Html.BeginForm("EditIngr", "CookBook"))
                  { %>
                <%=Html.Hidden("IdInRec", ingr.Id)%>
                <%= Html.TextBox("quantity", ingr.Quantity)%>
                <input type="submit" name="editIngr" value="edit" />
                <%} %>
            </td>
<td>
                <%using (Html.BeginForm("DelIngr", "CookBook"))
                  { %>
                <%=Html.Hidden("IdRec", Model.Id)%>
                <%=Html.Hidden("IdInRec", ingr.Id)%>
                <%=Html.Hidden("IdIn",ingr.Ingridient.Id) %>
                <input type="submit" name="delete" value="delete" />
                <%} %>
            </td>
            

        </tr>
        <%} %>
    </table>
    <hr />
Додавання інгридієнту
    <hr />
   <%using (Html.BeginForm("AddIn", "CookBook"))
  { %>
  <%=Html.DropDownList("ingID", (SelectList)ViewData["listIngr"])%>
  <%=Html.TextBox("quantity") %>
  <%=Html.Hidden("IdRec",Model.Id) %>
  <input type ="submit" value ="add" name ="add" />
<%} %>

    ]
</asp:Content>

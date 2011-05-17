<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Recept>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddRecipe
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>AddRecipe</h2>

<%using (Html.BeginForm("AddRecipe", "CookBook","idCategory")) %>
<% { %>
   
  Категорія <%=Html.DropDownList("cat", (SelectList)ViewData["allCategory"])%> 
      
<table>
<tr>
    <tr>
        <td>Назва:</td>
        <td><%= Html.TextBox("NameRecept") %></td>
    </tr>
     <tr>
        <td>Опис:</td>
        <td><%= Html.TextBox("description")%></td>
    </tr>
   <tr>
        <td>Картинка:</td>
        <td><input type="file" name="img" /></td>
        </tr>
    <tr>
        <td>Ціна:</td>
        <td><%= Html.TextBox("Price")%></td>
    </tr>
    <tr>
        <td>Час приготування:</td>
        <td><%= Html.TextBox("TimeCooking")%></td>
    </tr>
    <tr>
        <td><input type="submit" value="add" name="add"/></td>
    </tr>
</table>

<%} %>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Manager</h2>

<%using (Html.BeginForm("Role", "Manager")) { %>
<input type="submit" value="Role" name="Role" style="width:200px;" /><%} %>

<%using (Html.BeginForm("ChangeUser", "Manager")) { %>
<input type="submit" value="ChangeRoleUser" name="ChangeRoleUser" style="width:200px;" /><%} %>

<%using (Html.BeginForm("AddUser", "Manager")) { %>
<input type="submit" value="AddUser" name="AddUser" style="width:200px;" /><%} %>

<br/>
<br/>

<%using (Html.BeginForm("index","ItemInSklad")) { %>
<input type="submit" value="ItemInSklad" name="ItemInSklad" style="width:200px;" /><% } %>

<%using (Html.BeginForm("ingredientsEnd","ItemInSklad")) { %>
<input type="submit" value="IngredientsEndInSklad" name="IngredientsEndInSklad" style="width:200px;" /><% } %>

<%using (Html.BeginForm("index", "Ingridient")) { %>
<input type="submit" value="Ingridient" name="Ingridient" style="width:200px;" /><% } %>

<br/>
<br/>

<%using (Html.BeginForm("GetAllOrders", "Manager")) { %>
<input type="submit" value="AllOrder" name="AllOrder" style="width:200px;" /><% } %>

</asp:Content>

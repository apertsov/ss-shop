<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>
<%= Html.ActionLink("Role","Role") %><br />
<%= Html.ActionLink("Change role user","ChangeUser") %><br />
<%= Html.ActionLink("Add user","AddUser") %><br />
<%= Html.ActionLink("Ingridients end in sklad","ingredientsEnd","ItemInSklad")%><br />
<%= Html.ActionLink("Item in sklad","index","ItemInSklad")%><br />
<%= Html.ActionLink("Ingridient", "index", "Ingridient")%><br />
<%= Html.ActionLink("All Order", "GetAllOrders", "Manager")%><br />
</asp:Content>

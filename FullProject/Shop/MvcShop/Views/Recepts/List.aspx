<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShopModel.Entities.Recept>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List Recept - Cat:
    <%= ViewData["CurrentCategory"].ToString() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="Recepts">
<% foreach (var recept in Model) Html.RenderPartial("ReceptSummary",recept); %>
</div>
<div class="Pager">
    Page: <%= Html.PageLinks((int)ViewData["CurrentPage"], (int)ViewData["TotalPages"], x => Url.Action("List", new { page = x, category = ViewData["CurrentCategory"] }))%>
</div>
</asp:Content>

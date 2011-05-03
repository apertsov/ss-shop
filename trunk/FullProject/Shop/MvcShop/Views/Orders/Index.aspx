<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Orders</h2>
<% Html.RenderPartial("SearchByIdPartial"); %>

<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShopModel.Entities.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    SearchByUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>SearchByUser</h2>
<% Html.RenderPartial("SearchByIdPartial"); %>
<div> Search From <%= Html.Encode(ViewData["dtFrom"].ToString())%> To <%= Html.Encode(ViewData["dtTo"].ToString())%> </div>
<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
<% if (Model == null) { %>
<div>no search result</div>
<% } else { %>
<table>
<tr><th>OrderDate</th><th>OnDateTime</th><th>Status</th></tr>
<% foreach (var order in Model) { %>
<tr><td><%= order.Start.ToString() %></td><td><%= order.OnDateTime == order.Start ? "fastest" : order.OnDateTime.ToString()%></td><td><%= order.OrderStatus%></td></tr>
<% } %>
</table>
<% } %>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShopModel.Entities.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    SearchByUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2><%=Resources.Global.SearchByUser%></h2>
<div> <%=Resources.Global.Search1%>  <%= Html.Encode(ViewData["dtFrom"].ToString())%> <%=Resources.Global.Search2%>  <%= Html.Encode(ViewData["dtTo"].ToString())%> </div>
<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
<% if (Model == null) { %>
<div><%=Resources.Global.NoSearch%></div>
<% } else { %>
<table>
<tr>
<td>
<table>
<tr><th><%=Resources.Global.OrderDateTime %></th><th><%=Resources.Global.OrderDateTime1%></th><th><%=Resources.Global.OrderStatus%></th></tr>
<% foreach (var order in Model) { %>
<tr class="order-det"><td><a href="#" id="<%= order.Id %>" class="orderDetailsClick"><%= order.Start.ToString() %></a></td><td><%= order.OnDateTime == order.Start ? "fastest" : order.OnDateTime.ToString()%></td><td><%= order.OrderStatus%></td></tr>
<% } %>
</table>
</td>
<td>
<div id="detailsOrder"></div>
</td>
</tr>
</table>
<% } %>
</asp:Content>

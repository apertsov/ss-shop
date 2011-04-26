<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcShop.Controllers.NavigationLink>>" %>
<% foreach (var link in Model) { %>
<a href="<%= Url.RouteUrl(link.RouteValues)%>"><%=link.Text %></a>&nbsp;&nbsp;&nbsp;
<% } %>


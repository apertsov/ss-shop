<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcShop.Controllers.NavigationLink>>" %>
<ul id="menu">
<% foreach (var link in Model) { %>
<li>
<a href="<%= Url.RouteUrl(link.RouteValues)%>" class="<%= link.IsSelected?"selected":"" %>"><%=link.Text %></a>
</li>
<% } %>
</ul>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcShop.Controllers.NavigationLink>>" %>
<ul id="iconbar">
<% foreach (var link in Model) { %>
    <li><a href="<%= Url.RouteUrl(link.RouteValues)%>" class="<%= link.IsSelected?"selected":"" %>">
        <img src="../../Content/images/menuPict<%=link.Id %>.png" alt="" width="70" height="70"/>
	    <span><%=link.Text %></span>
    </a></li>
<% } %>
</ul>

<br/>
<br/>
<br/>
<br/>
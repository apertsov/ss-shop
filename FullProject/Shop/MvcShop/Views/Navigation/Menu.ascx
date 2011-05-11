<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcShop.Controllers.NavigationLink>>" %>
<!--
<ul id="menu">
<% foreach (var link in Model) { %>
<li>
<a href="<%= Url.RouteUrl(link.RouteValues)%>" class="<%= link.IsSelected?"selected":"" %>"><%=link.Text %></a>
</li>
<% } %>
</ul>
-->

<ul id="iconbar">
    <li><a href="/Orders/index">
		<img src="<%: Url.Content("~/Content/images/6_bisnes.png")%>" alt="" width="70" height="70"/>
		<span>Order</span>
	</a></li>
    <li><a href="/Cat4">
		<img src="<%: Url.Content("~/Content/images/zakuska_tbilisi1.png")%>" alt="" width="70" height="70"/>
		<span>Snacks</span>
	</a></li>
    <li><a href="/Cat3">
		<img src="<%: Url.Content("~/Content/images/Fun433_524.png")%>" alt="" width="70" height="70"/>
		<span>Drinks</span>
	</a></li>
    <li><a href="/Cat2">
		<img src="<%: Url.Content("~/Content/images/salad.png")%>" alt="" width="70" height="70"/>
		<span>Salads</span>
	</a></li>
    <li><a href="/Cat1">
		<img src="<%: Url.Content("~/Content/images/pitstsa_2.png")%>" alt="" width="70" height="70"/>
		<span>Pizza</span>
	</a></li>
    <li><a href="/">
		<img src="<%: Url.Content("~/Content/images/5_nedvij.png")%>" alt="" width="70" height="70"/>
		<span>Home</span>
	</a></li>
</ul>

<br/>
<br/>
<br/>
<br/>
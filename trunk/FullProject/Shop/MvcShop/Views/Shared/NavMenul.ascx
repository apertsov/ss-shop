<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
     <br />
     <%if( Context.User.IsInRole("manager")) {%>
     <%: Html.ActionLink("Manager", "Index", "Manager") %>
     <%} %>
     <%if( Context.User.IsInRole("cooker")){ %>
     <%: Html.ActionLink("CookBook", "Index","CookBook")%>
     <%} %>
     <%if( Context.User.IsInRole("cashier")){ %>
     <%: Html.ActionLink("Cashier", "Index", "Cashier") %>   
     <%} %>
     <%if( Context.User.IsInRole("kitchen")){ %>
     <%: Html.ActionLink("Kitchen", "Index", "Kitchen") %>
     <%} %>]
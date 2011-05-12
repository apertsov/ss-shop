<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <strong><%: Page.User.Identity.Name %></strong>!
         <% string Link=GetGlobalResourceObject("Global","LogOff").ToString(); %>
        [ <%: Html.ActionLink(Link, "LogOff", "Account") %> ]
<%
    }
    else {
%> 
         <% string Link=GetGlobalResourceObject("Global","LogOn").ToString(); %>
        [ <%: Html.ActionLink(Link, "LogOn", "Account") %> ]
<%
    }
%>

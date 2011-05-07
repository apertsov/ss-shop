<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <strong><%:Html.ActionLink(Page.User.Identity.Name, "UserInfo","Account") %></strong>!
        [ <%: Html.ActionLink("Log Off", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>

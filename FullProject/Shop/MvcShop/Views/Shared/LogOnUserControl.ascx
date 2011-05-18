<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <%=Resources.Global.Welcome %><strong><%: Html.ActionLink(Page.User.Identity.Name,"UserInfo","Account") %></strong>!
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

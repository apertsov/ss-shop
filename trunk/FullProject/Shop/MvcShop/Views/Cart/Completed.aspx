<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Resources.Global.Completed%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% var link = GetGlobalResourceObject("Global","Orders").ToString(); %>
<% if (User.Identity.IsAuthenticated == false) { %>
<h2><%=Resources.Global.Completed%></h2>
<%=Resources.Global.Thx %> <%= Html.ActionLink(link,"Index","Orders") %>
<% } else { %>
<h2><%=Resources.Global.Completed%></h2>
<%=Resources.Global.Thx1 %><%= Html.ActionLink(link,"Index","Orders") %>
<% }%> 
   
</asp:Content>

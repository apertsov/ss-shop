<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Resources.Global.Completed%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% string Link = GetGlobalResourceObject("Global","Orders").ToString(); %>
<% if (User.Identity.IsAuthenticated == false) { %>
<h2><%=Resources.Global.Completed%></h2>
<%=Resources.Global.Thx %> <%= Html.ActionLink(Link,"Index","Orders") %>
<% } else { %>
<h2><%=Resources.Global.Completed%></h2>
<%=Resources.Global.Thx1 %><%= Html.ActionLink(Link,"Index","Orders") %>
<% }%> 
   
</asp:Content>

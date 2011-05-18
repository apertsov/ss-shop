<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Info
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><%= User.Identity.Name %></h2>
<%=Resources.Global.FirstName %>:   <%=Profile["first"]%><br/>
<%=Resources.Global.LastName %>:    <%=Profile["last"]%><br/>
<%=Resources.Global.Address%>:      <%=Profile["address"]%><br />
<%=Resources.Global.Phone%>:        <%=Profile["phone"]%><br />

<%=Html.ActionLink(Resources.Global.ChangePassword,"ChangePassword") %>
<%=Html.ActionLink(Resources.Global.Edit, "ChangeProfile")%>
</asp:Content>

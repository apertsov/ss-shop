<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Info
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><%= User.Identity.Name %></h2>
First Name:   <%=Profile["first"]%><br/>
Last Name:    <%=Profile["last"]%><br/>
Address:      <%=Profile["address"]%><br />
Phone:        <%=Profile["phone"]%><br />
</asp:Content>

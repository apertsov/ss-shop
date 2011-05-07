<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Completed
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% if (User.Identity.IsAuthenticated == false) { %>
<h2>Completed</h2>
<div>thx for your order</div>
Well ship your goods as soon as possible <br/>
You can check Your Order at page <%= Html.ActionLink("Orders","Index","Orders") %>
<% } else { %>
<h2>Completed</h2>
<div>thx for your order</div>
You can check Your Order & History at page <%= Html.ActionLink("Orders","Index","Orders") %>
<% }%> 
   
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.ShippingDetails>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CheckOut
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Check Out Now</h2>
Please enter your details
<%= Html.ValidationSummary() %>
<% using (Html.BeginForm()) { %>
<h3>Ship to</h3>
<div>Name <%= Html.TextBox("Name") %></div>
<div>Number phone <%= Html.TextBox("NumberPhone") %></div>
<div>Address <%= Html.TextBox("Address") %></div>
<div><input type="submit" value="Complete order" /></div>
<% } %>

</asp:Content>

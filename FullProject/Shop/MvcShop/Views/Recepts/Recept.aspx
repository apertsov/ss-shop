<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Recept>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Recept
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Recept</h2>

<% ShopModel.Entities.Recept recept = (ShopModel.Entities.Recept) ViewData["recept"]; %>

<p>Description: 
<%= recept.Description %>
</p>

<p>NameRecept: 
<%= recept.NameRecept %>
</p>

<p>Price: 
<%= recept.Price %>
</p>

<p>TimeCooking: 
<%= recept.TimeCooking %>
</p>

<p>Ingridients: <br/>
<%= for (int i = 0; i < recept.Ingridients.Count; i++) %>
<% { %>
    <%= recept.Ingridients[i].Ingridient.IngridientName %><br/>
<% } %>
</p>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShopModel.Entities.Recept>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List Recept
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>
<%using (Html.BeginForm())
  { %>
    <%=Html.ActionLink("Add new recept", "AddRecipe", "CookBook","idCategory")%>
    <br />
  <%=Html.DropDownList("idCategory",(SelectList)ViewData["allCategory"],new { onchange = "this.form.action = 'Index'; this.form.submit();" }) %>
<%} %>
<br /> 
  <%foreach (var recept in Model)
            Html.RenderPartial("ReceptBookSummary", recept);
        %>
      
</asp:Content>

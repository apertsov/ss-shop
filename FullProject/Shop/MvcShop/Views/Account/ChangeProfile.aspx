<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Resources.Global.Edit %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><%=Resources.Global.Edit %></h2>  <h2><%= User.Identity.Name %></h2>
<%using(Html.BeginForm()){ %>
<%=Resources.Global.FirstName %>:   <%=Html.TextBox("First",Profile["first"])%><br/>
<%=Resources.Global.LastName %>:    <%=Html.TextBox("Last",Profile["last"])%><br/>
<%=Resources.Global.Address%>:      <%=Html.TextBox("Address",Profile["address"])%><br />
<%=Resources.Global.Phone%>:        <%=Html.TextBox("Phone",Profile["phone"])%><br />
<input type="submit" value="Ok" name="ok" />
<%} %>
</asp:Content>

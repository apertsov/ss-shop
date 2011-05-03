<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    SearchById
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Orders</h2>
<% Html.RenderPartial("SearchByIdPartial"); %>
<div> Search For OrderId=<%= Html.Encode(ViewData["sID"].ToString())%> </div>
<br/>
<%if (Model == null) { %>
<div>no search result</div>
<% } else { %>
<table>
<tr> <td>Your Name</td> <td><%=Model.Name %></td> </tr>
<tr> <td>Ordered</td> <td><%=Model.Start.ToString() %></td> </tr>
<tr> <td>to datetime</td> <td><%=Model.OnDateTime==Model.Start?"fastest":Model.OnDateTime.ToString() %></td> </tr>
<tr> <td>address</td> <td><%=Model.Address %></td> </tr>
<tr> <td>phone</td> <td><%=Model.Phone %></td> </tr>
<tr> <td>Status</td> <td><b><%=Model.OrderStatus %></b></td> </tr>
</table>
<% } %>

<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
</asp:Content>

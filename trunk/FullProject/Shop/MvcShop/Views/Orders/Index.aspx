<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Orders</h2>
<% if (Model == null) { %>
<div> You did not order, or an error identification</div>
<% } else { %>
<div>Your last order</div>
<table>
<tr><th>Name:</th><td><%= Model.Name %></td></tr>
<tr><th>Phone:</th><td><%= Model.Phone %></td></tr>
<tr><th>Address:</th><td><%= Model.Address %></td></tr>
<tr><th>Items:</th>
                    <td>
                        <% if (Model.OrderLines.Count > 0) { %>
                            <table>
                                <thead>
                                <tr><th>Name</th><th>Quantity</th><th>Price</th></tr>
                                </thead>
                                <tbody>
                                <% foreach (var orderLine in Model.OrderLines) { %>
                                    <tr><td><%= orderLine.Recept.NameRecept %></td><td><%=orderLine.Quantity %></td><td><%= (orderLine.Recept.Price*orderLine.Quantity).ToString() %></td> </tr>
                                <% } %>
                                </tbody>
                                <tfoot>
                                <tr>
                                    <td colspan="2" align="right">Total</td>
                                    <td><%=Model.ComputeTotalValue().ToString()%></td>
                                </tr>
                                </tfoot>
                            </table>
                        <% } %>
                    </td>
</tr>
<tr><th>Order DateTime:</th><td><%= Model.Start.ToString() %></td></tr>
<tr><th>Order on DateTime:</th><td><%= (Model.Start==Model.OnDateTime)?"fastest":Model.OnDateTime.ToString() %></td></tr>
<tr><th>Order Status:</th><td><div class="orderStatus" id="<%= Model.Id %>"><b><%= Model.OrderStatus %></b></div></td></tr>
</table>
<% } %>

<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
</asp:Content>

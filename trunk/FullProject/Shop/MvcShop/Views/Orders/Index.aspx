<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><%=Resources.Global.Orders %></h2>
<% if (Model == null) { %>
<div> <%=Resources.Global.NotOrder%></div>
<% } else { %>
<div><%=Resources.Global.LastOrder%></div>
<table>
<tr><th><%=Resources.Global.FirstName%>:</th><td><%= Model.Name %></td></tr>
<tr><th><%=Resources.Global.Phone%>:</th><td><%= Model.Phone %></td></tr>
<tr><th><%=Resources.Global.Address%>:</th><td><%= Model.Address %></td></tr>
<tr><th><%=Resources.Global.Item%>:</th>
                    <td>
                        <% if (Model.OrderLines.Count > 0) { %>
                            <table>
                                <thead>
                                <tr><th><%=Resources.Global.FirstName%></th><th><%=Resources.Global.Quantity %></th><th><%=Resources.Global.Price%></th></tr>
                                </thead>
                                <tbody>
                                <% foreach (var orderLine in Model.OrderLines) { %>
                                    <tr><td><%=GetGlobalResourceObject("Recept", "r"+orderLine.Recept.Id) %></td><td><%=orderLine.Quantity %></td><td><%= (orderLine.Recept.Price*orderLine.Quantity).ToString() %></td> </tr>
                                <% } %>
                                </tbody>
                                <tfoot>
                                <tr>
                                    <td colspan="2" align="right"><%=Resources.Global.Total%></td>
                                    <td><%=Model.ComputeTotalValue().ToString()%></td>
                                </tr>
                                </tfoot>
                            </table>
                        <% } %>
                    </td>
</tr>
<tr><th><%=Resources.Global.OrderDateTime%>:</th><td><%= Model.Start.ToString() %></td></tr>
<tr><th><%=Resources.Global.OrderDateTime1%>:</th><td><%= (Model.Start==Model.OnDateTime)?"fastest":Model.OnDateTime.ToString() %></td></tr>
<tr><th><%=Resources.Global.OrderStatus%>:</th><td><div class="orderStatus" id="<%= Model.Id %>"><b><%= Model.OrderStatus %></b></div></td></tr>
</table>
<% } %>

<% if (User.Identity.IsAuthenticated) Html.RenderPartial("SearchByUserName");%>
</asp:Content>

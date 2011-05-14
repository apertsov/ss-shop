<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Cart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Resources.Global.Cart %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2><%=Resources.Global.Cart %></h2>
<div>Your order can be processed no earlier than <%= DateTime.Now.AddMinutes(30+Model.GetMinutesCooking()).ToString() %></div>
<br/>
<% if ((Model != null) && (Model.Lines.Count>0)) { %>
<table width="90%">
<thead><tr>
            <th><%=Resources.Global.Quantity %></th>
            <th><%=Resources.Global.Item%></th>
            <th><%=Resources.Global.Price%></th>
            <th><%=Resources.Global.SubTotal%></th>
            <th></th>
       </tr>
</thead>
<tbody>
    <%
       foreach (var cartLine in Model.Lines)
       {%>
        <tr>
            <td> <%=cartLine.Quantity%></td>
            <td> <%=GetGlobalResourceObject("Recept", "r" + cartLine.Recept.Id)%></td>
            <td> <%=cartLine.Recept.Price.ToString("N")%></td>
            <td> <%=(cartLine.Recept.Price*cartLine.Quantity).ToString("N")%></td>
            <td>
            <% using (Html.BeginForm("RemoveFromCart", "Cart")) { %>
            <%= Html.Hidden("receptId",cartLine.Recept.Id) %>
            <%= Html.Hidden("returnUrl",ViewData["returnUrl"]) %>
            <input type="submit" value="<%=Resources.Global.Remove%>" />
            <% } %>
            </td>
        </tr>
    <%
       }%>
</tbody>
<tfoot>
<tr>
<td colspan="3" align="right"><%=Resources.Global.Total%></td>
<td><%=Model.ComputeTotalValue().ToString("N")%></td>
<td></td>
</tr>
</tfoot>
</table>
<% } %>
<div class="actionButtons">
    <a href="<%= Html.Encode(ViewData["returnUrl"])%>"><%=Resources.Global.Continue %></a>
    <%= Html.ActionLink(Resources.Global.CheckOut, "CheckOut","Cart") %>
</div>
</asp:Content>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ShopModel.Entities.Cart>" %>
<a href="#" id="triggerCart" class="trigger cart">
    <%=Resources.Global.ShoppingCart %><br />
    <%=Resources.Global.Item%>:<%= Model.Lines.Sum(x => x.Quantity) %><br />
    <%=Resources.Global.Total%>:<%= Model.ComputeTotalValue().ToString("N") %></a>
<div id="jCartPanel" class="panel cart">
    <center>
        <%=Resources.Global.ShoppingCartY %>:</center>
    <br />
    <br />
    <div class="spisok">
    <table width="90%" id="tableCart">
        <% if ((Model != null) && (Model.Lines.Count > 0))
           { %>
        <thead>
            <tr>
                <td>
                    <b>
                        <%=Resources.Global.Quantity%></b>
                </td>
                <td>
                    <b>
                        <%=Resources.Global.Item%></b>
                </td>
                <td>
                    <b>
                        <%=Resources.Global.Price%></b>
                </td>
                <td>
                    <b>
                        <%=Resources.Global.SubTotal%></b>
                </td>
                <td>
                </td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var cartLine in Model.Lines)
               { %>
            <tr>
                <td>
                    <a href="#" id="<%=cartLine.Recept.Id %>" class="addItemCart">
                        <img src="../../images/plus.png" alt="add" /></a>
                    <%=cartLine.Quantity%>
                    <a href="#" id="<%=cartLine.Recept.Id %>" class="minusItemCart">
                        <img src="../../images/minus.png" alt="minus" /></a>
                </td>
                <td>
                    <%=GetGlobalResourceObject("Recept","r"+cartLine.Recept.Id)%>
                </td>
                <td>
                    <%=cartLine.Recept.Price.ToString("N")%>
                </td>
                <td>
                    <%=(cartLine.Recept.Price * cartLine.Quantity).ToString("N")%>
                </td>
                <td>
                    <a href="#" id="<%=cartLine.Recept.Id %>" class="removeItemCart">
                        <img src="../../images/remove.png" alt="remove" /></a>
                </td>
            </tr>
            <% } %>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="3" align="right">
                    <%=Resources.Global.Total%>
                </td>
                <td>
                    <%=Model.ComputeTotalValue().ToString()%>
                </td>
                <td>
                </td>
            </tr>
        </tfoot>
        <% }
           else
           { %>
        <tr>
            <td>
                <%=Resources.Global.EmptyCart%>
            </td>
        </tr>
        <% } %>
    </table>
    </div>
    <% string check = Resources.Global.CheckOut.ToString(); %>
    <%= Html.ActionLink(check,"Index","Cart", new {returnUrl=Request.Url.PathAndQuery}, null) %>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="clearCart" href="#">
        <%=Resources.Global.ClearCart%></a>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<br/>
<%using (Html.BeginForm("GetById", "Orders")) %>
<% { %>
    Order Id = <%= Html.TextBox("orderId")%>
    <input type="submit" value="Get by Order Id" name="getByOrderId"/>
<% } %>
<br/>
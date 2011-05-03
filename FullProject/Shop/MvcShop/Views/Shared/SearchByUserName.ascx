<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<br/>
<%using (Html.BeginForm("GetByUser", "Orders")) %>
<% { %>
        Date From: <%= Html.TextBox("dtFrom", DateTime.Now.AddDays(-7).ToString(), new { @class = "datepicker" })%> 
        Date To: <%= Html.TextBox("dtTo", DateTime.Now.ToString(), new { @class = "datepicker" })%> 
        <input type="submit" value="Get by Period" name="getByOrderUser"/>
<% } %>
<br/>

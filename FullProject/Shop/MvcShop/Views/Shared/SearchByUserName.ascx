<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<br/>
<%using (Html.BeginForm("GetByUser", "Orders")) %>
<% { %>
        <%=Resources.Global.DateFrom%>: <%= Html.TextBox("dtFrom", DateTime.Now.AddDays(-7).ToString(), new { @class = "datepicker" })%> 
        <%=Resources.Global.DateTo%>: <%= Html.TextBox("dtTo", DateTime.Now.ToString(), new { @class = "datepicker" })%> 
        <input type="submit" value="<%=Resources.Global.GetPeriod%>" name="getByOrderUser"/>
<% } %>
<br/>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    UserRole
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<h2>User Role</h2>
<%using (Html.BeginForm())
  { %>
<input type="submit" value="Save" name="save"/>
<table>
<tr>
<td>Name User</td><td>Delete</td><td>Role</td>
</tr>
<tr>
<%foreach (var item in Membership.GetAllUsers())
  {
      MembershipUser user = (MembershipUser)item;%>
    <td>   <%=user.UserName%></td>
    <td>
         <% using (Html.BeginForm("DeleteUser","Manager"))
         {%>
         <%=Html.Hidden("user", user.UserName)%>
         <input type="submit" value="x" name="x" />
         <%} %>  
    </td>
<td>     
<%foreach (string name in Roles.GetAllRoles())
  { %>
<%if (Roles.IsUserInRole(user.UserName, name))
  {%>
     <%=Html.CheckBox(name + user.UserName, true)%>
     <%}
  else%>
     <%=Html.CheckBox(name + user.UserName, false)%><%=name%>
     
 <%} %> </td>
</tr>
<%}%>
</table>
<%=Html.ActionLink("index","index") %>
<%} %>
</asp:Content>

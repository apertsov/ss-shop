<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Role
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Role</h2>
<%string[] str=Roles.GetAllRoles();%>
<%for (int i = 0; i < str.Length; i++)
{%>  
    <%using (Html.BeginForm("Delete","Manager")){ %>
      <!--<input type="hidden" value="<%=str[i]%>" name="role" />-->
      <%=Html.Hidden("role",str[i]) %>
      <%=str[i]%>
      <input type="submit" value="X" name="delete" /> <br/>
<%}%>
      <br/>
 <%} %>
      Add new Role
           <%using (Html.BeginForm()){ %>
             Name Role<%=Html.TextBox("Name"," ") %>
             <input type="submit" value="Add" name="a"/>
      <%} %>
</asp:Content>

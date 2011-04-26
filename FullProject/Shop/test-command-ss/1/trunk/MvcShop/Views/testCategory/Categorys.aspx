<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Categorys</title>
</head>
<body>
    <div>
        
    <%using (Html.BeginForm())
      { %>
       id <%=Html.TextBox("Id")%>
       name  <%=Html.TextBox("CategoryName")%>
       <br/>
        <input type="submit" value="Add" name="sa"/>
        <input type="submit" value="Delete" name="sb"/>
        <input type="submit" value="Update" name="sc"/>

       <%} %>
    
    </div>
</body>
</html>

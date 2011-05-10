<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%= Html.ActionLink("English", "ChangeCulture", "Account", 
   new { lang = "en", returnUrl = this.Request.RawUrl }, null)%>
<%= Html.ActionLink("Русский", "ChangeCulture", "Account", 
   new { lang = "ru", returnUrl = this.Request.RawUrl }, null)%>

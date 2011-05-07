<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcShop.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a New Account</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
    </p>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>

              <div class="editor-label">
                    <%=Html.LabelFor(m => m.Fisrt)%>
              </div>
              <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Fisrt)%>
                    <%: Html.ValidationMessageFor(m => m.Fisrt)%>
              </div> 

              <div class="editor-label">
                     <%=Html.LabelFor(m => m.Last)%>
              </div>
              <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Last)%>
                    <%: Html.ValidationMessageFor(m => m.Last)%>
              </div>

              <div class="editor-label">
                     <%=Html.LabelFor(m => m.Address)%>
              </div>
              <div class="editor-field">
                     <%: Html.TextBoxFor(m => m.Address)%>
                    <%: Html.ValidationMessageFor(m => m.Address)%>
              </div>

              <div class="editor-label">
                      <%=Html.LabelFor(m => m.Phone)%>
              </div>
              <div class="editor-field">
                     <%: Html.TextBoxFor(m => m.Phone)%>
                    <%: Html.ValidationMessageFor(m => m.Phone)%>
              </div> 
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>

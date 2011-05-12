<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShopModel.Entities.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Teller
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Teller</h2>

<% ShopModel.Entities.Order[] list = (ShopModel.Entities.Order[]) ViewData["endOrders"]; %>

<table width="90%">

	<tr >
	    <td><b>#</b></td>
	    <td><b>Name</b></td>
	    <td><b>Phone</b></td>
	    <td><b>Address</b></td>
	    <td><b>Ordered</b></td>
	    <td><b>Time</b></td>
        <td><b>Order</b></td>
    </tr>

	<% for (int i = 0; i < list.Length; i++) %>
	<% { %>
	    <%var os = (int)list[i].OrderStatus; %>
            <%if (os == 2)     //if os==End
              { %>
	    <tr>
	        <td><%= list[i].Id%></td>
	        <td><%= list[i].Name%></td>
	        <td><%= list[i].Phone%></td>
	        <td><%= list[i].Address%></td>
	        <td><%= list[i].Start%></td>
	        <td><%= list[i].OnDateTime%></td>
            <td>
                <% for (int j = 0; j < list[i].OrderLines.Count; j++) %>
	            <% { %>
                       <%= list[i].OrderLines[j].Recept.NameRecept%><br/>
                <% } %>
	        </td>
	        
        </tr>
   
    <%} %>
    <%} %>
	</table>

</asp:Content>

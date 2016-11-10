<%@ Page Title="Ticker Users" Language="C#"
	Inherits="System.Web.Mvc.ViewPage" %>

	<h1>Members Only Area </h1>
	<p>Congratulations, <b>
		<%=Session["FriendlyIdentifier"] %></b>. You have completed the OpenID login process.
	</p>
	<p>
		<%=Html.ActionLink("Logout", "logout") %>
	</p>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

	<% if (ViewData["Message"] != null) { %>
	<div style="border: solid 1px red">
		<%= Html.Encode(ViewData["Message"].ToString())%>
	</div>
	<% } %>
	<p>You must log in before entering the Members Area: </p>
	<form action="Authenticate?ReturnUrl=<%=HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]) %>" method="post">
	<label for="openid_identifier">OpenID: </label>
	<input id="openid_identifier" name="openid_identifier" size="40" />
	<input type="submit" value="Login" />
	</form>

	<script type="text/javascript">
	document.getElementById("openid_identifier").focus();
	</script>

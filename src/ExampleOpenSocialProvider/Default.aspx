<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExampleOpenSocialProvider._Default" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>Welcome to the <a target="_blank" href="https://github.com/bittercoder/DevDefined.OAuth">DevDefined.OAuth</a> Open Social Provider Example site.</p>
    
		<p>
		This example demonstrates the <a href="http://oauth.net">OAuth</a> flow of <a href="http://code.google.com/apis/opensocial/articles/tutorial/tutorial-0.8.html" target="_blank">OpenSocial gadgets</a> that fetch data from a remote server
		 using OAuth 1.0 (OpenSocial gadgets spec 1.8 and later).
		</p>
		
		<p>
		This demo has been designed to run against (and has been tested with) the Open Social Gadgets implementation in 
		<a target="_blank" href="http://www.atlassian.com">Jira</a> versions 4 and up  (ah la shindig).  To try it with your own local instance of Jira, 
		you will need to edit the web.config file and specify the consumer key and certificate that Jira specifies on this admin page 
		<a target="_blank" href="http://localhost:8080/plugins/servlet/oauth/view-consumer-info">http://localhost:8080/plugins/servlet/oauth/view-consumer-info</a>.
		</p>

		<p>This sample site  features 2 gadgets</p>
		
		<h3>3 Legged</h3>

		<p>
		The first one is available here: <a target="_blank" href="<%=OpenSocial3LeggedOathV08GadgetUrl %>"><%=OpenSocial3LeggedOathV08GadgetUrl %></a>  - this is an 
		example of a typical 3-legged authorization "dance" - so the user adds the gadget, then authorizes access to their data, and finally sees that 
		data presented in the gadget's frame (in this case contacts from the Data.aspx page).
		</p>

		<h3>Signed</h3>

		<p>
		The second demo gadget is available here: <a target="_blank" href="<%=OpenSocialAuthorizaedV08GadgetUrl %>"><%=OpenSocialAuthorizaedV08GadgetUrl %></a> - this is 
		a gadget that does not delegate authentication and just uses the OAuth library for validating the source of the  request (the request being 
		made to the page SocialService.aspx).  This is designed to be hosted on a publically accessible service
		and tested via Friendster.  <a target="_blank" href="http://blog.bittercoder.com/PermaLink,guid,4f387bde-7ed6-480b-952b-bbc0ead9ebfb.aspx">There is a blog post with further details on this approach here</a>.
		</p>
				
</asp:Content>
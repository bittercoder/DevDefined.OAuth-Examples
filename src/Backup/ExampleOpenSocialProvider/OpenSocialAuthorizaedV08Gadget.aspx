<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenSocialAuthorizaedV08Gadget.aspx.cs" Inherits="ExampleOpenSocialProvider.OpenSocialAuthorizaedV08Gadget" %><?xml version="1.0" encoding="UTF-8" ?>
<Module>
  <ModulePrefs title="OAuth Signed TestBed" description="Testbed to test the OAuth library" title_url="http://www.devdefined.com/" author="Alex Henderson" author_email="bittercoder@gmail.com" author_affiliation="friendster" author_location="Auckland, New Zealand" thumbnail="" icon="">
    <Icon></Icon>
    <Locale lang="en" />
    <Require feature="opensocial-0.8" />
    <Require feature="dynamic-height"/>
    <Require feature="views"/>
  </ModulePrefs>
  <Content type="html">
    <![CDATA[
    <script>
    	function makeRequest(server_url, fn) {
    		var params = {};
    		params[gadgets.io.RequestParameters.METHOD] = gadgets.io.MethodType.GET;
    		params[gadgets.io.RequestParameters.CONTENT_TYPE] = gadgets.io.ContentType.TEXT;
    		params[gadgets.io.RequestParameters.AUTHORIZATION] = gadgets.io.AuthorizationType.SIGNED;
    		gadgets.io.makeRequest(server_url, fn, params);
    	}

    	function renderPage() {
    		var url = '<%=SocialServiceUrl%>';
    		makeRequest(url, pageload_Callback);
    	}

    	function pageload_Callback(data) {
    		var response;
    		if (data.text) { response = data.text; } else if (data.body) { response = data.body; } else { response = data; }
    		if (response.indexOf) {
    			document.getElementById('container').innerHTML = response;
    		}
    	}

    	gadgets.util.registerOnLoadHandler(function () {
    		renderPage();
    	});
    </script>
    <div id="container">
    </div>
  ]]>
  </Content>
</Module>
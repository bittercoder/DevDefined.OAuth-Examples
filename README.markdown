![DevDefined.OAuth logo][1]

Introduction
------------

The DevDefined.OAuth-Examples project is a set of examples demonstrating using the DevDefined.OAuth library for implementing OAuth consumers and providers.
The DevDefined.OAuth project can be found here: [2]

Current Examples
----------------

We currently have 3 examples in this project:

 * ExampleConsumerSite - a simple webforms site - demonstrating an OAuth consumer for consuming an OAuth service that lists contacts (email addresses etc.)
 * ExampleOAuthChannel - a simple WCF service - demonstrating an OAuth provider which securies a WCF service.
 * ExampleProviderSite - a simple webforms site - demonstrating an OAuth provider which exposes a simple contacts service via an aspx page (Data.aspx).
 
Still to do
-----------

 * Currently the WCF example and ExampleProviderSite overlap a bit, each example needs to be made more succinct.
 * Add examples for both Microsoft ASP.Net MVC 2 and Castle Monorail web frameworks.
 * Provide an example of refreshing a token.
 * Add examples of consuming commmon 3rd party services via OAuth, i.e. twitter, facebook, goodreads etc.
 * Write documentation/blog posts for each of the examples - showing the essentials of how they work.
 
  [1]: http://github.com/bittercoder/DevDefined.OAuth/raw/master/artifacts/DevDefinedOAuthTitle.png
  [2]: http://github.com/bittercoder/DevDefined.OAuth
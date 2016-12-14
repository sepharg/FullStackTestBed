About
===================
This a test bed created for the sole purpose of practicing full stack development using several technologies.
The current solution contains a project that calls a third party API (in this case I used the broadbandchoices api, but it can be anything), gets some data, exposes it via an internal web API and displays it in the browser using angular.js
As time goes on I´ll try and create more complex scenarios and probably separate the code into different solutions, as well as making more generic / reusable code.

Current assumptions
===================

 - Everything is part of an Asp net MVC app at the moment. Architecturally speaking this could be divided into several componenents (ToDo) : 
    - Class library that handles requests to third party API (with its own test project)
	- Internal Web API that returns the formatted representation of the bundles (this is debatable and may be overkill though, since our web API is only letting the data pass through)

 -	Error handling is simplified / ignored. The solution needs proper timeout handling, invalid response handling, etc. The same applies for logging and tracing
 - There should be a separation between the returned contents of the API (represented by the Bundle class) and the data presented in the UI. A Bundle -> UI DTO mapping should be used and let the UI use a simplified presentation model DTO. For simplicity I'm reusing the Bundle class throughout all layers. To make this generic, a higher abstraction should be created to handle mapping between third party API entities and our internal representation.
 - Used http://json2csharp.com/ to quickly create C# classes for the API results. May not be the prettiest but they work :). Polishing this we would return only the data that we're interested in using the appropriate data decorators
 - IApiConfiguration implementation has a hardcoded Api key and Baseurl values, this should be read from web config or similar.
 - Added angular scripts to the web page resources directly to save time. In a real world scenario a bootstrapping mechaninsm would be used as well as bundling/minification (i.e. using gulp)

Useful information about the contents
===================

 - FullStackTestBed.Web/BroadbandChoices : 3rd party api client
 - FullStackTestBed.Web/Controllers : simple web api to return json data from the underlying 3rd party api client
 - FullStackTestBed.Web/Scripts/app : angular js app to call our web api and bind data to the presentation layer
 - FullStackTestBed.Web/Views/Home/Index.cshtml : simple view to bind to angular js app and present the data to the user when requested
 - FullStackTestBed.Web/Scripts/jasmine-tests : jasmine tests for angular controller
 - FullStackTestBed.Web.Tests/BroadbandChoices : unit and integration tests against the 3rd party api

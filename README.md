Stratsys Api v1 - .NET Client Library
==============

Introduction
--------------
Repository contains both Stratsys.Apis.v1 used for accessing Stratsys Apis v1 as well as Stratsys.Apis.v1.ExampleTests with examples of usage. All available functionality in Stratsys Api v1 is accessible using this client library. 

Authorization
--------------
ClientId and ClientSecret needed for authorization is administrated on an application inside Stratsys. Access to temporary demo environment can be given by contacting Stratsys support.

Setup
--------------
NuGet packages needs to be restored for project to build. For usage of example tests Stratsys.Apis.v1.ExampleTests/App.config needs to be set with valid TestClientId and TestClientSecret.

Resources
--------------
The following Stratsys entity types can be accessed using Stratsys Api v1.
- *Departments*
- *Kpis*
- *KpiData*
- *KpiColumns*
- *Periodicities*
- *Scorecards*

Technical usage
--------------
Synchronous and asynchronous calls both are supported by client library. The resulting object from the response and the HttpResponseMessage are accessed in examples below. 
```csharp
var departments = new DepartmentService(ClientId, ClientSecret).Departments;
departments.Get(id).GetHttpResponse()
departments.Get(id).Fetch()
await departments.Get(id).GetHttpResponseAsync()
await departments.Get(id).FetchAsync()
```

NuGet Feed
--------------
Stratsys Api v1 - .NET Client Library can alse be retrieved with NuGet feed https://www.myget.org/F/stratsys/

Api Documentation
--------------
Further detailed documentation of Stratsys Api v1 can be found from Stratsys Developer page.

References
--------------
http://www.stratsys.se - Stratsys

About Stratsys
--------------
*Stratsys help companies and organizations to become successful and competitive by supporting them in their work to achieve their goals. With the help of Stratsys methods and tools, business strategies are made real.*


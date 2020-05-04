# [DEPRECATED]

Stratsys Api v1 - .NET Client Library
==============

Introduction
--------------
Repository contains both Stratsys.Apis.v1 used for accessing Stratsys Apis v1 as well as Stratsys.Apis.v1.ExampleTests with examples of usage. All functionality available in Stratsys Api v1 is accessible using this client library. 

Authorization
--------------
ClientId and ClientSecret needed for authorization is generated from creating an application inside Stratsys. Access to a demo environment for testing purposes can be retrieved by contacting Stratsys support.

Setup
--------------
NuGet packages needs to be restored for solution to build. For usage of example tests Stratsys.Apis.v1.ExampleTests/App.config needs to be set with valid TestClientId and TestClientSecret.

Resources
--------------
The following Stratsys entity types can be accessed using Stratsys Api v1.
- *Activity*
- *Authorization*
- *Comment*
- *Department*
- *Goal*
- *KpiColumn*
- *KpiData*
- *Kpi*
- *Periodicity*
- *ReportingList*
- *Scorecard*
- *Status*
- *User*

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
Further detailed documentation of Stratsys Api v1 can be found within Stratsys Developer page.

Code Sample
--------------
Code Sample for finding Kpis matching a name criteria
```csharp
using System;
using System.Net;
using System.Threading.Tasks;
using Stratsys.Apis.v1.Apis;

namespace StratsysApiV1
{
    /// <summary>
    /// Stratsys API v1 sample: find Kpis from name.
    /// Set clientId and clientSecret to the API from generated values found from Stratsys administration of applications.
    /// </summary>
    internal class FindKpisWithName
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Stratsys Kpi API: Find Kpis with name");
            Console.WriteLine("========================");

            try
            {
                new FindKpisWithName().Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task Run()
        {
            var stratsysApi = new StratsysApi("clientId", "clientSecret");
            var checkAccessResponseMessage = await stratsysApi.Authorizations.CheckAccess().GetHttpResponseAsync();
            if (checkAccessResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(checkAccessResponseMessage.StatusCode + "");
            }

            var apiResult = await stratsysApi.Kpis.Filter(name: "nameFilter").FetchAsync();
            if (!apiResult.Success)
            {
                throw new Exception(apiResult.Message);
            }

            var kpis = apiResult.Result;
            foreach (var kpi in kpis)
            {
                Console.WriteLine("Kpi: {0}", kpi.Name);
                Console.WriteLine("Id: {0}", kpi.Id);
                Console.WriteLine("DepartmentId: {0}", kpi.DepartmentId);
                Console.WriteLine("KpiColumnIds: {0}", string.Join(", ", kpi.KpiColumnIds));
                Console.WriteLine("========================");
            }

            Console.WriteLine("Total number of found Kpis matching criterias: {0}", kpis.Count);
            Console.WriteLine("========================");
        }
    }
}
```

References
--------------
http://www.stratsys.se - Stratsys

About Stratsys
--------------
*Stratsys help companies and organizations to become successful and competitive by supporting them in their work to achieve their goals. With the help of Stratsys methods and tools, business strategies are made real.*


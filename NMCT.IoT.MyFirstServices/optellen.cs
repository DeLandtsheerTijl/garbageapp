
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NMCT.IoT.MyFirstServices
{
    public static class optellen
    {

        [FunctionName("somberekenen")]
        public static async Task<IActionResult> somberekenen([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "som/{nr1}/{nr2}")]HttpRequest req, int nr1, int nr2, ILogger log)
        {
            int som = nr1 + nr2;
            string result = "De som is:  " + Convert.ToString(som) + ".";
            return new OkObjectResult(result);
            //    log.LogInformation("C# HTTP trigger function processed a request.");

            //    string name = req.Query["name"];

            //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //    dynamic data = JsonConvert.DeserializeObject(requestBody);
            //    name = name ?? data?.name;

            //    return name != null
            //        ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

    }
}

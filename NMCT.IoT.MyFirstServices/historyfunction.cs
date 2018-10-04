
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
    public static class historyfunction
    {
        [FunctionName("history")]
        public static async Task<IActionResult> history([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            string from = string.Empty;
            string to = string.Empty;

            foreach (var key in req.Query.Keys)
            {
                if (key == "from")
                    from = req.Query["from"];

                if (key == "to")
                    from = req.Query["to"];
            }


            string result = "From " + from + " tot " + to;
            log.LogInformation($"From:{from} to {to}");
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

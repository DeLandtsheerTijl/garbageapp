
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
    public static class delen
    {
        [FunctionName("deelfunction")]
        public static async Task<IActionResult> deelfunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "delen/{nr1}/{nr2}")]HttpRequest req, int nr1, int nr2, ILogger log)
        {
            try
            {
                if (nr2 == 0) return new BadRequestObjectResult("0 niet toegelaten");
                double uitkomst = Convert.ToDouble(nr1) / Convert.ToDouble(nr2);
                string result = "De uitkomst is:  " + Convert.ToString(uitkomst) + ".";
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
                throw;
            }
            
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

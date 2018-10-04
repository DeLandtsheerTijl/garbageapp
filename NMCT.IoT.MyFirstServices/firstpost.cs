
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
using NMCT.IoT.MyFirstServices.Models;

namespace NMCT.IoT.MyFirstServices
{
    public static class firstpost
    {

        [FunctionName("som")]
        public static async Task<IActionResult> som([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "som/firstpost/")]HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            SomModel model = JsonConvert.DeserializeObject<SomModel>(requestBody);

            int result = model.Getal1 + model.Getal2;

            SomResultaat som = new SomResultaat();
            som.Resultaat = result;

            return new OkObjectResult(som);




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

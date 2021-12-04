using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AppSix
{
    public static class AppSix
    {
        [FunctionName("AppSix")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "{name}")] HttpRequest req,
            string name)
        {
            //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            User user = new User();
            user.UserName = name;
            UserContext userContext = new UserContext();
            userContext.Add(user);
            userContext.SaveChanges();
            user.UserName = $"hello, {name}";
            return new OkObjectResult(user);
        }
    }
}

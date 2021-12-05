using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Linq;

namespace AppSix
{
    public static class MyEmail
    {
        [FunctionName("MyEmail")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ClaimsPrincipal claimsPrincipal)
        {
            var emailClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "emails");
            String email;
            if(emailClaim is null)
            {
                email = "no email found";
            }
            else
                email = emailClaim.Value;
            return new OkObjectResult(email);
        }
    }

    public class ReturnValue
    {
        public string Email { get; set; }
    }
}

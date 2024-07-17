using ApwPayrollWebApp.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApwPayrollWebApp.Controllers.Common
{
    public class BaseController:Controller
    {
        public void Notify(List<string> message, string? title, int statusCode)
        {
            NotificationToasterTypeEnum toasterType;

            switch (statusCode)
            {
                case 200:
                    toasterType = NotificationToasterTypeEnum.success;
                    break;
                case 400:
                case 404:
                    toasterType = NotificationToasterTypeEnum.error;
                    break;
                default:
                    toasterType = NotificationToasterTypeEnum.info; // Default to info for other statuses
                    break;
            }
            var msg = new
            {
                message = message,
                title = title?? "",
                icon = toasterType.ToString(),
                type = toasterType.ToString(),
                provider = GetProvider()

            };
            TempData["Message"]=JsonConvert.SerializeObject(msg);

        }


        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();
                ;
            IConfiguration configuration = builder.Build();
            var value = configuration["NotificationProvider"];
            return value;
        }
    }
}

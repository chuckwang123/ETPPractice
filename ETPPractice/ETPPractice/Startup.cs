using System.Web.Http;
using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.Runtime;
using Microsoft.Owin.Cors;
using Owin;
using Serilog;
using Serilog.Sinks.AwsCloudWatch;
using Swashbuckle.Application;
using LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory;

namespace ETPPractice
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            httpConfiguration.EnsureInitialized();
            httpConfiguration.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"));
            app.UseCors(CorsOptions.AllowAll)
                .UseWebApi(httpConfiguration);
                

            // name of the log group
            var logGroupName = "myLogGroup/Logs";
            // options for the sink, specifying the log group name
            var options = new CloudWatchSinkOptions { LogGroupName = logGroupName };

            // setup AWS CloudWatch client
            AWSCredentials credentials = new BasicAWSCredentials("AKIAJ6FNCCY6XKCAXKFA", "Jcs23DSuKeGyZn8vqJm7C7NuS4FP0tQMbccCAxeu");
            IAmazonCloudWatchLogs client = new AmazonCloudWatchLogsClient(credentials, RegionEndpoint.USEast1);
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
                .WriteTo.AmazonCloudWatch(options, client)
                .CreateLogger();

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog();
        }
    }
}

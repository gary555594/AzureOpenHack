
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace GetRatings
{
    public static class Function1
    {
        public static class DocByIdFromQueryString
        {
            [FunctionName("GetRating")]
            public static HttpResponseMessage Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
                [DocumentDB(
                databaseName: "bfyoc",
                collectionName: "ratings",
                ConnectionStringSetting = "CONN_STRING",
                Id = "{Query.id}")] Rating ratingItem,
                TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
                if (ratingItem == null)
                {
                    log.Info($"ToDo item not found");
                }
                else
                {
                    log.Info($"Found ToDo item, Description={ratingItem.productId}");
                }
                                
                return req.CreateResponse(HttpStatusCode.OK,ratingItem);
            }
        }
    }
}

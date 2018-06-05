using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GetRatings;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace GetRating
{
    public static class GetRating
    {
        [FunctionName("GetRating")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestMessage req,
            [DocumentDB(
                databaseName: "bfyoc",
                collectionName: "ratings",
                ConnectionStringSetting = "CONN_STRING",
                Id = "{Query.ratingId}")] Rating rating,
            TraceWriter log)

        {
            log.Info("C# HTTP trigger function processed a request.");

            return rating == null
                ? req.CreateResponse(HttpStatusCode.NotFound, "ratingId not found.")
                : req.CreateResponse(HttpStatusCode.OK, rating);
        }
    }

    
}

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fti.Workday;

public partial class Leave
{
    [FunctionName(nameof(ImportApprovedLeaveHttp))]
    public async Task<IActionResult> ImportApprovedLeaveHttp(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")]
        HttpRequest req,
        [DurableClient] IDurableOrchestrationClient starter)
    {

        string instanceId = await starter.StartNewAsync(nameof(ImportApprovedLeave));

            // Returns an HTTP 202 response with an instance management payload.
            // See https://learn.microsoft.com/azure/azure-functions/durable/durable-functions-http-api#start-orchestration
        return starter.CreateCheckStatusResponse(req, instanceId);

    }
}
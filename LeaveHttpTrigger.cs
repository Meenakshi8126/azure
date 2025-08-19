using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;

namespace Fti.Workday;

public partial class Leave
{
    [Function(nameof(ImportApprovedLeaveHttp))]
    public async Task<HttpResponseData> ImportApprovedLeaveHttp(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")]
        HttpRequestData req, //HttpRequest req,
        [DurableClient] DurableTaskClient starter)
    {

        string instanceId = await starter.ScheduleNewOrchestrationInstanceAsync(nameof(ImportApprovedLeave));

            // Returns an HTTP 202 response with an instance management payload.
            // See https://learn.microsoft.com/azure/azure-functions/durable/durable-functions-http-api#start-orchestration
        return await starter.CreateCheckStatusResponseAsync(req, instanceId);

    }
}
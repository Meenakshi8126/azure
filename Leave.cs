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

    [Function(nameof(ImportApprovedLeaveTimer))]
    public async Task ImportApprovedLeaveTimer(
        [TimerTrigger("0 0 2 * * *")] TimerInfo timer,
        [DurableClient] DurableTaskClient starter)
    {
        string instanceId = await starter.ScheduleNewOrchestrationInstanceAsync(nameof(ImportApprovedLeave));
        
        // Log the orchestration instance ID for monitoring
        // You can add logging here if needed
    }
}
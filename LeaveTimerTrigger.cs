using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace Fti.Workday;

public partial class Leave
{
    [FunctionName(nameof(ImportApprovedLeaveTimer))]
    public async Task ImportApprovedLeaveTimer(
        [TimerTrigger("0 0 2 * * *")] TimerInfo timer,
        [DurableClient] IDurableOrchestrationClient starter)
    {
        string instanceId = await starter.StartNewAsync(nameof(ImportApprovedLeave));
        
        // Log the orchestration instance ID for monitoring
        // You can add logging here if needed
    }
}
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;

namespace Fti.Workday;

public partial class Leave
{
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
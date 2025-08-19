namespace Fti.Workday.Api;
public partial class WorkdayApiService
{
    public async Task<List<ApprovedLeave>> GetApprovedLeaveAsync(DateTimeOffset fromDateUtc, DateTimeOffset toDateUtc)
    {
        HttpClient client = _httpClientFactory.CreateClient(_namedClient);

        string fromDateUtcParam = fromDateUtc.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        string toDateUtcParam = toDateUtc.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        // string fromDate = "2025-02-02T21:06:35Z";
        // string toDate = "2025-08-01T21:06:35Z";

        /*  Uncomment for testing without making a call to Workday

            List<ApprovedLeave> list = new()
            {
                new ApprovedLeave() { EmployeeId = "10001", LeaveDate = new DateOnly(month: 6, day: 4, year: 2025), Hours = 4 * 3600, Comments = "test", LastUpdateUTC=DateTimeOffset.UtcNow},
                new ApprovedLeave() { EmployeeId = "10001", LeaveDate = new DateOnly(month: 6, day: 5, year: 2025), Hours = 4 * 3600, Comments = "test 2", LastUpdateUTC=DateTimeOffset.UtcNow}
            };
           return list;
        */


        HttpResponseMessage response = await client.GetAsync(
            $"{_apiBase}CR_BROKER-ApprovedLeave?format=json&fromDateUTC={fromDateUtcParam}&toDateUTC={toDateUtcParam}");

        string result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            ApprovedLeaveReport approvedLeaveReport = result.JsonToObject<ApprovedLeaveReport>();

            // Convert hours to seconds for each approved leave record
            foreach (var leave in approvedLeaveReport.ApprovedLeaveRecords)
            {
                leave.Hours = leave.Hours * 3600;
            }

            return approvedLeaveReport.ApprovedLeaveRecords;
        }

        throw CreateWorkdayApiException(response.StatusCode, result);

    }
}
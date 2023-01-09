namespace IWantAPI.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "Employee005Policy")]
    public static async Task<IResult> Action(int? page,int? rows, QueryAllUsersWithClaimName query)
    {
        
        return Results.Ok(await query.Execute(page.Value,rows.Value));
    }
}

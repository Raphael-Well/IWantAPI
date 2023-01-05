using IWantAPI.Domain.Products;
using IWantAPI.Infra.Data;

namespace IWantAPI.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category(categoryRequest.Name, "teste", "teste");

        if(!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }
            

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}

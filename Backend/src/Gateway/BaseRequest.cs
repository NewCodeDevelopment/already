using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Gateway;

public abstract class BaseRequest
{
    protected const string BaseRoute = "/Api/";
    public const string ProductRoute = BaseRoute + "Products";
    public const string OrderRoute = BaseRoute + "Orders";
    public const string BasketRoute = BaseRoute + "Baskets";
}

public class BaseRequestById: BaseRequest
{
    [Required] 
    [FromRoute(Name = "Id")] public Guid Id { get; set; } = default!;
}
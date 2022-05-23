using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Gateway;

public class BaseRequest
{
    protected const string BaseRoute = "/Api/";
    public const string ProductRoute = BaseRoute + "Products";
    
    public class BaseRequestById: BaseRequest
    {
        [Required] 
        [FromRoute(Name = "Id")] public Guid Id { get; set; } = default!;
    }
}

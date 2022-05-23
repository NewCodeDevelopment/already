using System.Text.Json.Serialization;
using Shared.Services;
namespace Gateway;

public abstract class BaseDto
{
    public string Id { get; set; }
    public string CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }

    public BaseDto(Guid id, DateTimeOffset createdAt, DateTimeOffset updatedAt)
    {
        Id = id.ToString();
        CreatedAt = DateTimeOffsetService.ToLongDateTimeString(createdAt);
        UpdatedAt = DateTimeOffsetService.ToLongDateTimeString(updatedAt);
    }
  
    [JsonConstructor]
    public BaseDto(string id, string createdAt, string updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt =updatedAt;
    }
}

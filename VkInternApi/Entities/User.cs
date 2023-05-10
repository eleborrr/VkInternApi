namespace VkInternApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public int UserGroupId { get; set; }
    public int UserStateId { get; set; }
    public bool Active { get; set; }
}
namespace VkInternApi.Data.Dto;

public class ShowUserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserGroupId { get; set; }
    public int UserStateId { get; set; }
    public string GroupCode { get; set; }
    public string GroupDescription { get; set; }
    public string StateCode { get; set; }
    public string StateDescription { get; set; }
    public bool Active { get; set; }
}
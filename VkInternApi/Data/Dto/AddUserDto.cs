using System.ComponentModel.DataAnnotations;

namespace VkInternApi.Data.Dto;

public class AddUserDto
{
    [Required]
    [Range(10, 30)]
    public string Login { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    public int UserGroupId { get; set; }
    
    [Required]
    public int UserStateId { get; set; }
}
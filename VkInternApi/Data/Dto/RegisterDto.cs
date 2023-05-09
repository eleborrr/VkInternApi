using System.ComponentModel.DataAnnotations;

namespace VkInternApi.Data.Dto;

public class RegisterDto
{
    [Required]
    [Range(10, 30)]
    public string Login { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}
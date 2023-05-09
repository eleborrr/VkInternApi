using System.ComponentModel.DataAnnotations;

namespace VkInternApi.Data.Dto;

public class DeleteUserDto
{
    [Required]
    public int Id { get; set; }
}
namespace VkInternApi.Data.Dto;

public class UserChangeResponseDto
{
    public UserChangeResponseDto(bool isSuccessful, string message)
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
}
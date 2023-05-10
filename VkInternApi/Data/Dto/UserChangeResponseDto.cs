namespace VkInternApi.Data.Dto;

public class UserChangeResponseDto
{
    public UserChangeResponseDto(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
    public int StatusCode { get; set; }
    public string Message { get; set; }
}
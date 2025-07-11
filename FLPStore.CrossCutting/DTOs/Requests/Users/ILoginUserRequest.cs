namespace FLPStore.CrossCutting.DTOs.Requests.Users
{
    public interface ILoginUserRequest
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
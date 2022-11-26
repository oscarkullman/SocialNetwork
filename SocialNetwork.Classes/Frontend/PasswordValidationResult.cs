namespace SocialNetwork.Classes.Frontend
{
    public class PasswordValidationResult
    {
        public PasswordValidationResult(string message = "", bool success = false)
        {
            Message = message;
            Success = success;
        }
        
        public string? Message { get; set; }

        public bool Success { get; set; }
    }
}

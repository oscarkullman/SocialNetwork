namespace SocialNetwork.Classes.Frontend
{
    public class SignUpValidationResult
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? RepeatPassword { get; set; }

        public bool Success { get; set; }
    }
}

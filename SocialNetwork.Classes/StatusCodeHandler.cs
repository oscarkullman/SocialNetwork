namespace SocialNetwork.Classes
{
    public class StatusCodeHandler
    {
        public StatusCodeHandler(int? code = null, string? message = null)
        {
            Code = code;
            Message = message;

            if (code.HasValue && code >= 200 && code < 300)
                IsSuccessful = true;
        }

        public int? Code { get; set; }

        public List<string>? Errors { get; set; }

        public string? Message { get; set; }

        public bool IsSuccessful { get; private set; }
    }
}

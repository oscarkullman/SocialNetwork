namespace WebAPI.Infrastructure.Specification.Params
{
    public class UserParams
    {
        private string? _username;

        private string? _sort;

        public string? Username
        {
            get { return _username; }
            set { _username = (value != null ? value.ToLower() : value); }
        }

        public string? Sort
        {
            get { return _sort; }
            set { _sort = (value != null ? value.ToLower() : value); }
        }
    }
}

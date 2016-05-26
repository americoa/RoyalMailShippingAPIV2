
namespace RoyalMail.Common
{
    public sealed class Config
    {
        private const string _urlapp = "https://api.royalmail.net/shipping/v2";
#error Use Your information here
        private const string _clientSecret = "";
        private const string _clientId = "";
        public string UrlApp { get { return _urlapp; }}
        public string ClientSecret { get { return _clientSecret; } }
        public string ClientId { get { return _clientId; } }
    }
}

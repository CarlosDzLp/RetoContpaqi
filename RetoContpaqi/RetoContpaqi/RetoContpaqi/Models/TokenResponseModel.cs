namespace RetoContpaqi.Models
{
    public class TokenResponseModel
    {
        public string AccessToken { get; set; }
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenResponseModel(string responseString)
        {
            var responseParams = System.Web.HttpUtility.ParseQueryString(responseString);
            AccessToken = responseParams["access_token"];
            IdToken = responseParams["id_token"];
            RefreshToken = responseParams["refresh_token"];
        }
    }
}

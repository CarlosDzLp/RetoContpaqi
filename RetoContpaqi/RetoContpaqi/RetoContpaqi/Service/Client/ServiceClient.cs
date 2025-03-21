using Newtonsoft.Json;
using Refit;
using RetoContpaqi.Helpers;
using RetoContpaqi.Models;
using System.Net;

namespace RetoContpaqi.Service.Client
{
    public class ServiceClient : IServiceClient
    {
        #region Properties
        protected HttpClient _httpClient;
        protected RefitSettings _refitSettings;
        protected JsonSerializerSettings _jsonSerializerSettings;
        protected IConnectionService _connectionService;
        #endregion

        #region Constructor
        public ServiceClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(KeyDictionary.URL_BASE),
                Timeout = TimeSpan.FromSeconds(KeyDictionary.TIME_OUT),
            };
            _refitSettings = new RefitSettings();
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                Error = (sender, args) => args.ErrorContext.Handled = true,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
            };
            _refitSettings.ContentSerializer = new NewtonsoftJsonContentSerializer(_jsonSerializerSettings);
            _connectionService = Refit.RestService.For<IConnectionService>(_httpClient, _refitSettings);
        }
        #endregion

        #region Methods
        public async Task<List<UserModel>> ListUser()
        {
            try
            {
                var result = await _connectionService.ListUser();
                if (result.StatusCode == HttpStatusCode.OK)
                    return result.Content;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}

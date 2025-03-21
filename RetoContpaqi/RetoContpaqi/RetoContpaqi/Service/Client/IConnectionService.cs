using Refit;
using RetoContpaqi.Models;

namespace RetoContpaqi.Service.Client
{
    [Headers("Content-Type: application/json;", "Api-Version: 1.0", "accept: */*")]
    public interface IConnectionService
    {
        #region Service
        [Get("/users")]
        Task<ApiResponse<List<UserModel>>> ListUser();
        #endregion
    }
}

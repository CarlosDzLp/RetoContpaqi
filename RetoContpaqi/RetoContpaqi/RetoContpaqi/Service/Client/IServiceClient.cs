using RetoContpaqi.Models;

namespace RetoContpaqi.Service.Client
{
    public interface IServiceClient
    {
        #region Service
        Task<List<UserModel>> ListUser();
        #endregion
    }
}

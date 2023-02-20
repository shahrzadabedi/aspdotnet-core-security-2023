using System.Threading.Tasks;

namespace SecurityApp.Service.Interfaces
{

    public interface IRepositoryManager
    {
       
        IUserAuthenticationRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}

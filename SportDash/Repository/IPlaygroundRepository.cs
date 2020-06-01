using SportDash.Data;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IPlaygroundRepository
    {
        Task<ApplicationUser> GetPlayground(string id);
    }
}
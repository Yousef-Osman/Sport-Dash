using SportDash.Models;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IConnectedUsersRepository
    {
        ConnectedUser GetConnectionIdOfUser(string userId);
    }
}
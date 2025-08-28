using System.Collections.Generic;
using System.Threading.Tasks;
using Net5Angular8.Models;

namespace Net5Angular8.Services
{
    public interface IPositionsService
    {
        Task<IEnumerable<Position>> GetPositionsList();
    }
}

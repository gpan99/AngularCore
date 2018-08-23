using System.Collections.Generic;
using System.Threading.Tasks;

namespace TourManagement.API.Entities
{
    public interface IStatesRepository
    {
        Task<List<State>> GetStatesAsync();
    }
}
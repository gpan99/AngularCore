using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Helpers;

namespace TourManagement.API.Entities {
    public interface IUsersRepository
    {     
        Task<List<User>> GetUsersAsync(UserResourceParameters authorsResourceParameters);
        Task<User> GetUserAsync(int id);    
        Task<User> InsertUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
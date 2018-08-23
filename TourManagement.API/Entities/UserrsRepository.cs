using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using TourManagement.API.Services;
using TourManagement.API.Helpers;

namespace TourManagement.API.Entities
{
    public class UsersRepository : IUsersRepository
    {

        private readonly TourManagementContext _Context;
        private readonly ILogger _Logger;

        public UsersRepository(TourManagementContext context, ILoggerFactory loggerFactory) {
          _Context = context;
          _Logger = loggerFactory.CreateLogger("UsersRepository");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _Context.Users.OrderBy(c => c.LastName)
                                 .Include(c => c.Department).ToListAsync();
        }
        public Task<List<User>> GetUsersAsync(UserResourceParameters authorsResourceParameters)
        {
            if (!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                // trim & ignore casing
                var searchQueryForWhereClause = authorsResourceParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                var collection =  _Context.Users
                    .OrderBy(a => a.FirstName)
                    .ThenBy(a => a.LastName).Include(c => c.Department)
                    .AsQueryable();

                collection = collection
                    .Where(a => a.FirstName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || a.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause));

                return collection.ToListAsync();
            }
            return  _Context.Users.OrderBy(c => c.LastName)
                                 .Include(c => c.Department).ToListAsync();
        }
 
        public async Task<List<User>> GetUsersByNameAsync(string name)
        {
            return await _Context.Users.Where(c => c.FirstName.Contains(name))
                                 .Include(c => c.Department).ToListAsync();
        }

        public async Task<PagingResult<User>> GetUsersPageAsync(int skip, int take)
        {
            var totalRecords = await _Context.Users.CountAsync();
            var users = await _Context.Users
                                 .OrderBy(c => c.LastName)
                                 .Include(c => c.Department)
       
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
            return new PagingResult<User>(users, totalRecords);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _Context.Users
                                 .Include(c => c.Department)
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            _Context.Add(user);
            try
            {
              await _Context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
               _Logger.LogError($"Error in {nameof(InsertUserAsync)}: " + exp.Message);
            }

            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            //Will update all properties of the User
            _Context.Users.Attach(user);
            _Context.Entry(user).State = EntityState.Modified;
            try
            {
              return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
               _Logger.LogError($"Error in {nameof(UpdateUserAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            //Including orders since there's a foreign-key constraint and we need
            //to remove the orders in addition to the user
            var user = await _Context.Users
                                .SingleOrDefaultAsync(c => c.Id == id);
            _Context.Remove(user);
            try
            {
              return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
               _Logger.LogError($"Error in {nameof(DeleteUserAsync)}: " + exp.Message);
            }
            return false;
        }

    
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Services;
using ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        //Injection
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create
        public User Add(User newUser)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.Id == newUser.Id);

            if(user == null)
            {
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public User Get(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            return _dbContext.Users
                .Include(u => u.Activities)
                .FirstOrDefault(u => u.Id == id);
        }

        public User Update(User updatedUser)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

            if (user == null)
                return null;

            _dbContext.Entry(user)
                .CurrentValues
                .SetValues(updatedUser);
            _dbContext.Users.Update(user);

            _dbContext.SaveChanges();

            return updatedUser;
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _dbContext.Users.ToList();
            if (users == null)
                return null;

            return _dbContext.Users
                .Include(u => u.Activities)
                .ToList();
        }

    }
}

using ExerciseLogAPI.Core.Models;
using System.Collections.Generic;

namespace ExerciseLogAPI.Core.Services
{
    public interface IUserService
    {
        User Add(User user);
        User Get(int id);
        void Remove(User user);
        User Update(User updatedUser);
        IEnumerable<User> GetAll();
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public class UserService : IUserService
    {
        //Injection
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        //Add
        public User Add(User user)
        {
            User newUser = _userRepo.Add(user);

            if (newUser == null)
                throw new ApplicationException("Can not make duplicate entry of same user.");

            return newUser;
        }

        //Get
        public User Get(int id)
        {
            User user = _userRepo.Get(id);

            if (user == null)
                throw new ApplicationException("Could not find user.");

            return user;
        }

        //Update
        public User Update(User updatedUser)
        {
            var user = _userRepo.Update(updatedUser);

            if (user == null)
                throw new ApplicationException("Could not update user.");

            return user;
        }

        //Delete
        public void Remove(User user)
        { 
            //Error Handling done by calling _userRepo.Get(id) from UserController
            _userRepo.Remove(user);
        }

        //List
        public IEnumerable<User> GetAll()
        {
           IEnumerable<User> users =_userRepo.GetAll();

            if (users == null)
                throw new ApplicationException("Cannot return list of users.");

            return users;
        }
    }
}

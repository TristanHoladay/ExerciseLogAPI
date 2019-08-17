using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtensions
    {
        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                Name = userModel.Name,
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> users)
        {
            return users.Select(u => u.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> userModels)
        {
            return userModels.Select(u => u.ToDomainModel());
        }
    }
}

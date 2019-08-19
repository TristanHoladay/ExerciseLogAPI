using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        //Create
        Activity Add(Activity activity);

        //Read
        Activity Get(int id);

        //Update
        Activity Update(Activity activity);

        //Delete
        void Remove(Activity activity);

        //List
        IEnumerable<Activity> GetAll();
    }
}

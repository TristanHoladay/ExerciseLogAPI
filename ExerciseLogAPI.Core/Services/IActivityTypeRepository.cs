using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeRepository
    {
        //Create
        ActivityType Add(ActivityType type);

        //Read
        ActivityType Get(int id);

        //Update
        ActivityType Update(ActivityType type);

        //Delete
        void Remove(ActivityType type);

        //List
        IEnumerable<ActivityType> GetAll();
    }
}

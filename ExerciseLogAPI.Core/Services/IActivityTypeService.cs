using System.Collections.Generic;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeService
    {
        ActivityType Add(ActivityType type);
        ActivityType Get(int id);
        IEnumerable<ActivityType> GetAll();
        void Remove(ActivityType type);
        ActivityType Update(ActivityType updatedType);
    }
}
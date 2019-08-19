using System.Collections.Generic;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public interface IActivityService
    {
        Activity Add(Activity activity);
        Activity Get(int id);
        IEnumerable<Activity> GetAll();
        void Remove(Activity activity);
        Activity Update(Activity updatedActivity);
    }
}
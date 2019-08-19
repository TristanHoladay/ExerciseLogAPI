using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        //Injection
        private IActivityTypeRepository _activityTypeRepo { get; set; }

        public ActivityTypeService(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepo = activityTypeRepository;
        }

        //Create
        public ActivityType Add(ActivityType type)
        {
            _activityTypeRepo.Add(type);
            return type;
        }

        //Get
        public ActivityType Get(int id)
        {
            return _activityTypeRepo.Get(id);
        }

        //Update
        public ActivityType Update(ActivityType updatedType)
        {
            var type = _activityTypeRepo.Update(updatedType);

            return type;
        }

        //Delete
        public void Remove(ActivityType type)
        {
            _activityTypeRepo.Remove(type);
        }

        //List
        public IEnumerable<ActivityType> GetAll()
        {
            return _activityTypeRepo.GetAll();
        }
    }
}

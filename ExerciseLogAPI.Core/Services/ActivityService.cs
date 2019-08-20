using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {

        //Injection
        private IActivityRepository _activityRepo { get; set; }
        private IActivityTypeRepository _activityTypeRepo { get; set; }

        public ActivityService(IActivityRepository activityRepo, IActivityTypeRepository activityTypeRepository)
        {
            _activityRepo = activityRepo;
            _activityTypeRepo = activityTypeRepository;
        }



        //Create
        public Activity Add(Activity activity)
        {
            var activityType = _activityTypeRepo.Get(activity.ActivityTypeId);
            if(activityType.RecordType == RecordType.DurationAndDistance && activity.Distance <= 0)
            {
                throw new ApplicationException("You must supply a Distance for this activity.");
            }

            if(activity.Duration <=0 )
            {
                throw new ApplicationException("You must supply a duration for this activity.");
            }
            _activityRepo.Add(activity);
            return activity;
        }

        //Get
        public Activity Get(int id)
        {
            return _activityRepo.Get(id);
        }

        //Update
        public Activity Update(Activity updatedActivity)
        {
            var activity = _activityRepo.Update(updatedActivity);

            return activity;
        }

        //Delete
        public void Remove(Activity activity)
        {
            _activityRepo.Remove(activity);
        }

        //List
        public IEnumerable<Activity> GetAll()
        {
            return _activityRepo.GetAll();
        }
    }
}

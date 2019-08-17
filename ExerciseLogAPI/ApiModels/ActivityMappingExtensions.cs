using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtensions
    {
        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                Date = activity.Date,
                ActivityTypeId = activity.ActivityTypeId,
                ActivityType = activity.ActivityType != null
                    ? activity.ActivityType.Name 
                    : null,
                Duration = activity.Duration,
                Distance = activity.Distance,
                UserId = activity.UserId,
                User = activity.User != null
                    ? activity.User.Name
                    : null,
                Notes = activity.Notes,
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                Date = activityModel.Date,
                ActivityTypeId = activityModel.ActivityTypeId,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                UserId = activityModel.UserId, 
                Notes = activityModel.Notes,

            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
           return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}

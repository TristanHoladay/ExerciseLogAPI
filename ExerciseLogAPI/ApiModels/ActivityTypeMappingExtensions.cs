using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.ApiModels
{
    public static class ActivityTypeMappingExtensions
    {
        public static ActivityTypeModel ToApiModel(this ActivityType activityType)
        {
            return new ActivityTypeModel
            {
                Id = activityType.Id,
                Name = activityType.Name,
                RecordType = activityType.RecordType,
            };
        }

        public static ActivityType ToDomainModel(this ActivityTypeModel activityTypeModel)
        {
            return new ActivityType
            {
                Id = activityTypeModel.Id,
                Name = activityTypeModel.Name,
                RecordType = activityTypeModel.RecordType,
            };
        }

        public static IEnumerable<ActivityTypeModel> ToApiModels(this IEnumerable<ActivityType> activityTypes)
        {
            return activityTypes.Select(at => at.ToApiModel());
        }

        public static IEnumerable<ActivityType> ToDomainModels(this IEnumerable<ActivityTypeModel> activityTypeModels)
        {
            return activityTypeModels.Select(at => at.ToDomainModel());
        }
    }
}

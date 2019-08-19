using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Services;
using ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        //Injection
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create
        public ActivityType Add(ActivityType newActivityType)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(at => at.Id == newActivityType.Id);

            if (activityType == null)
            {
                _dbContext.ActivityTypes.Add(newActivityType);
                _dbContext.SaveChanges();
                return newActivityType;
            }
            else
            {
                return null;
            }
        }

        public ActivityType Get(int id)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(at => at.Id == id);

            if (activityType == null)
            {
                throw new ApplicationException("Could not find user.");
            }

            return _dbContext.ActivityTypes
                .Include(at => at.RecordType)
                .FirstOrDefault(at => at.Id == id);
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(at => at.Id == updatedActivityType.Id);

            if (activityType == null)
                return null;

            _dbContext.Entry(activityType)
                .CurrentValues
                .SetValues(updatedActivityType);
            _dbContext.ActivityTypes.Update(activityType);

            _dbContext.SaveChanges();

            return updatedActivityType;
        }

        public void Remove(ActivityType activityType)
        {
            _dbContext.ActivityTypes.Remove(activityType);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ActivityType> GetAll()
        {
            if (_dbContext.ActivityTypes.ToList() == null)
                return null;

            return _dbContext.ActivityTypes
                .Include(at => at.RecordType)
                .ToList();
        }

    }
}

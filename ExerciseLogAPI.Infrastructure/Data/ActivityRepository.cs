using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExerciseLogAPI.Core.Services;
using ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        //Injection
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //return activity + activityType + user

        //Create
        public Activity Add(Activity newActivity)
        {
            Activity activity = _dbContext.Activities.FirstOrDefault(a => a.Id == newActivity.Id);

            if (activity != null)
                return null;

            _dbContext.Add(newActivity);
            _dbContext.SaveChanges();

            return newActivity;
        }

        //Get
        public Activity Get(int id)
        {
            Activity activity = _dbContext.Activities.FirstOrDefault(a => a.Id == id);

            if (activity == null)
                return null;

            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .FirstOrDefault(a => a.Id == id);
        }

        //Update
        public Activity Update(Activity updatedActivity)
        {
            Activity activity = _dbContext.Activities.FirstOrDefault(a => a.Id == updatedActivity.Id);

            if (activity == null)
                return null;

            _dbContext.Entry(activity)
                .CurrentValues
                .SetValues(updatedActivity);
            _dbContext.Activities.Update(activity);
            _dbContext.SaveChanges();

            return updatedActivity;
        }

        //Delete
        public void Remove(Activity activity)
        {
            _dbContext.Activities.Remove(activity);
            _dbContext.SaveChanges();
        }

        //List of All Activities 
        public IEnumerable<Activity> GetAll()
        {
            if (_dbContext.Activities.ToList() == null)
                return null;

            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .ToList();
        }
    }
}

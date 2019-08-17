using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseLogAPI.ApiModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActivityModel> Activities { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseLogAPI.ApiModels
{
    public class ActivityModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ActivityTypeId { get; set; }
        public string ActivityType { get; set; }

        [Required]
        public double Duration { get; set; }
        public double Distance { get; set; }

        [Required]
        public int UserId { get; set; }
        public string User { get; set; }

        public string Notes { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseLogAPI.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}

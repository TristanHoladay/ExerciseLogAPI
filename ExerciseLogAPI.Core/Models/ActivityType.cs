using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseLogAPI.Core.Models
{
    public enum RecordType
    {
        DurationOnly,
        DurationAndDistance
    }

    public class ActivityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordType RecordType { get; set; }
    }
}

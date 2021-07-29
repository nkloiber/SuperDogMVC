using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDogMVC.Models
{
    public class SDEvent
    {
        public int Id { get; set; }

        [DisplayName("Created")]

        public DateTime Created { get; set; }

        [DisplayName("Updated")]

        public DateTime? Updated { get; set; }

        [DisplayName("Name of Event")]
        public string EventName { get; set; }

        [DisplayName("Location City")]

        public string EventCity { get; set; }

        [DisplayName("Location State")]

        public string EventState { get; set; }

        [DisplayName("Event Attendance")]

        public int EventAttendance { get; set; }

        [DisplayName("Date of Event")]

        public DateTime EventDate { get; set; }

    }
}

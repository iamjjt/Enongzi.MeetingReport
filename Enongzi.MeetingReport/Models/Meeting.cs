using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Enongzi.MeetingReport.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }
        public string Summary { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        public bool Current { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}

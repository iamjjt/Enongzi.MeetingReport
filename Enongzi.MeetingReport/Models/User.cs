﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enongzi.MeetingReport.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Referee { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Models
{
    public class UpdateUserRequest
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Age { get; set; }
        public bool IsPrisoner { get; set; }

    }
}

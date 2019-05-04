using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Interest(string name)
        {
            Name = name;
        }

        public Interest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
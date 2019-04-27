using System;

namespace ClinkedInSql.Models
{
    public class Users
    {

        public Users(string name, DateTime releaseDate, bool isPrisoner, int age)

        {
            Name = name;
            ReleaseDate = releaseDate;
            IsPrisoner = isPrisoner;
            Age = age;
        }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsPrisoner { get; set; }
        public int Age { get; set; }
        
    }
}


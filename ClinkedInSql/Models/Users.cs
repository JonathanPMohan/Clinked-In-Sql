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

        public Users(int id, string name, DateTime releaseDate, int age, bool isPrisoner)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Age = age;
            IsPrisoner = isPrisoner;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsPrisoner { get; set; }
        public int Age { get; set; }
        
    }
}


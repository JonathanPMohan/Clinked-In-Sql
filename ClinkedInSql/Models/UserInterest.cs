using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Models
{
    public class UserInterest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InterestId { get; set; }

        // Create User Interest Request //
        public UserInterest(int userId, int interestId)
        {
            UserId = userId;
            InterestId = interestId;
        }

        // Update User Interest Request //
        public UserInterest(int id, int userId, int interestId)
        {
            Id = id;
            UserId = userId;
            InterestId = interestId;
        }
    }
}

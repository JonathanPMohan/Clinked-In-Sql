using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Models
{
    public class CreateUserInterestRequest
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }
    }
}

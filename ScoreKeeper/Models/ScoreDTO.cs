using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreKeeper.Models
{
    public class ScoreDTO
    {
        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime ScoreDate { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
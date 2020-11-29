
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartuves.DL
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Words> Words { get; set; }
        public virtual List<ScoreBoard> ScoreBoards { get; set; }

        //public int SubjectId { get; set; }


    }
}

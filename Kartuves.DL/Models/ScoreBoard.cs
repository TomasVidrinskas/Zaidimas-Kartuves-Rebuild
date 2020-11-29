using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartuves.DL
{
    [Table("ScoreBoards")]
    public class ScoreBoard
    {
        [Key]

        public int ScoreBoardId { get; set; }
        public int PlayerId { get; set; }
        public DateTime DatePlayed { get; set; }
        public int WordId { get; set; }
        public int GuessCount { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Words Words { get; set; }
        public virtual Player Player { get; set; }
    }
}

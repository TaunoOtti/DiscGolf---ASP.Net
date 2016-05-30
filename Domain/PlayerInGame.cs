using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class PlayerInGame
    {
        [Display(Name = nameof(Resources.Domain.PLayerInGameId), ResourceType = typeof(Resources.Domain))]
        public int PlayerInGameId { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserInt User { get; set; }
        public virtual List<Score> Scores { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Score
    {
        public int ScoreId { get; set; }

        public int PlayerInGameId { get; set; }
        [ForeignKey("PlayerInGameId")]
        public virtual PlayerInGame PlayerInGame { get; set; }
        
        public int BasketId { get; set; }
        [ForeignKey("BasketId")]
        public virtual Basket Basket { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.Throws), ResourceType = typeof(Resources.Domain))]
        public int Throws { get; set; }

        [Display(Name = nameof(Resources.Domain.ThrowStyle), ResourceType = typeof(Resources.Domain))]
        public string ThrowStyle { get; set; }

        [Display(Name = nameof(Resources.Domain.Comment), ResourceType = typeof(Resources.Domain))]
        public string Comment { get; set; }

      




    }
}

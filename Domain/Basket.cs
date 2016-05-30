using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Basket
    {
        [Display(Name = nameof(Resources.Domain.Basket), ResourceType = typeof(Resources.Domain))]
        public int BasketId { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.BasketNr), ResourceType = typeof(Resources.Domain))]
        public int BasketNr { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.Distance), ResourceType = typeof(Resources.Domain))]
        public int Distance { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.Pars), ResourceType = typeof(Resources.Domain))]
        public int Pars { get; set; }

        [Display(Name = nameof(Resources.Domain.Comment), ResourceType = typeof(Resources.Domain))]
        public string Comment { get; set; } 
        public virtual List<Score> Scores { get; set; }

        [Display(Name = nameof(Resources.Domain.TrackId), ResourceType = typeof(Resources.Domain))]

        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class Game
    {
        public int GameId { get; set; }
       // [Required]
        [MaxLength(64, ErrorMessageResourceName = "GameNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "GameNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.GameName), ResourceType = typeof(Resources.Domain))]
        public string GameName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(Resources.Domain.Date), ResourceType = typeof(Resources.Domain))]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Resources.Domain.TrackId), ResourceType = typeof(Resources.Domain))]
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; }
        public virtual List<Game> Games { get; set; }
        public virtual List<Score> Scores { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(64, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Firstname), ResourceType = typeof(Resources.Domain))]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(64, ErrorMessageResourceName = "LastnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "LastnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Lastname), ResourceType = typeof(Resources.Domain))]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = nameof(Resources.Domain.Born), ResourceType = typeof(Resources.Domain))]
        public DateTime Born { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.Gender), ResourceType = typeof(Resources.Domain))]
        public Char Gender { get; set; }

        //[ForeignKey(nameof(User))]
        //public int UserId { get; set; }
        //public virtual UserInt User { get; set; }

        //public virtual List<PlayerInGame> PlayerInGames { get; set; } = new List<PlayerInGame>();

        // not mapped properties, just getters
      //  public string FirstLastname => (Firstname + " " + Lastname).Trim();
      //  public string LastFirstname => (Lastname + " " + Firstname).Trim();


    }
}

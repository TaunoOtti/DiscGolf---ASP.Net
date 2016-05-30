using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Track
    {

        public int TrackId { get; set; }

        [Required]
        [MaxLength(64, ErrorMessageResourceName = "TrackNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "TrackNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.TrackName), ResourceType = typeof(Resources.Domain))]
        public string TrackName { get; set; }

        [Required]
        [MaxLength(64, ErrorMessageResourceName = "TrackLocationLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "TrackLocationLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.TrackLocation), ResourceType = typeof(Resources.Domain))]
        public string TrackLocation { get; set; }
        public virtual List<Basket> Baskets { get; set; }
        public virtual List<Game> Games { get; set; }   
    }
}

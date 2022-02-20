using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helmes.Shared.Model
{

    public class User
    {
        public Guid ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool AgreedToTerms { get; set; }

        [Required]
        public List<Sectors> Sectors { get; set; } = new List<Sectors>();

        public bool IsValid()
        {
            if (Sectors.Count > 5) return false;
            if (Sectors.Count == 0) return false;
            if (!AgreedToTerms) return false;
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name)) return false;
            return true;
        }

    }
}

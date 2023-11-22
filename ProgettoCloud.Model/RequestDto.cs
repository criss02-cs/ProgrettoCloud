using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCloud.Model
{
    public record RequestDto
    {
        [Required(ErrorMessage = "Il codice dello stato membro è obbligatorio")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Lo stato membro deve avere 2 caratteri")]
        public string? CountryCode { get; set; }
        [Required(ErrorMessage = "La partiva iva è obbligatoria")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "La partita iva deve essere lunga 11 caratteri")]
        public string? VatNumber { get; set; }
    }
}

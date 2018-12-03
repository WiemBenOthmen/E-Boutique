using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBoutique.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        [Required (AllowEmptyStrings=false, ErrorMessage ="S'il vous plait entrez votre nom")]
        public String nom { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre prenom")]
        public String prenom{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre e-mail")]
        public String email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre numéro")]
        public String tel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre ville")]
        public String ville{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre adresse")]
        public String adresse { get; set; }

       [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre code postal")]
        public String codePostal { get; set; }

       [Required(AllowEmptyStrings = false, ErrorMessage = "S'il vous plait entrez votre date de naissance")]
        public String datenaissance{ get; set; }
    }
}
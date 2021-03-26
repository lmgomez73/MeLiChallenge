using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeLiChallenge.Model
{
    public class MessageItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int IdMessageItem { get; set; }

        public Satellite Satellite { get; set; }
        public string[] Phrases { get; set; }
        public double Distance { get; set; }

    }
}
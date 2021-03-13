using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeLiChallenge.Model
{
    public class Satellite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int IdSatelite { get; set; }
        public string Name { get; set; }
        public double PositionY { get; set; }
        public double PositionX { get; set; }
    }
}

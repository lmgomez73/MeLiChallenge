using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeLiChallenge.Model
{
    public class Satellite
    {
        [Key]
        public int IdSatelite { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeLiChallenge.Model
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int IdMessage { get; set; }
        public List<MessageItem> MessageItems { get; set; }
        public string MessageResult { get; set; }
        public DateTime ReceivedTime { get; set; }

    }
}

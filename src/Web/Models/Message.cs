using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Message
    {
        public int ID { get; set; }
        [Display(Name = "Message")]
        public string MsgText { get; set; }
        [Display(Name = "Timestamp")]
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
    }
}

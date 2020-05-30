using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.DTos
{
   public class SendEmailToParent
    {
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegisterSystem.ViewModel
{
   public class GetGradeDto
    {

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int GetterUserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.DTos
{
    public class AttachDetachStudentToGroup
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int GroupId { get; set; }

    }
}

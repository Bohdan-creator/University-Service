using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.DTos
{
    public class AddGradeToStudentDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public GradeScale GradeValue { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}

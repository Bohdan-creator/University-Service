using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Grade
    {
        public DateTime DateOfIssue { get; set; } = DateTime.Now.AddMilliseconds(100);
        public GradeScale GradeValue { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}

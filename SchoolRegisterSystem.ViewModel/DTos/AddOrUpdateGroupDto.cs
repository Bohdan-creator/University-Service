using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.DTos
{
    public class AddOrUpdateGroupDto
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
    }
}

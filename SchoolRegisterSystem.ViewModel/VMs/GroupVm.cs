﻿using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.VMs
{
    public class GroupVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Student> Students { get; set; }

        // public IList<SubjectG> SubjectGroups { get; set; }
    }
}

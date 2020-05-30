﻿using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.VMs
{
    public class GradeReportVm
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string ParentName { get; set; }
        public string GroupName { get; set; }

       
        public IDictionary<string, List<GradeScale>> StudentGradesPerSubject { get; set; }
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGradePerSubject { get; set; }
    }
}

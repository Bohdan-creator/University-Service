
using SchoolRegisterSystem.ViewModel;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegisterSystem.Services.Interfaces
{
    public interface IGradeService
    {
        GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto);
        void GetGrade(GetGradeDto getGradeDto);
        GradeReportVm GetGradesReportForStudent(GetGradeDto getGradesDto);
    }
}

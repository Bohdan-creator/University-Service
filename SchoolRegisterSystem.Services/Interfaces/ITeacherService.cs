using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.Services.Interfaces
{
   public interface ITeacherService
    {
      bool SendEmailToParent(SendEmailToParent sendEmailToParentDto);

        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null);
      //  TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate);
        IEnumerable<GroupVm> GetTeacherGroups(GetTeacherGroupsDto getTeachersGroups);

    }
}

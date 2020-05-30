using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null, IQueryable<Student> students=null);
        StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate);

    }
}

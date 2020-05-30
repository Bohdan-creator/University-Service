using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
        SubjectVm AddOrUpdate(AddOrUpdateSubjectDto addOrUpdateDto);
        SubjectVm GetSubject(Expression<Func<Subject, bool>> filterPredicate);
        IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterPredicate = null, IQueryable<Subject>subjects=null);
    }
}

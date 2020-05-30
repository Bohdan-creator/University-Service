using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.ViewModel.DTos
{
    public class GetTeacherGroupsDto
    {
        public int Id { get; set; }

        Expression<Func<Student, bool>> filterPredicate { get; set; }
    }
}

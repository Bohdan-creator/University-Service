
using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdate(AddOrUpdateGroupDto addOrUpdateGroupDto);
        GroupVm GetGroup(Expression<Func<Group, bool>> filterpredicate);
        IEnumerable<GroupVm> GetGroups(IEnumerable<Group> filterPredicate = null);

        StudentVm AttachStudentToGroup(AttachDetachStudentToGroup attachDetachStudentToGroup);
        StudentVm DetachStudentToGroup(AttachDetachStudentToGroup attachDetachStudentToGroup);
    }
}

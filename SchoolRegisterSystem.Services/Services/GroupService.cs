using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Identity;
using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.DAL.EF;
using SchoolRegisterSystem.Services.Interfaces;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.Services.Services
{
   public class GroupService:BaseService,IGroupService
    {
        private UserManager<User> _usermanager;
        public GroupService(ApplicationDbContext dbContext, UserManager<User> userManager):base(dbContext)
        {
            _usermanager = userManager;
        }

        public GroupVm AddOrUpdate(AddOrUpdateGroupDto addOrUpdateGroupDto)
        {
            if (addOrUpdateGroupDto == null)
            {
                throw new Exception("Group null");
            }
            var group = Mapper.Map<Group>(addOrUpdateGroupDto);
            if (addOrUpdateGroupDto.Id == 0)
            {
                _dbContext.Groups.Add(group);
                _dbContext.SaveChanges();
            }
            if (addOrUpdateGroupDto.Name != null)
            {
                _dbContext.Groups.Update(group);
            }
            _dbContext.SaveChanges();

            var groupVm = Mapper.Map<GroupVm>(group);
            return groupVm; 
        }

        public GroupVm GetGroup(Expression<Func<Group,bool>> filterpredicate)
        {
            if (filterpredicate == null)
            {
                throw new ArgumentNullException("Filter Predicate is null");
            }
            var group = _dbContext.Groups
                .FirstOrDefault(filterpredicate);
            var groupVm = Mapper.Map<GroupVm>(group);
            return groupVm;
        }
        public IEnumerable<GroupVm> GetGroups(IEnumerable<Group> filterPredicate = null)
        {
            var groups = _dbContext.Groups.ToList();
            var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groups.ToList()); 
            if (filterPredicate != null)
            {
                 groupVms = Mapper.Map<IEnumerable<GroupVm>>(filterPredicate.ToList());
            }
          
            return groupVms;
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroup attachDetachStudentToGroup)
        {
            if (attachDetachStudentToGroup == null)
            {
                throw new Exception("attach is null");
            }

            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(x => x.Id == attachDetachStudentToGroup.StudentId);

            if (student == null)
            {
                throw new Exception("student is null");
            }
            var group = _dbContext.Groups.FirstOrDefault(x => x.Id == attachDetachStudentToGroup.GroupId);

            if (group == null)
            {
                throw new Exception("group is null");
            }

            student.GroupId = group.Id;
            _dbContext.SaveChanges();
            var studentVm = Mapper.Map<StudentVm>(student);
            return studentVm;

        }

        public StudentVm DetachStudentToGroup(AttachDetachStudentToGroup attachDetachStudentToGroup)
        {
            if (attachDetachStudentToGroup == null)
            {
                throw new Exception("attach is null");
            }

            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(x => x.Id == attachDetachStudentToGroup.StudentId);

            if (student == null)
            {
                throw new Exception("student is null");
            }
            var group = _dbContext.Groups.FirstOrDefault(x => x.Id == attachDetachStudentToGroup.GroupId);

            if (group == null)
            {
                throw new Exception("group is null");
            }

            student.GroupId = null;
            group.Students.Remove(student);
            _dbContext.SaveChanges();
            var studentVm = Mapper.Map<StudentVm>(student);
            return studentVm;

        }



    }
}

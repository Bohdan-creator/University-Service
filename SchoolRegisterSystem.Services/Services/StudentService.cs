using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.DAL.EF;
using SchoolRegisterSystem.Services.Interfaces;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegisterSystem.Services.Services
{
    public class StudentService:BaseService,IStudentService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITeacherService _teacherService;


        public StudentService(ApplicationDbContext dbContext, UserManager<User> userManager, ITeacherService teacherService) : base(dbContext)
        {
            _userManager = userManager;
            _teacherService = teacherService;

        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null,IQueryable<Student> students = null)
        {
            var studentsEntities = students;
            if (students == null)
            {
                studentsEntities = _dbContext.Users.OfType<Student>();
            }
            
            if (filterPredicate != null) 
                studentsEntities = studentsEntities.Where(filterPredicate);
            var studentsVm = Mapper.Map<IEnumerable<StudentVm>>(studentsEntities);
            return studentsVm;
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
        {
            if (filterPredicate == null) throw new ArgumentNullException($"filterPredicate is null");
            var studentEntity = _dbContext.Users.OfType<Student>().FirstOrDefault(filterPredicate);
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }

       
    }
}

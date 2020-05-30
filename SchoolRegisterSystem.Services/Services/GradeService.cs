using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.DAL.EF;
using SchoolRegisterSystem.Services.Interfaces;
using SchoolRegisterSystem.ViewModel;
using SchoolRegisterSystem.ViewModel.DTos;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolRegisterSystem.Services.Services
{
    public class GradeService :BaseService,IGradeService
    {
        private readonly UserManager<User> _userManager;
        public GradeService(ApplicationDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto)
        {
            if (addGradeToStudentDto == null)
            {
                throw new Exception("Dto grade is null");
            }

            var teacher = _dbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentDto.TeacherId);
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(t => t.Id == addGradeToStudentDto.StudentId);
            var subject = _dbContext.Subjects.FirstOrDefault(t => t.Id == addGradeToStudentDto.SubjectId);

            if (student == null)
            {
                throw new Exception("Student is null");
            }
            if (teacher == null)
            {
                throw new Exception("Teacher is null");
            }
            if (!_userManager.IsInRoleAsync(teacher, "Teacher").Result)
            {
                throw new InvalidOperationException("You don't have role like Teacher");
            }
            var gradeEntity = Mapper.Map<Grade>(addGradeToStudentDto);
            _dbContext.Grade.Add(gradeEntity);
            _dbContext.SaveChanges();
            var gradeVm = Mapper.Map<GradeVm>(gradeEntity);
            return gradeVm;
        }
        public GradeReportVm GetGradesReportForStudent(GetGradeDto getGradesDto)
        {

            var getterUser = _dbContext.Users.FirstOrDefault(x => x.Id == getGradesDto.GetterUserId);
            if (getterUser == null)
            {
                throw new ArgumentNullException("getter user is null");
            }
            if (!_userManager.IsInRoleAsync(getterUser, "Teacher").Result &&
                !_userManager.IsInRoleAsync(getterUser, "Student").Result &&
                !_userManager.IsInRoleAsync(getterUser, "Parent").Result&&
                    !_userManager.IsInRoleAsync(getterUser, "Admin").Result)
            {
                throw new InvalidOperationException("The getter user don't have permissions to read.");
            }
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(x => x.Id == getGradesDto.StudentId);
            if (student == null)
            {
                throw new ArgumentNullException("getter user is null");

            }
            var gradesRaport = Mapper.Map<GradeReportVm>(student);
            return gradesRaport;

        }
            public void GetGrade(GetGradeDto getGradeDto)
        {
            if (getGradeDto == null)
            {
                throw new Exception("Grade is null");
            }
        //    var getUser = _dbContext.Users.FirstOrDefault(x => x.Id == getGradeDto.GetterUserId);
          //  if (getUser == null)
          //      throw new Exception("User is null");
          //  if (!_userManager.IsInRoleAsync(getUser, "Teacher").Result
          //      && !_userManager.IsInRoleAsync(getUser, "Teacher").Result
          //      && !_userManager.IsInRoleAsync(getUser, "Teacher").Result)
          //  {
          //      throw new InvalidOperationException("You don't have permission");
          //  }
          // // var student = _dbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradeDto.StudentId);
          ////  if (student == null)
          //      throw new InvalidOperationException("is not a student");
          ///  var gradesReport = Mapper.Map<GradeReportVm>(student);
            return ;
        }
    }
}

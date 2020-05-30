using AutoMapper;
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
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SchoolRegisterSystem.Services.Services
{
  public  class TeacherService: BaseService, ITeacherService
    {
        private readonly SmtpClient _smtpClient;
        private readonly UserManager<User> _userManager;
        private readonly IGroupService _groupService;
        private readonly ApplicationDbContext _applicationDbContext;
        public TeacherService(SmtpClient smtpClient, ApplicationDbContext dbContext, UserManager<User> userManager, IGroupService groupService) : base(dbContext)
        {
            _smtpClient = smtpClient;
            _userManager = userManager;
            _groupService = groupService;
            _applicationDbContext = dbContext;
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null)
        {
            var teacherEntities = _dbContext.Users.OfType<Teacher>().
            AsQueryable();

            if (filterPredicate != null)
            {
                teacherEntities = teacherEntities.Where(filterPredicate);
            }
            var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
            return teacherVms;
        }

        public bool SendEmailToParent(SendEmailToParent sendEmailToParentDto)
        {

                if (sendEmailToParentDto == null)
                {
                    throw new ArgumentNullException($"Dto is null");
                }
                var teacher = _dbContext.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == sendEmailToParentDto.SenderId);
                if (teacher == null || _userManager.IsInRoleAsync(teacher, "Teacher").Result == false)
                {
                    throw new ArgumentNullException($"teacher  is null");
                }
                var student = _dbContext.Users.OfType<Student>().FirstOrDefault(x => x.Id == sendEmailToParentDto.StudentId);

                if (student == null || !_userManager.IsInRoleAsync(student, "Student").Result)
                {
                    throw new ArgumentNullException($"student does not have permission");

                }

            SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587);
            smpt.EnableSsl = true;
            smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
            smpt.UseDefaultCredentials = false;
            smpt.Credentials = new NetworkCredential(teacher.Email, "basket2009");
            MailMessage message = new MailMessage();
            message.To.Add(student.Parent.Email);
            message.From = new MailAddress(teacher.Email);
            message.Subject = sendEmailToParentDto.Title;
            message.Body = sendEmailToParentDto.Content;
            smpt.Send(message);

            return true;

        }

        public IEnumerable<GroupVm> GetTeacherGroups(GetTeacherGroupsDto getTeachersGroups)
        {
            var teacher = _dbContext.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == getTeachersGroups.Id);

            var teacherGroups = _groupService.GetGroups();
            if (getTeachersGroups != null && teacher!=null)
            {

                var teacherg = teacher.Subjects.SelectMany(s => s.SubjectGroups.Select(gr => gr.Group));



                 teacherGroups = _groupService.GetGroups(teacher.Subjects.SelectMany(s => s.SubjectGroups.Select(gr => gr.Group)).Distinct());

            }
            return teacherGroups;
        }

        
    }
}

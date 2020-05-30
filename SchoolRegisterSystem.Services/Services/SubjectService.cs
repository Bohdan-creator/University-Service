using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
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
    public class SubjectService : BaseService, ISubjectService
    {

        public SubjectService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public SubjectVm AddOrUpdate(AddOrUpdateSubjectDto addOrUpdateSubjectDto)
        {
            if (addOrUpdateSubjectDto == null)
            {
                throw new ArgumentNullException("Dto of type is null");
            }
            var subjectEntity = Mapper.Map<Subject>(addOrUpdateSubjectDto);
            if (addOrUpdateSubjectDto.Id == null || addOrUpdateSubjectDto.Id == 0)
            {
                _dbContext.Subjects.Add(subjectEntity);
            }
            else
            {
                _dbContext.Subjects.Update(subjectEntity);
            }
            _dbContext.SaveChanges();
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;

            throw new NotImplementedException();
        }

        public SubjectVm GetSubject(Expression<Func<Subject, bool>> filterPredicate)
        {
            if (filterPredicate == null)
                throw new ArgumentNullException($"Predicate is null");
            Subject subjectEntity = _dbContext.Subjects
                .Include(s => s.Teacher)
                .Include(s => s.SubjectGroups)
                  .ThenInclude(sg => sg.Group)
                .FirstOrDefault(filterPredicate);
            SubjectVm subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterPredicate = null ,IQueryable<Subject> subjects=null)
        {
           


            var subjectEntities = _dbContext.Subjects
 .Include(s => s.Teacher)
 .Include(s => s.SubjectGroups)
 .ThenInclude(sg => sg.Group)
 .AsQueryable();
            if (subjects == null)
            {
                if (filterPredicate != null)
                {
                    subjectEntities = subjectEntities.Where(filterPredicate);
                }
            }
            else
            {
                subjectEntities = subjects;
                subjectEntities = subjectEntities.Where(filterPredicate);

            }
            IEnumerable<SubjectVm> subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntities);
            return subjectVms;

        }

        
    }
}

using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDBContext _dataContext;

        public CourseRepository(UniversityDBContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dataContext.Courses;
        }
    }
}

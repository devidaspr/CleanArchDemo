using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        //IEnumerable<Course> GetCourses();
        IQueryable<Course> GetCourses();
        void Add(Course course);
    }
}

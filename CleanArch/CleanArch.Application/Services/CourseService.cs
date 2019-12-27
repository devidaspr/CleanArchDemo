using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRespository;

        public CourseService(ICourseRepository courseRespository)
        {
            this._courseRespository = courseRespository;
        }
        public CourseViewModel GetCourses()
        {
            return new CourseViewModel ()
            {
                Courses = _courseRespository.GetCourses()
            };
        }
    }
}

using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRespository;
        private readonly IMediatorHandler _bus;

        public CourseService(ICourseRepository courseRespository, IMediatorHandler bus)
        {
            this._courseRespository = courseRespository;
            this._bus = bus;
        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = new CreateCourseCommand(
                course.Name,
                course.Description,
                course.ImageUrl
                );

            _bus.SendCommand(createCourseCommand);
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

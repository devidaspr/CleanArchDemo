using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRespository, IMediatorHandler bus, IMapper autoMapper)
        {
            this._courseRespository = courseRespository;
            this._bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            //Without using automapper
            //var createCourseCommand = new CreateCourseCommand(
            //    courseViewModel.Name,
            //    courseViewModel.Description,
            //    courseViewModel.ImageUrl
            //    );

            //_bus.SendCommand(createCourseCommand);

            //Using automapper
            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        //public CourseViewModel GetCourses()
        public IEnumerable<CourseViewModel> GetCourses()
        {
            //return new CourseViewModel ()
            //{
            //    Courses = _courseRespository.GetCourses()
            //};

            return _courseRespository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}

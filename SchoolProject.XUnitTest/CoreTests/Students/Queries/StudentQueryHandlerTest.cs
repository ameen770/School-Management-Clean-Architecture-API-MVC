using AutoMapper;
//using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Application.Features.Students.Queries.Handlers;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Application.Mapping.Students;
//using SchoolProject.Application.Resources;
using SchoolProject.Data.Entities;
//using SchoolProject.Data.Enums;
using SchoolProject.Service.Abstracts;
using SchoolProject.XUnitTest.TestModels;
using System.Net;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 6)]
namespace SchoolProject.XUnitTest.CoreTests.Students.Queries
{
    public class StudentQueryHandlerTest
    {

        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly IMapper _mapperMock;
        //private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;
        private readonly StudentProfile _studentProfile;


        public StudentQueryHandlerTest()
        {
            _studentProfile = new();
            _studentServiceMock = new();
           // _localizerMock = new();
            var configuration = new MapperConfiguration(c => c.AddProfile(_studentProfile));
            _mapperMock=new Mapper(configuration);
        }
        [Fact]
        public async Task Handle_StudentList_Should_NotNull_And_NotEmpty()
        {
            //Arrange
            var studentList = new List<Student>()
            {
                new Student(){ StudID=1, Name="Ameen", Address="Sanaa", Phone="772302176", DID=1}
            };

            var query = new GetStudentListQuery();
            _studentServiceMock.Setup(x => x.GetStudentsListAsync()).Returns(Task.FromResult(studentList));

            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapperMock);

            //Act
            var result = await handler.Handle(query, default);
            //Assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeOfType<List<GetStudentListResponse>>();
        }
        /*[Theory]
        [InlineData(3)]
        //[InlineData(2)]
        public async Task Handle_StudentById_where_Student_NotFound_Return_StatusCode404(int id)
        {
            //Arrange
            var department = new Department() { DID=1, DName="هندسة البرمجيات" };
            var studentList = new List<Student>()
            {
                new Student(){ StudID=1, Name="Ameen", Address="Sanaa", Phone="772302176", DID=1, Department=department},
                new Student(){ StudID=2, Name="Laith", Address="Sanaa", Phone="775903015", DID=1, Department=department}
            };

            var query = new GetStudentByIdQuery(id);
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.FirstOrDefault(x => x.StudID==id)));

            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapperMock);

            //Act
            var result = await handler.Handle(query, default);
            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[ClassData(typeof(PassDataUsingClassData))]
        [MemberData(nameof(PassDataToParamUsingMemberData.GetParamData), MemberType = typeof(PassDataToParamUsingMemberData))]
        public async Task Handle_StudentById_where_Student_Found_Return_StatusCode200(int id)
        {
            //Arrange
            var department = new Department() { DID = 1, DName = "هندسة البرمجيات" };
            var studentList = new List<Student>()
            {
                new Student(){ StudID=1, Name="Ameen", Address="Sanaa", Phone="772302176", DID=1, Department=department},
                new Student(){ StudID=2, Name="Laith", Address="Sanaa", Phone="775903015", DID=1, Department=department}
            };
            var query = new GetStudentByIdQuery(id);
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.FirstOrDefault(x => x.StudID==id)));

            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapperMock);

            //Act
            var result = await handler.Handle(query, default);
            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.StudID.Should().Be(id);
            result.Data.Name.Should().Be(studentList.FirstOrDefault(x => x.StudID==id).Name);
        }*/
    }
}

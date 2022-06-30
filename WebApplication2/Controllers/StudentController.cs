using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Classes;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController : ControllerBase
{
    
    private IStudentHelper _studentHelper;

    public StudentController(IStudentHelper istudenthelper)
    {
        _studentHelper = istudenthelper;
    }
    
    public List<Student> Students = new List<Student>()
    {
        new Student() {Name = "Tarek", Id = 1},
        new Student() {Name = "Jad", Id = 2},
        new Student() {Name = "Zeina", Id = 3}
    };
    
    [HttpGet("GetStudent")]
    public async Task<List<Student>> Get()
    {
        return Students;
    }

    [HttpGet("/{id}")]
    public Student GetStudentById([FromRoute] int id)
    {
        return _studentHelper.GetStudentById(Students, id);
    }

    [HttpPost("AddStudent")]
    public Student AddStudent([FromBody] AddStudentClass request)
    {
        Student student1 = new Student()
        {
            Name = request.name,
            Id = request.id
        };
        Students.Add(student1);
        return student1;
    }

}

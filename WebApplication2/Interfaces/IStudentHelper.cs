using WebApplication2.Classes;
using WebApplication2.Controllers;

namespace WebApplication2.Interfaces;

public interface IStudentInterface
{
    public StudentController ReturnAllStudents(List<Student> students);
}
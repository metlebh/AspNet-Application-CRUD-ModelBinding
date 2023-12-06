using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){
                
                Name="Metleb",
                Surname="Huseynov",
                Age=20,
                Speciality="Student of AACU"

            },
            new Student(){
                
                Name="Elman",
                Surname="Huseynov",
                Age=20,
                Speciality="Student of ASOIU"

            },
          
        };
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            var entity = new Student(true)
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Speciality = student.Speciality,
            };
            students.Add(entity);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            Student entity = students.FirstOrDefault(m => m.Id == id);


            if (entity == null)
                return NotFound();

            return View(entity);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            Student entity = students.FirstOrDefault(m => m.Id == student.Id);


            if (entity == null)
                return NotFound();


            entity.Name = student.Name;
            entity.Surname = student.Surname;
            entity.Age = student.Age;
            entity.Speciality = student.Speciality;

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Student entity = students.FirstOrDefault(m => m.Id == id);


            if (entity == null)
                return NotFound();

            students.Remove(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detials(int id)
        {
            Student entity = students.FirstOrDefault(m => m.Id == id);


            if (entity == null)
                return NotFound();

            return View(entity);
        }
    }
}
    
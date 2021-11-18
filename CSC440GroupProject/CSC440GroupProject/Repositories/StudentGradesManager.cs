using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC440GroupProject.Models;

namespace CSC440GroupProject.Repositories
{
    public class StudentGradesManager
    {
        private IGradeRepository gradeRepository;
        private IStudentRepository studentRepository;

        public StudentGradesManager(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            this.gradeRepository = gradeRepository;
            this.studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            studentRepository.Create(student);
        }

        public List<Student> GetStudents()
        {
            return studentRepository.GetList();
        }

        public void CreateGrade(Grade grade)
        {
            gradeRepository.Create(grade);
        }

        public List<Grade> GetStudentGrades(Student student)
        {
            return gradeRepository.GetList(student);
        }

        public void UpdateGrade(Grade grade)
        {
            gradeRepository.Update(grade);
        }

        public void DeleteGrade(Grade grade)
        {
            gradeRepository.Delete(grade);
        }

        public void GenerateTextReport(Student student, List<Grade> gradeRecords)
        {
            // generate text report
        }

        public void GeneratePdfReport(Student student, List<Grade> gradeRecords)
        {
            // generate pdf report
        }
    }
}

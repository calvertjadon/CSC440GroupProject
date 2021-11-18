using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC440GroupProject.Models;


namespace CSC440GroupProject.Repositories
{
    interface IStudentRepository
    {
        void Create(Student student);
        List<Student> GetList();
        bool StudentExists(Student student);
    }
}

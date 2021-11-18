using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC440GroupProject.Models;


namespace CSC440GroupProject.Repositories
{
    interface IGradeRepository
    {
        void Create(Grade grade);
        List<Grade> GetList(Student student);
        void Update(Grade grade);
        void Delete(Grade grade);
    }
}

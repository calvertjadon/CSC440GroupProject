﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC440GroupProject.Models;


namespace CSC440GroupProject.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetList();
    }
}

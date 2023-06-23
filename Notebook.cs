using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationConsole
{
    public class Notebook
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public Notebook()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
        }
    }
}

using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationConsole
{
    public class Course
    {
        public int Id { get; }
        public string Name { get; }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


}

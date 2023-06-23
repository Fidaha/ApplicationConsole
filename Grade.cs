using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationConsole
{
    public class Grade
    {
        public string CourseName { get; }
        public double Score { get; }
        public string Appreciation { get; }

        public Grade(string courseName, double score, string appreciation)
        {
            CourseName = courseName;
            Score = score;
            Appreciation = appreciation;
        }
    }
}

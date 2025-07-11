using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    public class Student {
        public String Name { get; } = String.Empty;
        public string Subject { get; } = String.Empty;
        public int Score { get; }

        public Student(string name, string subject, int score) {
            Name = name;
            Subject = subject;
            Score = score;
        }
    }
}



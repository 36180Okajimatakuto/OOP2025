using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Test01 {
    class Student {
        public String Name { get; init; } = String.Empty;
        public string Subject { get; init; } = String.Empty;
        public int Score { get; init; }

        public Student(string name, string subject, int score) {
            Name = name;
            Subject = subject;
            Score = score;
        }
    }
}

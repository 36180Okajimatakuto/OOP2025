﻿using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;
using System.Xml;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var employees = Deserialize("employees.json");
            ToXmlFile(employees);
        }



        static Employee[] Deserialize(string filePath) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };


            if (!File.Exists(filePath)) {
                Console.WriteLine($"ファイルが存在しません: {filePath}");
                return[] ;//ファイルが存在しないときに、プログラムを停止してくれるやつ
        }


            var text = File.ReadAllText(filePath);
            var employees = JsonSerializer.Deserialize<Employee[]>(text, options);
            return employees ?? [];

        }
        
	
        static void ToXmlFile(Employee[] employees) {
            using (var writer = XmlWriter.Create("employees.xml")) {

                XmlRootAttribute xRoot = new XmlRootAttribute {
                    ElementName = "Employees"
                };

                var serializer = new XmlSerializer(employees.GetType(), xRoot);
                serializer.Serialize(writer, employees);
            }

        }
    }

    public record Employee {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }
    }
}

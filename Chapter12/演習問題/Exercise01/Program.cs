using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;


namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            
            var emp = new Employee {
                Id = 123,
                Name = "山本太郎",
                HireDate = new DateTime(2018, 10, 1),
            };
            var jsonString = Serialize(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize(jsonString);
            Console.WriteLine(obj);


            //問題12.1.2
            Employee[] employees = [
                new () {
                    Id = 123,
                    Name = "山田太郎",
                    HireDate = new DateTime(2018, 10, 1),
                },
                new () {
                    Id = 198,
                    Name = "田中華子",
                    HireDate = new DateTime(2020, 4, 1),
                },
            ];
            Serialize("employees.json", employees);

            //問題12.1.3
            var empdata = Deserialize_f("employees.json");
            foreach (var empd in empdata)
                Console.WriteLine(empd);

        }
      

        static string Serialize(Employee emp) {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            return JsonSerializer.Serialize(emp, options);
 

        }

        static Employee? Deserialize(string text) {

            return JsonSerializer.Deserialize<Employee>(text); 
        }

        //問題12.1.2
        //シリアル化してファイルへ出力する
        static void Serialize(string filePath, IEnumerable<Employee> employees) {
            
                try {
                    // EmployeeのリストをJSON文字列にシリアライズ
                    string jsonString = JsonSerializer.Serialize(employees);
                    // ファイルに書き込む
                    File.WriteAllText(filePath, jsonString);
                }
                catch (Exception ex) {
                    Console.WriteLine($"ファイル書き込み中にエラーが発生しました: {ex.Message}");
                }
            


        }

        //問題12.1.3
        //逆シリアル化する
        static Employee[] Deserialize_f(string filePath) {
             try
        {
            // ファイルからJSON文字列を読み込む
            string jsonString = File.ReadAllText(filePath);
            // JSON文字列をEmployee配列に変換（デシリアライズ）
            Employee[] employees = JsonSerializer.Deserialize<Employee[]>(jsonString);
            return employees ?? Array.Empty<Employee>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ファイル読み込みまたはデシリアライズ中にエラーが発生しました: {ex.Message}");
            return Array.Empty<Employee>();
        }
        }


    }

    public record Employee {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }


}
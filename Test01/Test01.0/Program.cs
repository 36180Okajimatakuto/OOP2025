using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01._0 {
    public class Program {
        static void Main(string[] args) {
            var score = new ScoreCounter("StudentScore.csv");
            var TotalBySubject = score.GetPerStudentScore();
            foreach (var obj in TotalBySubject) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }
    }
}

//実行結果
//英語 520
//数学 550
//国語 500
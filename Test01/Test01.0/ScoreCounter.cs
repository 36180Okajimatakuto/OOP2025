using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01._0 {
    class ScoreCounter {
        private readonly IEnumerable<Student> _scores;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _scores = ReadScore(filePath);
        }

        // メソッドの概要： データを取得。List生成
        private static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines) {
                string[] items = line.Split(',');

                // コンストラクタを使用してStudentオブジェクトを生成
                var score = new Student(//コンストラクタを使うからオブジェクト初期化子は使わない（｛｝のこと）
                    items[0], // Name
                    items[1], // Subject
                    int.Parse(items[2]) // Score
                );
                scores.Add(score);
            }

            return scores;
        }

        // メソッドの概要： 科目別点数
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();

            foreach (var score in _scores) {
                if (dict.ContainsKey(score.Name)) {
                    dict[score.Name] += score.Score;
                } else {
                    dict[score.Name] = score.Score;
                }
            }

            return dict;
        }
    }
}


﻿namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }


        //メソッドの概要： データを取得。List生成
        private static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                string[] items = line.Split(',');
                Student Scores = new Student() {
                    //Name = items[0],
                    //Subject = items[1],
                    //Score = int.Parse(items[2]),
                };
                scores.Add(Scores);

            }
            
            return scores;

        }

        //メソッドの概要： 科目別点数
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
                //        if (dict.ContainsKey(score.Name))
                //            dict[score.Name] += score.Score;

                //        else

                //            dict[score.Name] = score.Score;

            }
            return dict;
        }


        

    }

}
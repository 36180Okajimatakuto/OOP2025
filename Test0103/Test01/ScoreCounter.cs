using static System.Formats.Asn1.AsnWriter;

namespace Test01 {
    public class ScoreCounter {
        private readonly IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {

            _score = ReadScore(filePath);
        }

        //メソッドの概要：
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines) {
                string[] items = line.Split(',');

                // コンストラクタを使用してStudentオブジェクトを生成
                var score = new Student(
                    items[0], // Name
                    items[1], // Subject
                    int.Parse(items[2]) // Score
                );
                sales.Add(score);
            }







            return sales;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
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

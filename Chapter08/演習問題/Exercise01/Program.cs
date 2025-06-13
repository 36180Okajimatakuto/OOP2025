
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);
        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<Char, int>();
            foreach (var c in text) {
                var tup = char.ToUpper(c);
                if (tup >= 'A' && tup <= 'Z') {
                    if (dict.ContainsKey(tup)) {


                        dict[tup]++;//登録済み：valueをインクリメント

                    } else {
                        dict[tup] = 1;//未登録：valueを設定


                    }
                }


            }
            foreach (var kvp in dict) {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            //すべての文字が読み終わったら、アルファベット順に並び変えて出力
            //foreach (var item in dict.OrderBy(x => x.Key)) {
            //    Console.WriteLine("{0}:{1}", item.Key, item.Value);　　　お手本

            //}



        }











        private static void Exercise2(string text) {
            var dict = new SortedDictionary<Char, int>();
            foreach (var c in text) {
                var tup = char.ToUpper(c);
                if (tup >= 'A' && tup <= 'Z') {
                    if (dict.ContainsKey(tup)) {


                        dict[tup]++;

                    } else {
                        dict[tup] = 1;


                    }
                }

            }

            foreach (var item in dict.OrderBy(x => x.Key)) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value); 

            }







        }
    }
}

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };
       

            var query = cities.Where(s => s.Length <= 5).ToArray();    //- query変数に代入
            foreach (var item in query) {                   //↑即時実行
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            cities[0] = "Osaka";            //- cities[0]を変更 
            foreach (var item in query) {   //- 再度、queryの内容を取り出す
                Console.WriteLine(item);
            }

        }
    }
}






//     .Where(s => s.Length <= 5)//条件にあったものを抽出
//.OrderBy(s => s[0]); //.Select(s => s.ToUpper());//別アブジェクトへ変換(新しい型へ射影する)
//                  ↑渡す方法　ラムダ演算子

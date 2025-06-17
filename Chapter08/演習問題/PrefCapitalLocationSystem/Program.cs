using System.Linq;

namespace PrefCapitalLocationSystem {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();
        //↑ここに都道府県と県庁所在地を入力して出力する

        #region//列挙型の定義
        public enum SelectMenu {
            Alldisp = 1,
            Search = 2,
            Exit = 9


        }


        #endregion


        static void Main(string[] args) {
            String? pref, prefCaptalLocation;

            //入力処理
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break;    //無限ループを抜ける(Ctrl + 'Z')

                //県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                //既に都道府県が登録されているか？
                //ヒント：ContainsKeyを使用して調べる
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか？(Y/N)");
                    if (Console.ReadLine() == "N") continue;
                }
                //県庁所在地登録処理
                prefOfficeDict[pref] = prefCaptalLocation ?? "**未入力**";
                Console.WriteLine();//改行

                #region 自作の上書きプログラム
                //    if (prefOfficeDict.ContainsKey(pref)) {
                //        Console.WriteLine($"「{pref}」はすでに登録されています。上書きしますか？ (y/n):");
                //        string? answer = Console.ReadLine();
                //        if (answer != null && (answer.ToLower() == "y" || answer.ToLower() == "yes")) {
                //            prefOfficeDict[pref] = prefCaptalLocation!;
                //            Console.WriteLine($"「{pref}」の県庁所在地を「{prefCaptalLocation}」に更新しました。");//４割CHATGPTの自力作
                //        } else {
                //            Console.WriteLine($"「{pref}」の登録をスキップしました。");
                //        }
                //    } else {
                //        prefOfficeDict.Add(pref, prefCaptalLocation!);
                //        Console.WriteLine($"「{pref}」を登録しました。");
                //    }
                #endregion
            }

            Boolean endFlag = false;    //終了フラグ（無限ループを抜け出す用）
            while (!endFlag) {
                switch (menuDisp()) {
                    case SelectMenu.Alldisp://一覧出力処理
                        allDisp();
                        break;
                    case SelectMenu.Search://検索処理
                        searchPrefCaptalLocation();
                        break;
                    case SelectMenu.Exit://無限ループを抜ける
                        endFlag = true;
                        break;
                }

                //        switch (menuDisp()) {
                //            case "1":                        //一覧出力処理
                //                allDisp();
                //                break;


                //            case "2":   //検索処理
                //                searchPrefCaptalLocation();
                //                break;


                //            case "9"://無限ループを抜ける

                //                break;
            }
        }

        //メニュー表示
        private static SelectMenu menuDisp() {
            Console.WriteLine("\n**** メニュー ****");
            Console.WriteLine("1：一覧表示");
            Console.WriteLine("2：検索");
            Console.WriteLine("9：終了");
            Console.Write(">");
            var menuSelect =  (SelectMenu)int.Parse(Console.ReadLine());
            return menuSelect;                          //  ↑nullになる可能性がある場合に波線が表示される
        }

        //一覧表示処理
        private static void allDisp() {
            foreach (var itiran in prefOfficeDict) {
                Console.WriteLine($"都道府県: {itiran.Key}, 県庁所在地: {itiran.Value}");
            }
        }
            //*　ここに入力　*******************//        

        //検索処理
        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            String? searchPref = Console.ReadLine();
            if (searchPref is null) return;
            Console.WriteLine(searchPref + "の県庁所在地は" + prefOfficeDict[searchPref] + "です");
        }
    }
}

using System.ComponentModel;
using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            #region 時刻のオブジェクト
                                      //↓不変オブジェクト
            var today =new DateTime(2025,7,12);//任意の日付
            var now = DateTime.Now;//日付と時刻



            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Today:{now}");
            #endregion



            #region//①自分の生年月日は何曜日かをプログラムで書いて調べる
            Console.Write("西暦：");
            int year =  int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            int day =   int.Parse(Console.ReadLine());
            var birthday = new DateTime(year, month, day);
            Console.WriteLine($"平成{year}年{month}月{day}日は{birthday:dddd}です");
            #endregion
            #region 日本語化
            //var culture = new CultureInfo("ja-JP");
            //culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            //string japaneseDate = birthday.ToString("ggyy年M月d日", culture);
            #endregion

            //②自分の生年月日はうるう年かをプログラムで書いて調べる
            var uruuYear = new DateTime(2005, 11, 5);

            Console.WriteLine($"うるう年は、{uruuYear}");
        
        }
    }
}

using Microsoft.VisualBasic;
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
            Console.WriteLine($"{year}年{month}月{day}日は{birthday:dddd}です");
            #endregion

            #region//お手本 日本語化
            //var culture = new CultureInfo("ja-JP");
            //culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            //var str = birth.ToString("ggyy年m月d日", culture);
            //var shortDayOfWeek = culture.DayTimeFormat.GetshortestDayName(birth.DayOfWeek);
            #endregion

            #region 日本語化
            //var culture = new CultureInfo("ja-JP");
            //culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            //var str = birthday.ToString("ggyy年M月d日", culture);
            //Console.WriteLine(str);
            #endregion

            #region//②自分の生年月日はうるう年かをプログラムで書いて調べる
            var uruuYear = DateTime.IsLeapYear(year);
            if (uruuYear) {
                Console.WriteLine("閏年です。");
            } else {
                Console.WriteLine("閏年ではありません。");
            }
            #endregion

            #region//③生まれてから〇〇〇〇日目です
            TimeSpan nannititatta = DateTime.Now - birthday ;
            Console.WriteLine($"入力された日から今日までに、{nannititatta.TotalDays}日目です。");
            #endregion

            #region//④あなたは〇〇歳です！
            var tosi = today.Year - birthday.Year;
            if (today < birthday.AddYears(tosi)) {
                tosi--;//chatGPTのIF文
            }
            Console.WriteLine("あなたは" +tosi + "歳です。");
            #endregion

            #region//⑤1月1日から何日目か？
            var todays = DateTime.Today;
            int hinitikeisan = todays.DayOfYear;//おてほん
            Console.WriteLine(hinitikeisan);
            #endregion


        }
    }
}

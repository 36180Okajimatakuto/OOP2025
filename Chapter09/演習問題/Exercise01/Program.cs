using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            #region メイン
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
        }
        #endregion

        #region 1番
        private static void DisplayDatePattern1(DateTime dateTime) {
            //2024/03/09 19:03
            //string.Formatを使った例
            var date = new DateTime(2024, 03, 09, 19, 03, 09);//GPT使用
            var hyouzi2 = string.Format("{0:yyyy/MM/dd HH:mm}", date);
            Console.WriteLine(hyouzi2);
        }
        #endregion

        #region 2番
        private static void DisplayDatePattern2(DateTime dateTime) {
            //2024年03月09日　19時03分09秒
            //DateTime.ToStringを使った例

            var date = new DateTime(2024, 03, 09, 19, 03, 09);
            var hyouzi1 = date.ToString("yyyy年mm月dd日 HH時mm分ss秒");
            Console.WriteLine(hyouzi1);
        }
        #endregion

        #region 3番
        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine("令和");
            int seireki = int.Parse(Console.ReadLine());
            Console.WriteLine("月");
            int tuki = int.Parse(Console.ReadLine());
            Console.WriteLine("日");
            int niti = int.Parse(Console.ReadLine());
            var nyuuryoku = new DateTime(seireki,tuki,niti);
            var dayofweek = culture.DateTimeFormat.GetDayName(nyuuryoku.DayOfWeek);
            var hyouzi1 = nyuuryoku.ToString("令和yy年MM月dd日");
            Console.Write(hyouzi1);
            Console.WriteLine($"({dayofweek})");
        }
        #endregion

    }
}

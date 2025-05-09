using System.Xml;

namespace Exercise02 {
    internal class Program {

        private static void Main(string[] args) {
            Console.WriteLine("***　　変換アプリ   ***");
            Console.WriteLine("1: インチからメートル");
            Console.WriteLine("2: メートルからインチ");
            string input   = Console.ReadLine();


        





            if ( 0> 1) {

                //インチからメートルへ変換

                for (int inch = 1; inch <= 10; inch++) {
                    double meter = InchToMeter(inch);
                    Console.WriteLine($"{inch}inch = {meter:0.0000}m");


                }
            } else {

                //メートルからインチへ変換

                for
                         (double meter = 1; meter <= 10; meter++) {
                    double inch = MeterToInch(meter);
                    Console.WriteLine($"{meter}m = {inch:0.0000}inch");
                }
            }

            static double InchToMeter(int inch) {
                return inch * 0.0254;
            }
            static double MeterToInch(double meter) {
                return meter / 0.0254;
            }




        }
    }
}






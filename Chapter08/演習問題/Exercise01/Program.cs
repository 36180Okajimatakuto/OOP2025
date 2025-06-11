
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


                        dict[tup]++;

                    } else {
                        dict[tup] = 1;

                       
                    }
                    
                        
                }
                
                
            }
            foreach (var kvp in dict) {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }



        }





            

    

        

        private static void Exercise2(string text) {



        }
    }
}

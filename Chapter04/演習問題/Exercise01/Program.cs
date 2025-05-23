
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
             "JavaScript", "Swift", "Go",
];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {

            foreach (var lang in langs) {
                if (lang.Contains('S'))
                    Console.WriteLine(lang);


            }

            Console.WriteLine("");

            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S')) Console.WriteLine(langs[i]);


            }
            Console.WriteLine("");//改行


            int index = 0;
            while (index < langs.Count) {
                if (langs[index].Contains('S'))
                    Console.WriteLine(langs[index]);
                index++;

            }

            Console.WriteLine("");//改行


        }

        private static void Exercise2(List<string> langs) {
            var selected = langs.Where(x => x.Contains('S'));
            foreach (var lang in selected) {
                Console.WriteLine(lang);
            }
        }

        private static void Exercise3(List<string> langs) {
            //二行で完結させる
            var lang = langs.Find(x => x.Length == 10);
            Console.WriteLine(lang ?? "unknown");









            //if (var List = langs.Find(s >= s.Length == 10){ 




            //    Console.WriteLine(langs);

            //} else {


            //    Console.WriteLine("unknown");
        }

    }
}

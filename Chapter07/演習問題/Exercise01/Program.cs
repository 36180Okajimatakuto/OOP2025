﻿
using System;
using System.ComponentModel.DataAnnotations;


namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise2(int[] numbers) {
            //foreach (var n in numbers.Skip(numbers.Length -2) ){
            //    Console.WriteLine(n);                             お手本
            //}
            

           var LastTwo = numbers.TakeLast(2);
            foreach (var n in LastTwo) {
                Console.WriteLine(n);

            }
            
           
            //P169以降
        }


        private static void Exercise3(int[] numbers) {

            //p173
            var sanketanumbers = numbers.Select(n => n.ToString("000"));
            foreach (var s in sanketanumbers) {
                Console.WriteLine(s);
            }
            

            

            
        }
        private static void Exercise4(int[] numbers) {

           
            foreach (var n in numbers.OrderBy(n => n).Take(3)) {
                Console.WriteLine(n);//             お手本
            }
            //Array.Sort(numbers);
            //int syouzyun = numbers.OrderBy(n => n).Take(3);


        }

        private static void Exercise5(int[] numbers) {

            var count = numbers.Distinct().Count(n => n >= 10);
            Console.WriteLine(count);           //お手本



        }
    }
}

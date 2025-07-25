﻿using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            var filePath = "novelist.json";

            if (!File.Exists(filePath)) {
                Console.WriteLine($"ファイルが存在しません: {filePath}");
                return; // 処理を中断
            }

            var jsonString = File.ReadAllText(filePath);
            var novelist = Deserialize(jsonString);
            if (novelist is not null) {
                Console.WriteLine(novelist);
                foreach (var item in novelist.Masterpieces) {
                    Console.WriteLine(item);
                }
            }
        }



        static Novelist? Deserialize(string jsonString) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals |
                    JsonNumberHandling.AllowReadingFromString

            };
            var novelist = JsonSerializer.Deserialize<Novelist>(jsonString, options);
            return novelist;//GPT
        }
    }

    public record Novelist {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        [JsonPropertyName("birth")]
        public DateTime Birthday { get; init; }
        public string[] Masterpieces { get; init; } = [];//空の配列を作成
    }
}

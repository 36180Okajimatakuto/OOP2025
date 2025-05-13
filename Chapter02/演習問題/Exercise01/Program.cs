namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //2.1.3
            var Song = new Song[] {
                new Song("Let it be", "The Beatles",243),
                new Song("Bridge Over Troubled Water","Simon & Garfunkel",293),
                new Song("Close To You","Carpenters",276),
                new Song("Honesty","Billy Joel",231),
                new Song("I Will Always Love You","Whitney Houston",273), 
            };

            


        }



        //2.1.4
        private static void printSongs(Song[] songs) {
#if false
            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title}, {song.ArtistName}{minutes}:{seconds:00}");


            }
#else
            //TimeSpanクラスを使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(55);
            }
            //また、以下でも可
            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1}{2:m\:es}", song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }

#endif 
            Console.WriteLine();


        }


    }
}

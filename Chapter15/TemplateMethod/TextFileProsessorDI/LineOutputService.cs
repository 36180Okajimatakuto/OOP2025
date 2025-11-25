using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProsessorDI {
    public class LineOutputService : ITextFileService {

        private int _count;
        public void Intialize(string fname) {
            _count = 0;
        }

        public void Excute(string line) {
            if (_count < 20) {//20行までしかカウントしないようにする
                Console.WriteLine(line);
            }
            _count++;//カウントしてる
            
        }

        public void Terminate() {

        }
    }
}

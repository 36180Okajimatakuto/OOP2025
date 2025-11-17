using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProsessorDI {
    public class TextFileProsessor {
        private int _count;
        private ITextFileService _service;

        //コンストラクター
        public TextFileProsessor(ITextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Intialize(fileName);

            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines) {
                _service.Excute(line);
            }
            _service.Terminate();
        }
    }
}

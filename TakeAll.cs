using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9
{
  public class TakeAll
    {
        public TakeAll()
        {

        }

        public string forPath { get; set; }//нужен нам для получения пути по которому будуьт открывать файлы 
        public string[] forMenu { get; set; }/* нужен для передачи в массив */
        public int take { get; set; }/*этот нам нужен для получения числа всех папко и файлов*/ 
        public string[,] againTake { get; set; }/*на главный массив куда мы передаем и разделяем на страницы все файлы и папки которые у нас есть*/
        public string forFunction { get; set; }

    }
}

using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lesson_9
{

    class Program:ClassForMetod
    {
        
        static void Main(string[] args)
        {

            string sAttr = ConfigurationManager.AppSettings.Get("Key0");

            int FirstNum = Convert.ToInt32(sAttr);// тут находится число конфига в котором указанно кол-во элементов для вывода

            TakeAll takeAll = new TakeAll();
            ClassForMetod classFor = new ClassForMetod();
            string pathof;
            int patforfile;
            bool succes;
            MetodForPath(out pathof, out patforfile, out succes);

            patforfile = MetodFOrWile(out pathof, patforfile, out succes);

            takeAll.forPath = pathof;
            int count = 0;
            int CounForPage = 0;
            string NamePath = takeAll.forPath;
            int NumFaile = 10;

            string[] AllMenu = MetodForStrings(FirstNum, takeAll, ref pathof, ref patforfile, ref succes, ref count, ref CounForPage, NamePath, NumFaile);

            NewMethod1(takeAll, AllMenu);

        }

      
      

    }
}


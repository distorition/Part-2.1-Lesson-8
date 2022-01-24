﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9
{
   public class ClassForMetod
    {
        public static string[] MetodForStrings(int FirstNum, TakeAll takeAll, ref string pathof, ref int patforfile, ref bool succes, ref int count, ref int CounForPage, string NamePath, int NumFaile)
        {
            takeAll.forMenu = new string[FirstNum];
            try
            {

                string[] AllMenu1 = MetodForTakeFaile(NamePath);// тут берем все наши файла 
            }
            catch
            {
                Console.WriteLine("такого пути не существует ввидите новый");
                MetodForPath(out pathof, out patforfile, out succes);
                MetodFOrWile(out pathof, patforfile, out succes);

            }
            string[] AllMenu = MetodForTakeFaile(NamePath);// тут берем все наши файла
            for (int i = 0; i < AllMenu.Length; i++)
            {

                takeAll.take = CounForPage++;
            }


            int NumOfPage = takeAll.take / NumFaile;// тут мы получаем кол-во страниц

            for (int i = 0; i < NumOfPage;)
            {
                i++;

                Console.Write($"[{i - 1}]" + " ");


                takeAll.againTake = new string[i, FirstNum];// тут мы создаем массив на кол-во страниц и эелментов в них

            }

            Console.WriteLine();

            for (int i = 0; i < takeAll.againTake.GetLength(0); i++)
            {
                for (int y = 0; y < takeAll.againTake.GetLength(1); y++)
                {

                    count++;
                    takeAll.againTake[i, y] = AllMenu[count];// тут мы заполняем его нашими элементами 

                }

            }

            return AllMenu;
        }

        public static int MetodFOrWile(out string pathof, int patforfile, out bool succes)
        {
            do
            {

                Console.WriteLine("Введен неверный путь ");
                Console.WriteLine("Вы ввели " + patforfile);


                MetodForPath(out pathof, out patforfile, out succes);


            }
            while (succes);
            return patforfile;
        }

        private static string[] MetodForTakeFaile(string NamePath)
        {
            return Directory.GetFileSystemEntries(NamePath, "*", SearchOption.AllDirectories);
        }

        public static void MetodForPath(out string pathof, out int patforfile, out bool succes)
        {
            Console.WriteLine("Ввидите директорию типо  диск D:\\навзание папки");
            pathof = Console.ReadLine();
            succes = int.TryParse(pathof, out patforfile);
        }

        public static void NewMethod1(TakeAll takeAll, string[] Allmenu)// в этот методе мы вывод на эракн и производим основные действие 
        {
            int schet = 0;

            DateTime date = DateTime.Now;
            string filename = "random_name_exception.txt";
            string notesDirr = "errors";
            Directory.CreateDirectory(notesDirr);
            string Pat = Path.Combine(notesDirr, filename);
            if (File.Exists(Pat))
            {

            }
            else
            {
                File.Move(filename, Pat);
            }



            Console.WriteLine();

            try
            {
                int number;
                string fileMNeu = "menu.txt";

                string input = Console.ReadLine();

                bool result = int.TryParse(input, out number);

                if (result == true)
                {


                    for (int i = 0; i < takeAll.againTake.GetLength(1); i++)
                    {
                        Console.WriteLine($"{i}{ takeAll.againTake[number, i]}");// тут мы выводим наш массив на экран с теми файлами и папками которые мы туда запихнули 

                        takeAll.forMenu[i] = takeAll.againTake[number, i];


                    }


                    File.WriteAllLines(fileMNeu, takeAll.forMenu);

                    MetodForKey(fileMNeu);




                    Console.WriteLine("C-copy");
                    Console.WriteLine("D-delte");
                    Console.WriteLine("I-Information");
                }
                else
                {
                    if (/*keyinfo.Key == ConsoleKey.I*/input == "i" || input == "I")
                    {
                        Console.WriteLine("Выбирите фаил для получения информации(нажмите на цифру )");
                        int againNum = Convert.ToInt32(Console.ReadLine());
                        FileInfo file = new FileInfo(takeAll.againTake[number, againNum]);
                        try
                        {
                            Console.WriteLine($"{file.Length} размер  kb");
                            Console.WriteLine(File.GetAttributes(takeAll.againTake[number, againNum]));


                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine(File.GetAttributes(takeAll.againTake[number, againNum]));
                        }

                    }

                    if (input == "C" || input == "c")
                    {
                        Console.WriteLine("вибирите куда копирем(нажмите на число)");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("вибирите что копируем");
                        int num2 = Convert.ToInt32(Console.ReadLine());

                        string againadd = Path.GetFileName(takeAll.againTake[number, num]);


                        string add = Path.GetFileName(takeAll.againTake[number, num]);
                        Console.WriteLine($"{takeAll.againTake[number, num]}");
                        Console.WriteLine($"копируем в папку   {takeAll.againTake[number, num]} элемент {takeAll.againTake[number, num2]}");
                        //string path1=Path.Combine(AllMenu[num],add);

                        // File.Move(AllMenu[num2], Path.Combine(AllMenu[num], add));
                        try
                        {

                            File.Copy(takeAll.againTake[number, num2], takeAll.againTake[number, num]);
                        }
                        catch (IOException)
                        {
                            Directory.Move(takeAll.againTake[number, num2], takeAll.againTake[number, num]);
                        }
                    }


                    if (input == "D" || input == "d")
                    {
                        Console.WriteLine("выберите файл который надо удалить ");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        File.Delete(takeAll.againTake[number, num1]);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("Неверный формат или страницы не существует ");
                File.AppendAllText(filename, Environment.NewLine);
                File.AppendAllText(filename, "IndexOutOfRangeException находиться в не границы массива ");
                File.AppendAllText(filename, date.ToString());


                NewMethod1(takeAll, Allmenu);

            }
            catch (OutOfMemoryException)
            {

            }

            NewMethod1(takeAll, Allmenu);


        }

        private static void MetodForKey(string fileMNeu)//метод для переходы между старницами по стрелкам
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            if (keyinfo.Key == ConsoleKey.PageUp)
            {
                string[] readFile = File.ReadAllLines(fileMNeu);
                for (int i = 0; i < readFile.Length; i++)
                {
                    Console.WriteLine(readFile[i]);
                }
            }
        }
    }
}

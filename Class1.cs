using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public static class Area
    {
        public static Int32 Triangle_Area(Int32 a, Int32 h)
        {
            return (a * h) / 2;
        }

        public static Int32 Square_Area(Int32 a)
        {
            return a * a;
        }

        public static Int32 Parallel_Area(Int32 a, Int32 b)
        {
            return a * b;
        }
    }

    public static class Text_Work
    {
        public static Boolean Palindrome(String str)
        {
            char[] char_array = str.ToLower().ToCharArray();
            Array.Reverse(char_array);
            String reverse = char_array.ToString();

            if (str.ToLower() == reverse) return true;
            else return false;
        }

        public static String Reverse(String str)
        {
            char[] char_array = str.ToLower().ToCharArray();
            Array.Reverse(char_array);
            String reverse = char_array.ToString();

            return reverse;
        }

        public static Int32 Num_of_Symbols(String str)
        {
            return str.Length;
        }
    }

    public static class Contact
    {
        public static void PIB(String pib)
        {
            char[] arr = pib.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsLetter(arr[i]))
                {
                    Console.WriteLine("Неверное введённое ФИО!");
                    break;
                }
            }
        }

        public static void Age(String age)
        {
            char[] arr = age.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsDigit(arr[i]))
                {
                    Console.WriteLine("Указание возраста содержит не числовые символы!");
                    break;
                }
            }
        }

        public static void Number(String numb)
        {
            if (!numb.StartsWith("+38") && numb.Length < 13)
            {
                Console.WriteLine("Неверно введённый номер!");
            }
            else
            {
                char[] arr = numb.ToCharArray();
                for (int i = 0; i < numb.Length; i++)
                {
                    if (!char.IsDigit(arr[i]))
                    {
                        Console.WriteLine("Номер содержит не числовые символы!");
                        break;
                    }
                }
            }
        }

        public static void Mail(String mail)
        {
            if (!IsValid(mail)) Console.WriteLine("Неверно ведённый email");
        }

        private static Boolean IsValid(String email)
        {
            String pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            if (isMatch.Success) return true;
            else return false;
        }
    }

    public static class File_System
    {
        public static Boolean FindWord(String path, String word)
        {
            FileInfo file = new FileInfo(path);

            if (file.ToString().Contains(word))
            {
                Console.WriteLine($"Слово {word} найдено");
                return true;
            }
            else
            {
                Console.WriteLine($"Слово {word} не найдено");
                return false;
            }
        }

        public static Boolean FindWordByDir(String path, String word)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles(path);
            Boolean check = false;

            foreach (var file in files)
            {
                if (file.ToString().Contains(word))
                {
                    Console.WriteLine($"Слово {word} найдено");
                    check = true;
                }
                else
                {
                    Console.WriteLine($"Слово {word} не найдено");
                    check = false;
                }
            }

            return check;
        }

        public static void DeleteFileByNames(String path, String name)
        {
            String[] names = name.Split(' ');
            DirectoryInfo directory = new DirectoryInfo(path);

            for (int i = 0; i < names.Length; i++)
            {
                FileInfo[] files = directory.GetFiles(names[i]);
            }
        }

        public static void DeleteFileMask(String path, String mask)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*" + mask);

            foreach (var file in files)
            {
                file.Delete();
            }
            Console.WriteLine($"Файлы с расширением {mask} удалены");
        }

        public static void MoveFile(String path, String path2)
        {
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                file.MoveTo(path2);
                Console.WriteLine("Файл перемещён");
            }
            else Console.WriteLine("Файл не существует");
        }

        public static void CopyFile(String path, String path2)
        {
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                file.CopyTo(path2, true);
                Console.WriteLine("Файл скопирован");
            }
        }
    }
}
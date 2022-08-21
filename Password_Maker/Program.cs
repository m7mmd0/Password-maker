using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Password_Maker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //UI
            Console.Title = "Password Maker 1.0";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            int PasswordLength;

            string CopyPassword;

            string[] Menu = {"                                                 ",
            "                                               WELCOME TO PASSWORD MAKER 2022                   ",
            "                                                                   "};

            for (int paint = 0; paint < Menu.Length; paint++)
            {
                Console.WriteLine(Menu[paint]);
            }
            Console.Write("Press Enter The length of the password:");
            PasswordLength = Convert.ToInt32(Console.ReadLine());

            if (PasswordLength >= 5)
            {
                Console.Clear();
                string Password = Password_Gen(PasswordLength);

                Console.WriteLine("Your Password is:" + Password);

                Console.WriteLine("Type /copy to copy your password");

                Console.Write(">:");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                CopyPassword = Console.ReadLine();

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (CopyPassword == "/copy")
                {
                    Clipboard.SetText(Password);
                    Console.Clear();

                    Console.Write("Password copied");
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("please type /copy to copy your password next time");
                    Application.Exit();
                }

            }
            else
            {
                Console.Clear();
                Console.Write("The password length should be at lest 5 character");
            }



            Console.ReadKey(true);
        }
        public static string Password_Gen(int L)
        {
            int length = L;

            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()-_=+";


            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();

        }

    }
}
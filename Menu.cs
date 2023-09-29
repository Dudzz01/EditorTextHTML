using System;

namespace EditorHtmlProject.MenuMain
{
    class Menu
    {
        public static string modeColorBackground;

        public static void Show()
        {

            SetTextMenuOptions();

        }

        public static void DrawScreen()
        {
            #region ColorMenu
            Console.BackgroundColor = ConsoleColor.Black; // cor do background do console
            Console.ForegroundColor = ConsoleColor.Gray; // cor das letras do console
            #endregion
            Console.Clear();

            #region DrawFormatScreen
            for (int i = 1; i <= 2; i++)
            {
                FormatColunsTextScreen("+", "-", 40);

                if (i == 2)
                {
                    break;
                }

                for (int lines = 0; lines <= 10; lines++)
                {
                    FormatColunsTextScreen("|", " ", 40);

                }
            }
            #endregion
        }

        public static void FormatColunsTextScreen(string format1, string format2, int spacament)
        {
            Console.Write(format1);

            for (int i = 0; i <= spacament; i++)
            {
                Console.Write(format2);
            }

            Console.Write(format1);
            System.Console.Write($"{Environment.NewLine}");
        }

        public static void SetTextMenuOptions()
        {
            int? options = null;

            while (options != 0)
            {
                DrawScreen();
                Console.SetCursorPosition(3, 2);
                System.Console.WriteLine($"Escolha uma das opcoes do menu abaixo!");
                Console.SetCursorPosition(3, 3);
                System.Console.WriteLine("1: Abra o Arquivo");
                Console.SetCursorPosition(3, 4);
                System.Console.WriteLine("2: Edite o arquivo");
                Console.SetCursorPosition(3, 5);
                System.Console.WriteLine("0: Feche o arquivo");
                Console.SetCursorPosition(3, 7);
                options = int.Parse(Console.ReadLine());

                switch (options)
                {
                    case 1:
                        Viewer.ReadFile();
                        break;

                    case 2:
                        Editor.WriteText();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.SetCursorPosition(3, 6);
                        System.Console.WriteLine("Comando invalido, tente novamente.");
                        break;
                }


            }
        }
    }
}
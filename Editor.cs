using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace EditorHtmlProject.MenuMain
{
    class Editor
    {

        public static string textHTML;

        public static void DrawEditor()
        {
            Console.BackgroundColor = ConsoleColor.White; // cor de fundo do console
            Console.ForegroundColor = ConsoleColor.Black; // cor das letras do console
            Console.Clear();
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("======EDITOR MODE=========");
        }

        public static void WriteText()
        {
            DrawEditor();
            System.Console.WriteLine($"Digite o texto desejado.{Environment.NewLine}");
            StringBuilder textBuilder = new StringBuilder();

            while (true)
            {

                var text = Console.ReadKey(true);

                if (text.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (text.Key == ConsoleKey.Enter)
                {
                    textBuilder.AppendLine();
                    System.Console.WriteLine();

                }
                else if (text.Key == ConsoleKey.Backspace)
                {
                    if (textBuilder.Length > 0)
                    {
                        textBuilder.Remove(textBuilder.Length - 1, 1);
                        System.Console.Write("\b \b");
                    }

                }
                else
                {
                    textBuilder.Append(text.KeyChar);
                    Console.Write(text.KeyChar);

                }
            }

            

            textHTML = textBuilder.ToString();

            var textFinal = Viewer.ConfigureTagStrongHTML(textHTML, false);

            
            SaveText(textFinal,textBuilder);
        }

        public static void SaveText(string text, StringBuilder textBuilder)
        {

            System.Console.WriteLine($"Qual diretório/caminho você deseja salvar o arquivo e seu respectivo conteúdo?{Environment.NewLine}");
            var path = Console.ReadLine();
            var oldText = Viewer.ReadFile(path);
            if(File.Exists(path))
            {
                textBuilder.Remove(0,textBuilder.Length);
                textBuilder.Append(oldText);
                textBuilder.AppendLine();
                textBuilder.Append(text);
            }

            using (StreamWriter file = new StreamWriter(path))
            {
                text = textBuilder.ToString();
                file.Write(text);
            }


        }



    }
}
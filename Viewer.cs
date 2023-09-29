using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace EditorHtmlProject.MenuMain
{
    class Viewer
    {
        public static void DrawViewer()
        {
            Console.BackgroundColor = ConsoleColor.White; // cor de fundo do console
            Console.ForegroundColor = ConsoleColor.Black; // cor das letras do console
            Console.Clear();
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("======READER MODE=========");

            
        }

        public static void ReadFile()
        {
            DrawViewer();
            System.Console.WriteLine("Digite o caminho/diretório do arquivo que você deseja ler");
            var path = Console.ReadLine();
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    var text = file.ReadToEnd();

                    ConfigureTagStrongHTML(Editor.textHTML,true);
                    System.Console.WriteLine($"{Environment.NewLine}Arquivo lido com sucesso, aperte qualquer tecla para voltar ao menu.");


                    Console.ReadKey(true);
                }

                return;
            }
            System.Console.WriteLine("Arquivo inexistente ou não encontrado, digite qualquer tecla para voltar ao menu");
            Console.ReadKey(true);
        }

        public static string? ReadFile(string path)
        {
            
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    var text = file.ReadToEnd();


                    return text;
                    
                }

                
            }
            return null;
            
        }

        public static string ConfigureTagStrongHTML(string text, bool read)
        {
            Regex[] regex = new Regex[40]; //array de padroes regex

            regex[0] = new Regex(@"(<strong>)(\s*[^<]+\s*)(</strong>)", RegexOptions.IgnoreCase); //primeiro parametro: utiliza-se o regex para encontrar o padrão de texto <strong>palavraQualquer</strong>, o segundo parametro faz com que o regex n diferencie palavras maiusculas de minusculas
            regex[1] = new Regex(@"(<strong>\s*[^<]+\s*</strong>)", RegexOptions.IgnoreCase);

            
            


            #region TagStrongHTML

            if (regex[0].IsMatch(text))
            {

                Console.ForegroundColor = ConsoleColor.Blue;

                var matchsRegex1 = regex[0].Matches(text);
                var matchsRegex2 = regex[1].Matches(text);

                string[] textWithBoldWords = new string[matchsRegex1.Count];
                string[] textWillReplace = new string[matchsRegex2.Count];
                int[] firstIndexOfBoldWords = new int[matchsRegex1.Count];
                char[] newText = new char[text.Length];

                var auxIndexOfArrayWords = 0;
                var auxBooleanOfArrayWords = false;
                

                

                for (int countText = 0; countText < matchsRegex1.Count; countText++)
                {
                    textWithBoldWords[countText] = regex[0].Match(text).Groups[2].Value;
                    textWillReplace[countText] = regex[1].Match(text).Groups[1].Value;
                    
                    
                    
                    if (text.Contains(textWillReplace[countText]))
                    {
                        text = text.Replace(textWillReplace[countText], textWithBoldWords[countText]);
                        firstIndexOfBoldWords[countText] = text.IndexOf(textWithBoldWords[countText]);

                    }
                }

                newText = text.ToCharArray();

                for (int count = 0; count < newText.Length; count++)
                {

                    if (count >= firstIndexOfBoldWords[auxIndexOfArrayWords] && count <= firstIndexOfBoldWords[auxIndexOfArrayWords] + textWithBoldWords[auxIndexOfArrayWords].Length)
                    {
                        if(read)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(newText[count]);
                        }
                        
                        
                        auxBooleanOfArrayWords = false;
                        
                        
                    }
                    else
                    {
                        if (read)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(newText[count]);
                        }
                    }

                    if (count > firstIndexOfBoldWords[auxIndexOfArrayWords] + textWithBoldWords[auxIndexOfArrayWords].Length && auxBooleanOfArrayWords == false)
                    {
                        if (auxIndexOfArrayWords < textWithBoldWords.Length-1 )
                        {
                            auxIndexOfArrayWords++;
                        }
                            
                        auxBooleanOfArrayWords = true;
                    }

                }


            }

            return text;
        }
        #endregion
    }
}

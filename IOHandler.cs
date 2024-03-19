using System;

namespace AlgorithmsAssessment
{
    public class IOHandler
    {
        public (bool, int) HandleMenu(string[] options)
        {
            Console.WriteLine();

            for (int i = 0; i < options.Length; i++)
            {
                WriteColourTextLine($"[{i + 1}] {options[i]}", ConsoleColor.Cyan);
            }

            WriteColourText("Option: ", ConsoleColor.Cyan);
            string option = Console.ReadLine();

            try
            {
                int value = Int32.Parse(option) - 1;

                if (value < 0 || value > options.Length - 1)
                {
                    throw new FormatException("Value is out of bounds.");
                }
                else
                {
                    return (true, value);
                }
            }
            catch (FormatException e)
            {
                WriteColourTextLine($"Invalid Value Entered.\nError Details: {e}", ConsoleColor.Red);
                return (false, 0);
            }
        }

        public void WriteColourTextLine(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void WriteColourText(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
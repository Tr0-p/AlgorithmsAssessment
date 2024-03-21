using System;

namespace AlgorithmsAssessment
{
    public class IOHandler
    {
        /// <summary>
        /// Outputs a menu and collects the users choice.
        /// </summary>
        /// <param name="options">The options to output.</param>
        /// <returns>Whether they successfully chose a correct option and the option chosen.</returns>
        /// <exception cref="FormatException"></exception>
        public (bool, int) HandleMenu(string[] options)
        {
            Console.WriteLine();
            
            // Loop through and output every option.
            for (int i = 0; i < options.Length; i++)
            {
                WriteColourTextLine($"[{i + 1}] {options[i]}", ConsoleColor.Cyan);
            }
            
            // Collect the users input on which option they'd like.
            WriteColourText("Option: ", ConsoleColor.Cyan);
            string option = Console.ReadLine();

            try
            {
                int value = Int32.Parse(option) - 1; // Convert the option into an integer.

                if (value < 0 || value > options.Length - 1)  // Ensure it is in the bounds.
                {
                    throw new FormatException("Value is out of bounds.");
                }
                else
                {
                    return (true, value);  // Return the value back.
                }
            }
            catch (FormatException e)
            {
                WriteColourTextLine($"Invalid Value Entered.\nError Details: {e}", ConsoleColor.Red);
                return (false, 0);
            }
        }
        
        /// <summary>
        /// Output a line of coloured text.
        /// </summary>
        /// <param name="text">The text to output.</param>
        /// <param name="colour">Which ConsoleColor to use.</param>
        public void WriteColourTextLine(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        
        /// <summary>
        /// Output characters onto the console.
        /// </summary>
        /// <param name="text">The text to output.</param>
        /// <param name="colour">Which ConsoleColour to use.</param>
        public void WriteColourText(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
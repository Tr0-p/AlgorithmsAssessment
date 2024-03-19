﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using AlgorithmsAssessment;

namespace AlgorithmsAssessment
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FileHandling fileHandler = new FileHandling();
            IOHandler io = new IOHandler();
            string[] arrayOptions = {"Net_1_256", "Net_2_256", "Net_3_256"};

            List<int> net1 = fileHandler.ReadFileIntoArray("Net_1_256.txt");
            List<int> net2 = fileHandler.ReadFileIntoArray("Net_2_256.txt");
            List<int> net3 = fileHandler.ReadFileIntoArray("Net_3_256.txt");
            
            (bool, int) arrayChosen = (false, 0);

            while (!arrayChosen.Item1)
            {
                arrayChosen = io.HandleMenu(arrayOptions);
            }
            
            
            
        }
    }
}
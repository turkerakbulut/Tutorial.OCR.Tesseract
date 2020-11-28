/* <copyright file=Program company="Türker Akbulut">
   Copyright (c) 2020 All Rights Reserved
   </copyright>
   <author>Türker Akbulut</author>
   <date>2020-11-28 5:38:52 PM</date>
   <summary>Class representing a Tutotial.OCR.WithTesseract.Program</summary>*/


using System;
using System.Diagnostics;
using T = Tesseract;

namespace Tutorial.OCR.Tesseract
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Input image path:");

            string input = Console.ReadLine();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            T.TesseractEngine engine = new T.TesseractEngine("tessdata", "tur", T.EngineMode.TesseractAndLstm);

            stopwatch.Stop();

            Console.WriteLine("Engine creation :" + stopwatch.ElapsedMilliseconds.ToString() + " ms");

            stopwatch.Restart();

            T.Pix image = T.Pix.LoadFromFile(input);

            T.Page page = engine.Process(image);

            string text = page.GetText();

            stopwatch.Stop();

            Console.WriteLine("Process time :" + stopwatch.ElapsedMilliseconds.ToString() + " ms");

            Console.Write("Result: " + text);

            Console.Read();
        }
    }
}
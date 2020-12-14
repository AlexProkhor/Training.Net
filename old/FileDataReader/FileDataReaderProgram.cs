// <copyright file="FileDataReaderProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/*
  Написать класс, который будет считывать построчно данные из файла,
  выводит в консоль и записывает в выходной файл только те, для которых пользователь нажал пробел,
  если он нажал Esc, то выбрасывать исключение.
  Реализовать здесь паттерн IDisposable.
*/
namespace FileDataReader
{
    using System;
    using System.IO;

    /// <summary>
    /// Takes information from and add to txt.
    /// </summary>
    public class TxtFiles : IDisposable
    {
        private static readonly string readPath = @"E:\Projects\Training.Net\Training.Net\FileDataReader_Read.txt";
        private static readonly string writePath = @"E:\Projects\Training.Net\Training.Net\FileDataReader_Write.txt";

        // Flag: Has Dispose already been called?
        private bool disposed;

        /// <summary>
        /// Gets txt readonly file.
        /// </summary>
        public StreamReader Reader { get; private set; }

        /// <summary>
        /// Gets or sets txt file.
        /// </summary>
        public StreamWriter Writer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TxtFiles"/> class.
        /// </summary>
        public TxtFiles()
        {
            disposed = false;
            Reader = null;
            try
            {
                Reader = new StreamReader(readPath, System.Text.Encoding.Default);
                Writer = new StreamWriter(writePath, true, System.Text.Encoding.Default);
            }
            catch (Exception ex)
            {
                if (Reader != null)
                {
                    Reader.Dispose();
                    Console.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposing txt files.
        /// </summary>
        /// <param name="disposing"> param. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                Reader.Dispose();
                Writer.Dispose();
            }

            disposed = true;
        }
    }

    /// <summary>
    /// Main.
    /// </summary>
    internal class FileDataReaderProgram
    {
        private static void Main()
        {
            using var txtFile = new TxtFiles();
            ReadLineFromTxt(txtFile);
        }

        /// <summary>
        /// Read string from txt.
        /// </summary>
        private static void ReadLineFromTxt(TxtFiles txtFile)
        {
            string line;
            while ((line = txtFile.Reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                WriteLineToTxt(line, txtFile);
            }
        }

        /// <summary>
        /// Write string to txt.
        /// </summary>
        /// <param name="line"> Line from ReadLineFromTxt.</param>
        /// <param name="txtFile"> Txt file. </param>
        private static void WriteLineToTxt(string line, TxtFiles txtFile)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Spacebar:
                    {
                        txtFile.Writer.WriteLine(line);
                    }

                    Console.WriteLine("recording completed...");
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Exeption! esc was pressed ");
                    break;
                default:
                    break;
            }
        }
    }
}

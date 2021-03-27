using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercise1
{
    class DummyDatabase
    {
        public bool IsConnected { get; set; } = false;

        public void Connect()
        {
            int random = new Random().Next(1,5);
            try
            {
                if (random == 1)
                    throw new DummyDatabaseConnectionException("Failed To Connect. Please Retry!");
                IsConnected = true;
                Console.WriteLine("Succesfully Connected.");
            }
            catch(DummyDatabaseConnectionException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finished Connection Try.");
                //Disconnect();
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from Database...");
            IsConnected = false;
        }

        public void Save(string[] wordsToSave)
        {
            if(IsConnected)
            {
                if(wordsToSave.Length > 5)
                {
                    Console.WriteLine("You cannot save more than 5 words using a Dummy Database. Removing the extra words...");
                    Array.Resize(ref wordsToSave, 5);
                }

                if (wordsToSave.Length != 0)
                {
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Words.txt";
                    using (TextWriter writer = File.CreateText(filePath))
                    {
                        foreach (string word in wordsToSave)
                        {
                            writer.Write(word + "\n");
                        }
                    }
                    Console.WriteLine("Succesfully saved the words. Please check the file on your Desktop.");
                }
                else
                    Console.WriteLine("Cannot save empty line.");
            }
            else
            {
                Console.WriteLine("You are not connected to the DummyDB, thus you cannot save words.");
            }
        }

    }
}

using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            DummyDatabase db = new DummyDatabase();

            db.Connect();

            Console.WriteLine("Please input the words that you want to be saved in the file (Separated by space):");
            string[] wordsToSave = Console.ReadLine().Split(" ");

            db.Save(wordsToSave);

            db.Disconnect();

        }
    }
}

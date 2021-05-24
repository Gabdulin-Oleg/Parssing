using System;
using System.Collections.Generic;
using System.IO;

namespace Parssing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Forms> forms = ParssingToWord.GetTablInForld();

            foreach (var item in forms)
            {
                Console.WriteLine("id: {0} , FirstName: {1} , LastName = {2}, MidleName = {3}, role = {4}",item.Id, item.FirstName, item.LastName, item.MidleName, item.Role);
            }

            Console.ReadKey();

        }
    }
}

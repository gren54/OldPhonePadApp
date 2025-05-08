using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePadApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Old Phone Pad Test");

            string input = "4433555 555666#";
            string output = OldPhonePadConverter.OldPhonePad(input);

            Console.WriteLine($"Output: {output}");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}  

using System;
using System.IO;

namespace EvolandPakExtractor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var file in Directory.GetFiles("D:\\Debugging\\Projects\\Evoland Legendary Edition\\Original Paks"))
            {
                Unpack(Path.GetFileName(file));
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static void Unpack(string fileName)
        {
            string inputFile = fileName;
            string outputPath = Path.ChangeExtension(Path.Combine("Extracted", inputFile), null);
            if (Directory.Exists(outputPath))
            {
                Console.WriteLine($"{fileName}: Output path already exists");
                return;
            }

            PakFile pak = PakFile.ReadPakFile(inputFile);

            pak.ExtractAll(outputPath);
        }

        private static void Pack(string inputDirectory, string fileName)
        {
            PakFile.Pack(inputDirectory, fileName);
        }
    }
}

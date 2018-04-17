using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Genetic_Algorithm_Implemented_in_CS
{
    class Program
    {
        static GeneticAlgorithm<char> geneticAlgorithm;
        static Random random;
        static string targetString = "To be, or not to be, that is the question.";
        static string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,.|!#$%&/()=? ";
        static int populationSize = 200;
        static  float mutationRate = 0.01f;
        static int elitism = 5;
        static void Main(string[] args)
        {
            
            random = new Random() ;
            geneticAlgorithm = new GeneticAlgorithm<char>(populationSize, targetString.Length, random, GetRandomCharacter, CalcFitness, elitism, mutationRate );
            Program.Update();
        }

        static char GetRandomCharacter()
        {
            int index = random.Next(validCharacters.Length);
            return validCharacters[index];
        }

        static float CalcFitness(int index)
        {
            float score = 0;
            for (int i = 0; i < geneticAlgorithm.Population[index].Genes.Length; i++)
            {
                if (geneticAlgorithm.Population[index].Genes[i] == targetString[i])
                {
                    score++;
                }   
            }
            score /= targetString.Length;
            return score;
        }

        static void Update ()
        {
            while (true)
            {
                
                geneticAlgorithm.NewGeneration();
                Console.WriteLine(geneticAlgorithm.BestGenes);
                
            }
        }
    }
}

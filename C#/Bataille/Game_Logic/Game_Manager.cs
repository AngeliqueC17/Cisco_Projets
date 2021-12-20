using System;

namespace Game_Logic
{
    public class Game_Manager
    {
        public static void Initialization()
        {
            int nbpl;
            do
            {
                Console.WriteLine("Veuillez entrer un nombre entre 2 et 6");
                nbpl = int.Parse(Console.ReadLine());
            } while (nbpl > 1 && nbpl < 7);
        }
    }
}
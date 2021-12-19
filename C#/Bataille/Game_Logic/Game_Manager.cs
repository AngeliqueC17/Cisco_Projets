using System;

namespace Game_Logic
{
    public class Game_Manager
    {
        private static Player _aPlayer;
        
        public static void Initialization()
        {
            int nbpl;
            string name;
            nbpl = int.Parse(Console.ReadLine());
            while (nbpl < 2  || nbpl > 6){
                Console.WriteLine("Veuillez entrer un nombre entre 2 et 6");
                nbpl = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < nbpl; i++)
            {
                Console.WriteLine("Veuillez saisir le prénom du joueur n°" + i );
                name = Console.ReadLine();
                _aPlayer = new Player(name); //NE FONCTIONNE PAS, FAIRE UN TABLEAU
            }
        }
    }
}
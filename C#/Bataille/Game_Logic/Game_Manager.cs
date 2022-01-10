using System;
using System.Threading.Tasks;
using Deck_of_Cards;

namespace Game_Logic
{
    public class Game_Manager

    {
        public static async Task Initialization()
        {
            Deck deck = await Call.Draw_A_Card(); //Calls the method to implement the deck
        }

        //Faire une méthode afin de stocker les joueurs dans un tableau
        //Tant qu'il y a des joueurs, les mettres dans un tableau

        //Faire une méthode qui permet de distribuer une carte par une carte à chacun des joueurs
        //deck.card.pop = distribuer une carte
        //Une carte distribuée à un joueur = +1 dans la pile de carte du joueur
        //Une carte distribuée à un joueur = -1 dans la pile de carte du deck principal
        //Il est possible selon le nombre de joueurs que certains aient plus de cartes que d'autres

    }
}
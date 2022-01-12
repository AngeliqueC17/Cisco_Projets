using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Deck_of_Cards;
using Newtonsoft.Json;

namespace Game_Logic
{
    public class Game_Manager

    {
        public Deck Jeu;
        public Call MonAPI;

        public Game_Manager()
        {
            MonAPI = new Call();
            Jeu = new Deck();
        }
     /*   public static void Initialization(int nbpl)
        {
            Deck deck = Draw_A_Card(); //Calls the method to implement the deck
            int[] tab = new int[nbpl - 1];
            foreach (int joueur in tab)
            {
                //Deck deck = Initialization();
                int nbJoueur = nbpl;
                int nbrCartesJoueur = deck.Remaining / nbJoueur;
                tab[joueur] = nbrCartesJoueur; // on met le nombre de carte du joueur 
                nbJoueur = nbJoueur - 1;
                //  deck = deck.Remaining - nbrCartesJoueur;

            }
            for (int i = 0; i <= nbpl; i++)
            {

            }

        }*/
        /* public List<Card> Draw(int howMany)
         {
             List<Card> userHand = new List<Card>();

             for (int i = 0; i < howMany; i++)
             {
                 int index = RandomNumber(0, CardSet.Count);

                 userHand.Add(new Card((int)CardSet[index].CardSuit, (int)CardSet[index].CardValue));
                 CardSet.RemoveAt(index);
             }

             return userHand;
         }*/

        public static void Distribution(int nbpl, Deck deck)
        {
            int nbcarddeck = 52;
            int cardpl = 0;
            int nbj = nbpl;
            //Uri Url = new Uri("https://deckofcardsapi.com/api/deck/<<deck_id>>/pile/<<pile_name>>/add/?cards=AS,2S");
            for (int i = 1; i <= nbpl; i++)
            {
                cardpl = nbcarddeck / nbj;
                // string index = Random(nbj, deck.Cards);
                //deck.Cards;
                var rand = new Random();
                List<Card> liste = new List<Card>;
                for (int j =1; j<=cardpl; j++)
                {
                    
                    //liste.Add(rand.Next(deck.Cards, deck.Cards));
                }
               
                string Urle = "https://deckofcardsapi.com/api/deck/" + deck.ID + "/pile/player" + i + "/add/?cards=" + liste ;
                Uri Url = new Uri(Urle);
                Task<string> MonJeu = Call.FonctionGet(Url);
                string contentResponse = MonJeu.Result;
                Piles pile = JsonConvert.DeserializeObject<Piles>(contentResponse);
            }

        }


        public static Deck Initialization(int nbpl)
        {
            string Urle = "https://deckofcardsapi.com/api/deck/new/draw/?count=52"; 
            Uri Url = new Uri(Urle);                                                                          
            Task<string> MonJeu = Call.FonctionGet(Url);
            string contentResponse = MonJeu.Result;//This choice is explained in order to be able to have a deck made up of 52 cards that can be displayed
            Deck deck = JsonConvert.DeserializeObject<Deck>(contentResponse); //Converts the recovered JSON into objects, here a deck with cards
            Distribution(nbpl, deck);
            return deck; //Return the deck with an ID, the count of remaining, the cards and the deck shuffled
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
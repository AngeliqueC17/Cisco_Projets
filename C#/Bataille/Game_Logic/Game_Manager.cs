using System;
using System.Collections.Generic;
using System.Linq;
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
            Jeu = Initialization();
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

        public static void Distribution(int nbpl, Deck deck)
        {
            int nbcarddeck = 52;
            int cardpl = 0;
            int nbj = nbpl;
            Uri Url; //Url = new Uri("https://deckofcardsapi.com/api/deck/<<deck_id>>/pile/<<pile_name>>/add/?cards=AS,2S"); // base url, without modification
            string url_in_text = string.Empty;
            for (int i = 1; i <= nbpl; i++) //for the total number of players, for every player
            {
                string liste = ""; // create a list wich will contain the cards of the current player
                cardpl = nbcarddeck / nbj; // initialise the number of cards that the player will have
                url_in_text = "https://deckofcardsapi.com/api/deck/" + deck.ID + "/draw/?count=" + cardpl;// draw the number cards of the player
                Url = new Uri(url_in_text);
                Task<string> MonJeu = Call.FonctionGet(Url);
                // get json call
                string contentResponse = MonJeu.Result;
                Deck pile = JsonConvert.DeserializeObject<Deck>(contentResponse); // convert the pile
                Console.WriteLine(deck.Cards);
                foreach (string uneCarte in pile.Cards.Select(Card => Card.Code))
                {
                    liste += uneCarte + ','; // add to the list the cards of the current player
                }
                url_in_text = "https://deckofcardsapi.com/api/deck/" + deck.ID + "/pile/player" + i + "/add/?cards=" + liste;
                Console.WriteLine(url_in_text);// add to the pile of the player the card
                Url = new Uri(url_in_text);
                Task<string> MonJeu2 = Call.FonctionGet(Url);
                nbj = nbj - 1; // number of players - 1 , for the next instruction for, for the calcul
                nbcarddeck = nbcarddeck - cardpl; // update the total number of cards of the deck
            }

        }


        public static Deck Initialization()
        {
            string Urle = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"; 
            Uri Url = new Uri(Urle);                                                                          
            Task<string> MonJeu = Call.FonctionGet(Url);
            string contentResponse = MonJeu.Result;//This choice is explained in order to be able to have a deck made up of 52 cards that can be displayed
            Deck deck = JsonConvert.DeserializeObject<Deck>(contentResponse); //Converts the recovered JSON into objects, here a deck with cards
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
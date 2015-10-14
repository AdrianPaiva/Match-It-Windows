using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
/**************************************************
* Adrian Paiva
* 100864588
* created: 10/20/2014
* lastEdit: 11/1/2014
**************************************************/


namespace MatchIt
{
    class Deck
    {
        private List<Pair> deck;
        private List<Card> cardsShuffled;
        private Pair p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25;
        private Texture2D t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25;

        public Deck(Game1 game)
        {
            t1 = game.Content.Load<Texture2D>("1");
            t2 = game.Content.Load<Texture2D>("2");
            t3 = game.Content.Load<Texture2D>("3");
            t4 = game.Content.Load<Texture2D>("4");
            t5 = game.Content.Load<Texture2D>("5");
            t6 = game.Content.Load<Texture2D>("6");
            t7 = game.Content.Load<Texture2D>("7");
            t8 = game.Content.Load<Texture2D>("8");
            t9 = game.Content.Load<Texture2D>("9");
            t10 = game.Content.Load<Texture2D>("10");
            t11 = game.Content.Load<Texture2D>("11");
            t12 = game.Content.Load<Texture2D>("12");
            t13 = game.Content.Load<Texture2D>("13");
            t14 = game.Content.Load<Texture2D>("14");
            t15 = game.Content.Load<Texture2D>("15");
            t16 = game.Content.Load<Texture2D>("16");
            t17 = game.Content.Load<Texture2D>("17");
            t18 = game.Content.Load<Texture2D>("18");
            t19 = game.Content.Load<Texture2D>("19");
            t20 = game.Content.Load<Texture2D>("20");
            t21 = game.Content.Load<Texture2D>("21");
            t22 = game.Content.Load<Texture2D>("22");
            t23 = game.Content.Load<Texture2D>("23");
            t24 = game.Content.Load<Texture2D>("24");
            t25 = game.Content.Load<Texture2D>("25");

            Card c1 = new Card(t1, 1);
            Card c2 = new Card(t1, 1);
            Card c3 = new Card(t2, 2);
            Card c4 = new Card(t2, 2);
            Card c5 = new Card(t3, 3);
            Card c6 = new Card(t3, 3);
            Card c7 = new Card(t4, 4);
            Card c8 = new Card(t4, 4);
            Card c9 = new Card(t5, 5);
            Card c10 = new Card(t5, 5);
            Card c11 = new Card(t6, 6);
            Card c12 = new Card(t6, 6);
            Card c13 = new Card(t7, 7);
            Card c14 = new Card(t7, 7);
            Card c15 = new Card(t8, 8);
            Card c16 = new Card(t8, 8);
            Card c17 = new Card(t9,9);
            Card c18 = new Card(t9,9);
            Card c19 = new Card(t10,10);
            Card c20 = new Card(t10,10);
            Card c21 = new Card(t11,11);
            Card c22 = new Card(t11,11);
            Card c23 = new Card(t12,12);
            Card c24 = new Card(t12,12);
            Card c25 = new Card(t13,13);
            Card c26 = new Card(t13,13);
            Card c27 = new Card(t14,14);
            Card c28 = new Card(t14,14);
            Card c29 = new Card(t15,15);
            Card c30 = new Card(t15,15);
            Card c31 = new Card(t16,16);
            Card c32 = new Card(t16,16);
            Card c33 = new Card(t17,17);
            Card c34 = new Card(t17,17);
            Card c35 = new Card(t18,18);
            Card c36 = new Card(t18,18);
            Card c37 = new Card(t19,19);
            Card c38 = new Card(t19,19);
            Card c39 = new Card(t20,20);
            Card c40 = new Card(t20,20);
            Card c41 = new Card(t21,21);
            Card c42 = new Card(t21,21);
            Card c43 = new Card(t22,22);
            Card c44 = new Card(t22,22);
            Card c45 = new Card(t23,23);
            Card c46 = new Card(t23,23);
            Card c47 = new Card(t24,24);
            Card c48 = new Card(t24,24);
            Card c49 = new Card(t25,25);
            Card c50 = new Card(t25,25);

            p1 = new Pair(c1, c2);
            p2 = new Pair(c3, c4);
            p3 = new Pair(c5, c6);
            p4 = new Pair(c7, c8);
            p5 = new Pair(c9, c10);
            p6 = new Pair(c11, c12);
            p7 = new Pair(c13, c14);
            p8 = new Pair(c15, c16);
            p9 = new Pair(c17, c18);
            p10 = new Pair(c19, c20);
            p11 = new Pair(c21, c22);
            p12 = new Pair(c23, c24);
            p13 = new Pair(c25, c26);
            p14 = new Pair(c27, c28);
            p15 = new Pair(c29, c30);
            p16 = new Pair(c31, c32);
            p17 = new Pair(c33, c34);
            p18 = new Pair(c35, c36);
            p19 = new Pair(c37, c38);
            p20 = new Pair(c39, c40);
            p21 = new Pair(c41, c42);
            p22 = new Pair(c43, c44);
            p23 = new Pair(c45, c46);
            p24 = new Pair(c47, c48);
            p25 = new Pair(c49, c50);

            deck = new List<Pair>();
            deck.Add(p1);
            deck.Add(p2);
            deck.Add(p3);
            deck.Add(p4);
            deck.Add(p5);
            deck.Add(p6);
            deck.Add(p7);
            deck.Add(p8);
            deck.Add(p9);
            deck.Add(p10);
            deck.Add(p11);
            deck.Add(p12);
            deck.Add(p13);
            deck.Add(p14);
            deck.Add(p15);
            deck.Add(p16);
            deck.Add(p17);
            deck.Add(p18);
            deck.Add(p19);
            deck.Add(p20);
            deck.Add(p21);
            deck.Add(p22);
            deck.Add(p23);
            deck.Add(p24);
            deck.Add(p25);

            Shuffle(deck);
            cardsShuffled = getCardsFromPairs();
            Shuffle(cardsShuffled);
            
        }
        private void Shuffle<E>(List<E> inputList)
        {
            /*
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); 
                randomList.Add(inputList[randomIndex]); 
                inputList.RemoveAt(randomIndex); 
            }*/

            Random rng = new Random();
            int n = inputList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                E value = inputList[k];
                inputList[k] = inputList[n];
                inputList[n] = value;
            }
            
            //return randomList; 
        }
        private List<Card> getCardsFromPairs()
        {
            List<Card> cards = new List<Card>();

            foreach (Pair p in deck)
            {
                cards.Add(p.getFirst());
                cards.Add(p.getSecond());
            }
            cards.RemoveRange(12, cards.Count - 12); // remove extra cards
            
            return cards;
        }
        public List<Card> getCardsShuffled()
        {
            
            return cardsShuffled;
        }
        
    }
}

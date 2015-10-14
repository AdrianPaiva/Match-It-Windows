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
using System.Threading;
using System.Xml.Serialization;
using System.IO;

/**************************************************
* Adrian Paiva
* 100864588
* created: 10/20/2014
* lastEdit: 11/1/2014
**************************************************/
namespace MatchIt
{
    class GameScreen
    {
        private Texture2D backgroundTexture;
        private Texture2D cardBack;
        private Game1 game;
        int screenWidth;
        int screenHeight;
        private Texture2D quitButton;
        private Vector2 quitButtonPosition;
        private MouseState mouseState;
        private Point mousePosition;
        private Rectangle quitButtonRectangle;
        private Deck deck;
        private List<Card> cards;
        ButtonState prevState = ButtonState.Released;
        private Rectangle[] rectangles;

        private SpriteFont font;
        float timer = 0;
        Boolean runTimer;

        private int cardsFlipped;
        private int card1;
        private int card2;

        float elapsedTime = 0;

        public GameScreen(Game1 game)
        {
            runTimer = true;
            cardsFlipped = 0;
            font = game.Content.Load<SpriteFont>("myFont");

            this.game = game;
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
            backgroundTexture = game.Content.Load<Texture2D>("background");
            cardBack = game.Content.Load<Texture2D>("mainBack");
            quitButton = game.Content.Load<Texture2D>("quit");
            quitButtonPosition = new Vector2(700, 400);

            quitButtonRectangle = new Rectangle((int)quitButtonPosition.X, (int)quitButtonPosition.Y, quitButton.Width, quitButton.Height);

            deck = new Deck(game);

            cards = deck.getCardsShuffled();

            rectangles = new Rectangle[12] { 
                new Rectangle(50, 0, 100, 100),
                new Rectangle(50, 125, 100, 100),
                new Rectangle(50, 250, 100, 100),
                new Rectangle(250, 0, 100, 100),
                new Rectangle(250, 125, 100, 100),
                new Rectangle(250, 250, 100, 100),
                new Rectangle(450, 0, 100, 100),
                new Rectangle(450, 125, 100, 100),
                new Rectangle(450, 250, 100, 100), 
                new Rectangle(650, 0, 100, 100),
                new Rectangle(650, 125, 100, 100),
                new Rectangle(650, 250, 100, 100),
                };

            cards[0].setRect(rectangles[0]);
            cards[1].setRect(rectangles[1]);
            cards[2].setRect(rectangles[2]);
            cards[3].setRect(rectangles[3]);
            cards[4].setRect(rectangles[4]);
            cards[5].setRect(rectangles[5]);
            cards[6].setRect(rectangles[6]);
            cards[7].setRect(rectangles[7]);
            cards[8].setRect(rectangles[8]);
            cards[9].setRect(rectangles[9]);
            cards[10].setRect(rectangles[10]);
            cards[11].setRect(rectangles[11]);

            
            
        }
        public void Update(GameTime gameTime)
        {
            if (runTimer)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            mouseState = Mouse.GetState();

            ButtonState currState = mouseState.LeftButton;
            if (currState == ButtonState.Pressed && currState != prevState)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (quitButtonRectangle.Contains(mousePosition)) // quit Button
                {
                    game.quitGame();
                }

                foreach (Rectangle r in rectangles)
                {
                    if (r.Contains(mousePosition))
                    {                       
                        foreach (Card c in cards)
                        {
                            //int a 
                            if (c.getRect().Intersects(r) && !c.isFlipped())
                            {                              
                                if (cardsFlipped == 0)
                                {
                                    c.flip();
                                    cardsFlipped++;
                                    card1 = cards.IndexOf(c); 
                                } 
                                else if(cardsFlipped == 1 && cards.IndexOf(c) != card1)
                                {
                                    c.flip();
                                    cardsFlipped++;
                                    card2 = cards.IndexOf(c);                                     
                                }                              
                            }
                        }
                    }
                }
                
                prevState = currState;

            } if (currState == ButtonState.Released)
            {
                prevState = currState;
            }

            if (cardsFlipped == 2)
            {
                elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsedTime >= 1000)
                {

                    if (cards[card1].getPairId() == cards[card2].getPairId())
                    {
                        cards[card1].setVisible(false);
                        cards[card2].setVisible(false);

                    }
                    else if (cards[card1].getPairId() != cards[card2].getPairId())
                    {
                        cards[card1].flip();
                        cards[card2].flip();
                    }

                    int count = 0;

                    foreach (Card c in cards)
                    {
                        if(c.isFlipped())
                        {
                          count++; // total cards flipped
                        }
                     }
                    if (count == 12)// user wins
                    {
                        runTimer = false;
                        string username = Environment.UserName;
                        float time = timer;
                        Player p = new Player(username, time);
                        //p.setName(username);
                       // p.setTime(time);
                        savePlayer(p);

                    }
                    cardsFlipped = 0;
                    elapsedTime = 0;

                }
            }           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
             Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
             spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

             foreach (Card c in cards)
             {
                 if (c.isVisible())
                 {
                     spriteBatch.Draw(c.isFlipped() ? c.getImage() : cardBack, c.getRect(), Color.White);
                 }
                     
             }
            spriteBatch.DrawString(font,timer.ToString("0.00"), new Vector2(100,400), Color.PeachPuff);

            if(!runTimer) // user wins
            {
                spriteBatch.DrawString(font, "You Win !!!!", new Vector2(250, 200), Color.PeachPuff);
            }
             

             spriteBatch.Draw(quitButton, quitButtonPosition,Color.White);

        }
        public void savePlayer(Player p)
        {
            List<Player> players = loadPlayers();
            players.Add(p);

            FileStream stream = File.Open(@"C:\scores.xml", FileMode.Create);
            try
            {
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
                serializer.Serialize(stream, players);
            }
            finally
            {
                
                stream.Close();
            }
        }
        public List<Player> loadPlayers()
        {
            List<Player> players = new List<Player>();


            try
            {

                if (File.Exists(@"C:\scores.xml"))
                {
                    FileStream stream = File.Open(@"C:\scores.xml", FileMode.Open, FileAccess.Read);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
                    players = (List<Player>)serializer.Deserialize(stream);
                    stream.Close();
                }

            }
            catch(Exception e)
            {
                
            }

            return players;
        }
    }
}

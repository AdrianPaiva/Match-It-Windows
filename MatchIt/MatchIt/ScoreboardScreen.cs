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
    class ScoreboardScreen
    {
        private Texture2D backgroundTexture;
        private Game1 game;
        int screenWidth;
        int screenHeight;

        private Texture2D homeButton;
        private Vector2 homeButtonPosition;

        private MouseState mouseState;
        private Point mousePosition;

        private Rectangle homeButtonRectangle;
        ButtonState prevState = ButtonState.Released;
        private SpriteFont font;
        private SpriteFont scoreFont;

        private List<Player> players;

        public ScoreboardScreen(Game1 game)
        {
            players = loadPlayers();

            players.Sort(delegate(Player x, Player y)
            {
                return x.time.CompareTo(y.time);
            });

            font = game.Content.Load<SpriteFont>("myFont");
            scoreFont = game.Content.Load<SpriteFont>("scoreFont");

            this.game = game;
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
            backgroundTexture = game.Content.Load<Texture2D>("background");

            homeButton = game.Content.Load<Texture2D>("home");
            homeButtonPosition = new Vector2(700, 400);
            homeButtonRectangle = new Rectangle((int)homeButtonPosition.X, (int)homeButtonPosition.Y, homeButton.Width, homeButton.Height);
        }
        public void Update()
        {
            

            mouseState = Mouse.GetState();

            ButtonState currState = mouseState.LeftButton;
            if (currState == ButtonState.Pressed && currState != prevState)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (homeButtonRectangle.Contains(mousePosition))
                {
                    game.quitGame();
                }

                prevState = currState;

            } if (currState == ButtonState.Released)
            {
                prevState = currState;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            
            spriteBatch.Draw(homeButton, homeButtonPosition, Color.White);

            spriteBatch.DrawString(font,"NAME", new Vector2(225, 5), Color.PeachPuff);
            spriteBatch.DrawString(font, "TIME", new Vector2(450, 5), Color.PeachPuff);

            foreach (Player p in players)
            {
                int a = players.IndexOf(p) + 2;
                spriteBatch.DrawString(scoreFont,p.name, new Vector2(225, (25 * a) ), Color.OrangeRed);
                spriteBatch.DrawString(scoreFont, p.time.ToString(), new Vector2(450, (25 * a)), Color.OrangeRed);
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
            finally
            {
                // Close the file
                
            }

            return players;
        }
    }
}

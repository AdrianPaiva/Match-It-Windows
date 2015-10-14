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
/**************************************************
* Adrian Paiva
* 100864588
* created: 10/20/2014
* lastEdit: 11/1/2014
**************************************************/
namespace MatchIt
{
    class StartScreen
    {
        private Texture2D backgroundTexture;
        private Game1 game;

        int screenWidth;
        int screenHeight;

        private Texture2D startButton;
        private Texture2D scoreboardButton;

        private Vector2 startButtonPosition;
        private Vector2 scoreboardButtonPosition;

        private MouseState mouseState;
        private Point mousePosition;

        private Rectangle startButtonRectangle;
        private Rectangle scoreboardButtonRectangle;

        ButtonState prevState = ButtonState.Released;

        public StartScreen(Game1 game)
        {
            this.game = game;
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;

            backgroundTexture = game.Content.Load<Texture2D>("background");

            startButton = game.Content.Load<Texture2D>("startButton");
            startButtonPosition = new Vector2((screenWidth / 2)- 100, 100);

            scoreboardButton = game.Content.Load<Texture2D>("scoreboard");
            scoreboardButtonPosition = new Vector2((screenWidth / 2) - 100, 200);

            startButtonRectangle = new Rectangle((int)startButtonPosition.X, (int)startButtonPosition.Y, startButton.Width, startButton.Height);
            scoreboardButtonRectangle = new Rectangle((int)scoreboardButtonPosition.X, (int)scoreboardButtonPosition.Y, scoreboardButton.Width, scoreboardButton.Height);
            
            
        }
        public void Update()
        {
            /*
            

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mousePosition = new Point(mouseState.X,mouseState.Y);              

                if (startButtonRectangle.Contains(mousePosition))
                {
                    game.startGame();
                }
                else if(scoreboardButtonRectangle.Contains(mousePosition))
                {
                    game.startScoreBoard();
                }
                
            }
            */
            
            
            mouseState = Mouse.GetState();

            ButtonState currState = mouseState.LeftButton;
            if (currState == ButtonState.Pressed && currState != prevState)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);

                if (startButtonRectangle.Contains(mousePosition))
                {
                    game.startGame();
                }
                else if (scoreboardButtonRectangle.Contains(mousePosition))
                {
                    game.startScoreBoard();
                }
                prevState = currState;

            } if (currState == ButtonState.Released)
            {
                prevState = currState;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (backgroundTexture != null)
            {
                Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
                spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            }
            spriteBatch.Draw(startButton, startButtonPosition, Color.White);
            spriteBatch.Draw(scoreboardButton, scoreboardButtonPosition, Color.White);
                
        }
    }
}

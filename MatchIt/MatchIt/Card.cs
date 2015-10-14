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
    class Card
    {
        private Texture2D image;
        private Texture2D backImage;
        
        private Boolean flipped;
        private int pairId;
        private Rectangle rect;
        private Boolean visible;

        public Card(Texture2D image, int pairId)
        {
            this.image = image;
            this.pairId = pairId;
            visible = true;
            flipped = false;
        }

        public Texture2D getImage()
        {
            return image;
        }

        public void setImage(Texture2D image)
        {
            this.image = image;

        }

        public Boolean isFlipped()
        {
            return flipped;
        }

        public void setFlipped(Boolean flipped)
        {
            this.flipped = flipped;

        }

        public int getPairId()
        {
            return pairId;
        }

        public void setPairId(int pairId)
        {
            this.pairId = pairId;

        }
        public void flip()
        {
            if (isFlipped())
            {
                flipped = false;
            }
            else if (!isFlipped())
            {
                flipped = true;

            }
        }
        public Rectangle getRect()
        {
            return rect;
        }
        public void setRect(Rectangle rect)
        {
            this.rect = rect;
        }
        public Boolean isVisible()
        {
            return visible;
        }
        public void setVisible(Boolean visible)
        {
            this.visible = visible;
        }


    }
}

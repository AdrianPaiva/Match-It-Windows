using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**************************************************
* Adrian Paiva
* 100864588
* created: 10/20/2014
* lastEdit: 11/1/2014
**************************************************/
namespace MatchIt
{
    [Serializable]
    public class Player
    {
        public string name;
        public float time;

        public Player()
        {

        }
        public Player(string name, float time)
        {
            this.name = name;
            this.time = time;
        }
        /*
        public string getName()
        {
            return name;
        }
        public float getTime()
        {
            return time;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setTime(float time)
        {
            this.time = time;
        }
         * */
    }
}

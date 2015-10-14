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
    class Pair
    {
        private Card first;
        private Card second;

        public Pair(Card first, Card second)
        {
            this.first = first;
            this.second = second;
        }
        public Card getFirst()
        {
            return first;
        }

        public void setFirst(Card first)
        {
            this.first = first;
        }

        public Card getSecond()
        {
            return second;
        }

        public void setSecond(Card second)
        {
            this.second = second;
        }

    }
}

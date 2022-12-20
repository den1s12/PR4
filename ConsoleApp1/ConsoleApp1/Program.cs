using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Baseship
    {
        private int counter;
        protected int speed;
        public string Move(int distance)
        {
            counter++;
            string result = string.Format("Пройдено км:{0}", distance);
            return result;
        }
    }
    public class TransportShip : Baseship
    {
        public void Start()
        {

        }
    }
}

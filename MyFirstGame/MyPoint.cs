using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class MyPoint
    {
        string point = "*";
        public int _x, _y;
        public List<Tuple<int, int>> locationsOfThePoint = new List<Tuple<int, int>>();

        public MyPoint(){}

        public MyPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void PrintPoint()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }

        public bool IsPointHasBeenThereAlready(int x, int y)
        {
            Tuple<int, int> currentLocation = new Tuple<int, int>(x, y);
            for (int i = 0; i < locationsOfThePoint.Count; i++)
            {
                if(locationsOfThePoint[i].Equals(currentLocation))
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangBackgroundColor(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }

        public void MoveRight()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            _x++;
            if (_x >= 80) { throw new ArgumentOutOfRangeException(); }
            locationsOfThePoint.Add(new Tuple<int, int>(_x, _y));
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }

        public void MoveLeft()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            _x--;
            locationsOfThePoint.Add(new Tuple<int, int>(_x, _y));
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }

        public void MoveForward()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            _y--;
            locationsOfThePoint.Add(new Tuple<int, int>(_x, _y));
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }

        public void MoveBackward()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            _y++;
            if (_y >= 25) { throw new ArgumentOutOfRangeException(); }
            locationsOfThePoint.Add(new Tuple<int, int>(_x, _y));
            Console.SetCursorPosition(_x, _y);
            Console.Write(point);
        }



    }
}

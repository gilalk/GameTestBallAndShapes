using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    interface IShape
    {
        public void Draw();
        public bool IsCellOccupied(int x, int y);
    }

    class Line : IShape
    {
        private int _x, _y, _length;
        private static string myLine = "=";

        public Line(int x, int y, int length)
        {
            _x = x;
            _y = y;
            _length = length;
        }

        public void Draw()
        {
            for (int i = 0; i < _length; i++)
            {
                Console.SetCursorPosition(_x + i, _y);
                Console.Write(myLine);
            }
        }

        public bool IsCellOccupied(int x, int y)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_x + i == x && _y == y)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Square : IShape
    {
        private int _x, _y, _size;
        private static string mySquare = "ם";

        public Square(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
        }
        public void Draw()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.SetCursorPosition(_x + j, _y + i);
                    Console.Write(mySquare);
                }
            }
        }

        public bool IsCellOccupied(int x, int y)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if(_x + j == x && _y + i == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }



    class Triangle : IShape
    {
        private int _x, _y, _size;
        private static string myTriangle = "#";

        public Triangle(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
        }

        public void Draw()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.SetCursorPosition(_x + j, _y + i);
                    Console.Write(myTriangle);
                }
            }
        }

        public bool IsCellOccupied(int x, int y)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (_x + j == x && _y + i == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class Rectangle : IShape
    {
        private int _x, _y, _length, _width;
        private string myRectangle = "ם";

        public Rectangle(int x, int y, int length, int width)
        {
            _x = x;
            _y = y;
            _length = length;
            _width = width;
        }

        public void Draw()
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.SetCursorPosition(_x + j, _y + i);
                    Console.Write(myRectangle);
                }
            }
        }

        public bool IsCellOccupied(int x, int y)
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if(_x + j == x && _y + i == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

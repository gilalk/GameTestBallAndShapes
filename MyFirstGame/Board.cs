using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Board
    {
        List<IShape> _shapes;
        MyPoint _ball;
        Random rnd;
        int _height, _width;
        ConsoleKeyInfo key;
        public int tries = 0;

        enum ShapesNames
        {
            Line,
            Square,
            Rectangle,
            Triangle
        }


        public Board(int width, int height)
        {
            _shapes = new List<IShape>();
            _ball = new MyPoint();
            rnd = new Random();
            _height = height;
            _width = width;
            Console.SetWindowSize(width, height);
        }

        public void ClearBoard()
        {
            _shapes.Clear();
            _ball = null;
        }

        public bool CheckPositionForTheShape(int x, int y, int length, int width)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                for (int j = x; j < x + length; j++)
                {
                    for (int h = y; h < y + width; h++)
                    {
                        if (_shapes[i].IsCellOccupied(j, h))
                        {
                            tries++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void PrintShapes(int numOfShapes)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < numOfShapes; i++)
            {
                int shapeNum = rnd.Next(4);
                switch (shapeNum)
                {
                    case (int)ShapesNames.Square:
                        int size = rnd.Next(3, 11);
                        int x = rnd.Next(_width - size);
                        int y = rnd.Next(_height - size);
                        if (!CheckPositionForTheShape(x, y, size, size) && tries < 20)
                        {
                            _shapes.Add(new Square(x, y, size));
                        }
                        else if (tries == 20)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case (int)ShapesNames.Triangle:
                        int size1 = rnd.Next(3, 10);
                        int x1 = rnd.Next(_width - size1);
                        int y1 = rnd.Next(_height - size1);
                        if (!CheckPositionForTheShape(x1, y1, size1, size1) && tries < 20)
                        {
                            _shapes.Add(new Triangle(x1, y1, size1));
                        }
                        else if (tries == 20)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case (int)ShapesNames.Rectangle:
                        int length = rnd.Next(3, 11);
                        int width = rnd.Next(3, 11);
                        int x2 = rnd.Next(_width - width);
                        int y2 = rnd.Next(_height - length);
                        if (!CheckPositionForTheShape(x2, y2, length, width) && tries < 20)
                        {
                            _shapes.Add(new Rectangle(x2, y2, length, width));
                        }
                        else if (tries == 20)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case (int)ShapesNames.Line:
                        int length1 = rnd.Next(3, 11);
                        int x3 = rnd.Next(_width - length1);
                        int y3 = rnd.Next(_height - 1);
                        if (!CheckPositionForTheShape(x3, y3, length1, length1) && tries < 20)
                        {
                            _shapes.Add(new Line(x3, y3, length1));
                        }
                        else if (tries == 20)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < _shapes.Count; i++)
            {
                _shapes[i].Draw();
            }
            tries = 0;
        }

        public void PrintPoint()
        {
            bool success = true;
            while (true)
            {
                int x = rnd.Next(_width);
                int y = rnd.Next(_height);

                for (int i = 0; i < _shapes.Count; i++)
                {
                    if (_shapes[i].IsCellOccupied(x, y))
                    {
                        success = false;
                        break;
                    }
                }
                if (success)
                {
                    _ball = new MyPoint(x, y);
                    _ball.locationsOfThePoint.Add(new Tuple<int, int>(x, y));
                    break;
                }
                else
                {
                    success = true;
                }
            }

            _ball.PrintPoint();
        }

        public bool CheckIfNextCellIsOccupied(int x, int y)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsCellOccupied(x, y) || _ball.IsPointHasBeenThereAlready(x, y))
                {
                    return true;
                }
            }
            return false;
        }

        public void MovePoint()
        {
            try
            {
                Console.CursorVisible = false;
                key = Console.ReadKey(true);
                int x = (_ball._x);
                int y = (_ball._y);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CheckIfNextCellIsOccupied(x, y - 1))
                        {
                            _ball.locationsOfThePoint.Clear();
                            throw new ArgumentOutOfRangeException();
                        }
                        _ball.ChangBackgroundColor(x, y);
                        _ball.MoveForward();
                        break;
                    case ConsoleKey.DownArrow:
                        if (CheckIfNextCellIsOccupied(x, y + 1))
                        {
                            _ball.locationsOfThePoint.Clear();
                            throw new ArgumentOutOfRangeException();
                        }
                        _ball.ChangBackgroundColor(x, y);
                        _ball.MoveBackward();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (CheckIfNextCellIsOccupied(x - 1, y))
                        {
                            _ball.locationsOfThePoint.Clear();
                            throw new ArgumentOutOfRangeException();
                        }
                        _ball.ChangBackgroundColor(x, y);
                        _ball.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        if (CheckIfNextCellIsOccupied(x + 1, y))
                        {
                            _ball.locationsOfThePoint.Clear();
                            throw new ArgumentOutOfRangeException();
                        }
                        _ball.ChangBackgroundColor(x, y);
                        _ball.MoveRight();
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

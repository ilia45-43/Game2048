using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2048
{
    class Game2048
    {
        public static void MoveLeft() // Функция передвижения влево
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[i, j] == 0)
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j + 1];
                        Game1.gameBoard[i, j + 1] = 0;
                    }
                }
            }

            SumLeft();
        }

        private static void SumLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[i, j] == Game1.gameBoard[i, j + 1])
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j] + Game1.gameBoard[i, j + 1];
                        Game1.gameBoard[i, j + 1] = 0;
                        break;
                    }
                }
            }
        } // Складывает элементы при перемещении влево

        public static void MoveRight() // Функция передвижения вправо
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[i, j + 1] == 0)
                    {
                        Game1.gameBoard[i, j + 1] = Game1.gameBoard[i, j];
                        Game1.gameBoard[i, j] = 0;
                    }
                }
            }

            SumRight();
        }

        private static void SumRight()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[i, j + 1] == Game1.gameBoard[i, j])
                    {
                        Game1.gameBoard[i, j + 1] = Game1.gameBoard[i, j + 1] + Game1.gameBoard[i, j];
                        Game1.gameBoard[i, j] = 0;
                        break;
                    }
                }
            }
        } // Складывает элементы при перемещении вправо

        public static void MoveUp() // Функция передвижения вверх
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game1.gameBoard[i, j] == 0)
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i + 1, j];
                        Game1.gameBoard[i + 1, j] = 0;
                    }
                }
            }

            SumUp();
        }

        private static void SumUp()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game1.gameBoard[i, j] == Game1.gameBoard[i + 1, j])
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j] + Game1.gameBoard[i + 1, j];
                        Game1.gameBoard[i + 1, j] = 0;
                        break;
                    }
                }
            }
        } // Складывает элементы при перемещении вверх

        public static void MoveDown() // Функция передвижения вниз
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game1.gameBoard[i + 1, j] == 0)
                    {
                        Game1.gameBoard[i + 1, j] = Game1.gameBoard[i, j];
                        Game1.gameBoard[i, j] = 0;
                    }
                }
            }

            SumDowm();
        }

        private static void SumDowm()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game1.gameBoard[i, j] == Game1.gameBoard[i + 1, j])
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j] + Game1.gameBoard[i + 1, j];
                        Game1.gameBoard[i + 1, j] = 0;
                        break;
                    }
                }
            }
        } // Складывает элементы при перемещении вниз
    }
}

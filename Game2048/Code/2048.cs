using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2048
{
    class Game2048
    {
        static bool checkNewStep = false;

        public static void MoveLeft() // Функция передвижения влево
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                        if (Game1.gameBoard[i, j] == 0)
                        {
                            Game1.gameBoard[i, j] = Game1.gameBoard[i, j + 1];
                            Game1.gameBoard[i, j + 1] = 0;
                            checkNewStep = true;
                        }
        }

        public static void SumLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[i, j + 1] == Game1.gameBoard[i, j])
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j] + Game1.gameBoard[i, j + 1];
                        Game1.gameBoard[i, j + 1] = 0;
                        checkNewStep = true;
                    }
                }
            }
        } // Складывает элементы при перемещении влево

        public static void MoveRight() // Функция передвижения вправо
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                        if (Game1.gameBoard[i, j + 1] == 0)
                        {
                            Game1.gameBoard[i, j + 1] = Game1.gameBoard[i, j];
                            Game1.gameBoard[i, j] = 0;
                            checkNewStep = true;
                        }
        }

        public static void SumRight()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (Game1.gameBoard[i, j - 1] == Game1.gameBoard[i, j])
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j - 1] + Game1.gameBoard[i, j];
                        Game1.gameBoard[i, j - 1] = 0;
                        checkNewStep = true;
                    }
                }
            }
        } // Складывает элементы при перемещении вправо

        public static void MoveUp() // Функция передвижения вверх
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                        if (Game1.gameBoard[i, j] == 0)
                        {
                            Game1.gameBoard[i, j] = Game1.gameBoard[i + 1, j];
                            Game1.gameBoard[i + 1, j] = 0;
                            checkNewStep = true;
                        }
        }

        public static void SumUp()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game1.gameBoard[j, i] == Game1.gameBoard[j + 1, i])
                    {
                        Game1.gameBoard[j, i] = Game1.gameBoard[j, i] + Game1.gameBoard[j + 1, i];
                        Game1.gameBoard[j + 1, i] = 0;
                        checkNewStep = true;
                    }
                }
            }
        } // Складывает элементы при перемещении вверх

        public static void MoveDown() // Функция передвижения вниз
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                        if (Game1.gameBoard[i + 1, j] == 0)
                        {
                            Game1.gameBoard[i + 1, j] = Game1.gameBoard[i, j];
                            Game1.gameBoard[i, j] = 0;
                            checkNewStep = true;
                        }
        }

        public static void SumDown()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (Game1.gameBoard[j, i] == Game1.gameBoard[j - 1, i])
                    {
                        Game1.gameBoard[j, i] = Game1.gameBoard[j, i] + Game1.gameBoard[j - 1, i];
                        Game1.gameBoard[j - 1, i] = 0;
                        checkNewStep = true;
                    }
                }
            }
        } // Складывает элементы при перемещении вниз

        public static void NewNumber()
        {
            if (checkNewStep)
            {
                Random rand = new Random();

                List<int> spaceI = new List<int>();
                List<int> spaceJ = new List<int>();

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (Game1.gameBoard[i, j] == 0)
                        {
                            spaceI.Add(i);
                            spaceJ.Add(j);
                        }

                int randomPlace = rand.Next(0, spaceI.Count);

                Game1.gameBoard[spaceI[randomPlace], spaceJ[randomPlace]] = 2;

                checkNewStep = false;
            }
        }
    }
}

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

        public static void CountingScore(int number)
        {
            Game1.score += number;
        }

        public static bool CheckEndGame()
        {
            int[,] copyGameBoard = new int[4, 4];

            Array.Copy(Game1.gameBoard, 0, copyGameBoard, 0, 16);

            if ((MoveDown(copyGameBoard) && MoveUp(copyGameBoard) && MoveLeft(copyGameBoard) && MoveRight(copyGameBoard)
                && SumDown(copyGameBoard) && SumUp(copyGameBoard) && SumLeft(copyGameBoard) && SumRight(copyGameBoard)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MoveLeft() // Функция передвижения влево
        {
            for (int u = 0; u < 4; u++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((Game1.gameBoard[i, j] == 0) && (Game1.gameBoard[i, j + 1] != 0))
                        {
                            Game1.gameBoard[i, j] = Game1.gameBoard[i, j + 1];
                            Game1.gameBoard[i, j + 1] = 0;
                            checkNewStep = true;
                        }
                    }
                }
            }
        }

        public static void SumLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Game1.gameBoard[i, j + 1] == Game1.gameBoard[i, j]) && (Game1.gameBoard[i, j] != 0))
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j] + Game1.gameBoard[i, j + 1];
                        Game1.gameBoard[i, j + 1] = 0;
                        checkNewStep = true;
                        CountingScore(Game1.gameBoard[i, j]);
                    }
                }
            }
        }

        public static void MoveRight() // Функция передвижения вправо
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if ((Game1.gameBoard[i, j + 1] == 0) && (Game1.gameBoard[i, j] != 0))
                        {
                            Game1.gameBoard[i, j + 1] = Game1.gameBoard[i, j];
                            Game1.gameBoard[i, j] = 0;
                            checkNewStep = true;

                        }
                    }
        }

        public static void SumRight()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if ((Game1.gameBoard[i, j - 1] == Game1.gameBoard[i, j]) && (Game1.gameBoard[i, j] != 0))
                    {
                        Game1.gameBoard[i, j] = Game1.gameBoard[i, j - 1] + Game1.gameBoard[i, j];
                        Game1.gameBoard[i, j - 1] = 0;
                        checkNewStep = true;
                        CountingScore(Game1.gameBoard[i, j]);
                    }
                }
            }
        }

        public static void MoveUp()
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((Game1.gameBoard[i, j] == 0) && (Game1.gameBoard[i + 1, j] != 0))
                        {
                            Game1.gameBoard[i, j] = Game1.gameBoard[i + 1, j];
                            Game1.gameBoard[i + 1, j] = 0;
                            checkNewStep = true;
                        }
                    }
        }

        public static void SumUp()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Game1.gameBoard[j, i] == Game1.gameBoard[j + 1, i]) && (Game1.gameBoard[j, i] != 0))
                    {
                        Game1.gameBoard[j, i] = Game1.gameBoard[j, i] + Game1.gameBoard[j + 1, i];
                        Game1.gameBoard[j + 1, i] = 0;
                        checkNewStep = true;
                        CountingScore(Game1.gameBoard[j, i]);
                    }
                }
            }
        }

        public static void MoveDown() // Функция передвижения вниз
        {
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((Game1.gameBoard[i + 1, j] == 0) && (Game1.gameBoard[i, j] != 0))
                        {
                            Game1.gameBoard[i + 1, j] = Game1.gameBoard[i, j];
                            Game1.gameBoard[i, j] = 0;
                            checkNewStep = true;
                        }
                    }
        }

        public static void SumDown()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if ((Game1.gameBoard[j, i] == Game1.gameBoard[j - 1, i]) && (Game1.gameBoard[j, i] != 0))
                    {
                        Game1.gameBoard[j, i] = Game1.gameBoard[j, i] + Game1.gameBoard[j - 1, i];
                        Game1.gameBoard[j - 1, i] = 0;
                        checkNewStep = true;
                        CountingScore(Game1.gameBoard[j, i]);
                    }
                }
            }
        }

        

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

                int chanceForFour = rand.Next(0,100);

                Game1.gameBoard[spaceI[randomPlace], spaceJ[randomPlace]] = chanceForFour <= 10 ? 4 : 2;

                checkNewStep = false;
                spaceI.Clear();
                spaceJ.Clear();
            }

        }

        public static bool MoveLeft(int[,] mas)
        {
            bool checkStep = false;
            for (int u = 0; u < 4; u++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((mas[i, j] == 0) && (mas[i, j + 1] != 0))
                        {
                            mas[i, j] = mas[i, j + 1];
                            mas[i, j + 1] = 0;
                            checkStep = true;
                        }
                    }
                }
            }
            return checkStep;
        }

        public static bool SumDown(int[,] mas)
        {
            bool checkStep = false;
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if ((mas[j, i] == mas[j - 1, i]) && (mas[j, i] != 0))
                    {
                        mas[j, i] = mas[j, i] + mas[j - 1, i];
                        mas[j - 1, i] = 0;
                        checkStep = true;
                    }
                }
            }
            return checkStep;
        }

        public static bool MoveDown(int[,] mas)
        {
            bool checkStep = false;
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((mas[i + 1, j] == 0) && (mas[i, j] != 0))
                        {
                            mas[i + 1, j] = mas[i, j];
                            mas[i, j] = 0;
                            checkStep = true;
                        }
                    }
            return checkStep;
        }

        public static bool SumUp(int[,] mas)
        {
            bool checkStep = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((mas[j, i] == mas[j + 1, i]) && (mas[j, i] != 0))
                    {
                        mas[j, i] = mas[j, i] + mas[j + 1, i];
                        mas[j + 1, i] = 0;
                        checkStep = true;
                    }
                }
            }
            return checkStep;
        }

        public static bool MoveUp(int[,] mas)
        {
            bool checkStep = false;
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((mas[i, j] == 0) && (mas[i + 1, j] != 0))
                        {
                            mas[i, j] = mas[i + 1, j];
                            mas[i + 1, j] = 0;
                            checkStep = true;
                        }
                    }
            return checkStep;
        }

        public static bool SumRight(int[,] mas)
        {
            bool checkStep = false;
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if ((mas[i, j - 1] == mas[i, j]) && (mas[i, j] != 0))
                    {
                        mas[i, j] = mas[i, j - 1] + mas[i, j];
                        mas[i, j - 1] = 0;
                        checkStep = true;
                    }
                }
            }
            return checkStep;
        }

        public static bool MoveRight(int[,] mas)
        {
            bool checkStep = false;
            for (int u = 0; u < 4; u++)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if ((mas[i, j + 1] == 0) && (mas[i, j] != 0))
                        {
                            mas[i, j + 1] = mas[i, j];
                            mas[i, j] = 0;
                            checkStep = true;

                        }
                    }
            return checkStep;
        }

        public static bool SumLeft(int[,] mas)
        {
            bool checkStep = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((mas[i, j + 1] == mas[i, j]) && (mas[i, j] != 0))
                    {
                        mas[i, j] = mas[i, j] + mas[i, j + 1];
                        mas[i, j + 1] = 0;
                        checkStep = true;
                    }
                }
            }
            return checkStep;
        }

    }
}

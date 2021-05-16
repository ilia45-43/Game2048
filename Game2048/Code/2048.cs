using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game2048
{
    public class Game2048 : Game1
    {
        static bool checkNewStep = false;

        public static List<int[,]> savedSteps = new List<int[,]>();
        public static List<int> savedScore = new List<int>();

        private static Vector2 start = new Vector2(50, 50); // Просто начальный вектор от которого будут отталкиваться остальные векторы

        public static void CountingScore(int number)
        {
            score += number;
        }

        public static void MakingPositions()
        {
            for (int i = 0; i < 4; i++) // Тут формируются места для наших иконок, для каждого значения свое место, 
                                        // То есть это просто векторы
            {
                for (int j = 0; j < 4; j++)
                {
                    positions[i, j] = new Vector2(start.X + (120 * j), start.Y + (120 * i));
                }
            }
        }

        public static void DrawingNumbers()
        {
            for (int i = 0; i < 4; i++) // Ниже 2 цикла которые проверяют, есть ли какие то цифры на игровой доске,
                                        // если нет ничего, если есть => отрисовывают цифру которая есть в базе
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameBoard[i, j] == 2)
                    {
                        _spriteBatch.Draw(texture_2, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 4)
                    {
                        _spriteBatch.Draw(texture_4, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 8)
                    {
                        _spriteBatch.Draw(texture_8, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 16)
                    {
                        _spriteBatch.Draw(texture_16, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 32)
                    {
                        _spriteBatch.Draw(texture_32, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 64)
                    {
                        _spriteBatch.Draw(texture_64, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 128)
                    {
                        _spriteBatch.Draw(texture_128, positions[i, j], Color.White);
                    }
                    else if (gameBoard[i, j] == 2048)
                    {
                        _spriteBatch.Draw(texture_2048, positions[i, j], Color.White);
                    }
                }
            }
        }

        public static void DrawingScoreText()
        {
            Vector2 position = new Microsoft.Xna.Framework.Vector2(_graphics.PreferredBackBufferWidth - 200, _graphics.PreferredBackBufferHeight - 100); // position
            Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 255);// color yellow
            _spriteBatch.DrawString(textForScore, score.ToString(), position, color); // draw text
        }

        //public static bool CheckEndGame()
        //{
        //    int[,] copyGameBoard = new int[4, 4];

        //    Array.Copy(gameBoard, 0, copyGameBoard, 0, 16);

        //    if ((MoveDown(copyGameBoard) && MoveUp(copyGameBoard) && MoveLeft(copyGameBoard) && MoveRight(copyGameBoard)
        //        && SumDown(copyGameBoard) && SumUp(copyGameBoard) && SumLeft(copyGameBoard) && SumRight(copyGameBoard)) == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static void MoveLeft() // Функция передвижения влево
        {
            for (int u = 0; u < 4; u++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((gameBoard[i, j] == 0) && (gameBoard[i, j + 1] != 0))
                        {
                            gameBoard[i, j] = gameBoard[i, j + 1];
                            gameBoard[i, j + 1] = 0;
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
                    if ((gameBoard[i, j + 1] == gameBoard[i, j]) && (gameBoard[i, j] != 0))
                    {
                        gameBoard[i, j] = gameBoard[i, j] + gameBoard[i, j + 1];
                        gameBoard[i, j + 1] = 0;
                        checkNewStep = true;
                        CountingScore(gameBoard[i, j]);
                        SavePreviousStep(gameBoard[i, j]);
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
                        if ((gameBoard[i, j + 1] == 0) && (gameBoard[i, j] != 0))
                        {
                            gameBoard[i, j + 1] = gameBoard[i, j];
                            gameBoard[i, j] = 0;
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
                    if ((gameBoard[i, j - 1] == gameBoard[i, j]) && (gameBoard[i, j] != 0))
                    {
                        gameBoard[i, j] = gameBoard[i, j - 1] + gameBoard[i, j];
                        gameBoard[i, j - 1] = 0;
                        checkNewStep = true;
                        CountingScore(gameBoard[i, j]);
                        SavePreviousStep(gameBoard[i, j]);
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
                        if ((gameBoard[i, j] == 0) && (gameBoard[i + 1, j] != 0))
                        {
                            gameBoard[i, j] = gameBoard[i + 1, j];
                            gameBoard[i + 1, j] = 0;
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
                    if ((gameBoard[j, i] == gameBoard[j + 1, i]) && (gameBoard[j, i] != 0))
                    {
                        gameBoard[j, i] = gameBoard[j, i] + gameBoard[j + 1, i];
                        gameBoard[j + 1, i] = 0;
                        checkNewStep = true;
                        CountingScore(gameBoard[j, i]);
                        SavePreviousStep(gameBoard[j, i]);
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
                        if ((gameBoard[i + 1, j] == 0) && (gameBoard[i, j] != 0))
                        {
                            gameBoard[i + 1, j] = gameBoard[i, j];
                            gameBoard[i, j] = 0;
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
                    if ((gameBoard[j, i] == gameBoard[j - 1, i]) && (gameBoard[j, i] != 0))
                    {
                        gameBoard[j, i] = gameBoard[j, i] + gameBoard[j - 1, i];
                        gameBoard[j - 1, i] = 0;
                        checkNewStep = true;
                        CountingScore(gameBoard[j, i]);
                        SavePreviousStep(gameBoard[j, i]);
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
                        if (gameBoard[i, j] == 0)
                        {
                            spaceI.Add(i);
                            spaceJ.Add(j);
                        }

                int randomPlace = rand.Next(0, spaceI.Count);

                int chanceForFour = rand.Next(0,100);

                gameBoard[spaceI[randomPlace], spaceJ[randomPlace]] = chanceForFour <= 10 ? 4 : 2;

                checkNewStep = false;
                spaceI.Clear();
                spaceJ.Clear();

            }
        }

        public static void MoveBack()
        {
            Array.Copy(savedSteps[savedSteps.Count - 2], gameBoard, 16);
            score -= savedScore[savedScore.Count - 1];

            savedSteps.RemoveAt(savedSteps.Count - 1);
            savedScore.RemoveAt(savedScore.Count - 1);
        }

        public static void SavePreviousStep(int scoreMinus)
        {
            int[,] newMas = new int[4, 4];

            Array.Copy(gameBoard, newMas, 16);

            //if((savedScore.Count - 1) == 0)
            //{
            //    savedScore.RemoveAt(savedScore.Count - 1);
            //}

            savedSteps.Add(newMas);
            savedScore.Add(scoreMinus);
        }


        //public static bool MoveLeft(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int u = 0; u < 4; u++)
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if ((mas[i, j] == 0) && (mas[i, j + 1] != 0))
        //                {
        //                    mas[i, j] = mas[i, j + 1];
        //                    mas[i, j + 1] = 0;
        //                    checkStep = true;
        //                }
        //            }
        //        }
        //    }
        //    return checkStep;
        //}

        //public static bool SumDown(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int i = 3; i >= 0; i--)
        //    {
        //        for (int j = 3; j > 0; j--)
        //        {
        //            if ((mas[j, i] == mas[j - 1, i]) && (mas[j, i] != 0))
        //            {
        //                mas[j, i] = mas[j, i] + mas[j - 1, i];
        //                mas[j - 1, i] = 0;
        //                checkStep = true;
        //            }
        //        }
        //    }
        //    return checkStep;
        //}

        //public static bool MoveDown(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int u = 0; u < 4; u++)
        //        for (int i = 0; i < 3; i++)
        //            for (int j = 0; j < 4; j++)
        //            {
        //                if ((mas[i + 1, j] == 0) && (mas[i, j] != 0))
        //                {
        //                    mas[i + 1, j] = mas[i, j];
        //                    mas[i, j] = 0;
        //                    checkStep = true;
        //                }
        //            }
        //    return checkStep;
        //}

        //public static bool SumUp(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if ((mas[j, i] == mas[j + 1, i]) && (mas[j, i] != 0))
        //            {
        //                mas[j, i] = mas[j, i] + mas[j + 1, i];
        //                mas[j + 1, i] = 0;
        //                checkStep = true;
        //            }
        //        }
        //    }
        //    return checkStep;
        //}

        //public static bool MoveUp(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int u = 0; u < 4; u++)
        //        for (int i = 0; i < 3; i++)
        //            for (int j = 0; j < 4; j++)
        //            {
        //                if ((mas[i, j] == 0) && (mas[i + 1, j] != 0))
        //                {
        //                    mas[i, j] = mas[i + 1, j];
        //                    mas[i + 1, j] = 0;
        //                    checkStep = true;
        //                }
        //            }
        //    return checkStep;
        //}

        //public static bool SumRight(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int i = 3; i >= 0; i--)
        //    {
        //        for (int j = 3; j > 0; j--)
        //        {
        //            if ((mas[i, j - 1] == mas[i, j]) && (mas[i, j] != 0))
        //            {
        //                mas[i, j] = mas[i, j - 1] + mas[i, j];
        //                mas[i, j - 1] = 0;
        //                checkStep = true;
        //            }
        //        }
        //    }
        //    return checkStep;
        //}

        //public static bool MoveRight(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int u = 0; u < 4; u++)
        //        for (int i = 0; i < 4; i++)
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if ((mas[i, j + 1] == 0) && (mas[i, j] != 0))
        //                {
        //                    mas[i, j + 1] = mas[i, j];
        //                    mas[i, j] = 0;
        //                    checkStep = true;

        //                }
        //            }
        //    return checkStep;
        //}

        //public static bool SumLeft(int[,] mas)
        //{
        //    bool checkStep = false;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if ((mas[i, j + 1] == mas[i, j]) && (mas[i, j] != 0))
        //            {
        //                mas[i, j] = mas[i, j] + mas[i, j + 1];
        //                mas[i, j + 1] = 0;
        //                checkStep = true;
        //            }
        //        }
        //    }
        //    return checkStep;
        //}

    }
}

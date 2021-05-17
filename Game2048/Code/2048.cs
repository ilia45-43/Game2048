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

        private static Vector2 start = new Vector2(86, 110);

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
                    if(gameBoard[i,j] == 0)
                    {
                        _spriteBatch.Draw(texture_0, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 2)
                    {
                        _spriteBatch.Draw(texture_2, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 4)
                    {
                        _spriteBatch.Draw(texture_4, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 8)
                    {
                        _spriteBatch.Draw(texture_8, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 16)
                    {
                        _spriteBatch.Draw(texture_16, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 32)
                    {
                        _spriteBatch.Draw(texture_32, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 64)
                    {
                        _spriteBatch.Draw(texture_64, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 128)
                    {
                        _spriteBatch.Draw(texture_128, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 256)
                    {
                        _spriteBatch.Draw(texture_256, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 512)
                    {
                        _spriteBatch.Draw(texture_512, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 1024)
                    {
                        _spriteBatch.Draw(texture_1024, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 2048)
                    {
                        _spriteBatch.Draw(texture_2048, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 4096)
                    {
                        _spriteBatch.Draw(texture_4096, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 8192)
                    {
                        _spriteBatch.Draw(texture_8192, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 16384)
                    {
                        _spriteBatch.Draw(texture_16384, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 32768)
                    {
                        _spriteBatch.Draw(texture_32768, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 65536)
                    {
                        _spriteBatch.Draw(texture_65536, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                    else if (gameBoard[i, j] == 131072)
                    {
                        _spriteBatch.Draw(texture_131072, new Rectangle((int)positions[i, j].X, (int)positions[i, j].Y, 108, 108), Color.White);
                    }
                }
            }
        }

        public static void DrawingScoreText()
        {
            Vector2 position = new Microsoft.Xna.Framework.Vector2(_graphics.PreferredBackBufferWidth - 135, _graphics.PreferredBackBufferHeight - 620); // position
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

        public static int[,] NewNumber(int[,] newMas)
        {
            Random rand = new Random();

            List<int> spaceI = new List<int>();
            List<int> spaceJ = new List<int>();

            int[,] mas = new int[4, 4];
            Array.Copy(newMas, mas, 16);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mas[i, j] == 0)
                    {
                        spaceI.Add(i);
                        spaceJ.Add(j);
                    }

            int randomPlace = rand.Next(0, spaceI.Count);
            int chanceForFour = rand.Next(0, 100);

            mas[spaceI[randomPlace], spaceJ[randomPlace]] = chanceForFour <= 10 ? 4 : 2;

            spaceI.Clear();
            spaceJ.Clear();

            return mas;
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

            savedSteps.Add(newMas);
            savedScore.Add(scoreMinus);

            if (savedSteps.Count >= 10)
            {
                savedSteps.RemoveAt(0);
                savedScore.RemoveAt(0);
            }
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

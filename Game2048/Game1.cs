﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2048
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture_2;
        private Texture2D texture_4;
        private Texture2D texture_8;
        private Texture2D texture_16;
        private Texture2D texture_32;
        private Texture2D texture_2048;

        static Vector2 start = new Vector2(50, 50); // Просто начальный вектор от которого будут отталкиваться остальные векторы

        Vector2[,] positions = new Vector2[4, 4] { 
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start }};

        public static int[,] gameBoard = new int[4, 4] { 
            { 2, 2, 2, 2 }, 
            { 2, 0, 0, 0 }, 
            { 0, 0, 0, 0 }, 
            { 2, 0, 4, 8 } }; // Основная доска с которой будем работать

        public bool checkKeyDown = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 50);
        }

        protected override void Initialize()
        {
            ChangingWindowSize(650, 650); // Метод который регулирует размер окна, он ниже

            base.Initialize();
        }

        /// <summary>
        /// This function changes the window size (Меняет размер окна)
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void ChangingWindowSize(int width, int height)
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = width; // Ширина
            _graphics.PreferredBackBufferHeight = height; // Высота
            _graphics.ApplyChanges();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture_2 = Content.Load<Texture2D>("2");
            texture_4 = Content.Load<Texture2D>("4");
            texture_8 = Content.Load<Texture2D>("8");
            texture_16 = Content.Load<Texture2D>("16"); // Иннициализируем пикчи циферок в память
            texture_32 = Content.Load<Texture2D>("32");
            texture_2048 = Content.Load<Texture2D>("2048");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //if (keyboardState.IsKeyDown(Keys.Left))
            //    position.X -= speed;
            //if (keyboardState.IsKeyDown(Keys.Right))
            //    position.X += speed;
            //if (keyboardState.IsKeyDown(Keys.Up))
            //    position.Y -= speed;
            //if (keyboardState.IsKeyDown(Keys.Down))
            //    position.Y += speed;

            if (!checkKeyDown)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    Game2048.MoveLeft();
                    Game2048.SumLeft();
                    Game2048.MoveLeft();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    Game2048.MoveRight();
                    Game2048.SumRight();
                    Game2048.MoveRight();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    Game2048.MoveUp();
                    Game2048.SumUp();
                    Game2048.MoveUp();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    Game2048.MoveDown();
                    Game2048.SumDown();
                    Game2048.MoveDown();
                    checkKeyDown = true;
                }
            }

            if (keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left))
            {
                checkKeyDown = false;
            }

            MakingPositions(); // Это та функция которая делает просто позиции

            base.Update(gameTime);
        }

        private void MakingPositions()
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Chocolate); // Цвет фона

            _spriteBatch.Begin(); // Начало отрисовки 

            DrawingNumbers(); // Это функция как раз таки проверяет цифры, и ставит их как надо

            _spriteBatch.End(); // Конец отрисовки

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void DrawingNumbers()
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
                    else if (gameBoard[i,j] == 2048)
                    {
                        _spriteBatch.Draw(texture_2048, positions[i, j], Color.White);
                    }
                }
            }
        }
    }
}

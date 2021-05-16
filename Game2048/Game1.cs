using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game2048
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static SpriteFont textForScore;

        public static Texture2D texture_2;
        public static Texture2D texture_4;
        public static Texture2D texture_8;
        public static Texture2D texture_16;
        public static Texture2D texture_32;
        public static Texture2D texture_64;
        public static Texture2D texture_128;
        public static Texture2D texture_2048;

        private static Vector2 start = new Vector2(50, 50); // Просто начальный вектор от которого будут отталкиваться остальные векторы

        public bool checkKeyDown = false;
        public bool boolMoveBack = true;

        public static int score = 0;

        public static int countOfBackMove = 0;

        public static Vector2[,] positions = new Vector2[4, 4] { 
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start }};

        public static int[,] gameBoard = new int[4, 4] { 
            { 0, 0, 0, 4 }, 
            { 2, 0, 0, 0 }, 
            { 2, 0, 0, 0 }, 
            { 0, 0, 0, 0 } }; // Основная доска с которой будем работать

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
            texture_64 = Content.Load<Texture2D>("64");
            texture_128 = Content.Load<Texture2D>("128");
            texture_2048 = Content.Load<Texture2D>("2048");

            textForScore = Content.Load<SpriteFont>("TextForScore");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (!checkKeyDown)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveLeft();
                    Game2048.SumLeft();
                    Game2048.MoveLeft();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveRight();
                    Game2048.SumRight();
                    Game2048.MoveRight();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveUp();
                    Game2048.SumUp();
                    Game2048.MoveUp();
                    checkKeyDown = true;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveDown();
                    Game2048.SumDown();
                    Game2048.MoveDown();
                    checkKeyDown = true;
                }
            }

            

            if (countOfBackMove <= 10)
            {
                if (boolMoveBack)
                {
                    if (keyboardState.IsKeyDown(Keys.Back))
                    {
                        Game2048.MoveBack();
                        boolMoveBack = false;
                        countOfBackMove++;
                    }
                }
            }

            if ((boolMoveBack == false) && (keyboardState.IsKeyUp(Keys.Back)))
            {
                boolMoveBack = true;
            }

            if ((checkKeyDown == true) && (keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left)))
            {
                checkKeyDown = false;
                Game2048.NewNumber();
            }

            Game2048.MakingPositions(); // Это та функция которая делает просто позиции

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Chocolate); // Цвет фона

            _spriteBatch.Begin(); // Начало отрисовки 

            Game2048.DrawingNumbers(); // Это функция как раз таки проверяет цифры, и ставит их как надо

            Game2048.DrawingScoreText();

            _spriteBatch.End(); // Конец отрисовки

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

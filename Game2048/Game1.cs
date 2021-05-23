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
        public static SpriteFont textForAnimaton;

        public static Texture2D texture_background;

        #region LoadedContent
        public static Texture2D texture_backspace;
        public static Texture2D texture_bestScore;
        public static Texture2D texture_newGame;
        public static Texture2D texture_signboard;
        public static Texture2D texture_scoreFrame;
        public static Texture2D texture_0;
        public static Texture2D texture_2;
        public static Texture2D texture_4;
        public static Texture2D texture_8;
        public static Texture2D texture_16;
        public static Texture2D texture_32;
        public static Texture2D texture_64;
        public static Texture2D texture_128;
        public static Texture2D texture_256;
        public static Texture2D texture_512;
        public static Texture2D texture_1024;
        public static Texture2D texture_2048;
        public static Texture2D texture_4096;
        public static Texture2D texture_8192;
        public static Texture2D texture_16384;
        public static Texture2D texture_32768;
        public static Texture2D texture_65536;
        public static Texture2D texture_131072;
        #endregion

        private static Vector2 start = new Vector2(50, 50);

        public bool check_Key_Down = false;
        public bool bool_Move_Back = true;
        public bool check_CanMoveBack = false;
        public bool check_NewBoardBuilded = true;
        //public static bool bool_ForAnimation = false;

        public static int score = 0;

        public static int countOfBackMove = 3;

        public static Vector2[,] positions = new Vector2[4, 4] {
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start }};

        public static int[,] gameBoard = new int[4, 4] {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 } };

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

            int[,] startMas = new int[4, 4];

            startMas = Game2048.NewNumber(startMas);
            startMas = Game2048.NewNumber(startMas);

            gameBoard = startMas;

            base.Initialize();
        }

        private static void NewGameBoard()
        {
            int[,] startMas = new int[4, 4];

            startMas = Game2048.NewNumber(startMas);
            startMas = Game2048.NewNumber(startMas);

            gameBoard = startMas;
            score = 0;
        }

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

            texture_backspace = Content.Load<Texture2D>("backspace");
            texture_bestScore = Content.Load<Texture2D>("bestScore");
            texture_newGame = Content.Load<Texture2D>("newGame");
            texture_scoreFrame = Content.Load<Texture2D>("scoreFrame");
            texture_background = Content.Load<Texture2D>("background");
            texture_signboard = Content.Load<Texture2D>("signboard");
            texture_0 = Content.Load<Texture2D>("0");
            texture_2 = Content.Load<Texture2D>("2");
            texture_4 = Content.Load<Texture2D>("4");
            texture_8 = Content.Load<Texture2D>("8");
            texture_16 = Content.Load<Texture2D>("16"); // Иннициализируем пикчи циферок в память
            texture_32 = Content.Load<Texture2D>("32");
            texture_64 = Content.Load<Texture2D>("64");
            texture_128 = Content.Load<Texture2D>("128");
            texture_256 = Content.Load<Texture2D>("256");
            texture_512 = Content.Load<Texture2D>("512");
            texture_1024 = Content.Load<Texture2D>("1024");
            texture_2048 = Content.Load<Texture2D>("2048");
            texture_4096 = Content.Load<Texture2D>("4096");
            texture_8192 = Content.Load<Texture2D>("8192");
            texture_16384 = Content.Load<Texture2D>("16384");
            texture_32768 = Content.Load<Texture2D>("32768");
            texture_65536 = Content.Load<Texture2D>("65536");
            texture_131072 = Content.Load<Texture2D>("131072");

            textForScore = Content.Load<SpriteFont>("TextForScore");
            textForAnimaton = Content.Load<SpriteFont>("TextForAnimation");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (!check_Key_Down)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveLeft();
                    Game2048.SumLeft();
                    Game2048.MoveLeft();
                    check_Key_Down = true;
                    check_CanMoveBack = true;
                }

                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveRight();
                    Game2048.SumRight();
                    Game2048.MoveRight();
                    check_Key_Down = true;
                    check_CanMoveBack = true;
                }

                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveUp();
                    Game2048.SumUp();
                    Game2048.MoveUp();
                    check_Key_Down = true;
                    check_CanMoveBack = true;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    Game2048.SavePreviousStep(0);
                    Game2048.MoveDown();
                    Game2048.SumDown();
                    Game2048.MoveDown();
                    check_Key_Down = true;
                    check_CanMoveBack = true;
                }
            }

            if (check_CanMoveBack)
            {
                if (countOfBackMove >= 0)
                {
                    if (bool_Move_Back)
                    {
                        if (((currentMouseState.X >= 220) && (currentMouseState.X <= 350)) && ((currentMouseState.Y >= 70) && (currentMouseState.Y <= 125)) && (currentMouseState.LeftButton == ButtonState.Pressed))
                            //(keyboardState.IsKeyDown(Keys.Back))
                        {
                            Game2048.MoveBack();
                            bool_Move_Back = false;
                            countOfBackMove--;
                            check_CanMoveBack = false;
                        }
                    }
                }
            }
            if ((bool_Move_Back == false) && ((currentMouseState.X >= 360) && (currentMouseState.X <= 530)) && ((currentMouseState.Y >= 70) && (currentMouseState.Y <= 130)) && (currentMouseState.LeftButton == ButtonState.Released))
            {
                bool_Move_Back = true;
            }

            if ((check_Key_Down == true) && (keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left)))
            {
                check_Key_Down = false;
                Game2048.NewNumber();
            }

            if (check_NewBoardBuilded)
            {
                if (((currentMouseState.X >= 360) && (currentMouseState.X <= 530)) && ((currentMouseState.Y >= 70) && (currentMouseState.Y <= 130)) && (currentMouseState.LeftButton == ButtonState.Pressed))
                {
                    NewGameBoard();
                    check_NewBoardBuilded = false;
                }
            }
            if (((currentMouseState.X >= 360) && (currentMouseState.X <= 530)) && ((currentMouseState.Y >= 70) && (currentMouseState.Y <= 130)) && (currentMouseState.LeftButton == ButtonState.Released) && (check_NewBoardBuilded == false))
            {
                check_NewBoardBuilded = true;
            }

            Game2048.MakingPositions();

            if (Game2048.CheckEndGame())
            {
                score = 999999999;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.IndianRed); // Цвет фона

            _spriteBatch.Begin();

            DrawingObjects();
            Game2048.DrawingNumbers();
            Game2048.DrawingScoreText();

            //if (bool_ForAnimation)
            //{
            //    AnimationForScore(Game2048.plusScore);
            //}

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //public static void AnimationForScore(int num)
        //{
        //    Vector2 position = new Microsoft.Xna.Framework.Vector2(_graphics.PreferredBackBufferWidth - 135, _graphics.PreferredBackBufferHeight - 620); // position
        //    Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 255);// color yellow
        //    _spriteBatch.DrawString(textForAnimaton, num.ToString(), position, color); // draw text

        //    for (int i = 0; i < 500; i++)
        //    {
        //        _spriteBatch.DrawString(textForAnimaton, num.ToString(), new Vector2(position.X, position.Y - 1/2), color); // draw text
        //    }

        //    Game2048.plusScore = 0;

        //    bool_ForAnimation = false;
        //}

        private static void DrawingObjects()
        {
            _graphics.GraphicsDevice.Clear(Color.DarkOrchid);

            _spriteBatch.Draw(texture_backspace, new Rectangle(220,70,130,55), Color.White);

            _spriteBatch.Draw(texture_bestScore, new Rectangle(360, 10, 170, 55),Color.White);

            _spriteBatch.Draw(texture_newGame, new Rectangle(360, 70, 170, 60), Color.White);

            _spriteBatch.Draw(texture_background, new Vector2(69, 133), Color.White);

            _spriteBatch.Draw(texture_scoreFrame, new Rectangle(220, 10, 130, 55), Color.White);

            _spriteBatch.Draw(texture_signboard, new Rectangle(10, 35, 200, 70), Color.White);
        }
    }
}
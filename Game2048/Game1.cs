using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;

namespace Game2048
{
    public class Game1 : Game
    {
        #region Initialization
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static SpriteFont textForScore;
        public static SpriteFont textForAnimaton;
        public static SpriteFont backspaceCount_Sprite;
        public static SpriteFont bestScore_Sprite;
        #endregion

        public static Texture2D texture_background;

        #region LoadedContent
        public static Texture2D texture_gameOver;
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

        public static int score = 0;
        public static int bestScoreInt = 0;
        public static int countOfBackMove = 3;

        public static Vector2[,] positions = new Vector2[4, 4] {
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start },
            { start, start, start, start }};

        public static int[,] gameBoard = new int[4, 4] {
            { 2, 4, 2, 4 },
            { 4, 2, 4, 2 },
            { 2, 4, 2, 4 },
            { 4, 2, 4, 2 } };

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

            NewGameBoard();

            Game2048.BestScore_Get();
            
            base.Initialize();
        }

        private static void NewGameBoard()
        {
            int[,] startMas = new int[4, 4];

            startMas = Game2048.NewNumber(startMas);
            startMas = Game2048.NewNumber(startMas);

            gameBoard = startMas;
            score = 0;
            countOfBackMove = 3;
            Game2048.savedSteps.Clear();
            Game2048.savedScore.Clear();
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

            texture_gameOver = Content.Load<Texture2D>("gameOver");
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
            backspaceCount_Sprite = Content.Load<SpriteFont>("Backspace_Count");
            bestScore_Sprite = Content.Load<SpriteFont>("BestScore_Count");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Чек нажатий
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

            // Чек отмены хода
            if (check_CanMoveBack)
            {
                if (countOfBackMove >= 1)
                {
                    if (bool_Move_Back)
                    {
                        if (bool_Move_Back && keyboardState.IsKeyDown(Keys.Back))
                        {
                            Game2048.MoveBack();
                            bool_Move_Back = false;
                            countOfBackMove--;
                            check_CanMoveBack = false;
                        }
                    }
                }
            }
            // Чек отмены хода (отжатие)
            if (!bool_Move_Back && keyboardState.IsKeyUp(Keys.Back))
            {
                bool_Move_Back = true;
            }

            // Чек для генерирования новой плитки
            if (check_Key_Down && (keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left)))
            {
                check_Key_Down = false;
                Game2048.NewNumber();
            }

            // Чек новой игры
            if (check_NewBoardBuilded)
            {
                if (((currentMouseState.X >= 360) && (currentMouseState.X <= 530)) && ((currentMouseState.Y >= 70) && 
                    (currentMouseState.Y <= 130)) && (currentMouseState.LeftButton == ButtonState.Pressed) )
                {
                    NewGameBoard();
                    check_NewBoardBuilded = false;
                }
            }

            // Чек новой игры (отжатие)
            if (((currentMouseState.X >= 360) && (currentMouseState.X <= 530)) && ((currentMouseState.Y >= 70) && 
                (currentMouseState.Y <= 130)) && (currentMouseState.LeftButton == ButtonState.Released) && (!check_NewBoardBuilded)) 
            {
                check_NewBoardBuilded = true;
            }


            Game2048.MakingPositions(); // Генерация позиций для плиточек


            if (score >= bestScoreInt)
            {
                Game2048.BestScore_Save();
                bestScoreInt = score;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            GraphicsDevice.Clear(Color.IndianRed); // Цвет фона

            _spriteBatch.Begin();

             DrawingObjects();

            Game2048.DrawingAllText();

            if (Game2048.CheckEndGame())
            {
                _spriteBatch.Draw(texture_gameOver, new Vector2(69, 133), Color.White);

                if (((currentMouseState.X >= 217) && (currentMouseState.X <= 417)) && ((currentMouseState.Y >= 447) &&
                    (currentMouseState.Y <= 510)) && (currentMouseState.LeftButton == ButtonState.Pressed)) 
                {
                    NewGameBoard();
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private static void DrawingObjects()
        {
            _graphics.GraphicsDevice.Clear(Color.DarkOrchid);

            _spriteBatch.Draw(texture_backspace, new Rectangle(220, 70, 130, 55), Color.White);

            _spriteBatch.Draw(texture_bestScore, new Rectangle(360, 10, 170, 55),Color.White);

            _spriteBatch.Draw(texture_newGame, new Rectangle(360, 70, 170, 60), Color.White);

            _spriteBatch.Draw(texture_background, new Vector2(69, 133), Color.White);

            _spriteBatch.Draw(texture_scoreFrame, new Rectangle(220, 10, 130, 55), Color.White);

            _spriteBatch.Draw(texture_signboard, new Rectangle(10, 35, 200, 70), Color.White);
        }
    }
}
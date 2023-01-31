using InputSimulator.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RealityDataLibrary;
using System.Collections.Generic;

namespace InputSimulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int hardWareWidth = 720;
        private int hardWareHeight = 480;
        private AppOutParam outParam;
        private Texture2D characterTexture;


        private MouseState mouseState;

        /// <summary>
        /// クリック結果を表示するようにしてみた
        /// </summary>
        private List<PlayerActionData> playerClickDatas = new List<PlayerActionData>();


        /// <summary>
        /// 
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = hardWareWidth;
            _graphics.PreferredBackBufferHeight = hardWareHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            outParam = new AppOutParam(Content.Load<SpriteFont>("File"));
            characterTexture = Content.Load<Texture2D>("tp_player_ship");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            // TODO: Add your update logic here
            if (mouseState.LeftButton == ButtonState.Pressed) {
                playerClickDatas.Add(new PlayerActionData(new Vector2((float)mouseState.X, (float)mouseState.Y)));
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            int xPos = mouseState.X;
            int yPos = mouseState.Y;
            string mouseClick = (mouseState.LeftButton == ButtonState.Pressed).ToString();
            for (int i = 0; i < playerClickDatas.Count; i++)
            {
                _spriteBatch.Draw(characterTexture, playerClickDatas[i].GetPosition(), Microsoft.Xna.Framework.Color.White);
            }

            // TODO: Add your drawing code here
            _spriteBatch.DrawString(outParam.GetSpriteFont(), $"Xpos : {xPos} Ypos : {yPos} mouseClick : {mouseClick}", Vector2.Zero, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
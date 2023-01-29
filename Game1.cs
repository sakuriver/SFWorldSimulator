using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SFSimulator;

namespace SFWorldSimulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D texture;
        Texture2D characterTexture;
        private int hardWareHeight = 224;
        private int hardWareWidth = 256;
        private GameSceneName gameNowScene;
        private PlayerActionData playerData;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = hardWareHeight;
            _graphics.PreferredBackBufferWidth = hardWareWidth;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            gameNowScene = GameSceneName.Title;
            playerData = new PlayerActionData(new Vector2(100.0f, 150.0f));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("tp_title");
            characterTexture = Content.Load<Texture2D>("tp_player_ship");            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                if (gameNowScene == GameSceneName.Title) {
                    gameNowScene = GameSceneName.Main;
                }
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            switch (gameNowScene) {
                case GameSceneName.Title:
                    this.GameTitleDraw();
                    break;
                case GameSceneName.Main:
                    this.GameMainDraw();
                    break;
            }
            base.Draw(gameTime);
        }


        private void GameTitleDraw()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(0, 0, hardWareWidth, hardWareHeight), Color.White);
            _spriteBatch.End();
        }

        private void GameMainDraw() 
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(characterTexture, playerData.GetPosition(), Color.White);
            _spriteBatch.End();
        }

    }
}
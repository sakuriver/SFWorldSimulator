using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SFSimulator;
using System.Collections.Generic;

namespace SFWorldSimulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Texture2D characterTexture;

        private List<PlayerActionData> playerBulletDatas = new List<PlayerActionData>();

        private int hardWareHeight = 224;
        private int hardWareWidth = 256;
        private int playerPositionAddValue = 3;
        private int playerPositionSubValue = -3;

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (gameNowScene == GameSceneName.Title)
                {
                    gameNowScene = GameSceneName.Main;
                }
            }
            this.GameMainUpdate();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            switch (gameNowScene)
            {
                case GameSceneName.Title:
                    this.GameTitleDraw();
                    break;
                case GameSceneName.Main:
                    this.GameMainDraw();
                    break;
            }
            base.Draw(gameTime);
        }


        /// <summary>
        /// タイトル画面での表示周りを編集する関数
        /// タイトルでの反転なども記述
        /// </summary>
        private void GameTitleDraw()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(0, 0, hardWareWidth, hardWareHeight), Color.White);
   
            _spriteBatch.End();
        }

        /// <summary>
        /// メイン画面でのキャラクター表示周りを編集する関数
        /// </summary>
        private void GameMainDraw()
        {
            _spriteBatch.Begin();
            // 自キャラ関係の描画
            _spriteBatch.Draw(characterTexture, playerData.GetPosition(), Color.White);
            
            for (int i = 0; i < playerBulletDatas.Count; i++)
            {
                _spriteBatch.Draw(characterTexture, playerBulletDatas[i].GetPosition(), Color.White);
            }
            _spriteBatch.End();
        }

        /// <summary>
        /// メイン画面内での更新処理
        /// キーボードなどでの入力関連を保持する
        /// </summary>
        private void GameMainUpdate()
        {
            if (gameNowScene != GameSceneName.Main)
            {
                return;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                playerData.AddPosition(0, playerPositionSubValue);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                playerData.AddPosition(0, playerPositionAddValue);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                playerData.AddPosition(playerPositionSubValue, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                playerData.AddPosition(playerPositionAddValue, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                playerBulletDatas.Add(new PlayerActionData(playerData.GetPosition()));
            }

            for (int i = 0; i < playerBulletDatas.Count;i++)
            {
                playerBulletDatas[i].AddPosition(playerPositionAddValue, 0);

                if (playerBulletDatas[i].GetPosition().X > 300) {
                    playerBulletDatas.RemoveAt(i);
                }
            }

        }

        /// <summary>
        /// Todo: 実際に弾が当たった時の表示を追記する。
        /// </summary>
        private void UpdateFieldBattle()
        {
            // 敵機体の判定

            // 自機の判定
        }

    }
}
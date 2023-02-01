using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SFSimulator;
using SFSimulator.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SFWorldSimulator
{
    public class Game1 : Game
    {
        /// <summary>
        /// 
        /// </summary>
        private GraphicsDeviceManager _graphics;

        /// <summary>
        /// ゲームで表示するフォントオブジェクト
        /// </summary>
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// タイトル画像
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// キャラクター画像
        /// </summary>
        private Texture2D characterTexture;

        /// <summary>
        /// 敵画像
        /// </summary>
        private Texture2D enemyTexture;

        /// <summary>
        /// 各種UI関連情報として利用する部分
        /// </summary>
        private AppOutParam outParam;

        /// <summary>
        /// プレイヤーの発射したときの弾情報
        /// </summary>
        private List<PlayerActionData> playerBulletDatas = new List<PlayerActionData>();

        // ゲームとしてビルドするときの画面サイズ

        /// <summary>
        /// 画面全体の高さ
        /// </summary>
        private int hardWareHeight = 224;

        /// <summary>
        /// 画面全体の幅
        /// </summary>
        private int hardWareWidth = 256;

        /// <summary>
        /// 座標の移動速度 
        /// </summary>
        private int playerPositionAddValue = 3;
        private int playerPositionSubValue = -3;



        // 敵が出現するフレーム数
        // Todo 揺らぎを出す場合は、minとmaxを指定するタイプに切り替える
        private int EnemyAppearFrameNum = 100;

        // 敵が１フレームで移動する最大速度
        private int EnemyMaxSpeedNum = 10;

        // 敵出現用フレームカウンター
        private int enemyAppearFrameCount = 0;

        // ゲーム内の上部に表示するスコア情報
        // 敵を倒したりボーナスを計算したいときはこの変数を書き換える
        private int gameScore;

        /// <summary>
        /// ゲームの進行上のシーン情報
        /// </summary>
        private GameSceneName gameNowScene;

        /// <summary>
        /// プレイヤーのアクション用データ
        /// </summary>
        private PlayerActionData playerData;

        /// <summary>
        /// 敵情報
        /// </summary>
        private List<PlayerActionData> enemyShipDatas = new List<PlayerActionData>();

        /// <summary>
        /// ゲーム実行時のコンストラクタ
        /// </summary>
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


        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// Contentからの各種画像情報を読み込み
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("tp_title");
            characterTexture = Content.Load<Texture2D>("tp_player_ship");
            enemyTexture = Content.Load<Texture2D>("tp_enemy_ship");
            outParam = new AppOutParam(Content.Load<SpriteFont>("File"));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// ゲームのメインループで使っている時間部分
        /// </summary>
        /// <param name="gameTime">更新時間情報</param>
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
            this.UpdateFieldBattle();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">更新時間情報</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
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
            _spriteBatch.Draw(texture, new Microsoft.Xna.Framework.Rectangle(0, 0, hardWareWidth, hardWareHeight), Microsoft.Xna.Framework.Color.White);
            _spriteBatch.End();
        }

        /// <summary>
        /// メイン画面でのキャラクター表示周りを編集する関数
        /// </summary>
        private void GameMainDraw()
        {
            _spriteBatch.Begin();
            // 自キャラ関係の描画
            _spriteBatch.Draw(characterTexture, playerData.GetPosition(), Microsoft.Xna.Framework.Color.White);

            for (int i = 0; i < playerBulletDatas.Count; i++)
            {
                _spriteBatch.Draw(characterTexture, playerBulletDatas[i].GetPosition(), Microsoft.Xna.Framework.Color.White);
            }

            // 敵キャラ関係
            for (int i = 0; i < enemyShipDatas.Count; i++)
            {
                _spriteBatch.Draw(enemyTexture, enemyShipDatas[i].GetPosition(), Microsoft.Xna.Framework.Color.White);
            }

            // 描画専用処理が増えたらコメント解除して実装
            //this.MyCharacterDraw();
            //this.EnemyDraw();

            // 画面の一番奥に表示されるUIを設定
            this.UIHeaderDraw();
            this.UITalkDialogDraw();
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

            for (int i = 0; i < playerBulletDatas.Count; i++)
            {
                playerBulletDatas[i].AddPosition(playerPositionAddValue, 0);

                if (playerBulletDatas[i].GetPosition().X > 300)
                {
                    playerBulletDatas.RemoveAt(i);
                }
            }

        }

        /// <summary>
        /// Todo: 実際に弾が当たった時の表示を追記する。
        /// </summary>
        private void UpdateFieldBattle()
        {
            // 敵機体の移動処理
            Random random = new Random();
            MoveEnemy(random);

            // 出現処理
            if (enemyAppearFrameCount >= EnemyAppearFrameNum)
            {
                int yValue = random.Next(hardWareHeight);
                enemyShipDatas.Add(new PlayerActionData(new Vector2(200, yValue)));
                enemyAppearFrameCount = 0;
            }

            enemyAppearFrameCount++;

            // 自機の判定
        }

        /// <summary>
        /// 敵移動処理
        /// </summary>
        /// <param name="random">移動速度算出用オブジェクト</param>
        private void MoveEnemy(Random random)
        {
            // 敵キャラ関係
            for (int i = 0; i < enemyShipDatas.Count; i++)
            {
                // 敵を移動する
                int yAddValue = random.Next(EnemyMaxSpeedNum);
                int ySubValue = random.Next(EnemyMaxSpeedNum);
                enemyShipDatas[i].AddPosition(0, yAddValue - ySubValue);
                // 移動後に弾に接触しているかを確認する
            }

        }

        /// <summary>
        /// Todo 自キャラ関係の描画処理
        /// 処理行数が多そうであれば、専用関数で呼び出し
        /// </summary>
        private void MyCharacterDraw()
        {
        }

        /// <summary>
        /// Todo 敵キャラ固有の描画表示の改修希望があれば移行して修正
        /// </summary>
        private void EnemyDraw()
        {
        }


        /// <summary>
        /// ゲーム中のUI情報を表示する
        /// </summary>
        private void UIHeaderDraw()
        {
            string scoreStr = $"score {gameScore}";
            _spriteBatch.DrawString(outParam.GetSpriteFont(), "stage 1", new Vector2(0, AppOutParam.OutPutUiHeaderYpos), Microsoft.Xna.Framework.Color.White);
            _spriteBatch.DrawString(outParam.GetSpriteFont(), scoreStr, new Vector2(100, AppOutParam.OutPutUiHeaderYpos), Microsoft.Xna.Framework.Color.White);
        }

        /// <summary>
        /// ダイアログボックス領域の表示作業
        /// </summary>
        private void UITalkDialogDraw()
        {
            // 会話情報を作りこんで設定する場合は本関数を利用 
            // Todo 会話情報カスタマイズ時は 以下の行をダイアログ表示用にカスタマイズ
            _spriteBatch.DrawString(outParam.GetSpriteFont(), "test", new Vector2(100, AppOutParam.OutputTalkYpos), Microsoft.Xna.Framework.Color.White);
            //this.UITalkDialogDraw();

        }
    }
}
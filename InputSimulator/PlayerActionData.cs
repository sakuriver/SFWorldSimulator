using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace InputSimulator
{
    /// <summary>
    /// プレイヤーが操作するキャラクターや
    /// パラメータ関連のクラス
    /// </summary>
    public class PlayerActionData
    {
        /// <summary>
        /// キャラクター座標情報
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// キャラうたー初期座標設定
        /// </summary>
        /// <param name="initialPosition"></param>
        public PlayerActionData(Vector2 initialPosition) {
            position = initialPosition;
        }

        /// <summary>
        /// キャラクター情報の座標を加算する
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public void AddPosition(int x, int y) {
            position.X += x;
            position.Y += y;
        }

        /// <summary>
        /// キャラクター座標を取得する
        /// </summary>
        /// <returns>現在のキャラクター座標</returns>
        public Vector2 GetPosition()
        {
            return position;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SFSimulator
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerActionData
    {
        /// <summary>
        /// 
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// 
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
        }

        /// <summary>
        /// キャラクター座標を取得する
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return position;
        }


    }
}

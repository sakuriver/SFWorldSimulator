using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SFSimulator.UI
{
    /// <summary>
    /// アプリの外回り用の情報管理
    /// 
    /// </summary>
    public class AppOutParam
    {
        /// <summary>
        /// 指定がない場合に利用する文字列
        /// </summary>
        private SpriteFont defaultFont;

        /// <summary>
        /// ヘッダー情報のUI定義
        /// </summary>
        public const int OutPutUiHeaderYpos = 10;

        /// <summary>
        /// 会話ダイアログ用のUI定義
        /// </summary>
        public const int OutputTalkYpos = 180;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteFont">文字情報ファイル</param>
        public AppOutParam(SpriteFont _defaultFont)
        {
            defaultFont = _defaultFont;
        }

        public SpriteFont GetSpriteFont()
        {
            return defaultFont;
        }


    }
}

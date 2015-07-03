using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceExplorer.Engine
{
    class SistemView : GameView
    {
        public static Sistem TrenutniSistem;
        public SistemView(GameNode nodesakojimsamsesudario)
        {
            TrenutniSistem = (Sistem)nodesakojimsamsesudario;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            TrenutniSistem.Draw(spriteBatch);
        }

    }
}

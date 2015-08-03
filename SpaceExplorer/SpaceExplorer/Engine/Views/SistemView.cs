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
        public string name;
        public SistemView(GameNode nodesakojimsamsesudario, PlayerShip playerShip)
        {
            TrenutniSistem = (Sistem)nodesakojimsamsesudario;
            this.name = nodesakojimsamsesudario.ImeSistemaKomePripada;
            playerShip.Position = new Vector2(this.horizontalSize/2 - playerShip.Sprite.Origin.X, this.verticalSize - playerShip.Sprite.Height - 40);
            playerShip.rotationAngle = 0f;
            Config.currentSpeed = 0;
            Config.brzinaTrosenjaGoriva = 10000;
            playerShip.spremanZaPonovanUlazakUSistem = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            TrenutniSistem.Draw(spriteBatch);
        }

    }
}

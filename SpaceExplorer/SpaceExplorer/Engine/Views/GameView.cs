using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace SpaceExplorer.Engine
{
    class GameView : View
    {
        public GameView()
        {
            this.horizontalSize = base.horizontalSize - Config.VelicinaDesnogMenija;
            this.verticalSize = base.verticalSize;
            Config.velicinaGameplayprozoraHorizontala = this.horizontalSize;
            Config.velicinaGameplayprozoraVertikala = this.verticalSize;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
                
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using System.Text;


namespace SpaceExplorer.Engine
{
    class MenuToolbarView : View
    {
        public MenuToolbarView()
        {
            this.horizontalSize = Config.VelicinaDesnogMenija;
            this.verticalSize = base.verticalSize;
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
        public override void Update(GameTime gameTime)
        {
        }
    }
}

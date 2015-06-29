using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace SpaceExplorer.Engine
{
    class View
    {
        public int verticalSize;
        public int horizontalSize;

        public View()
        {
            this.horizontalSize = Config.Screen_Width;
            this.verticalSize = Config.Screen_Height;
        }

        
        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

    }
}

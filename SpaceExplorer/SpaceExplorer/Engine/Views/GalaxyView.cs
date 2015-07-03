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
    class GalaxyView : GameView
    {
        public static List<Sistem> Sistemi = new List<Sistem>();
        public static Texture2D teksturaGalaksije;

        public GalaxyView()
        {
        
        }
        
        public override void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i <= Sistemi.Count - 1; i++)
            {
                Sistemi[i].Draw(spritebatch); 
            }    
        }

        public override void Update(GameTime gameTime)
        {
        
        }
    }
}

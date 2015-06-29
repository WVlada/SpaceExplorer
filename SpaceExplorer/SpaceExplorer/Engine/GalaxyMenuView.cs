using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Text;

namespace SpaceExplorer.Engine
{
    class GalaxyMenuView : MenuToolbarView
    {
        public static Texture2D teksturaMenija;

        public GalaxyMenuView()
        {
        
        }
        public static void UcitajPozadinu(ContentManager content)
        {
            teksturaMenija = content.Load<Texture2D>("circle");

        }
        public override void Draw(SpriteBatch spritebatch)
        {
            // za ovaj VIEW levi-gore ugao je 0,0 
            spritebatch.Draw(teksturaMenija, new Rectangle(0, 0, base.horizontalSize, base.verticalSize), Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
        
        }
    }
}

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
        public static SpriteFont menuItemsFont;
        public string[] menuItems;

        public GalaxyMenuView()
        {
            this.menuItems = new string[] {"Ships name", "Save game", "Load game", "Options"};
        }
        public static void UcitajPozadinu(ContentManager content)
        {
            teksturaMenija = content.Load<Texture2D>("menu");
            menuItemsFont = content.Load<SpriteFont>("Tahoma");
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            // za ovaj VIEW levi-gore ugao je 0,0 
            spritebatch.Draw(teksturaMenija, new Rectangle(0, 0, base.horizontalSize, base.verticalSize), Color.White);
            for (int i = 0; i < this.menuItems.Length; i++)
                {
                spritebatch.DrawString(menuItemsFont, menuItems[i], new Vector2(40, this.verticalSize - 150 + i * 25), Color.White);
                }
            }

        public override void Update(GameTime gameTime)
        {
        
        }
    }
}

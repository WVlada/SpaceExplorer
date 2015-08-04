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
    class PlanetView : GameView
    {

        public Rectangle DonjiDeoEkrana;
        public static Texture2D donjiMeni;
        public Planet planeta;

        public PlanetView(Planet planet, PlayerShip playerShip)
        {
            DonjiDeoEkrana = new Rectangle(0, base.verticalSize - 100, base.horizontalSize, 100);
            this.planeta = planet;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(donjiMeni,DonjiDeoEkrana,Color.Red);
                spriteBatch.Draw(planeta.Sprite.Texture, new Rectangle(0,0,100,100), Color.Red);
        }

        public static void UcitajPlanetView(ContentManager content)
        {
            donjiMeni = content.Load<Texture2D>("dot");
        }

    }
}

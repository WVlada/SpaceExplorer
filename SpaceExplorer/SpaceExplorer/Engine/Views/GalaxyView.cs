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
        public string imeSistemaKomePripada = "Galaksija";
        static SpriteFont imenaSistema;
        
        public GalaxyView(GameNode playerShip)
        {
            playerShip.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - playerShip.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala);
            Config.currentSpeed = 0;
            Config.brzinaTrosenjaGoriva = 1000;
        }
        public GalaxyView(GameNode playerShip, Sistem sistem)
        {
            playerShip.Position = sistem.Position - playerShip.Sprite.Origin;
            Config.currentSpeed = 0;
        }
        public GalaxyView()
        {
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i <= Sistemi.Count - 1; i++)
            {
                spritebatch.Draw(Sistemi[i].spoljnatekstura.Texture, Sistemi[i].Position, Color.White);
                spritebatch.DrawString(imenaSistema, Sistemi[i].Position.ToString(), Sistemi[i].Position, Color.Wheat);
            }    
        }
        public static void UcitajSadrzaj(ContentManager content)
        {
            imenaSistema = content.Load<SpriteFont>("Tahoma");
        }
        public override void Update(GameTime gameTime)
        {
        
        }
    }
}

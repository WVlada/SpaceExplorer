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

        public GalaxyView(GameNode playerShip, Sistem sistem)
        {
            Config.currentSpeed = 0;
            Config.brzinaTrosenjaGoriva = 1000;
            // drzacu ovih sto dok ne implementiram da ne mogu da se vratim u sistem cim izadjem iz njega
            playerShip.Position = new Vector2(sistem.Position.X - playerShip.Sprite.Origin.X - 100, sistem.Position.Y - playerShip.Sprite.Origin.Y);
        }
        void Ship_sudarSaSistemom(Sistem sistem, PlayerShip playerShip)
        {
           Config.TrenutniPogledi[0] = new SistemView(sistem, playerShip); Config.TrenutniPogledi[1] = new SistemMenuView();
           playerShip.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - playerShip.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala - playerShip.Sprite.Height);
           Config.currentSpeed = 0;
        }
        public GalaxyView(PlayerShip playerShip)
        {
            playerShip.sudarSaSistemom += new UcitajSistem(Ship_sudarSaSistemom);
            playerShip.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - playerShip.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala - 100);
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

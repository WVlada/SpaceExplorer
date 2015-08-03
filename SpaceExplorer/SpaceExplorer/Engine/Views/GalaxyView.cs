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

        // ovaj se poziva kada se izlazi iz nekog sistema
        public GalaxyView(PlayerShip playerShip, Sistem sistem)
        {
            Config.currentSpeed = 0;
            Config.brzinaTrosenjaGoriva = 1000;
            playerShip.spremanZaPonovanUlazakUSistem = false;
            playerShip.kilometaraZaVracanjeUSistem = 0;
            playerShip.Position = new Vector2(sistem.Position.X - playerShip.Sprite.Origin.X, sistem.Position.Y - playerShip.Sprite.Origin.Y);
        }
        void Ship_sudarSaSistemom(Sistem sistem, PlayerShip playerShip)
        {
            if (playerShip.spremanZaPonovanUlazakUSistem)
            {
                Config.TrenutniPogledi[0] = new SistemView(sistem, playerShip); Config.TrenutniPogledi[1] = new SistemMenuView();
                playerShip.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - playerShip.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala - playerShip.Sprite.Height);
                Config.currentSpeed = 0;
                playerShip.spremanZaPonovanUlazakUSistem = false;
                playerShip.kilometaraZaVracanjeUSistem = 0;
            }
        }
        //ovaj se poziva samo pri ucitavanju,tj sponovanju playerShipa
        public GalaxyView(PlayerShip playerShip)
        {
            playerShip.sudarSaSistemom += new UcitajSistem(Ship_sudarSaSistemom);
            playerShip.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - playerShip.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala - 100);
        }
        //ovaj se ucitava u straticku listu na pocetku, samo da postoji
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

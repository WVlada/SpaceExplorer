using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SpaceExplorer.Game;

namespace SpaceExplorer.Engine
{
    class Sistem : GameNode
    {
        public string Ime;
        public Vector2 Pozicija;
        public int velicinaSistema;
        Random rnd = new Random();
        public Sun Sunce;
        public List<Planet> Planete = new List<Planet>();
        static SpriteFont imenaSistema;
        
        public int brojPlaneta;
        public Vector2[] lokacijaIBrojMeseca;
        
        //vec ima sprite
        public Sistem(SpriteSheet spriteSheet, string name, Vector2 position, Sun sunce, int brojPlaneta, Vector2[] lokacijaIBrojMeseca) : base(spriteSheet)
        {
            // konstruktor sistema za GalaxyView
            this.Ime = name;
            this.Position = position;
            this.Sunce = sunce;
            
            PlayerShip.PlayerShips[0].CollisionList.Add(this);

            // konstruktor sistema za SistemView
            if (brojPlaneta != null) {this.brojPlaneta = brojPlaneta;}
            //this.KonstruisiPlanete(brojPlaneta);
            if (lokacijaIBrojMeseca != null) {this.lokacijaIBrojMeseca = lokacijaIBrojMeseca;}

            GalaxyView.Sistemi.Add(this);
        }
        
        private void KonstruisiSistem(int brojplaneta)
        {
            int X = velicinaSistema / brojPlaneta;
            
            int daljina = rnd.Next((int)(X - X/2), X * 2 );
            X -= daljina;
            // pa ponovo
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // ovo treba biti sunce
            spriteBatch.Draw(this.Sunce.Sprite.Texture, new Rectangle(0, 0, this.Sunce.Sprite.Texture.Width, this.Sunce.Sprite.Texture.Height), Color.White);
            spriteBatch.DrawString(imenaSistema,this.Ime, new Vector2(300,0), Color.White);

        }

        public static void UcitajSadrzaj(ContentManager content)
        {
            imenaSistema = content.Load<SpriteFont>("Tahoma");
        }
    }
}

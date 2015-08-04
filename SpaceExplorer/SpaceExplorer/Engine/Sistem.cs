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
    class Sistem : GameNode
    {
        public string Ime;
        public int velicinaSistema;
        Random rnd = new Random();
        public Sun Sunce;
        public List<Planet> Planete = new List<Planet>();
        static SpriteFont imenaSistema;
        public Sprite spoljnatekstura;
        public Vector2 spoljnapozicija;
                
        public int brojPlaneta;
        public Vector2[] lokacijaIBrojMeseca;
        
        //vec ima sprite
        public Sistem(SpriteSheet spriteSheet, string name, Vector2 position, Sun sunce, int brojPlaneta, Vector2[] lokacijaIBrojMeseca, Vector2 spoljna, Sprite spoljnaTekstura, Vector2 velicinaSistema) : base(spriteSheet)
        {
            // konstruktor sistema za GalaxyView
            this.Ime = name;
            this.Position = position;
            this.Sunce = sunce;
            this.spoljnapozicija = spoljna;
            this.spoljnatekstura = spoljnaTekstura;
            GalaxyView.Sistemi.Add(this);
            
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
            for (int i = 1; i <= brojPlaneta; i++)
            {
                Planet planet = new Planet(Config.PlanetSpriteSheet, brojPlaneta, i, this);
                //planet.Position = new Vector2(100 * i, 100 * i);
                Planete.Add(planet);
            }
            // konstruktor sistema za SistemView
            if (brojPlaneta != null) {this.brojPlaneta = brojPlaneta;}
            //this.KonstruisiPlanete(brojPlaneta);
            if (lokacijaIBrojMeseca != null) {this.lokacijaIBrojMeseca = lokacijaIBrojMeseca;}

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
            //spriteBatch.Draw(this.Sunce.Sprite.Texture, this.Sunce.Position, Color.Wheat);
            spriteBatch.Draw(this.Sunce.Sprite.Texture, this.Sunce.Position, this.Sunce.Sprite.FrameBounds, Color.White);
            spriteBatch.DrawString(imenaSistema,this.Ime, new Vector2(300,0), Color.White);
            spriteBatch.DrawString(imenaSistema, this.Sunce.Position.ToString(), this.Sunce.Position, Color.Wheat);

            for (int i = 0; i < this.Planete.Count; i++)
            {
                spriteBatch.Draw(this.Planete[i].Sprite.Texture, this.Planete[i].Position,this.Planete[i].Sprite.FrameBounds, Color.White);
            
            }
        }
        
        public static void UcitajSadrzaj(ContentManager content)
        {
            imenaSistema = content.Load<SpriteFont>("Tahoma");
        }
    }
}

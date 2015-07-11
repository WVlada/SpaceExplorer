using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna;
using System.Text;
using SpaceExplorer.Engine;

namespace SpaceExplorer.Game
{
    class Level
    {
        public static Texture2D Saturn;
        
        public static void UcitajNeprijatelje()
        {
            Enemy one = new Enemy(Config.AsteroidSpriteSheet, "Sol");
            one.Position = new Vector2(650, 150);
            one.Health = 20;
            one.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;
            Enemy two = new Enemy(Config.AsteroidSpriteSheet);
            two.Position = new Vector2(400, 200);
            two.Health = 60;
            two.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;
            Enemy three = new Enemy(Config.PlanetSpriteSheet);
            three.Position = new Vector2(600, 400);
            three.Health = 20;
            three.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;
            Enemy four = new Enemy(Config.PlanetSpriteSheet2);
            four.Position = new Vector2(500, 450);
            four.Health = 20;
            four.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;
            Enemy five = new Enemy(Config.GasGiantSpriteSheet);
            five.Position = new Vector2(200, 200);
            five.Health = 20;
            five.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;
            Enemy six = new Enemy(Config.GasGiantSpriteSheet2);
            six.Position = new Vector2(300, 300);
            six.Health = 20;
            six.ExplosionSpriteSheet = Config.AsteroidExplosionSpriteSheet;

            Sistem Sol = new Sistem(Config.PickASpoljniSPriteSheet("star"), "Sol", new Vector2(300, 300), new Sun(Config.PickASunSPriteSheet()), 9, null, new Vector2(300, 300), new Sprite(Config.PickASpoljniSPriteSheet()), new Vector2(Config.velicinaGameplayprozoraHorizontala / 2, Config.velicinaGameplayprozoraVertikala / 2));
            Sistem AlphaCentauri = new Sistem(Config.PickASpoljniSPriteSheet(), "Alpha Centauri", new Vector2(550, 430), new Sun(Config.PickASunSPriteSheet()), 6, null, new Vector2(350, 350), new Sprite(Config.PickASpoljniSPriteSheet()), new Vector2(Config.velicinaGameplayprozoraHorizontala / 2, Config.velicinaGameplayprozoraVertikala / 2));
        }

        public static void UcitajPozadinu(ContentManager content)
        {
            Saturn = content.Load<Texture2D>("saturn");
            
        }
        public static void NacrtajPozadinu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Saturn, new Rectangle(100, 100, Saturn.Width, Saturn.Height), Color.White);
        }
    }
}

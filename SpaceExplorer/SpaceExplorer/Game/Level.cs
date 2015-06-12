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
            Enemy one = new Enemy(Config.AsteroidSpriteSheet);
            one.Position = new Vector2(650, 150);
            one.Health = 10;
            Enemy two = new Enemy(Config.AsteroidSpriteSheet);
            two.Position = new Vector2(400, 200);
            two.Health = 10;
            Enemy three = new Enemy(Config.PlanetSpriteSheet);
            three.Position = new Vector2(600, 400);
            three.Health = 10;
        }

        public static void UcitajPozadinu(ContentManager content)
        {
            Saturn = content.Load<Texture2D>("saturn");
            
        }
        public static void NacrtajPozadinu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Saturn, new Rectangle(500, 100, Saturn.Width, Saturn.Height), Color.White);
        }
    }
}

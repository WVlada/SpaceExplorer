using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceExplorer.Engine;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Game
{
    class Config
    {
        public static int Screen_Width = 800;
        public static int Screen_Height = 600;

        public static int PlayerShipSpeed = 1;
        public static int PlayerShipHealth = 100;
        public static Vector2 PlayerShipSpawnPosition = new Vector2(100, 100);

        public static SpriteSheet AsteroidSpriteSheet = new SpriteSheet("asteroid", 5, 6, 15, 30, SpriteSheetMode.Normalan);
        public static SpriteSheet EnemyShipSpriteSheet = new SpriteSheet("enemyship", 1, 1, 30, 1, SpriteSheetMode.Normalan);
        public static SpriteSheet PlanetSpriteSheet = new SpriteSheet("planet1", 5, 4, 15, 19, SpriteSheetMode.Normalan);

        public static SpriteSheet PlayerShipEngine = new SpriteSheet("engine", 1,1,5,1, SpriteSheetMode.Normalan);
        public static SpriteSheet ShipHealthBar = new SpriteSheet("dot", 1, 1, 1, 1, SpriteSheetMode.Normalan);
        

        public static SpriteSheet[] ShipSpriteSheets = new SpriteSheet[]
        {   new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
        };

        public static SpriteSheet AsteroidExplosionSpriteSheet = new SpriteSheet("asteroideksplozija", 5, 4, 17, 30, SpriteSheetMode.BezTekstureZaStetu);
        public static SpriteSheet PlayerShipExplosionSpriteSheet = new SpriteSheet("playershipeksplozija", 3, 4, 12, 30, SpriteSheetMode.BezTekstureZaStetu);
    }
}

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
        public static int Screen_Width = 1024;
        public static int Screen_Height = 768;
        public static int VelicinaDesnogMenija = 300;

        public static float currentSpeed;

        public static int PlayerShipSpeed = 1;
        public static int PlayerShipHealth = 100;
        public static Vector2 PlayerShipSpawnPosition = new Vector2(Screen_Width/2-64, Screen_Height-64);
        public static int DaljinaZaKoliziju = 70;

        public static SpriteSheet AsteroidSpriteSheet = new SpriteSheet("asteroid", 5, 6, 15, 30, SpriteSheetMode.Normalan);
        public static SpriteSheet EnemyShipSpriteSheet = new SpriteSheet("enemyship", 1, 1, 30, 1, SpriteSheetMode.Normalan);
        public static SpriteSheet PlanetSpriteSheet = new SpriteSheet("planet1", 5, 4, 15, 19, SpriteSheetMode.Normalan);
        public static SpriteSheet PlanetSpriteSheet2 = new SpriteSheet("planet2", 5, 4, 5, 19, SpriteSheetMode.Normalan);
        public static SpriteSheet SunSpriteSheet = new SpriteSheet("sun1", 1, 1, 5, 1, SpriteSheetMode.Normalan);
        public static SpriteSheet GasGiantSpriteSheet = new SpriteSheet("image1", 5, 5, 15, 22, SpriteSheetMode.Normalan);
        public static SpriteSheet GasGiantSpriteSheet2 = new SpriteSheet("image2", 10, 3, 15, 23, SpriteSheetMode.Normalan);


        public static SpriteSheet PlayerShipEngine = new SpriteSheet("engine", 1,1,5,1, SpriteSheetMode.Normalan);
        public static SpriteSheet ShipHealthBar = new SpriteSheet("dot", 1, 1, 1, 1, SpriteSheetMode.Normalan);
        

        public static SpriteSheet[] ShipSpriteSheets = new SpriteSheet[]
        {   new SpriteSheet("malispaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
            new SpriteSheet("spaceship",1,1,30,1,SpriteSheetMode.Normalan),
        };

        public static SpriteSheet AsteroidExplosionSpriteSheet = new SpriteSheet("asteroideksplozija", 5, 4, 17, 30, SpriteSheetMode.BezTekstureZaStetu);
        public static SpriteSheet PlayerShipExplosionSpriteSheet = new SpriteSheet("playershipeksplozija", 3, 4, 10, 12, SpriteSheetMode.BezTekstureZaStetu);
        
        public static View[] TrenutniPogledi = new View[] { new GalaxyView(), new GalaxyMenuView() };

        public static SpriteSheet NekiSistem = new SpriteSheet("star", 1, 1, 5, 1, SpriteSheetMode.Normalan);
        public static SpriteSheet NekiSistem2 = new SpriteSheet("diamond", 1, 1, 5, 1, SpriteSheetMode.Normalan);
    }
}

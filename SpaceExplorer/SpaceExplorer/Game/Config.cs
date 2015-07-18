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
        public static int Screen_Width = 1366;
        public static int Screen_Height = 768;
        public static int VelicinaDesnogMenija = 300;
        public static int velicinaGameplayprozoraHorizontala;
        public static int velicinaGameplayprozoraVertikala;
        public static int brzinaTrosenjaGoriva = 1000;
        
        public static float currentSpeed;

        public static int PlayerShipSpeed = 1;
        public static int PlayerShipHealth = 100;
        public static Vector2 PlayerShipSpawnPosition = new Vector2(Screen_Width/2-64, Screen_Height-164);
        public static int DaljinaZaKoliziju = 30;

        public static SpriteSheet AsteroidSpriteSheet = new SpriteSheet("asteroid", 5, 6, 15, 30, SpriteSheetMode.Normalan);
        public static SpriteSheet EnemyShipSpriteSheet = new SpriteSheet("enemyship", 1, 1, 30, 1, SpriteSheetMode.Normalan);
        public static SpriteSheet PlanetSpriteSheet = new SpriteSheet("planetmala1", 5, 4, 15, 19, SpriteSheetMode.Normalan);
        public static SpriteSheet PlanetSpriteSheet2 = new SpriteSheet("planet2", 5, 4, 5, 19, SpriteSheetMode.Normalan);
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

        public static SpriteSheet[] SistemskiSpoljniSpriteSheetovi = new SpriteSheet[] {
        new SpriteSheet("star", 1, 1, 5, 1, SpriteSheetMode.Normalan),
        new SpriteSheet("diamond", 1, 1, 5, 1, SpriteSheetMode.Normalan),
        new SpriteSheet("dot", 1, 1, 5, 1, SpriteSheetMode.Normalan),
        new SpriteSheet("circle", 1, 1, 5, 1, SpriteSheetMode.Normalan)
        };

        public static SpriteSheet[] SunSpriteSheet = new SpriteSheet[] {
        new SpriteSheet("sun1", 1, 1, 15, 1, SpriteSheetMode.Normalan),
        new SpriteSheet("sun2", 1, 1, 15, 1, SpriteSheetMode.Normalan),
        new SpriteSheet("sun3", 5, 6, 15, 30, SpriteSheetMode.Normalan),
        };

        public static SpriteSheet[] PlanetsSpriteSheet = new SpriteSheet[] {
        new SpriteSheet("gasred1", 9, 9, 15, 80, SpriteSheetMode.Normalan),
        new SpriteSheet("gasred2", 9, 9, 15, 80, SpriteSheetMode.Normalan),
        new SpriteSheet("planet1", 5, 4, 15, 19, SpriteSheetMode.Normalan),
        new SpriteSheet("planet2", 5, 4, 5, 19, SpriteSheetMode.Normalan)
        };


        static Random x = new Random(); // ovime sam resio taj problem
        public static SpriteSheet PickASpoljniSPriteSheet(string a = "default")
        {
            // cesto mi izbacuje iste, verovatno zbog brzine obracuna, moram nekako da resim
            if (a == "default")
            {
                //Random x = new Random();
                int i = x.Next(0, Config.SistemskiSpoljniSpriteSheetovi.Length);
                return Config.SistemskiSpoljniSpriteSheetovi[i];
            }
            else
            {
                for (int i = 0; i <= Config.SistemskiSpoljniSpriteSheetovi.Length - 1; i++)
                {
                    if (Config.SistemskiSpoljniSpriteSheetovi[i].assetName == a)
                    { return Config.SistemskiSpoljniSpriteSheetovi[i]; }
                    
                }
                //Random x = new Random();
                int j = x.Next(0, Config.SistemskiSpoljniSpriteSheetovi.Length);
                return Config.SistemskiSpoljniSpriteSheetovi[j];
            }
        }
        public static SpriteSheet PickASunSPriteSheet()
        {
            //Random x = new Random();
            int i = x.Next(0, Config.SunSpriteSheet.Length);
            return Config.SunSpriteSheet[i];
        }
        public static SpriteSheet PickAPlanetSPriteSheet()
        {
            //Random x = new Random();
            int i = x.Next(0, Config.PlanetsSpriteSheet.Length);
            return Config.PlanetsSpriteSheet[i];
        }


    }
}

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
    class Planet : GameNode
    {
        public static List<Planet> SvePlanete = new List<Planet>();
        
        public Sistem sistem;
        public SpriteSheet spoljnaTeksuta;
        public Model modelPlanete;
        public SpriteFont FontZaStatistiku;
        
        public Planet(SpriteSheet spriteSheet, int brojPlaneta, int brojOvePlanete, Sistem sistemKomePripada) : base(spriteSheet) 
        {
            this.sistem = sistemKomePripada;
            this.Position = NapraviPrimitive.randomMEstoZaPlanetu(Config.TrenutniPogledi[0], brojPlaneta, brojOvePlanete, this.Sprite.sheet);
            SvePlanete.Add(this);
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
            UcitajStatistikuZaPlanetu(this);
        }

        public Planet OdaberiPlanetu()
        {
            Random broj = new Random();
            int x = broj.Next(0, SvePlanete.Count - 1);
            return SvePlanete[x];
        }
        public static void UcitajPlanetice(ContentManager content)
        {
            foreach (Planet planetica in SvePlanete)
            {
                 planetica.modelPlanete = content.Load<Model>("Models\\AlienPlanet2");
                 planetica.FontZaStatistiku = content.Load<SpriteFont>("Tahoma");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= Stats.Count-1; i++)
            {
                spriteBatch.DrawString(FontZaStatistiku, Stats[i], new Vector2(50, 50 * i), Color.White);
            }
           
        }

        private List<String> Stats = new List<string>();
        private string _temperature;
        private string _pressure;
        private string _diameter;
        private string _waterpresence;
        private void UcitajStatistikuZaPlanetu(Planet planeta)
        {
            this.Stats.Add("Temperature : 35");
            this.Stats.Add("Pressure : 20");
            this.Stats.Add("Diameter : 500");
            this.Stats.Add("Water Presence : 35%");
            this.Stats.Add("CO2 presence : 40%");
        }
    }
}

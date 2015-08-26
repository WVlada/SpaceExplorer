using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace SpaceExplorer.Engine
{
    class Planet : GameNode
    {
        public static List<Planet> SvePlanete = new List<Planet>();
        
        public Sistem sistem;
        public SpriteSheet spoljnaTeksuta;
        public Model modelPlanete;
        public SpriteFont FontZaStatistiku;
        public SpriteFont FontZaImePlanete;
        public string _planetType;
        
        public Planet(SpriteSheet spriteSheet, int brojPlaneta, int brojOvePlanete, Sistem sistemKomePripada) : base(spriteSheet) 
        {
            this.sistem = sistemKomePripada;
            this.Position = NapraviPrimitive.randomMEstoZaPlanetu(Config.TrenutniPogledi[0], brojPlaneta, brojOvePlanete, this.Sprite.sheet);
            SvePlanete.Add(this);
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
            UcitajStatistikuZaPlanetu(this);
            _planetType = "Neki tip planete";
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
                 planetica.modelPlanete = content.Load<Model>("Models\\GasGiantGreenFBX");
                 planetica.FontZaStatistiku = content.Load<SpriteFont>("Tahoma");
                 planetica.FontZaImePlanete = content.Load<SpriteFont>("TahomaLarger");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= Stats.Count-1; i++)
            {
                if (i < 5)
                spriteBatch.DrawString(FontZaStatistiku, Stats[i], new Vector2(100, 35 + 150 + 50 * i), Color.White);
                else
                spriteBatch.DrawString(FontZaStatistiku, Stats[i], new Vector2(775, 35 + 150 + 50 * (i-5)), Color.White);
            }
            // pretpostavljam da je 18 horizontalna velicina 1 chara
            spriteBatch.DrawString(FontZaImePlanete, _planetType, new Vector2(PlanetView.donjiMeni.Width / 2 - _planetType.Length * 18 / 2, 35 + 20), Color.White);
            spriteBatch.DrawString(FontZaStatistiku, "Ime sistema", new Vector2(PlanetView.donjiMeni.Width / 2 - 200 , 3), Color.White);
            spriteBatch.DrawString(FontZaStatistiku, "Broj planete", new Vector2(840, 3), Color.White);
        }

        private List<String> Stats = new List<string>();
        private string _temperature;
        private string _pressure;
        private string _diameter;
        private string _waterpresence;
        private void UcitajStatistikuZaPlanetu(Planet planeta)
        {
            this.Stats.Add("Orbit : 35 a.u.");
            this.Stats.Add("Atmosphere: 20 atm");
            this.Stats.Add("Temperature: 500 c");
            this.Stats.Add("Weather: Class 1");
            this.Stats.Add("Tectonics: Class 2");

            this.Stats.Add("Mass: 35 e.s.");
            this.Stats.Add("Radius: 20 e.s.");
            this.Stats.Add("Gravity: 0.90 g.");
            this.Stats.Add("Day: 1.16 days");
            this.Stats.Add("Tilt: 11");

        }
    }
}

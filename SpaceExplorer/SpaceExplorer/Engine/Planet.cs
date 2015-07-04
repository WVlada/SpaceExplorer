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
        
        Sistem sistem;
        public SpriteSheet spoljnaTeksuta;
        
        public Planet(SpriteSheet spriteSheet) : base(spriteSheet) 
        {
            this.sistem = sistem;
            sistem.Planete.Add(this);
            SvePlanete.Add(this);
            
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
        }

        public Planet OdaberiPlanetu()
        {
            Random broj = new Random();
            int x = broj.Next(0, SvePlanete.Count - 1);
            return SvePlanete[x];
        }



    }
}

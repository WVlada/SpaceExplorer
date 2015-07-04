using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Content;

namespace SpaceExplorer.Engine
{
    class Enemy : GameNode
    {
        public static List<Enemy> ListaSvihNeprijatelja = new List<Enemy>();
        
        public Enemy(SpriteSheet spriteSheet) : base(spriteSheet) 
        {
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
        }
        public Enemy(SpriteSheet spriteSheet, string imeSistema)
            : base(spriteSheet)
        {
            PlayerShip.PlayerShips[0].CollisionList.Add(this);
        }

        
        
    }
}

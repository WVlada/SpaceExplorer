using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;

namespace SpaceExplorer.Engine
{
    class GameNode : Node
    {
        public double Health;
        public List<GameNode> CollisionList;//nije static! nego svako ima svoju
        Timer hitTimer;
        public SpriteSheet ExplosionSpriteSheet;
        

        static Random randomBroj = new Random();

        public GameNode(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            hitTimer = new Timer();
            hitTimer.Fire += new NotifyHandler(hitTimer_Fire);
        }

        void hitTimer_Fire()
        {
            this.Sprite.TextureIndex = 0;
            this.hitTimer.Stop();
        }
        public virtual void TakeDamage(double iznosStete)
        {
            this.Health -= iznosStete;
            if (this.Health <= 0)
            { this.Explode(); this.Remove(); }
        }
        public virtual void Explode()
        {
             if (this.ExplosionSpriteSheet != null)
               { 
                    new EffectNode(this.ExplosionSpriteSheet, this.Position); 
               }
        }
        public void Remove()
        {
            Node.Nodes.Remove(this);
            PlayerShip.PlayerShips[0].CollisionList.Remove(this);
        }
    }
}

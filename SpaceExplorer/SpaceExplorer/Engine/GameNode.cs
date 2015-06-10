using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
    }
}

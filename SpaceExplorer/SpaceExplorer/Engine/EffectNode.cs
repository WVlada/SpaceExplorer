using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace SpaceExplorer.Engine
{
    class EffectNode : Node
    {
        public EffectNode(SpriteSheet spriteSheet, Vector2 position  )
            : base(spriteSheet) 
        {
            this.Position = position;
            this.Sprite.KrajLoopa += new NotifyHandler(Sprite_KrajLoopa);
        }

        void Sprite_KrajLoopa()
        {
            Nodes.Remove(this);
        }

    }
}

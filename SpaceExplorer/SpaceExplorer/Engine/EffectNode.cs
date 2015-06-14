using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace SpaceExplorer.Engine
{
    class EffectNode : Node
    {
        public EffectNode(SpriteSheet spriteSheet, Vector2 position, Node nod)
            : base(spriteSheet) 
        {
            this.Position = CentrirajEksploziju(position,nod);
            this.Sprite.KrajLoopa += new NotifyHandler(Sprite_KrajLoopa);
        }

        void Sprite_KrajLoopa()
        {
            Nodes.Remove(this);
        }
        float x;
        float y;
        Vector2 CentrirajEksploziju(Vector2 polozajNoda, Node nod)
        {
            if (nod.Sprite.Origin.X < this.Sprite.Origin.X)
            { x = polozajNoda.X - (this.Sprite.Origin.X - nod.Sprite.Origin.X); }
            else
            { x = polozajNoda.X + (this.Sprite.Origin.X - nod.Sprite.Origin.X); }

            if (nod.Sprite.Origin.Y < this.Sprite.Origin.Y)
            { y = polozajNoda.Y - (this.Sprite.Origin.Y - nod.Sprite.Origin.Y); }
            else
            { y = polozajNoda.Y + (this.Sprite.Origin.Y - nod.Sprite.Origin.Y); }

            return new Vector2(x, y);
        }
    }
}

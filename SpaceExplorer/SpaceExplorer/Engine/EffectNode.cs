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
            this.Position = CentrirajEksploziju(position,this, nod);
            this.Sprite.KrajLoopa += new NotifyHandler(Sprite_KrajLoopa);
        }

        void Sprite_KrajLoopa()
        {
            Nodes.Remove(this);
        }
        float x;
        float y;
        Vector2 CentrirajEksploziju(Vector2 polozajNodaKojiTrebaDaEksplodira, EffectNode nodeEfekat, Node nod)
        {
            if (nodeEfekat.Sprite.Origin.X < nod.Sprite.Origin.X)//ako je eksplozija manja
            { x = polozajNodaKojiTrebaDaEksplodira.X + nod.Sprite.Origin.X - nodeEfekat.Sprite.Origin.X; }
            else // ako je eksplozija veca
            { x = polozajNodaKojiTrebaDaEksplodira.X + nod.Sprite.Origin.X - nodeEfekat.Sprite.Origin.X; }

            if (nodeEfekat.Sprite.Origin.Y < this.Sprite.Origin.Y)
            { y = polozajNodaKojiTrebaDaEksplodira.Y + nod.Sprite.Origin.Y - nodeEfekat.Sprite.Origin.Y; }
            else
            { y = polozajNodaKojiTrebaDaEksplodira.Y + nod.Sprite.Origin.Y - nodeEfekat.Sprite.Origin.Y; }

            return new Vector2(x, y);
        }
    }
}

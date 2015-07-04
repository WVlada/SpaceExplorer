using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using SpaceExplorer.Game;

namespace SpaceExplorer.Engine
{
    class Sun : GameNode
    {
        public Sun(SpriteSheet spriteSheet) : base(spriteSheet) 
        {
            this.Position = new Vector2(Config.velicinaGameplayprozoraHorizontala / 2 - this.Sprite.Origin.X, Config.velicinaGameplayprozoraVertikala / 2 - this.Sprite.Origin.Y);
        }
    }

}

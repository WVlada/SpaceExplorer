using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SpaceExplorer.Engine;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Game
{
    class ShipEngine : Node
    {
        public ShipEngine(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            this.Position = PlayerShip.PlayerShips[0].Position;
        }

        public float daljinaOdTeksture = 25;

        public override void Update(GameTime gameTime)
        {
            this.Position = PlayerShip.PlayerShips[0].Position + PlayerShip.PlayerShips[0].Sprite.Origin - this.Sprite.Origin + new Vector2(0, PlayerShip.PlayerShips[0].Sprite.Height + daljinaOdTeksture);
        }

    }
}

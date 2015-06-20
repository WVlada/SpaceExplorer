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

        // i cropovao sam engine sa top strane
        public float daljinaOdTeksture = 0;

        public override void Update(GameTime gameTime)
        {
            //this.Position = PlayerShip.PlayerShips[0].Position + PlayerShip.PlayerShips[0].Sprite.Origin - this.Sprite.Origin + new Vector2(0, PlayerShip.PlayerShips[0].Sprite.Height + daljinaOdTeksture);
            this.Position = new Vector2(PlayerShip.PlayerShips[0].Position.X + PlayerShip.PlayerShips[0].Sprite.Origin.X - this.Sprite.Origin.X, PlayerShip.PlayerShips[0].Position.Y + PlayerShip.PlayerShips[0].Sprite.Height + daljinaOdTeksture);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.Sprite.Texture, this.Position + new Vector2(100, -64), this.Sprite.FrameBounds, Color.White, Player.Players[0].Ship.rotationAngle, new Vector2(100, -64), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(this.Sprite.Texture, this.Position + new Vector2(this.Sprite.Width / 2, -PlayerShip.PlayerShips[0].Sprite.Height / 2), this.Sprite.FrameBounds, Color.White, Player.Players[0].Ship.rotationAngle, new Vector2(this.Sprite.Width / 2, -PlayerShip.PlayerShips[0].Sprite.Height / 2), 1f, SpriteEffects.None, 0f);
        }

    }
}

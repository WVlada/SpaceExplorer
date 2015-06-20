using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SpaceExplorer.Engine;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Game
{
    class ShipHealthBar : Node
    {
        public ShipHealthBar(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            this.Position = PlayerShip.PlayerShips[0].Position;
        }

        public int daljinaOdTeksture = 40;
        public int DuzinaHealthBara;
        public float koeficijent;

        public override void Update(GameTime gameTime)
        {
            this.destinationRectangle = new Rectangle((int)PlayerShip.PlayerShips[0].Position.X, (int)PlayerShip.PlayerShips[0].Position.Y - daljinaOdTeksture, (int)DuzinaHealthBara, 8);
            koeficijent = (float)PlayerShip.PlayerShips[0].Health / Config.PlayerShipHealth;
            
            this.Position = PlayerShip.PlayerShips[0].Position;
            
            this.DuzinaHealthBara = (int)(koeficijent* PlayerShip.PlayerShips[0].Sprite.Width); // (int)PlayerShip.PlayerShips[0].Health % (int)PlayerShip.PlayerShips[0].Sprite.Width;
            // ako je ovo full health 
            // trnutni health / ukupnim healtom --- u izonosu izmedju 0 i 1
            // sa tim ttreba da mnozim player width
        }

        public Rectangle destinationRectangle;
        public override void Draw(SpriteBatch spriteBatch)
        {
          spriteBatch.Draw(Config.ShipHealthBar.Teksture[0], this.Position + new Vector2(PlayerShip.PlayerShips[0].Sprite.Width / 2, PlayerShip.PlayerShips[0].Sprite.Height / 2), destinationRectangle, Color.Green, Player.Players[0].Ship.rotationAngle, new Vector2(PlayerShip.PlayerShips[0].Sprite.Width / 2, daljinaOdTeksture + PlayerShip.PlayerShips[0].Sprite.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}

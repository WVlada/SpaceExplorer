using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;

namespace SpaceExplorer.Game
{
    class PlayerShip : Ship
    {
        public static List<GameNode> PlayerShips = new List<GameNode>();

        public ShipEngine shipEngine;

        public PlayerShip(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            PlayerShips.Add(this);
            this.Speed = Config.PlayerShipSpeed;
            this.Health = Config.PlayerShipHealth;
            this.Position = Config.PlayerShipSpawnPosition;
            this.CollisionList = new List<GameNode>();

            this.shipEngine = new ShipEngine(Config.PlayerShipEngine);
        }

    }
}

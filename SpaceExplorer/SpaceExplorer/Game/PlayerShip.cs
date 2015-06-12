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
        public ShipHealthBar shipHealthBar;

        public PlayerShip(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            PlayerShips.Add(this);
            this.Speed = Config.PlayerShipSpeed;
            this.Health = Config.PlayerShipHealth;
            this.Position = Config.PlayerShipSpawnPosition;
            this.CollisionList = new List<GameNode>();

            this.shipEngine = new ShipEngine(Config.PlayerShipEngine);
            this.shipHealthBar = new ShipHealthBar(Config.ShipHealthBar);
        }
        
        public override void Update(GameTime gameTime)
        {
            if (this.CollisionList != null)
            {
                for (int i = CollisionList.Count - 1; i >= 0; i--)
                {
                    if (Node.CheckCollision(PlayerShip.PlayerShips[0], PlayerShip.PlayerShips[0].CollisionList[i]))
                    { this.Collide(this.CollisionList[i]); }
                    //this mi zamenjjuje -> PlayerShip.PlayerShips[0]
                }
            }
            base.Update(gameTime);
        }

        public void Collide(GameNode nodeSaKojimSamSeSudario)
        {
            this.TakeDamage(nodeSaKojimSamSeSudario.Health);
            nodeSaKojimSamSeSudario.TakeDamage(this.Health);
            //ovde mi je greska, jer u drugom updajtu, vrednost helta enemija je -80, pa to oduzimam od mog helta...
            // znaci moram da implamentiram Remove()
        }
        public override void TakeDamage(double iznosStete)
        // znaci ne mogu i GameNode i PlayerShip da imaju TakeDamage metod, tome sluzi VIRTUAL metod
        {
            this.Health -= iznosStete;
        }
    }
}

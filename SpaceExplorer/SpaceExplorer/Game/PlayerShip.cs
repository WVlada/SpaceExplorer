﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using SpaceExplorer.Engine;

namespace SpaceExplorer.Game
{
    delegate void RenderujSistem(object sender, EventArgs e);
    
    class PlayerShip : Ship
    {
        public static List<GameNode> PlayerShips = new List<GameNode>();

        public ShipEngine shipEngine;
        public ShipHealthBar shipHealthBar;
        public event RenderujSistem sudarSaSistemom;

        public PlayerShip(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            PlayerShips.Add(this);
            this.Speed = Config.PlayerShipSpeed;
            this.Health = Config.PlayerShipHealth;
            this.Position = Config.PlayerShipSpawnPosition;
            this.CollisionList = new List<GameNode>();

            this.rotationAngle = 0f;
            this.shipEngine = new ShipEngine(Config.PlayerShipEngine);
            this.shipHealthBar = new ShipHealthBar(Config.ShipHealthBar);
            this.ExplosionSpriteSheet = Config.PlayerShipExplosionSpriteSheet;
        }
        
        public override void Update(GameTime gameTime)
        {
            if (this.CollisionList != null)
            {
                for (int i = CollisionList.Count - 1; i >= 0; i--)
                {
                    if (this.CollisionList.Count != 0)
                    {
                        if (Node.CheckCollision(PlayerShip.PlayerShips[0], PlayerShip.PlayerShips[0].CollisionList[i]))
                        { this.Collide(this.CollisionList[i]); }
                        //this mi zamenjjuje -> PlayerShip.PlayerShips[0]
                    }
                }
            }
            base.Update(gameTime);
        }
        
        public void Collide(GameNode nodeSaKojimSamSeSudario)
        {
            if (nodeSaKojimSamSeSudario is Sistem) { Config.TrenutniPogledi[0] = new SistemView(nodeSaKojimSamSeSudario); }
            else
            this.TakeDamage(nodeSaKojimSamSeSudario.Health);
            nodeSaKojimSamSeSudario.TakeDamage(this.Health);
            //ovde mi je greska, jer u drugom updajtu, vrednost helta enemija je -80, pa to oduzimam od mog helta...
            // znaci moram da implamentiram Remove()
        }
        public override void TakeDamage(double iznosStete)
        // znaci ne mogu i GameNode i PlayerShip da imaju TakeDamage metod, tome sluzi VIRTUAL metod
        {
            this.Health -= iznosStete;
            if (this.Health <= 0)
            { this.Explode(); PlayerShip.PlayerShips.Remove(this); 
              Nodes.Remove(this); Nodes.Remove(this.shipHealthBar); 
              Nodes.Remove(this.shipEngine); this.CollisionList.Clear(); 
            // moram sve poskidati, jer dobijam index out of range - svi ovi nodovi
            // zavise od polozaja playershipa za crtanje, a njega vise nema
            }
        }
        public float rotationAngle;
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Texture, this.Position + this.Sprite.Origin, this.Sprite.FrameBounds, Color.White, this.rotationAngle, this.Sprite.Origin , 1f, SpriteEffects.None, 0f);
        }

        // pomeranje svake sekunde za po (1,1)
        Timer tajmer;
        public void Makac()
        {
            tajmer = new Timer();
            tajmer.Start(1);
            tajmer.Fire += new NotifyHandler(tajmer_Fire);
        }
        void tajmer_Fire()
        {
            this.Direction = new Vector2(1, 1);
            tajmer.Stop();
        }

        public void PomeriSe()
        {
            if (Config.currentSpeed > 200) { Config.currentSpeed = 200; }
            if (Config.currentSpeed <= 0) { Config.currentSpeed = 0; }
            // jer su u xna-u 0 rotacija sprajta je udesno
            Vector2 pravac = new Vector2((float)Math.Sin(rotationAngle), - (float)Math.Cos(rotationAngle));
            pravac.Normalize();
            this.Move(pravac*Config.currentSpeed);
        }
    }
}

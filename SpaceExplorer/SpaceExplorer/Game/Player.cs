using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceExplorer.Engine;

namespace SpaceExplorer.Game
{
    class Player
    {
        public static Player[] Players;//array svih playera
        public PlayerShip Ship;//player ima ship
        KeyboardState lastKeyboardState;
        
        static Player()
        {
         Players = new Player[4];
         for (int i = 0; i < Players.Length; i++)
            {
             Players[i] = new Player();
            }
         SpawnShip(PlayerIndex.One);
        }
        // staticki kontruktor se automatski poziva pre bilo kakvog pozivanja bilo kog membera
        // ne moze se pozvati direktno
        // zasto mi onda baca exception kad hocu da registrujem event za brod, da je brod NULL?

        public static void SpawnShip(PlayerIndex playerIndex)
        {
            if (Players[(int)playerIndex].Ship == null)
            { Players[(int)playerIndex].Ship = new PlayerShip(Config.ShipSpriteSheets[(int)playerIndex]); }
        
        }

        public static void ProcessInput()
        {
            for (int i = 0; i < Players.Length; i++)
            { Players[i].ProcessInput((PlayerIndex)i); }
        }
        
        void ProcessInput(PlayerIndex playerIndex)
        {
            KeyboardState keystate = Keyboard.GetState(playerIndex);

            if (this.Ship == null)
                { if (keystate.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)) { SpawnShip(PlayerIndex.One); } }
            if (playerIndex == PlayerIndex.One)
                {
                    //Ship.Direction = new Vector2(0, 0);
                    if (keystate.IsKeyUp(Keys.Up)) { Config.currentSpeed -= 0.2f; this.Ship.PomeriSe(); }
                    if (keystate.IsKeyDown(Keys.A)) { this.Ship.Makac(); }
                    if (keystate.IsKeyDown(Keys.Up)) { Config.currentSpeed += 0.3f; this.Ship.PomeriSe(); }
                    if (keystate.IsKeyDown(Keys.Down)) { Config.currentSpeed -= 0.3f; this.Ship.PomeriSe(); }//sada radi duplo u stvari
                    if (keystate.IsKeyDown(Keys.Left))  { this.Ship.rotationAngle -= 0.05f; }
                    if (keystate.IsKeyDown(Keys.Right)) { this.Ship.rotationAngle += 0.05f; }
                }
            lastKeyboardState = keystate;
        }   
    }
}

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
        {Players = new Player[4];
         for (int i = 0; i < Players.Length; i++)
         {Players[i] = new Player();}}

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
                    Ship.Direction = new Vector2(0, 0); 
                    
                    if (keystate.IsKeyDown(Keys.Up)) { Ship.Direction.Y -= 2; }
                    if (keystate.IsKeyDown(Keys.Down))  { Ship.Direction.Y += 2; }
                    if (keystate.IsKeyDown(Keys.Left))  { this.Ship.rotationAngle += 0.05f; }
                    if (keystate.IsKeyDown(Keys.Right)) { this.Ship.rotationAngle -= 0.05f; }
                }
            lastKeyboardState = keystate;
        }   
    }
}

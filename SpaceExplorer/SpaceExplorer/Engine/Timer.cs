using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Engine
{
    delegate void NotifyHandler();

    class Timer
    {
        static List<Timer> Timers = new List<Timer>();
        private double timeRemaining;
        private double trajanje;
        public event NotifyHandler Fire;

        public void Start(double trajanje)
        {
            Timers.Remove(this);
            Timers.Add(this);
            this.trajanje = trajanje;
            this.timeRemaining = trajanje;
        }
        public void Stop()
        {
            Timers.Remove(this);
        }
        public static void Update(GameTime gameTime)
        {
            for (int i = Timers.Count - 1; i >= 0; i--)
            {   
                Timer timer = Timers[i];
                timer.timeRemaining -= gameTime.ElapsedGameTime.TotalSeconds;
                if (timer.timeRemaining <= 0)
                { timer.Fire(); timer.timeRemaining = timer.trajanje; }
            }
        }
    }
}

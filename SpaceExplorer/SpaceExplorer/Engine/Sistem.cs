using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceExplorer.Engine
{
    class Sistem : Node
    {
        public string Ime;
        public Vector2 Pozicija;
        //vec ima sprite
        public Sistem(SpriteSheet spriteSheet, string name, Vector2 position) : base(spriteSheet)
        {
            this.Ime = name;
            this.Pozicija = position;

            GalaxyView.Sistemi.Add(this);
        }
    }
}

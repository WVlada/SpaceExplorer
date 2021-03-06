﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Text;

namespace SpaceExplorer.Engine
{
    class PlanetMenuView : MenuToolbarView
    {
        public static Texture2D teksturaMenija;

        public static void UcitajPozadinu(ContentManager content)
        {
            teksturaMenija = content.Load<Texture2D>("PlanetMenu");

        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(teksturaMenija, new Rectangle(0, 0, base.horizontalSize, base.verticalSize), Color.White);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Engine
{
    class NapraviPrimitive
    {
        static Random randomBroj = new Random();
        public static Vector2 randomMEstoZaPlanetu(View vju, int brojplaneta, int brojOvePlanete, SpriteSheet sprajtKojiSeCrta, double nakrivX = 0f, double nakrivY = 0f, int X = 0, int Y = 0)
        {
            Vector2 pozicija = new Vector2();
            // ovde cu pozvati radijuse
            List<Vector2> listaVectora2 = new List<Vector2>();
            List<int> ListaRadijusa = new List<int>();
            
            // ovo vraca listu radijusa
            ListaRadijusa = NekaFunkcija(vju, brojplaneta);  
            
            
            int m = ListaRadijusa[brojOvePlanete-1];
            listaVectora2 = NapraviPozicijeZaKrug(vju, m, sprajtKojiSeCrta, nakrivX, nakrivY, X, Y);
			            
            int V = randomBroj.Next(0, listaVectora2.Count);
            pozicija = listaVectora2[V];
            return pozicija;
        }

        static Random zaRasporedPlaneta = new Random();
        private static List<int> NekaFunkcija(View vju, int brojPlaneta)
        {
            List<int> polozaji = new List<int>();
            int ceosistem = vju.horizontalSize / 2;
            int korak = ceosistem / brojPlaneta;
            for (int i = 1; i <= brojPlaneta ; i++)
			{
                polozaji.Add(korak*i);
                
			}
            return polozaji;
        }
        static List<Vector2> NapraviPozicijeZaKrug(View vju, int radius, SpriteSheet sprajtKojiSeCrta, double nakrivX = 0f, double nakrivY = 0f, int X = 0, int Y = 0)
        {
            List<Vector2> neki = new List<Vector2>();
            //double angleStep = 80f / radius;
            //double angleStep = Math.PI / 2;//za krst
            Vector2 pozicija1 = new Vector2();
            if (X != 0 && Y != 0)
            {
                Vector2 pozicija2 = new Vector2(X - sprajtKojiSeCrta.TileWidth /2, Y - sprajtKojiSeCrta.TileHeight / 2);
                pozicija1 = pozicija2;
            }
            else
            {
                Vector2 pozicija2 = new Vector2(vju.horizontalSize / 2 - radius - sprajtKojiSeCrta.TileWidth / 2, vju.verticalSize / 2 - radius - sprajtKojiSeCrta.TileHeight / 2);
                pozicija1 = pozicija2;
            }

            double angleStep = Math.PI / 24;
            double NakrivljenjeX = nakrivX;
            double NakrivljenjeY = nakrivY;
            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle + NakrivljenjeX)) + (int)pozicija1.X;
                int y = (int)Math.Round(radius + radius * Math.Sin(angle + NakrivljenjeY)) + (int)pozicija1.Y;
                neki.Add(new Vector2(x, y));
            }
            return neki;
        }

        public Texture2D NapraviKrug(GraphicsDevice graphicDevice, int radius)
        {
            int spoljniradius = radius * 2 + 2; // da krug ne izadnje iz granica
            Texture2D tekstura = new Texture2D(graphicDevice, spoljniradius, spoljniradius);

            Color[] data = new Color[spoljniradius * spoljniradius];

            // prvo neka sve bude transparentno
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Transparent;
            }
            // minimalni korak?
            double angleStep = 0.5f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                // koristimo parametric definiciju kruga sa wikipedije
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * spoljniradius + x + 1] = Color.White;
                data[y * spoljniradius + x] = Color.White;

            }
            tekstura.SetData<Color>(data);
            return tekstura;

        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZakladniCtverecek
{
    public class Hra : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private int sirkaOkna = 800;
        private int vyskaOkna = 600;

        private Ctverecek ctverecek;

        public Hra()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = sirkaOkna;
            graphics.PreferredBackBufferHeight = vyskaOkna;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            int velikostCtverecku = 50;
            int rychlostCtverecku = 5;

            ctverecek = new Ctverecek(velikostCtverecku, rychlostCtverecku, Color.Black, (sirkaOkna - velikostCtverecku) / 2, (vyskaOkna - velikostCtverecku) / 2, GraphicsDevice, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ctverecek.aktualizovat();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            ctverecek.vykreslit(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

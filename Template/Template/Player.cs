using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class Player
    {
        Vector2 position;
        Texture2D texture;
        Vector2 velocity;
        const float GRAVITY = 9.82f;
        Rectangle hitbox;
        List<Block> BlockLista;
        double SenasteHopp;


        bool Hopp = true;


        public Player(Texture2D texture, Vector2 position, List<Block> BlockLista)
        {
            this.position = position;
            this.texture = texture;
            this.BlockLista = BlockLista;
        }

        public void Update(GameTime gameTime)
        {

            hitbox = new Rectangle((int)position.X, (int)position.Y, 50, 50);

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                position.X++;



            if (Keyboard.GetState().IsKeyDown(Keys.A))
                position.X--;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Hopp)
            {
                velocity.Y = -5;
                position.Y -= 5;
                Hopp = false;
                SenasteHopp = gameTime.ElapsedGameTime.TotalSeconds;
            }


            velocity.Y += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Block block in BlockLista)
            {
                if (hitbox.Intersects(block.GetBlockHitbox()))
                {
                    velocity.Y = 0;
                    Hopp = true;
                }

            }
            

            position += velocity;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Hopp)
            {
                spriteBatch.Draw(texture, hitbox, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, hitbox, Color.Green);
            }

        }
    }
}





using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class Block: BasBlock
    {

        int size;

        List<Block> BlockLista;

        Rectangle hitbox;

        public Block(Texture2D texture, Vector2 position, int size, List<Block> BlockLista) : base (position, texture)
        {

            this.size = size;
            this.BlockLista = BlockLista;

            hitbox = new Rectangle((int)position.X, (int)position.Y, size, 30);
        }

        public Rectangle GetBlockHitbox()
        {
            return hitbox;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

                spriteBatch.Draw(texture, hitbox, Color.Green);

        }
    }
}




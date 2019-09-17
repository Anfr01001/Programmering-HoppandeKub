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

        float transperancy = 255;
        float ChangeRateTrans = 70;



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

        public override void Update(GameTime gameTime)
        {
            transperancy -= ChangeRateTrans * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (transperancy < 0)
            {
                hitbox.X = 9999;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, hitbox, new Color(Color.Green, (int)transperancy));

        }
    }
}




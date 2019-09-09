using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class BasBlock
    {

        protected Vector2 position;
        protected Texture2D texture;

        public BasBlock(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

    }
}

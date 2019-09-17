using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Pixel;

        MouseState MState;
        Vector2 MousePos;

        Player player;


        List<Block> BlockLista = new List<Block>();

        void CreatePixel()
        {
            Pixel = new Texture2D(GraphicsDevice, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            CreatePixel();

            //block = new Block(Pixel, new Vector2(200, 300), 200);
            BlockLista.Add(new Block(Pixel, new Vector2(200, 300), 200, BlockLista));
            player = new Player(Pixel, new Vector2(300, 0), BlockLista);


            
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            foreach (Block block in BlockLista)
            {
                block.Update(gameTime);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                MState = Mouse.GetState();
                MousePos = new Vector2(MState.X, MState.Y);
                BlockLista.Add(new Block(Pixel, MousePos, 200, BlockLista));
            }




            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            player.Draw(spriteBatch);

            foreach (Block block in BlockLista)
            {
                block.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}









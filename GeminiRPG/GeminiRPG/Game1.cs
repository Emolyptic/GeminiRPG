using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GeminiRPG
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Vector2 mPosition = new Vector2(0, 0);
		CharacterSprite Player;
		Level Level1;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			Player = new CharacterSprite();
			Level1 = new Level();
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			

			// TODO: use this.Content to load your game content here
			Player.LoadContent(this.Content, "Characters/Jean Sprite");
			Level1.LoadContent(this.Content);

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			Player.Update(gameTime);
			for (int i = 0; i < Level1.wall.Length; i++)
			{
				if (IntersectPixel(Player.top, Player.textureData, Level1.wallRectangle[i], Level1.wallTextureData))
					Console.WriteLine("TOP");

				if (IntersectPixel(Player.bottom, Player.textureData, Level1.wallRectangle[i], Level1.wallTextureData))
					Console.WriteLine("BOTTOM");

				if (IntersectPixel(Player.left, Player.textureData, Level1.wallRectangle[i], Level1.wallTextureData))
					Console.WriteLine("LEFT");

				if (IntersectPixel(Player.right, Player.textureData, Level1.wallRectangle[i], Level1.wallTextureData))
					Console.WriteLine("RIGHT");
			}
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
			{
				Player.Position = new Vector2(Player.Position.X, Player.Position.Y + 1);
			}

			if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
			{
				Player.Position = new Vector2(Player.Position.X, Player.Position.Y - 1);
			}

			if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
			{
				Player.Position = new Vector2(Player.Position.X - 1, Player.Position.Y);
			}

			if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
			{
				Player.Position = new Vector2(Player.Position.X + 1, Player.Position.Y);
			}

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			Level1.Draw(this.spriteBatch);
			Player.Draw(this.spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}

		static bool IntersectPixel(Rectangle rect1, Color[] data1,
									Rectangle rect2, Color[] data2)
		{
			int top = Math.Max(rect1.Top, rect2.Top);
			int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
			int left = Math.Max(rect1.Left, rect2.Left);
			int right = Math.Min(rect1.Right, rect2.Right);


			for (int y = top; y < bottom; y++)
			{
				for (int x = left; x < right; x++)
				{
					Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
					Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

					if (color1.A != 0 && color2.A != 0)
						return true;
				}
			}
			return false;
		}
		

				
	}
}

	
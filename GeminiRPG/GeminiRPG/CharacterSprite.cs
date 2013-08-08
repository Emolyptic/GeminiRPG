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
	class CharacterSprite
	{
		//CHARACTER SPRITES ARE IN TWO PARTS: LOWER HALF IS THE COLLISION HALF UPPER HALF IS PASSABLE

		
		public Vector2 Position = new Vector2(160, 160);
		public Texture2D spriteTexture;
		//public Rectangle spriteRect;

		//Movement Rectangles
		public Rectangle top;
		public Rectangle bottom;
		public Rectangle right;
		public Rectangle left;


		//public Texture2D boundingBox;
		public Color[] textureData;

		//Load the texture for the sprite using the Content Pipeline
		public void LoadContent(ContentManager theContentManager, string theAssetName)
		{
			//boundingBox = theContentManager.Load<Texture2D>("Characters/BoundingBox");
			spriteTexture = theContentManager.Load<Texture2D>(theAssetName);

			textureData = new Color[spriteTexture.Width * spriteTexture.Height];
			spriteTexture.GetData(textureData);
		}

		//Draw the sprite to the screen
		public void Draw(SpriteBatch theSpriteBatch)
		{
			//theSpriteBatch.Draw(boundingBox, new Vector2 (Position.X - 3.5f ,Position.Y -3.5f) , Color.White);
			theSpriteBatch.Draw(spriteTexture, Position, Color.White);
		}

		public void Update(GameTime gameTime)
		{
			//spriteRect = new Rectangle((int)Position.X, (int)Position.Y, spriteTexture.Width, spriteTexture.Height);
			top = new Rectangle((int)Position.X, (int)Position.Y - 32, spriteTexture.Width-4, 4);
			bottom = new Rectangle((int)Position.X, (int)Position.Y + 32, spriteTexture.Width-4, 4);
			right = new Rectangle((int)Position.X + 32 , (int)Position.Y, 4, spriteTexture.Height-4);
			left = new Rectangle((int)Position.X - 32, (int)Position.Y, 4, spriteTexture.Height-4);
		}

	}
}

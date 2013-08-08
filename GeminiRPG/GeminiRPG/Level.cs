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
	enum TileType {Passable, Unpassable};
	class Level
	{
		public Texture2D[] wall;
		public Rectangle[] wallRectangle;
		public Texture2D[] blank;

		public Color[][] wallTextureData;

		public Level()
		{
			wall = new Texture2D[38];
			blank = new Texture2D[62];
			wallTextureData = new Color[38][];
			wallRectangle = new Rectangle[38];
		}

		public void LoadContent(ContentManager theContentManager)
		{
			for (int i = 0; i < 38; i++) 
			{
				wall[i] = theContentManager.Load<Texture2D>("Levels/Wall");
				wallTextureData[i] = new Color[wall[i].Width * wall[i].Height];
				wall[i].GetData(wallTextureData[i]);
				wallRectangle[i] = new Rectangle(0, 0, wall[i].Width, wall[i].Height);
			}
			for (int q = 0; q < 11; q++)
				wallRectangle[q] = new Rectangle(0, q * 32, wall[q].Width, wall[q].Height);
			
			for (int w = 0; w < 11; w++)
				wallRectangle[w+10] = new Rectangle(320, w * 32, wall[w+10].Width, wall[w+10].Height);

			for (int e = 1; e < 10; e++)
				wallRectangle[e + 19] = new Rectangle(e * 32, 0, wall[e + 19].Width, wall[e + 19].Height);
			
			for (int h = 1; h < 10; h++)
				wallRectangle[h + 28] = new Rectangle(h * 32, 320, wall[h + 28].Width, wall[h + 28].Height);
			
			for (int k = 0; k < 62; k++)
			{
				blank[k] = theContentManager.Load<Texture2D>("Levels/Blank");
			}
		}

		//Draw the sprite to the screen
		public void Draw(SpriteBatch theSpriteBatch)
		{
			for(int i = 1 ; i < 10; i++)
			{
				for (int j = 1; j < 10; j++)
				{
					theSpriteBatch.Draw(blank[i], new Vector2(i * 32,j * 32), Color.White);
				}
			}

			for (int q = 0; q < 11; q++)
			{
				theSpriteBatch.Draw(wall[q], new Vector2(0, q * 32), Color.White);

			}
			for (int w = 0; w < 11; w++)
			{
				theSpriteBatch.Draw(wall[w + 10], new Vector2(320, w * 32), Color.White);
			}
			for (int e = 1; e < 10; e++)
			{
				theSpriteBatch.Draw(wall[e + 19], new Vector2(e * 32, 0), Color.White);
			}
			for (int h = 1; h < 10; h++)
			{
				theSpriteBatch.Draw(wall[h + 28], new Vector2(h * 32, 320), Color.White);
			}
		}

	}
}

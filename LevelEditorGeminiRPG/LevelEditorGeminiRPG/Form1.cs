using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LevelEditorGeminiRPG
{
	public partial class Form1 : Form
	{
		List<PictureBox> Tiles;
		PictureBox[][] Map;

		public Form1()
		{
			InitializeComponent();
			Tiles = new List<PictureBox>();
			Map = new PictureBox[20][];
			CreateGrid();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void loadTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();

			// allow multiple selection
			d.Multiselect = true;

			// filter the desired file types
			d.Filter = "JPG |*.jpg|PNG|*.png|BMP|*.bmp";

			// show the dialog and check if the selection was made

			//this.pictureBox1.

			if (d.ShowDialog() == DialogResult.OK)
			{
				foreach (string image in d.FileNames)
				{
					// create a new control
					PictureBox pb = new PictureBox();

					//pb.Tag = tag;
					//btn.Tag = tag;
					pb.MouseDown += pictureBox_MouseDown;
					
					// assign the image
					pb.Image = new Bitmap(image);

					//listaImagens.Add(new Bitmap(image));

					// stretch the image
					pb.SizeMode = PictureBoxSizeMode.StretchImage;

					// set the size of the picture box
					pb.Height = 32;
					pb.Width = 32;

					// add the control to the container
					this.flowLayoutPanel1.Controls.Add(pb);
					this.flowLayoutPanel1.AutoScroll = true;
					//this.pictureBox1.Autoscroll = true;

					Tiles.Add(pb);
					//tag++;

				}

			}


		}

		private void pictureBox_MouseDown(object sender, EventArgs e)
		{ 
			this.pictureBox1.Image = (PictureBox)sender.Image;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void CreateGrid()
		{

		}






	}
}

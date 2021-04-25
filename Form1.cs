using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private int[] red=new int[256];
        private int[] green = new int[256];
        private int[] blue = new int[256];
        
        private int szer;
        private int wys;
        public Form1()
        {

            InitializeComponent();
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                  
                    pictureBox1.Load(file.FileName);
                    szer = pictureBox1.Image.Width;
                    wys = pictureBox1.Image.Height;
                    pictureBox2.Image = new Bitmap(szer, wys);
                    pictureBox1.Invalidate();
                }
            }




        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            /*if (path != String.Empty) {
                g.DrawImage(im,new Point(0,0));
               
            }*/

        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             if (path != String.Empty)
             {
                 g.DrawImage(img, new Point(0, 0));

             }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             if (path != String.Empty)
             {
                 g.DrawImage(img, new Point(0, 0));

             }*/
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;

            trackBar1.Maximum = 126;
            trackBar1.Minimum = 0;

            trackBar2.Maximum = 0;
            trackBar2.Minimum = -128;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;

            trackBar1.Maximum = 126;
            trackBar1.Minimum = 0;

            trackBar2.Maximum = 0;
            trackBar2.Minimum = -126;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            if (radioButton1.Checked)
                {

                    for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                          

                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                          
                            

                            red = (127 / (127 - trackBar1.Value)) * (red - trackBar1.Value);
                            green = (127 / (127 - trackBar1.Value)) * (green - trackBar1.Value);
                            blue = (127 / (127 - trackBar1.Value)) * (blue - trackBar1.Value);
                            if (red > 255)
                                red = 255;
                            else if (red < 0)
                                red = 0;
                            if (green > 255)
                                green = 255;
                            else if (green < 0)
                                green = 0;
                            if (blue > 255)
                                blue = 255;
                            else if (blue < 0)
                                blue = 0;

                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                            this.red[red] += 1;
                            this.green[green] += 1;
                            this.blue[blue] += 1;
                            pictureBox2.Invalidate();

                        }
                    }
                
                panel8.Invalidate();
                panel7.Invalidate();
                panel6.Invalidate();
               
            }
                else
                {
                for (int x = 0; x < 256; x++)
                {
                    this.red[x] = 0;
                    this.green[x] = 0;
                    this.blue[x] = 0;
                }
                for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                           
                        if (red < 127)
                                red = ((127 - trackBar1.Value) / 127) * red;
                            else
                                red = ((127 - trackBar1.Value) / 127) * red + (2 * trackBar1.Value);

                            if (green < 127)
                                green = ((127 - trackBar1.Value) / 127) * green;
                            else
                                green = ((127 - trackBar1.Value) / 127) * green + (2 * trackBar1.Value);


                            if (blue < 127)
                                blue = ((127 - trackBar1.Value) / 127) * blue;
                            else
                                blue = ((127 - trackBar1.Value) / 127) * blue + (2 * trackBar1.Value);
                            if (red > 255)
                                red = 255;
                            else if (red < 0)
                                red = 0;
                            if (green > 255)
                                green = 255;
                            else if (green < 0)
                                green = 0;
                            if (blue > 255)
                                blue = 255;
                            else if (blue < 0)
                                blue = 0;

                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                        this.red[red] += 1;
                        this.green[green] += 1;
                        this.blue[blue] += 1;
                        pictureBox2.Invalidate();

                        }
                    }

                }


            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            if (radioButton1.Checked)
                {
               
                for (int x = 0; x <szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            double red = c.R;
                            double green = c.G;
                            double blue = c.B;
                            

                            red = ((127 + (double)trackBar2.Value) / 127) * (red - (double)trackBar2.Value);
                            green = ((127 + (double)trackBar2.Value) / 127) * (green - (double)trackBar2.Value);
                            blue = ((127 + (double)trackBar2.Value) / 127) * (blue - (double)trackBar2.Value);
                   
                        

                            Color nowy = Color.FromArgb((int)red, (int)green, (int)blue);
                            xy.SetPixel(x, y, nowy);
                            this.red[(int)red] += 1;
                            this.green[(int)green] += 1;
                            this.blue[(int)blue] += 1;
                        

                        }

                    }
                pictureBox2.Invalidate();
                panel8.Invalidate();
                panel7.Invalidate();
                panel6.Invalidate();
            }
                else
                {
                for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                            

                        if (red < (127 + trackBar2.Value))
                            {
                                red = (127 / (127 + trackBar2.Value)) * red;
                            }
                            else if (red > (127 - trackBar2.Value))
                            {
                                red = (127 * red + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                red = 127;

                            if (green < (127 + trackBar2.Value))
                            {
                                green = (127 / (127 + trackBar2.Value)) * green;
                            }
                            else if (green > (127 - trackBar2.Value))
                            {
                                green = (127 * green + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                green = 127;

                            if (blue < (127 + trackBar2.Value))
                            {
                                blue = (127 / (127 + trackBar2.Value)) * blue;
                            }
                            else if (blue > (127 - trackBar2.Value))
                            {
                                blue = (127 * blue + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                blue = 127;


                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                        this.red[red] += 1;
                        this.green[green] += 1;
                        this.blue[blue] += 1;
                        pictureBox2.Invalidate();

                        }
                    }
                }

            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
          
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(blue, green, blue);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[blue] += 1;
                    this.green[green] += 1;
                    this.blue[blue] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //red
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(255, 0, 0);
            if (szer != 0) { 
            for (int x = 0; x < this.red.Length; x++)
            {

                g.DrawLine(new Pen(redo), new Point(x, panel8.Height),
                    new Point(x, panel8.Height-((this.red[x])/10)) );
            }
        }
            

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //green
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(0, 255, 0);
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel7.Height), new Point(x, panel7.Height - ((this.green[x]) / 10)));
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            //blue
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(0, 0, 255);
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel6.Height), new Point(x, panel6.Height - ((this.blue[x]) / 10)));
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(blue, green, red);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[blue] += 1;
                    this.green[green] += 1;
                    this.blue[red] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(green, red, blue);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[green] += 1;
                    this.green[red] += 1;
                    this.blue[blue] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(red, blue, green);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[red] += 1;
                    this.green[blue] += 1;
                    this.blue[green] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }
    }

}

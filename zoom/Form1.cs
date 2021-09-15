using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace zoom
{
    public partial class Form1 : Form
    {
        Image imgOriginal;

        public Form1()
        {
            InitializeComponent();
        }
        Image zoomimage(Image img, Size s)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * s.Width), Convert.ToInt32(img.Height * s.Height));
            Graphics g = Graphics.FromImage(bm);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;

        }

        PictureBox pp;

        public static string ConvertFromToTime( string timeHour, string inputFormat, string outputFormat)
        {
            var timeFromInput = DateTime.ParseExact(timeHour, inputFormat, null, DateTimeStyles.None);
            string timeOutput = timeFromInput.ToString(
                outputFormat,
                CultureInfo.InvariantCulture);
            return timeOutput;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

           



            //string time24 = "20:15:23";
            //DateTime dt = DateTime.ParseExact(time24, "HH:mm:ss", null, DateTimeStyles.None); ;
            //String time12 = dt.ToString("0h:mm:ss");


            //trackBar1.Minimum = 1;
            //trackBar1.Maximum = 6;
            //trackBar1.SmallChange = 1;
            //trackBar1.LargeChange = 1;
            //trackBar1.UseWaitCursor = false;
            //this.DoubleBuffered = true;
            //pp = new PictureBox();

            //pp.Image = pictureBox1.Image;

            imgOriginal = pictureBox1.Image;


            //trackBar1.Minimum = 200;
            //trackBar1.Maximum = 600;
            //pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            //pictureBox1.Top = (ClientSize.Height - pictureBox1.Height) / 2;
        }

        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                pictureBox1.Image = Zoom(imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
            }

            //pictureBox1.Size = new Size(trackBar1.Value, pictureBox1.Size.Height);
            //pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            //pictureBox1.Top = (ClientSize.Height - pictureBox1.Height) / 2;
            //if (trackBar1.Value != 0)
            //{
            //    pictureBox1.Image = null;
            //    pictureBox1.Image=zoomimage(pp.Image,new Size(trackBar1.Value,trackBar1.Value));

            //}
        }
    }
}

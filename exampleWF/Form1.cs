using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using exampleWF.Properties;
using System.Windows;

namespace exampleWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.MouseEnter += (s, e) => { button1.BackgroundImage = Resources._13011246; button1.ForeColor = Color.White; };
            button1.MouseLeave += (s, e) => { button1.BackgroundImage = null; button1.ForeColor = Color.Black; };
        }

        byte r;
        byte g;
        byte b;
        async void Button1_Click(object sender, EventArgs e)
        {
           
            Sound();
            Thread thread = new Thread(MyThread1);
            thread.Start();

            button1.MouseLeave += (s, a) => { button1.BackgroundImage = Resources._13011246; button1.Text = ""; };
            //button1.BackgroundImage = Resources._13011246; button1.Text = "";

            for ( r = 65, g = 105, b = 225; r <= 135 & g <= 206 & b <= 250; r +=3, g += 5, b +=1, await Task.Delay(100))
            {
                MyProgressBar();
            }

            pictureBox1.Image = Resources.wormsGranade;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            label1.ForeColor = Color.FromArgb(135, 206, 250);
            await Task.Delay(2500);

            pictureBox2.Image = Resources.wormsGun;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            // g = 205 поставить
            for ( r = 135, g = 206, b = 250; r <= 255 & g > 0 & b <= 255; r += 24, g -= 41, b += 1, await Task.Delay(150))
            {
                MyProgressBar();
            }
            
            label1.ForeColor = Color.FromArgb(255, 0, 255);
            await Task.Delay(2500);

            for ( r = 255, g = 0, b = 255; r >= 65 & g <= 105 & b >= 225; r -= 19, g += 10, b -= 3, await Task.Delay(50))
            {
                MyProgressBar();
            }
            label1.ForeColor = Color.FromArgb(65, 105, 225);
            await Task.Delay(2500);
            Close();
        }

        void MyThread1()
        {
            //progressBar1.Maximum = 36500;
            while(progressBar1.Value != 65500)
            {
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value++));
                
            }
        }
       
        void MyProgressBar()
        {

            label1.ForeColor = Color.FromArgb(r, g, b);

            progressBar2.Value = r;
            progressBar3.Value = g;
            progressBar4.Value = b;
        }

        void Sound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Resources.Worms___Hello);
            simpleSound.Play();
        }

    }
}

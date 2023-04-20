using Microsoft.Win32;
using System.Diagnostics;

namespace _2048LastVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(255, 0, 0);
            pictureBox3.BackColor = Color.FromArgb(255, 255, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 255, 0);
            pictureBox4.BackColor = Color.FromArgb(0, 0, 255);
            TextAnim(label1);
            AnimBord();
        }
        async void TextAnim(Label zx)
        {
        stars:
            char[] chrs = zx.Text.ToString().ToCharArray();
            zx.Text = "";
            for (int i = 0; i < chrs.Length; i++)
            {
                zx.Text += chrs[i].ToString();
                for (int ro = 0, go = 0, bo = 0; ro <= 190 & go <= 0 & bo <= 255; ro += 6, go += 0, bo += 8, await Task.Delay(5))
                {
                    zx.ForeColor = Color.FromArgb((int)ro, (int)go, (int)bo);
                }
                await Task.Delay(10);
            }
            await Task.Delay(2000);
            goto stars;
        }
        async void AnimBord()
        {
        start:
            for (int ro = 0, go = 0, bo = 0; ro <= 255 & go <= 0 & bo <= 0; ro += 13, go += 0, bo += 0, await Task.Delay(30))
            {
                pictureBox1.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 255 & go <= 255 & bo <= 0; ro += 13, go += 13, bo += 0, await Task.Delay(30))
            {
                pictureBox3.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 0 & go <= 255 & bo <= 0; ro += 0, go += 13, bo += 0, await Task.Delay(30))
            {
                pictureBox2.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 0 & go <= 0 & bo <= 255; ro += 0, go += 0, bo += 13, await Task.Delay(30))
            {
                pictureBox4.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            goto start;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new _2048Old().Show();
            Cheker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new _2048New().Show();
            Cheker();
        }
        private async void Cheker()
        {
            await Task.Run(() =>
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software"))
                {

                }
            });
        }
    }
}
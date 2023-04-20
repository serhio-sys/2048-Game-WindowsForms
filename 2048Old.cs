using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _2048LastVersion
{
    public partial class _2048Old : Form
    {
#pragma warning disable CS8625
        private int timeS = 0;
        private int timeM = 0;
        public int[,] mp = new int[4, 4];
        private int score = 6;
        public Label[,] labels = new Label[4, 4];
        public PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        private bool CriticalSit = false;
        private Label[] Score = new Label[9];
        public _2048Old()
        {
            CreateScoreList();

            if (File.Exists(@"C:\Users\Sergey\source\repos\2048LastVersion\2048LastVersion\bin\Debug\net6.0-windows\Score.txt"))
            {
                string[] score = File.ReadAllLines(@"C:\Users\Sergey\source\repos\2048LastVersion\2048LastVersion\bin\Debug\net6.0-windows\Score.txt");
                for (int i =0;i<score.Length;i++)
                {
                    Score[i].Text = score[i];
                }
            }
            KeyDown += new KeyEventHandler(KeyPressed);
            InitializeComponent();
            CreateMap();
            PictureBox picture = new PictureBox();
            picture.Location = new Point(7,59);
            picture.Size = new Size(345,345);
            picture.BackColor = Color.White;
            this.Controls.Add(picture);
            CreateStartBlocks();
            mp[0, 0] = 1;
            mp[0, 1] = 1;
            mp[1, 0] = 1;
            timer1.Start();
        }
        private void CreateScoreList()
        {
            for (int i =0;i<Score.Length;i++)
            {
                if (i<3) {
                    Score[i] = new Label();
                    Score[i].Font = new Font(new FontFamily("Microsoft Sans Serif"), 16);
                    Score[i].ForeColor = Color.White;
                    Score[i].Location = new Point(412, 84 + i * 31);
                    Score[i].Size = new Size(400, 36);
                    this.Controls.Add(Score[i]);
                }
                else
                {

                    Score[i] = new Label();
                    Score[i].Font = new Font(new FontFamily("Microsoft Sans Serif"), 16);
                    Score[i].ForeColor = Color.White;
                    Score[i].Location = new Point(412, 84 + i * 31);
                    Score[i].Size = new Size(400, 36);
                }
            }
        }
        private void CreateStartBlocks()
        {
            pictureBoxes[0, 0] = new PictureBox();
            pictureBoxes[0, 0].Location = new Point(12, 63);
            pictureBoxes[0, 0].Size = new Size(80, 80);
            pictureBoxes[0, 0].BackColor = Color.Yellow;
            labels[0, 0] = new Label();
            labels[0, 0].Text = "2";
            labels[0, 0].Size = new Size(80, 80);
            labels[0, 0].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 0].Font = new Font(new FontFamily("Arial Black"), 18);
            pictureBoxes[0, 0].Controls.Add(labels[0, 0]);
            this.Controls.Add(pictureBoxes[0, 0]);
            pictureBoxes[0, 0].BringToFront();



            pictureBoxes[0, 1] = new PictureBox();
            pictureBoxes[0, 1].Location = new Point(12 + 85, 63);
            pictureBoxes[0, 1].Size = new Size(80, 80);
            pictureBoxes[0, 1].BackColor = Color.Yellow;
            labels[0, 1] = new Label();
            labels[0, 1].Text = "2";
            labels[0, 1].Size = new Size(80, 80);
            labels[0, 1].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 1].Font = new Font(new FontFamily("Arial Black"), 18);
            pictureBoxes[0, 1].Controls.Add(labels[0, 1]);
            this.Controls.Add(pictureBoxes[0, 1]);
            pictureBoxes[0, 1].BringToFront();


            pictureBoxes[1, 0] = new PictureBox();
            pictureBoxes[1, 0].Location = new Point(12, 63 + 85);
            pictureBoxes[1, 0].Size = new Size(80, 80);
            pictureBoxes[1, 0].BackColor = Color.Yellow;
            labels[1, 0] = new Label();
            labels[1, 0].Text = "2";
            labels[1, 0].Size = new Size(80, 80);
            labels[1, 0].TextAlign = ContentAlignment.MiddleCenter;
            labels[1, 0].Font = new Font(new FontFamily("Arial Black"), 18);
            pictureBoxes[1, 0].Controls.Add(labels[1, 0]);
            this.Controls.Add(pictureBoxes[1, 0]);
            pictureBoxes[1, 0].BringToFront();
        }
        private void CreateMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(12 + 85 * j, 63 + 85 * i);
                    pictureBox.Size = new Size(80, 80);
                    pictureBox.BackColor = Color.Gray;
                    this.Controls.Add(pictureBox);
                }
            }
        }

        private void ReplaceMap(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pictureBoxes[x, y] == null)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Location = new Point(12 + 85 * j, 63 + 85 * i);
                        pictureBox.Size = new Size(80, 80);
                        pictureBox.BackColor = Color.Gray;
                        this.Controls.Add(pictureBox);
                        pictureBox.BringToFront();
                    }
                }
            }
        }
        private void ChangeColors(int sum, int z, int x)
        {
            if (sum % 2048 == 0) { MessageBox.Show("You Win! Your Score: " + score); Thread.Sleep(5000); System.Environment.Exit(0); }

            else if (sum % 1024 == 0) { pictureBoxes[z, x].BackColor = Color.DarkRed; }

            else if (sum % 512 == 0) { pictureBoxes[z, x].BackColor = Color.DarkGoldenrod; }

            else if (sum % 256 == 0) { pictureBoxes[z, x].BackColor = Color.DarkBlue; }

            else if (sum % 128 == 0) { pictureBoxes[z, x].BackColor = Color.BurlyWood; }

            else if (sum % 64 == 0) { pictureBoxes[z, x].BackColor = Color.Brown; }

            else if (sum % 32 == 0) { pictureBoxes[z, x].BackColor = Color.Green; }

            else if (sum % 16 == 0) { pictureBoxes[z, x].BackColor = Color.Red; }

            else if (sum % 8 == 0) { pictureBoxes[z, x].BackColor = Color.Blue; }

            else if (sum % 4 == 0) { pictureBoxes[z, x].BackColor = Color.Orange; }

        }
        private void CreatePics()
        {
            Random random = new Random();
            int a = random.Next(0, 4);
            int b = random.Next(0, 4);
            while (pictureBoxes[a, b] != null)
            {
                a = random.Next(0, 4);
                b = random.Next(0, 4);
            }
            mp[a, b] = 1;
            pictureBoxes[a, b] = new PictureBox();
            labels[a, b] = new Label();
            labels[a, b].Text = "2";
            labels[a, b].Size = new Size(80, 80);
            labels[a, b].TextAlign = ContentAlignment.MiddleCenter;
            labels[a, b].Font = new Font(new FontFamily("Arial Black"), 18);
            pictureBoxes[a, b].Controls.Add(labels[a, b]);
            pictureBoxes[a, b].Location = new Point(12 + b * 85, 63 + 85 * a);
            pictureBoxes[a, b].Size = new Size(80, 80);
            pictureBoxes[a, b].BackColor = Color.Yellow;
            this.Controls.Add(pictureBoxes[a, b]);
            pictureBoxes[a, b].BringToFront();



        }
        private void KeyPressed(object? send, KeyEventArgs e)
        {
            bool IfWasMoved = false;
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            Thread.Sleep(15);
                            for (int j = 2; j >= 0; j--)
                            {
                                if (mp[k, j] == 1)
                                {
                                    for (int i = j + 1; i < 4; i++)
                                    {
                                        if (mp[k, i] == 0)
                                        {
                                            IfWasMoved = true;
                                            mp[k, i - 1] = 0;
                                            mp[k, i] = 1;
                                            pictureBoxes[k, i] = pictureBoxes[k, i - 1];
                                            pictureBoxes[k, i - 1] = null;
                                            labels[k, i] = labels[k, i - 1];
                                            labels[k, i - 1] = null;
                                            pictureBoxes[k, i].Location = new Point(pictureBoxes[k, i].Location.X + 85, pictureBoxes[k, i].Location.Y);

                                        }
                                        else
                                        {
                                            int z = int.Parse(labels[k, i].Text);
                                            int x = int.Parse(labels[k, i - 1].Text);
                                            if (z == x)
                                            {
                                                IfWasMoved = true;
                                                labels[k, i].Text = (z + x).ToString();
                                                score += (z + x);
                                                ChangeColors(z + x, k, i);
                                                label1.Text = "Score: " + score;
                                                mp[k, i - 1] = 0;
                                                this.Controls.Remove(pictureBoxes[k, i - 1]);
                                                this.Controls.Remove(labels[k, i - 1]);
                                                pictureBoxes[k, i - 1] = null;
                                                labels[k, i - 1] = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        CheckForWin();
                        break;
                    }
                case "Left":
                    {
                        for (int k = 0; k < 4; k++)
                        {

                            Thread.Sleep(15);
                            for (int j = 1; j < 4; j++)
                            {
                                if (mp[k, j] == 1)
                                {
                                    for (int i = j - 1; i >= 0; i--)
                                    {
                                        if (mp[k, i] == 0)
                                        {
                                            IfWasMoved = true;
                                            mp[k, i + 1] = 0;
                                            mp[k, i] = 1;
                                            pictureBoxes[k, i] = pictureBoxes[k, i + 1];
                                            pictureBoxes[k, i + 1] = null;
                                            labels[k, i] = labels[k, i + 1];
                                            labels[k, i + 1] = null;
                                            pictureBoxes[k, i].Location = new Point(pictureBoxes[k, i].Location.X - 85, pictureBoxes[k, i].Location.Y);
                                        }
                                        else
                                        {
                                            int z = int.Parse(labels[k, i].Text);

                                            int x = int.Parse(labels[k, i + 1].Text);
                                            if (z == x)
                                            {
                                                IfWasMoved = true;
                                                labels[k, i].Text = (z + x).ToString();
                                                score += (z + x);
                                                ChangeColors(z + x, k, i);
                                                label1.Text = "Score: " + score;
                                                mp[k, i + 1] = 0;
                                                this.Controls.Remove(pictureBoxes[k, i + 1]);
                                                this.Controls.Remove(labels[k, i + 1]);
                                                pictureBoxes[k, i + 1] = null;
                                                labels[k, i + 1] = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        CheckForWin();
                        break;
                    }
                case "Down":
                    {
                        for (int k = 2; k >= 0; k--)
                        {
                            Thread.Sleep(15);
                            for (int j = 0; j < 4; j++)
                            {
                                if (mp[k, j] == 1)
                                {
                                    for (int i = k + 1; i < 4; i++)
                                    {
                                        if (mp[i, j] == 0)
                                        {
                                            IfWasMoved = true;
                                            mp[i - 1, j] = 0;
                                            mp[i, j] = 1;
                                            pictureBoxes[i, j] = pictureBoxes[i - 1, j];
                                            pictureBoxes[i - 1, j] = null;
                                            labels[i, j] = labels[i - 1, j];
                                            labels[i - 1, j] = null;
                                            pictureBoxes[i, j].Location = new Point(pictureBoxes[i, j].Location.X, pictureBoxes[i, j].Location.Y + 85);
                                        }
                                        else
                                        {
                                            int z = int.Parse(labels[i, j].Text);
                                            int x = int.Parse(labels[i - 1, j].Text);
                                            if (z == x)
                                            {
                                                IfWasMoved = true;
                                                labels[i, j].Text = (z + x).ToString();
                                                score += (z + x);
                                                ChangeColors(z + x, i, j);
                                                label1.Text = "Score: " + score;
                                                mp[i - 1, j] = 0;
                                                this.Controls.Remove(pictureBoxes[i - 1, j]);
                                                this.Controls.Remove(labels[i - 1, j]);
                                                pictureBoxes[i - 1, j] = null;
                                                labels[i - 1, j] = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        CheckForWin();
                        break;
                    }
                case "Up":
                    {
                        for (int k = 1; k < 4; k++)
                        {

                            Thread.Sleep(15);
                            for (int j = 0; j < 4; j++)
                            {
                                if (mp[k, j] == 1)
                                {
                                    for (int i = k - 1; i >= 0; i--)
                                    {
                                        if (mp[i, j] == 0)
                                        {
                                            IfWasMoved = true;
                                            mp[i + 1, j] = 0;
                                            mp[i, j] = 1;
                                            pictureBoxes[i, j] = pictureBoxes[i + 1, j];
                                            pictureBoxes[i + 1, j] = null;
                                            labels[i, j] = labels[i + 1, j];
                                            labels[i + 1, j] = null;
                                            pictureBoxes[i, j].Location = new Point(pictureBoxes[i, j].Location.X, pictureBoxes[i, j].Location.Y - 85);
                                        }
                                        else
                                        {
                                            int z = int.Parse(labels[i, j].Text);
                                            int x = int.Parse(labels[i + 1, j].Text);
                                            if (z == x)
                                            {
                                                IfWasMoved = true;
                                                labels[i, j].Text = (z + x).ToString();
                                                score += (z + x);
                                                ChangeColors(z + x, i, j);
                                                label1.Text = "Score: " + score;
                                                mp[i + 1, j] = 0;
                                                this.Controls.Remove(pictureBoxes[i + 1, j]);
                                                this.Controls.Remove(labels[i + 1, j]);
                                                pictureBoxes[i + 1, j] = null;
                                                labels[i + 1, j] = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        CheckForWin();
                        break;
                    }
            }
            if (IfWasMoved == true)
            {
                CreatePics();
            }
        }
        private void CheckForWin()
        {
            int CT = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (mp[i, j] == 1)
                    {
                        CT++;
                    }
                }
            }
            if (CT == 16 && CriticalSit == true)
            {
                int select=0;
                string[] allscore = File.ReadAllLines(@"C:\Users\Sergey\source\repos\2048LastVersion\2048LastVersion\bin\Debug\net6.0-windows\Score.txt");
                for (int i = 0;i<allscore.Length;i++)
                {
                    string check = allscore[i];
                    if (score>int.Parse(check.Remove(0,3)))
                    {
                        select = i;

                        break;
                    }
                }
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Sergey\source\repos\2048LastVersion\2048LastVersion\bin\Debug\net6.0-windows\Score.txt", false))
                {
                    for (int i = 0;i<Score.Length;i++)
                    {
                        int d = i + 1;
                        if (i==select)
                        {
                            if (i<9) {
                                Score[i + 1].Text = d+1+") "+Score[i].Text.Remove(0,3);
                            }
                            sw.WriteLine(d+") "+score);
                            
                        }
                        else
                        {
                            if (i<8)
                            {
                                Score[i + 1].Text = d + 1 + ") " + Score[i+1].Text.Remove(0, 3);
                            }
                            sw.WriteLine(Score[i].Text);
                        }
                    }
                }
                MessageBox.Show($"Ваш счёт записан! \nScore - {score}","LOSE");
                Close();
            }
            else if (CT == 16)
            {
                MessageBox.Show("Warn you", "Warn");
                CriticalSit = true;
            }
            else
            {
                CriticalSit = false;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (timeS == 60)
            {
                timeM++;
                timeS = 0;
            }
            if (timeM > 0)
            {
                label2.Text = "In Game: " + timeM + "m. " + timeS + "s.";
                timeS++;
            }
            else
            {
                label2.Text = "In Game: " + timeS + "s.";
                timeS++;
            }
        }

        private void _2048Old_Load(object sender, EventArgs e)
        {

        }
    }
}

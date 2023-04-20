
namespace _2048LastVersion
{

    public partial class _2048New : Form
    {
#pragma warning disable CS8625
        private bool Start = true;
        public int[,] mp = new int[4, 4];
        private int score = 6;
        public Label[,] labels = new Label[4, 4];
        public PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        private bool CriticalSit = false;
        private bool Shot = false;
        private bool CheckForClickA = false;
        private bool CheckForClickD = false;
        private short TimeA = 0;
        private short TimeB = 0;
        private bool WasMoved= false;
        public PictureBox[] FieldForShot = new PictureBox[4];
        public Label[] LabelsForShot = new Label[4];
        private int[] FieldForSmp = new int[4];
        private PictureBox NextP = new PictureBox();
        private Label NextL = new Label();
        public Strelka strelka = new Strelka(0,0);
        private bool first = true;
        public _2048New()
        {
            CreateMap();
            CreateFieldForShot();
            CreateStartBlocks();
            InitializeComponent();
            BlinkForLabelForeRev(label3, 0, 0, 0, 255, 255, 255, 80);
            BlinkForLabelForeRev(label4, 0, 0, 0, 255, 255, 255, 80);
            BlinkForLabelForeRev(label7, 0, 0, 0, 255, 255, 255, 80);
            BlinkForPictRev(pictureBox1, 0, 0, 0, 255, 255, 255, 80);
            BlinkForPictRev(pictureBox2, 0, 0, 0, 255, 255, 255, 80);
            BlinkForPictRev(pictureBox3, 0, 0, 0, 255, 255, 255, 80);
            BlinkForLabelBackRev(label2, 0, 0, 0, 255, 255, 255, 80);
            BlinkForLabelBackRev(label5, 0, 0, 0, 255, 255, 255, 80);
            KeyDown += new KeyEventHandler(KeyBind);
            mp[0, 0] = 1;
            mp[0, 1] = 1;
            NextBlock();
            StrlAnim();
            AnimBord();
            pictureBox5.BackColor = Color.Red;
            pictureBox7.BackColor = Color.Yellow;
            pictureBox4.BackColor = Color.Green;
            pictureBox6.BackColor = Color.Blue;
            TextAnim(label1);
        }
        async void TextAnim(Label zx)
        {
            stars:
            zx.Text = "";
            string txt = "Score";
            char[] chrs = txt.ToCharArray();
            for (int i = 0; i < chrs.Length; i++)
            {
                    zx.Text += chrs[i].ToString();
                    for (int ro = 0, go = 0, bo = 0; ro <= 255 & go <= 0 & bo <= 0; ro += 8, go += 0, bo += 0, await Task.Delay(5))
                    {
                        zx.ForeColor = Color.FromArgb((int)ro, (int)go, (int)bo);
                    }
                await Task.Delay(10);
            }
            zx.Text += ": " + score;
            await Task.Delay(2000);
            goto stars;
        }
        async void AnimBord()
        {
            start:
            for (int ro = 0, go = 0, bo = 0; ro <= 255 & go <= 0 & bo <= 0; ro += 13, go += 0, bo += 0, await Task.Delay(30))
            {
                pictureBox5.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 255 & go <= 255 & bo <= 0; ro += 13, go += 13, bo += 0, await Task.Delay(30))
            {
                pictureBox7.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 0 & go <= 255 & bo <= 0; ro += 0, go += 13, bo += 0, await Task.Delay(30))
            {
                pictureBox4.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            for (int ro = 0, go = 0, bo = 0; ro <= 0 & go <= 0 & bo <= 255; ro += 0, go += 0, bo += 13, await Task.Delay(30))
            {
                pictureBox6.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }
            await Task.Delay(50);
            goto start;
        }
        async void StrlAnim()
        {
            bool End = false;
            restart:
            if (End==false) {
                while (strelka.y != 400)
                {
                    strelka.y -= 1;
                    await Task.Delay(15);
                    Invalidate();
                }
                End = true;
                goto restart;
            }
            else
            {
                while (strelka.y != 410)
                {
                    strelka.y += 1;
                    await Task.Delay(80);
                    Invalidate();
                }
                End = false;
                goto restart;
            }
        }
        async void BlinkForLabelBackRev(Label zx, int r, int g, int b, int rn, int gn, int bn, int speed)
        {
            int dlr, dlg, dlb, del = speed;
            if (speed >= 60 && speed <= 90)
            {
                del = speed / 3;
            }
            else if (speed >= 90 && speed <= 140)
            {
                del = speed / 5;
            }
            else if (speed < 60)
            {
                del = speed / 2;
            }
            dlr = (rn - r) / del;
            dlg = (gn - g) / del;
            dlb = (bn - b) / del;
            for (int ro = r, go = g, bo = b; ro <= rn & go <= gn & bo <= bn; ro += dlr, go += dlg, bo += dlb, await Task.Delay(speed))
            {
                if (ro == 255 & bo == 255 & go == 255)
                    break;
                zx.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }

        }
        async void BlinkForLabelForeRev(Label zx, int r, int g, int b, int rn, int gn, int bn, int speed)
        {
            int dlr, dlg, dlb, del = speed;
            if (speed >= 60 && speed <= 90)
            {
                del = speed / 3;
            }
            else if (speed >= 90 && speed <= 140)
            {
                del = speed / 5;
            }
            else if (speed < 60)
            {
                del = speed / 2;
            }
            dlr = (rn - r) / del;
            dlg = (gn - g) / del;
            dlb = (bn - b) / del;
            for (int ro = r, go = g, bo = b; ro <= rn & go <= gn & bo <= bn; ro += dlr, go += dlg, bo += dlb, await Task.Delay(speed))
            {
                if (ro == 255 & bo == 255 & go == 255)
                    break;
                zx.ForeColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }

        }
        async void BlinkForPictRev(PictureBox zx, int r, int g, int b, int rn, int gn, int bn, int speed)
        {
            int dlr, dlg, dlb, del = speed;
            if (speed >= 60 && speed <= 90)
            {
                del = speed / 3;
            }
            else if (speed >= 90 && speed <= 140)
            {
                del = speed / 5;
            }
            else if (speed < 60)
            {
                del = speed / 2;
            }
            dlr = (rn - r) / del;
            dlg = (gn - g) / del;
            dlb = (bn - b) / del;
            for (int ro = r, go = g, bo = b; ro <= rn & go <= gn & bo <= bn; ro += dlr, go += dlg, bo += dlb, await Task.Delay(speed))
            {
                if (ro == 255 & bo == 255 & go == 255)
                    break;
                zx.BackColor = Color.FromArgb((int)ro, (int)go, (int)bo);
            }

        }
        private void CreateStartBlocks()
        {
            pictureBoxes[0, 0] = new PictureBox();
            pictureBoxes[0, 0].Location = new Point(31, 63);
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
            BlinkForPictRev(pictureBoxes[0,0],0,0,0,255,255,0,50);


            pictureBoxes[0, 1] = new PictureBox();
            pictureBoxes[0, 1].Location = new Point(31 + 85, 63);
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
            BlinkForPictRev(pictureBoxes[0, 1], 0, 0, 0, 255, 255, 0, 50);

        }
        private void CreateMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(31 + 85 * j, 63 + 85 * i);
                    pictureBox.Size = new Size(80, 80);
                    pictureBox.BackColor = Color.FromArgb(176,176,176);
                    this.Controls.Add(pictureBox);
                    BlinkForPictRev(pictureBox,0,0,0,176,176,176,80);
                }
            }
        }
        private void CreateFieldForShot()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox FieldForS = new PictureBox();
                FieldForS.Location = new Point(31 + 85 * i, 478);
                FieldForS.Size = new Size(80, 80);
                FieldForS.BackColor = Color.FromArgb(176, 176, 176);
                this.Controls.Add(FieldForS);
                BlinkForPictRev(FieldForS, 0, 0, 0, 176, 176, 176, 80);
            }
        }
        private void ChangeColors(int sum, int c, int x)
        {
            if (sum % 2048 == 0) { pictureBoxes[c, x].BackColor = Color.DarkGray; labels[c, x].Font = new Font(new FontFamily("Arial Black"), 14); labels[c, x].ForeColor = Color.White; MessageBox.Show("You Win! Your Score: " + score); Thread.Sleep(500); System.Environment.Exit(0); }

            else if (sum % 1024 == 0) { pictureBoxes[c, x].BackColor = Color.DarkRed; labels[c, x].Font = new Font(new FontFamily("Arial Black"),14); }

            else if (sum % 512 == 0) { pictureBoxes[c, x].BackColor = Color.DarkGoldenrod; }

            else if (sum % 256 == 0) { pictureBoxes[c, x].BackColor = Color.DarkBlue; }

            else if (sum % 128 == 0) { pictureBoxes[c, x].BackColor = Color.BurlyWood; }

            else if (sum % 64 == 0) { pictureBoxes[c, x].BackColor = Color.Brown; }

            else if (sum % 32 == 0) { pictureBoxes[c, x].BackColor = Color.Green; }

            else if (sum % 16 == 0) { pictureBoxes[c, x].BackColor = Color.Red; }

            else if (sum % 8 == 0) { pictureBoxes[c, x].BackColor = Color.Blue; }

            else if (sum % 4 == 0) { pictureBoxes[c, x].BackColor = Color.Orange; }

        }
        private void CreatePics(Label label,PictureBox pictureBox)
        {
            if (first==true)
            {
                Random random = new Random();
                int a = random.Next(0, 4);
                FieldForSmp[a] = 1;
                FieldForShot[a] = new PictureBox();
                LabelsForShot[a] = new Label();
                LabelsForShot[a].Text = label.Text;
                LabelsForShot[a].Size = new Size(80, 80);
                LabelsForShot[a].TextAlign = ContentAlignment.MiddleCenter;
                LabelsForShot[a].Font = label.Font;
                FieldForShot[a].Controls.Add(LabelsForShot[a]);
                FieldForShot[a].Location = new Point(31 + a * 85, 478);
                FieldForShot[a].Size = new Size(80, 80);
                strelka.x = 40 + a * 85;
                strelka.y = 410;
                FieldForShot[a].BackColor = pictureBox.BackColor;
                this.Controls.Add(FieldForShot[a]);
                FieldForShot[a].BringToFront();
                BlinkForPictRev(FieldForShot[a], 0, 0, 0, 255, 255, 0, 50);
                first = false;
            }
            else
            {
                Random random = new Random();
                int a = random.Next(0, 4);
                FieldForSmp[a] = 1;
                FieldForShot[a] = new PictureBox();
                LabelsForShot[a] = new Label();
                LabelsForShot[a].Text = label.Text;
                LabelsForShot[a].Size = new Size(80, 80);
                LabelsForShot[a].TextAlign = ContentAlignment.MiddleCenter;
                LabelsForShot[a].Font = label.Font;
                FieldForShot[a].Controls.Add(LabelsForShot[a]);
                FieldForShot[a].Location = new Point(31 + a * 85, 478);
                FieldForShot[a].Size = new Size(80, 80);
                strelka.x = 40 + a * 85;
                strelka.y = 410;
                FieldForShot[a].BackColor = pictureBox.BackColor;
                this.Controls.Add(FieldForShot[a]);
                FieldForShot[a].BringToFront();
            }
        }
        private void NextBlock()
        {
            bool LvlUp = false;
            if (Start == true) {
                NextL.Text = "2";
                NextL.Size = new Size(80, 80);
                NextL.TextAlign = ContentAlignment.MiddleCenter;
                NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                NextP.Controls.Add(NextL);
                NextP.Location = new Point(406, 120);
                NextP.Size = new Size(80, 80);
                NextP.BackColor = Color.FromArgb(255,255,0);
                Start = false;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (labels[i, j] == null) { }
                    else
                    {
                        if (int.Parse(labels[i, j].Text) == 128)
                        {
                            LvlUp = true;
                        }
                    }
                }
            }
            if (LvlUp == false) {
                int a = new Random().Next(0, 12);
                if (a <= 6)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "2";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Yellow;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
                else if (a > 6 && a <= 9)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "4";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Orange;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
                else if (a > 9 && a <= 12)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "8";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Blue;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
            }
            else
            {
                int a = new Random().Next(0, 12);
                if (a <= 3)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "2";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Yellow;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
                else if (a > 3 && a <= 7)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "4";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Orange;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
                else if (a > 7 && a <= 9)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "8";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Blue;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
                else if (a>9 && a<=11)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "16";
                    NextL.Size = new Size(70, 70);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Red;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();

                }
                else if (a==12)
                {
                    CreatePics(NextL, NextP);
                    NextL.Text = "32";
                    NextL.Size = new Size(80, 80);
                    NextL.TextAlign = ContentAlignment.MiddleCenter;
                    NextL.Font = new Font(new FontFamily("Arial Black"), 18);
                    NextP.Controls.Add(NextL);
                    NextP.Location = new Point(406, 120);
                    NextP.Size = new Size(70, 70);
                    NextP.BackColor = Color.Green;
                    this.Controls.Add(NextP);
                    NextP.BringToFront();
                }
            }
            Invalidate();
        }
        private void KeyBind(object? z,KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (WasMoved == false)
                            {
                                if (FieldForSmp[i] == 1)
                                {
                                    if (i + 1 < 4)
                                    {
                                        FieldForSmp[i + 1] = 1;
                                        FieldForSmp[i] = 0;
                                        FieldForShot[i + 1] = FieldForShot[i];
                                        LabelsForShot[i + 1] = LabelsForShot[i];
                                        LabelsForShot[i] = null;
                                        strelka.x += 85;
                                        FieldForShot[i + 1].Location = new Point(FieldForShot[i].Location.X + 85, FieldForShot[i].Location.Y);
                                        FieldForShot[i] = null;
                                        WasMoved = true;
                                        Invalidate();
                                    }
                                }
                            }
                        }
                        WasMoved = false;
                        break;
                    }
                case "Left":
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (WasMoved == false)
                            {
                                if (FieldForSmp[i] == 1)
                                {
                                    if (i - 1 >= 0)
                                    {
                                        FieldForSmp[i - 1] = 1;
                                        FieldForSmp[i] = 0;
                                        FieldForShot[i - 1] = FieldForShot[i];
                                        LabelsForShot[i - 1] = LabelsForShot[i];
                                        LabelsForShot[i] = null;
                                        strelka.x -= 85;
                                        FieldForShot[i - 1].Location = new Point(FieldForShot[i].Location.X - 85, FieldForShot[i].Location.Y);
                                        FieldForShot[i] = null;
                                        WasMoved = true;
                                        Invalidate();
                                    }
                                }
                            }
                        }
                        WasMoved = false;
                        break;
                    }
                case "Space":
                    {
                        int PosShot = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (FieldForSmp[i]==1)
                            {
                                if (mp[3,i]==0) {
                                    PosShot = i;
                                    pictureBoxes[3, i] = FieldForShot[i];
                                    labels[3, i] = LabelsForShot[i];
                                    mp[3, i] = 1;
                                    pictureBoxes[3, i].Location = new Point(FieldForShot[i].Location.X, FieldForShot[i].Location.Y - 160);
                                    FieldForSmp[i] = 0;
                                    pictureBoxes[3, i].Controls.Add(labels[3, i]);
                                    this.Controls.Add(pictureBoxes[3, i]);
                                    pictureBoxes[3, i].BringToFront();
                                    FieldForShot[i] = null;
                                    LabelsForShot[i] = null;
                                    Shot = true;
                                }
                                else
                                {
                                    PosShot = i;
                                    Shot = false;
                                }
                            }
                        }
                        if (Shot == true)
                        {
                                for (int j = 1; j < 4; j++)
                                {
                                Thread.Sleep(15);
                                if (mp[j,PosShot] == 1)
                                    {
                                        for (int i = j-1; i >= 0; i--)
                                        {
                                            if (mp[i, PosShot] == 0)
                                            {
                                                mp[i + 1, PosShot] = 0;
                                                mp[i, PosShot] = 1;
                                                pictureBoxes[i, PosShot] = pictureBoxes[i + 1, PosShot];
                                                pictureBoxes[i + 1, PosShot] = null;
                                                labels[i, PosShot] = labels[i + 1, PosShot];
                                                labels[i + 1, PosShot] = null;
                                                pictureBoxes[i, PosShot].Location = new Point(pictureBoxes[i, PosShot].Location.X, pictureBoxes[i, PosShot].Location.Y - 85);
                                            }
                                            else
                                            {
                                                int zx = int.Parse(labels[i, PosShot].Text);
                                                int x = int.Parse(labels[i + 1, PosShot].Text);
                                                if (zx == x)
                                                {
                                                    labels[i, PosShot].Text = (zx + x).ToString();
                                                    score += (zx + x);
                                                    ChangeColors(zx + x, i, PosShot);
                                                    mp[i + 1, PosShot] = 0;
                                                    this.Controls.Remove(pictureBoxes[i + 1, PosShot]);
                                                    this.Controls.Remove(labels[i + 1, PosShot]);
                                                    pictureBoxes[i + 1, PosShot] = null;
                                                    labels[i + 1, PosShot] = null;
                                                }
                                            }
                                        }
                                    }
                                }
                            NextBlock();
                        }
                        else
                        {
                            for (int j = 1; j < 4; j++)
                            {
                                Thread.Sleep(15);
                                if (mp[j, PosShot] == 1)
                                {
                                    for (int i = j - 1; i >= 0; i--)
                                    {
                                        if (mp[i, PosShot] == 0)
                                        {
                                            mp[i + 1, PosShot] = 0;
                                            mp[i, PosShot] = 1;
                                            pictureBoxes[i, PosShot] = pictureBoxes[i + 1, PosShot];
                                            pictureBoxes[i + 1, PosShot] = null;
                                            labels[i, PosShot] = labels[i + 1, PosShot];
                                            labels[i + 1, PosShot] = null;
                                            pictureBoxes[i, PosShot].Location = new Point(pictureBoxes[i, PosShot].Location.X, pictureBoxes[i, PosShot].Location.Y - 85);
                                        }
                                        else
                                        {
                                            int zx = int.Parse(labels[i, PosShot].Text);
                                            int x = int.Parse(labels[i + 1, PosShot].Text);
                                            if (zx == x)
                                            {
                                                labels[i, PosShot].Text = (zx + x).ToString();
                                                score += (zx + x);
                                                ChangeColors(zx + x, i, PosShot);
                                                mp[i + 1, PosShot] = 0;
                                                this.Controls.Remove(pictureBoxes[i + 1, PosShot]);
                                                this.Controls.Remove(labels[i + 1, PosShot]);
                                                pictureBoxes[i + 1, PosShot] = null;
                                                labels[i + 1, PosShot] = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        CheckForLose();
                        break;
                    }
                case "A":
                    {
                        if (CheckForClickA==false) {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int j = 1; j < 4; j++)
                                {
                                    if (mp[k, j] == 1)
                                    {
                                        for (int i = j - 1; i >= 0; i--)
                                        {
                                            if (mp[k, i] == 0)
                                            {
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
                                                int zx = int.Parse(labels[k, i].Text);

                                                int x = int.Parse(labels[k, i + 1].Text);
                                                if (zx == x)
                                                {
                                                    labels[k, i].Text = (zx + x).ToString();
                                                    score += (zx + x);
                                                    ChangeColors(zx + x, k, i);
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
                            CheckForClickA = true;
                            TimeA = 0;
                            pictureBox2.BackColor = Color.Red;
                            label5.BackColor = Color.Red;
                            timer1.Start();
                        }
                        break;
                    }
                case "D":
                    {
                        if (CheckForClickD==false) {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int j = 2; j >= 0; j--)
                                {
                                    if (mp[k, j] == 1)
                                    {
                                        for (int i = j + 1; i < 4; i++)
                                        {
                                            if (mp[k, i] == 0)
                                            {
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
                                                int zx = int.Parse(labels[k, i].Text);
                                                int x = int.Parse(labels[k, i - 1].Text);
                                                if (zx == x)
                                                {
                                                    labels[k, i].Text = (zx + x).ToString();
                                                    score += (zx + x);
                                                    ChangeColors(zx + x, k, i);
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
                            CheckForClickD = true;
                            TimeB = 0;
                            pictureBox1.BackColor = Color.Red;
                            label2.BackColor = Color.Red;
                            timer2.Start();
                        }
                        break;
                    }
            }
        }

        private void _2048New_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeA++;
            if (TimeA == 10)
            {
                CheckForClickA = false;
                pictureBox2.BackColor = Color.White;
                label5.BackColor = Color.White;
                timer1.Stop();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeB++;
            if (TimeB==10)
            {
                CheckForClickD = false;
                pictureBox1.BackColor = Color.White;
                label2.BackColor = Color.White;
                timer2.Stop();
            }
        }
        private void CheckForLose()
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
                MessageBox.Show("LOSE","You lose\nYour score");
            }
            else if (CT == 16)
            {
                MessageBox.Show("Warn", "Warn\nYour score");
                CriticalSit = true;
            }
            else
            {
                CriticalSit = false;
            }
        }

        private void _2048New_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(strelka.Image,strelka.x,strelka.y,65,65);
        }
    }
    public class Strelka
    {
        public int x;
        public int y;
        public Image Image;
        public Strelka(int x,int y)
        {
            this.x = x;
            this.y = y;
            Image = new Bitmap("C:\\Users\\Sergey\\source\\repos\\2048LastVersion\\2048LastVersion\\bin\\Debug\\net6.0-windows\\st.png");
        }
    }
}

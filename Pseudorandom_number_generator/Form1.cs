using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pseudorandom_number_generator
{
    public partial class Form1 : Form
    {
        private TextBox seedInput;
        private NumericUpDown countInput;
        private Button generateButton;
        private ListBox numberList;
        private PictureBox drawArea;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "��������� ���������� ����� (���)";
            this.Size = new Size(600, 500);

            Label seedLabel = new Label { Text = "Seed:", Location = new Point(10, 10), AutoSize = true };
            seedInput = new TextBox { Location = new Point(55, 10), Width = 100 };

            Label countLabel = new Label { Text = "���-�� �����:", Location = new Point(160, 10), AutoSize = true };
            countInput = new NumericUpDown { Location = new Point(270, 10), Width = 60, Minimum = 1, Maximum = 10000, Value = 100 };

            generateButton = new Button { Text = "�������������", Location = new Point(350, 10), Width = 120, Height = 30 };
            generateButton.Click += GenerateRandomWalk;

            numberList = new ListBox { Location = new Point(10, 40), Size = new Size(150, 400) };

            drawArea = new PictureBox { Location = new Point(170, 40), Size = new Size(400, 400), BorderStyle = BorderStyle.FixedSingle };

            this.Controls.Add(seedLabel);
            this.Controls.Add(seedInput);
            this.Controls.Add(countLabel);
            this.Controls.Add(countInput);
            this.Controls.Add(generateButton);
            this.Controls.Add(numberList);
            this.Controls.Add(drawArea);
        }

        private void GenerateRandomWalk(object sender, EventArgs e)
        {
            if (!int.TryParse(seedInput.Text, out int seed))
            {
                MessageBox.Show("������� ���������� seed (����� �����).");
                return;
            }

            int count = (int)countInput.Value;
            int[] randomNumbersX = new int[count];
            int[] randomNumbersY = new int[count];

            for (int i = 0; i < count; i++)
            {
                randomNumbersX[i] = CustomRandom(ref seed, 0, 20);
                randomNumbersY[i] = CustomRandom(ref seed, 0, 20);
            }

            numberList.Items.Clear();
            Bitmap bmp = new Bitmap(drawArea.Width, drawArea.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int x = drawArea.Width / 2;
            int y = drawArea.Height / 2;
            Pen pen = new Pen(Color.Blue, 2);

            for (int i = 0; i < count; i++)
            {
                int newX = x + randomNumbersX[i];
                int newY = y + randomNumbersY[i];

                numberList.Items.Add($"({newX}, {newY})");
                g.DrawLine(pen, x, y, newX, newY);
                x = newX;
                y = newY;
            }

            drawArea.Image = bmp;
        }

        private int CustomRandom(ref int seed, int min, int max)
        {
            #region �������� ������������ ����� (���)
            // �������� �� �������: X_{n+1} = (a * X_n + c) % m
            // ���:
            // a = 1664525 � ��������� (�����������)
            // c = 1013904223 � ����������
            // m = int.MaxValue � ������ (����������� � �������� int)
            // X_n � ������� ��������� (seed), ������� ����������� ��� ������ ������
            // X_{n+1} � ��������� ��������������� �����
            #endregion

            const int a = 1664525;
            const int c = 1013904223;
            const int m = int.MaxValue;
            seed = (a * seed + c) % m;
            return min + (seed % (max - min + 1));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resistor_code
{
    public partial class Form1 : Form
    {
        public static readonly Color[] StripColors = { Color.Black, Color.SaddleBrown, Color.Red, Color.DarkOrange, Color.Yellow,
            Color.Green, Color.DarkBlue, Color.Orchid, Color.DimGray, Color.White, Color.DarkGoldenrod, Color.Silver };
        // BLAC    BROW    RED     ORAN    YELL    GREE    BLUE    PURP   GREY    WHIT    GOLD     SILV
        public static readonly string[] Digit1 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", null, null };
        public static readonly string[] Digit2 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", null, null };
        public static readonly string[] Digit3 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", null, null };
        public static readonly string[] Multiplier = { "1", "10", "100", "1K", "10K", "100K", "1M", "10M", null, null, "0.1", "0.01" };
        public static readonly string[] Tolerance = { null, "1", "2", null, null, "0.5", "0.25", "0.1", "0.05", null, "5", "10" };
        public static readonly string[] TRC = { null, "100", "50", "15", "25", null, "10", "5", null, null, null, null };

        private Point[] stripLocation = new Point[8];
        public int Resister_band_count { get; set; }
        string s_digit1 = "1";
        string s_digit2 = "0";
        string s_digit3 = "0";
        string s_multiplier = "1";
        string s_tolerance = "5";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitButtons();
            saveStripLocation();
            button51_Click(null, null);
        }

        private void ResetResistorValue()
        {
            s_digit1 = "1";
            s_digit2 = "0";
            s_digit3 = "0";
            s_multiplier = "1";
            s_tolerance = "5";

        }
        private void saveStripLocation()
        {
            stripLocation[0] = tableLayoutPanel3.Location;
            stripLocation[1] = tableLayoutPanel4.Location;
            stripLocation[2] = tableLayoutPanel5.Location;
            stripLocation[3] = tableLayoutPanel6.Location;
            stripLocation[4] = tableLayoutPanel7.Location;
        }
        private void restoreStrip()
        {
            tableLayoutPanel3.Location = stripLocation[0];
            tableLayoutPanel4.Location = stripLocation[1];
            tableLayoutPanel5.Location = stripLocation[2];
            tableLayoutPanel6.Location = stripLocation[3];
            tableLayoutPanel7.Location = stripLocation[4];
        }

        private void InitButtons()
        {
            InitButtons(buttonA0, StripColors[0], Digit1[0]);
            InitButtons(buttonA1, StripColors[1], Digit1[1]);
            InitButtons(buttonA2, StripColors[2], Digit1[2]);
            InitButtons(buttonA3, StripColors[3], Digit1[3]);
            InitButtons(buttonA4, StripColors[4], Digit1[4]);
            InitButtons(buttonA5, StripColors[5], Digit1[5]);
            InitButtons(buttonA6, StripColors[6], Digit1[6]);
            InitButtons(buttonA7, StripColors[7], Digit1[7]);
            InitButtons(buttonA8, StripColors[8], Digit1[8]);
            InitButtons(buttonA9, StripColors[9], Digit1[9]);

            InitButtons(buttonB0, StripColors[0], Digit2[0]);
            InitButtons(buttonB1, StripColors[1], Digit2[1]);
            InitButtons(buttonB2, StripColors[2], Digit2[2]);
            InitButtons(buttonB3, StripColors[3], Digit2[3]);
            InitButtons(buttonB4, StripColors[4], Digit2[4]);
            InitButtons(buttonB5, StripColors[5], Digit2[5]);
            InitButtons(buttonB6, StripColors[6], Digit2[6]);
            InitButtons(buttonB7, StripColors[7], Digit2[7]);
            InitButtons(buttonB8, StripColors[8], Digit2[8]);
            InitButtons(buttonB9, StripColors[9], Digit2[9]);

            InitButtons(buttonC0, StripColors[0], Digit3[0]);
            InitButtons(buttonC1, StripColors[1], Digit3[1]);
            InitButtons(buttonC2, StripColors[2], Digit3[2]);
            InitButtons(buttonC3, StripColors[3], Digit3[3]);
            InitButtons(buttonC4, StripColors[4], Digit3[4]);
            InitButtons(buttonC5, StripColors[5], Digit3[5]);
            InitButtons(buttonC6, StripColors[6], Digit3[6]);
            InitButtons(buttonC7, StripColors[7], Digit3[7]);
            InitButtons(buttonC8, StripColors[8], Digit3[8]);
            InitButtons(buttonC9, StripColors[9], Digit3[9]);

            InitButtons(buttonD0, StripColors[0], Multiplier[0]);
            InitButtons(buttonD1, StripColors[1], Multiplier[1]);
            InitButtons(buttonD2, StripColors[2], Multiplier[2]);
            InitButtons(buttonD3, StripColors[3], Multiplier[3]);
            InitButtons(buttonD4, StripColors[4], Multiplier[4]);
            InitButtons(buttonD5, StripColors[5], Multiplier[5]);
            InitButtons(buttonD6, StripColors[6], Multiplier[6]);
            InitButtons(buttonD7, StripColors[7], Multiplier[7]);
            InitButtons(buttonDA, StripColors[10], Multiplier[10]);
            InitButtons(buttonDB, StripColors[11], Multiplier[11]);

            InitButtons(buttonE1, StripColors[1], Tolerance[1]);
            InitButtons(buttonE2, StripColors[2], Tolerance[2]);
            InitButtons(buttonE5, StripColors[5], Tolerance[5]);
            InitButtons(buttonE6, StripColors[6], Tolerance[6]);
            InitButtons(buttonE7, StripColors[7], Tolerance[7]);
            InitButtons(buttonE8, StripColors[8], Tolerance[8]);
            InitButtons(buttonEA, StripColors[10], Tolerance[10]);
            InitButtons(buttonEB, StripColors[11], Tolerance[11]);
        }

        private void InitButtons(Button button, Color color, string v)
        {

            button.FlatAppearance.BorderSize = 0;
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = "";
            button.BackColor = color;
            button.Text = v;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            // set strip for 4 bands resistor
            tableLayoutPanel5.Visible = false;
            tableLayoutPanel3.Left = tableLayoutPanel1.Left;
            tableLayoutPanel4.Left = tableLayoutPanel8.Left;
            tableLayoutPanel6.Left = tableLayoutPanel9.Left;
            tableLayoutPanel7.Left = tableLayoutPanel10.Left;
            pictureBox6.Visible = false;
            Resister_band_count = 4;
            Console.WriteLine("{0} {1} {2} {3}", s_digit1, s_digit2, s_digit3, s_multiplier);
            CalculateResistorValue();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Visible = true;
            pictureBox6.Visible = true;
            restoreStrip();
            Resister_band_count = 5;
            Console.WriteLine("{0} {1} {2} {3}", s_digit1, s_digit2, s_digit3, s_multiplier);
            CalculateResistorValue();
        }

        private void ButtonStripA_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Convert.ToInt16(btn.Text);
            pictureBox3.BackColor = StripColors[number];
            pictureBox3.BorderStyle = BorderStyle.None;
            s_digit1 = btn.Text;
            CalculateResistorValue();
        }

        private void ButtonStripB_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Convert.ToInt16(btn.Text);
            pictureBox4.BackColor = StripColors[number];
            pictureBox4.BorderStyle = BorderStyle.None;
            s_digit2 = btn.Text;
            CalculateResistorValue();
        }

        private void ButtonStripC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Convert.ToInt16(btn.Text);
            pictureBox5.BackColor = StripColors[number];
            pictureBox5.BorderStyle = BorderStyle.None;
            s_digit3 = btn.Text;
            CalculateResistorValue();

        }

        private void ButtonStripD_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Convert.ToInt16(btn.Tag);
            switch (Resister_band_count)
            {
                case 4:
                    pictureBox5.BackColor = StripColors[number];
                    pictureBox5.BorderStyle = BorderStyle.None;
                    break;
                case 5:
                    pictureBox6.BackColor = StripColors[number];
                    pictureBox6.BorderStyle = BorderStyle.None;
                    break;
            }
            s_multiplier = btn.Text;
            CalculateResistorValue();
        }
        private void ButtonStripE_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Convert.ToInt16(btn.Tag);
            pictureBox7.BackColor = StripColors[number];
            pictureBox7.BorderStyle = BorderStyle.None;
            s_tolerance = Tolerance[number];
            CalculateResistorValue();
        }
        private void CalculateResistorValue()
        {
            double multiplier = MathHelper.RemoveSufix(s_multiplier);
            string s_value = s_digit1 + s_digit2 + s_digit3;
            if (Resister_band_count == 4)
                s_value = s_digit1 + s_digit2;
            if (Resister_band_count == 5)
                s_value = s_digit1 + s_digit2 + s_digit3;
            Console.WriteLine(s_value);
            double value = double.Parse(s_value, CultureInfo.InvariantCulture);
            value *= multiplier;
            s_value = MathHelper.AddSufix(value);
            string output = String.Format("{0}Ω ±{1}%", s_value, s_tolerance );
            Console.WriteLine(output);
            label1.Text = output;
        }
    }
}

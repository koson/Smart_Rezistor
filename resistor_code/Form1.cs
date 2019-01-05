using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitButtons();
            saveStripLocation();
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
            InitButtons(button1,  StripColors[0], Digit1[0]);
            InitButtons(button2,  StripColors[1], Digit1[1]);
            InitButtons(button3,  StripColors[2], Digit1[2]);
            InitButtons(button4,  StripColors[3], Digit1[3]);
            InitButtons(button5,  StripColors[4], Digit1[4]);
            InitButtons(button6,  StripColors[5], Digit1[5]);
            InitButtons(button7,  StripColors[6], Digit1[6]);
            InitButtons(button8,  StripColors[7], Digit1[7]);
            InitButtons(button9,  StripColors[8], Digit1[8]);
            InitButtons(button10, StripColors[9], Digit1[9]);

            InitButtons(button11, StripColors[0], Digit2[0]);
            InitButtons(button12, StripColors[1], Digit2[1]);
            InitButtons(button13, StripColors[2], Digit2[2]);
            InitButtons(button14, StripColors[3], Digit2[3]);
            InitButtons(button15, StripColors[4], Digit2[4]);
            InitButtons(button16, StripColors[5], Digit2[5]);
            InitButtons(button17, StripColors[6], Digit2[6]);
            InitButtons(button18, StripColors[7], Digit2[7]);
            InitButtons(button19, StripColors[8], Digit2[8]);
            InitButtons(button20, StripColors[9], Digit2[9]);

            InitButtons(button21, StripColors[0], Multiplier[0]);
            InitButtons(button22, StripColors[1], Multiplier[1]);
            InitButtons(button23, StripColors[2], Multiplier[2]);
            InitButtons(button24, StripColors[3], Multiplier[3]);
            InitButtons(button25, StripColors[4], Multiplier[4]);
            InitButtons(button26, StripColors[5], Multiplier[5]);
            InitButtons(button27, StripColors[6], Multiplier[6]);
            InitButtons(button28, StripColors[7], Multiplier[7]);
            InitButtons(button29, StripColors[8], Multiplier[8]);

            InitButtons(button32, StripColors[1], Multiplier[1]);
            InitButtons(button33, StripColors[2], Multiplier[2]);
            InitButtons(button36, StripColors[5], Multiplier[5]);
            InitButtons(button37, StripColors[6], Multiplier[6]);
            InitButtons(button38, StripColors[7], Multiplier[7]);
 


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

        }

        private void button52_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Visible = true;
            restoreStrip();
        }

    }
}

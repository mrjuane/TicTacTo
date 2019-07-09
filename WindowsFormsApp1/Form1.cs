using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTICTACTOE
{
    public partial class Form1 : Form
    {
        private short [] matris = new short[9];
        private bool active = true;
        enum Player: short {Player1 = 1,Player2};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Enabled = false;
            short controlTag = Convert.ToInt16(p.Tag);

            if (active)
            {
                this.matris[controlTag] = (short)Player.Player1;
                p.Image = Properties.Resources.X;
                this.CheckWin((short)Player.Player1);
            }
            else
            {
                this.matris[controlTag] = (short)Player.Player2; 
                p.Image = Properties.Resources.O;
                this.CheckWin((short)Player.Player2);
            }
            active = !active;
        }
        /// <summary>
        /// Method to comprare for check Win
        /// </summary>
        /// <param name="l">Player to Check can be 1 or 2</param>
        private void CheckWin(short l)
        {
            foreach (var item in LWin)
            {
                if (matris[item[0]] == l && matris[item[1]] == l && matris[item[2]] == l)
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show($"PLAYER {l.ToString()} WIN");
                    return;
                }
            }
        }
        /// <summary>
        /// Reset the table 
        /// </summary>
        private void reset()
        {
            active = true;
            PictureBox iterateItem = null;
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(System.Windows.Forms.PictureBox))
                {
                    iterateItem = (PictureBox)item;
                    iterateItem.Image = null;
                    iterateItem.Enabled = true;
                }
            }
            for (int i = 0; i < matris.Length; i++)
            {
                matris[i] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        /// <summary>
        /// List to compare for get WIN
        /// </summary>
        List<short[]> LWin = new List<short[]>()
        {
           new short[] {0,1,2},
           new short[] {0,4,8},
           new short[] {0,3,6},
           new short[] {1,4,7},
           new short[] {2,5,8},
           new short[] {2,4,6},
           new short[] {3,4,5},
           new short[] {6,7,8}

        };
    }

}

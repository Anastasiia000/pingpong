using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingpong
{
    public partial class Form1 : Form
    {
        private int speedVertical = 2, speedHorizon = 2, score=0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);
            gameBall.Left += speedHorizon;
            gameBall.Top += speedVertical;
            if (gameBall.Left <= background.Left)
                speedHorizon *= -1;
            if (gameBall.Right >= background.Right)
                speedHorizon *= -1;
            if (gameBall.Top <= background.Top)
                speedVertical *= -1;
            if (gameBall.Bottom >= background.Bottom)
                timer1.Enabled=false;
            if (gameBall.Bottom >= gamePanel.Top && gameBall.Bottom <= gamePanel.Bottom
                && gameBall.Left >= gamePanel.Left && gameBall.Right <= gamePanel.Right) 
            {
                speedVertical += 1;
                speedHorizon += 1;
                speedVertical *= -1;
                score += 1;
                if (gamePanel.Width >= 80)
                    gamePanel.Width -= 35;
                else
                {
                    timer1.Enabled = false;
                    MessageBox.Show("You winner!! Your score: " + score);
                    Close();
                }

            } 
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true; //іконки програми будуть рухатися
            Cursor.Hide(); //ховаємо курсор
            this.FormBorderStyle = FormBorderStyle.None; //безграниць стиль програми
            this.TopMost = true; //наша програма запуститься поверху інших програм
            this.Bounds = Screen.PrimaryScreen.Bounds; //розміри нашої програми буде по висоті і ширині нашого екрану
            gamePanel.Top = background.Bottom - (background.Bottom / 10); //наша панелька, яка відбиває мячік буде прижата до нижнього краю, завжди на певній відстанні
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }
    }
}

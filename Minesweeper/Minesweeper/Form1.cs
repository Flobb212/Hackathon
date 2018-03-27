using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        int gridX = 50;
        int gridY = 25;
        ButtonObject[,] grid;
        ButtonObject btn;
        Color buttonDefault;

        Random rnd;
        int randX;
        int randY;

        ButtonObject[] mines;
        int numOfMines = 100;

        public Form1()
        {
            InitializeComponent();
            numOfMines = (int)((gridX * gridY)/8); 
            grid = new ButtonObject[gridX, gridY];
            Reset();
        }

        public void Reset()
        {
            mineContainer.Controls.Clear();

            for (int x = 0; x < gridX; x++)
            {
                for (int y = 0; y < gridY; y++)
                {
                    btn = new ButtonObject();
                    btn.thisHereButton = new Button();

                    buttonDefault = default(Color);
                    btn.thisHereButton.BackColor = buttonDefault;
                    btn.xPos = x;
                    btn.yPos = y;
                    grid[x, y] = btn;
                    btn.thisHereButton.MouseUp += new MouseEventHandler(button_Click);
                    btn.thisHereButton.Width = 25;
                    btn.thisHereButton.Height = 25;
                    btn.thisHereButton.Location = new System.Drawing.Point(25 + x * 25, 40 + y * 25);
                    mineContainer.Controls.Add(btn.thisHereButton);
                    btn.thisHereButton.BringToFront();
                    btn.contans = mineContainer;
                }
            }

            rnd = new Random();
            mines = new ButtonObject[numOfMines];

            for (int x = 0; x < numOfMines; x++)
            {
                randX = rnd.Next(0, gridX);
                randY = rnd.Next(0, gridY);
                mines[x] = grid[randX, randY];

                //grid[randX, randY].thisHereButton.BackColor = Color.Red;
            }

            foreach (ButtonObject subject in grid)
            {
                AlertNeighbours(subject);
            }
        }


        protected void button_Click(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            ButtonObject bigDaddy = null;

            foreach (ButtonObject target in grid)
            {
                if (button == target.thisHereButton)
                {
                    bigDaddy = target;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (button.BackColor == Color.Green)
                {
                    return;
                }
                else
                {
                    EliminateSquare(bigDaddy);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (button.BackColor == Color.Green)
                {
                    button.BackColor = buttonDefault;
                }
                else
                {
                    button.BackColor = Color.Green;
                }
            }
        }

        public void EliminateSquare(ButtonObject thisGuy)
        {
            if (mines.Contains(thisGuy))
            {
                foreach (ButtonObject mine in mines)
                {
                    mine.thisHereButton.BackColor = Color.Red;
                }

                MessageBox.Show("Oh no, you dun goofed it now");
                Reset();
            }
            else
            {
                thisGuy.Clearing(new List<ButtonObject>(), mines);
            }
        }

        void AlertNeighbours(ButtonObject button)
        {
            int butX = button.xPos;
            int butY = button.yPos;

            for(int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if(butX + x >= 0 && butX + x < gridX && butY + y >= 0 && butY + y < gridY)
                    {
                        if (mines.Contains(button))
                        {
                            grid[butX + x, butY + y].numNeighbourBombs++;
                        }
                        button.neighbours.Add(grid[butX + x, butY + y]);                        
                    }
                }
            }            
        }


        private void Container_Enter(object sender, EventArgs e)
        {

        }
    }
}

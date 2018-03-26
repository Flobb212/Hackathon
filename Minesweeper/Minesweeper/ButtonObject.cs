using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class ButtonObject
    {
        public List<ButtonObject> neighbours = new List<ButtonObject>();
        public int numNeighbourBombs = 0;
        public Button thisHereButton;
        public int xPos;
        public int yPos;
        public GroupBox contans;

        public List<ButtonObject> Clearing(List<ButtonObject> checkedButtons, ButtonObject[] mines)
        {
            checkedButtons.Add(this);

            if (numNeighbourBombs > 0)
            {
                TextBox val = new TextBox();
                val.Width = 25;
                val.Height = 25;
                val.Text = numNeighbourBombs.ToString();
                val.Location = new System.Drawing.Point(25 + xPos * 25, 40 + yPos * 25);
                val.BringToFront();
                contans.Controls.Add(val);
                thisHereButton.Dispose();
                return checkedButtons;
            }

            foreach (ButtonObject neigh in neighbours)
            {
                if(!checkedButtons.Contains(neigh) && !mines.Contains(neigh))
                {
                    checkedButtons = neigh.Clearing(checkedButtons, mines);
                }
            }

            contans.Controls.Remove(thisHereButton);
            thisHereButton.Dispose();

            return checkedButtons;
        }

    }
}

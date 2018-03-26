using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class ButtonObject
    {
        public List<ButtonObject> neighbours = new List<ButtonObject>();
        public int numNeighbourBombs = 0;
        public Button thisHereButton;
        public int xPos;
        public int yPos;

        public List<ButtonObject> Clearing(List<ButtonObject> checkedButtons)
        {


            return checkedButtons;
        }

    }
}

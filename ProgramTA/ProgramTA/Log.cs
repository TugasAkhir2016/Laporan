using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTA
{
    public partial class Log : Form
    {
        public class data
        {
            public int Pixels { set; get; }
            public int H1_Awal { set; get; }
            public int H2_AFCEDP { set; get; }
            public int H3_ACEDP { set; get; }
            public data(int pixels,int h1,int h2,int h3)
            {
                Pixels = pixels;
                H1_Awal = h1; H2_AFCEDP = h2; H3_ACEDP = h3;
            }
        }
        List<data> datatoShow;
        int[] h1;
        int[] h2;
        int[] h3;
        public Log(int[] H, int[] H2, int[] H3)
        {
            this.h1 = H;
            this.h2 = H2;
            this.h3 = H3;
            datatoShow = new List<data>();
            InitializeComponent();
        }


        private void Log_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < h1.Length; i++)
            {
                datatoShow.Add(new data(i , h1[i], h2[i], h3[i]));
            }
            var bind = new Library.Forms.SortableBindingList<data>(datatoShow);
            //var bind = new BindingList<data>(datatoShow);
            dataGridView1.DataSource = bind;
            dataGridView1.Refresh();
            button1.Enabled = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dataGridView1.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dataGridView1.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
            
            //this.dataGridView1.Sort(this.dataGridView1.Columns[dtg_Column.Name], ListSortDirection.Ascending)
        }
        private void dataGridView1_DataBindingComplete(object sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode. 
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}

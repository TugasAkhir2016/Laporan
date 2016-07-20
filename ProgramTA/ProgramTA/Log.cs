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
            public int Pixels_Citra_Awal { set; get; }
            public int JumlahKemunculan { set; get; }
            public int Pixel_Citra_AFCEDP { set; get; }
            public int Jumlah_kemunculan { set; get; }
            public int Pixel_Citra_ACEDP { set; get; }
            public int jumlah_kemunculan_ { set; get; }
            public data(int pixels,int h1,int f1,int h2,int f2,int h3)
            {
                Pixels_Citra_Awal = pixels;
                JumlahKemunculan = h1;
                Pixel_Citra_AFCEDP = f1;
                Jumlah_kemunculan = h2;
                Pixel_Citra_ACEDP = f2;
                jumlah_kemunculan_ = h3;
            }
        }
        List<data> datatoShow1;
        int[] h1;
        int[] h2;
        int[] h3;
        int[] f1;
        int[] f2;
        public Log(int[] H, int[] H2, int[] H3,int[] F1,int[] F2)
        {
            this.h1 = H;
            this.h2 = H2;
            this.h3 = H3;
            f1 = F1; f2 = F2;
            datatoShow1 = new List<data>();
            InitializeComponent();
        }


        private void Log_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false; //dataGridView2.Visible = false; dataGridView3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            for (int i = 0; i < h1.Length; i++)
            {
                datatoShow1.Add(new data(i,h1[i],f1[i],h2[f1[i]],f2[i],h3[f2[i]]));
            }
            var bind1 = new Library.Forms.SortableBindingList<data>(datatoShow1);
            //var bind = new BindingList<data>(datatoShow);
            dataGridView1.DataSource = bind1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            button1.Enabled = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewColumn newColumn = dtg.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dtg.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dtg.SortOrder == SortOrder.Ascending)
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
            //if(dtg == dataGridView1)
            //{
            //    dataGridView1.Sort(newColumn, direction);
            //}
            //else if(dtg == dataGridView2)
            //{
            //    dataGridView2.Sort(newColumn, direction);
            //}
            //else
            //{
            //    dataGridView3.Sort(newColumn, direction);
            //}
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

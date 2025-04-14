using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using World = Microsoft.Office.Interop.Word;

namespace ModulFo
{
    public class WorldWriter
    {
        public void WriteToWord(string[] data, string patch, int rowIndex, int columnIndex) { 
        World.Application application = new World.Application();
            application.Visible = false;
            World.Document doc = null;
            try {
                doc = application.Documents.Open(patch);
                World.Table table = doc.Tables[1];
                table.Cell(rowIndex,1).Range.Text = data[0];
                table.Cell(rowIndex, 3).Range.Text = data[1];
                doc.Save();
                doc.Close();
                application.Quit();
                MessageBox.Show("Данные успешно внесены в таблицу!");
            }
            catch(Exception e) {
                doc.Close();
                application.Quit();
                MessageBox.Show(e.ToString());
            }
        }
    }
}

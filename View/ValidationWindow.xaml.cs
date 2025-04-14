using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModulFo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ValidationWindow : Window
    {
        WorldWriter worldWriter;
        int index = 3;
        public ValidationWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string respond = await ServerRequest.getFio("http://localhost:4444/TransferSimulator/fullName");
            FioName.Text = formatText(respond);
        }

        private string formatText(string fio) {
           return fio.Substring(fio.IndexOf(":")+2).Replace("}", "").Replace("\"", "");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorldWriter worldWriter = new WorldWriter();
            if (!validateName((FioName.Text))){
                ResultBox.Text = "Успешно";
            } else ResultBox.Text = "не успешно";
            string[] data = { $"{FioName.Text}", $"{ResultBox.Text}" };
            worldWriter.WriteToWord(data, "C:\\Users\\admin\\Desktop\\№54826140\\ModulFo\\ТестКейс.docx", index,1);
            index++;
        }

        private bool validateName(string fio) {
            return Regex.IsMatch(fio, @"[^а-яА-ЯёЁ0-9\s]");
        }
    }
}

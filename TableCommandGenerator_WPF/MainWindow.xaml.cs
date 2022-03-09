using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TableCommandGenerator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Document.Blocks.Clear();
            if (nameTable.Text != "" && indexArray.Text != "" && indexId.Text != "")
            {
                string mode = commandSelecter.Text;
                String answer = "";
                int indexStart = int.Parse(indexArray.Text.Split(':')[0].Split(' ')[1]);
                switch (mode){
                    case "ВПР":
                        answer += $"=ВПР({indexId.Text};'{nameTable.Text}'!$A${indexArray.Text.Split(':')[0].Split(' ')[1]}:${indexArray.Text.Split(':')[1].Split(' ')[0]}${int.Parse(namberOfNotes.Text) + indexStart - 1};{int.Parse(namberOfColums.Text)};ЛОЖЬ)";
                        break;
                    case "ВЫБОР":


                        answer += $"=ВЫБОР({indexId.Text};";
                        for (int i = indexStart; i <= int.Parse(namberOfNotes.Text) + indexStart; i++)
                        {
                            if (i != int.Parse(namberOfNotes.Text) + indexStart && !nameTable.Text.Contains(' '))
                                answer += $"TEXTJOIN(\" \"; ИСТИНА; {nameTable.Text}!{indexArray.Text.Split(':')[0].Split(' ')[0]}{i}:{indexArray.Text.Split(':')[1].Split(' ')[0]}{i});";
                            if (i == int.Parse(namberOfNotes.Text) + indexStart && !nameTable.Text.Contains(' '))
                                answer += $"TEXTJOIN(\" \"; ИСТИНА;{nameTable.Text}!{indexArray.Text.Split(':')[0].Split(' ')[0]}{i}:{indexArray.Text.Split(':')[1].Split(' ')[0]}{i}))";
                            if (i != int.Parse(namberOfNotes.Text) + indexStart && nameTable.Text.Contains(' '))
                                answer += $"TEXTJOIN(\" \"; ИСТИНА; '{nameTable.Text}'!{indexArray.Text.Split(':')[0].Split(' ')[0]}{i}:{indexArray.Text.Split(':')[1].Split(' ')[0]}{i});";
                            if (i == int.Parse(namberOfNotes.Text) + indexStart && nameTable.Text.Contains(' '))
                                answer += $"TEXTJOIN(\" \"; ИСТИНА;'{nameTable.Text}'!{indexArray.Text.Split(':')[0].Split(' ')[0]}{i}:{indexArray.Text.Split(':')[1].Split(' ')[0]}{i}))";

                        }
                        break;
                }

                
                OutputTextBox.AppendText(answer);

            }//dfdf
            else
            {
                MessageBox.Show(
                    "Не все поля заполнены!",
                    "Ошибка"
                    );
            }
        }

        private void namberOfNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }

        private void namberOfColums_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }
    }
}

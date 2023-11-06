using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

namespace WpfApp3
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

        Thread thread1 = new Thread(() => { });
        string b = null;

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(selectedFileName);
                    textbox.Text = fileContent;
                    b = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya okuma hatası: " + ex.Message);
                }
            }
        }

        private void ___Click(object sender, RoutedEventArgs e)
        {
            progress.Maximum = b.Length;
            thread1 = new Thread(() =>
            {
                for (int i = 0; i < b.Length; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        textbox2.Text += b[i];
                        progress.Value += 1;
                    });
                    Thread.Sleep(1000);
                }
            });
            thread1.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thread1.Suspend();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            thread1.Resume();
        }
    }
}

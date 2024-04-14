using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace WayOfTheSamurai4SaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SaveDataFile? SaveData { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            try
            {
                SaveData = new SaveDataFile(dialog.FileName);
                DataContext = SaveData;
            }
            catch (FileNotFoundException)
            {
                string messageBoxText = "ファイルが見つかりません。\nファイル名を確認して再実行してください";
                string caption = "開く";
                var button = MessageBoxButton.OK;
                var icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.Message;
                string caption = "開く";
                var button = MessageBoxButton.OK;
                var icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (SaveData is null)
            {
                return;
            }

            SaveFile(SaveData.Path);
        }

        private void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            SaveFile(dialog.FileName);
        }

        private void SaveFile(string path)
        {
            if (SaveData is null)
            {
                return;
            }

            try
            {
                SaveData.Write(path);
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.Message;
                string caption = "保存";
                var button = MessageBoxButton.OK;
                var icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
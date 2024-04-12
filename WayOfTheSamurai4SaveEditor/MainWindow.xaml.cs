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
        public SaveData Save { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();

            // Data binding
            mainCharacterDataGrid.ItemsSource = Save.MainCharacters;
            taitouDataGrid.ItemsSource = Save.Taitou;
            bukiBukuroDataGrid.ItemsSource = Save.BukiBukuro;
            bukiDansuDataGrid.ItemsSource = Save.BukiDansu;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == false)
            {
                return;
            }

            var path = dialog.FileName;
            try
            {
                Save = SaveDataLoader.Load(path);
            }
            catch (FileNotFoundException)
            {
                string messageBoxText = "ファイルが見つかりません。\nファイル名を確認して再実行してください";
                string caption = "開く";
                var button = MessageBoxButton.OK;
                var icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                throw;
            }

            // Data binding
            mainCharacterDataGrid.ItemsSource = Save.MainCharacters;
            taitouDataGrid.ItemsSource = Save.Taitou;
            bukiBukuroDataGrid.ItemsSource = Save.BukiBukuro;
            bukiDansuDataGrid.ItemsSource = Save.BukiDansu;
        }
    }
}
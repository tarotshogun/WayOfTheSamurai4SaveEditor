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
        // TODO: Move to ViewModel
        RawSaveData raw;
        SaveDataViewModel save;

        public MainWindow()
        {
            InitializeComponent();
            raw = new();
            save = new();
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
                raw = SaveDataAccessor.Load(dialog.FileName);
                save = new SaveDataViewModel(raw);
                DataContext = save;
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
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            // クラス構成ぐちゃぐちゃですがな
            MainCharacterConverter.ToRawMainCharacter(save.MainCharacters[0], ref raw);
            WeaponConverter.ToRawBukiDansuWeapons(save.BukiDansu, ref raw.BukiDansu);

            try
            {
                SaveDataAccessor.Save(dialog.FileName, raw);
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
    }
}
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;


namespace WayOfTheSamurai4SaveEditor
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string DefaultTitle = "侍道4セーブエディタ";

        // TODO: Replace to `ReactiveProperty`
        public SaveDataFile? SaveData
        {
            get { return _saveData; }
            set
            {
                _saveData = value;
                NotifyPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand OpenFileCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveAsFileCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        SaveDataFile? _saveData = null;
        string _title = DefaultTitle;

        public MainWindowViewModel()
        {
            OpenFileCommand = new DelegateCommand(OpenFile);
            SaveFileCommand = new DelegateCommand(SaveFile, CanSaveFile)
                .ObservesProperty(() => SaveData);
            SaveAsFileCommand = new DelegateCommand(SaveAsFile, CanSaveFile)
                .ObservesProperty(() => SaveData);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool CanSaveFile()
        {
            return SaveData is not null;
        }

        void OpenFile()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            try
            {
                SaveData = new SaveDataFile(dialog.FileName);
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

            if (SaveData is not null)
            {
                var fileName = System.IO.Path.GetFileName(SaveData.Path);
                Title = DefaultTitle + " - " + fileName;
            }
        }

        void SaveFile()
        {
            Debug.Assert(SaveData is not null);
            SaveFile(SaveData.Path);
        }

        void SaveAsFile()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            SaveFile(dialog.FileName);
        }

        void SaveFile(string path)
        {
            try
            {
                Debug.Assert(SaveData is not null);
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

using Endless_Development_Project_Studio.DataStorage;
using Microsoft.Win32;
using ReDive_Bot.library.PrincessDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Endless_Development_Project_Studio.Controls
{
    public class ServerSettingsControlViewModel : BaseViewModel
    {
        public ICommand Cancel { get; set; }
        public ICommand OpenFolder { get; set; }
        public ICommand SaveSettings { get; set; }
        public ICommand OpenSettigs { get; set; }
        public ICommand Start { get; set; }
        public string JarFile { get; set; }
        public string ServerPath { get; set; }
        public string MinRam { get; set; }
        public string MaxRam { get; set; }
        public string Parameter { get; set; }
        public string ChangeDate { get; set; }
        public string Title { get; set; }
        public double CurrentHeight { get; set; } = 100;
        public ulong id { get; set; }
        public double SectionOpacity { get; set; }
        public ServerSettingsModel Complex { get; set; }
        public ServerWindow _ServerWindow { get; set; }
        public ServerSettingsControlViewModel(ulong id)
        {
            Cancel = new RelayCommand(CancelAction);
            OpenFolder = new RelayCommand(OpenFolderAction);
            SaveSettings = new RelayCommand(SaveSettingsAction);
            OpenSettigs = new RelayCommand(OpenSettigsAction);
            Start = new RelayCommand(OnStart);
            SectionOpacity = 1;
            OnPropertyChanged(nameof(SectionOpacity));
            OnPropertyChanged(nameof(Cancel));
            OnPropertyChanged(nameof(OpenFolder));
            OnPropertyChanged(nameof(OpenSettigs));
            OnPropertyChanged(nameof(SaveSettings));
            OnPropertyChanged(nameof(Start));
            Complex = ServerSave.GetSettings(id);

            Title = Complex.Title;
            JarFile = Complex.JarFile;
            MinRam = Complex.MinRam;
            MaxRam = Complex.MaxRam;
            Parameter = Complex.Parameter;
            ServerPath = Complex.StartFolder;
            ChangeDate = Complex.ChangeDate;

            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(JarFile));
            OnPropertyChanged(nameof(MinRam));
            OnPropertyChanged(nameof(MaxRam));
            OnPropertyChanged(nameof(ChangeDate));
        }
        public ServerSettingsControlViewModel()
        {
          
        }
         
        public void OnStart()
        {
            string @jarfile = JarFile;
            string @serverPath = ServerPath;
            StringBuilder ParameterStringBuilder = new StringBuilder();
            ParameterStringBuilder.Append("-server");
            ParameterStringBuilder.Append($" {MinRam}");
            ParameterStringBuilder.Append($" {MaxRam}");
            ParameterStringBuilder.Append($" {Parameter}");
            ParameterStringBuilder.Append(" -jar");
            ParameterStringBuilder.Append($" \"\"{@jarfile}\"\"");
            ParameterStringBuilder.Append(" nogui");
            Process p = new Process();
            var path = @serverPath;

            Console.WriteLine("\"" + ParameterStringBuilder.ToString() + "|" + path + "\"");
            p.StartInfo.Arguments = " \" " + ParameterStringBuilder.ToString() + "|" + path + " \"";
            p.StartInfo.FileName = "C:\\EDP\\Builds\\EDP-External_Output.exe";
            p.Start();
          //_ServerWindow = new ServerWindow(ParameterStringBuilder.ToString(), @serverPath);
          //_ServerWindow.Show();
        }
        public void CancelAction()
        {
            SectionOpacity = 1;
            ServerSectionCache.SSPath = "";
            OnPropertyChanged(nameof(SectionOpacity));
            ServerSectionCache.SectionObject = null;
            Title = Complex.Title;
            JarFile = Complex.JarFile;
            MinRam = Complex.MinRam;
            MaxRam = Complex.MaxRam;
            Parameter = Complex.Parameter;
            ServerPath = Complex.StartFolder;
            ChangeDate = Complex.ChangeDate;

            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(JarFile));
            OnPropertyChanged(nameof(MinRam));
            OnPropertyChanged(nameof(MaxRam));
            OnPropertyChanged(nameof(Parameter));
            OnPropertyChanged(nameof(ChangeDate));
            CurrentHeight = 100;
            OnPropertyChanged(nameof(CurrentHeight));
            ServerSectionCache.ChangeSection();
        }
        public void OpenFolderAction()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += (e, y) => { if (y.Cancel == false) { JarFile = openFileDialog.FileName; OnPropertyChanged(nameof(JarFile)); } };
            openFileDialog.ShowDialog();
            ServerSectionCache.ChangeSection();
        }
        public void SaveSettingsAction()
        {
            SectionOpacity = 1;
            ServerSectionCache.SSPath = "";
            OnPropertyChanged(nameof(SectionOpacity));
            ServerSectionCache.SectionObject = null;
            Complex.Title = Title;
                Complex.JarFile = JarFile;
                Complex.MinRam = MinRam;
                Complex.MaxRam = MaxRam;
                Complex.Parameter = Parameter;
            try
            {
                ServerPath = JarFile.Replace(JarFile.Split('\\').LastOrDefault(), "");
            }
            catch { }
                Complex.StartFolder = ServerPath;
          

            CurrentHeight = 100;

            ChangeDate = DateTime.Now.ToString();
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(ChangeDate));
            OnPropertyChanged(nameof(CurrentHeight));
            Complex.ChangeDate = ChangeDate;
            ServerSave.SaveSettingsContainer();
            ServerSectionCache.ChangeSection();
        }
        public void OpenSettigsAction()
        {
            CurrentHeight = 310;
            OnPropertyChanged(nameof(CurrentHeight));
            ServerSectionCache.SSPath = ServerPath;
            SectionOpacity = 0.5;
            OnPropertyChanged(nameof(SectionOpacity));
            ServerSectionCache.SectionObject = this;
            ServerSectionCache.ChangeSection();
        }
    }
    public class ServerSettingsControlDesign : ServerSettingsControlViewModel
    {
        public static ServerSettingsControlDesign Instance
      => new ServerSettingsControlDesign();
    }
    public class ServerSettingsItemListControlDesign : BaseViewModel
    {
        public static ServerSettingsItemListControlDesign Instance
    = new ServerSettingsItemListControlDesign();
        public BindingList<ServerSettingsControlViewModel> Items { get; set; } = new BindingList<ServerSettingsControlViewModel>();
    }

}

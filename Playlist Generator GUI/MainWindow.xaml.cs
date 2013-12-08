using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PlaylistGenerator {
    public partial class MainWindow : Window {
        private MainWindowViewModel ViewModel {
            get { return (MainWindowViewModel)DataContext; }
        }

        private Generator Generator { get; set; }

        public MainWindow() {
            InitializeComponent();

            Generator = new Generator();

            //Set window title.
            Title = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        private void browse_Click(object sender, RoutedEventArgs e) {
            //Create folder browser dialog.
            using (var d = new System.Windows.Forms.FolderBrowserDialog()) {
                d.ShowNewFolderButton = false;
                d.SelectedPath = ViewModel.Directory;
                d.Description = "Pick a folder with music files.";

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ViewModel.Directory = d.SelectedPath;
            }
        }

        private void generate_Click(object sender, RoutedEventArgs e) {
            Generator.Configuration = new GuiConfiguration(ViewModel);
            Generator.CreatePlaylists();

            ViewModel.Status = String.Format(
                "Wrote {0} {1}s to \"{2}\"",
                ViewModel.SelectedFiles.Length,
                ViewModel.SelectedFileType.TrimStart('.'),
                Generator.Configuration.Contexts[0].FileName
            );            
        }
    }
}

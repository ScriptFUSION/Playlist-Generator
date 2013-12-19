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

            ParseCommandLineArguments();
        }

        private void ParseCommandLineArguments() {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1) //Argument 0 is the application path.
                //Assume argument 1 is a directory.
                ViewModel.Directory = args[1];
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

        private void Window_Drop(object sender, DragEventArgs e) {
            var d = (DataObject)e.Data;

            if (d.ContainsFileDropList())
                //Assume first file is a directory.
                ViewModel.Directory = d.GetFileDropList()[0];
        }

        /* PreviewDragOver is required instead of DragOver event for drag to
         * work with TextBox controls for some reason. Cursor still glitches
         * when passing over TextBox borders. Can't drag over Window chrome. */
        private void Window_PreviewDragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true;
            }
        }
    }
}

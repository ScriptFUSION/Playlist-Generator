using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

using FileDirectory = System.IO.Directory;

namespace PlaylistGenerator {
    sealed class MainWindowViewModel : ViewModel {
        //Working directory.
        private string directory;

        //Files in working directory.
        private string[] files;

        //File types in working directory, count.
        private Dictionary<string, int> fileTypes = new Dictionary<string, int>();

        //File type selected by user.
        private string selectedFileType;

        //Status bar message.
        private StatusMessage statusMessage = new StatusMessage();

        public MainWindowViewModel() {
            statusMessage.MessageChanged += delegate { OnPropertyChanged("Status"); };
        }

        public string Directory {
            get { return directory; }
            set {
                directory = value;

                OnPropertyChanged();

                //Update dependent properties.
                if (FileDirectory.Exists(value)) {
                    //Find files in directory.
                    Files = FileDirectory.GetFiles(Directory);

                    //Extract and count file types.
                    FileTypes = PathUtils.ExtractFileExtensions(Files).CountValues();
                }
                else {
                    Files = null;
                    FileTypes = null;
                }
            }
        }

        public string[] Files {
            get { return files; }
            set {
                files = value;

                OnPropertyChanged();
                OnPropertyChanged("SelectedFiles");
            }
        }
        
        public Dictionary<string, int> FileTypes {
            get { return fileTypes; }
            set {
                fileTypes = value;

                OnPropertyChanged();
            }
        }

        public string SelectedFileType {
            get { return selectedFileType; }
            set {
                selectedFileType = value;

                OnPropertyChanged();
                OnPropertyChanged("SelectedFiles");
            }
        }

        /// <summary>
        /// Gets a dynamically generated subset of Files filtered by SelectedFileType extension.
        /// </summary>
        public string[] SelectedFiles {
            get {
                if (Files == null || SelectedFileType == null)
                    return Files;

                return PathUtils.ExtractFileNames(Files.Where(f => f.EndsWith(SelectedFileType)));
            }
        }

        public string Status {
            get { return statusMessage.Message; }
            set { statusMessage.Message = value; }
        }
    }
}

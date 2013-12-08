using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace PlaylistGenerator {
    abstract class ViewModel : INotifyPropertyChanged {
        private PropertyChangedEventHandler eh;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged {
            add { eh += value; }
            remove { eh -= value; }
        }

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string property = null) {
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(property));
        }
    }
}

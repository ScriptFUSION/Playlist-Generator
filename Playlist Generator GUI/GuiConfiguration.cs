using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistGenerator {
    class GuiConfiguration : Configuration {
        public GuiConfiguration(MainWindowViewModel viewModel) {
            Contexts.Add(
                new PlaylistContext(
                    new M3U(viewModel.SelectedFiles),
                    viewModel.Directory
                )
            );
        }
    }
}

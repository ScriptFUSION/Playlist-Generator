using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace PlaylistGenerator {
    /// <summary>
    /// Shows the specified DefaultMessage until its Message property is set.
    /// Message returns to DefaultMessage after the specified timeout.
    /// </summary>
    class StatusMessage {
        private const string DEFAULT_MESSAGE = "Ready";

        private string message;
        private Timer timer;

        public event EventHandler MessageChanged;

        public StatusMessage(int timeout = 5000) {
            message = DefaultMessage = DEFAULT_MESSAGE;

            timer = new Timer(timeout);
            timer.AutoReset = false;
            timer.Elapsed += delegate { Message = DefaultMessage; };
        }
        
        public string Message {
            get { return message; }

            set {
                message = value;

                if (MessageChanged != null)
                    //Raise MessageChanged event.
                    MessageChanged(this, null);

                if (value != DefaultMessage) {
                    //Restart timer to return message to default.
                    timer.Stop();
                    timer.Start();
                }
            }
        }

        public string DefaultMessage { get; set; }
    }
}

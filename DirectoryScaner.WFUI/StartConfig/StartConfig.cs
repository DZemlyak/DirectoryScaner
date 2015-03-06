using System.IO;
using System.Windows.Forms;

namespace DirectoryScaner.WFUI.StartConfig
{
    static class StartConfig {
        public static void GetLogicalDrives(ComboBox control) {
            foreach (var logicalDrive in Directory.GetLogicalDrives()) {
                control.Items.Add(logicalDrive);
            }
            control.SelectedIndex = 0;
        }
    }
}

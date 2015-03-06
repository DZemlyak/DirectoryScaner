using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using DirectoryScaner.Contracts;
using DirectoryScaner.WFUI.Data;
using DirectoryScaner.WFUI.Properties;
using DirectoryScaner.WFUI.Visualization;

namespace DirectoryScaner.WFUI
{
    public partial class MainForm : Form
    {
        #region Variables

        private string _mainDirectory;
        private string _xmlFilePath;
        
        private Thread _scanThread;
        private readonly Thread _visualizeThread;
        private Thread _writeThread;

        private IDirectoryScaner _scaner;
        private readonly IVisualizer _visualizer;
        private IWriter _saver;
        
        private FolderData _folderData;

        // Control directories scanning
        public static ManualResetEvent ScanerAwaiter;

        // Control tree visualization
        public static ManualResetEvent TreeAwaiter;

        // Control data visualiztion ending
        public static ManualResetEvent MainAwaiter;

        // Control writing to file
        public static ManualResetEvent WriterAwaiter;

        #endregion

        public MainForm() {
            InitializeComponent();

            StartConfig.StartConfig.GetLogicalDrives(comboBox_directories);

            saveFileDialog_file_path.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            
            ScanerAwaiter = new ManualResetEvent(false);
            TreeAwaiter = new ManualResetEvent(false);
            MainAwaiter = new ManualResetEvent(false);
            WriterAwaiter = new ManualResetEvent(false);

            _folderData = new FolderData();
            
            _visualizer = new TreeVisualizer(Visualization);

            _visualizeThread = new Thread(_visualizer.Visualize) {Name = "Visualization"};
            _visualizeThread.Start();

            _scaner = new DirectoryScaner(_folderData, InitializeErrorDisplay);
        }

        #region Visualization

        public delegate void TreeVisualizeCallBack();

        // We need Invole method, because access to form elements allowed only from main thred
        private void Visualization() {
            var callback = new TreeVisualizeCallBack(VisualizeTree);
            Invoke(callback);
        }

        public void VisualizeTree() {
            try {
                if (String.IsNullOrEmpty(_folderData.ParentPath) && String.IsNullOrEmpty(_folderData.Directory)) {
                    foreach (var file in _folderData.Files) {
                        treeView_directory.Nodes.Add(file);
                    }
                }
                else if (!String.IsNullOrEmpty(_folderData.Directory) && _folderData.ParentPath.Equals(_mainDirectory)) {
                    treeView_directory.Nodes.Add(_folderData.Directory).Name = _folderData.Directory;
                    foreach (var file in _folderData.Files) {
                        treeView_directory.Nodes[_folderData.Directory].Nodes.Add(file);
                    }
                }
                else {
                    var node = GetTreeNode();
                    node.Nodes.Add(_folderData.Directory).Name = _folderData.Directory;
                    foreach (var file in _folderData.Files) {
                        node.Nodes[_folderData.Directory].Nodes.Add(file);
                    }
                }
            }
            catch (Exception e) {
                InitializeErrorDisplay(e);
            }
            finally {
                MainAwaiter.Set();
            }
        }

        #endregion

        #region Error messages

        public delegate void ErrorCallBack(Exception e);

        // We need Invole method, because access to form elements allowed only from main thred
        private void InitializeErrorDisplay(Exception e) {
            var callback = new ErrorCallBack(DisplayError);
            Invoke(callback, e);
        }

        private void DisplayError(Exception e) {
            richTextBox_info.Text = String.Format(e.Message.ToString(CultureInfo.InvariantCulture) + Environment.NewLine) + richTextBox_info.Text;
        }

        #endregion

        #region Form Events

        private void button_scan_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(_xmlFilePath)) {
                MessageBox.Show("Select the file, results should be saved to!", "Notice");
                return;
            }
            _mainDirectory = comboBox_directories.SelectedItem.ToString();
            treeView_directory.Nodes.Clear();
            richTextBox_info.Text = Resources.MainForm_Scanning_has_been_started;
            DisableElements();

            DirectoryScaner.ThreadFinished = false;

            _saver = new XmlWriter(_folderData, _xmlFilePath, _mainDirectory, InitializeErrorDisplay);
            _writeThread = new Thread(_saver.Write) { Name = "Writer" };
            _writeThread.Start();

            _scanThread = new Thread(() => {
                _scaner = new DirectoryScaner(_folderData, InitializeErrorDisplay);
                _scaner.Scan(String.Empty, _mainDirectory, new List<string>());
                MessageBox.Show(Resources.MainForm_Scanning_is_finished, Resources.MainForm_Header_Finished);
                _writeThread.Abort();
                _folderData = new FolderData();
                var callback = new Action(EnableElements);
                Invoke(callback);
            }) { Name = "Scaner" };
            _scanThread.Start();
        }

        private void button_cancelScan_Click(object sender, EventArgs e) {
            
            DirectoryScaner.ThreadFinished = true;
            _scanThread.Abort();
            _writeThread.Abort();
            Application.DoEvents();
            StopScanning();
            _folderData = new FolderData();
        }

        private void treeView_directory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            ClearInfo();
            var path = _mainDirectory + e.Node.FullPath;
            try {
                dynamic info = new DirectoryInfo(path);
                if (!info.Exists) {
                    info = new FileInfo(path);
                    DisplayFileSize(info);
                }
                else CountDirectorySize(info);

                DisplayInfo(info);
            }
            catch (IdentityNotMappedException) {
                InitializeErrorDisplay(new Exception("Cannot get user's identity for selected node!"));
            }
            catch (Exception ex) {
                InitializeErrorDisplay(ex);
            }
        }

        private void button_file_path_Click(object sender, EventArgs e) {
            saveFileDialog_file_path.ShowDialog();
        }

        private void saveFileDialog_file_path_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            label_file_path.Text = _xmlFilePath = saveFileDialog_file_path.FileName;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Process.GetCurrentProcess().Kill();
        }

        #endregion

        #region Support methods

        public TreeNode GetTreeNode() {
            var parent = _folderData.ParentPath.Substring(0, _folderData.ParentPath.Length - 1);
            var parentPath = parent.Substring(3);
            parent = parent.Substring(parent.LastIndexOf('\\') + 1);
            var nodes = treeView_directory.Nodes.Find(parent, true);
            var node = nodes.First(x => x.FullPath == parentPath);
            return node;
        }

        private void DisableElements() {
            button_cancelScan.Enabled = true;
            button_scan.Enabled = false;
            comboBox_directories.Enabled = false;
        }

        private void EnableElements() {
            button_cancelScan.Enabled = false;
            button_scan.Enabled = true;
            comboBox_directories.Enabled = true;
        }

        private void StopScanning() {
            MainAwaiter.Reset();
            ScanerAwaiter.Reset();
            TreeAwaiter.Reset();
            WriterAwaiter.Reset();
            EnableElements();
        }
        
        private void DisplayInfo(FileSystemInfo info) {
            var generalDictionary = FolderData.GetGeneralInfo(info);
            label_name.Text = generalDictionary["Name"];
            label_creationDate.Text = generalDictionary["CreationTime"];
            label_modificationDate.Text = generalDictionary["LastWriteTime"];
            label_lastAccessDate.Text = generalDictionary["LastAccessTime"];
            label_attributes.Text = generalDictionary["Attributes"];

            var specialInfoDictionary = FolderData.GetSpecialInfo(info);
            label_owner.Text = specialInfoDictionary["Owner"];
            label_rights.Text = specialInfoDictionary["Rights"];
        }


        private delegate void DisplayFolderSizeCallback(long size);
        private void CountDirectorySize(DirectoryInfo info) {
            long size = 0;
            Action getSize = () => FolderData.GetFolderSize(info, ref size, true);
            var callback = new DisplayFolderSizeCallback(DisplayDirectorySize);
            getSize.BeginInvoke(delegate { Invoke(callback, size); }, null);
        }

        private void DisplayDirectorySize(long size) {
            label_size.Text = string.Format("{0:N} b", size);
        }
        
        private void DisplayFileSize(FileInfo info) {
            label_size.Text = info.Length / 1000000 == 0 ? info.Length / 1000 + " KB" : info.Length / 1000000 + " MB";
        }

        private void ClearInfo() {
            label_name.Text = label_creationDate.Text = label_modificationDate.Text =
            label_lastAccessDate.Text = label_attributes.Text = label_owner.Text = 
            label_rights.Text = String.Empty;
            label_size.Text = Resources.MainForm_ClearInfo_Calculating;
        }

        #endregion

    }
}


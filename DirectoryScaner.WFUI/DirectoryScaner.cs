using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DirectoryScaner.Contracts;

namespace DirectoryScaner.WFUI
{
    public sealed class DirectoryScaner : IDirectoryScaner
    {
        public static volatile bool ThreadFinished;
        private readonly FolderData _folderData;
        
        // Callback returns error to form class to be shown on form in nain thread
        private readonly MainForm.ErrorCallBack _errorCallBack;

        public DirectoryScaner(FolderData folderData, MainForm.ErrorCallBack errorCallBack) {
            _folderData = folderData;
            _errorCallBack = errorCallBack;
        }

        public void Scan(string directory, string parentDirectory, List<string> unavailableDirectories) {
            try {
                if (!new DriveInfo(parentDirectory).IsReady) throw new Exception("Drive is not ready!");

                if (String.IsNullOrEmpty(directory)) {
                    _folderData.Files.Clear();
                    GetFiles(parentDirectory);
                    ChangeThreads();
                }

                foreach (var d in Directory.GetDirectories(parentDirectory + directory)) {

                    var info = new DirectoryInfo(d);

                    if (info.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    if (unavailableDirectories.Contains(d.Substring(d.LastIndexOf('\\') + 1)))
                        return;

                    _folderData.ParentPath = info.FullName.Substring(0, info.FullName.LastIndexOf('\\') + 1);
                    _folderData.Directory = d.Substring(d.LastIndexOf('\\') + 1);
                    _folderData.Files.Clear();
                    GetFiles(d);

                    ChangeThreads();

                    Scan(_folderData.Directory, _folderData.ParentPath, unavailableDirectories);
                }
            }
            catch (ThreadAbortException) {
                _errorCallBack(new Exception("Scan has been canceled!"));
                Thread.CurrentThread.Join();
            }
            catch (Exception e) {
                _errorCallBack(e);
                if(String.IsNullOrEmpty(directory)) return;
                unavailableDirectories.Add(_folderData.Directory);
                var parent = _folderData.ParentPath.Substring(0, _folderData.ParentPath.Length - 1);
                Scan(parent.Substring(parent.LastIndexOf('\\') + 1), 
                    parent.Substring(0, parent.LastIndexOf('\\') + 1), unavailableDirectories);
            }
        }

        private void GetFiles(string directory) {
            foreach (var f in Directory.GetFiles(directory)) {
                var info = new FileInfo(f);
                if (info.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                _folderData.Files.Add(f.Substring(f.LastIndexOf('\\') + 1));
            }
        }

        private static void ChangeThreads() {
            MainForm.TreeAwaiter.Set();
            MainForm.ScanerAwaiter.WaitOne();
            MainForm.ScanerAwaiter.Reset();
        }
    }
}

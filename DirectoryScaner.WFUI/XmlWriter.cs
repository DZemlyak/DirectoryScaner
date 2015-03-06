using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DirectoryScaner.Contracts;

namespace DirectoryScaner.WFUI
{
    public class XmlWriter : IWriter
    {
        private const string FileBodyName = "structure";
        private readonly FolderData _folderData;
        private readonly string _filePath;
        private readonly string _mainDirectory;
        private readonly MainForm.ErrorCallBack _errorCallBack;
        
        public XmlWriter(FolderData folderData, string filePath, string mainDirectory, MainForm.ErrorCallBack errorCallback) {
            _folderData = folderData;
            _filePath = filePath;
            _mainDirectory = mainDirectory;
            _errorCallBack = errorCallback;
        }

        public void Write() {
            WriteStartElements();
            while (true) {
                MainForm.WriterAwaiter.WaitOne();
                MainForm.WriterAwaiter.Reset();
                
                WriteData();

                MainForm.ScanerAwaiter.Set();
            }
        }

        private void WriteStartElements() {
            try {
                using (var textWriter = new XmlTextWriter(_filePath, Encoding.UTF8)) {
                    textWriter.WriteStartDocument();
                    textWriter.WriteStartElement(FileBodyName);
                    textWriter.WriteEndElement();
                }
            }
            catch (Exception e) {
                _errorCallBack(e);
            }
        }

        private void WriteData() {
            var document = new XmlDocument();
            try {
                document.Load(_filePath);

                if (String.IsNullOrEmpty(_folderData.ParentPath) && String.IsNullOrEmpty(_folderData.Directory)) {
                    // Adding files to root directory
                    AddFilesNodes(document, document.DocumentElement);
                }
                else if (!String.IsNullOrEmpty(_folderData.Directory) && _folderData.ParentPath.Equals(_mainDirectory)) {
                    // Adding directory to root directory and files to new directory
                    var directoryElement = document.CreateElement("directory");
                    AddDirectoryNodes(document, document.DocumentElement, directoryElement);
                    AddFilesNodes(document, directoryElement);
                }
                else {
                    // Adding directory to other directories and files to new directory
                    var node = GetNode(document);
                    var directoryElement = document.CreateElement("directory");
                    AddDirectoryNodes(document, node, directoryElement);
                    AddFilesNodes(document, directoryElement);
                }
            }
            catch (Exception e) {
                _errorCallBack(e);
            }
            finally {
                document.Save(_filePath);
            }
        }

        // Getting the node pointing depth and Name attribute
        private XmlNode GetNode(XmlDocument document) {
            var nodePath = "/" + FileBodyName;
            for (int i = 0; i < _folderData.ParentPath.Count(x => x.Equals('\\')) - 1; i++) {
                nodePath += "/directory";
            }
            var parentFolder = _folderData.ParentPath.Remove(_folderData.ParentPath.Length - 1);
            nodePath = string.Format("{0}[@Name='{1}']", nodePath, parentFolder.Substring(parentFolder.LastIndexOf('\\') + 1));
            return document.SelectSingleNode(nodePath);
        }

        private void AddDirectoryNodes(XmlDocument document, XmlNode directoryElement, XmlNode directoryToBeAdded) {
            directoryElement.AppendChild(directoryToBeAdded);
            var info = new DirectoryInfo(_folderData.ParentPath + _folderData.Directory);
            AddGeneralAttributes(document, directoryToBeAdded, info);
            AddDirectorySize(document, directoryToBeAdded, info);
        }

        private void AddFilesNodes(XmlDocument document, XmlNode directoryElement) {
            // Adding all files to directory
            foreach (var file in _folderData.Files) {
                var fileElement = document.CreateElement("file");
                directoryElement.AppendChild(fileElement);

                // Adding attributes to file
                var path = _mainDirectory +
                           _folderData.ParentPath.Substring(_folderData.ParentPath.IndexOf('\\') + 1) +
                           _folderData.Directory + "\\" + file;
                var info = new FileInfo(path);
                AddGeneralAttributes(document, fileElement, info);
                AddFileSize(document, fileElement, info);
            }
        }

        private static void AddFileSize(XmlDocument document, XmlNode element, FileInfo info) {
            var attribute = document.CreateAttribute("Size");
            var size = FolderData.GetFileSize(info);
            attribute.Value = size / 1000000 == 0 ? size / 1000 + " KB" : size / 1000000 + " MB";
            element.Attributes.Append(attribute);
        }

        private static void AddDirectorySize(XmlDocument document, XmlNode element, DirectoryInfo info) {
            long size = 0;
            var attribute = document.CreateAttribute("Size");
            FolderData.GetFolderSize(info, ref size);
            attribute.Value = size / 1000000 == 0 ? size / 1000 + " KB" : size / 1000000 + " MB";
            element.Attributes.Append(attribute);
        }

        private static void AddGeneralAttributes(XmlDocument document, XmlNode element, FileSystemInfo info) {
            XmlAttribute attribute;
            foreach (var row in FolderData.GetGeneralInfo(info)) {
                attribute = document.CreateAttribute(row.Key);
                attribute.Value = row.Value;
                element.Attributes.Append(attribute);
            }
            foreach (var row in FolderData.GetSpecialInfo(info)) {
                attribute = document.CreateAttribute(row.Key);
                attribute.Value = row.Value;
                element.Attributes.Append(attribute);
            }
        }
    }
}

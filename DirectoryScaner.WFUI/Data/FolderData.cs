using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace DirectoryScaner.WFUI.Data
{
    public class FolderData
    {
        public string Directory { get; set; }
        public string ParentPath { get; set; }
        public List<string> Files { get; set; }

        public FolderData() {
            Directory = String.Empty;
            ParentPath = String.Empty;
            Files = new List<string>();
        }

        public static Dictionary<string, string> GetGeneralInfo(FileSystemInfo info) {
            var dictionary = new Dictionary<string, string> {
                {"Name", info.Name},
                {"CreationTime", info.CreationTime.ToString(CultureInfo.InvariantCulture)},
                {"LastWriteTime", info.LastWriteTime.ToString(CultureInfo.InvariantCulture)},
                {"LastAccessTime", info.LastAccessTime.ToString(CultureInfo.InvariantCulture)},
                {"Attributes", info.Attributes.ToString()}
            };
            return dictionary;
        }

        public static Dictionary<string, string> GetSpecialInfo(FileSystemInfo info)
        {
            var dictionary = new Dictionary<string, string>();

            dynamic infoForRights;
            var rights = info as DirectoryInfo;
            if (rights != null) {
                infoForRights = rights;
            } else infoForRights = info as FileInfo;

            if(infoForRights == null) throw new Exception("Cannot get file's info about owner and your rights!");

            var specialInfo = infoForRights.GetAccessControl(AccessControlSections.Owner);
            dictionary.Add("Owner", specialInfo.GetOwner(typeof(NTAccount)).Value);

            specialInfo = infoForRights.GetAccessControl(AccessControlSections.Access);
            var rules = specialInfo.GetAccessRules(true, true, typeof (SecurityIdentifier));
            var accessRights =  GetAccessRights(rules);
            dictionary.Add("Rights", accessRights);

            return dictionary;
        }

        public static long GetFileSize(FileInfo info) {
            return info.Length;
        }

        public static void GetFolderSize(DirectoryInfo info, ref long size, bool countRootFiles) {
            if (countRootFiles) {
                size += info.GetFiles().Where(file => !file.Attributes.HasFlag(FileAttributes.Hidden)).Sum(file => file.Length);
            }
            foreach (var directory in info.GetDirectories()
                .Where(directory => !directory.Attributes.HasFlag(FileAttributes.Hidden))) {
                size += directory.GetFiles().Where(file => !file.Attributes.HasFlag(FileAttributes.Hidden))
                    .Sum(file => file.Length);
                GetFolderSize(directory, ref size, false);
            }
        }

        private static string GetAccessRights(dynamic rules) {
            var accessRights = String.Empty;
            var userIdentity = WindowsIdentity.GetCurrent();
            
            foreach (FileSystemAccessRule rule in rules) {
                var sid = (SecurityIdentifier) rule.IdentityReference;

                if ((!sid.IsAccountSid() || userIdentity.User != sid) && (sid.IsAccountSid() || !userIdentity.Groups.Contains(sid)))
                    continue;
                if (rule.AccessControlType != AccessControlType.Allow) continue;
                if (((rule.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData)) {
                    if(!accessRights.Contains("Write"))
                        accessRights += "Write | ";
                }
                if (((rule.FileSystemRights & FileSystemRights.ReadData) == FileSystemRights.ReadData)) {
                    if (!accessRights.Contains("Copy"))
                        accessRights += "Copy | ";
                }
                if (((rule.FileSystemRights & FileSystemRights.AppendData) == FileSystemRights.AppendData)) {
                    if (!accessRights.Contains("Append")) 
                        accessRights += "Append | ";
                }
                if (((rule.FileSystemRights & FileSystemRights.Delete) == FileSystemRights.Delete)) {
                    if (!accessRights.Contains("Delete")) 
                        accessRights += "Delete | ";
                }
                if (((rule.FileSystemRights & FileSystemRights.FullControl) != FileSystemRights.FullControl)) continue;
                if (!accessRights.Contains("Full Control")) {
                    accessRights = "Full Control";
		    break;
		}
            }
            return accessRights;
        }
    }
}

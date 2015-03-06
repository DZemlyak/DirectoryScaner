using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScaner.Contracts
{
    public interface IDirectoryScaner
    {
        void Scan(string directory, string parentDirectory, List<string> unavailableDirectories);
    }
}

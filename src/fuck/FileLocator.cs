using System;

namespace fuck
{
    public class FileLocator
    {
        private const string BASH_HISTORY_FILE_NAME = @".bash_history";
        private const string SYSTEM_DRIVE = @"%SystemDrive%";
        private const string BSLASH = @"\";
        public string BashHistoryPath()
        {
            return WindowsUsersDiractory() + BSLASH + UserDirectory() + BSLASH + BASH_HISTORY_FILE_NAME;
        }
        private string WindowsUsersDiractory()
        {
            return Environment.ExpandEnvironmentVariables(SYSTEM_DRIVE) + BSLASH + "Users";
        }

        private string UserDirectory()
        {
            return Environment.UserName;
        }
    }
}

using KeePassLib;
using KeePassLib.Interfaces;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using System.Security;

namespace KeePassServer.Core
{
    public class Database : IDatabase
    {
        private readonly PwDatabase _pwDatabase;
        private bool disposedValue;

        public static IDatabase Open(string databasePath, SecureString password)
        {
            return new Database(databasePath, password);
        }
        public Database(string databasePath, SecureString password, IStatusLogger statusLogger = null)
        {
            _pwDatabase = new PwDatabase();
            var compositeKey = new CompositeKey();
            compositeKey.AddUserKey(new KcpPassword(password.ToByteArray()));
            _pwDatabase.Open(IOConnectionInfo.FromPath(databasePath), compositeKey, statusLogger ?? KeePassStatusLogger.Instance);
            PwGroup pgRestoreSelect = _pwDatabase.RootGroup.FindGroup(_pwDatabase.LastSelectedGroup, true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (_pwDatabase.IsOpen)
                    {
                        _pwDatabase.Close();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Database()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }
    }
}

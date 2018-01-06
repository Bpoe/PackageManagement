namespace PackageManagement
{
    using System.Collections.Generic;

    public class WindowsUpdatePackageManager : IPackageManager
    {
        public IList<Package> GetAvailableUpdates()
        {
            var updates = new List<Package>();

            return updates;
        }
    }
}

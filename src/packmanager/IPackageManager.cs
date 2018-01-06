namespace PackageManagement
{
    using System.Collections.Generic;
    
    public interface IPackageManager
    {
        IList<Package> GetAvailableUpdates();
    }
}

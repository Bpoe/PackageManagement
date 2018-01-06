namespace PackageManagement
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Package
    {
        public string Name;

        public string Architecture;

        public string Version;

        public string Repository;
    }
}

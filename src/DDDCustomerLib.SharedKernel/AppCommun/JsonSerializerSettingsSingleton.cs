using Newtonsoft.Json;

namespace dDDCustomerLib.SharedKernel
{
    public sealed class JsonSerializerSettingsSingleton
    {
        private JsonSerializerSettingsSingleton() { }

        public static JsonSerializerSettings Instance { get; } = new()
        {
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            NullValueHandling = NullValueHandling.Include,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };
    }
}
namespace dDDCustomerLib.SharedKernel
{
    public static class MessagingConstants
    {
        public static class Credentials
        {
            public const string DEFAULT_USERNAME = "guest";
            public const string DEFAULT_PASSWORD = "guest";
        }

        public static class Exchanges
        {
            public const string DDDCUSTOMER_BUSINESSMANAGEMENT_EXCHANGE = "dddcustomer-businessmanagement";

            public const string DDDCUSTOMER_CUSTOMERPUBLICWEBSITE_EXCHANGE =
                "dddcustomer-customerpublicwebsite";
        }

        public static class NetworkConfig
        {
            public const int DEFAULT_PORT = 5672;
            public const string DEFAULT_VIRTUAL_HOST = "/";
        }

        public static class Queues
        {
            public const string FDCM_BUSINESSMANAGEMENT_IN = "fdcm-businessmanagement-in";
            public const string FDCM_DDDCUSTOMER_IN = "fdcm-dddcustomer-in";
            public const string FDVCP_DDDCUSTOMER_IN = "fdvcp-dddcustomer-in";
            public const string FDVCP_CUSTOMERPUBLICWEBSITE_IN = "fdvcp-customerpublicwebsite-in";
        }
    }
}
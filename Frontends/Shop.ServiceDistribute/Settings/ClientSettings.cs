namespace Shop.ServiceDistribute.Settings
{
    public class ClientSettings
    {
        public Client ShopVisitorClient { get; set; }
        public Client ShopManagerClient { get; set; }
        public Client ShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}

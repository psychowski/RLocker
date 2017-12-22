namespace RLockerClient.Model.Interfaces
{
    interface IClientConfigurationManager 
    {
        void SaveConfiguration(ClientConfiguration config);
        ClientConfiguration GetConfiguration();
    }
}

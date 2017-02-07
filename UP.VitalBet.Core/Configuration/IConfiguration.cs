namespace UP.VitalBet.Core.Configuration
{
    public interface IConfiguration
    {

        string ReadProperty(string key);

        bool HasProperty(string key);

    }
}

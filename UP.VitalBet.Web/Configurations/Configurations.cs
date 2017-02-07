using System;
using System.Configuration;
using System.Linq;
using UP.VitalBet.Core.Configuration;

namespace UP.VitalBet.Web.Configurations
{
    
    public class WebConfiguration : IConfiguration
    {

        public WebConfiguration()
        {

        } 

        public virtual bool HasProperty(string key)
        {
            return !String.IsNullOrWhiteSpace(key) && ConfigurationManager.AppSettings.AllKeys.Select((string x) => x).Contains(key);
        } 

        public virtual string ReadProperty(string key)
        {
            string returnValue = String.Empty;
            if (this.HasProperty(key))
            {
                returnValue = ConfigurationManager.AppSettings[key];
            }
            return returnValue;
        } 

    }
}
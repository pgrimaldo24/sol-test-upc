namespace Sol.Pierr.Grimaldo.CrossCutting.Common.AppSetting
{
    public class AppSettings
    {
        public CredentialORC OrclCredentials { get; set; } 
    }

    public class CredentialORC
    {
        public string DataSource { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}

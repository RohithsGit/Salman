namespace firstAPI.model
{
    public class User
    {
        public string USERID { get; set; }         // maps to [varchar](20) NOT NULL
        public string PASSWORD { get; set; }       // maps to [varchar](20) NULL
        public long? MOBILE { get; set; }          // maps to [bigint] NULL
    }
}

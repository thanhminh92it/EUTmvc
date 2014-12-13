
namespace EUTmvc.Models
{
    public class EmailFrom
    {
        public string account = "phamthanhminh9x@gmail.com";
        public string pass = "phamthanhminh92";
        public string displayName = "minhpt";
        public int port = 587;
        public string host = "smtp.gmail.com";
    }

    public class EmailTo
    {
        public string mailto { get; set; }
        public string subject { get; set; }
        public string contents { get; set; }
    }
}
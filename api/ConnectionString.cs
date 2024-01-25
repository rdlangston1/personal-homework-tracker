using Org.BouncyCastle.Asn1.Icao;

namespace api
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString(){
            string server = "t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com	";
            string database = "l5jrtr3mspw5vukf";
            string port = "3306";
            string username = "frzfm3exs53b0o19";
            string password = "rrwzbflezjbdw37b";

            cs = $@"server = {server};username={username};database={database};port={port};password={password}";
        }
    }
}
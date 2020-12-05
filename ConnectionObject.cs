using System;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;

namespace RESTfulFish
{
    public class ConnectionObject : IDisposable
    {
        public static TcpClient tc;
        public static NetworkStream tcS;

        private static EndianBinaryWriter bw;
        private static EndianBinaryReader br;

        /*
         * Some house keeping
         */
        ~ConnectionObject()
        {
            tc.GetStream().Close();
            tc.Close();
        }

        /*
         * Create the server connection
         */
        public ConnectionObject()
        {

        }

        public static void Connect()
        {
            string FishbowlServer = ConfigurationManager.AppSettings.Get("FishbowlServer");
            int FishbowlPort = Int32.Parse(ConfigurationManager.AppSettings.Get("FishbowlPort"));

            try
            {
                tc = new TcpClient(FishbowlServer, FishbowlPort);
                tc.NoDelay = true;
                tc.ReceiveBufferSize = 8192;
                tc.SendBufferSize = 8192;
                tc.ReceiveTimeout = 10000;
                tc.SendTimeout = 1000;
            }
            catch (Exception e)
            {
                Console.WriteLine("ConnectionObject.Connect(): {0}", e);
                Console.ReadLine();
                System.Environment.Exit(1);
            }
            tcS = tc.GetStream();
            bw = new EndianBinaryWriter(new BigEndianBitConverter(), tcS);
            br = new EndianBinaryReader(new BigEndianBitConverter(), tcS);
        }

        /*
         * Send the JSON/XML request string
         */
        public static String sendCommand(string command)
        {
            try
            {
                bw = new EndianBinaryWriter(new BigEndianBitConverter(), tcS);
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] bytes = encoding.GetBytes(command);
                bw.Write(bytes.Length);
                bw.Write(bytes);
                bw.Flush();
                Thread.Sleep(1000);
                br = new EndianBinaryReader(new BigEndianBitConverter(), tcS);
                int i = br.ReadInt32();
                byte[] bytess = new byte[i];
                br.Read(bytess, 0, i);
                String response = encoding.GetString(bytess, 0, i);

                return response;
            }
            catch (Exception e)
            {
                return FishbowlLegacy.GenericXMLError(e.ToString());
            }
        }

        /*
         * Check when Fishbowl server starts
         */
        public static bool IsFishbowlPortOpen()
        {
            string FishbowlServer = ConfigurationManager.AppSettings.Get("FishbowlServer");
            int FishbowlPort = Int32.Parse(ConfigurationManager.AppSettings.Get("FishbowlPort"));
            int timeout = 5;

            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(FishbowlServer, FishbowlPort, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(timeout);
                    client.EndConnect(result);
                    return success;
                }
            }
            catch
            {
                return false;
            }
        }
        public void Dispose()
        {
            tc.GetStream().Close();
            tc.Close();
        }
    }
}

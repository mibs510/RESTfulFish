using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace RESTfulFish
{
    class FishbowlLegacy
    {
        /* Description: This method begins writing the common portion 
         * of any XML request for Fishbowl server.
         * String Request: Name of request (e.g. GetSOListRq)
         */
        public static Tuple<XmlWriter, StringWriter> BeginWriteXml(String Key, String Request)
        {
            StringWriter XmlSw = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            XmlWriter XmlW = XmlWriter.Create(XmlSw, settings);

            XmlW.WriteStartElement("FbiXml");
            XmlW.WriteStartElement("Ticket");
            // For LoginRq, <Ticket />
            if (Key == null)
                XmlW.WriteEndElement();
            if (Key != null)
            {
                // <Key>**KEY**</Key>
                XmlW.WriteElementString("Key", Key);
                // </Ticket>
                XmlW.WriteEndElement();
            }
            XmlW.WriteStartElement("FbiMsgsRq");
            XmlW.WriteStartElement(Request);
            return Tuple.Create(XmlW, XmlSw);
        }

        /* Description: This method closes the common portion of
         * any XML request for Fishbowl server from an XmlWriter 
         * object. It then returns it as a string and properly
         * disposes XmlWriter and StringWriter object.
         */
        public static string EndWriteXml(XmlWriter XmlW, StringWriter XmlSw)
        {
            //</[REQUEST]Rq>
            XmlW.WriteEndElement();
            // </FbiMsgsRq>
            XmlW.WriteEndElement();
            // </FbiXml>
            XmlW.WriteEndElement();
            XmlW.Flush();

            String xml = XmlSw.ToString();
            XmlW.Dispose();
            XmlSw.Dispose();
            return xml;
        }

        /* Description: Returns a generic XML response with an error message.
         */
        public static String GenericXMLError(string message)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            StringBuilder XML = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(XML, settings))
            {
                writer.WriteStartElement("RESTfulFish");
                writer.WriteElementString("status", "error");
                writer.WriteElementString("message", message);
                writer.WriteEndElement();
            }
            return XML.ToString();
        }

        /* Description: Pull the session Key out of the XML response.
         */
        public static String PullKey(String response)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(response)))
                {
                    while (reader.Read())
                    {
                        //if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("Key"))
                        if (reader.Name.Equals("Key") && reader.Read())
                        {
                            // We need to make the key available to everyone globally.
                            Misc.Key = reader.Value.ToString();
                            return Misc.Key;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("FishbowlLegacy.PullKey(): Exception: {0}", e.Message);
                Console.WriteLine("FishbowlLegacy.PullKey(): Received: {0}", response);
            }
            return Misc.Key;
        }

        /* Description: Pull the status code out of the XML response.
         */
        public static String PullStatusCode(String response)
        {
            String statusCode = "";
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(response)))
            {
                try
                {
                    while (reader.ReadToFollowing("FbiMsgsRs"))
                    {
                        reader.MoveToFirstAttribute();
                        return reader.Value.ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("FishbowlLegacy.PullStatusCode(): Exception: {0}", e.Message);
                    Console.WriteLine("FishbowlLegacy.PullStatusCode(): Received: {0}", response);
                }

            }
            return statusCode;
        }

        public static String Xml2Json(String response)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            return JsonConvert.SerializeXmlNode(doc);
        }
    }
}

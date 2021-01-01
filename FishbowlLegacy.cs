using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace RESTfulFish
{
    class FishbowlLegacy
    {
        /* Description: This function begins writing the common portion 
         * of any XML request for Fishbowl server.
         * String Request: Name of request (e.g. GetSOListRq)
         */
        public static Tuple<XmlWriter, StringWriter> BeginWriteXmlRq(String Key, String Request)
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

        /* Description: This function closes the common portion of
         * any XML request for Fishbowl server from an XmlWriter 
         * object. It then returns it as a string and properly
         * disposes XmlWriter and StringWriter object.
         */
        public static string EndWriteXmlRq(XmlWriter XmlW, StringWriter XmlSw)
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

        public static String ExtractFishbowlObject(String Payload, String Object)
        {
            if (IsJson(Payload))
                Payload = Json2Xml(Payload);

            try
            {
                return string.Concat(XElement.Parse(Payload).Elements(Object).Nodes());
            }
            catch (Exception e)
            {
                Misc.ExceptionMessage("ExtractFishbowlObject", e, null, false);
            }

            return null;
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

        /* Description: Determines if a string is valid Json.
         */
        public static bool IsJson(String input)
        {
            try
            {
                JToken.Parse(input);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /* Description: Determines if a string is valid XML.
         */
        public static bool IsXml(String input)
        {
            try
            {
                XElement.Parse(input);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string Json2Xml(String Json)
        {
            try
            {
                XNode node = JsonConvert.DeserializeXNode(Json);
                return node.ToString();
            }
            catch (Exception e)
            {
                Misc.ExceptionMessage("Json2Xml", e, Json, false);
            }
            return null;
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
                Misc.ExceptionMessage("PullKey", e, response, true);
            }
            return Misc.Key;
        }

        /* Description: Pull the status code out of an XML response.
         */
        public static String PullStatusCode(String response)
        {
            String statusCode = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(response)))
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
                    Misc.ExceptionMessage("PullStatusCode", e, response, false);
                }

            }
            return statusCode;
        }

        public static bool ValidPayload(String Payload)
        {
            if (IsJson(Payload))
            {
                Payload = Json2Xml(Payload);
            }

            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(Payload)))
                {
                    while (reader.Read())
                    {
                        if (reader.Name.Equals("FishbowlLegacyObjects"))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionMessage("ValidPayload", e, Payload, false);
            }
            return false;
        }

        /* Desription: This method writes an object that is obtained
         * from a IHttpContext.Request.Payload into a Fishbowl request.
         */
        public static void WriteFishbowlLegacyObj(XmlWriter XmlW, String localName, String Obj)
        {
            XmlW.WriteStartElement(localName);
            // We must use WriteRaw otherwise '<' and '>' are converted to '&lt;' and '&gt;'.
            XmlW.WriteRaw(Obj);
            XmlW.WriteEndElement();
        }

        /* Description: This pretty self explanatory. 
         * This method converts a response from Fishbowl server
         * in XML to Json.
         */
        public static String Xml2Json(String Xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Xml);

                return JsonConvert.SerializeXmlNode(doc);
            }
            catch(Exception e)
            {
                Misc.ExceptionMessage("Xml2Json", e, null, false);
            }

            return null;
        }
    }
}

using System;
using System.Xml;

namespace RESTfulFish
{
    class FishbowlLegacy
    {
        /* Description: Pull the session Key out of the server XML response.
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

        /* Pull the status code out of the server XML response.
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
    }
}

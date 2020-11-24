using Newtonsoft.Json;
using System;
using System.IO;

namespace RESTfulFish
{
    class Fishbowl
    {
        /* Description: Pull the session Key out of the server XML response.
         */
        public static String PullKey(String response)
        {
            try
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(response)))
                {
                    // Traverse the reader object holding the response from Fishbowl
                    while (reader.Read())
                    {
                        // Let's look for a PropertyName token with a value of Key
                        if (reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "Key")
                        {
                            reader.Read();
                            // We need to make the key available to everyone globally.
                            Misc.Key = reader.Value.ToString();
                            return Misc.Key;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fishbowl.PullKey(): Exception: {0}", e.Message);
                Console.WriteLine("Fishbowl.PullKey(): Received: {0}", response);
            }
            return Misc.Key;
        }

        /* Pull the status code out of the server XML response.
         */
        public static String PullStatusCode(String response)
        {
            String statusCode = null;
            try
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(response)))
                {
                    // Traverse the reader object holding the response from Fishbowl
                    while (reader.Read())
                    {
                        // Let's look for a PropertyName token with a value of statusCode
                        if (reader.TokenType == JsonToken.PropertyName && reader.Value.ToString() == "statusCode")
                        {
                            // Get the value of statusCode
                            reader.Read();
                            return reader.Value.ToString();
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Fishbowl.PullStatusCode(): Exception: {0}", e.Message);
                Console.WriteLine("Fishbowl.PullStatusCode(): Received: {0}", response);
            }

            return statusCode;
        }
    }
}

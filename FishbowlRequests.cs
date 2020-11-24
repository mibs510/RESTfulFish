using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace RESTfulFish
{
    class FishbowlRequests
    {
        public FishbowlRequests()
        {

        }

        /* Description: Returns the beginning Json format of any FishbowlRequest.
         * Syntax: 
         * {
                "FbiJson": {
                    "Ticket": {
                        "Key": "xTypHT/pZXZy6Re+H66kSA=="
                    },
                    "FbiMsgsRq": {
         */
        private static JsonWriter StartFishbowlRequestObject(string Key, StringBuilder sb)
        {
            StringWriter sw = new StringWriter(sb);
            JsonWriter writer = new JsonTextWriter(sw)
            {
                Formatting = Formatting.Indented
            };
            writer.WriteStartObject();
            writer.WritePropertyName("FbiJson");
            writer.WriteStartObject();
            writer.WritePropertyName("Ticket");
            writer.WriteStartObject();
            writer.WritePropertyName("Key");
            writer.WriteValue(Key);
            writer.WriteEndObject();
            writer.WritePropertyName("FbiMsgsRq");
            writer.WriteStartObject();

            return writer;
        }

        /* Description: Closes a FishbowlRequest object. 
         * Beaware that this only closes FbiJson, Ticket, and FbiMsgsRq!
         * Syntax: 		}
	                  }
                    }
         */
        private static void EndFishbowlRequestObject(JsonWriter writer)
        {
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        /* Description: Returns results of sql query in csv format. 
         * The ExecuteQueryRq can run a query saved in the Data module,
         * or a custom query included in the request.
         * The Data module may be helpful for testing queries and extracting queries based on reports.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                    "ExecuteQueryRq": {
				                        "Name": "PartList"
			                    }
		                    }
	                    }
                    }
         */
        public static String ExecuteQueryRq(String Key, String Name, String Query)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("ExecuteQueryRq");
            writer.WriteStartObject();

            if (Query != null && Name == null)
            {
                writer.WritePropertyName("Query");
                writer.WriteValue(Query);
            } else if (Query == null && Name != null)
            {
                writer.WritePropertyName("Name");
                writer.WriteValue(Name);
            }
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: This request allows you to run any of the CSV imports. 
         * The type is formatted as "ImportCsvName" with no spaces. 
         * Data columns can be blank, but each data column must be represented in the request. 
         * The example uses the import to edit/add a vendor. 
         * It is best practice to always include the header rows when importing data.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                    "ImportRq": {
				                    "Type": "ImportVendors",
				                    "Rows": {
					                    "Row": [
					                        "\"Name\",\"AddressName\",\"AddressContact\",
                                            \"AddressType\",\"IsDefault\",\"Address\",\"City\",
                                            \"State\",\"Zip\",\"Country\",\"Main\",\"Home\",\"Work\",
                                            \"Mobile\",\"Fax\",\"Email\",\"Pager\",\"Web\",\"Other\",
                                            \"DefaultTerms\",\"DefaultShippingTerms\",\"Status\",
                                            \"AlertNotes\",\"URL\",\"DefaultCarrier\",\"MinOrderAmount\",
                                            \"Active\",\"AccountNumber\",\"CurrencyName\",\"CurrencyRate\",
                                            \"CF-Custom1\",\"CF-Custom2\",\"CF-Custom3\",\"CF-Custom4\"",
					                        "\"Monroe Bike Company\",\"Williams Bike Company - 210\",
                                            \"Williams Bike Company\",\"50\",\"true\",\"Wall st.\",
                                            \"New York\",\"NY\",\"21004\",\"UNITED STATES\",
                                            \"212-321-5643\",,,,,,,,,,,,,"
					                            ]
				                    }
			                    }
		                    }
	                    }
}
         * TODO: Reimplement Row as a string array so that the web app do not have to 
         * recall this request for each row, if there is more than one to be imported.
         */
        public static String ImportRq(String Key, String type, String HeaderRow, String Row)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("ImportRq");
            writer.WriteStartObject();
            writer.WritePropertyName("Type");
            writer.WriteValue(type);
            writer.WritePropertyName("Rows");
            writer.WriteStartObject();
            writer.WritePropertyName("Row");
            writer.WriteStartArray();
            writer.WriteValue(HeaderRow);
            writer.WriteValue(Row);
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: This request allows you to get the headers of an import.
         * The type is formatted as "ImportCsvName" with no spaces.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                    "ImportHeaderRq": {
				                    "Type": "ImportAddInventory"
			                    }
		                    }
	                    }
                    }
         */
        public static String ImportHeaderRq(String Key, String type)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("ImportHeaderRq");
            writer.WriteStartObject();
            writer.WritePropertyName("Type");
            writer.WriteValue(type);
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: Will issue a sales order.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                    "IssueSORq": {
				                    "SONumber": "50054"
			                    }
		                    }
	                    }
                    }
         */
        public static String IssueSORq(String Key, String SONumber)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("IssueSORq");
            writer.WriteStartObject();
            writer.WritePropertyName("SONumber");
            writer.WriteValue(SONumber);
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: Logs a user in to Fishbowl. 
         * The IAID can be any randomly generated integer value as long as 
         * the IAID and the IAName are unique per Fishbowl server. 
         * The algorithm required to encrypt the password is Base64.encode(MD5.hash(password))
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": ""
		                    },
		                    "FbiMsgsRq": {
			                    "LoginRq": {
				                    "IAID": 1234,
				                    "IADescription": "Fishbowl Developer Hook an API test application for Fishbowl Inventory",
				                    "UserName": "admin",
				                    "IAName": "Fishbowl Developer Hook",
				                    "UserPassword": "ISMvKXpXpadDiUoOSoAfww=="
			                    }
		                    }
	                    }
                    }
         */
        public static String LoginRq(String IAID, String IADescription, String UserName, String IAName, String UserPassword)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(UserPassword));
            string encryptedUserPassword = Convert.ToBase64String(encoded, 0, 16);

            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject("", sb);

            writer.WritePropertyName("LoginRq");
            writer.WriteStartObject();
            writer.WritePropertyName("IAID");
            writer.WriteValue(IAID);
            writer.WritePropertyName("IADescription");
            writer.WriteValue(IADescription);
            writer.WritePropertyName("UserName");
            writer.WriteValue(UserName);
            writer.WritePropertyName("IAName");
            writer.WriteValue(IAName);
            writer.WritePropertyName("UserPassword");
            writer.WriteValue(encryptedUserPassword);
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: Logs a user out of Fishbowl.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
                                "LogoutRq": ""
		                    }
                        }
                    }
         */
        public static String LogoutRq(String Key)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("LogoutRq");
            writer.WriteValue("");

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: Will do an automatic pick, pack, and ship on a SO.
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
                                "QuickShipRq": {
				                    "SONumber": "50052"
			                    }
		                    }
	                    }
                    }
         */
        public static String QuickShipRq(String Key, String SONumber)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("QuickShipRq");
            writer.WriteStartObject();
            writer.WritePropertyName("SONumber");
            writer.WriteValue(SONumber);
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }

        /* Description: This request is used to void sales orders
         * Syntax: {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                    "VoidSORq": {
				                    "SONumber": "50052"
			                    }
		                    }
	                    }
                    }
         */
        public static String VoidSORq(String Key, String SONumber)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = StartFishbowlRequestObject(Key, sb);

            writer.WritePropertyName("VoidSORq");
            writer.WriteStartObject();
            writer.WritePropertyName("SONumber");
            writer.WriteValue(SONumber);
            writer.WriteEndObject();

            EndFishbowlRequestObject(writer);

            return sb.ToString();
        }
    }
}

using System;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
// TODO: Should we be using something like SqlKata?

namespace RESTfulFish
{
    class GenerateSQLQuery
    {
        public static String CustomerListRq()
        {
            using (var query = new QueryFactory())
            {
                return query.Query("customer").ToString();
            }
        }

        /* Description: Returns a list of location group(s) and their IDs
         * This is used for LocationGroupID in CustomFishbowl(Legacy)Requests.GetSOListRq
         * Syntax: <ExecuteQueryRq>
                    <Query>SELECT * FROM `locationgroup`</Query>
                   </ExecuteQueryRq>
            {
                "FbiJson": {
                    "Ticket": {
                        "Key": "xTypHT/pZXZy6Re+H66kSA=="
                    },
                    "FbiMsgsRq": {
                         "ExecuteQueryRq": {
                                "Query": "SELECT * FROM `locationgroup`"
                            }
                        }
                    }
            }
         * Example response: <FbiXml><Ticket><UserID>12</UserID><Key>158d1317-d4bf-464c-88c0-844cf2c229c0</Key></Ticket>
         * <FbiMsgsRs statusCode="1000"><ExecuteQueryRs statusCode="1000">
                <Rows>
                    <Row>"id","activeFlag","dateLastModified","name","qbClassId"</Row>
                    <Row>"1","true","2019-04-16 10:18:31.646","Site 1","1"</Row>
                    <Row>"2","true","2017-09-27 10:50:24.648","Site 2","1"</Row>
                    <Row>"3","false","2018-03-30 09:56:26.197","Site 3","1"</Row>
                    <Row>"4","false","2018-03-30 09:56:38.915","Site 4","1"</Row>
                    <Row>"5","false","2018-03-30 09:56:33.672","Site 5","1"</Row>
                    <Row>"6","true","2018-09-18 14:00:02.782","Site 6","1"</Row>
                    <Row>"7","false","2019-04-28 13:24:11.626","HQ","1"</Row>
                    <Row>"8","true","2019-04-16 10:18:38.782","Storage","1"</Row>
                </Rows>
            </ExecuteQueryRs></FbiMsgsRs></FbiXml>
         */
        public static String GetLocationGroupIDRq()
        {
            using (var query = new QueryFactory())
            {
                return query.Query("locationgroup").ToString();
            }
        }

        /* Description: Returns a list of Sales Order types and their IDs.
         * This is used for typeID in CustomFishbowl(Legacy)Requests.GetSOListRq
         * Syntax: <ExecuteQueryRq>
                    <Query>SELECT * FROM `soitemtype`</Query>
                   </ExecuteQueryRq> 
            {
                "FbiJson": {
                    "Ticket": {
                        "Key": "xTypHT/pZXZy6Re+H66kSA=="
                    },
                    "FbiMsgsRq": {
                         "ExecuteQueryRq": {
                                "Query": "SELECT * FROM `soitemtype`"
                            }
                        }
                    }
            }
         * Example response: <FbiXml><Ticket><UserID>12</UserID><Key>4fdb572f-baef-4e9c-beb8-95228873890a</Key></Ticket>
         * <FbiMsgsRs statusCode="1000"><ExecuteQueryRs statusCode="1000">
                <Rows>
                    <Row>"id","name"</Row>
                    <Row>"50","Assoc. Price"</Row>
                    <Row>"20","Credit Return"</Row>
                    <Row>"31","Discount Amount"</Row>
                    <Row>"30","Discount Percentage"</Row>
                    <Row>"12","Drop Ship"</Row>
                    <Row>"80","Kit"</Row>
                    <Row>"21","Misc. Credit"</Row>
                    <Row>"11","Misc. Sale"</Row>
                    <Row>"90","Note"</Row>
                    <Row>"10","Sale"</Row>
                    <Row>"60","Shipping"</Row>
                    <Row>"40","Subtotal"</Row>
                    <Row>"70","Tax"</Row>
                </Rows>
            </ExecuteQueryRs></FbiMsgsRs></FbiXml>
         */

        public static String GetSOItemTypeRq()
        {
            var compiler = new MySqlCompiler();
            var query = new Query("soitemtype");
            SqlResult result = compiler.Compile(query);
            return result.Sql;
        }

        /* Description: This is an equivalent to FishbowlLegacyRequests.GetSOListRq.
         * This function generates a SQL query and uses FishbowlLegacyRequests.ExecuteQueryRq
         * to encapsulated into XML format and sends the request to Fishbowl and returns the response.
         * Syntax:
         * TODO: Add AccountNumber and ProductDetails
         */
        public static String GetSOListRq(String SONum, String LocationGroupID,
        String StatusID, String CustomerPO, String CustomerID,
        String BillToName, String ShipToName, String ProductNum,
        String ProductDesc, String Salesman,
        String typeID, String DateIssuedBegin, String DateIssuedEnd, String DateCreatedBegin,
        String DateCreatedEnd, String DateLasteModifiedBegin,
        String DateLasteModifiedEnd, String DateScheduledBegin,
        String DateScheduledEnd, String DateCompletedBegin, String DateCompletedEnd)
        {
            IDictionary<string, string> whereEquals = new Dictionary<string, string>();
            if (SONum != null)
                whereEquals.Add("num", SONum);
            if (LocationGroupID != null)
                whereEquals.Add("locationGroupId", LocationGroupID);
            if (StatusID != null)
                whereEquals.Add("statusId", StatusID);
            if (CustomerPO != null)
                whereEquals.Add("customerPO", CustomerPO);
            if (CustomerID != null)
                whereEquals.Add("customerId", CustomerID);
            if (BillToName != null)
                whereEquals.Add("billToName", BillToName);
            if (ShipToName != null)
                whereEquals.Add("shipToName", ShipToName);
            if (Salesman != null)
                whereEquals.Add("salesmanId", Salesman);
            if (typeID != null)
                whereEquals.Add("typeId", typeID);
            
            IDictionary<string, string> whereLike = new Dictionary<string, string>();
            if (ProductNum != null)
                whereLike.Add("productNum", ProductNum);
            if (ProductDesc != null)
                whereLike.Add("description", ProductDesc);

            IDictionary<string, string> whereGreaterThanOrEqualTo = new Dictionary<string, string>();
            if (DateIssuedBegin != null)
                whereGreaterThanOrEqualTo.Add("dateIssued", DateIssuedBegin);
            if (DateCreatedBegin != null)
                whereGreaterThanOrEqualTo.Add("dateCreated", DateCreatedBegin);
            if (DateLasteModifiedBegin != null)
                whereGreaterThanOrEqualTo.Add("dateLastModified", DateLasteModifiedBegin);
            if (DateScheduledBegin != null)
                whereGreaterThanOrEqualTo.Add("dateCalStart", DateScheduledBegin);
            if (DateCompletedBegin != null)
                whereGreaterThanOrEqualTo.Add("dateCompleted", DateCompletedBegin);

            IDictionary<string, string> whereLessThanOrEqualTo = new Dictionary<string, string>();
            if (DateIssuedEnd != null)
                whereLessThanOrEqualTo.Add("dateIssued", DateIssuedEnd);
            if (DateCreatedEnd != null)
                whereLessThanOrEqualTo.Add("dateCreated", DateCreatedEnd);
            if (DateLasteModifiedEnd != null)
                whereLessThanOrEqualTo.Add("dateLastModified", DateLasteModifiedEnd);
            if (DateScheduledEnd != null)
                whereLessThanOrEqualTo.Add("dateCalEnd", DateScheduledEnd);
            if (DateCompletedEnd != null)
                whereLessThanOrEqualTo.Add("dateCompleted", DateCompletedEnd);

            var compiler = new MySqlCompiler();
            var query = new Query("so");
            query.Join("soitem", "so.id", "soitem.soId").OrderBy("so.num");

            foreach (var WhereEquals in whereEquals)
            {
                query.Where(WhereEquals.Key, WhereEquals.Value);
            }
            foreach (var WhereLike in whereLike)
            {
                query.WhereLike(WhereLike.Key, WhereLike.Value);
            }
            foreach (var WhereGreaterThanOrEqualTo in whereGreaterThanOrEqualTo)
            {
                query.Where(WhereGreaterThanOrEqualTo.Key, ">=", WhereGreaterThanOrEqualTo.Value);
            }
            foreach (var WhereLessThanOrEqualTo in whereLessThanOrEqualTo)
            {
                query.Where(WhereLessThanOrEqualTo.Key, "<=", WhereLessThanOrEqualTo.Value);
            }

            // Cleanup 
            whereEquals.Clear();
            whereLike.Clear();
            whereGreaterThanOrEqualTo.Clear();
            whereLessThanOrEqualTo.Clear();

            return compiler.Compile(query).ToString().Replace("\n","");
        }

        /* Description: Returns a list of Sales Order status IDs and names group(s). 
         * This is used for StatusID in CustomFishbowl(Legacy)Requests.GetSOListRq
         * Syntax: <ExecuteQueryRq>
	                        <Query>SELECT * FROM `sostatus`</Query>
                   </ExecuteQueryRq>
                    {
	                    "FbiJson": {
		                    "Ticket": {
			                    "Key": "xTypHT/pZXZy6Re+H66kSA=="
		                    },
		                    "FbiMsgsRq": {
			                     "ExecuteQueryRq": {
				                        "Query": "SELECT * FROM `sostatus`"
			                        }
		                        }
	                        }
                    }
         * Example: <FbiXml><Ticket><UserID>12</UserID><Key>c3ba975d-e0d8-44b7-9dff-7d4cb54eee4e</Key></Ticket>
         * <FbiMsgsRs statusCode="1000"><ExecuteQueryRs statusCode="1000">
                        <Rows>
                            <Row>"id","name"</Row>
                            <Row>"85","Cancelled"</Row>
                            <Row>"70","Closed Short"</Row>
                            <Row>"10","Estimate"</Row>
                            <Row>"90","Expired"</Row>
                            <Row>"60","Fulfilled"</Row>
                            <Row>"95","Historical"</Row>
                            <Row>"25","In Progress"</Row>
                            <Row>"20","Issued"</Row>
                            <Row>"80","Voided"</Row>
                        </Rows>
                    </ExecuteQueryRs></FbiMsgsRs></FbiXml>
        */
        public static String GetSOStatusIDRq()
        {
            return "SELECT * FROM `sostatus`";
        }
    }
}

using System;

namespace RESTfulFish
{
    class CustomFishbowlRequests
    {
        public static string CustomerListRq(string Key)
        {
            return FishbowlRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.CustomerListRq());
        }
        public static string GetLocationGroupIDRq(String Key)
        {
            return FishbowlRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetLocationGroupIDRq());
        }

        public static string GetSOItemTypeRq(String Key)
        {
            return FishbowlRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetSOItemTypeRq());
        }

        public static string GetSOListRq(String Key, String SONum, String LocationGroupID,
        String StatusID, String CustomerPO, String CustomerID,
        String BillToName, String ShipToName, String ProductNum,
        String ProductDesc, String Salesman,
        String typeID, String DateIssuedBegin, String DateIssuedEnd, String DateCreatedBegin,
        String DateCreatedEnd, String DateLasteModifiedBegin,
        String DateLasteModifiedEnd, String DateScheduledBegin,
        String DateScheduledEnd, String DateCompletedBegin, String DateCompletedEnd)
        {
            return FishbowlRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetSOListRq(SONum, LocationGroupID,
                StatusID, CustomerPO, CustomerID,
                BillToName, ShipToName, ProductNum,
                ProductDesc, Salesman,
                typeID, DateIssuedBegin, DateIssuedEnd, DateCreatedBegin,
                DateCreatedEnd, DateLasteModifiedBegin,
                DateLasteModifiedEnd, DateScheduledBegin,
                DateScheduledEnd, DateCompletedBegin, DateCompletedEnd));
        }

        public static string GetSOStatusIDRq(String Key)
        {
            return FishbowlRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetSOStatusIDRq());
        }
    }
}

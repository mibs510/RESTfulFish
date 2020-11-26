using System;

namespace RESTfulFish
{
    class CustomFishbowlLegacyRequests
    {
        public static string CustomerListRq(string Key)
        {
            return FishbowlLegacyRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.CustomerListRq());
        }

        public static string GetSOItemTypeRq(String Key)
        {
            return FishbowlLegacyRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetSOItemTypeRq());
        }
        // Reimplemented because the existing request in FishbowlLegacyRequests class doesn't work?
        public static string GetSOListRq(String Key, String SONum, String LocationGroupID,
        String StatusID, String CustomerPO, String CustomerID,
        String BillToName, String ShipToName, String ProductNum,
        String ProductDesc, String Salesman,
        String typeID, String DateIssuedBegin, String DateIssuedEnd, String DateCreatedBegin,
        String DateCreatedEnd, String DateLasteModifiedBegin,
        String DateLasteModifiedEnd, String DateScheduledBegin,
        String DateScheduledEnd, String DateCompletedBegin, String DateCompletedEnd)
        {
            return FishbowlLegacyRequests.ExecuteQueryRq(
                Key, null, GenerateSQLQuery.GetSOListRq(SONum, LocationGroupID,
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
            return FishbowlLegacyRequests.ExecuteQueryRq(Key, null,
                GenerateSQLQuery.GetSOStatusIDRq());
        }
    }
}

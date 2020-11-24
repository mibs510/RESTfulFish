using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using RESTfulFish;
using System;
using System.Configuration;
using System.Threading;

[RestResource]
public class Grapes
{
    // private String NoObjectGiven = "No valid object given!";
    private String NoRequestGiven = "No valid request given!";
    private String FishbowlServerDown = "Fishbowl server is down!";

    // Gitbook.io URLS
    // private String GitbookCustomFishbowlLegacyRequest = "https://mibs510.gitbook.io/restfulfish/rest-api/customfishbowllegacyrequest";
    // private String GitbookCustomFishbowlRequest = "https://mibs510.gitbook.io/restfulfish/rest-api/customfishbowlrequest";
    // private String GitbookFishbowlLegacyObject = "https://mibs510.gitbook.io/restfulfish/rest-api/fishbowllegacyobject";
    // private String GitbookFishbowlLegacyRequest = "https://mibs510.gitbook.io/restfulfish/rest-api/fishbowllegacyrequest";
    // private String GitbookFishbowlRequest = "https://mibs510.gitbook.io/restfulfish/rest-api/fishbowlrequest";
    private String GitbookAPIHelp = "https://mibs510.gitbook.io/restfulfish/rest-api/api-help";
    private String GitbookFishbowlRequestsAppconfig = "https://mibs510.gitbook.io/restfulfish/app.config#fishbowlrequests";
    private String GitbookFishbowlLegacyRequestAppconfig = "https://mibs510.gitbook.io/restfulfish/app.config#fishbowllegacyrequests";

    public static void StartGrapevineServer()
    {
        Console.WriteLine("StartGrapevineServer() started");
        try
        {
            using (var server = new RestServer())
            {
                if (Misc.UseHTTPS)
                    server.UseHttps = true;

                server.Port = ConfigurationManager.AppSettings.Get("HttpPort");
                server.LogToConsole().Start();
                Console.ReadLine();
                server.Stop();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("StartGrapevineServer(): {0}", e);
            Console.ReadLine();
            System.Environment.Exit(1);
        }
    }

    [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/")]
    public IHttpContext FishbowlRequest(IHttpContext context)
    {
        // TODO: Point to an HTML page to display all possible requests
        var response = "";

        // Lets wait until KeepAlive() has received a statusCode.
        while (Misc.HoldAllFishbowlRequests)
        {
            Console.WriteLine("ConnectionObject.sendCommand(): Misc.HoldAllFishbowlRequests = {0}", Misc.HoldAllFishbowlRequests);
            // Should we wait longer to check?
            Thread.Sleep(1);
        }

        // Custom Fishbowl Legacy Requests
        if (context.Request.QueryString["CustomFishbowlLegacyRequest"] != null)
        {
            Console.WriteLine("Grapes() Inside of CustomFishbowlLegacyRequest");
            var request = context.Request.QueryString["CustomFishbowlLegacyRequest"] ?? NoRequestGiven;

            if (!Misc.FishbowlLegacyRequest)
            {
                context.Response.Redirect(GitbookFishbowlLegacyRequestAppconfig);
                goto SendResponse;
            }

            if (request == "CustomerListRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlLegacyRequests.CustomerListRq(Misc.Key));
            }

            if (request == "GetLocationGroupIDRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlLegacyRequests.GetLocationGroupIDRq(Misc.Key));
            }

            if (request == "GetSOItemTypeRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlLegacyRequests.GetSOItemTypeRq(Misc.Key));
            }

            /* Description: This is the SQL equivalent of the already built-in GetSOListRq
             * (as seen from FishbowlLegacyRequests class). 
             * Returns a detailed list of SOs (Sales Orders) based on the search parameters.
             * TODO: Test and verify functionality. Add two missing parameters.
             */
            if (request == "GetSOListRq")
            {
                var SONum = context.Request.QueryString["SONum"];
                var LocationGroupID = context.Request.QueryString["LocationGroup"];
                var StatusID = context.Request.QueryString["Status"];
                var CustomerPO = context.Request.QueryString["CustomerPO"];
                var CustomerID = context.Request.QueryString["CustomerName"];
                var BillToName = context.Request.QueryString["BillTo"];
                var ShipToName = context.Request.QueryString["ShipTo"];
                var ProductNum = context.Request.QueryString["ProductNum"];
                var ProductDesc = context.Request.QueryString["ProductDesc"];
                var Salesman = context.Request.QueryString["Salesman"];
                var typeID = context.Request.QueryString["type"];
                var DateIssuedBegin = context.Request.QueryString["DateIssuedBegin"];
                var DateIssuedEnd = context.Request.QueryString["DateIssuedEnd"];
                var DateCreatedBegin = context.Request.QueryString["DateCreatedBegin"];
                var DateCreatedEnd = context.Request.QueryString["DateCreatedEnd"];
                var DateLasteModifiedBegin = context.Request.QueryString["DateLasteModifiedBegin"];
                var DateLasteModifiedEnd = context.Request.QueryString["DateLasteModifiedEnd"];
                var DateScheduledBegin = context.Request.QueryString["DateScheduledBegin"];
                var DateScheduledEnd = context.Request.QueryString["DateScheduledEnd"];
                var DateCompletedBegin = context.Request.QueryString["DateCompletedBegin"];
                var DateCompletedEnd = context.Request.QueryString["DateCompletedEnd"];
                response = ConnectionObject.sendCommand(CustomFishbowlLegacyRequests.GetSOListRq(
                    Misc.Key, SONum, LocationGroupID, StatusID, CustomerPO, CustomerID, BillToName,
                    ShipToName, ProductNum, ProductDesc, Salesman, typeID, 
                    DateIssuedBegin, DateIssuedEnd, DateCreatedBegin,
                    DateCreatedEnd, DateLasteModifiedBegin, DateLasteModifiedEnd,
                    DateScheduledBegin, DateScheduledEnd, DateCompletedBegin,
                    DateCompletedEnd));
            }

            if (request == "GetSOStatusIDRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlLegacyRequests.GetSOStatusIDRq(Misc.Key));
            }
        }

        // Fishbowl Legacy Requests
        if (context.Request.QueryString["FishbowlLegacyRequest"] != null)
        {
            Console.WriteLine("Grapes() Inside of FishbowlLegacyRequest");
            var request = context.Request.QueryString["FishbowlLegacyRequest"] ?? NoRequestGiven;

            if (!Misc.FishbowlLegacyRequest)
            {
                context.Response.Redirect(GitbookFishbowlLegacyRequestAppconfig);
                goto SendResponse;
            }

            if (request == "AddInventoryRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var Quantity = context.Request.QueryString["Quantity"];
                var UOMID = context.Request.QueryString["UOMID"];
                var Cost = context.Request.QueryString["Cost"];
                var Note = context.Request.QueryString["Note"];
                var TrackingObj = context.Request.QueryString["TrackingObj"];
                var LocationTagNum = context.Request.QueryString["LocationTagNum"];
                var TagNum = context.Request.QueryString["TagNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.AddInventoryRq(Misc.Key,
                    PartNum, Quantity, UOMID, Cost, Note, TrackingObj, LocationTagNum, TagNum));
            }

            if (request == "AddMemoRq")
            {
                var ItemType = context.Request.QueryString["ItemType"];
                var PartNum = context.Request.QueryString["PartNum"];
                var ProductNum = context.Request.QueryString["ProductNum"];
                var OrderNum = context.Request.QueryString["OrderNum"];
                var CustomerNum = context.Request.QueryString["CustomerNum"];
                var VendorNum = context.Request.QueryString["VendorNum"];
                var MemoObj = context.Request.QueryString["MemoObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.AddMemoRq(Misc.Key,
                    ItemType, PartNum, ProductNum, OrderNum, CustomerNum, VendorNum, MemoObj));
            }

            if (request == "AddSOItemRq")
            {
                var OrderNum = context.Request.QueryString["OrderNum"];
                var SalesOrderItemObj = context.Request.QueryString["SalesOrderItemObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.AddSOItemRq(Misc.Key,
                    OrderNum, SalesOrderItemObj));
            }

            if (request == "AddWorkOrderItemRq")
            {
                var OrderNum = context.Request.QueryString["OrderNum"];
                var TypeId = context.Request.QueryString["TypeId"];
                var Description = context.Request.QueryString["Description"];
                var PartNum = context.Request.QueryString["PartNum"];
                var Quantity = context.Request.QueryString["Quantity"];
                var UOMCode = context.Request.QueryString["UOMCode"];
                var Cost = context.Request.QueryString["Cost"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.AddWorkOrderItemRq(Misc.Key,
                    OrderNum, TypeId, Description, PartNum, Quantity, UOMCode, Cost));
            }

            if (request == "BuildBomRq")
            {
                var BomNumber = context.Request.QueryString["BomNumber"];
                var Quantity = context.Request.QueryString["Quantity"];
                var DateScheduled = context.Request.QueryString["DateScheduled"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.BuildBomRq(Misc.Key,
                    BomNumber, Quantity, DateScheduled));
            }

            if (request == "CalculateSORq")
            {
                var SalesOrderObj = context.Request.QueryString["SalesOrderObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CalculateSORq(Misc.Key,
                    SalesOrderObj));
            }

            if (request == "CarrierListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CarrierListRq(Misc.Key));
            }

            if (request == "CloseShortSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CloseShortSORq(Misc.Key,
                    SONumber));
            }

            // Works
            if (request == "CustomerGetRq")
            {
                var Name = context.Request.QueryString["Name"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CustomerGetRq(Misc.Key,
                    Name));
            }

            // Works
            if (request == "CustomerListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CustomerListRq(Misc.Key));
            }

            // Works
            if (request == "CustomerNameListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CustomerNameListRq(Misc.Key));
            }

            if (request == "CycleCountRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var Quantity = context.Request.QueryString["Quantity"];
                var LocationID = context.Request.QueryString["LocationID"];
                var Tracking = context.Request.QueryString["Tracking"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.CycleCountRq(Misc.Key,
                    PartNum, Quantity, LocationID, Tracking));
            }

            if (request == "EmailReportRq")
            {
                var ReportName = context.Request.QueryString["ReportName"];
                var ReportTree = context.Request.QueryString["ReportTree"];
                var Email = context.Request.QueryString["Email"];
                var Name = context.Request.QueryString["Name"];
                var Value = context.Request.QueryString["Value"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.EmailReportRq(Misc.Key,
                    ReportName, ReportTree, Email, Name, Value));
            }

            if (request == "ExportListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ExportListRq(Misc.Key));
            }

            // Works
            if (request == "ExportRq")
            {
                var Type = context.Request.QueryString["Type"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ExportRq(Misc.Key,
                    Type));
            }

            // Works. Must input Name OR Query, not both.
            if (request == "ExecuteQueryRq")
            {
                var Name = context.Request.QueryString["Name"];
                var Query = context.Request.QueryString["Query"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ExecuteQueryRq(Misc.Key,
                    Name, Query));
            }

            if (request == "GetAccountListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetAccountListRq(Misc.Key));
            }

            //TODO: Send only non-null XML tags
            if (request == "GetPartListRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var PartDesc = context.Request.QueryString["PartDesc"];
                var PartDetails = context.Request.QueryString["PartDetails"];
                var PartUPC = context.Request.QueryString["PartUPC"];
                var PartType = context.Request.QueryString["PartType"];
                var ABCCode = context.Request.QueryString["ABCCode"];
                var VendorName = context.Request.QueryString["VendorName"];
                var VendorNum = context.Request.QueryString["VendorNum"];
                var ProductNum = context.Request.QueryString["ProductNum"];
                var ProductDesc = context.Request.QueryString["ProductDesc"];
                var ActiveFlag = context.Request.QueryString["ActiveFlag"];
                var ShowActive = context.Request.QueryString["ShowActive"];
                var ShowInactive = context.Request.QueryString["ShowInactive"];
                var HasBOM = context.Request.QueryString["HasBOM"];
                var Configurable = context.Request.QueryString["Configurable"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetPartListRq(Misc.Key,
                    PartNum, PartDesc, PartDetails, PartUPC, PartType, ABCCode, VendorName, VendorNum,
                    ProductNum, ProductDesc, ActiveFlag, ShowActive, ShowInactive, HasBOM, Configurable));
            }

            if (request == "GetPickRq")
            {
                var PickNum = context.Request.QueryString["PickNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetPickRq(Misc.Key, PickNum));
            }
            // Works (returns statusCode of 1000) but does not return actual POs!
            if (request == "GetPOListRq")
            {
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetPOListRq(Misc.Key, LocationGroup));
            }

            if (request == "GetReceiptRq")
            {
                var OrderNumber = context.Request.QueryString["OrderNumber"];
                var OrderType = context.Request.QueryString["OrderType"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetReceiptRq(Misc.Key,
                    OrderNumber, OrderType, LocationGroup));
            }

            if (request == "GetShipListRq")
            {
                var StartRecord = context.Request.QueryString["StartRecord"];
                var RecordCount = context.Request.QueryString["RecordCount"];
                var OrderTypeID = context.Request.QueryString["OrderTypeID"];
                var StatusID = context.Request.QueryString["StatusID"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                var Carrier = context.Request.QueryString["Carrier"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetShipListRq(Misc.Key,
                    StartRecord, RecordCount, OrderTypeID, StatusID, LocationGroup, Carrier));
            }

            if (request == "GetShipmentRq")
            {
                var ShipmentNum = context.Request.QueryString["ShipmentNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetShipmentRq(Misc.Key, ShipmentNum));
            }

            if (request == "GetShipNowListRq")
            {
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                var Name = context.Request.QueryString["Name"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetShipNowListRq(Misc.Key, LocationGroup, Name));
            }

            /* Does not work inside [RestResource], throws
             * System.IO.IOException: Unable to read data from the transport connection: 
             * A connection attempt failed because the connected party did not properly 
             * respond after a period of time, or established connection failed because 
             * connected host has failed to respond.
             * Works outside of [RestResource] (e.g. inside Main()) but seems to awlays return a
             * statusCode of 1012 "Unknown error: null"
             * TODO: Implement something similar with FishbowlLegacyRequests.ExecuteQueryRq()
             * or FishbowlRequests.ExecuteQueryRq()
             */
            if (request == "GetSOListRq")
            {
                var SONum = context.Request.QueryString["SONum"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                var Status = context.Request.QueryString["Status"];
                var CustomerPO = context.Request.QueryString["CustomerPO"];
                var CustomerName = context.Request.QueryString["CustomerName"];
                var AccountNumber = context.Request.QueryString["AccountNumber"];
                var BillTo = context.Request.QueryString["BillTo"];
                var ShipTo = context.Request.QueryString["ShipTo"];
                var ProductNum = context.Request.QueryString["ProductNum"];
                var ProductDesc = context.Request.QueryString["ProductDesc"];
                var ProductDetails = context.Request.QueryString["ProductDetails"];
                var Salesman = context.Request.QueryString["Salesman"];
                var type = context.Request.QueryString["type"];
                var DateIssuedBegin = context.Request.QueryString["DateIssuedBegin"];
                var DateIssuedEnd = context.Request.QueryString["DateIssuedEnd"];
                var DateCreatedBegin = context.Request.QueryString["DateCreatedBegin"];
                var DateCreatedEnd = context.Request.QueryString["DateCreatedEnd"];
                var DateLasteModifiedBegin = context.Request.QueryString["DateLasteModifiedBegin"];
                var DateLasteModifiedEnd = context.Request.QueryString["DateLasteModifiedEnd"];
                var DateScheduledBegin = context.Request.QueryString["DateScheduledBegin"];
                var DateScheduledEnd = context.Request.QueryString["DateScheduledEnd"];
                var DateCompletedBegin = context.Request.QueryString["DateCompletedBegin"];
                var DateCompletedEnd = context.Request.QueryString["DateCompletedEnd"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetSOListRq(Misc.Key,
                    SONum, LocationGroup, Status, CustomerPO, CustomerName, AccountNumber, BillTo,
                    ShipTo, ProductNum, ProductDesc, ProductDetails, Salesman, type, DateIssuedBegin,
                    DateIssuedEnd, DateCreatedBegin, DateCreatedEnd, DateLasteModifiedBegin,
                    DateLasteModifiedEnd, DateScheduledBegin, DateScheduledEnd, DateCompletedBegin,
                    DateCompletedEnd)); ;
            }

            // Works. Requires both PartNumber and LocationGroup
            // PartNumber: part number as entered in Fishbowl
            // LocationGroup: Demo, RMA, Site 1, Site 2, All
            if (request == "GetTotalInventoryRq")
            {
                var PartNumber = context.Request.QueryString["PartNumber"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetTotalInventoryRq(Misc.Key,
                    PartNumber, LocationGroup));
            }

            if (request == "ImportListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportListRq(Misc.Key));
            }

            if (request == "ImportRq")
            {
                var type = context.Request.QueryString["type"];
                var HeaderRow = context.Request.QueryString["HeaderRow"];
                var Row = context.Request.QueryString["Row"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportRq(Misc.Key,
                    type, HeaderRow, Row));
            }

            if (request == "ImportHeaderRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportHeaderRq(Misc.Key));
            }

            // Works. Requires PartNum.
            if (request == "InvQtyRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var LastModifiedFrom = context.Request.QueryString["LastModifiedFrom"];
                var LastModifiedTo = context.Request.QueryString["LastModifiedTo"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.InvQtyRq(Misc.Key,
                    PartNum, LastModifiedFrom, LastModifiedTo));
            }

            if (request == "IssueSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.IssueSORq(Misc.Key, SONumber));
            }

            // Works
            if (request == "LightPartListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.LightPartListRq(Misc.Key));
            }

            // Works. Requires Number to return meaningful data.
            if (request == "LoadSORq")
            {
                var Number = context.Request.QueryString["Number"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.LoadSORq(Misc.Key, Number));
            }
            // Works
            if (request == "LocationListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.LocationListRq(Misc.Key));
            }

            if (request == "LocationQueryRq")
            {
                var LocationID = context.Request.QueryString["LocationID"];
                var TagNum = context.Request.QueryString["TagNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.LocationQueryRq(Misc.Key,
                    LocationID, TagNum));
            }

            // Skipping LoginRq

            if (request == "MakePaymentRq")
            {
                var PaymentObj = context.Request.QueryString["PaymentObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.MakePaymentRq(Misc.Key, PaymentObj));
            }

            if (request == "MoveRq")
            {
                var SourceLocationObj = context.Request.QueryString["SourceLocationObj"];
                var PartObj = context.Request.QueryString["PartObj"];
                var Quantity = context.Request.QueryString["Quantity"];
                var Note = context.Request.QueryString["Note"];
                var TrackingObj = context.Request.QueryString["TrackingObj"];
                var DestinationLocationObj = context.Request.QueryString["DestinationLocationObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.MoveRq(Misc.Key,
                    SourceLocationObj, PartObj, Quantity, Note, TrackingObj, DestinationLocationObj));
            }

            if (request == "PartCostRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.PartCostRq(Misc.Key, PartNum));
            }

            if (request == "PartGetRq")
            {
                var Number = context.Request.QueryString["Number"];
                var GetImage = context.Request.QueryString["GetImage"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.PartGetRq(Misc.Key,
                    Number, GetImage));
            }

            if (request == "PartQueryRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.PartQueryRq(Misc.Key,
                    PartNum, LocationGroup));
            }

            if (request == "PickQueryRq")
            {
                var StartIndex = context.Request.QueryString["StartIndex"];
                var RecordCount = context.Request.QueryString["RecordCount"];
                var PickNum = context.Request.QueryString["PickNum"];
                var OrderNum = context.Request.QueryString["OrderNum"];
                var PickType = context.Request.QueryString["PickType"];
                var Status = context.Request.QueryString["Status"];
                var Priority = context.Request.QueryString["Priority"];
                var StartDate = context.Request.QueryString["StartDate"];
                var EndDate = context.Request.QueryString["EndDate"];
                var Fulfillable = context.Request.QueryString["Fulfillable"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.PickQueryRq(Misc.Key,
                    StartIndex, RecordCount, PickNum, OrderNum, PickType, Status, Priority,
                    StartDate, EndDate, Fulfillable, LocationGroup));
            }

            if (request == "PrintReportRq")
            {
                var ModuleName = context.Request.QueryString["ModuleName"];
                var Name = context.Request.QueryString["Name"];
                var Value = context.Request.QueryString["Value"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.PrintReportRq(Misc.Key,
                    ModuleName, Name, Value));
            }

            if (request == "ProductGetRq")
            {
                var Number = context.Request.QueryString["Number"];
                var GetImage = context.Request.QueryString["GetImage"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ProductGetRq(Misc.Key,
                    Number, GetImage));
            }

            if (request == "ProductPriceRq")
            {
                var ProductNumber = context.Request.QueryString["ProductNumber"];
                var CustomerName = context.Request.QueryString["CustomerName"];
                var Quantity = context.Request.QueryString["Quantity"];
                var Date = context.Request.QueryString["Date"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ProductPriceRq(Misc.Key,
                    ProductNumber, CustomerName, Quantity, Date));
            }

            if (request == "QuickShipRq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                var FulfillServiceItems = context.Request.QueryString["FulfillServiceItems"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                var ErrorIfNotFulfilled = context.Request.QueryString["ErrorIfNotFulfilled"];
                var ShipDate = context.Request.QueryString["ShipDate"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.QuickShipRq(Misc.Key,
                    SONumber, FulfillServiceItems, LocationGroup, ErrorIfNotFulfilled, ShipDate));
            }

            if (request == "ReceivingListRq")
            {
                var OrderNumber = context.Request.QueryString["OrderNumber"];
                var OrderType = context.Request.QueryString["OrderType"];
                var ReceiptStatus = context.Request.QueryString["ReceiptStatus"];
                var StartRecord = context.Request.QueryString["StartRecord"];
                var RecordCount = context.Request.QueryString["RecordCount"];
                var DateIssuedBegin = context.Request.QueryString["DateIssuedBegin"];
                var DateIssuedEnd = context.Request.QueryString["DateIssuedEnd"];
                var DateFulfilledBegin = context.Request.QueryString["DateFulfilledBegin"];
                var DateFulfilledEnd = context.Request.QueryString["DateFulfilledEnd"];
                var DateReceivedBegin = context.Request.QueryString["DateReceivedBegin"];
                var DateReceivedEnd = context.Request.QueryString["DateReceivedEnd"];
                var DateReconciledBegin = context.Request.QueryString["DateReconciledBegin"];
                var DateReconciledEnd = context.Request.QueryString["DateReconciledEnd"];
                var PartNum = context.Request.QueryString["PartNum"];
                var PartDesc = context.Request.QueryString["PartDesc"];
                var LocationGroupID = context.Request.QueryString["LocationGroupID"];
                var RMANum = context.Request.QueryString["RMANum"];
                var VendorName = context.Request.QueryString["VendorName"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ReceivingListRq(Misc.Key,
                    OrderNumber, OrderType, ReceiptStatus, StartRecord, RecordCount, DateIssuedBegin,
                    DateIssuedEnd, DateFulfilledBegin, DateFulfilledEnd, DateReceivedBegin, DateReceivedEnd,
                    DateReconciledBegin, DateReconciledEnd, PartNum, PartDesc, LocationGroupID, RMANum,
                    VendorName));
            }

            if (request == "SaveDiscountRq")
            {
                var DiscountObj = context.Request.QueryString["DiscountObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveDiscountRq(Misc.Key, DiscountObj));
            }

            if (request == "SaveImageRq")
            {
                var type = context.Request.QueryString["type"];
                var Number = context.Request.QueryString["Number"];
                var Image = context.Request.QueryString["Image"];
                var UpdateAssociations = context.Request.QueryString["UpdateAssociations"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveImageRq(Misc.Key,
                    type, Number, Image, UpdateAssociations));
            }

            if (request == "SavePickRq")
            {
                var PickObj = context.Request.QueryString["PickObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SavePickRq(Misc.Key, PickObj));
            }

            if (request == "SaveReceiptRq")
            {
                var ReceiptObj = context.Request.QueryString["ReceiptObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveReceiptRq(Misc.Key, ReceiptObj));
            }

            if (request == "SaveReportRq")
            {
                var ReportTree = context.Request.QueryString["ReportTree"];
                var ReportObj = context.Request.QueryString["ReportObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveReportRq(Misc.Key,
                    ReportTree, ReportObj));
            }

            if (request == "SaveShipmentRq")
            {
                var ShippingObj = context.Request.QueryString["ShippingObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveShipmentRq(Misc.Key, ShippingObj));
            }

            if (request == "SaveUPCRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var UPC = context.Request.QueryString["UPC"];
                var UpdateProducts = context.Request.QueryString["UpdateProducts"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveUPCRq(Misc.Key,
                    PartNum, UPC, UpdateProducts));
            }

            if (request == "SetDefPartLocRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var LocationObj = context.Request.QueryString["LocationObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SetDefPartLocRq(Misc.Key,
                    PartNum, LocationObj));
            }

            if (request == "SaveTaxRateRq")
            {
                var TaxRateObj = context.Request.QueryString["TaxRateObj"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveTaxRateRq(Misc.Key, TaxRateObj));
            }

            if (request == "ShipRq")
            {
                var ShipNum = context.Request.QueryString["ShipNum"];
                var ShipDate = context.Request.QueryString["ShipDate"];
                var FulfillService = context.Request.QueryString["FulfillService"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ShipRq(Misc.Key,
                    ShipNum, ShipDate, FulfillService));
            }
            // Works
            if (request == "UOMRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.UOMRq(Misc.Key));
            }
            // Works. Requires Name.
            if (request == "VendorGetRq")
            {
                var Name = context.Request.QueryString["Name"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VendorGetRq(Misc.Key, Name));
            }

            // Works
            if (request == "VendorListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VendorListRq(Misc.Key));
            }

            // Works
            if (request == "VendorNameListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VendorNameListRq(Misc.Key));
            }

            if (request == "VoidShipmentRq")
            {
                var ShipNum = context.Request.QueryString["ShipNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VoidShipmentRq(Misc.Key, ShipNum));
            }

            if (request == "VoidSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VoidSORq(Misc.Key, SONumber));
            }
        }

        // Custom Fishbowl Requests
        if (context.Request.QueryString["CustomFishbowlRequest"] != null)
        {
            Console.WriteLine("Grapes() Inside of CustomFishbowlRequest");
            var request = context.Request.QueryString["CustomFishbowlRequest"] ?? NoRequestGiven;

            if (!Misc.FishbowlRequest)
            {
                context.Response.Redirect(GitbookFishbowlRequestsAppconfig);
                goto SendResponse;
            }

            if (request == "CustomerListRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlRequests.CustomerListRq(Misc.Key));
            }

            if (request == "GetLocationGroupIDRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlRequests.GetLocationGroupIDRq(Misc.Key));
            }

            if (request == "GetSOItemTypeRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlRequests.GetSOItemTypeRq(Misc.Key));
            }

            if (request == "GetSOListRq")
            {
                var SONum = context.Request.QueryString["SONum"];
                var LocationGroupID = context.Request.QueryString["LocationGroupID"];
                var StatusID = context.Request.QueryString["StatusID"];
                var CustomerPO = context.Request.QueryString["CustomerPO"];
                var CustomerID = context.Request.QueryString["CustomerID"];
                var BillToName = context.Request.QueryString["BillToName"];
                var ShipToName = context.Request.QueryString["ShipToName"];
                var ProductNum = context.Request.QueryString["ProductNum"];
                var ProductDesc = context.Request.QueryString["ProductDesc"];
                var Salesman = context.Request.QueryString["Salesman"];
                var typeID = context.Request.QueryString["typeID"];
                var DateIssuedBegin = context.Request.QueryString["DateIssuedBegin"];
                var DateIssuedEnd = context.Request.QueryString["DateIssuedEnd"];
                var DateCreatedBegin = context.Request.QueryString["DateCreatedBegin"];
                var DateCreatedEnd = context.Request.QueryString["DateCreatedEnd"];
                var DateLasteModifiedBegin = context.Request.QueryString["DateLasteModifiedBegin"];
                var DateLasteModifiedEnd = context.Request.QueryString["DateLasteModifiedEnd"];
                var DateScheduledBegin = context.Request.QueryString["DateScheduledBegin"];
                var DateScheduledEnd = context.Request.QueryString["DateScheduledEnd"];
                var DateCompletedBegin = context.Request.QueryString["DateCompletedBegin"];
                var DateCompletedEnd = context.Request.QueryString["DateCompletedEnd"];
                response = CustomFishbowlRequests.GetSOListRq(
                    Misc.Key, SONum, LocationGroupID, StatusID, CustomerPO, CustomerID, BillToName,
                    ShipToName, ProductNum, ProductDesc, Salesman, typeID,
                    DateIssuedBegin, DateIssuedEnd, DateCreatedBegin,
                    DateCreatedEnd, DateLasteModifiedBegin, DateLasteModifiedEnd,
                    DateScheduledBegin, DateScheduledEnd, DateCompletedBegin,
                    DateCompletedEnd);
            }

            if (request == "GetSOStatusIDRq")
            {
                response = ConnectionObject.sendCommand(CustomFishbowlRequests.GetSOStatusIDRq(Misc.Key));
            }
        }

        // Fishbowl Requests
        if (context.Request.QueryString["FishbowlRequest"] != null)
        {
            Console.WriteLine("Grapes() Inside of FishbowlRequest");
            var request = context.Request.QueryString["FishbowlRequest"] ?? NoRequestGiven;

            if (!Misc.FishbowlRequest)
            {
                context.Response.Redirect(GitbookFishbowlRequestsAppconfig);
                goto SendResponse;
            }

            if (request == "ExecuteQueryRq")
            {
                var Name = context.Request.QueryString["Name"] ?? null;
                var Query = context.Request.QueryString["Query"] ?? null;
                response = ConnectionObject.sendCommand(FishbowlRequests.ExecuteQueryRq(Misc.Key, Name, Query));
            }

            if (request == "ImportRq")
            {
                var type = context.Request.QueryString["type"];
                var HeaderRow = context.Request.QueryString["HeaderRow"];
                var Row = context.Request.QueryString["Row"];
                response = ConnectionObject.sendCommand(FishbowlRequests.ImportRq(Misc.Key, type, HeaderRow, Row));
            }

            if (request == "ImportHeaderRq")
            {
                var type = context.Request.QueryString["type"];
                response = ConnectionObject.sendCommand(FishbowlRequests.ImportHeaderRq(Misc.Key, type));
            }

            if (request == "IssueSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlRequests.IssueSORq(Misc.Key, SONumber));
            }

            // Skipping LoginRq

            // Skipping LogoutRq

            /* TODO: Add the following parameters: FulfillServiceItems, ErrorIfNotFulfilled, ShipDate
             * Refer to https://www.fishbowlinventory.com/wiki/Fishbowl_API
             */

            if (request == "QuickShipRq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlRequests.QuickShipRq(Misc.Key, SONumber));
            }

            if (request == "VoidSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];
                response = ConnectionObject.sendCommand(FishbowlRequests.VoidSORq(Misc.Key, SONumber));
            }
        }

        if (response == "")
        {
            context.Response.Redirect(GitbookAPIHelp);
            goto SendResponse;
        }

        if (Misc.FishbowlServerDown)
            response += FishbowlServerDown;

        SendResponse:
        context.Response.SendResponse(response);
        return context;
    }
}
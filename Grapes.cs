using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using RESTfulFish;
using System;
using System.Configuration;

[RestResource]
public class Grapes
{
    /* Description: Start grapevine HTTP(S) server
     * 
     */
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
                while (true)
                {

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("StartGrapevineServer(): {0}", e);
            Console.ReadLine();
            System.Environment.Exit(1);
        }
    }

    [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = @"^/\w+/$")]
    public IHttpContext FishbowlRequest(IHttpContext context)
    {
        var response = "";
        bool RespondInJson = false;

        if (Misc.FishbowlServerDown)
        {
            response = FishbowlLegacy.GenericXMLError("Fishbowl server host is down!");
            context.Response.StatusCode = HttpStatusCode.BadGateway;
            goto sendResponse;
        }

        if (context.Request.PathInfo != "/xml/")
        {
            if (context.Request.PathInfo == "/json/")
            {
                RespondInJson = true;
            }
            else if (context.Request.PathInfo != "/json/")
            {
                response = FishbowlLegacy.GenericXMLError("Invalid path! Must be \"xml\" or \"json\".");
                context.Response.StatusCode = HttpStatusCode.BadRequest;
                goto sendResponse;
            }
        }

        Console.WriteLine("context.Request.Payload:\n{0}", context.Request.Payload);
        Console.WriteLine("context.Request.Payload.Length: {0}", context.Request.Payload.Length);

        if (context.Request.Payload.Length != 0)
        {
            if (RespondInJson && !FishbowlLegacy.IsJson(context.Request.Payload))
            {
                response = FishbowlLegacy.GenericXMLError("Invalid body format! Object(s) must be in Json.");
                context.Response.StatusCode = HttpStatusCode.BadRequest;
                goto sendResponse;
            }
            else if (!RespondInJson && !FishbowlLegacy.IsXml(context.Request.Payload))
            {
                response = FishbowlLegacy.GenericXMLError("Invalid body format! Object(s) must be in XML.");
                context.Response.StatusCode = HttpStatusCode.BadRequest;
                goto sendResponse;
            }

            if (!FishbowlLegacy.ValidPayload(context.Request.Payload))
            {
                response = FishbowlLegacy.GenericXMLError("Invalid body format! Object(s) must be within <FishbowlLegacyObjects></FishbowlLegacyObjects> or {\"FishbowlLegacyObjects\":{}}.");
                context.Response.StatusCode = HttpStatusCode.BadRequest;
                goto sendResponse;
            }
        }

        response = FishbowlLegacy.GenericXMLError("Not a valid key!");

        // Lets wait until KeepAlive() has received a statusCode.
        while (Misc.HoldAllFishbowlRequests)
        {
            Console.WriteLine("ConnectionObject.sendCommand(): Misc.HoldAllFishbowlRequests = {0}", Misc.HoldAllFishbowlRequests);
        }

        // Fishbowl Legacy Requests
        if (context.Request.QueryString["FishbowlLegacyRequest"] != null)
        {
            var request = context.Request.QueryString["FishbowlLegacyRequest"] ?? FishbowlLegacy.GenericXMLError("Key FishbowlLegacyRequest does not have a valid value!");

            if (request == "AddInventoryRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var Quantity = context.Request.QueryString["Quantity"];
                var UOMID = context.Request.QueryString["UOMID"];
                var Cost = context.Request.QueryString["Cost"];
                var Note = context.Request.QueryString["Note"];
                var TrackingObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Tracking");
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
                var MemoObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Memo");
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.AddMemoRq(Misc.Key,
                    ItemType, PartNum, ProductNum, OrderNum, CustomerNum, VendorNum, MemoObj));
            }

            if (request == "AddSOItemRq")
            {
                var OrderNum = context.Request.QueryString["OrderNum"];
                var SalesOrderItemObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "SalesOrderItem");
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
                var SalesOrderObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "SalesOrder");
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

                if (Name == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"Name\".");
                    goto sendResponse;
                }

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

                if (PartNum == null || Quantity == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"PartNum\", \"Quantity\", or \"LocationID\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

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

                if (Name != null && Query != null)
                {
                    response = FishbowlLegacy.GenericXMLError("\"Name\" and \"Query\" element passed.");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                if (Name == null && Query == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"Name\" or \"Query\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ExecuteQueryRq(Misc.Key,
                    Name, Query));
            }

            if (request == "GetAccountListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetAccountListRq(Misc.Key));
            }

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
                var ShipmentID = context.Request.QueryString["ShipmentID"];
                var ShipmentNum = context.Request.QueryString["ShipmentNum"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetShipmentRq(Misc.Key, ShipmentID, ShipmentNum));
            }

            if (request == "GetShipNowListRq")
            {
                var LocationGroup = context.Request.QueryString["LocationGroup"];
                var Name = context.Request.QueryString["Name"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetShipNowListRq(Misc.Key, LocationGroup, Name));
            }

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
                var Type = context.Request.QueryString["Type"];
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
                    ShipTo, ProductNum, ProductDesc, ProductDetails, Salesman, Type, DateIssuedBegin,
                    DateIssuedEnd, DateCreatedBegin, DateCreatedEnd, DateLasteModifiedBegin,
                    DateLasteModifiedEnd, DateScheduledBegin, DateScheduledEnd, DateCompletedBegin,
                    DateCompletedEnd));
            }

            /* Works. Requires both PartNumber and LocationGroup
             * PartNumber: part number as entered in Fishbowl
             * LocationGroup: Demo, RMA, Site 1, Site 2, All
             */
            if (request == "GetTotalInventoryRq")
            {
                var PartNumber = context.Request.QueryString["PartNumber"];
                var LocationGroup = context.Request.QueryString["LocationGroup"];

                if (PartNumber == null || LocationGroup == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required elements \"PartNumber\" and \"LocationGroup\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.GetTotalInventoryRq(Misc.Key,
                    PartNumber, LocationGroup));
            }

            if (request == "ImportListRq")
            {
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportListRq(Misc.Key));
            }

            if (request == "ImportRq")
            {
                var Type = context.Request.QueryString["Type"];
                var Rows = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Rows");

                if (Type == null || Rows == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required elements \"Type\" and/or \"Rows\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportRq(Misc.Key,
                    Type, Rows));
            }

            if (request == "ImportHeaderRq")
            {
                var Type = context.Request.QueryString["Type"];

                if (Type == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required elements \"Type\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.ImportHeaderRq(Misc.Key, Type));
            }

            // Works. Requires PartNum.
            if (request == "InvQtyRq")
            {
                var PartNum = context.Request.QueryString["PartNum"];
                var LastModifiedFrom = context.Request.QueryString["LastModifiedFrom"];
                var LastModifiedTo = context.Request.QueryString["LastModifiedTo"];

                if (PartNum == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"PartNum\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

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

            // Works. Requires 'Number' to return meaningful data.
            if (request == "LoadSORq")
            {
                var Number = context.Request.QueryString["Number"];

                if (Number == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"Number\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

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
                var PaymentObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Payment");
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.MakePaymentRq(Misc.Key, PaymentObj));
            }

            if (request == "MoveRq")
            {
                var SourceLocationObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "SourceLocation");
                var PartObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Part"); ;
                var Quantity = context.Request.QueryString["Quantity"];
                var Note = context.Request.QueryString["Note"];
                var TrackingObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Tracking");
                var DestinationLocationObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "DestinationLocation");
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

                if (Number == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"Number\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

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
                var DiscountObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Discount"); ;
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveDiscountRq(Misc.Key, DiscountObj));
            }

            if (request == "SaveImageRq")
            {
                var Type = context.Request.QueryString["Type"];
                var Number = context.Request.QueryString["Number"];
                var Image = context.Request.QueryString["Image"];
                var UpdateAssociations = context.Request.QueryString["UpdateAssociations"];
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveImageRq(Misc.Key,
                    Type, Number, Image, UpdateAssociations));
            }

            if (request == "SavePickRq")
            {
                var PickObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Pick");
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SavePickRq(Misc.Key, PickObj));
            }

            if (request == "SaveReceiptRq")
            {
                var ReceiptObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Receipt");
                if (ReceiptObj == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required object \"Receipt\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveReceiptRq(Misc.Key, ReceiptObj));
            }

            if (request == "SaveReportRq")
            {
                var ReportTree = context.Request.QueryString["ReportTree"];
                var ReportObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Report");
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SaveReportRq(Misc.Key,
                    ReportTree, ReportObj));
            }

            if (request == "SaveShipmentRq")
            {
                var ShippingObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Shipping");
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
                var LocationObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "Location");
                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.SetDefPartLocRq(Misc.Key,
                    PartNum, LocationObj));
            }

            if (request == "SaveTaxRateRq")
            {
                var TaxRateObj = FishbowlLegacy.ExtractFishbowlObject(context.Request.Payload, "TaxRate");
                if (TaxRateObj == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required object \"TaxRate\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }
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

                if (Name == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"Name\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

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

                if (ShipNum == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"ShipNum\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VoidShipmentRq(Misc.Key, ShipNum));
            }

            if (request == "VoidSORq")
            {
                var SONumber = context.Request.QueryString["SONumber"];

                if (SONumber == null)
                {
                    response = FishbowlLegacy.GenericXMLError("Missing required element \"SONumber\".");
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    goto sendResponse;
                }

                response = ConnectionObject.sendCommand(FishbowlLegacyRequests.VoidSORq(Misc.Key, SONumber));
            }
        }

    sendResponse:
        if (RespondInJson)
            context.Response.SendResponse(FishbowlLegacy.Xml2Json(response));
        else
            context.Response.SendResponse(response);

        return context;
    }
}
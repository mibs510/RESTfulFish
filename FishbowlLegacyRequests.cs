using System;
using System.Xml;
using System.Security.Cryptography;
using System.IO;

namespace RESTfulFish
{
    class FishbowlLegacyRequests
    {
        public FishbowlLegacyRequests()
        {

        }

        /* Description: Adds initial inventory of a part.
         * Syntax: <AddInventoryRq>
	                    <PartNum>string</PartNum>
	                    <Quantity>int</Quantity>
	                    <UOMID>int</UOMID>
	                    <Cost>price</Cost>
	                    <Note>string</Note>
	                    <Tracking>Tracking object</Tracking>
	                    <LocationTagNum>int</LocationTagNum>
	                    <TagNum>int</TagNum>
                   </AddInventoryRq>
        */
        public static String AddInventoryRq(String Key, String PartNum, String Quantity, 
            String UOMID, String Cost, String Note, String TrackingObj, 
            String LocationTagNum, String TagNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "AddInventoryRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (UOMID != null)
                xml.Item1.WriteElementString("UOMID", UOMID);
            if (Cost != null)
                xml.Item1.WriteElementString("Cost", Cost);
            if (Note != null)
                xml.Item1.WriteElementString("Note", Note);
            if (TrackingObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Tracking", TrackingObj);
            if (LocationTagNum != null)
                xml.Item1.WriteElementString("LocationTagNum", LocationTagNum);
            if (PartNum != null)
                xml.Item1.WriteElementString("TagNum", TagNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Adds a memo to the specified object.
         * Syntax; <AddMemoRq>
	                        <ItemType>Part, Product, Customer, Vendor, SO, PO, TO, MO, RMA, BOM</ItemType>
	                        <PartNum>string</PartNum>
	                        <ProductNum>string</ProductNum>
	                        <OrderNum>string</OrderNum>
	                        <CustomerNum>string</CustomerNum>
	                        <VendorNum>string</VendorNum>
	                        <Memo>Memo object</Memo>
                   </AddMemoRq>
        */
        public static String AddMemoRq(String Key, String ItemType, String PartNum, 
            String ProductNum, String OrderNum, String CustomerNum, 
            String VendorNum, String MemoObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "AddMemoRq");

            if (ItemType != null)
                xml.Item1.WriteElementString("ItemType", ItemType);
            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (ProductNum != null)
                xml.Item1.WriteElementString("ProductNum", ProductNum);
            if (OrderNum != null)
                xml.Item1.WriteElementString("OrderNum", OrderNum);
            if (CustomerNum != null)
                xml.Item1.WriteElementString("CustomerNum", CustomerNum);
            if (VendorNum != null)
                xml.Item1.WriteElementString("VendorNum", VendorNum);
            if (MemoObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Memo", MemoObj);


            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Adds an item to a Sales Order.
         * Syntax: <AddSOItemRq>
	                        <OrderNum>string</OrderNum>
	                        <SalesOrderItem>Sales Order Item object</SalesOrderItem>
                   </AddSOItemRq>
        */
        public static String AddSOItemRq(String Key, String OrderNum, String SalesOrderItemObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "AddSOItemRq");

            if (OrderNum != null)
                xml.Item1.WriteElementString("OrderNum", OrderNum);
            if (SalesOrderItemObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "SalesOrderItem", SalesOrderItemObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Add an item to an existing open WO.
         * Syntax: <AddWorkOrderItemRq>
	                        <OrderNum>string</OrderNum>
	                        <TypeId>DB int</TypeId>
	                        <Description>string</Description>
	                        <PartNum>string</PartNum>
	                        <Quantity>int</Quantity>
	                        <UOMCode>string</UOMCode>
	                        <Cost>Money</Cost>
                   </AddWorkOrderItemRq>
        */
        public static String AddWorkOrderItemRq(String Key, String OrderNum, String TypeId, 
            String Description, String PartNum, String Quantity, String UOMCode, 
            String Cost)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "AddWorkOrderItemRq");

            if (OrderNum != null)
                xml.Item1.WriteElementString("OrderNum", OrderNum);
            if (TypeId != null)
                xml.Item1.WriteElementString("TypeId", TypeId);
            if (Description != null)
                xml.Item1.WriteElementString("Description", Description);
            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (UOMCode != null)
                xml.Item1.WriteElementString("UOMCode", UOMCode);
            if (Cost != null)
                xml.Item1.WriteElementString("Cost", Cost);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }


        /* Description: Adjust the inventory in a tag.
         * Syntax: <BuildBomRq>
	                        <BomNumber>string</BomNumber>
	                        <Quantity>int</Quantity>
	                        <DateScheduled>Date</DateScheduled>
                   </BuildBomRq>
        */
        public static String BuildBomRq(String Key, String BomNumber, String Quantity, 
            String DateScheduled)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "BuildBomRq");

            if (BomNumber != null)
                xml.Item1.WriteElementString("BomNumber", BomNumber);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (DateScheduled != null)
                xml.Item1.WriteElementString("DateScheduled", DateScheduled);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This generates a shipping order that is completely fictitious.
         * You would use this request to calculate the cost etc. 
         * If you want to actually process this order you need to use the Save.
         * Syntax: <CalculateSORq>
	                        <SalesOrder>Sales Order object</SalesOrder>
                   </CalculateSORq>
        */
        public static String CalculateSORq(String Key, String SalesOrderObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CalculateSORq");

            if (SalesOrderObj != null)
                xml.Item1.WriteElementString("SalesOrder", SalesOrderObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns the names of every Carrier in your database.
         * Syntax: <CarrierListRq />
         */
        public static String CarrierListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CarrierListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request is used to close short a sales order
         * Syntax: <CloseShortSORq>SO Number</CloseShortSORq>
         */
        public static String CloseShortSORq(String Key, String SONumber)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CloseShortSORq");

            if (SONumber != null)
                xml.Item1.WriteString(SONumber);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This returns a Customer object from your database 
         * with all the data associated with that customer Note When 
         * currency rate is 0 then customer is using the default currency rate.
         * Syntax: <CustomerGetRq>
	                        <Name>Customer Name</Name>
                   </CustomerGetRq>
        */
        public static String CustomerGetRq(String Key, String Name)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CustomerGetRq");

            if (Name != null)
                xml.Item1.WriteElementString("Name", Name);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a list of every Customer in your database with their details.
         * Syntax: <CustomerListRq />
         */
        public static String CustomerListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CustomerListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a list of the names of all the customers in your database.
         * Syntax: <CustomerNameListRq />
         */
        public static String CustomerNameListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CustomerNameListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Used to correct inventory amounts. Including Tracking information in optional.
         * Syntax: <CycleCountRq>
	                    <PartNum>DB int</PartNum>
	                    <Quantity>int</Quantity>
	                    <LocationID>DB int</LocationID>
	                    <Tracking>string</Tracking>
                   </CycleCountRq>
        */
        public static String CycleCountRq(String Key, String PartNum, String Quantity, 
            String LocationID, String Tracking)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "CycleCountRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (LocationID != null)
                xml.Item1.WriteElementString("LocationID", LocationID);
            if (Tracking != null)
                xml.Item1.WriteElementString("Tracking", Tracking);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Emails a report to a given email address (Date ranges cannot be specified)
         * Syntax: <EmailReportRq>
	                        <ReportName>string</ReportName>
	                        <ReportTree>string</ReportTree>
	                        <Email>string</Email>
	                        <ParameterList>
		                            <ReportParam>
			                                <Name>string</Name>
		                                	<Value>string</Value>
		                            </ReportParam>
	                        </ParameterList>
                   </EmailReportRq>
        */
        public static String EmailReportRq(String Key, String ReportName, String ReportTree, 
            String Email, String Name, String Value)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "EmailReportRq");

            if (ReportName != null)
                xml.Item1.WriteElementString("ReportName", ReportName);
            if (ReportTree != null)
                xml.Item1.WriteElementString("ReportTree", ReportTree);
            if (Email != null)
                xml.Item1.WriteElementString("Email", Email);
            if (Name != null && Value != null)
            {
                xml.Item1.WriteStartElement("ParameterList");
                xml.Item1.WriteStartElement("ReportParam");
                xml.Item1.WriteElementString("Name", Name);
                xml.Item1.WriteElementString("Value", Value);
                xml.Item1.WriteEndElement();
                xml.Item1.WriteEndElement();
            }

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns all available export options
         * Syntax: <ExportListRq />
         */
        public static String ExportListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ExportListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns export data of specified export Type
         * Syntax: <ExportRq>
	                    <Type>DB string</Type>
                   </ExportRq>
        */
        public static String ExportRq(String Key, String Type)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ExportRq");

            if (Type != null)
                xml.Item1.WriteElementString("Type", Type);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns results of sql query in csv format. 
         * Two options are available. 
         * A query that has been saved in the Fishbowl Client data 
         * module can be executed using<Name> or a query can be 
         * placed directly in the call using<Query>.
         * Syntax: <ExecuteQueryRq>
	                        <Name>DB string</Name>(optional)
	                        <Query>DB string</Query>(optional)
                   </ExecuteQueryRq>
        */
        public static String ExecuteQueryRq(String Key, String Name, String Query)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ExecuteQueryRq");

            if (Name != null)
                xml.Item1.WriteElementString("Name", Name);
            if (Query != null)
                xml.Item1.WriteElementString("Query", Query);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a list of all QuickBooks accounts complete with IDs, Types, and balances.
         * Syntax: <GetAccountListRq />
         */
        public static String GetAccountListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetAccountListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request will return the information on a specified pick.
         * Syntax: <GetPartListRq>
	                        <PartNum>DB string</PartNum>
	                        <PartDesc>string</PartDesc>
	                        <PartDetails>string</PartDetails>
	                        <PartUPC>string</PartUPC>
	                        <PartType>DB string</PartType>
	                        <ABCCode>string</ABCCode>
	                        <VendorName>DB string</VendorName>
	                        <VendorNum>string</VendorNum>
	                        <ProductNum>DB string</ProductNum>
	                        <ProductDesc>string</ProductDesc>
	                        <ActiveFlag>boolean</ActiveFlag>
	                        <ShowActive>boolean</ShowActive>
	                        <ShowInactive>boolean</ShowInactive>
	                        <HasBOM>boolean</HasBOM>
	                        <Configurable>boolean</Configurable>
                   </GetPartListRq>
         * TODO: Determine which parameters are required for basic minimum functionality.
         */
        public static String GetPartListRq(String Key, String PartNum, String PartDesc, 
            String PartDetails, String PartUPC, String PartType, String ABCCode, 
            String VendorName, String VendorNum, String ProductNum, 
            String ProductDesc, String ActiveFlag, String ShowActive, 
            String ShowInactive, String HasBOM, String Configurable)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetPartListRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (PartDesc != null)
                xml.Item1.WriteElementString("PartDesc", PartDesc);
            if (PartDetails != null)
                xml.Item1.WriteElementString("PartDetails", PartDetails);
            if (PartUPC != null)
                xml.Item1.WriteElementString("PartUPC", PartUPC);
            if (PartType != null)
                xml.Item1.WriteElementString("PartType", PartType);
            if (ABCCode != null)
                xml.Item1.WriteElementString("ABCCode", ABCCode);
            if (VendorName != null)
                xml.Item1.WriteElementString("VendorName", VendorName);
            if (VendorNum != null)
                xml.Item1.WriteElementString("VendorNum", VendorNum);
            if (ProductNum != null)
                xml.Item1.WriteElementString("ProductNum", ProductNum);
            if (ProductDesc != null)
                xml.Item1.WriteElementString("ProductDesc", ProductDesc);
            if (ActiveFlag != null)
                xml.Item1.WriteElementString("ActiveFlag", ActiveFlag);
            if (ShowActive != null)
                xml.Item1.WriteElementString("ShowActive", ShowActive);
            if (ShowInactive != null)
                xml.Item1.WriteElementString("ShowInactive", ShowInactive);
            if (HasBOM != null)
                xml.Item1.WriteElementString("HasBOM", HasBOM);
            if (Configurable != null)
                xml.Item1.WriteElementString("Configurable", Configurable);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request will return the information on a specified pick.
         * Syntax: <GetPickRq>
	                       <PickNum>DB string</PickNum>
                   </GetPickRq>
        */
        public static String GetPickRq(String Key, String PickNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetPickRq");

            if (PickNum != null)
                xml.Item1.WriteElementString("PickNum", PickNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns all purchase order queued in the specified location.
         * Syntax: <GetPOListRq>
	                       <LocationGroup>DB string</LocationGroup>
                   </GetPOListRq>
        */
        public static String GetPOListRq(String Key, String LocationGroup)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetPOListRq");

            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns receipt information.
         * Syntax: <GetReceiptRq>
	                       <OrderNumber>DB string</OrderNumber>
                           <OrderType>DB int</OrderType>
	                       <LocationGroup>DB int</LocationGroup>
                   </GetReceiptRq>
        */
        public static String GetReceiptRq(String Key, String OrderNumber, String OrderType, 
            String LocationGroup)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetReceiptRq");

            if (OrderNumber != null)
                xml.Item1.WriteElementString("OrderNumber", OrderNumber);
            if (OrderType != null)
                xml.Item1.WriteElementString("OrderType", OrderType);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Request a list of Shipments. 
         * This includes all those that have been shipped. 
         * Be sure to include more specifics on what you want to see. 
         * Note You cannot use Order Number in conjunction with Order Type and Carrier. 
         * Order Number returns the history of the use of that number, see Example 2. 
         * Also, to merit a response you must include the RecordCount field.
         * Syntax: <GetShipListRq>
	                       <StartRecord>int</StartRecord>
	                       <RecordCount>int</RecordCount>
	                       <OrderNumber>int</OrderNumber>
	                       <OrderTypeID>DB int</OrderTypeID>
	                       <LocationGroup>DB int</LocationGroup>
	                       <Carrier>DB int</Carrier>
                   </GetShipListRq>
        */
        public static String GetShipListRq(String Key, String StartRecord, 
            String RecordCount, String OrderTypeID, String StatusID, 
            String LocationGroup, String Carrier)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetShipListRq");

            if (StartRecord != null)
                xml.Item1.WriteElementString("StartRecord", StartRecord);
            if (RecordCount != null)
                xml.Item1.WriteElementString("RecordCount", RecordCount);
            if (OrderTypeID != null)
                xml.Item1.WriteElementString("OrderTypeID", OrderTypeID);
            if (StatusID != null)
                xml.Item1.WriteElementString("StatusID", StatusID);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);
            if (Carrier != null)
                xml.Item1.WriteElementString("Carrier", Carrier);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns the shipment details about a specified shipment.
         * Syntax: <GetShipmentRq>
	                        <ShipmentID>int</ShipmentID>
	                        <ShipmentNum>string</ShipmentNum>
                   </GetShipmentRq>
        */
        public static String GetShipmentRq(String Key, String ShipmentID, String ShipmentNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetShipmentRq");

            if (ShipmentID != null)
                xml.Item1.WriteElementString("ShipmentNum", ShipmentID);
            if (ShipmentNum != null)
                xml.Item1.WriteElementString("ShipmentNum", ShipmentNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a list of orders that are packed and ready to ship.
         * Syntax: <GetShipNowListRq>
	                        <LocationGroup>string</LocationGroup>
	                        <Carrier>
		                            <Name>string</Name>
	                        </Carrier>
                   </GetShipNowListRq>
        */
        public static String GetShipNowListRq(String Key, String LocationGroup, String Name)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetShipNowListRq");

            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);
            if (Name != null)
            {
                xml.Item1.WriteStartElement("Carrier");
                xml.Item1.WriteElementString("Name", Name);
                xml.Item1.WriteEndElement();
            }

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a detailed list of SOs (Sales Orders) based on the search parameters.
         * Syntax: <GetSOListRq>
	                        <SONum>string</SONum>
	                        <LocationGroup>DB int</LocationGroup>
	                        <Status>string</Status>
	                        <CustomerPO>string</CustomerPO>
	                        <CustomerName>string</CustomerName>
	                        <AccountNumber>string</AccountNumber>
	                        <BillTo>string</BillTo>
	                        <ShipTo>string</ShipTo>
	                        <ProductNum>string</ProductNum>
	                        <ProductDesc>string</ProductDesc>
	                        <ProductDetails>string</ProductDetails>
	                        <Salesman>string</Salesman>
	                        <Type>string</Type>
	                        <DateIssuedBegin>date</DateIssuedBegin>
	                        <DateIssuedEnd>date</DateIssuedEnd>
	                        <DateCreatedBegin>date</DateCreatedBegin>
	                        <DateCreatedEnd>date</DateCreatedEnd>
	                        <DateLasteModifiedBegin>date</DateLasteModifiedBegin>
	                        <DateLasteModifiedEnd>date</DateLasteModifiedEnd>
	                        <DateScheduledBegin>date</DateScheduledBegin>
	                        <DateScheduledEnd>date</DateScheduledEnd>
                	        <DateCompletedBegin>date</DateCompletedBegin>
	                        <DateCompletedEnd>date</DateCompletedEnd>
                   </GetSOListRq>
         */
        public static String GetSOListRq(String Key, String SONum, String LocationGroup,
            String Status, String CustomerPO, String CustomerName,
            String AccountNumber, String BillTo, String ShipTo, String ProductNum,
            String ProductDesc, String ProductDetails, String Salesman,
            String Type, String DateIssuedBegin, String DateIssuedEnd, String DateCreatedBegin,
            String DateCreatedEnd, String DateLasteModifiedBegin,
            String DateLasteModifiedEnd, String DateScheduledBegin,
            String DateScheduledEnd, String DateCompletedBegin, String DateCompletedEnd)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetSOListRq");

            if (SONum != null)
                xml.Item1.WriteElementString("SONum", SONum);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);
            if (Status != null)
                xml.Item1.WriteElementString("Status", Status);
            if (CustomerPO != null)
                xml.Item1.WriteElementString("CustomerPO", CustomerPO);
            if (CustomerName != null)
                xml.Item1.WriteElementString("CustomerName", CustomerName);
            if (AccountNumber != null)
                xml.Item1.WriteElementString("AccountNumber", AccountNumber);
            if (BillTo != null)
                xml.Item1.WriteElementString("BillTo", BillTo);
            if (ShipTo != null)
                xml.Item1.WriteElementString("ShipTo", ShipTo);
            if (ProductNum != null)
                xml.Item1.WriteElementString("ProductNum", ProductNum);
            if (ProductDesc != null)
                xml.Item1.WriteElementString("ProductDesc", ProductDesc);
            if (ProductDetails != null)
                xml.Item1.WriteElementString("ProductDetails", ProductDetails);
            if (Salesman != null)
                xml.Item1.WriteElementString("Salesman", Salesman);
            if (Type != null)
                xml.Item1.WriteElementString("Type", Type);
            if (DateIssuedBegin != null)
                xml.Item1.WriteElementString("DateIssuedBegin", DateIssuedBegin);
            if (DateIssuedEnd != null)
                xml.Item1.WriteElementString("DateIssuedEnd", DateIssuedEnd);
            if (DateCreatedBegin != null)
                xml.Item1.WriteElementString("DateCreatedBegin", DateCreatedBegin);
            if (DateCreatedEnd != null)
                xml.Item1.WriteElementString("DateCreatedEnd", DateCreatedEnd);
            if (DateLasteModifiedBegin != null)
                xml.Item1.WriteElementString("DateLasteModifiedBegin", DateLasteModifiedBegin);
            if (DateLasteModifiedEnd != null)
                xml.Item1.WriteElementString("DateLasteModifiedEnd", DateLasteModifiedEnd);
            if (DateScheduledBegin != null)
                xml.Item1.WriteElementString("DateScheduledBegin", DateScheduledBegin);
            if (DateScheduledEnd != null)
                xml.Item1.WriteElementString("DateScheduledEnd", DateScheduledEnd);
            if (DateCompletedBegin != null)
                xml.Item1.WriteElementString("DateCompletedBegin", DateCompletedBegin);
            if (DateCompletedEnd != null)
                xml.Item1.WriteElementString("DateCompletedEnd", DateCompletedEnd);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns the total number of the inquired item at a specific location.
         * Syntax: <GetTotalInventoryRq>
	                        <PartNumber>string</PartNumber>
	                        <LocationGroup>DB string</LocationGroup>
                   </GetTotalInventoryRq>
        */
        public static String GetTotalInventoryRq(String Key, String PartNumber, String LocationGroup)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "GetTotalInventoryRq");

            if (PartNumber != null)
                xml.Item1.WriteElementString("PartNumber", PartNumber);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request returns a list of your import options.
         * Syntax: <ImportListRq />
         */
        public static String ImportListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ImportListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request allows you to import data. 
         * The example uses the import to edit/add a vendor. 
         * Data columns can be blank, but each data column must be represented in the request. 
         * It is best practice to always include the header rows when importing data.
         * Syntax: <ImportRq>
	                    <Type>DB string</Type>
	                    <Rows>
		                    <Row>Data for each column required by the Type</Row>
	                    </Rows>
                   </ImportRq>
        * TODO: Reimplement Row as a string array so that the web app does not have to 
        * call this request for each row, if there is more than one row to be imported.
        */
        public static String ImportRq(String Key, String Type, String Rows)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ImportRq");

            if (Type != null)
                xml.Item1.WriteElementString("Type", Type);
            if (Rows != null)
            {
                xml.Item1.WriteStartElement("Rows", Rows);
                xml.Item1.WriteEndElement();
            }

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request allows you to get the headers of an import. 
         * The example retrieves the import headers of the Add Inventory import.
         * Syntax: <ImportHeaderRq>
	                        <Type>ImportAddInventory</Type>
                   </ImportHeaderRq>
        */
        public static String ImportHeaderRq(String Key, String Type)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ImportHeaderRq");

            if (Type != null)
                xml.Item1.WriteElementString("Type", Type);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns details and quantity of a 
         * specified Part or list of parts modified within the given date range.
         * Syntax: <InvQtyRq>
	                    <PartNum>DB string</PartNum>
	                    <LastModifiedFrom>Date</LastModifiedFrom>
	                    <LastModifiedTo>Date</LastModifiedTo>
                   </InvQtyRq>
        */ 
        public static String InvQtyRq(String Key, String PartNum, String LastModifiedFrom, 
            String LastModifiedTo)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "InvQtyRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (LastModifiedFrom != null)
                xml.Item1.WriteElementString("LastModifiedFrom", LastModifiedFrom);
            if (LastModifiedTo != null)
                xml.Item1.WriteElementString("LastModifiedTo", LastModifiedTo);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Will issue a SalesOrder.
         * Syntax: <IssueSORq>
	                    <SONumber>string</SONumber>
                   </IssueSORq>
        */
        public static String IssueSORq(String Key, String SONumber)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "IssueSORq");

            if (SONumber != null)
                xml.Item1.WriteElementString("SONumber", SONumber);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a simple list of parts.
         * Syntax: <LightPartListRq />
         */
        public static String LightPartListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "LightPartListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This will return information about the specified sales order.
         * Syntax: <LoadSORq>
	                    <Number>string</Number>
                   </LoadSORq>
        */
        public static String LoadSORq(String Key, String Number)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "LoadSORq");

            if (Number != null)
                xml.Item1.WriteElementString("Number", Number);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns a list of locations and their details.
         * Syntax: <LocationListRq />
         */
        public static String LocationListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "LocationListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns information on a Location.
         * Syntax: <LocationQueryRq>
	                        <LocationID>DB int</LocationID>
	                        <TagNum>int</TagNum>
                   </LocationQueryRq>
        */
        public static String LocationQueryRq(String Key, String LocationID, String TagNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "LocationQueryRq");

            if (LocationID != null)
                xml.Item1.WriteElementString("LocationID", LocationID);
            if (TagNum != null)
                xml.Item1.WriteElementString("TagNum", TagNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Logs a user in or out of Fishbowl.
         * If the login request contains a ticket it will log the user out.
         * The IAID and the IAName must be unique per Fishbowl server.
         * The algorithm required to encrypt the password is Base64.encode(MD5.hash(password))
         * Syntax: <LoginRq>
	                    <IAID>int</IAID>
	                    <IAName>string</IAName>
	                    <IADescription>string</IADescription>
	                    <Username>string</Username>
	                    <UserPassword>encrypted string</UserPassword>
                   </LoginRq>
         */
        public static String LoginRq(String IAID, String IADescription, String UserName, 
            String IAName, String UserPassword)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(UserPassword));
            string encryptedUserPassword = Convert.ToBase64String(encoded, 0, 16);
            
            // Cleanup
            md5.Dispose();
            encoded = null;

            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(null, "LoginRq");

            if (IAID != null)
                xml.Item1.WriteElementString("IAID", IAID);
            if (IADescription != null)
                xml.Item1.WriteElementString("IADescription", IADescription);
            if (UserName != null)
                xml.Item1.WriteElementString("UserName", UserName);
            if (IAName != null)
                xml.Item1.WriteElementString("IAName", IAName);
            if (UserPassword != null)
                xml.Item1.WriteElementString("UserPassword", encryptedUserPassword);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Makes a payment on the specified order.
         * Syntax: <MakePaymentRq>
	                        <Payment>Payment object</Payment>
                   </MakePaymentRq>
        */
        public static String MakePaymentRq(String Key, String PaymentObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "MakePaymentRq");

            if (PaymentObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Payment", PaymentObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Moves items from one specified location to another.
         * Syntax: <MoveRq>
	                    <SourceLocation>
		                        <Location>Location object</Location>
	                    </SourceLocation>
	                    <Part>Part object</Part>
	                    <Quantity>int</Quantity>
	                    <Note>string</Note>
	                    <Tracking>Tracking object</Tracking>
	                    <DestinationLocation>
		                        <Location>Location object</Location>
	                    </DestinationLocation>
                   </MoveRq>
        */
        public static String MoveRq(String Key, String SourceLocationObj, String PartObj, 
            String Quantity, String Note, String TrackingObj, String DestinationLocationObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "MoveRq");

            if (SourceLocationObj != null)
            {
                xml.Item1.WriteStartElement("SourceLocation");
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Location", SourceLocationObj);
                xml.Item1.WriteEndElement();
            }
            if (PartObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Part", PartObj);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (Note != null)
                xml.Item1.WriteElementString("Note", Note);
            if (TrackingObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Tracking", TrackingObj);
            if (DestinationLocationObj != null)
            {
                xml.Item1.WriteStartElement("DestinationLocation");
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Location", DestinationLocationObj);
                xml.Item1.WriteEndElement();
            }

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Use this request to obtain the average cost at which you've previously 
         * bought this Part.
         * Syntax: <PartCostRq>
	                        <PartNum>string</PartNum>
                   </PartCostRq>
        */
        public static String PartCostRq(String Key, String PartNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "PartCostRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns all the information pertaining to a specified Part at your default location.
         * Syntax: <PartGetRq>
	                       <Number>string</Number>
	                       <GetImage>boolean</GetImage>
                   </PartGetRq>
        */
        public static String PartGetRq(String Key, String Number, String GetImage)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "PartGetRq");

            if (Number != null)
                xml.Item1.WriteElementString("Number", Number);
            if (GetImage != null)
                xml.Item1.WriteElementString("GetImage", GetImage);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Like Part Get, Part Query Returns all the information pertaining to a specified Part. 
         * However, you can also specify location.
         * Syntax: <PartQueryRq>
	                        <PartNum>int</PartNum>
	                        <LocationGroup>string</LocationGroup>
                   </PartQueryRq>
        */
        public static String PartQueryRq(String Key, String PartNum, String LocationGroup)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "PartGetRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request will return all the picks that you specify. 
         * You can refine your results by its place in the index 
         * (StartIndex in conjunction with RecordCount), pick number, 
         * order number, pick Type, status, priority, the first date to include, 
         * last date to include, whether or not it's fulfillable, or by its 
         * location group. The starting index defines at what point the records 
         * you want returned will start, default is 0. Record count is how may
         * records you want returned.
         * Syntax: <PickQueryRq>
	                        <StartIndex>int</StartIndex>
	                        <RecordCount>int</RecordCount>
	                        <PickNum>string</PickNum>
	                        <OrderNum>string</OrderNum>
	                        <PickType>DB string</PickType>
	                        <Status>DB string</Status>
	                        <Priority>DB string</Priority>
	                        <StartDate>date/time</StartDate>
	                        <EndDate>date/time</EndDate>
            	            <Fulfillable>boolean</Fulfillable>
	                        <LocationGroup>DB string</LocationGroup>
                   </PickQueryRq>
        */
        public static String PickQueryRq(String Key, String StartIndex, String RecordCount, 
            String PickNum, String OrderNum, String PickType, String Status, 
            String Priority, String StartDate, String EndDate, 
            String Fulfillable, String LocationGroup)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "PickQueryRq");

            if (StartIndex != null)
                xml.Item1.WriteElementString("StartIndex", StartIndex);
            if (RecordCount != null)
                xml.Item1.WriteElementString("RecordCount", RecordCount);
            if (PickNum != null)
                xml.Item1.WriteElementString("PickNum", PickNum);
            if (OrderNum != null)
                xml.Item1.WriteElementString("OrderNum", OrderNum);
            if (PickType != null)
                xml.Item1.WriteElementString("PickType", PickType);
            if (Status != null)
                xml.Item1.WriteElementString("Status", Status);
            if (Priority != null)
                xml.Item1.WriteElementString("Priority", Priority);
            if (StartDate != null)
                xml.Item1.WriteElementString("StartDate", StartDate);
            if (EndDate != null)
                xml.Item1.WriteElementString("EndDate", EndDate);
            if (Fulfillable != null)
                xml.Item1.WriteElementString("Fulfillable", Fulfillable);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);


            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Prints the default report for the specified module.
         * Syntax: <PrintReportRq>
	                       <ModuleName>Shipping</ModuleName>
	                       <ParameterList>
		                            <ReportParam>
			                                <Name>shipID</Name>
			                                <Value>33</Value>
		                            </ReportParam>
	                       </ParameterList>
                   </PrintReportRq>
        */
        public static String PrintReportRq(String Key, String ModuleName, String Name, String Value)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "PrintReportRq");

            if (ModuleName != null)
                xml.Item1.WriteElementString("ModuleName", ModuleName);
            if (Name != null && Value != null)
            {
                xml.Item1.WriteStartElement("ParameterList");
                xml.Item1.WriteStartElement("ReportParam");
                xml.Item1.WriteElementString("Name", Name);
                xml.Item1.WriteElementString("Value", Value);
                xml.Item1.WriteEndElement();
                xml.Item1.WriteEndElement();
            }

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Requests detailed information about the product. 
         * This includes the product's underlying part, 
         * the product's base UOM and its tracking information. 
         * GetImage is a flag indicating if the image should be included.
         * Syntax: <ProductGetRq>
	                        <Number>string</Number>
	                        <GetImage>boolean</GetImage>
                   </ProductGetRq>
        */
        public static String ProductGetRq(String Key, String Number, String GetImage)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ProductGetRq");

            if (Number != null)
                xml.Item1.WriteElementString("Number", Number);
            if (GetImage != null)
                xml.Item1.WriteElementString("GetImage", GetImage);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Request the best price for a given product.
         * Syntax: <ProductPriceRq>
	                        <ProductNumber>string</ProductNumber>
	                        <CustomerName>string</CustomerName>
	                        <Quantity>int</Quantity>
	                        <Date>date</Date>
                   </ProductPriceRq>
        */
        public static String ProductPriceRq(String Key, String ProductNumber, String CustomerName, 
            String Quantity, String Date)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ProductPriceRq");

            if (ProductNumber != null)
                xml.Item1.WriteElementString("ProductNumber", ProductNumber);
            if (CustomerName != null)
                xml.Item1.WriteElementString("CustomerName", CustomerName);
            if (Quantity != null)
                xml.Item1.WriteElementString("Quantity", Quantity);
            if (Date != null)
                xml.Item1.WriteElementString("Date", Date);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Will do an automatic pick, pack, and ship on a 
         * Sales Order that has already been issued 
         * (Work Orders tied to the SO must be fulfilled also). 
         * Fishbowl automatically picks the best tracking available. 
         * FulfillServiceItems indicates if the service items on 
         * the SO should be fulfilled during ship.
         * Syntax: <QuickShipRq>
	                        <SONumber>string</SONumber>
	                        <FulfillServiceItems>boolean</FulfillServiceItems>
	                        <LocationGroup>string</LocationGroup>
	                        <ErrorIfNotFulfilled>boolean</ErrorIfNotFulfilled>
	                        <ShipDate>date</ShipDate>
                   </QuickShipRq>
        */
        public static String QuickShipRq(String Key, String SONumber, String FulfillServiceItems, 
            String LocationGroup, String ErrorIfNotFulfilled, String ShipDate)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "QuickShipRq");

            if (SONumber != null)
                xml.Item1.WriteElementString("SONumber", SONumber);
            if (FulfillServiceItems != null)
                xml.Item1.WriteElementString("FulfillServiceItems", FulfillServiceItems);
            if (LocationGroup != null)
                xml.Item1.WriteElementString("LocationGroup", LocationGroup);
            if (ErrorIfNotFulfilled != null)
                xml.Item1.WriteElementString("ErrorIfNotFulfilled", ErrorIfNotFulfilled);
            if (ShipDate != null)
                xml.Item1.WriteElementString("ShipDate", ShipDate);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Returns information about orders in the receiving module.
         * You can narrow your search by filling in as many of the controls as you wish. 
         * It will return all orders that contain the specified details. 
         * Note To get a response the order number specified must be a receiving order!
         * Syntax: <ReceivingListRq>
	                        <OrderNumber>string</OrderNumber>
	                        <OrderType>DB int</OrderType>
	                        <ReceiptStatus>DB int</ReceiptStatus>
	                        <StartRecord>int</StartRecord>
	                        <RecordCount>int</RecordCount>
	                        <DateIssuedBegin>date/time</DateIssuedBegin>
	                        <DateIssuedEnd>date/time</DateIssuedEnd>
	                        <DateFulfilledBegin>date/time</DateFulfilledBegin>
	                        <DateFulfilledEnd>date/time</DateFulfilledEnd>
	                        <DateReceivedBegin>date/time</DateReceivedBegin>
	                        <DateReceivedEnd>date/time</DateReceivedEnd>
	                        <DateReconciledBegin>date/time</DateReconciledBegin>
	                        <DateReconciledEnd>date/time</DateReconciledEnd>
                	        <PartNum>string</PartNum>
	                        <PartDesc>string</PartDesc>
	                        <LocationGroupID>DB int</LocationGroupID>
	                        <RMANum>string</RMANum>
	                        <VendorName>string</VendorName>
                   </ReceivingListRq>
        */
        public static String ReceivingListRq(String Key, String OrderNumber, String OrderType,
            String ReceiptStatus, String StartRecord, String RecordCount, String DateIssuedBegin,
            String DateIssuedEnd, String DateFulfilledBegin, String DateFulfilledEnd,
            String DateReceivedBegin, String DateReceivedEnd, String DateReconciledBegin,
            String DateReconciledEnd, String PartNum, String PartDesc, String LocationGroupID,
            String RMANum, String VendorName)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "ReceivingListRq");

            if (OrderNumber != null)
                xml.Item1.WriteElementString("OrderNumber", OrderNumber);
            if (OrderType != null)
                xml.Item1.WriteElementString("OrderType", OrderType);
            if (ReceiptStatus != null)
                xml.Item1.WriteElementString("ReceiptStatus", ReceiptStatus);
            if (StartRecord != null)
                xml.Item1.WriteElementString("StartRecord", StartRecord);
            if (RecordCount != null)
                xml.Item1.WriteElementString("RecordCount", RecordCount);
            if (DateIssuedBegin != null)
                xml.Item1.WriteElementString("DateIssuedBegin", DateIssuedBegin);
            if (DateIssuedEnd != null)
                xml.Item1.WriteElementString("DateIssuedEnd", DateIssuedEnd);
            if (DateFulfilledBegin != null)
                xml.Item1.WriteElementString("DateFulfilledBegin", DateFulfilledBegin);
            if (DateFulfilledEnd != null)
                xml.Item1.WriteElementString("DateFulfilledEnd", DateFulfilledEnd);
            if (DateReceivedBegin != null)
                xml.Item1.WriteElementString("DateReceivedBegin", DateReceivedBegin);
            if (DateReceivedEnd != null)
                xml.Item1.WriteElementString("DateReceivedEnd", DateReceivedEnd);
            if (DateReconciledBegin != null)
                xml.Item1.WriteElementString("DateReconciledBegin", DateReconciledBegin);
            if (DateReconciledEnd != null)
                xml.Item1.WriteElementString("DateReconciledEnd", DateReconciledEnd);
            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (PartDesc != null)
                xml.Item1.WriteElementString("PartDesc", PartDesc);
            if (LocationGroupID != null)
                xml.Item1.WriteElementString("LocationGroupID", LocationGroupID);
            if (RMANum != null)
                xml.Item1.WriteElementString("RMANum", RMANum);
            if (VendorName != null)
                xml.Item1.WriteElementString("VendorName", VendorName);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Saves and updates discounts
         * Syntax: <SaveDiscountRq>
	                        <Discount>Discount object</Discount>
                   </SaveDiscountRq>
        */
        public static String SaveDiscountRq(String Key, String DiscountObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveDiscountRq");

            if (DiscountObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Discount", DiscountObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Saves an image to the associated object.
         * Syntax: <SaveImageRq>
	                        <Type>string</Type>
	                        <Number>string</Number>
	                        <Image>string</Image>
	                        <UpdateAssociations>boolean</UpdateAssociations>
                   </SaveImageRq>
        */
        public static String SaveImageRq(String Key, String Type, String Number, 
            String Image, String UpdateAssociations)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveImageRq");

            if (Type != null)
                xml.Item1.WriteElementString("Type", Type);
            if (Number != null)
                xml.Item1.WriteElementString("Number", Number);
            if (Image != null)
                xml.Item1.WriteElementString("Image", Image);
            if (UpdateAssociations != null)
                xml.Item1.WriteElementString("UpdateAssociations", UpdateAssociations);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request enables you to make changes to and fulfill picks.
         * Syntax: <SavePickRq>
	                    <Pick>Pick object</Pick>
                   </SavePickRq>
        */
        public static String SavePickRq(String Key, String PickObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SavePickRq");

            if (PickObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Pick", PickObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Updates receipt stored data.
         * Syntax: <SaveReceiptRq>
	                        <Receipt>Receipt object</Receipt>
                   </SaveReceiptRq>
        */
        public static String SaveReceiptRq(String Key, String ReceiptObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveReceiptRq");

            if (ReceiptObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Receipt", ReceiptObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Saves the report data. (Must restart client to view changes)
         * Syntax: <SaveReportRq>
	                    <ReportTree>DB String</ReportTree>
	                    <Report>Report object</Report>
                   </SaveReportRq>
        */
        public static String SaveReportRq(String Key, String ReportTree, String ReportObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveReportRq");

            if (ReportTree != null)
                xml.Item1.WriteElementString("ReportTree", ReportTree);
            if (ReportObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Report", ReportObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Saves the shipment data.
         * Syntax: <SaveShipmentRq>
	                        <Shipping>Shipping object</Shipping>>
                   </SaveShipmentRq>
        */
        public static String SaveShipmentRq(String Key, String ShippingObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveShipmentRq");

            if (ShippingObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Shipping", ShippingObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Request permits the change of a product UPC (Universal Product Code).
         * Syntax: <SaveUPCRq>
	                    <PartNum>DB string</PartNum>
	                    <UPC>string</UPC>
	                    <UpdateProducts>boolean</UpdateProducts>
                   </SaveUPCRq>
         */
        public static String SaveUPCRq(String Key, String PartNum, String UPC, String UpdateProducts)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveUPCRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (UPC != null)
                xml.Item1.WriteElementString("UPC", UPC);
            if (UpdateProducts != null)
                xml.Item1.WriteElementString("UpdateProducts", UpdateProducts);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Enables you to change the default location of a part.
         * Use the database to find all the details for the Location object 
         * that you want to use as the default location.
         * Syntax: <SetDefPartLocRq>
	                        <PartNum>DB string</PartNum>
	                        <Location>Location object</Location>
                   </SetDefPartLocRq>
        */
        public static String SetDefPartLocRq(String Key, String PartNum, String LocationObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SetDefPartLocRq");

            if (PartNum != null)
                xml.Item1.WriteElementString("PartNum", PartNum);
            if (LocationObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "Location", LocationObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Saves and updates tax rates.
         * Note The percent that is entered must be entered in 
         * decimal format (i.e. 10 percent is entered as .1).
         * Syntax: <SaveTaxRateRq>
	                        <TaxRate>Tax Rate object</TaxRate>
                   </SaveTaxRateRq>
        */
        public static String SaveTaxRateRq(String Key, String TaxRateObj)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SaveTaxRateRq");

            if (TaxRateObj != null)
                FishbowlLegacy.WriteFishbowlLegacyObj(xml.Item1, "TaxRate", TaxRateObj);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Ships an order. Note Order Number must be written with an S in front.
         * Syntax: <ShipRq>
        	            <ShipNum>string</ShipNum>
	                    <ShipDate>date/time</ShipDate>
	                    <FulfillService>boolean</FulfillService>
                   </ShipRq>
        */
        public static String ShipRq(String Key, String ShipNum, String ShipDate, String FulfillService)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "SetDefPartLocRq");

            if (ShipNum != null)
                xml.Item1.WriteElementString("ShipNum", ShipNum);
            if (ShipDate != null)
                xml.Item1.WriteElementString("ShipDate", ShipDate);
            if (FulfillService != null)
                xml.Item1.WriteElementString("FulfillService", FulfillService);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Requests a list of UOMs.
         * Syntax: <UOMRq />
         */
        public static String UOMRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "UOMRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Retrieves a vendor object. 
         * Note When currency rate is 0 then vendor is using the default currency rate
         * Syntax: <VendorGetRq>
	                       <Name>DB string</Name>
                   </VendorGetRq>
         */
        public static String VendorGetRq(String Key, String Name)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "VendorGetRq");

            if (Name != null)
                xml.Item1.WriteElementString("Name", Name);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Requests a list of all vendors.
         * Syntax: <VendorListRq />
        */
        public static String VendorListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "VendorListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: Requests a list of all vendor names.
         * Syntax: <VendorNameListRq />
        */
        public static String VendorNameListRq(String Key)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "VendorNameListRq");

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request is used to void shipments 
         * that are in a packed status or shipped status.
         * Syntax: <VoidShipmentRq>ShipNum<VoidShipmentRq>
         */
        public static String VoidShipmentRq(String Key, String ShipNum)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "VoidShipmentRq");

            if (ShipNum != null)
                xml.Item1.WriteString(ShipNum);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }

        /* Description: This request is used to void sales orders
         * Syntax: <VoidSORq>SO Number</VoidSORq>
         */
        public static String VoidSORq(String Key, String SONumber)
        {
            Tuple<XmlWriter, StringWriter> xml = FishbowlLegacy.BeginWriteXmlRq(Key, "VoidSORq");

            if (SONumber != null)
                xml.Item1.WriteString(SONumber);

            return FishbowlLegacy.EndWriteXmlRq(xml.Item1, xml.Item2);
        }
    }
}

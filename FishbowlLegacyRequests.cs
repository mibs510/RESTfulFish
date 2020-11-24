using System;
using System.Xml;
using System.Security.Cryptography;


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
            return "<FbiXml><Ticket><Key>" + Key + "</Key>" +
                "</Ticket><FbiMsgsRq><AddInventoryRq>" +
                "<PartNum>" + PartNum + "</PartNum>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<UOMID>" + UOMID + "</UOMID>" +
                "<Cost>" + Cost + "</Cost>" +
                "<Note>" + Note + "</Note>" +
                "<Tracking>" + TrackingObj + "</Tracking>" +
                "<LocationTagNum>" + LocationTagNum + "</LocationTagNum>" +
                "<TagNum>" + TagNum + "</TagNum>" +
                "</AddInventoryRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><AddMemoRq><ItemType>" + ItemType + "</ItemType>" +
                "<PartNum>" + PartNum + "</PartNum>" +
                "<ProductNum>" + ProductNum + "</ProductNum>" +
                "<OrderNum>" + OrderNum + "</OrderNum>" +
                "<CustomerNum>" + CustomerNum + "</CustomerNum>" +
                "<VendorNum>" + VendorNum + "</VendorNum>" +
                "<Memo>" + MemoObj + "</Memo>" +
                "</AddMemoRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Adds an item to a Sales Order.
         * Syntax: <AddSOItemRq>
	                        <OrderNum>string</OrderNum>
	                        <SalesOrderItem>Sales Order Item object</SalesOrderItem>
                   </AddSOItemRq>
        */
        public static String AddSOItemRq(String Key, String OrderNum, String SalesOrderItemObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><AddSOItemRq><OrderNum>" + OrderNum + "</OrderNum>" +
                "<SalesOrderItem>" + SalesOrderItemObj + "</SalesOrderItem>" +
                "</AddSOItemRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><AddWorkOrderItemRq><OrderNum>" + OrderNum + "</OrderNum>" +
                "<TypeId>" + TypeId + "</TypeId>" +
                "<Description>" + Description + "</Description>" +
                "<PartNum>" + PartNum + "</PartNum>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<UOMCode>" + UOMCode + "</UOMCode>" +
                "<Cost>" + Cost + "</Cost>" +
                "</AddWorkOrderItemRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><BuildBomRq><BomNumber>" + BomNumber + "</BomNumber>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<DateScheduled>" + DateScheduled + "</DateScheduled>" +
                "</BuildBomRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CalculateSORq><SalesOrder>" + SalesOrderObj + "</SalesOrder>" +
                "</CalculateSORq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns the names of every Carrier in your database.
         * Syntax: <CarrierListRq />
         */
        public static String CarrierListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CarrierListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request is used to close short a sales order
         * Syntax: <CloseShortSORq>SO Number</CloseShortSORq>
         */
        public static String CloseShortSORq(String Key, String SONumber)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CloseShortSORq><SONumber>" + SONumber + "</SONumber>" +
                "</CloseShortSORq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket><FbiMsgsRq>" +
                "<CustomerGetRq><Name>" + Name + "</Name></CustomerGetRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns a list of every Customer in your database with their details.
         * Syntax: <CustomerListRq />
         */
        public static String CustomerListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CustomerListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns a list of the names of all the customers in your database.
         * Syntax: <CustomerNameListRq />
         */
        public static String CustomerNameListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CustomerNameListRq /></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><CycleCountRq><PartNum>" + PartNum + "</PartNum>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<LocationID>" + LocationID + "</LocationID>" +
                "<Tracking>" + Tracking + "</Tracking>" +
                "</CycleCountRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><EmailReportRq><ReportName>" + ReportName + "</ReportName>" +
                "<ReportTree>" + ReportTree + "</ReportTree>" +
                "<Email>" + Email + "</Email>" +
                "<ParameterList><ReportParam>" +
                "<Name>" + Name + "</Name>" +
                "<Value>" + Value + "</Value>" +
                "</ReportParam></ParameterList>" +
                "</EmailReportRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns all available export options
         * Syntax: <ExportListRq />
         */
        public static String ExportListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ExportListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns export data of specified export type
         * Syntax: <ExportRq>
	                    <Type>DB string</Type>
                   </ExportRq>
        */
        public static String ExportRq(String Key, String Type)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ExportRq><Type>" + Type + "</Type></ExportRq></FbiMsgsRq></FbiXml>";
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
            System.Text.StringBuilder buffer = new System.Text.StringBuilder("<FbiXml><Ticket><Key>");
            buffer.Append(Key);
            buffer.Append("</Key></Ticket><FbiMsgsRq><ExecuteQueryRq>");
            
            if (Name != null )
            {
                buffer.Append("<Name>");
                buffer.Append(Name);
                buffer.Append("</Name>");
            }

            if (Query != null)
            {
                buffer.Append("<Query>");
                buffer.Append(Query);
                buffer.Append("</Query>");
            }

            buffer.Append("</ExecuteQueryRq></FbiMsgsRq></FbiXml>");

            return buffer.ToString();
        }

        /* Description: Returns a list of all QuickBooks accounts complete with IDs, types, and balances.
         * Syntax: <GetAccountListRq />
         */
        public static String GetAccountListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetAccountListRq /></FbiMsgsRq></FbiXml>";
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
         * Build a buffer to omit opening and closing tags with null parameters.
         */
        public static String GetPartListRq(String Key, String PartNum, String PartDesc, 
            String PartDetails, String PartUPC, String PartType, String ABCCode, 
            String VendorName, String VendorNum, String ProductNum, 
            String ProductDesc, String ActiveFlag, String ShowActive, 
            String ShowInactive, String HasBOM, String Configurable)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetPartListRq><PartNum>" + PartNum + "</PartNum>" +
                "<PartDesc>" + PartDesc + "</PartDesc>" +
                "<PartDetails>" + PartDetails + "</PartDetails>" +
                "<PartUPC>" + PartUPC + "</PartUPC>" +
                "<PartType>" + PartType + "</PartType>" +
                "<ABCCode>" + ABCCode + "</ABCCode>" +
                "<VendorName>" + VendorName + "</VendorName>" +
                "<VendorNum>" + VendorNum + "</VendorNum>" +
                "<ProductNum>" + ProductNum + "</ProductNum>" +
                "<ProductDesc>" + ProductDesc + "</ProductDesc>" +
                "<ActiveFlag>" + ActiveFlag + "</ActiveFlag>" +
                "<ShowActive>" + ShowActive + "</ShowActive>" +
                "<ShowInactive>" + ShowInactive + "</ShowInactive>" +
                "<HasBOM>" + HasBOM + "</HasBOM>" +
                "<Configurable>" + Configurable + "</Configurable>" +
                "</GetPartListRq></FbiMsgsRq></FbiXml>";
        }
        public static String GetPartListRq(String Key, String PartNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetPartListRq><PartNum>" + PartNum + "</PartNum>" +
                "</GetPartListRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request will return the information on a specified pick.
         * Syntax: <GetPickRq>
	                       <PickNum>DB string</PickNum>
                   </GetPickRq>
        */
        public static String GetPickRq(String Key, String PickNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetPickRq><PickNum>" + PickNum + "</PickNum>" +
                "</GetPickRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns all purchase order queued in the specified location.
         * Syntax: <GetPOListRq>
	                       <LocationGroup>DB string</LocationGroup>
                   </GetPOListRq>
        */
        public static String GetPOListRq(String Key, String LocationGroup)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetPOListRq><LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "</GetPOListRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetReceiptRq><OrderNumber>" + OrderNumber + "</OrderNumber>" +
                "<OrderType>" + OrderType + "</OrderType>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "</GetReceiptRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetShipListRq><StartRecord>" + StartRecord + "</StartRecord>" +
                "<RecordCount>" + RecordCount + "</RecordCount>" +
                "<OrderTypeID>" + OrderTypeID + "</OrderTypeID>" +
                "<StatusID>" + StatusID + "</StatusID>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "<Carrier>" + Carrier + "</Carrier>" +
                "</GetShipListRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns the shipment details about a specified shipment.
         * Syntax: <GetShipmentRq>
	                        <ShipmentID>int</ShipmentID>
	                        <ShipmentN
        */
        public static String GetShipmentRq(String Key, String ShipmentNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetShipmentRq><ShipmentNum>" + ShipmentNum + "</ShipmentNum>" +
                "</GetShipmentRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetShipNowListRq><LocationGroup>" + LocationGroup + "</LocationGroup>" +
                    "<Carrier><Name>" + Name + "</Name></Carrier></GetShipNowListRq></FbiMsgsRq></FbiXml>";
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
         * TODO: Determine why Grapevine does not like this function. GetSOListRq behaves outside of [Restresource].
         * Determine why it seems to return a statusCode of 1130 even if *almost* all parameters are passed valid
         * data.
         */
        public static String GetSOListRq(String Key, String SONum, String LocationGroup,
            String Status, String CustomerPO, String CustomerName,
            String AccountNumber, String BillTo, String ShipTo, String ProductNum,
            String ProductDesc, String ProductDetails, String Salesman,
            String type, String DateIssuedBegin, String DateIssuedEnd, String DateCreatedBegin,
            String DateCreatedEnd, String DateLasteModifiedBegin,
            String DateLasteModifiedEnd, String DateScheduledBegin,
            String DateScheduledEnd, String DateCompletedBegin, String DateCompletedEnd)
        {
            System.Text.StringBuilder buffer = new System.Text.StringBuilder("<FbiXml><Ticket><Key>");
            buffer.Append(Key);
            buffer.Append("</Key></Ticket><FbiMsgsRq><GetSOListRq>");
            if (SONum != null)
            {
                buffer.Append("<SONum>");
                buffer.Append(SONum);
                buffer.Append("</SONum>");
            }
            if (LocationGroup != null)
            {
                buffer.Append("<LocationGroup>");
                buffer.Append(LocationGroup);
                buffer.Append("</LocationGroup>");
            }
            if (Status != null)
            {
                buffer.Append("<Status>");
                buffer.Append(Status);
                buffer.Append("</Status>");
            }
            if (CustomerPO != null)
            {
                buffer.Append("<CustomerPO>");
                buffer.Append(CustomerPO);
                buffer.Append("</CustomerPO>");
            }
            if (CustomerName != null)
            {
                buffer.Append("<CustomerName>");
                buffer.Append(CustomerName);
                buffer.Append("</CustomerName>");
            }
            if (AccountNumber != null)
            {
                buffer.Append("<AccountNumber>");
                buffer.Append(AccountNumber);
                buffer.Append("</AccountNumber>");
            }
            if (BillTo != null)
            {
                buffer.Append("<BillTo>");
                buffer.Append(BillTo);
                buffer.Append("</BillTo>");
            }
            if (ShipTo != null)
            {
                buffer.Append("<ShipTo>");
                buffer.Append(ShipTo);
                buffer.Append("</ShipTo>");
            }
            if (ProductNum != null)
            {
                buffer.Append("<ProductNum>");
                buffer.Append(ProductNum);
                buffer.Append("</ProductNum>");
            }                
            if (ProductDesc != null)
            {
                buffer.Append("<ProductDesc>");
                buffer.Append(ProductDesc);
                buffer.Append("</ProductDesc>");
            }    
            if (ProductDetails != null)
            {
                buffer.Append("<ProductDetails>");
                buffer.Append(ProductDetails);
                buffer.Append("</ProductDetails>");
            }
            if (Salesman != null)
            {
                buffer.Append("<Salesman>");
                buffer.Append(Salesman);
                buffer.Append("</Salesman>");
            }
            if (type != null)
            {
                buffer.Append("<Type>");
                buffer.Append(type);
                buffer.Append("</Type>");
            }
            if (DateIssuedBegin != null)
            {
                buffer.Append("<DateIssuedBegin>");
                buffer.Append(DateIssuedBegin);
                buffer.Append("</DateIssuedBegin>");
            }
            if (DateIssuedEnd != null)
            {
                buffer.Append("<DateIssuedEnd>");
                buffer.Append(DateIssuedEnd);
                buffer.Append("</DateIssuedEnd>");
            }
            if (DateCreatedBegin != null)
            {
                buffer.Append("<DateCreatedBegin>");
                buffer.Append(DateCreatedBegin);
                buffer.Append("</DateCreatedBegin>");
            }
            if (DateCreatedEnd != null)
            {
                buffer.Append("<DateCreatedEnd>");
                buffer.Append(DateCreatedEnd);
                buffer.Append("</DateCreatedEnd>");
            }
            if (DateLasteModifiedBegin != null)
            {
                buffer.Append("<DateLasteModifiedBegin>");
                buffer.Append(DateLasteModifiedBegin);
                buffer.Append("</DateLasteModifiedBegin>");
            }
            if (DateLasteModifiedEnd != null)
            {
                buffer.Append("<DateLasteModifiedEnd>");
                buffer.Append(DateLasteModifiedEnd);
                buffer.Append("</DateLasteModifiedEnd>");
            }
            if (DateScheduledBegin != null)
            {
                buffer.Append("<DateScheduledBegin>");
                buffer.Append(DateScheduledBegin);
                buffer.Append("</DateScheduledBegin>");
            }
            if (DateScheduledEnd != null)
            {
                buffer.Append("<DateScheduledEnd>");
                buffer.Append(DateScheduledEnd);
                buffer.Append("</DateScheduledEnd>");
            }
            if (DateCompletedBegin != null)
            {
                buffer.Append("<DateCompletedBegin>");
                buffer.Append(DateCompletedBegin);
                buffer.Append("</DateCompletedBegin>");
            }
            if (DateCompletedEnd != null)
            {
                buffer.Append("<DateCompletedEnd>");
                buffer.Append(DateCompletedEnd);
                buffer.Append("</DateCompletedEnd>");
            }
                
            buffer.Append("</GetSOListRq></FbiMsgsRq></FbiXml>");
            return buffer.ToString();
        }

        /* Description: Returns the total number of the inquired item at a specific location.
         * Syntax: <GetTotalInventoryRq>
	                        <PartNumber>string</PartNumber>
	                        <LocationGroup>DB string</LocationGroup>
                   </GetTotalInventoryRq>
        */
        public static String GetTotalInventoryRq(String Key, String PartNumber, String LocationGroup)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><GetTotalInventoryRq>" +
                "<PartNumber>" + PartNumber + "</PartNumber>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "</GetTotalInventoryRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request returns a list of your import options.
         * Syntax: <ImportListRq />
         */
        public static String ImportListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ImportListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request allows you to import data. 
         * The example uses the import to edit/add a vendor. 
         * Data columns can be blank, but each data column must be represented in the request. 
         * It is best practice to always include the header rows when importing data.
         * Syntax: <ImportRq>
	                    <Type>DB string</Type>
	                    <Rows>
		                    <Row>Data for each column required by the type</Row>
	                    </Rows>
                   </ImportRq>
        * TODO: Reimplement Row as a string array so that the web app do not have to 
        * recall this request for each row, if there is more than one to be imported.
        */
        public static String ImportRq(String Key, String type, String HeaderRow, String Row)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ImportRq><Type>" + type + "</Type>" +
                "<Rows><Row>" + HeaderRow + "</Row>" +
                "<Row>" + Row + "</Row></Rows>" +
                "</ImportRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request allows you to get the headers of an import. 
         * The example retrieves the import headers of the Add Inventory import.
         * Syntax: <ImportHeaderRq>
	                        <Type>ImportAddInventory</Type>
                   </ImportHeaderRq>
        */
        public static String ImportHeaderRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ImportHeaderRq><Type>ImportAddInventory</Type>" +
                "</ImportHeaderRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><InvQtyRq><PartNum>" + PartNum + "</PartNum>" +
                "<LastModifiedFrom>" + LastModifiedFrom + "</LastModifiedFrom>" +
                "<LastModifiedTo>" + LastModifiedTo + "</LastModifiedTo>" +
                "</InvQtyRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Will issue a SalesOrder.
         * Syntax: <IssueSORq>
	                    <SONumber>string</SONumber>
                   </IssueSORq>
        */
        public static String IssueSORq(String Key, String SONumber)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><IssueSORq><SONumber>" + SONumber + "</SONumber>" +
                "</IssueSORq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns a simple list of parts.
         * Syntax: <LightPartListRq />
         */
        public static String LightPartListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><LightPartListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: This will return information about the specified sales order.
         * Syntax: <LoadSORq>
	                    <Number>string</Number>
                   </LoadSORq>
        */
        public static String LoadSORq(String Key, String Number)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><LoadSORq><Number>" + Number + "</Number>" +
                "</LoadSORq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns a list of locations and their details.
         * Syntax: <LocationListRq />
         */
        public static String LocationListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><LocationListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns information on a Location.
         * Syntax: <LocationQueryRq>
	                        <LocationID>DB int</LocationID>
	                        <TagNum>int</TagNum>
                   </LocationQueryRq>
        */
        public static String LocationQueryRq(String Key, String LocationID, String TagNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><LocationQueryRq>" +
                "<LocationID>" + LocationID + "</LocationID>" +
                "<TagNum>" + TagNum + "</TagNum>" +
                "</LocationQueryRq></FbiMsgsRq></FbiXml>";
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

            return "<FbiXml><Ticket/><FbiMsgsRq><LoginRq>" +
                "<IAID>" + IAID + "</IAID>" +
                "<IAName>" + IAName + "</IAName>" +
                "<IADescription>" + IADescription + "</IADescription>" +
                "<UserName>" + UserName + "</UserName>" +
                "<UserPassword>" + encryptedUserPassword + "</UserPassword>" +
                "</LoginRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Makes a payment on the specified order.
         * Syntax: <MakePaymentRq>
	                        <Payment>Payment object</Payment>
                   </MakePaymentRq>
        */
        public static String MakePaymentRq(String Key, String PaymentObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><MakePaymentRq><Payment>" + PaymentObj + "</Payment>" +
                "</MakePaymentRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><MoveRq><SourceLocation><Location>" + SourceLocationObj + "</Location>" +
                "</SourceLocation><Part>" + PartObj + "</Part>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<Note>" + Note + "</Note><" +
                "Tracking>" + TrackingObj + "</Tracking>" +
                "<DestinationLocation>" +
                "<Location>" + DestinationLocationObj + "</Location>" +
                "</DestinationLocation>" +
                "</MoveRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Use this request to obtain the average cost at which you've previously 
         * bought this Part.
         * Syntax: <PartCostRq>
	                        <PartNum>string</PartNum>
                   </PartCostRq>
        */
        public static String PartCostRq(String Key, String PartNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><PartCostRq><PartNum>" + PartNum + "</PartNum>" +
                "</PartCostRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Returns all the information pertaining to a specified Part at your default location.
         * Syntax: <PartGetRq>
	                       <Number>string</Number>
	                       <GetImage>boolean</GetImage>
                   </PartGetRq>
        */
        public static String PartGetRq(String Key, String Number, String GetImage)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><PartGetRq><Number>" + Number + "</Number>" +
                "<GetImage>" + GetImage + "</GetImage>" +
                "</PartGetRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><PartQueryRq><PartNum>" + PartNum + "</PartNum>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "</PartQueryRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request will return all the picks that you specify. 
         * You can refine your results by its place in the index 
         * (StartIndex in conjunction with RecordCount), pick number, 
         * order number, pick type, status, priority, the first date to include, 
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><PickQueryRq><StartIndex>" + StartIndex + "</StartIndex>" +
                "<RecordCount>" + RecordCount + "</RecordCount>" +
                "<PickNum>" + PickNum + "</PickNum>" +
                "<OrderNum>" + OrderNum + "</OrderNum>" +
                "<PickType>" + PickType + "</PickType>" +
                "<Status>" + Status + "</Status>" +
                "<Priority>" + Priority + "</Priority>" +
                "<StartDate>" + StartDate + "</StartDate>" +
                "<EndDate>" + EndDate + "</EndDate>" +
                "<Fulfillable>" + Fulfillable + "</Fulfillable>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "</PickQueryRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><PrintReportRq><ModuleName>" + ModuleName + "</ModuleName>" +
                "<ParameterList><ReportParam><Name>" + Name + "</Name>" +
                "<Value>" + Value + "</Value>" +
                "</ReportParam></ParameterList></PrintReportRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ProductGetRq><Number>" + Number + "</Number>" +
                "<GetImage>" + GetImage + "</GetImage>" +
                "</ProductGetRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ProductPriceRq><ProductNumber>" + ProductNumber + "</ProductNumber>" +
                "<CustomerName>" + CustomerName + "</CustomerName>" +
                "<Quantity>" + Quantity + "</Quantity>" +
                "<Date>" + Date + "</Date>" +
                "</ProductPriceRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><QuickShipRq><SONumber>" + SONumber + "</SONumber>" +
                "<FulfillServiceItems>" + FulfillServiceItems + "</FulfillServiceItems>" +
                "<LocationGroup>" + LocationGroup + "</LocationGroup>" +
                "<ErrorIfNotFulfilled>" + ErrorIfNotFulfilled + "</ErrorIfNotFulfilled>" +
                "<ShipDate>" + ShipDate + "</ShipDate>" +
                "</QuickShipRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key>" +
                "</Ticket><FbiMsgsRq><ReceivingListRq>" +
                "<OrderNumber>" + OrderNumber + "</OrderNumber>" +
                "<OrderType>" + OrderType + "</OrderType>" +
                "<ReceiptStatus>" + ReceiptStatus + "</ReceiptStatus>" +
                "<StartRecord>" + StartRecord + "</StartRecord>" +
                "<RecordCount>" + RecordCount + "</RecordCount>" +
                "<DateIssuedBegin>" + DateIssuedBegin + "</DateIssuedBegin>" +
                "<DateIssuedEnd>" + DateIssuedEnd + "</DateIssuedEnd>" +
                "<DateFulfilledBegin>" + DateFulfilledBegin + "</DateFulfilledBegin>" +
                "<DateFulfilledEnd>" + DateFulfilledEnd + "</DateFulfilledEnd>" +
                "<DateReceivedBegin>" + DateReceivedBegin + "</DateReceivedBegin>" +
                "<DateReceivedEnd>" + DateReceivedEnd + "</DateReceivedEnd>" +
                "<DateReconciledBegin>" + DateReconciledBegin + "</DateReconciledBegin>" +
                "<DateReconciledEnd>" + DateReconciledEnd + "</DateReconciledEnd>" +
                "<PartNum>" + PartNum + "</PartNum>" +
                "<PartDesc>" + PartDesc + "</PartDesc>" +
                "<LocationGroupID>" + LocationGroupID + "</LocationGroupID>" +
                "<RMANum>" + RMANum + "</RMANum>" +
                "<VendorName>" + VendorName + "</VendorName>" +
                "</ReceivingListRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Saves and updates discounts
         * Syntax: <SaveDiscountRq>
	                        <Discount>Discount object</Discount>
                   </SaveDiscountRq>
        */
        public static String SaveDiscountRq(String Key, String DiscountObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveDiscountRq><Discount>" + DiscountObj + "</Discount>" +
                "</SaveDiscountRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Saves an image to the associated object.
         * Syntax: <SaveImageRq>
	                        <Type>string</Type>
	                        <Number>string</Number>
	                        <Image>string</Image>
	                        <UpdateAssociations>boolean</UpdateAssociations>
                   </SaveImageRq>
        */
        public static String SaveImageRq(String Key, String type, String Number, 
            String Image, String UpdateAssociations)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveImageRq><Type>" + type + "</Type>" +
                "<Number>" + Number + "</Number>" +
                "<Image>" + Image + "</Image>" +
                "<UpdateAssociations>" + UpdateAssociations + "</UpdateAssociations>" +
                "</SaveImageRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request enables you to make changes to and fulfill picks.
         * Syntax: <SavePickRq>
	                    <Pick>Pick object</Pick>
                   </SavePickRq>
        */
        public static String SavePickRq(String Key, String PickObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SavePickRq><Pick>" + PickObj + "</Pick>" +
                "</SavePickRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Updates receipt stored data.
         * Syntax: <SaveReceiptRq>
	                        <Receipt>Receipt object</Receipt>
                   </SaveReceiptRq>
        */
        public static String SaveReceiptRq(String Key, String ReceiptObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveReceiptRq><Receipt>" + ReceiptObj + "</Receipt>" +
                "</SaveReceiptRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Saves the report data. (Must restart client to view changes)
         * Syntax: <SaveReportRq>
	                    <ReportTree>DB String</ReportTree>
	                    <Report>Report object</Report>
                   </SaveReportRq>
        */
        public static String SaveReportRq(String Key, String ReportTree, String ReportObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveReportRq><ReportTree>" + ReportTree + "</ReportTree>" +
                "<Report>" + ReportObj + "</Report>" +
                "</SaveReportRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Saves the shipment data.
         * Syntax: <SaveShipmentRq>
	                        <Shipping>Shipping object</Shipping>>
                   </SaveShipmentRq>
        */
        public static String SaveShipmentRq(String Key, String ShippingObj)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveShipmentRq><Shipping>" + ShippingObj + "</Shipping>" +
                "</SaveShipmentRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveUPCRq><PartNum>" + PartNum + "</PartNum>" +
                "<UPC>" + UPC + "</UPC>" +
                "<UpdateProducts>" + UpdateProducts + "</UpdateProducts>" +
                "</SaveUPCRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SetDefPartLocRq><PartNum>" + PartNum + "</PartNum>" +
                "<Location>" + LocationObj + "</Location>" +
                "</SetDefPartLocRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><SaveTaxRateRq><TaxRate>" + TaxRateObj + "</TaxRate>" +
                "</SaveTaxRateRq></FbiMsgsRq></FbiXml>";
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
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><ShipRq><ShipNum>" + ShipNum + "</ShipNum>" +
                "<ShipDate>" + ShipDate + "</ShipDate>" +
                "<FulfillService>" + FulfillService + "</FulfillService>" +
                "</ShipRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Requests a list of UOMs.
         * Syntax: <UOMRq />
         */
        public static String UOMRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key>" +
                "</Ticket><FbiMsgsRq><UOMRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: Retrieves a vendor object. 
         * Note When currency rate is 0 then vendor is using the default currency rate
         * Syntax: <VendorGetRq>
	                       <Name>DB string</Name>
                   </VendorGetRq>
         */
        public static String VendorGetRq(String Key, String Name)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><VendorGetRq><Name>" + Name + "</Name>" +
                "</VendorGetRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: Requests a list of all vendors.
         * Syntax: <VendorListRq />
        */
        public static String VendorListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key>" +
                "</Ticket><FbiMsgsRq><VendorListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: Requests a list of all vendor names.
         * Syntax: <VendorNameListRq />
        */
        public static String VendorNameListRq(String Key)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key>" +
                "</Ticket><FbiMsgsRq><VendorNameListRq /></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request is used to void shipments 
         * that are in a packed status or shipped status.
         * Syntax: <VoidShipmentRq>ShipNum<VoidShipmentRq>
         */
        public static String VoidShipmentRq(String Key, String ShipNum)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><VoidShipmentRq><ShipNum>" + ShipNum + "</ShipNum>" +
                "</VoidShipmentRq></FbiMsgsRq></FbiXml>";
        }

        /* Description: This request is used to void sales orders
         * Syntax: <VoidSORq>SO Number</VoidSORq>
         */
        public static String VoidSORq(String Key, String SONumber)
        {
            return "<FbiXml><Ticket><Key>" + Key + "</Key></Ticket>" +
                "<FbiMsgsRq><VoidSORq><SONumber>" + SONumber + "</SONumber>" +
                "</VoidSORq></FbiMsgsRq></FbiXml>";
        }
    }
}

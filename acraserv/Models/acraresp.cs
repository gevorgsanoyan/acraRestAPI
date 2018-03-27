using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;


using System.Data.Entity.Validation;

namespace acraserv.Models
{
    public class acraresp
    {
        public string reqId { get; set; }
        public string respMsg { get; set; }

    }


    public static class AnyInstruments
    {
        public static DateTime AcrStrToDateTime(string Val)
        {
            DateTime rtD = new DateTime(1800, 1, 1);
            int d = 0;
            int m = 0;
            int y = 0;


            try
            {
                d = StringToInt(Val.Substring(0, 2));
                m = StringToInt(Val.Substring(3, 2));
                y = StringToInt(Val.Substring(6, 4));
                rtD = new DateTime(y, m, d);
            }
            catch
            {
                rtD = new DateTime(1800, 1, 1);
            }
            return rtD;

        }
        public static DateTime AcrStrToDateTimeRev(string Val)
        {
            DateTime rtD = new DateTime(1800, 1, 1);
            int d = 0;
            int m = 0;
            int y = 0;


            try
            {
                d = StringToInt(Val.Substring(8, 2));
                m = StringToInt(Val.Substring(5, 2));
                y = StringToInt(Val.Substring(0, 4));
                rtD = new DateTime(y, m, d);
            }
            catch
            {
                rtD = new DateTime(1800, 1, 1);
            }
            return rtD;

        }
        public static DateTime StringToDateTime(string Val)
        {
            int d = 0;
            int m = 0;
            int y = 0;
            DateTime rtD = new DateTime(1800, 1, 1);
            try
            {
                return Convert.ToDateTime(Val);
            }
            catch
            {
                if (Val.IndexOf("-") != -1)
                {
                    d = StringToInt(Val.Substring(0, 2));
                    m = StringToInt(Val.Substring(3, 2));
                    y = StringToInt(Val.Substring(6, 4));
                    try
                    {
                        rtD = new DateTime(y, m, d);
                    }
                    catch
                    {
                        return rtD;
                    }
                }//if (Val.IndexOf("-") == -1)

                if (Val.IndexOf("/^/") == -1)
                {
                    return rtD;
                }//if (Val.IndexOf("/^/") == -1)
                else
                {
                    try
                    {
                        return Convert.ToDateTime(Val.Substring(0, Val.IndexOf("/^/")));
                    }
                    catch
                    {
                        return rtD;
                    }//catch
                }//else if (Val.IndexOf("/^/") == -1)
            }//catch
        }//public static DateTime StringToDateTime(string Val)
        public static int StringToInt(string Val)
        {
            try
            {
                return int.Parse(Val);
            }
            catch
            {
                return 0;
            }
        }//public int StringToInt(string Val)
        public static short StringToShort(string Val)
        {
            try
            {
                return short.Parse(Val);
            }
            catch
            {
                return 0;
            }
        }
        public static long StringToLong(string Val)
        {
            try
            {
                return long.Parse(Val);
            }
            catch
            {
                return 0;
            }
        }//public long StringToInt(string Val)

        public static float StringToFloat(string Val)
        {
            try
            {
                return float.Parse(Val);
            }
            catch
            {
                return 0;
            }
        }//public long StringToFloat(string Val)

        public static double StringToDouble(string Val)
        {
            try
            {
                return double.Parse(Val);
            }
            catch
            {
                return 0;
            }
        }//public double StringToInt(string Val)        

        public static string DayMonthToString0(string s)
        {
            return s.Length > 1 ? s : "0" + s;
        }//public static string DayMonthToString0(string s)

        public static long GetACRA_RecID_By_ClientID(long client_ID)
        {
            DataTable tbl;
            LUISDataTableAdapters.ACRA_ReqID_By_ClientIDTableAdapter aAdp = new LUISDataTableAdapters.ACRA_ReqID_By_ClientIDTableAdapter();
            tbl = aAdp.GetData(client_ID);
            if (tbl.Rows.Count > 0)
                return StringToLong(tbl.Rows[0][0].ToString());
            else
                return 0;
        }//public static long GetACRA_RecID_By_ClientID(long client_ID)

       

        
        public static int GetCurrIDByExchCode(string curr)
        {
            DataTable tbl;
            LUISDataTableAdapters.GetCurrIDByExchCodeTableAdapter cAdp = new LUISDataTableAdapters.GetCurrIDByExchCodeTableAdapter();
            tbl = cAdp.GetData(curr);
            return StringToInt(tbl.Rows[0][0].ToString());
        }//public static int GetCurrIDByExchCode(string curr)

        public static int CurrIDByExchCode(string exchCode)
        {
            DataTable tbl;
            LUISDataTableAdapters.CurrIDByExchCodeTableAdapter adp = new LUISDataTableAdapters.CurrIDByExchCodeTableAdapter();
            tbl = adp.GetData(exchCode);
            if (tbl.Rows.Count > 0)
                return StringToInt(tbl.Rows[0][0].ToString());
            else
                return 0;
        }//public static int CurrIDByExchCode(string exchCode)


        public static int GetACRA_CreditStatusIDByName(string status)
        {
            DataTable tbl;
            LUISDataTableAdapters.GetACRA_CreditStatusIDByNameTableAdapter lAdb = new LUISDataTableAdapters.GetACRA_CreditStatusIDByNameTableAdapter();
            tbl = lAdb.GetData(status);
            return StringToInt(tbl.Rows[0][0].ToString());
        }//public static int GetACRA_CreditStatusIDByName(string status)

        public static int GetACRA_CreditScopeIDByName(string scopeName)
        {
            DataTable tbl;
            LUISDataTableAdapters.GetACRACreditScopeIDByNameTableAdapter lAdb = new LUISDataTableAdapters.GetACRACreditScopeIDByNameTableAdapter();
            tbl = lAdb.GetData(scopeName);
            return StringToInt(tbl.Rows[0][0].ToString());
        }//public static int GetACRA_CreditScopeIDByName(string scopeName)

        public static long ClientIDFromHaytID(long hayt_ID)
        {
            DataTable tbl;
            LUISDataTableAdapters.ClientIDFromHaytIDTableAdapter adp = new LUISDataTableAdapters.ClientIDFromHaytIDTableAdapter();
            tbl = adp.GetData(hayt_ID);
            if (tbl.Rows.Count > 0)
                return StringToLong(tbl.Rows[0][0].ToString());
            else
                return 0;
        }//public static long ClinetIDFromHaytID(long hayt_ID)

       

        public static int GetLoanClassIDByName(string loanClass)
        {
            DataTable tbl;
            LUISDataTableAdapters.GetLoanClassIDByNameTableAdapter lAdb = new LUISDataTableAdapters.GetLoanClassIDByNameTableAdapter();
            tbl = lAdb.GetData(loanClass);
            return StringToInt(tbl.Rows[0][0].ToString());
        }//public static int GetLoanClassIDByName(string loanClass)


        public static string myDecode(string src)
        {
            Encoding srcCode = Encoding.Unicode;
            Encoding dstCode = Encoding.UTF32;

            byte[] srcb = srcCode.GetBytes(src);
            byte[] dstb = Encoding.Convert(srcCode, dstCode, srcb);
            char[] dstch = new char[dstCode.GetCharCount(dstb, 0, dstb.Length)];
            dstCode.GetChars(dstb, dstb.Length, 0, dstch, 0);
            string res = new string(dstch);
            return res;
        }//public static string myDecode(string srs)

        public static double Client_ACRA_Overdue(long client_ID)
        {
            LUISDataTableAdapters.Client_ACRA_OverdueTableAdapter adp = new LUISDataTableAdapters.Client_ACRA_OverdueTableAdapter();
            DataTable tbl = adp.GetData(client_ID);
            if (tbl.Rows.Count > 0)
                return StringToDouble(tbl.Rows[0][0].ToString());
            else
                return 0;
        }//public static double Client_ACRA_Overdue(long client_ID)

        public static int Client_ACRA_OverdueLoanClass(long client_ID)
        {
            LUISDataTableAdapters.Client_ACRA_OverdueLoanClassTableAdapter adp = new LUISDataTableAdapters.Client_ACRA_OverdueLoanClassTableAdapter();
            DataTable tbl = adp.GetData(client_ID);
            if (tbl.Rows.Count > 0)
                return StringToInt(tbl.Rows[0][0].ToString());
            else
                return 0;
        }//public static int Client_ACRA_OverdueLoanClass(long client_ID)

               
        public static long IsErrorInACRAData(long clinet_ID)
        {
            LUISDataTableAdapters.ACRA_DErrPassp_By_ClientIDTableAdapter adp = new LUISDataTableAdapters.ACRA_DErrPassp_By_ClientIDTableAdapter();
            DataTable tbl = adp.GetData(clinet_ID);
            if (tbl.Rows.Count > 0)
            {
                if (StringToInt(tbl.Rows[0]["passport"].ToString()) < 0)
                {
                    return StringToLong(tbl.Rows[0]["result_ID"].ToString());
                }//if (tbl.Rows[0]["passport"].ToString().IndexOf("/") > -1)
                else
                    return 0;
            }//if (tbl.Rows.Count > 0)
            else
                return 0;
        }//public static long IsErrorInACRAData(long clinet_ID)

        public static long ACRA_ReqIDBySocCard(string SocCard)
        {
            LUISDataTableAdapters.ACRA_ReqIDBySocCardTableAdapter reqAdp = new LUISDataTableAdapters.ACRA_ReqIDBySocCardTableAdapter();
            DataTable tbl = reqAdp.GetData(SocCard);

            if (tbl.Rows.Count > 0)
            {
                return StringToLong(tbl.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }

        }//public static long ACRA_ReqIDBySocCard(string SocCard)

               
        //----------------------- File downloading
        public static string ServerMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }//public static string ServerMapPath(string path)

        public static HttpResponse GetHttpResponse()
        {
            return HttpContext.Current.Response;
        }//public static HttpResponse GetHttpResponse()

        public static void DownLoadFileFromServer(string fileName)
        {
            //This is used to get Project Location.
            //string filePath = ServerMapPath(fileName);
            //This is used to get the current response.
            HttpResponse res = GetHttpResponse();
            res.Clear();
            res.AppendHeader("content-disposition", "attachment; filename=" + fileName);
            res.ContentType = "application/octet-stream";
            res.WriteFile(fileName);
            res.Flush();
            res.End();
        }//public static void DownLoadFileFromServer(string fileName)

        //------------------------End file downloading code
               

    }//class AnyInstruments


    public class ACRA_O_Participient
    {
        public string KindBorrower;
        public string TaxID;
        public string FirmName;
        public string RequestTarget;
        public string UsageRange;

        public ACRA_O_Participient()
        {
            KindBorrower = "<KindBorrower>2</KindBorrower>";
        }//public ACRA_O_Participient()

        public ACRA_O_Participient(string taxID, string firmName, int requestTarget, int usageRange)
        {
            KindBorrower = "<KindBorrower>2</KindBorrower>";
            TaxID = "<TaxID>" + taxID + "</TaxID>";
            FirmName = "<FirmName>[CDATA[" + firmName + "]]</FirmName>";
            RequestTarget = "<RequestTarget>" + requestTarget.ToString() + "</RequestTarget>";
            UsageRange = "<UsageRange>" + usageRange.ToString() + "</UsageRange>";
        }//public ACRA_O_Participient(string taxID, string firmName)

        public string P_ToString()
        {
            return KindBorrower + TaxID + FirmName + RequestTarget + UsageRange;
        }//string ToString()

    }//public class ACRA_O_Participient

    public class ACRA_P_Participient
    {
        public string KindBorrower;
        public string FirstName;
        public string LastName;
        public string DateofBirth;
        public string PassportNumber;
        public string SocCardNumber;
        public string RequestTarget;
        public string UsageRange;
        public string IdCardNumber;

        public ACRA_P_Participient()
        {
            KindBorrower = "<KindBorrower>1</KindBorrower>";
        }

        public ACRA_P_Participient(string firstName, string lastName, DateTime DOB, string passportNumber, string socCardNumber, int requestTarget, int usageRange)
        {
            string idcardnum = "";
            if (passportNumber[0] == '0')
            {
                idcardnum = passportNumber;
            }

            KindBorrower = "<KindBorrower>1</KindBorrower>";
            FirstName = "<FirstName><![CDATA[" + firstName + "]]></FirstName>";
            LastName = "<LastName><![CDATA[" + lastName + "]]></LastName>";
            DateofBirth = "<DateofBirth><![CDATA[" + AnyInstruments.DayMonthToString0(DOB.Day.ToString()) + "-" + AnyInstruments.DayMonthToString0(DOB.Month.ToString()) + "-" + DOB.Year.ToString() + "]]></DateofBirth>";
            PassportNumber = "<PassportNumber>" + passportNumber.Trim() + "</PassportNumber>";
            SocCardNumber = "<SocCardNumber>" + socCardNumber + "</SocCardNumber>";
            IdCardNumber = "<IdCardNumber>" + idcardnum.Trim() + "</IdCardNumber>";
            RequestTarget = "<RequestTarget>" + requestTarget.ToString() + "</RequestTarget>";
            UsageRange = "<UsageRange>" + usageRange.ToString() + "</UsageRange>";
        }

        public string P_ToString()
        {
            return KindBorrower + FirstName + LastName + DateofBirth + PassportNumber + SocCardNumber + IdCardNumber + RequestTarget + UsageRange;
        }//string ToString()
    }//public class ACRA_P_Participient 

    public class ACRA_Request
    {
        private string persons;
        private string organizations;

        private string ReqID;
        private string AppNumber;
        private string dt;
        private string SID;
        private string ReportType;

        public ACRA_Request(string rID, string appNumb, string sID)
        {
            persons = "<ROWDATA type=\"Bank_Application_LOAN_PP\">";
            organizations = "<ROWDATA type=\"Bank_Application_LOAN_JP\">";
            ReqID = "<ReqID><![CDATA[" + rID + "]]></ReqID>";
            AppNumber = "<AppNumber><![CDATA[" + appNumb + "]]></AppNumber>";
            dt = "<DateTime><![CDATA[" + DateTime.Now.ToString() + "]]></DateTime>";
            SID = "<SID><![CDATA[" + sID + "]]></SID>";
            ReportType = "<ReportType><![CDATA[01]]></ReportType>";
        }//public ACRA_Request() { 

        public void SetPerson(ACRA_P_Participient Participient)
        {
            persons += ReqID + AppNumber + dt + SID + ReportType;
            persons += "<Participient id=\"1\">" + Participient.P_ToString() + "</Participient>";
            persons += "</ROWDATA>";
        }//public void SetPersons()


        public void SetOrganization(ACRA_O_Participient Participient)
        {
            organizations += ReqID + AppNumber + dt + SID + ReportType;
            organizations += "<Participient id=\"1\">" + Participient.P_ToString() + "</Participient>";
            organizations += "</ROWDATA>";
        }//public void SetOrganization(ACRA_O_Participient[] Participient)

        public string GetPerson()
        {
            return persons;
        }//public string GetPerson()

        public string GetOrganization()
        {
            return organizations;
        }//public string GetOrganization()

    }//public class ACRA_Request


    public class ACRAResponseI
    {
        protected int bPos;
        protected int sStart;
        protected int sEnd;
        protected string tmpStr;
        protected string tmpStrC;

        public string FirstName;
        public string LastName;
        public string PassportNumber;
        public DateTime DateofBirth;
        public string SocCardNumber;
        public int ThePresenceData;
        public string AddressR;
        public string AddressC;
        public int Residence;


        public string PersonIncomeS;
        public DataTable PersonIncome;
        public DataTable TotalLoanLiabilities;
        public DataTable TotalGuaranteeLiabilities;
        public DataTable Loan;
        public DataTable CurrentOverdueLoan;
        public DataTable Guarantee;
        public DataTable CurrentOverdueGuarantee;
        public int SwitchisClassQuantity;
        public DateTime InformationReviewDate;
        public int TheWorstClassLoan;
        public int RequestQuantity30;
        public int RequestQuantity;
        public int DelayPaymentQuantity;
        public int DelayQuantity;
        public int TheWorsClassGuarantee;
        public int data_err;

        public ACRAResponseI(XmlDocument acraXML)
        {
            DataRow rw;
            

            PersonIncome = new DataTable();
            PersonIncome.Columns.Add("Employer", typeof(string));
            PersonIncome.Columns.Add("TotAvgIncome", typeof(double));
            PersonIncome.Columns.Add("currID", typeof(int));
            PersonIncome.Columns.Add("Updated", typeof(DateTime));

            TotalLoanLiabilities = new DataTable();
            TotalLoanLiabilities.Columns.Add("Amount", typeof(double));
            TotalLoanLiabilities.Columns.Add("currID", typeof(int));

            TotalGuaranteeLiabilities = new DataTable();
            TotalGuaranteeLiabilities.Columns.Add("Amount", typeof(double));
            TotalGuaranteeLiabilities.Columns.Add("currID", typeof(int));

            Loan = new DataTable();
            Loan.Columns.Add("CreditID", typeof(string));
            Loan.Columns.Add("SourceName", typeof(string));
            Loan.Columns.Add("Amount", typeof(double));
            Loan.Columns.Add("currID", typeof(int));
            Loan.Columns.Add("CreditingDate", typeof(DateTime));
            Loan.Columns.Add("CloseDate", typeof(DateTime));
            Loan.Columns.Add("Interest", typeof(float));
            Loan.Columns.Add("Balance", typeof(double));
            Loan.Columns.Add("LastPaymentDate", typeof(DateTime));
            Loan.Columns.Add("LoanClass", typeof(int));
            Loan.Columns.Add("DelayPaymentQuantity1_12", typeof(int));
            Loan.Columns.Add("DelayPaymentQuantity13_24", typeof(int));
            Loan.Columns.Add("DelayPaymentFrequency1_12", typeof(int));
            Loan.Columns.Add("DelayPaymentFrequency13_24", typeof(int));
            Loan.Columns.Add("CreditStatus", typeof(int));
            Loan.Columns.Add("ContractAmount", typeof(double));
            Loan.Columns.Add("CreditScope", typeof(int));
            Loan.Columns.Add("CreditUsePlace", typeof(int));
            Loan.Columns.Add("PersonCount", typeof(int));
            Loan.Columns.Add("GuarantorCount", typeof(int));
            Loan.Columns.Add("PledgeSubject", typeof(string));
            Loan.Columns.Add("CollateralNotes", typeof(string));
            Loan.Columns.Add("CollateralAmount", typeof(double));
            Loan.Columns.Add("CollateralCurrency", typeof(int));
            Loan.Columns.Add("PMT", typeof(int));

            CurrentOverdueLoan = new DataTable();
            CurrentOverdueLoan.Columns.Add("Amount", typeof(double));
            CurrentOverdueLoan.Columns.Add("currID", typeof(int));

            Guarantee = new DataTable();
            Guarantee.Columns.Add("CreditID", typeof(string));
            Guarantee.Columns.Add("SourceName", typeof(string));
            Guarantee.Columns.Add("Amount", typeof(double));
            Guarantee.Columns.Add("currID", typeof(int));
            Guarantee.Columns.Add("CreditingDate", typeof(DateTime));
            Guarantee.Columns.Add("CloseDate", typeof(DateTime));
            Guarantee.Columns.Add("Interest", typeof(decimal));
            Guarantee.Columns.Add("Balance", typeof(double));
            Guarantee.Columns.Add("LastPaymentDate", typeof(DateTime));
            Guarantee.Columns.Add("GuaranteeClass", typeof(int));
            Guarantee.Columns.Add("DelayPaymentQuantity1_12", typeof(int));
            Guarantee.Columns.Add("DelayPaymentQuantity13_24", typeof(int));
            Guarantee.Columns.Add("DelayPaymentFrequency1_12", typeof(int));
            Guarantee.Columns.Add("DelayPaymentFrequency13_24", typeof(int));
            Guarantee.Columns.Add("CreditStatus", typeof(int));
            Guarantee.Columns.Add("ContractAmount", typeof(double));
            Guarantee.Columns.Add("CreditScope", typeof(int));
            Guarantee.Columns.Add("CreditUsePlace", typeof(int));
            Guarantee.Columns.Add("PersonCount", typeof(int));
            Guarantee.Columns.Add("GuarantorCount", typeof(int));
            Guarantee.Columns.Add("PledgeSubject", typeof(string));
            Guarantee.Columns.Add("CollateralNotes", typeof(string));
            Guarantee.Columns.Add("CollateralAmount", typeof(double));
            Guarantee.Columns.Add("CollateralCurrency", typeof(int));
            Guarantee.Columns.Add("PMT", typeof(int));

            CurrentOverdueGuarantee = new DataTable();
            CurrentOverdueGuarantee.Columns.Add("Amount", typeof(double));
            CurrentOverdueGuarantee.Columns.Add("currID", typeof(int));

            FirstName = acraXML.GetElementsByTagName("FirstName").Item(0).InnerText;
            LastName = acraXML.GetElementsByTagName("LastName").Item(0).InnerText;
            PassportNumber = acraXML.GetElementsByTagName("PassportNumber").Item(0).InnerText;
            DateofBirth = AnyInstruments.StringToDateTime(acraXML.GetElementsByTagName("DateofBirth").Item(0).InnerText);
            SocCardNumber = acraXML.GetElementsByTagName("SocCardNumber").Item(0).InnerText;//.Substring(0,10);
            data_err = 0;
            if (SocCardNumber.IndexOf('^') > 0)
            {
                data_err = 1;
            }
            ThePresenceData = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("ThePresenceData").Item(0).InnerText);
            AddressR = ConvertACRA_Address(acraXML.GetElementsByTagName("Address").Item(0).InnerText, 1);
            AddressC = ConvertACRA_Address(acraXML.GetElementsByTagName("Address").Item(0).InnerText, 2);

            if (acraXML.GetElementsByTagName("Residence").Item(0).InnerText.Trim() == "Ռեզիդենտ")
            {
                Residence = 1;
            }//if (Residence.ToString() == "Ռեզիդենտ")
            else
            {
                Residence = 2;
            }//else if (value.ToString() == "Ռեզիդենտ")


            PersonIncomeS = acraXML.GetElementsByTagName("PersonIncome").Item(0).InnerText;


            
            rw = PersonIncome.NewRow();
            rw["Employer"] = PersonIncomeS;
            rw["TotAvgIncome"] = 0;
            rw["currID"] = 1;
            rw["Updated"] = DateTime.Now;
            PersonIncome.Rows.Add(rw);


            for (int i = 0; i < acraXML.GetElementsByTagName("TotalLoanLiabilities").Count; i++)
            {
                rw = TotalLoanLiabilities.NewRow();
                rw["Amount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("TotalLoanLiabilities").Item(i)["Amount"].InnerText);
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("TotalLoanLiabilities").Item(i)["Currency"].InnerText);
                TotalLoanLiabilities.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("TotalLoanLiabilities").Count; i++)

            for (int i = 0; i < acraXML.GetElementsByTagName("TotalGuaranteeLiabilities").Count; i++)
            {
                rw = TotalGuaranteeLiabilities.NewRow();
                rw["Amount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("TotalGuaranteeLiabilities").Item(i)["Amount"].InnerText);
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("TotalGuaranteeLiabilities").Item(i)["Currency"].InnerText);
                TotalGuaranteeLiabilities.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("TotalGuaranteeLiabilities").Count; i++)


            for (int i = 0; i < acraXML.GetElementsByTagName("Loan").Count; i++)
            {
                rw = Loan.NewRow();
                rw["CreditID"] = acraXML.GetElementsByTagName("Loan").Item(i)["CreditID"].InnerText;
                rw["SourceName"] = acraXML.GetElementsByTagName("Loan").Item(i)["SourceName"].InnerText;
                rw["Amount"] = acraXML.GetElementsByTagName("Loan").Item(i)["Amount"].InnerText;
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("Loan").Item(i)["Currency"].InnerText);
                rw["CreditingDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Loan").Item(i)["CreditingDate"].InnerText);
                rw["CloseDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Loan").Item(i)["CloseDate"].InnerText);
                rw["Interest"] = AnyInstruments.StringToFloat(acraXML.GetElementsByTagName("Loan").Item(i)["Interest"].InnerText);
                rw["Balance"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Loan").Item(i)["Balance"].InnerText);
                rw["LastPaymentDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Loan").Item(i)["LoanLastPaymentDate"].InnerText);
                rw["LoanClass"] = AnyInstruments.GetLoanClassIDByName(acraXML.GetElementsByTagName("Loan").Item(i)["TheLoanClass"].InnerText.Trim());
                rw["DelayPaymentQuantity1_12"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["DelayPaymentQuantity1-12"].InnerText);
                rw["DelayPaymentQuantity13_24"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["DelayPaymentQuantity13-24"].InnerText);
                rw["DelayPaymentFrequency1_12"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["DelayPaymentFrequency1-12"].InnerText);
                rw["DelayPaymentFrequency13_24"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["DelayPaymentFrequency13-24"].InnerText);
                rw["CreditStatus"] = AnyInstruments.GetACRA_CreditStatusIDByName(acraXML.GetElementsByTagName("Loan").Item(i)["CreditStatus"].InnerText.Trim());
                rw["ContractAmount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Loan").Item(i)["ContractAmount"].InnerText);
                rw["CreditScope"] = AnyInstruments.GetACRA_CreditScopeIDByName(acraXML.GetElementsByTagName("Loan").Item(i)["CreditScope"].InnerText.Trim());
                rw["CreditUsePlace"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["CreditUsePlace"].InnerText);
                rw["PersonCount"] = 666;//--removed from ACRA 21.12.15---AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["PersonCount"].InnerText);
                rw["GuarantorCount"] = 666;//--removed from ACRA 21.12.15---AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Loan").Item(i)["GuarantorCount"].InnerText);
                rw["PledgeSubject"] = acraXML.GetElementsByTagName("Loan").Item(i)["PledgeSubject"].InnerText;
                rw["CollateralNotes"] = acraXML.GetElementsByTagName("Loan").Item(i)["CollateralNotes"].InnerText;
                rw["CollateralAmount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Loan").Item(i)["CollateralAmount"].InnerText);
                if (AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Loan").Item(i)["CollateralAmount"].InnerText) > 0)
                {
                    rw["CollateralCurrency"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("Loan").Item(i)["CollateralCurrency"].InnerText.Trim());
                }
                rw["PMT"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Loan").Item(i)["PMT"].InnerText);
                Loan.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("Loan").Count; i++)


            for (int i = 0; i < acraXML.GetElementsByTagName("CurrentOverdueLoan").Count; i++)
            {
                rw = CurrentOverdueLoan.NewRow();
                rw["Amount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("CurrentOverdueLoan").Item(i)["Amount"].InnerText);
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("CurrentOverdueLoan").Item(i)["Currency"].InnerText);
                CurrentOverdueLoan.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("CurrentOverdueLoan").Count; i++)


            for (int i = 0; i < acraXML.GetElementsByTagName("Guarantee").Count; i++)
            {
                rw = Guarantee.NewRow();
                rw["CreditID"] = acraXML.GetElementsByTagName("Guarantee").Item(i)["CreditID"].InnerText;
                rw["SourceName"] = acraXML.GetElementsByTagName("Guarantee").Item(i)["SourceName"].InnerText;
                rw["Amount"] = acraXML.GetElementsByTagName("Guarantee").Item(i)["Amount"].InnerText;
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("Guarantee").Item(i)["Currency"].InnerText);
                rw["CreditingDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Guarantee").Item(i)["CreditingDate"].InnerText);
                rw["CloseDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Guarantee").Item(i)["CloseDate"].InnerText);
                rw["Interest"] = AnyInstruments.StringToFloat(acraXML.GetElementsByTagName("Guarantee").Item(i)["Interest"].InnerText);
                rw["Balance"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Guarantee").Item(i)["Balance"].InnerText);
                if (acraXML.GetElementsByTagName("Guarantee").Item(i)["GuaranteeLastPaymentDate"].InnerText.Length > 0)
                {
                    rw["LastPaymentDate"] = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("Guarantee").Item(i)["GuaranteeLastPaymentDate"].InnerText);
                }//
                rw["GuaranteeClass"] = AnyInstruments.GetLoanClassIDByName(acraXML.GetElementsByTagName("Guarantee").Item(i)["TheGuaranteeClass"].InnerText.Trim());
                rw["DelayPaymentQuantity1_12"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["DelayPaymentQuantity1-12"].InnerText);
                rw["DelayPaymentQuantity13_24"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["DelayPaymentQuantity13-24"].InnerText);
                rw["DelayPaymentFrequency1_12"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["DelayPaymentFrequency1-12"].InnerText);
                rw["DelayPaymentFrequency13_24"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["DelayPaymentFrequency13-24"].InnerText);
                rw["CreditStatus"] = AnyInstruments.GetACRA_CreditStatusIDByName(acraXML.GetElementsByTagName("Guarantee").Item(i)["CreditStatus"].InnerText.Trim());
                rw["ContractAmount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Guarantee").Item(i)["ContractAmount"].InnerText);
                rw["CreditScope"] = AnyInstruments.GetACRA_CreditScopeIDByName(acraXML.GetElementsByTagName("Guarantee").Item(i)["CreditScope"].InnerText.Trim());
                rw["CreditUsePlace"] = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["CreditUsePlace"].InnerText);
                rw["PersonCount"] = 666;//--removed from ACRA 21.12.15---AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["PersonCount"].InnerText);
                rw["GuarantorCount"] = 666;//--removed from ACRA 21.12.15---AnyInstruments.StringToInt(acraXML.GetElementsByTagName("Guarantee").Item(i)["GuarantorCount"].InnerText);
                rw["PledgeSubject"] = acraXML.GetElementsByTagName("Guarantee").Item(i)["PledgeSubject"].InnerText;
                rw["CollateralNotes"] = acraXML.GetElementsByTagName("Guarantee").Item(i)["CollateralNotes"].InnerText;
                rw["CollateralAmount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Guarantee").Item(i)["CollateralAmount"].InnerText);
                if (AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Guarantee").Item(i)["CollateralAmount"].InnerText) > 0)
                {
                    rw["CollateralCurrency"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("Guarantee").Item(i)["CollateralCurrency"].InnerText.Trim());
                }
                rw["PMT"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("Guarantee").Item(i)["PMT"].InnerText);
                Guarantee.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("Guarantee").Count; i++)

            for (int i = 0; i < acraXML.GetElementsByTagName("CurrentOverdueGuarantee").Count; i++)
            {
                rw = CurrentOverdueGuarantee.NewRow();
                rw["Amount"] = AnyInstruments.StringToDouble(acraXML.GetElementsByTagName("CurrentOverdueGuarantee").Item(i)["Amount"].InnerText);
                rw["currID"] = AnyInstruments.GetCurrIDByExchCode(acraXML.GetElementsByTagName("CurrentOverdueGuarantee").Item(i)["Currency"].InnerText);
                CurrentOverdueGuarantee.Rows.Add(rw);
            }//for (int i = 0; i < acraXML.GetElementsByTagName("CurrentOverdueGuarantee").Count; i++)


            SwitchisClassQuantity = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("SwitchisClassQuantity").Item(0).InnerText);
            InformationReviewDate = AnyInstruments.AcrStrToDateTime(acraXML.GetElementsByTagName("InformationReviewDate").Item(0).InnerText);
            try
            {
                TheWorstClassLoan = AnyInstruments.GetLoanClassIDByName(acraXML.GetElementsByTagName("TheWorstClassLoan").Item(0).InnerText);
            }
            catch
            {
                TheWorstClassLoan = 0;
            }
            RequestQuantity30 = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("RequestQuantity30").Item(0).InnerText);
            RequestQuantity = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("RequestQuantity").Item(0).InnerText);
            DelayPaymentQuantity = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("DelayPaymentQuantity").Item(0).InnerText);
            DelayQuantity = AnyInstruments.StringToInt(acraXML.GetElementsByTagName("DelayQuantity").Item(0).InnerText);
            try
            {
                TheWorsClassGuarantee = AnyInstruments.GetLoanClassIDByName(acraXML.GetElementsByTagName("TheWorsClassGuarantee").Item(0).InnerText);
            }
            catch
            {
                TheWorsClassGuarantee = 0;
            }

        }//public ACRAResponseI(XmlDocument acraXML)

        private void ACRAIncomeParse(string Pincome)
        {
            
            DataRow rw;
            
            rw = PersonIncome.NewRow();
            rw["Employer"] = "";
            rw["TotAvgIncome"] = 0;
            rw["currID"] = 1;
            
            rw["Updated"] = DateTime.Now;
            rw["Employer"] = 0;
            
            PersonIncome.Rows.Add(rw);
        }//private DataTable ACRAIncomeParse()

        private string ConvertACRA_Address(string addr, int addr_type)
        {
            int iStart;
            int iEnd;
            string retVal = "";

            if (addr_type == 1)
            {
                iStart = 0;
                iEnd = addr.IndexOf("/^/");
                if (iEnd > 0)
                {
                    retVal = addr.Substring(iStart, iEnd - iStart);
                }
                else
                {
                    retVal = addr;
                }
            }
            else
            {
                iStart = addr.IndexOf("/^/") + 3;
                iEnd = addr.Length - 1;
                if (iEnd > 0 && iStart >= 0)
                {
                    retVal = addr.Substring(iStart, iEnd - iStart);
                }//
                else
                {
                    retVal = "";
                }//
            } //if (addr_type == 1)

            return retVal;
        }//private string ConvertACRA_Address(string addr, int addr_type)
    }

    public class ACRARequestInput
    {

        private XmlDocument acraInfoXML = new XmlDocument();
        private Stream acraResp;
        public string req_ID;
        private long r_ID;
        private double avgIncome = 0;
        private ACRA_P_Participient part;

        protected LUISDataTableAdapters.ACRA_RequestsISelectTableAdapter acraAdp;
        protected LUISDataTableAdapters.ACRA_R_LoanSelectTableAdapter loanAdp;
        protected LUISDataTableAdapters.ACRA_R_TotalLiabilitiesSelectTableAdapter liabAdp;
        protected LUISDataTableAdapters.ACRA_R_CurrentOverdueSelectTableAdapter overdAdp;

        public ACRAResponseI q;
        public string Req_Err;
        public DateTime req_date;
        public long acra_res_code;
        public long client_ID;

        public ACRARequestInput()
        { }

        public ACRARequestInput(int user_ID, long hayt_ID, string firstName, string lastName, DateTime DOB, string passpNumb, string socCard, int RequestTarget, int UsageRange, int reqType, int isTest)
        {
            client_ID = AnyInstruments.ClientIDFromHaytID(hayt_ID);
            acraAdp = new LUISDataTableAdapters.ACRA_RequestsISelectTableAdapter();
            loanAdp = new LUISDataTableAdapters.ACRA_R_LoanSelectTableAdapter();
            liabAdp = new LUISDataTableAdapters.ACRA_R_TotalLiabilitiesSelectTableAdapter();
            overdAdp = new LUISDataTableAdapters.ACRA_R_CurrentOverdueSelectTableAdapter();

            part = new ACRA_P_Participient(firstName, lastName, DOB, passpNumb, socCard, RequestTarget, UsageRange);
            acraResp = ACRA_WebRequest.GetWebRequestS(user_ID, 1, part, null, hayt_ID.ToString(), reqType, isTest);

            acraInfoXML = new XmlDocument();
            acraInfoXML.Load(acraResp);

            req_ID = acraInfoXML.GetElementsByTagName("ReqID").Item(0).InnerText;
            acraInfoXML.Save(HttpContext.Current.Server.MapPath(@"~\ACRAXML\acra" + req_ID + ".xml"));
            try
            {
                Req_Err = acraInfoXML.GetElementsByTagName("Response").Item(0).InnerText;
            }
            catch
            {
                Req_Err = "Unknown ERROR! Please try again!";
                return;
            }

            if (acraInfoXML.GetElementsByTagName("ErrorDesc").Count > 0)
            {
                Req_Err = acraInfoXML.GetElementsByTagName("ErrorDesc").Item(0).InnerText;
            }//if (acraInfoXML.GetElementsByTagName("ErrorDesc").Count > 0)
            else
            {
                q = new ACRAResponseI(acraInfoXML);
                //Session.Add("acra_resp", ACRAResponseI);

                if (q.ThePresenceData == 1)
                {
                    for (int i = 0; i < q.PersonIncome.Rows.Count; i++)
                    {
                        avgIncome += AnyInstruments.StringToDouble(q.PersonIncome.Rows[0]["TotAvgIncome"].ToString());
                    }//for (int i = 0; i < q.PersonIncome.Rows.Count; i++)                    

                    string tempStr = q.SocCardNumber;
                    if ((tempStr.IndexOf('^') != -1) || (tempStr.Trim() == ""))
                    {
                        tempStr = socCard;
                    }
                    acraAdp.Insert(req_ID, DateTime.Now, 1, hayt_ID.ToString(), q.FirstName, q.LastName, q.DateofBirth, q.PassportNumber,
                        tempStr, 1, q.AddressR + '_' + q.AddressC, q.ThePresenceData, AnyInstruments.StringToInt(q.Residence.ToString()),
                        avgIncome, AnyInstruments.StringToDateTime(q.PersonIncome.Rows[0]["Updated"].ToString())
                        , q.PersonIncome.Rows[0]["Employer"].ToString(), q.RequestQuantity30,
                        q.RequestQuantity, q.DelayQuantity, q.DelayPaymentQuantity, null, null, null, null, null, q.TheWorsClassGuarantee);

                    r_ID = (long)acraAdp.GetACRA_RequestID(req_ID);

                    acra_res_code = AnyInstruments.IsErrorInACRAData(client_ID);

                    if (q.Loan.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.Loan.Rows.Count; i++)
                        {
                            loanAdp.Insert(r_ID, 1, q.Loan.Rows[i]["CreditID"].ToString(), q.Loan.Rows[i]["SourceName"].ToString(),
                                AnyInstruments.StringToDouble(q.Loan.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["currID"].ToString()), AnyInstruments.StringToDateTime(q.Loan.Rows[i]["CreditingDate"].ToString()),
                                AnyInstruments.StringToDateTime(q.Loan.Rows[i]["CloseDate"].ToString()), AnyInstruments.StringToDouble(q.Loan.Rows[i]["Interest"].ToString()),
                                AnyInstruments.StringToDouble(q.Loan.Rows[i]["Balance"].ToString()), AnyInstruments.StringToDateTime(q.Loan.Rows[i]["LastPaymentDate"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["LoanClass"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["DelayPaymentQuantity1_12"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["DelayPaymentQuantity13_24"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["DelayPaymentFrequency1_12"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["DelayPaymentFrequency13_24"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["CreditStatus"].ToString()),
                                AnyInstruments.StringToDouble(q.Loan.Rows[i]["ContractAmount"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["CreditScope"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["CreditUsePlace"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["PersonCount"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["GuarantorCount"].ToString()),
                                q.Loan.Rows[i]["PledgeSubject"].ToString(),
                                q.Loan.Rows[i]["CollateralNotes"].ToString(),
                                AnyInstruments.StringToDouble(q.Loan.Rows[i]["CollateralAmount"].ToString()),
                                AnyInstruments.StringToInt(q.Loan.Rows[i]["CollateralCurrency"].ToString()),
                                AnyInstruments.StringToDouble(q.Loan.Rows[i]["PMT"].ToString()));
                        }//for(int i = 0; i < q.Loan.Rows.Count; i++)
                    }//if (q.Loan.Rows.Count > 0)

                    if (q.Guarantee.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.Guarantee.Rows.Count; i++)
                        {
                            loanAdp.Insert(r_ID, 2, q.Guarantee.Rows[i]["CreditID"].ToString(), q.Guarantee.Rows[i]["SourceName"].ToString(),
                                AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["currID"].ToString()), AnyInstruments.StringToDateTime(q.Guarantee.Rows[i]["CreditingDate"].ToString()),
                                AnyInstruments.StringToDateTime(q.Guarantee.Rows[i]["CloseDate"].ToString()), AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["Interest"].ToString()),
                                AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["Balance"].ToString()), AnyInstruments.StringToDateTime(q.Guarantee.Rows[i]["LastPaymentDate"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["GuaranteeClass"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["DelayPaymentQuantity1_12"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["DelayPaymentQuantity13_24"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["DelayPaymentFrequency1_12"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["DelayPaymentFrequency13_24"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["CreditStatus"].ToString()),
                                AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["ContractAmount"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["CreditScope"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["CreditUsePlace"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["PersonCount"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["GuarantorCount"].ToString()),
                                q.Guarantee.Rows[i]["PledgeSubject"].ToString(),
                                q.Guarantee.Rows[i]["CollateralNotes"].ToString(),
                                AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["CollateralAmount"].ToString()),
                                AnyInstruments.StringToInt(q.Guarantee.Rows[i]["CollateralCurrency"].ToString()),
                                AnyInstruments.StringToDouble(q.Guarantee.Rows[i]["PMT"].ToString()));
                        }//for(int i = 0; i < q.Guarantee.Rows.Count; i++)
                    }//if (q.Guarantee.Rows.Count > 0)


                    if (q.CurrentOverdueLoan.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.CurrentOverdueLoan.Rows.Count; i++)
                        {
                            overdAdp.Insert(1, r_ID, AnyInstruments.StringToDouble(q.CurrentOverdueLoan.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.CurrentOverdueLoan.Rows[i]["currID"].ToString()));
                        }//for(int i = 0; i <q.CurrentOverdueLoan.Rows.Count;i++)

                    }//if(q.CurrentOverdueLoan.Rows.Count > 0)                            


                    if (q.CurrentOverdueGuarantee.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.CurrentOverdueGuarantee.Rows.Count; i++)
                        {
                            overdAdp.Insert(2, r_ID, AnyInstruments.StringToDouble(q.CurrentOverdueGuarantee.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.CurrentOverdueGuarantee.Rows[i]["currID"].ToString()));
                        }//for(int i = 0; i <q.CurrentOverdueGuarantee.Rows.Count;i++)
                    }//if(q.CurrentOverdueGuarantee.Rows.Count > 0)

                    if (q.TotalLoanLiabilities.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.TotalLoanLiabilities.Rows.Count; i++)
                        {
                            liabAdp.Insert(r_ID, 1, AnyInstruments.StringToDouble(q.TotalLoanLiabilities.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.TotalLoanLiabilities.Rows[i]["currID"].ToString()));
                        }//for(int i = 0; i<q.TotalLoanLiabilities.Rows.Count;i++)
                    }//if (q.TotalLoanLiabilities.Rows.Count > 0)

                    if (q.TotalGuaranteeLiabilities.Rows.Count > 0)
                    {
                        for (int i = 0; i < q.TotalGuaranteeLiabilities.Rows.Count; i++)
                        {
                            liabAdp.Insert(r_ID, 2, AnyInstruments.StringToDouble(q.TotalGuaranteeLiabilities.Rows[i]["Amount"].ToString()),
                                AnyInstruments.StringToInt(q.TotalGuaranteeLiabilities.Rows[i]["currID"].ToString()));
                        }//for(int i = 0; i<q.TotalLoanLiabilities.Rows.Count;i++)
                    }//if (q.TotalLoanLiabilities.Rows.Count > 0)


                }//if (q.ThePresenceData == 1)


            }//else  if (acraInfoXML.GetElementsByTagName("ErrorDesc").Count > 0)

            req_date = AnyInstruments.StringToDateTime(acraInfoXML.GetElementsByTagName("DateTime").Item(0).InnerText);
            ACRA_WebRequest.UpdateACRAReqStatus(AnyInstruments.StringToLong(req_ID), req_date, Req_Err, Req_Err);
        }//public ACRARequestInput(int user_ID, long hayt_ID, string firstName, string lastName, DateTime DOB,string passpNumb, string socCard)

        public double isOverdue()
        {
            return AnyInstruments.Client_ACRA_Overdue(client_ID);
        }


        public int ACRARequestInputNew(int user_ID, long hayt_ID, string firstName, string lastName, DateTime DOB, string passpNumb, string socCard, int RequestTarget, int UsageRange, int reqType, int isTest)
        {
            int rtVal = 0;

            string err = "0";


            part = new ACRA_P_Participient(firstName, lastName, DOB, passpNumb, socCard, RequestTarget, UsageRange);
            acraResp = ACRA_WebRequest.GetWebRequestS(user_ID, 1, part, null, hayt_ID.ToString(), reqType, isTest);

            acraInfoXML = new XmlDocument();
            acraInfoXML.Load(acraResp);

            req_ID = acraInfoXML.GetElementsByTagName("ReqID").Item(0).InnerText;
            acraInfoXML.Save(HttpContext.Current.Server.MapPath(@"~\ACRAXML\acra" + req_ID + ".xml"));
            try
            {
                Req_Err = acraInfoXML.GetElementsByTagName("Response").Item(0).InnerText;
            }
            catch
            {
                Req_Err = "Unknown ERROR! Please try again!";
                rtVal = -1;
                return rtVal;
            }

            if (acraInfoXML.GetElementsByTagName("ErrorDesc").Count > 0)
            {
                Req_Err = acraInfoXML.GetElementsByTagName("ErrorDesc").Item(0).InnerText;
                
                int dp = 0;
                try
                {
                    XmlNodeList ThePresenceData = acraInfoXML.GetElementsByTagName("ThePresenceData");
                    dp = int.Parse(ThePresenceData.Item(0).InnerText);
                    if (dp == 2)
                        Req_Err = "2#" + Req_Err;
                }                
                catch(Exception ex)
                {
                    Req_Err = ex.Message + " # " + Req_Err;
                }
            }
            else
            {
                newACRAEntities db = new acraserv.newACRAEntities();

                XmlNodeList ThePresenceData = acraInfoXML.GetElementsByTagName("ThePresenceData");

                XmlNodeList ReqID = acraInfoXML.GetElementsByTagName("ReqID");//bid_numb
                XmlNodeList AppNumber = acraInfoXML.GetElementsByTagName("AppNumber");//AppNumber
                XmlNodeList rDateTime = acraInfoXML.GetElementsByTagName("DateTime");//r_ans_date
                XmlNodeList ReportNumber = acraInfoXML.GetElementsByTagName("ReportNumber");//ReportNumber
                XmlNodeList FirstName = acraInfoXML.GetElementsByTagName("FirstName");//first_name
                XmlNodeList LastName = acraInfoXML.GetElementsByTagName("LastName");//last_name
                XmlNodeList PassportNumber = acraInfoXML.GetElementsByTagName("PassportNumber");//passport
                XmlNodeList IdCardNumber = acraInfoXML.GetElementsByTagName("IdCardNumber");//IdCardNumber
                XmlNodeList DateofBirth = acraInfoXML.GetElementsByTagName("DateofBirth");//DOB
                XmlNodeList SocCardNumber = acraInfoXML.GetElementsByTagName("SocCardNumber");//soc_card
                XmlNodeList Address = acraInfoXML.GetElementsByTagName("Address");//address
                XmlNodeList Residence = acraInfoXML.GetElementsByTagName("Residence");//residentity
                XmlNodeList PersonIncome = acraInfoXML.GetElementsByTagName("PersonIncome");//employer
                XmlNodeList PersonBankruptIncome = acraInfoXML.GetElementsByTagName("PersonBankruptIncome");//PersonBankruptIncome
                XmlNodeList SwitchisClassQuantity = acraInfoXML.GetElementsByTagName("SwitchisClassQuantity");//SwitchisClassQuantity
                XmlNodeList InformationReviewDate = acraInfoXML.GetElementsByTagName("InformationReviewDate");//InformationReviewDate
                XmlNodeList TheWorstClassLoan = acraInfoXML.GetElementsByTagName("TheWorstClassLoan");//TheWorstClassLoan
                XmlNodeList RequestQuantity30 = acraInfoXML.GetElementsByTagName("RequestQuantity30");//req30_count
                XmlNodeList RequestQuantity = acraInfoXML.GetElementsByTagName("RequestQuantity");//req_count
                XmlNodeList SelfEnquiryQuantity30 = acraInfoXML.GetElementsByTagName("SelfEnquiryQuantity30");//SelfEnquiryQuantity30
                XmlNodeList SelfEnquiryQuantity = acraInfoXML.GetElementsByTagName("SelfEnquiryQuantity");//SelfEnquiryQuantity
                XmlNodeList DelayPaymentQuantity = acraInfoXML.GetElementsByTagName("DelayPaymentQuantity");//DelayPaymentQuantity
                XmlNodeList DelayQuantity = acraInfoXML.GetElementsByTagName("DelayQuantity");//delay_tot
                XmlNodeList TheWorsClassGuarantee = acraInfoXML.GetElementsByTagName("TheWorsClassGuarantee");//TheWorsClassGuarantee



                //DB Input start ------------------------------------------------------------------------------------
                
                ACRA_RequestsI r = new ACRA_RequestsI();


                r.bid_numb = (ReqID.Item(0) != null) ? ReqID.Item(0).InnerText : "NoNode";
                r.AppNumber = (AppNumber.Item(0) != null) ? AppNumber.Item(0).InnerText : "NoNode";
                r.r_ans_date = (rDateTime.Item(0) != null) ? AnyInstruments.AcrStrToDateTime(rDateTime.Item(0).InnerText): new DateTime(1800,1,1);
                r.ReportNumber = (ReportNumber.Item(0) != null) ? ReportNumber.Item(0).InnerText : "NoNode";
                r.first_name = (FirstName.Item(0) != null) ? FirstName.Item(0).InnerText : "NoNode";
                r.last_name = (LastName.Item(0) != null) ? LastName.Item(0).InnerText : "NoNode";
                r.passport = (PassportNumber.Item(0) != null) ? (PassportNumber.Item(0).InnerText.Length > 9 ? PassportNumber.Item(0).InnerText.Substring(0,9): PassportNumber.Item(0).InnerText) : "NoNode";
                r.IdCardNumber = (IdCardNumber.Item(0) != null) ? IdCardNumber.Item(0).InnerText : "NoNode";
                r.DOB = (DateofBirth.Item(0) != null) ? AnyInstruments.AcrStrToDateTime(DateofBirth.Item(0).InnerText) : new DateTime(1800, 1, 1);
                r.soc_card = (SocCardNumber.Item(0) != null) ? SocCardNumber.Item(0).InnerText.TrimEnd() : "NoNode";
                r.address = (Address.Item(0) != null) ? (Address.Item(0).InnerText.Length > 500 ? Address.Item(0).InnerText.Substring(0,499) : Address.Item(0).InnerText ): "NoNode";
                r.residentity = (Residence.Item(0) != null) ? AnyInstruments.StringToInt(Residence.Item(0).InnerText.TrimEnd()) : 1;
                if (PersonIncome.Item(0) != null)
                {
                    if (PersonIncome.Item(0).InnerText.Length > 150)
                    {
                        int piLen = PersonIncome.Item(0).InnerText.Length;
                        r.employer = PersonIncome.Item(0).InnerText.Substring(piLen-150, 150);
                        int piDateInx = 0;
                        int piSalIndex = 0;
                        try
                        {
                            piSalIndex = r.employer.LastIndexOf("Salary:")+8;
                            piDateInx = r.employer.LastIndexOf("End:") + 5;
                            string piSal = r.employer.Substring(piSalIndex, 150 - piSalIndex - 4);
                            string piDate = r.employer.Substring(piDateInx, 150 - piSalIndex+1);
                            r.avrg_m_income = AnyInstruments.StringToDouble(piSal);
                            r.income_update_date = AnyInstruments.AcrStrToDateTimeRev(piDate);
                        }
                        catch(Exception piEx)
                        {
                            r.avrg_m_income = 0;
                            Req_Err = "Person income parsing error _ " + piEx.Message + "# " + Req_Err;
                        }
                        
                    }
                    else
                    {
                        r.employer = PersonIncome.Item(0).InnerText;
                    }//if(PersonIncome.Item(0).InnerText.Length > 150)
                    
                }
                else
                {
                    r.avrg_m_income = 0;
                    r.employer = "NoNode";
                }//if(PersonIncome.Item(0) != null)                
                r.PersonBankruptIncome = (PersonBankruptIncome.Item(0) != null) ? PersonBankruptIncome.Item(0).InnerText : "NoNode";
                r.SwitchisClassQuantity = (SwitchisClassQuantity.Item(0) != null) ? SwitchisClassQuantity.Item(0).InnerText : "NoNode";
                r.InformationReviewDate = (InformationReviewDate.Item(0) != null) ? InformationReviewDate.Item(0).InnerText : "NoNode";
                r.TheWorstClassLoan = (TheWorstClassLoan.Item(0) != null) ? TheWorstClassLoan.Item(0).InnerText : "NoNode";
                r.req30_count = (RequestQuantity30.Item(0) != null) ? AnyInstruments.StringToInt(RequestQuantity30.Item(0).InnerText.TrimEnd()) : -1;
                r.req_count = (RequestQuantity.Item(0) != null) ? AnyInstruments.StringToInt(RequestQuantity.Item(0).InnerText.TrimEnd()) : -1;
                r.SelfEnquiryQuantity30 = (SelfEnquiryQuantity30.Item(0) !=null) ? SelfEnquiryQuantity30.Item(0).InnerText : "NoNode";
                r.SelfEnquiryQuantity = (SelfEnquiryQuantity.Item(0) != null) ? SelfEnquiryQuantity.Item(0).InnerText : "NoNode";
                r.delay_tot = (DelayQuantity.Item(0) != null) ? AnyInstruments.StringToInt(DelayQuantity.Item(0).InnerText.TrimEnd()) : 1;
                r.TheWorsClassGuarantee = (TheWorsClassGuarantee.Item(0) != null) ? TheWorsClassGuarantee.Item(0).InnerText : "NoNode";
                r.DelayPaymentQuantity = (DelayPaymentQuantity.Item(0) != null) ? DelayPaymentQuantity.Item(0).InnerText : "NoNode";




                long resultId = 0;

                
                try
                {
                    db.ACRA_RequestsI.Add(r);
                    db.SaveChanges();
                    resultId = r.result_ID;
                }
                catch(DbEntityValidationException saveEx)
                {
                    
                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" +  ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                    return -1;
                }
                catch (Exception rex)
                {
                    Req_Err = "RequestI _ " + rex.Message + "# " + Req_Err;
                }


                //DB Input end --------------------------------------------------------------------------------------

                double Amount = 0;
                double AmountUSD = 0;
                int curId = 0;
                try
                {
                    XmlNodeList TotalLiabilities = acraInfoXML.GetElementsByTagName("TotalLiabilities");
                    for (int i = 0; i < TotalLiabilities.Count; i++)
                    {
                        XmlNode tn = TotalLiabilities.Item(i);
                        curId = AnyInstruments.GetCurrIDByExchCode(tn.ChildNodes.Item(1).InnerText);
                        Amount = AnyInstruments.StringToDouble(tn.ChildNodes.Item(0).InnerText);

                        //DB Input start ------------------------------------------------------------------------------------
                        if(resultId > 0)
                        {
                            ACRA_R_TotalLiabilities tl = new ACRA_R_TotalLiabilities();
                            tl.fk_result_ID = resultId;
                            tl.l_type = 1;
                            tl.currID = curId;
                            tl.Amount = Amount;

                            db.ACRA_R_TotalLiabilities.Add(tl);
                            db.SaveChanges();
                        }                        
                        //DB Input end --------------------------------------------------------------------------------------

                    }
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception lex)
                {
                    Req_Err += "TotalLiabilities _ " + lex.Message + "# " + Req_Err;
                }
                
                Amount = 0;
                AmountUSD = 0;
                curId = 0;
                try
                {
                    XmlNodeList TotalGuaranteeLiabilities = acraInfoXML.GetElementsByTagName("TotalGuaranteeLiabilities");
                    for (int i = 0; i < TotalGuaranteeLiabilities.Count; i++)
                    {
                        XmlNode tn = TotalGuaranteeLiabilities.Item(i);
                        curId = AnyInstruments.GetCurrIDByExchCode(tn.ChildNodes.Item(1).InnerText);
                        Amount = AnyInstruments.StringToDouble(tn.ChildNodes.Item(0).InnerText);

                        //DB Input start ------------------------------------------------------------------------------------
                        if (resultId > 0)
                        {
                            ACRA_R_TotalLiabilities tl = new ACRA_R_TotalLiabilities();
                            tl.fk_result_ID = resultId;
                            tl.l_type = 2;
                            tl.currID = curId;
                            tl.Amount = Amount;

                            db.ACRA_R_TotalLiabilities.Add(tl);
                            db.SaveChanges();
                        }
                        //DB Input end --------------------------------------------------------------------------------------
                    }
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception lex)
                {
                    Req_Err = "TotalGuaranteeLiabilities _ " + lex.Message + "# " + Req_Err;
                }
                
                Amount = 0;
                AmountUSD = 0;
                curId = 0;

                long savedLoanId = 0;

                DateTime? vIncomingDate = null;//new
                double vAmountOverdue = 0;//new
                DateTime? vCreditStart = null;//new
                DateTime? vOutstandingDate = null;//new
                int vOverdueDays = 0;//new
                float vOutstandingPercent = 0;//new
                double vPaymentAmount = 0;//new
                DateTime? vClassificationLastDate = null; //new
                string vCreditNotes = "";//new
                int vProlongationsNum = 0; //new
                int sumOutstandingDaysCount = 0;//new
                string vCreditType = "";//new

                string vCreditID = "";
                string vSourceName = "";
                DateTime? vCreditingDate = null;
                DateTime? vCloseDate = null;
                float vInterest = 0;
                double vBalance = 0;
                DateTime? vLoanLastPaymentDate = null;
                int vLoanClass = 0;
                int vDelayPaymentQuantity1_12 = 0;
                int vDelayPaymentQuantity13_24 = 0;
                int vDelayPaymentFrequency1_12 = 0;
                int vDelayPaymentFrequency13_24 = 0;                
                int vCreditStatus = 0;
                double vCreditAmount = 0;//ContractAmount?
                int vCreditScope = 0;
                int vCreditUsePlaceOld = 0;
                string vCreditUsePlace = "";
                string vPledgeSubject = "";
                string vCollateralNotes = "";
                double vCollateralAmount = 0;
                int vCollateralCurrency = 0;
                double vPMT = 0;
                string vCreditScopeText = "";

                string nodeName = "";

                try
                {
                    XmlNodeList Loan = acraInfoXML.GetElementsByTagName("Loan");
                    for(int l=0; l < Loan.Count;l++)
                    {
                        XmlNode lnode = Loan.Item(l);
                        XmlNode OutstandingDaysCount = null;

                        for (int n=0; n < lnode.ChildNodes.Count; n++)
                        {
                            nodeName = lnode.ChildNodes.Item(n).Name;
                            switch (nodeName)
                            {
                                case "CreditID":
                                    vCreditID = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "SourceName":
                                    vSourceName = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "Amount":
                                    Amount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Currency":
                                    curId = AnyInstruments.GetCurrIDByExchCode(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditingDate":
                                    vCreditingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "IncomingDate":
                                    vIncomingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CloseDate":
                                    vCloseDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Interest":
                                    vInterest = AnyInstruments.StringToFloat(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Balance":
                                    vBalance = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "AmountOverdue":
                                    vAmountOverdue = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "LoanLastPaymentDate":
                                    vLoanLastPaymentDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "TheLoanClass":
                                     vLoanClass = AnyInstruments.GetLoanClassIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentQuantity1-12":
                                    vDelayPaymentQuantity1_12 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentQuantity13-24":
                                    vDelayPaymentQuantity13_24 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentFrequency1-12":
                                    vDelayPaymentFrequency1_12 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentFrequency13-24":
                                    vDelayPaymentFrequency13_24 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditType":
                                    vCreditType = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "CreditStatus":
                                    vCreditStatus = AnyInstruments.GetACRA_CreditStatusIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditStart":
                                    vCreditStart = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingDate":
                                    vOutstandingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OverdueDays":
                                    vOverdueDays = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingPercent":
                                    vOutstandingPercent = AnyInstruments.StringToFloat(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditAmount":
                                    vCreditAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "PaymentAmount":
                                    vPaymentAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditScope":
                                    vCreditScope = AnyInstruments.GetACRA_CreditScopeIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    vCreditScopeText = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "ClassificationLastDate":
                                    vClassificationLastDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditNotes":
                                    vCreditNotes = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "ProlongationsNum":
                                    vProlongationsNum = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditUsePlace":
                                    vCreditUsePlace = lnode.ChildNodes.Item(n).InnerText;
                                    vCreditUsePlaceOld = (lnode.ChildNodes.Item(n).InnerText != null) ? AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText) : 0;
                                    break;
                                case "PledgeSubject":
                                    vPledgeSubject = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "CollateralNotes":
                                    vCollateralNotes = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "CollateralAmount":
                                    vCollateralAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "PMT":
                                    vPMT = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingDaysCount":
                                    OutstandingDaysCount = lnode.ChildNodes.Item(n);
                                    break;
                            }
                        }//for(int n=0; n < lnode.ChildNodes.Count; n++)
                         //DB Input start ------------------------------------------------------------------------------------
                        ACRA_R_Loan ln = new ACRA_R_Loan();
                        ln.fk_result_ID = resultId;
                        ln.l_type = 1;
                        ln.Amount = Amount;
                        ln.AmountOverdue = vAmountOverdue;
                        ln.Balance = vBalance;
                        ln.ClassificationLastDate = vClassificationLastDate;
                        ln.CloseDate = vCloseDate;
                        ln.CollateralAmount = vCollateralAmount;
                        ln.CollateralCurrency = vCollateralCurrency;
                        ln.CollateralNotes = vCollateralNotes;
                        ln.ContractAmount = vCreditAmount;
                        ln.CreditID = vCreditID;
                        ln.CreditingDate = vCreditingDate;
                        ln.CreditNotes = vCreditNotes;
                        ln.CreditScope = vCreditScope;
                        ln.CreditStart = vCreditStart;
                        ln.CreditStatus = vCreditStatus;
                        ln.CreditType = vCreditType;
                        ln.CreditUsePlaceText = vCreditUsePlace;
                        ln.currID = curId;
                        ln.DelayPaymentFrequency13_24 = vDelayPaymentFrequency13_24;
                        ln.DelayPaymentFrequency1_12 = vDelayPaymentFrequency1_12;
                        ln.DelayPaymentQuantity13_24 = vDelayPaymentQuantity13_24;
                        ln.DelayPaymentQuantity1_12 = vDelayPaymentQuantity1_12;
                        ln.IncomingDate = vIncomingDate;
                        ln.Interest = vInterest;
                        ln.LastPaymentDate = vLoanLastPaymentDate;
                        ln.LoanClass = vLoanClass;
                        ln.OutstandingDate = vOutstandingDate;
                        ln.OutstandingPercent = vOutstandingPercent;
                        ln.OverdueDays = vOverdueDays;
                        ln.PaymentAmount = vPaymentAmount;
                        ln.PledgeSubject = vPledgeSubject;
                        ln.PMT = vPMT;
                        ln.ProlongationsNum = vProlongationsNum;
                        ln.SourceName = vSourceName;
                        ln.CreditScopeText = vCreditScopeText;
                        ln.CreditUsePlace = vCreditUsePlaceOld;                   

                        db.ACRA_R_Loan.Add(ln);
                        db.SaveChanges();
                        savedLoanId = ln.loan_ID;

                        //get savedLoanId
                        //DB Input end --------------------------------------------------------------------------------------
                        if (OutstandingDaysCount != null)
                        {
                        try
                        {
                            for (int d = 0; d < OutstandingDaysCount.ChildNodes.Count; d++)
                            {
                                XmlNode odaysY = OutstandingDaysCount.ChildNodes.Item(d);
                                nodeName = odaysY.Attributes.GetNamedItem("name").Value;
                                ListItem mnt = new ListItem();
                                ListItemCollection mnts = new ListItemCollection();
                                for (int m = 0; m < odaysY.ChildNodes.Count; m++)
                                {
                                    mnt.Text = odaysY.ChildNodes.Item(m).Attributes.GetNamedItem("name").Value;
                                    mnt.Value = odaysY.ChildNodes.Item(m).InnerText;
                                    mnts.Add(mnt);
                                    mnt = new ListItem();
                                }
                                for (int m = 0; m < mnts.Count; m++)
                                {
                                    
                                    ACRA_osDays od = new ACRA_osDays();
                                    od.loanId = savedLoanId;
                                    od.osYear = nodeName;
                                    od.osMoth = mnts[m].Text;
                                    od.osValue = mnts[m].Value;
                                    db.ACRA_osDays.Add(od);
                                    db.SaveChanges();
                                    //DB Input end --------------------------------------------------------------------------------------
                                }//for(int m=0; m < mnts.Count;m++)
                            }//for(int d=0; d< OutstandingDaysCount.ChildNodes.Count; d++)
                        }
                        catch {; }
                        }//if(OutstandingDaysCount != null)

                    }//for(int l=0; l < Loan.Count;l++)
            }
                catch (DbEntityValidationException saveEx)
            {

                foreach (var eve in saveEx.EntityValidationErrors)
                {
                    Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                    }
                }
            }
            catch (Exception lnex)
            {
                Req_Err = "Loans _ " + nodeName + " _ " + lnex.Message + " # " + Req_Err;
            }

            double vGuarantorAmount = 0;//new
                vAmountOverdue = 0;
                vOverdueDays = 0;
                vOutstandingPercent = 0;//new
                vPaymentAmount = 0;
                vProlongationsNum = 0; //new
                sumOutstandingDaysCount = 0;//new
                vCreditType = "";//new
                vCreditID = "";
                vSourceName = "";
                vInterest = 0;
                vBalance = 0;                
                vLoanClass = 0;
                vDelayPaymentQuantity1_12 = 0;
                vDelayPaymentQuantity13_24 = 0;
                vDelayPaymentFrequency1_12 = 0;
                vDelayPaymentFrequency13_24 = 0;
                vCreditStatus = 0;
                vCreditAmount = 0;
                vCreditScope = 0;
                vCreditUsePlace = "";
                vPledgeSubject = "";
                vCollateralNotes = "";
                vCollateralAmount = 0;  
                vCollateralCurrency = 0;
                vPMT = 0;
                nodeName = "";

                try
                {
                    XmlNodeList Guarantee = acraInfoXML.GetElementsByTagName("Guarantee");
                    for (int l = 0; l < Guarantee.Count; l++)
                    {
                        XmlNode lnode = Guarantee.Item(l);
                        XmlNode OutstandingDaysCount = null;

                        for (int n = 0; n < lnode.ChildNodes.Count; n++)
                        {
                            nodeName = lnode.ChildNodes.Item(n).Name;
                            switch (nodeName)
                            {
                                case "CreditID":
                                    vCreditID = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "SourceName":
                                    vSourceName = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "Amount":
                                    Amount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Currency":
                                    curId = AnyInstruments.GetCurrIDByExchCode(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditingDate":
                                    vCreditingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "IncomingDate":
                                    vIncomingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "GuaranteeCancellationDate":
                                    vCloseDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Interest":
                                    vInterest = AnyInstruments.StringToFloat(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Balance":
                                    vBalance = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "AmountOverdue":
                                    vAmountOverdue = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "GuaranteeLastPaymentDate":
                                    vLoanLastPaymentDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "TheGuaranteeClass":
                                    vLoanClass = AnyInstruments.GetLoanClassIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentQuantity1-12":
                                    vDelayPaymentQuantity1_12 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentQuantity13-24":
                                    vDelayPaymentQuantity13_24 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentFrequency1-12":
                                    vDelayPaymentFrequency1_12 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "DelayPaymentFrequency13-24":
                                    vDelayPaymentFrequency13_24 = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditType":
                                    vCreditType = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "CreditStatus":
                                    vCreditStatus = AnyInstruments.GetACRA_CreditStatusIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditStart":
                                    vCreditStart = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingDate":
                                    vOutstandingDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OverdueDays":
                                    vOverdueDays = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingPercent":
                                    vOutstandingPercent = AnyInstruments.StringToFloat(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditAmount":
                                    vCreditAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "PaymentAmount":
                                    vPaymentAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditScope":
                                    vCreditScope = AnyInstruments.GetACRA_CreditScopeIDByName(lnode.ChildNodes.Item(n).InnerText);
                                    vCreditScopeText = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "ClassificationLastDate":
                                    vClassificationLastDate = AnyInstruments.AcrStrToDateTime(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditNotes":
                                    vCreditNotes = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "ProlongationsNum":
                                    vProlongationsNum = AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "GuarantorAmount":
                                    vGuarantorAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "CreditUsePlace":
                                    vCreditUsePlace = lnode.ChildNodes.Item(n).InnerText;
                                    vCreditUsePlaceOld = (lnode.ChildNodes.Item(n).InnerText != null) ? AnyInstruments.StringToInt(lnode.ChildNodes.Item(n).InnerText) : 0;
                                    break;
                                case "PledgeSubject":
                                    vPledgeSubject = lnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "CollateralNotes":
                                    vCollateralNotes = (lnode.ChildNodes.Item(n).InnerText != null) ? (lnode.ChildNodes.Item(n).InnerText.Length > 150 ? lnode.ChildNodes.Item(n).InnerText.Substring(150): lnode.ChildNodes.Item(n).InnerText):"NoNode";
                                    break;
                                case "CollateralAmount":
                                    vCollateralAmount = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "PMT":
                                    vPMT = AnyInstruments.StringToDouble(lnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "OutstandingDaysCount":
                                    OutstandingDaysCount = lnode.ChildNodes.Item(n);
                                    break;
                            }
                        }//for(int n=0; n < lnode.ChildNodes.Count; n++)
                         //DB Input start ------------------------------------------------------------------------------------
                        ACRA_R_Loan ln = new ACRA_R_Loan();
                        ln.fk_result_ID = resultId;
                        ln.l_type = 2;
                        ln.Amount = Amount;
                        ln.AmountOverdue = vAmountOverdue;
                        ln.Balance = vBalance;
                        ln.ClassificationLastDate = vClassificationLastDate;
                        ln.CloseDate = vCloseDate;
                        ln.CollateralAmount = vCollateralAmount;
                        ln.CollateralCurrency = vCollateralCurrency;
                        ln.CollateralNotes = vCollateralNotes;
                        ln.ContractAmount = vCreditAmount;
                        ln.CreditID = vCreditID;
                        ln.CreditingDate = vCreditingDate;
                        ln.CreditNotes = vCreditNotes;
                        ln.CreditScope = vCreditScope;
                        ln.CreditStart = vCreditStart;
                        ln.CreditStatus = vCreditStatus;
                        ln.CreditType = vCreditType;
                        ln.CreditUsePlaceText = vCreditUsePlace;
                        ln.currID = curId;
                        ln.DelayPaymentFrequency13_24 = vDelayPaymentFrequency13_24;
                        ln.DelayPaymentFrequency1_12 = vDelayPaymentFrequency1_12;
                        ln.DelayPaymentQuantity13_24 = vDelayPaymentQuantity13_24;
                        ln.DelayPaymentQuantity1_12 = vDelayPaymentQuantity1_12;
                        ln.GuarantorAmount = vGuarantorAmount;
                        ln.IncomingDate = vIncomingDate;
                        ln.Interest = vInterest;
                        ln.LastPaymentDate = vLoanLastPaymentDate;
                        ln.LoanClass = vLoanClass;
                        ln.OutstandingDate = vOutstandingDate;
                        ln.OutstandingPercent = vOutstandingPercent;
                        ln.OverdueDays = vOverdueDays;
                        ln.PaymentAmount = vPaymentAmount;
                        ln.PledgeSubject = vPledgeSubject;
                        ln.PMT = vPMT;
                        ln.ProlongationsNum = vProlongationsNum;
                        ln.SourceName = vSourceName;
                        ln.CreditScopeText = vCreditScopeText;
                        ln.CreditUsePlace = vCreditUsePlaceOld;                  

                        db.ACRA_R_Loan.Add(ln);
                        db.SaveChanges();
                        savedLoanId = ln.loan_ID;
                        //DB Input end --------------------------------------------------------------------------------------
                        if (OutstandingDaysCount != null)
                        {
                            for (int d = 0; d < OutstandingDaysCount.ChildNodes.Count; d++)
                            {
                                XmlNode odaysY = OutstandingDaysCount.ChildNodes.Item(d);
                                nodeName = odaysY.Attributes.GetNamedItem("name").Value;
                                ListItem mnt = new ListItem();
                                ListItemCollection mnts = new ListItemCollection();
                                for (int m = 0; m < odaysY.ChildNodes.Count; m++)
                                {
                                    mnt.Text = odaysY.ChildNodes.Item(m).Attributes.GetNamedItem("name").Value;
                                    mnt.Value = odaysY.ChildNodes.Item(m).InnerText;
                                    mnts.Add(mnt);
                                    mnt = new ListItem();
                                }
                                for (int m = 0; m < mnts.Count; m++)
                                {

                                    //DB Input start ------------------------------------------------------------------------------------
                                    //set savedLoanId

                                    ACRA_osDays od = new ACRA_osDays();
                                    od.loanId = savedLoanId;
                                    od.osYear = nodeName;
                                    od.osMoth = mnts[m].Text;
                                    od.osValue = mnts[m].Value;
                                    db.ACRA_osDays.Add(od);
                                    db.SaveChanges();
                                    //DB Input end --------------------------------------------------------------------------------------
                                }//for (int m = 0; m < mnts.Count; m++)
                            }//for (int d = 0; d < OutstandingDaysCount.ChildNodes.Count; d++)
                        }//if(OutstandingDaysCount !=null)
                    }//for(int l=0; l < Loan.Count;l++)
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception lnex)
                {
                    Req_Err = "Guarantee _ " + nodeName + " _ " + lnex.Message + " # " + Req_Err;
                }

                int vCurrent = 0;
                int vClosed = 0;
                int vTotal = 0;

                try
                {
                    XmlNodeList CountOfLoans = acraInfoXML.GetElementsByTagName("CountOfLoans");
                    for(int i = 0; i < CountOfLoans.Count; i++)
                    {
                        XmlNode clnode = CountOfLoans.Item(i);
                        for (int n = 0; n < clnode.ChildNodes.Count; n++)
                        {
                            nodeName = clnode.ChildNodes.Item(n).Name;
                            switch (nodeName)
                            {
                                case "Current":
                                    vCurrent = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Closed":
                                    vClosed = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Total":
                                    vTotal = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                            }//switch (nodeName)                             
                        }//for (int n = 0; n < clnode.ChildNodes.Count; n++)                        
                    }//for(int i = 0; i < CountOfLoans.Count; i++)

                    //DB Input start ------------------------------------------------------------------------------------

                    ACRA_TotalOfLnAndGr cl = new ACRA_TotalOfLnAndGr();
                    cl.resultId = resultId;
                    cl.lType = 1;
                    cl.vClosed = vClosed;
                    cl.vCurrent = vCurrent;
                    cl.vTotal = vTotal;

                    db.ACRA_TotalOfLnAndGr.Add(cl);
                    db.SaveChanges();

                    //DB Input end --------------------------------------------------------------------------------------

                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception clnex)
                {
                    Req_Err = "CountOfLoans _ " + nodeName + " _ " + clnex.Message + " # " + Req_Err;
                }

                vCurrent = 0;
                vClosed = 0;
                vTotal = 0;

                try
                {
                    XmlNodeList CountOfGuarantees = acraInfoXML.GetElementsByTagName("CountOfGuarantees");
                    for (int i = 0; i < CountOfGuarantees.Count; i++)
                    {
                        XmlNode clnode = CountOfGuarantees.Item(i);
                        for (int n = 0; n < clnode.ChildNodes.Count; n++)
                        {
                            nodeName = clnode.ChildNodes.Item(n).Name;
                            switch (nodeName)
                            {
                                case "Current":
                                    vCurrent = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Closed":
                                    vClosed = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                                case "Total":
                                    vTotal = AnyInstruments.StringToInt(clnode.ChildNodes.Item(n).InnerText);
                                    break;
                            }//switch (nodeName)                             
                        }//for (int n = 0; n < clnode.ChildNodes.Count; n++)

                    }//for(int i = 0; i < CountOfLoans.Count; i++)
                    //DB Input start ------------------------------------------------------------------------------------

                    ACRA_TotalOfLnAndGr cl = new ACRA_TotalOfLnAndGr();
                    cl.resultId = resultId;
                    cl.lType = 2;
                    cl.vClosed = vClosed;
                    cl.vCurrent = vCurrent;
                    cl.vTotal = vTotal;

                    db.ACRA_TotalOfLnAndGr.Add(cl);
                    db.SaveChanges();

                    //DB Input end --------------------------------------------------------------------------------------
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception clnex)
                {
                    Req_Err = "CountOfGuarantees _ " + nodeName + " _ " + clnex.Message + " # " + Req_Err;
                }


                Amount = 0;
                AmountUSD = 0;
                curId = 0;
                try
                {
                    XmlNodeList CurrentOverdueLoan = acraInfoXML.GetElementsByTagName("CurrentOverdueLoan");
                    for (int i = 0; i < CurrentOverdueLoan.Count; i++)
                    {
                        XmlNode tn = CurrentOverdueLoan.Item(i);
                        curId = AnyInstruments.GetCurrIDByExchCode(tn.ChildNodes.Item(1).InnerText);
                        Amount = AnyInstruments.StringToDouble(tn.ChildNodes.Item(0).InnerText);

                        //DB Input start ------------------------------------------------------------------------------------
                        ACRA_R_CurrentOverdue ovd = new ACRA_R_CurrentOverdue();
                        ovd.fk_result_ID = resultId;
                        ovd.l_type = 1;
                        ovd.currID = curId;
                        ovd.Amount = Amount;
                        db.ACRA_R_CurrentOverdue.Add(ovd);
                        db.SaveChanges();
                        //DB Input end --------------------------------------------------------------------------------------
                    }
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception lex)
                {
                    Req_Err = "CurrentOverdueLoan _ " + lex.Message + "# " + Req_Err;
                }

                Amount = 0;
                AmountUSD = 0;
                curId = 0;
                try
                {
                    XmlNodeList CurrentOverdueGuarantee = acraInfoXML.GetElementsByTagName("CurrentOverdueGuarantee");
                    for (int i = 0; i < CurrentOverdueGuarantee.Count; i++)
                    {
                        XmlNode tn = CurrentOverdueGuarantee.Item(i);
                        curId = AnyInstruments.GetCurrIDByExchCode(tn.ChildNodes.Item(1).InnerText);
                        Amount = AnyInstruments.StringToDouble(tn.ChildNodes.Item(0).InnerText);

                        //DB Input start ------------------------------------------------------------------------------------
                        ACRA_R_CurrentOverdue ovd = new ACRA_R_CurrentOverdue();
                        ovd.fk_result_ID = resultId;
                        ovd.l_type = 2;
                        ovd.currID = curId;
                        ovd.Amount = Amount;
                        db.ACRA_R_CurrentOverdue.Add(ovd);
                        db.SaveChanges();
                        //DB Input end --------------------------------------------------------------------------------------
                    }
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception lex)
                {
                    Req_Err = "CurrentOverdueGuarantee _ " + lex.Message + "# " + Req_Err;
                }


                string vNumber = "";
                string vBankName = "";
                string vDate = "";
                string vReason = "";
                string vSubReason = "";

                try
                {
                    XmlNodeList Request = acraInfoXML.GetElementsByTagName("Request");
                    for (int i = 0; i < Request.Count; i++)
                    {
                        XmlNode rnode = Request.Item(i);
                        for (int n = 0; n < rnode.ChildNodes.Count; n++)
                        {
                            nodeName = rnode.ChildNodes.Item(n).Name;
                            switch (nodeName)
                            {
                                case "Number":
                                    vNumber = rnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "BankName":
                                    vBankName = rnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "Date":
                                    vDate = rnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "Reason":
                                    vReason = rnode.ChildNodes.Item(n).InnerText;
                                    break;
                                case "SubReason":
                                    vSubReason = rnode.ChildNodes.Item(n).InnerText;
                                    break;
                            }//switch (nodeName)                             
                        }//for (int n = 0; n < clnode.ChildNodes.Count; n++)

                        //DB Input start ------------------------------------------------------------------------------------

                        ACRA_RequestesInfo rinfo = new ACRA_RequestesInfo();
                        rinfo.resultId = resultId;
                        rinfo.vBankName = vBankName;
                        rinfo.vDate = vDate;
                        rinfo.vNumber = vNumber;
                        rinfo.vReason = vReason;
                        rinfo.vSubReason = vSubReason;
                        db.ACRA_RequestesInfo.Add(rinfo);
                        db.SaveChanges();  
                        //DB Input end --------------------------------------------------------------------------------------

                    }//for(int i = 0; i < CountOfLoans.Count; i++)
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception reqex)
                {
                    Req_Err = "Request _ " + nodeName + " _ " + reqex.Message + " # " + Req_Err;
                }


                string vDebtorNum = "";
                string vInterrelatedSourceName = "";

                string iNumber = "";
                string iCreditStart = "";
                string iLastInstallment = "";
                double iContractAmount = 0;
                double iAmountDue = 0;
                double iAmountOverdue = 0;
                float iOutstandingPercent = 0;
                string iOutstandingDate = "";
                string iCurrency = "";
                string iCreditClassification = "";

                try
                {
                    XmlNodeList Interrelated = acraInfoXML.GetElementsByTagName("Interrelated");
                    for (int ir = 0; ir < Interrelated.Count; ir++)
                    {
                        vDebtorNum = Interrelated.Item(ir).ChildNodes[0].InnerText;
                        vInterrelatedSourceName = Interrelated.Item(ir).ChildNodes[1].InnerText.Length > 50 ? Interrelated.Item(ir).ChildNodes[1].InnerText.Substring(0,50) : Interrelated.Item(ir).ChildNodes[1].InnerText;
                        XmlNodeList InterrelatedLoans = Interrelated.Item(ir).ChildNodes[2].ChildNodes;
                        for (int i = 0; i < InterrelatedLoans.Count; i++)
                        {
                            XmlNode InterrelatedLoan = InterrelatedLoans.Item(i);
                            iNumber = InterrelatedLoan["Number"].InnerText;
                            iCreditStart = InterrelatedLoan["CreditStart"].InnerText;
                            iLastInstallment = InterrelatedLoan["LastInstallment"].InnerText;
                            iContractAmount = AnyInstruments.StringToDouble(InterrelatedLoan["ContractAmount"].InnerText);
                            iAmountDue = AnyInstruments.StringToDouble(InterrelatedLoan["AmountDue"].InnerText);
                            iAmountOverdue = AnyInstruments.StringToDouble(InterrelatedLoan["AmountOverdue"].InnerText);
                            iOutstandingPercent = AnyInstruments.StringToFloat(InterrelatedLoan["OutstandingPercent"].InnerText);
                            iOutstandingDate = InterrelatedLoan["OutstandingDate"].InnerText;
                            iCurrency = InterrelatedLoan["Currency"].InnerText;
                            iCreditClassification = InterrelatedLoan["CreditClassification"].InnerText;


                            //DB Input start ------------------------------------------------------------------------------------

                            ACRA_Interrelated irl = new ACRA_Interrelated();
                            irl.resultId = resultId;
                            irl.vDebtorNum = vDebtorNum;
                            irl.vInterrelatedSourceName = vInterrelatedSourceName;
                            irl.iAmountDue = iAmountDue;
                            irl.iAmountOverdue = iAmountOverdue;
                            irl.iContractAmount = iContractAmount;
                            irl.iCreditClassification = iCreditClassification;
                            irl.iCreditStart = iCreditStart;
                            irl.iCurrency = iCurrency;
                            irl.iLastInstallment = iLastInstallment;
                            irl.iNumber = iNumber;
                            irl.iOutstandingDate = iOutstandingDate;
                            irl.iOutstandingPercent = iOutstandingPercent;
                            db.ACRA_Interrelated.Add(irl);
                            db.SaveChanges();
                            //req_ID, vDebtorNum, vInterrelatedSourceName
                            //DB Input end --------------------------------------------------------------------------------------

                        }//for(int i = 0; i < InterrelatedLoans.Count; i++)

                    }//for(int ir = 0; ir < Interrelated.Count; ir++)
                }
                catch (DbEntityValidationException saveEx)
                {

                    foreach (var eve in saveEx.EntityValidationErrors)
                    {
                        Req_Err += " Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State.ToString() + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Req_Err += $"- Property:" + ve.PropertyName + " , Error:" + ve.ErrorMessage;
                        }
                    }
                }
                catch (Exception irex)
                {
                    Req_Err = "Interrelated _ " + vInterrelatedSourceName + " - " + iNumber  + " _ " + irex.Message + " # " + Req_Err;
                }




            }//if (acraInfoXML.GetElementsByTagName("ErrorDesc").Count > 0)




            req_date = DateTime.Now; 
            ACRA_WebRequest.UpdateACRAReqStatus(AnyInstruments.StringToLong(req_ID), req_date, Req_Err, Req_Err);

            return rtVal;
        }//public int ACRARequestInputNew(int user_ID, long hayt_ID, string firstName, string lastName, DateTime DOB, string passpNumb, string socCard, int RequestTarget, int UsageRange, int reqType, int isTest)
        

    }//ACRARequestInput

    public static class ACRA_WebRequest
    {
        public static string ACRAMonAddr = "https://XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public static string ACRANewLoanAddr = "https://XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

        public static string ACRAMonAddrTest = "http://XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public static string ACRANewLoanAddrTest = "http://XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

        public static string ACRAWebAddres = "https://XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

        public static DataTable GetACRAUser(int user_ID)
        {
            DataTable tbl;
            byte[] b;
            int len = 16;

            LUISDataTableAdapters.ACRAUsersSelectTableAdapter acraUseradp = new LUISDataTableAdapters.ACRAUsersSelectTableAdapter();
            tbl = acraUseradp.GetData(user_ID);
            if (tbl.Rows.Count > 0)
            {
                b = (byte[])tbl.Rows[0]["acra_pwd"]; 

                while (len > 0 && b[len - 1] == 0)
                {
                    len--;
                }//while(len > 0 && b[len-1] == 0)
                byte[] croped = new byte[len];
                if (len > 0)
                {
                    Array.Copy(b, 0, croped, 0, len);
                    b = croped;
                    tbl.Rows[0]["acra_pwd"] = b;
                }//if (len > 0)
                else
                {
                    tbl.Rows[0]["acra_pwd"] = Encoding.ASCII.GetBytes("XXXXXX");
                }//else if (len > 0)                         
            }//if(tbl.Rows.Count > 0)
            //Encrytion must be add
            return tbl;
        }//public static DataTable GetACRAUser(int user_ID)

        public static string GetACRARequestID(int req_type)
        {
            DataTable tbl;
            LUISDataTableAdapters.ACRA_ReqStatusGetLastTableAdapter statAbp = new LUISDataTableAdapters.ACRA_ReqStatusGetLastTableAdapter();
            statAbp.Insert(DateTime.Now, req_type);
            tbl = statAbp.GetData();

            return tbl.Rows[0]["req_ID"].ToString();

        }//public static string GetACRARequestID()


        public static void UpdateACRAReqStatus(long req_ID, DateTime req_date, string req_result, string err)
        {
            DateTime dt = new DateTime(1800, 1, 1);
            if (req_date.Year < 1800)
            {
                req_date = dt;
            }//if (req_date.Year < 1800)
            LUISDataTableAdapters.ACRA_ReqStatusGetLastTableAdapter statAbp = new LUISDataTableAdapters.ACRA_ReqStatusGetLastTableAdapter();
            statAbp.Update(req_ID, req_date, req_result + err);
        }//public static void UpdateACRAReqStatus(long req_ID)

        public static Stream GetWebRequestS(int user_ID, int p_or_j, ACRA_P_Participient partP, ACRA_O_Participient partO, string appNumb, int reqType, int isTest)
        {
            string SID;
            string LogReq;
            string request;
            string Req_Err;
            string req_ID;
            Stream acraResp;
            DataTable AcraUser = GetACRAUser(user_ID);
            byte[] b = (byte[])AcraUser.Rows[0]["acra_pwd"];

            if (isTest > 1)
                LogReq = "<ROWDATA type=\"Bank_LogIn\"><ReqID>" + GetACRARequestID(1) + "</ReqID><User>" + AcraUser.Rows[0]["acra_user"].ToString() + "</User><Password>" + System.Text.ASCIIEncoding.ASCII.GetString(b) + "</Password></ROWDATA>";
            else
                LogReq = "<ROWDATA type=\"Bank_LogIn\"><ReqID>" + GetACRARequestID(1) + "</ReqID><User>ArturG</User><Password>123456</Password></ROWDATA>";


            CookieContainer cookies = new CookieContainer();
            XmlDocument logRespXML = new XmlDocument();

            switch(reqType)
            {
                case 1:
                    if (isTest == 1)
                    {
                        ACRAWebAddres = ACRANewLoanAddrTest;
                    }
                    else
                    {
                        ACRAWebAddres = ACRANewLoanAddr;
                    }
                    
                    break;
                case 2:
                    if (isTest == 1)
                    {
                        ACRAWebAddres = ACRAMonAddrTest;
                    }
                    else
                    {
                        ACRAWebAddres = ACRAMonAddr;
                    }
                    break;
            }//switch(reqType)


            HttpWebRequest logReq = (HttpWebRequest)WebRequest.Create(ACRAWebAddres);
            logReq.CookieContainer = cookies;
            logReq.Method = "POST";
            logReq.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = Encoding.ASCII.GetBytes("query_xml=" + LogReq);

            logReq.ContentLength = buffer.Length;

            Stream webPostData = logReq.GetRequestStream();
            webPostData.Write(buffer, 0, buffer.Length);
            webPostData.Close();
            HttpWebResponse webResp = (HttpWebResponse)logReq.GetResponse();

            Stream webAnswer = webResp.GetResponseStream();
            StreamReader answerReader = new StreamReader(webAnswer);
            logRespXML.LoadXml(answerReader.ReadToEnd());


            if (logRespXML.GetElementsByTagName("Response").Item(0).InnerText != "OK")
            {
                Req_Err = logRespXML.GetElementsByTagName("Error").Item(0).InnerText;
                SID = "";
                req_ID = "";
            }
            else
            {
                Req_Err = "";
                SID = logRespXML.GetElementsByTagName("SID").Item(0).InnerText;
                req_ID = logRespXML.GetElementsByTagName("ReqID").Item(0).InnerText;
            }

            UpdateACRAReqStatus(AnyInstruments.StringToLong(req_ID), DateTime.Now, logRespXML.GetElementsByTagName("Response").Item(0).InnerText, Req_Err);

            ACRA_Request req = new ACRA_Request(GetACRARequestID(2), appNumb, SID);

            if (p_or_j == 1)
            {
                req.SetPerson(partP);
                request = req.GetPerson();
            }//if (p_or_j == 1)
            else
            {
                req.SetOrganization(partO);
                request = req.GetOrganization();
            }//else if (p_or_j == 1)


            buffer = Encoding.UTF8.GetBytes("query_xml=" + request);

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(ACRA_WebRequest.ACRAWebAddres);
            webReq.CookieContainer = cookies;
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.ContentLength = buffer.Length;
            webPostData = webReq.GetRequestStream();
            webPostData.Write(buffer, 0, buffer.Length);
            webPostData.Close();
            webResp = (HttpWebResponse)webReq.GetResponse();

            acraResp = webResp.GetResponseStream();

            return acraResp;

        }//public static XmlDocument GetWebRequest(string request)


    }
    //public static class ACRA_WebRequest


}
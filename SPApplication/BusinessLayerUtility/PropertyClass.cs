using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayerUtility
{
    public class PropertyClass
    {

        private static int financialyearid;
        public int FinancialYearId
        {
            get { return financialyearid; }
            set { financialyearid = value; }
        }
        
        private static string computername;
        public string ComputerName
        {
            get { return computername; }
            set { computername = value; }
        }

        private static string formname;
        public string FormName
        {
            get { return formname; }
            set { formname = value; }
        }

        private static string formnameprofile;
        public string FormNameProfile
        {
            get { return formnameprofile; }
            set { formnameprofile = value; }
        }

        private static bool viewticketflag;
        public bool ViewTicketFlag
        {
            get { return viewticketflag; }
            set { viewticketflag = value; }
        }

        private static int uploaddocumentid;
        public int UploadDocumentId
        {
            get { return uploaddocumentid; }
            set { uploaddocumentid = value; }
        }

        private static int formid;
        public int FormId
        {
            get { return formid; }
            set { formid = value; }
        }

        private static int documentid;
        public int DocumentId
        {
            get { return documentid; }
            set { documentid = value; }
        }

        private static string documentpath;
        public string DocumentPath
        {
            get { return documentpath; }
            set { documentpath = value; }
        }

        private static string documentname;
        public string DocumentName
        {
            get { return documentname; }
            set { documentname = value; }
        }
 
        private static bool checkflagarm;
        public bool CheckFlagARM
        {
            get { return checkflagarm; }
            set { checkflagarm = value; }
        }

        private static DateTime entrydate;
        public DateTime EntryDate
        {
            get { return entrydate; }
            set { entrydate = value; }
        }

        private static DateTime entrytime;
        public DateTime EntryTime
        {
            get { return entrytime; }
            set { entrytime = value; }
        }

        //private static string documentpath;
        //public string DocumentPath
        //{
        //    get { return documentpath; }
        //    set { documentpath = value; }
        //}

        private static string formheader;
        public string FormHeader
        {
            get { return formheader; }
            set { formheader = value; }
        }

        private static int tableid;
        public int TableId
        {
            get { return tableid; }
            set { tableid = value; }
        }

        private static string searchtype;
        public string SearchType
        {
            get { return searchtype; }
            set { searchtype = value; }
        }
        //Report

        private static string reportform;
        public string ReportForm
        {
            get { return reportform; }
            set { reportform = value; }
        }

        private static int reportquery;
        public int ReportQuery
        {
            get { return reportquery; }
            set { reportquery = value; }
        }

        private static int searchid;
        public int SearchId
        {
            get { return searchid; }
            set { searchid = value; }
        }

        //Contry Master
        private static int contryid;
        public int ContryId
        {
            get { return contryid; }
            set { contryid = value; }
        }

        private static string contryname;
        public string ContryName
        {
            get { return contryname; }
            set { contryname = value; }
        }

        //State Master
        private static int stateid;
        public int StateId
        {
            get { return stateid; }
            set { stateid = value; }
        }

        private static string statename;
        public string StateName
        {
            get { return statename; }
            set { statename = value; }
        }


        //Manpower

        private static int manpowerid;
        public int ManpowerId
        {
            get { return manpowerid; }
            set { manpowerid = value; }
        }

        private static DateTime dateofrequisition;
        public DateTime DateOfRequisition
        {
            get { return dateofrequisition; }
            set { dateofrequisition = value; }
        }

        private static DateTime expecteddate;
        public DateTime ExpectedDate
        {
            get { return expecteddate; }
            set { expecteddate = value; }
        }

        private static string reasonOfrequest;
        public string ReasonOfRequest
        {
            get { return reasonOfrequest; }
            set { reasonOfrequest = value; }
        }

        private static string noofcandidates;
        public string NoOfCandidates
        {
            get { return noofcandidates; }
            set { noofcandidates = value; }
        }

        private static string skill;
        public string Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        //District Master
        private static int districtid;
        public int DistrictId
        {
            get { return districtid; }
            set { districtid = value; }
        }

        private static string districtname;
        public string DistrictName
        {
            get { return districtname; }
            set { districtname = value; }
        }

        //Taluka Master
        private static int talukaid;
        public int TalukaId
        {
            get { return talukaid; }
            set { talukaid = value; }
        }

        private static string talukaname;
        public string TalukaName
        {
            get { return talukaname; }
            set { talukaname = value; }
        }

        //City/Village Master
        private static int cityvillageid;
        public int CityVillageId
        {
            get { return cityvillageid; }
            set { cityvillageid = value; }
        }

        private static string cityvillagename;
        public string CityVillageName
        {
            get { return cityvillagename; }
            set { cityvillagename = value; }
        }

        private static int pincode;
        public int Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }

        //Area Master
        private static int areaid;
        public int AreaId
        {
            get { return areaid; }
            set { areaid = value; }
        }

        private static string areaname;
        public string AreaName
        {
            get { return areaname; }
            set { areaname = value; }
        }

        private static string uertype;
        public string UserType
        {
            get { return uertype; }
            set { uertype = value; }
        }

        //Location Master
        private static int locationid;
        public int LocationId
        {
            get { return locationid; }
            set { locationid = value; }
        }

        private static int inchargeid;
        public int InchargeId
        {
            get { return inchargeid; }
            set { inchargeid = value; }
        }

        private static int approvedflag;
        public int ApprovedFlag
        {
            get { return approvedflag; }
            set { approvedflag = value; }
        }

        private static string approvalstatus;
        public string ApprovalStatus
        {
            get { return approvalstatus; }
            set { approvalstatus = value; }
        }

        private static string attendancestatus;
        public string AttendanceStatus
        {
            get { return attendancestatus; }
            set { attendancestatus = value; }
        }



        private static string locationname;
        public string LocationName
        {
            get { return locationname; }
            set { locationname = value; }
        }

        private static string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private static string contactperson;
        public string ContactPerson
        {
            get { return contactperson; }
            set { contactperson = value; }
        }

        private static string mobilenumber;
        public string MobileNumber
        {
            get { return mobilenumber; }
            set { mobilenumber = value; }
        }

        private static int extensionno;
        public int ExtensionNo
        {
            get { return extensionno; }
            set { extensionno = value; }
        }

        private static int userid;
        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        private static int flagc;
        public int FlagC
        {
            get { return flagc; }
            set { flagc = value; }
        }

        private static bool searchflag;
        public bool SearchFlag
        {
            get { return searchflag; }
            set { searchflag = value; }
        }

        private static bool searchflagleavecompoff;
        public bool SearchFlagLeaveCompOff
        {
            get { return searchflagleavecompoff; }
            set { searchflagleavecompoff = value; }
        }

        private static bool deleteflag;
        public bool DeleteFlag
        {
            get { return deleteflag; }
            set { deleteflag = value; }
        }

        //Employee Type Master

        private static int employementtypeid;
        public int EmployementTypeId
        {
            get { return employementtypeid; }
            set { employementtypeid = value; }
        }

        private static string employementtype;
        public string EmployementType
        {
            get { return employementtype; }
            set { employementtype = value; }
        }

        ////Leave Master
        //private static int leavetypeid;
        //public int LeaveTypeId
        //{
        //    get { return leavetypeid; }
        //    set { leavetypeid = value; }
        //}

        private static string leavetypefname;
        public string LeaveTypeFName
        {
            get { return leavetypefname; }
            set { leavetypefname = value; }
        }

        //Company Profile

        private static int companyid;
        public int CompanyId
        {
            get { return companyid; }
            set { companyid = value; }
        }

        private static string companyname;
        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private static string registeredaddress;
        public string RegisteredAddress
        {
            get { return registeredaddress; }
            set { registeredaddress = value; }
        }


        private static string unitsaddressdetails;
        public string UnitsAddressDetails
        {
            get { return unitsaddressdetails; }
            set { unitsaddressdetails = value; }
        }


        //private static int areaid;
        //public int AreaId
        //{
        //    get { return areaid; }
        //    set { areaid = value; }
        //}

        private static string emailid;
        public string EmailId
        {
            get { return emailid; }
            set { emailid = value; }
        }

        private static string website;
        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        private static string contactnumber;
        public string ContactNumber
        {
            get { return contactnumber; }
            set { contactnumber = value; }
        }

        private static DateTime establishmentdate;
        public DateTime EstablishmentDate
        {
            get { return establishmentdate; }
            set { establishmentdate = value; }
        }

        private static DateTime dateofincorporation;
        public DateTime DateOfIncorporation
        {
            get { return dateofincorporation; }
            set { dateofincorporation = value; }
        }

        private static string registrationnumber;
        public string RegistrationNumber
        {
            get { return registrationnumber; }
            set { registrationnumber = value; }
        }

        private static string factorylicensenumber;
        public string FactoryLicenseNumber
        {
            get { return factorylicensenumber; }
            set { factorylicensenumber = value; }
        }

        private static string udyogaadharnumber;
        public string UdyogAadharNumber
        {
            get { return udyogaadharnumber; }
            set { udyogaadharnumber = value; }
        }

        private static string fssaino;
        public string FSSAINo
        {
            get { return fssaino; }
            set { fssaino = value; }
        }

        private static string gstin;
        public string GSTIN
        {
            get { return gstin; }
            set { gstin = value; }
        }

        private static string panno;
        public string PANNo
        {
            get { return panno; }
            set { panno = value; }
        }

        private static string tanno;
        public string TANNo
        {
            get { return tanno; }
            set { tanno = value; }
        }

        private static string pfestablishmentid;
        public string PFEstablishmentID
        {
            get { return pfestablishmentid; }
            set { pfestablishmentid = value; }
        }

        private static string esicestablishmentid;
        public string ESICEstablishmentID
        {
            get { return esicestablishmentid; }
            set { esicestablishmentid = value; }
        }

        // private static string ptrcno;
        //public string PTRCNo
        //{
        //    get { return ptrcno; }
        //    set { ptrcno = value; }
        //}

        //   private static string ptecno;
        //public string PTECNo
        //{
        //    get { return ptecno; }
        //    set { ptecno = value; }
        //}

        private static string lwfno;
        public string LWFNo
        {
            get { return lwfno; }
            set { lwfno = value; }
        }

        private static string labourlicenseregno;
        public string LabourLicenseRegNo
        {
            get { return labourlicenseregno; }
            set { labourlicenseregno = value; }
        }

        private static DateTime labourlicensedate;
        public DateTime LabourLicenseDate
        {
            get { return labourlicensedate; }
            set { labourlicensedate = value; }
        }

        //private static string totalemployeeasperlicense;
        //public string TotalEmployeeAsPerLicense
        //{
        //    get { return totalemployeeasperlicense; }
        //    set { totalemployeeasperlicense = value; }
        //}

        private static string brcregno;
        public string BRCRegNo
        {
            get { return brcregno; }
            set { brcregno = value; }
        }

        private static DateTime brcregistereddate;
        public DateTime BRCRegisteredDate
        {
            get { return brcregistereddate; }
            set { brcregistereddate = value; }
        }

        private static string isoregno;
        public string ISORegNo
        {
            get { return isoregno; }
            set { isoregno = value; }
        }

        private static DateTime isoregistereddate;
        public DateTime ISORegisteredDate
        {
            get { return isoregistereddate; }
            set { isoregistereddate = value; }
        }

        private static string bankname;
        public string BankName
        {
            get { return bankname; }
            set { bankname = value; }
        }

        private static string accountno;
        public string AccountNo
        {
            get { return accountno; }
            set { accountno = value; }
        }

        private static string branchname;
        public string BranchName
        {
            get { return branchname; }
            set { branchname = value; }
        }

        private static string micrno;
        public string MICRNo
        {
            get { return micrno; }
            set { micrno = value; }
        }

        private static string ifsccode;
        public string IFSCCode
        {
            get { return ifsccode; }
            set { ifsccode = value; }
        }

        //Designation Master

        private static int designationid;
        public int DesignationId
        {
            get { return designationid; }
            set { designationid = value; }
        }

        private static string designation;
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private static string designationcategory;
        public string DesignationCategory
        {
            get { return designationcategory; }
            set { designationcategory = value; }
        }

        private static int overtimeflag;
        public int OvertimeFlag
        {
            get { return overtimeflag; }
            set { overtimeflag = value; }
        }

        private static int overtimeapplicable;
        public int OverTimeApplicable
        {
            get { return overtimeapplicable; }
            set { overtimeapplicable = value; }
        }

        private static string overtimeapplicableyn;
        public string OverTimeApplicableYesNo
        {
            get { return overtimeapplicableyn; }
            set { overtimeapplicableyn = value; }
        }

        private static string calculatefor;
        public string CalculateFor
        {
            get { return calculatefor; }
            set { calculatefor = value; }
        }

        private static int flexiblehoursflag;
        public int FlexibleHoursFlag
        {
            get { return flexiblehoursflag; }
            set { flexiblehoursflag = value; }
        }

        private static string flexiblehoursflagyesno;
        public string FlexibleHoursFlagYesNo
        {
            get { return flexiblehoursflagyesno; }
            set { flexiblehoursflagyesno = value; }
        }

        private static int leaves;
        public int Leaves
        {
            get { return leaves; }
            set { leaves = value; }
        }

        private static string leavecountdesignation;
        public string LeaveCountDesignation
        {
            get { return leavecountdesignation; }
            set { leavecountdesignation = value; }
        }

        private static int otapplicable;
        public int OTApplicable
        {
            get { return otapplicable; }
            set { otapplicable = value; }
        }

        private static string grade;
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        //Contractor  Master
        //private static int leaveid;
        //public int LeaveId
        //{
        //    get { return leaveid; }
        //    set { leaveid = value; }
        //}

        //private static string leavename;
        //public string LeaveName
        //{
        //    get { return leavename; }
        //    set { leavename = value; }
        //}

        //Contractor Master

        //ContractorId int PK 
        //RegisterNo varchar(200) 
        //ContractorName varchar(500) 
        //Address text 
        //AreaId int 
        //ProprietorName varchar(200) 
        //MobileNumber bigint 
        //EmailId varchar(100) 
        //JoiningDate date 
        //GSTIN varchar(20) 
        //PFIstablishmentId varchar(100) 
        //ESICEstablishmentId varchar(100) 
        //PTRCNo varchar(100) 
        //PTECNo varchar(100) 
        //ContractRenewalDate date 
        //LabourLicenseNo varchar(100) 
        //TotalEmployeeAsPerLicense varchar(100) 
        //UdyogAadharNo varchar(50) 
        //AadharNo varchar(50) 
        //PANCardNumber varchar(50) 
        //PaymentMode

        private static int contractorid;
        public int ContractorId
        {
            get { return contractorid; }
            set { contractorid = value; }
        }

        private static string registerno;
        public string RegisterNo
        {
            get { return registerno; }
            set { registerno = value; }
        }

        private static string vendornumber;
        public string VendorNumber
        {
            get { return vendornumber; }
            set { vendornumber = value; }
        }

        private static string contractorname;
        public string ContractorName
        {
            get { return contractorname; }
            set { contractorname = value; }
        }

        private static string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private static string proprietorname;
        public string ProprietorName
        {
            get { return proprietorname; }
            set { proprietorname = value; }
        }

        private static DateTime joiningdate;
        public DateTime JoiningDate
        {
            get { return joiningdate; }
            set { joiningdate = value; }
        }

        //private static string pfistablishmentid;
        //public string PFIstablishmentId
        //{
        //    get { return pfistablishmentid; }
        //    set { pfistablishmentid = value; }
        //}

        private static string ptrcno;
        public string PTRCNo
        {
            get { return ptrcno; }
            set { ptrcno = value; }
        }

        private static string ptecno;
        public string PTECNo
        {
            get { return ptecno; }
            set { ptecno = value; }
        }

        private static DateTime contractrenewaldate;
        public DateTime ContractRenewalDate
        {
            get { return contractrenewaldate; }
            set { contractrenewaldate = value; }
        }

        private static string labourlicenseno;
        public string LabourLicenseNo
        {
            get { return labourlicenseno; }
            set { labourlicenseno = value; }
        }

        private static string totalemployeeasperlicense;
        public string TotalEmployeeAsPerLicense
        {
            get { return totalemployeeasperlicense; }
            set { totalemployeeasperlicense = value; }
        }

        private static string udyogaadharno;
        public string UdyogAadharNo
        {
            get { return udyogaadharno; }
            set { udyogaadharno = value; }
        }

        private static string aadharno;
        public string AadharNo
        {
            get { return aadharno; }
            set { aadharno = value; }
        }

        private static string pancardnumber;
        public string PANCardNumber
        {
            get { return pancardnumber; }
            set { pancardnumber = value; }
        }

        private static string paymentmode;
        public string PaymentMode
        {
            get { return paymentmode; }
            set { paymentmode = value; }
        }

        //Department Master
        private static int departmentid;
        public int DepartmentId
        {
            get { return departmentid; }
            set { departmentid = value; }
        }

        private static int approvalstatusid;
        public int ApprovalStatusId
        {
            get { return approvalstatusid; }
            set { approvalstatusid = value; }
        }

        private static string inchargename;
        public string InchargeName
        {
            get { return inchargename; }
            set { inchargename = value; }
        }

        private static string hrname;
        public string HRName
        {
            get { return hrname; }
            set { hrname = value; }
        }

        private static string plantheadname;
        public string PlantHeadName
        {
            get { return plantheadname; }
            set { plantheadname = value; }
        }

        private static string department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        //Holiday Master

        private static int holidayid;
        public int HolidayId
        {
            get { return holidayid; }
            set { holidayid = value; }
        }

        private static DateTime holidaydate;
        public DateTime HolidayDate
        {
            get { return holidaydate; }
            set { holidaydate = value; }
        }

        private static string holidayday;
        public string HolidayDay
        {
            get { return holidayday; }
            set { holidayday = value; }
        }

        private static string festival;
        public string Festival
        {
            get { return festival; }
            set { festival = value; }
        }

        private static string compoffreason;
        public string CompOffReason
        {
            get { return compoffreason; }
            set { compoffreason = value; }
        }

        private static string workremarks;
        public string WorkRemarks
        {
            get { return workremarks; }
            set { workremarks = value; }
        }

        private static int nationalholidayflag;
        public int NationalHolidayFlag
        {
            get { return nationalholidayflag; }
            set { nationalholidayflag = value; }
        }

        // private static string emailid;
        //public string EmailId
        // {
        //     get { return emailid; }
        //     set { emailid = value; }
        // }

        //private static string extensionno;
        //public string ExtensionNo
        // {
        //     get { return extensionno; }
        //     set { extensionno = value; }
        // }

        //Report Data

        private static int reporttableid;
        public int ReportTableId
        {
            get { return reporttableid; }
            set { reporttableid = value; }
        }

        private static string columnnames;
        public string ColumnNames
        {
            get { return columnnames; }
            set { columnnames = value; }
        }


        private static string totaldays;
        public string TotalDays
        {
            get { return totaldays; }
            set { totaldays = value; }
        }

        private static string totalpresent;
        public string TotalPresent
        {
            get { return totalpresent; }
            set { totalpresent = value; }
        }

        private static string totalabsent;
        public string TotalAbsent
        {
            get { return totalabsent; }
            set { totalabsent = value; }
        }

        private static string totalduration;
        public string TotalDuration
        {
            get { return totalduration; }
            set { totalduration = value; }
        }

        private static string totallate;
        public string TotalLate
        {
            get { return totallate; }
            set { totallate = value; }
        }

        //private static string totaldays;
        //public string TotalDays
        //{
        //    get { return totaldays; }
        //    set { totaldays = value; }
        //}

        private static string totalot;
        public string TotalOT
        {
            get { return totalot; }
            set { totalot = value; }
        }

        private static int monthnumber;
        public int MonthNumber
        {
            get { return monthnumber; }
            set { monthnumber = value; }
        }

        //private static int monthnumber;
        //public int MonthNumber
        //{
        //    get { return monthnumber; }
        //    set { monthnumber = value; }
        //}

        private static int monthyear;
        public int MonthYear
        {
            get { return monthyear; }
            set { monthyear = value; }
        }

        //Employee Master

        private static int employeeid;
        public int EmployeeId
        {
            get { return employeeid; }
            set { employeeid = value; }
        }

        private static int esslLemployeeid;
        public int ESSLEmployeeId
        {
            get { return esslLemployeeid; }
            set { esslLemployeeid = value; }
        }

        private static DateTime attendancedate;
        public DateTime AttendanceDate
        {
            get { return attendancedate; }
            set { attendancedate = value; }
        }

        public void ClearAttendanceRecords()
        {
            OutDoorEntryFlag = 0;
            AttendanceRecordId = 0;
            AttendanceRecordMasterId = 0;
            AttendanceHistoryId = 0;
            EsslAttendanceLogsId = 0;
            EmployeeId = 0;
            ShiftId = 0;
            ShiftGroupId = 0;
            InTime = DateTime.Now;
            OutTime = DateTime.Now;
            Duration = "";
            OverTime = "";
            TotalDuration = "";
            StatusCode = "";
            LateBy = 0;
            EarlyBy = 0;
            MissedInPunch = 0;
            MissedOutPunch = 0;
            ChangeDepartmentFlag = 0;
            ChangeDepartmentId = 0;
            ChangeLocationtId = 0;
            LeaveTypeId = 0;
            LeaveDuration = 0;
            WeeklyOff = 0;
            Holiday = 0;
            LeaveRemarks = "";
            PunchRecords = "";
            LossOfHours = 0;
            Present = 0;
            Absent = 0;
            Remarks = "";
            EditFlag = 0;
            OverTimeManualFlag = 0;
            RemarksReply = "";
        }

        private static int otapprovalflag;
        public int OTApprovalFlag
        {
            get { return otapprovalflag; }
            set { otapprovalflag = value; }
        }

        private static string attendanceday;
        public string AttendanceDay
        {
            get { return attendanceday; }
            set { attendanceday = value; }
        }

        private static int amonth;
        public int AMonth
        {
            get { return amonth; }
            set { amonth = value; }
        }


        private static int ayear;
        public int AYear
        {
            get { return ayear; }
            set { ayear = value; }
        }

        private static string empinital;
        public string EmpInital
        {
            get { return empinital; }
            set { empinital = value; }
        }

        private static string employeename;
        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; }
        }

        private static string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private static DateTime dob;
        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        private static int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private static string maritalstatus;
        public string MaritalStatus
        {
            get { return maritalstatus; }
            set { maritalstatus = value; }
        }

        private static DateTime marriagedate;
        public DateTime MarriageDate
        {
            get { return marriagedate; }
            set { marriagedate = value; }
        }

        private static string personalemailid;
        public string PersonalEmailID
        {
            get { return personalemailid; }
            set { personalemailid = value; }
        }

        private static string mobileno;
        public string MobileNo
        {
            get { return mobileno; }
            set { mobileno = value; }
        }

        private static string officialemailid;
        public string OfficialEmailID
        {
            get { return officialemailid; }
            set { officialemailid = value; }
        }

        private static string bloodgroup;
        public string BloodGroup
        {
            get { return bloodgroup; }
            set { bloodgroup = value; }
        }


        private static string aadharcardnumber;
        public string AadharCardNumber
        {
            get { return aadharcardnumber; }
            set { aadharcardnumber = value; }
        }

        //private static string pancardnumber;
        //public string PanCardNumber
        //{
        //    get { return pancardnumber; }
        //    set { pancardnumber = value; }
        //}

        private static string fathername;
        public string FatherName
        {
            get { return fathername; }
            set { fathername = value; }
        }

        private static string mothername;
        public string MotherName
        {
            get { return mothername; }
            set { mothername = value; }
        }

        private static string drivinglicensenumber;
        public string DrivingLicenseNumber
        {
            get { return drivinglicensenumber; }
            set { drivinglicensenumber = value; }
        }

        private static string personalidentificationmark;
        public string PersonalIdentificationMark
        {
            get { return personalidentificationmark; }
            set { personalidentificationmark = value; }
        }

        private static int physicaldisability;
        public int PhysicalDisability
        {
            get { return physicaldisability; }
            set { physicaldisability = value; }
        }

        private static string descriptionofphysicaldisability;
        public string DescriptionOfPhysicalDisability
        {
            get { return descriptionofphysicaldisability; }
            set { descriptionofphysicaldisability = value; }
        }

        private static DateTime doj;
        public DateTime DOJ
        {
            get { return doj; }
            set { doj = value; }
        }

        private static string totalyearsservice;
        public string TotalYearsService
        {
            get { return totalyearsservice; }
            set { totalyearsservice = value; }
        }

        //private static int contractorid;
        //public int ContractorId
        //{
        //    get { return contractorid; }
        //    set { contractorid = value; }
        //}

        //private static int employementtypeid;
        //public int EmployementTypeId
        //{
        //    get { return employementtypeid; }
        //    set { employementtypeid = value; }
        //}

        //private static int departmentid;
        //public int DepartmentId
        //{
        //    get { return departmentid; }
        //    set { departmentid = value; }
        //}

        //private static int designationid;
        //public int DesignationId
        //{
        //    get { return designationid; }
        //    set { designationid = value; }
        //}

        private static string jobprofile;
        public string JobProfile
        {
            get { return jobprofile; }
            set { jobprofile = value; }
        }

        private static string jobprofilefilename;
        public string JobProfileFileName
        {
            get { return jobprofilefilename; }
            set { jobprofilefilename = value; }
        }

        private static int categoryid;
        public int CategoryId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }

        private static int jobprofileid;
        public int JobProfileId
        {
            get { return jobprofileid; }
            set { jobprofileid = value; }
        }

        //Memo

        private static string memosubject;
        public string MemoSubject
        {
            get { return memosubject; }
            set { memosubject = value; }
        }

        private static string lettertype;
        public string LetterType
        {
            get { return lettertype; }
            set { lettertype = value; }
        }

        private static string letterdata;
        public string LetterData
        {
            get { return letterdata; }
            set { letterdata = value; }
        }

        private static int memofine;
        public int MemoFine
        {
            get { return memofine; }
            set { memofine = value; }
        }

        private static int memocount;
        public int MemoCount
        {
            get { return memocount; }
            set { memocount = value; }
        }

        private static string memotemplate;
        public string MemoTemplate
        {
            get { return memotemplate; }
            set { memotemplate = value; }
        }

        private static int memotemplateid;
        public int MemoTemplateMasterId
        {
            get { return memotemplateid; }
            set { memotemplateid = value; }
        }

        private static int memoid;
        public int MemoId
        {
            get { return memoid; }
            set { memoid = value; }
        }


        //private static int LocationId;
        // public int LocationId
        // {
        //     get { return categoryid; }
        //     set { categoryid = value; }
        // }

        private static int reportingto;
        public int ReportingTo
        {
            get { return reportingto; }
            set { reportingto = value; }
        }

        private static string nationality;
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        //private static int areaid;
        //public int AreaId
        //{
        //    get { return areaid; }
        //    set { areaid = value; }
        //}

        private static int policestationid;
        public int PoliceStationId
        {
            get { return policestationid; }
            set { policestationid = value; }
        }

        private static int sameaspa;
        public int SameAsPA
        {
            get { return sameaspa; }
            set { sameaspa = value; }
        }

        private static string address1;
        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        private static int areaid1;
        public int AreaId1
        {
            get { return areaid1; }
            set { areaid1 = value; }
        }
        private static int policestationid1;
        public int PoliceStationId1
        {
            get { return policestationid1; }
            set { policestationid1 = value; }
        }

        private static DateTime dor;
        public DateTime DOR
        {
            get { return dor; }
            set { dor = value; }
        }

        private static DateTime doc;
        public DateTime DOC
        {
            get { return doc; }
            set { doc = value; }
        }

        private static int employeecodeindevice;
        public int EmployeeCodeInDevice
        {
            get { return employeecodeindevice; }
            set { employeecodeindevice = value; }
        }

        private static string employeerfidnumber;
        public string EmployeeRFIDNumber
        {
            get { return employeerfidnumber; }
            set { employeerfidnumber = value; }
        }

        private static string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private static bool attendanceeditformflag;
        public bool EttendanceEditFormFlag
        {
            get { return attendanceeditformflag; }
            set { attendanceeditformflag = value; }
        }

        private static string reply;
        public string Reply
        {
            get { return reply; }
            set { reply = value; }
        }

        private static int recordstatus;
        public int RecordStatus
        {
            get { return recordstatus; }
            set { recordstatus = value; }
        }

        private static string employeedevicegroup;
        public string EmployeeDeviceGroup
        {
            get { return employeedevicegroup; }
            set { employeedevicegroup = value; }
        }

        private static int shiftgroupid;
        public int ShiftGroupId
        {
            get { return shiftgroupid; }
            set { shiftgroupid = value; }
        }

        private static string shiftgroup;
        public string ShiftGroup
        {
            get { return shiftgroup; }
            set { shiftgroup = value; }
        }

        private static int shiftgroupshiftid;
        public int ShiftGroupShiftId
        {
            get { return shiftgroupshiftid; }
            set { shiftgroupshiftid = value; }
        }

        private static int deviceid;
        public int DeviceId
        {
            get { return deviceid; }
            set { deviceid = value; }
        }

        private static int geofenceid;
        public int GeofenceId
        {
            get { return geofenceid; }
            set { geofenceid = value; }
        }

        private static int employeefamilyid;
        public int EmployeeFamilyId
        {
            get { return employeefamilyid; }
            set { employeefamilyid = value; }
        }



        private static string membername;
        public string MemberName
        {
            get { return membername; }
            set { membername = value; }
        }

        private static string relationship;
        public string Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        private static string familydetailsgender;
        public string FamilyGender
        {
            get { return familydetailsgender; }
            set { familydetailsgender = value; }
        }

        private static DateTime memberdob;
        public DateTime MemberDOB
        {
            get { return memberdob; }
            set { memberdob = value; }
        }

        private static string isresidingwith;
        public string IsResidingWith
        {
            get { return isresidingwith; }
            set { isresidingwith = value; }
        }



        private static string isdependentonyou;
        public string IsDependentOnYou
        {
            get { return isdependentonyou; }
            set { isdependentonyou = value; }
        }

        private static string memberpancard;
        public string MemberPANCard
        {
            get { return memberpancard; }
            set { memberpancard = value; }
        }

        private static string memberaadharcard;
        public string MemberAadharCard
        {
            get { return memberaadharcard; }
            set { memberaadharcard = value; }
        }

        private static string membercontactno;
        public string MemberContactNo
        {
            get { return membercontactno; }
            set { membercontactno = value; }
        }

        private static string isprimarynominee;
        public string IsPrimaryNominee
        {
            get { return isprimarynominee; }
            set { isprimarynominee = value; }
        }

        private static string nomineename;
        public string NomineeName
        {
            get { return nomineename; }
            set { nomineename = value; }
        }
        private static string nomineerelationship;
        public string NomineeRelationship
        {
            get { return nomineerelationship; }
            set { nomineerelationship = value; }
        }

        private static string nomineeaddress;
        public string NomineeAddress
        {
            get { return nomineeaddress; }
            set { nomineeaddress = value; }
        }

        private static DateTime nomineedob;
        public DateTime NomineeDOB
        {
            get { return nomineedob; }
            set { nomineedob = value; }
        }

        private static string nomineecontactno;
        public string NomineeContactNo
        {
            get { return nomineecontactno; }
            set { nomineecontactno = value; }
        }

        private static string nomineefor;
        public string NomineeFor
        {
            get { return nomineefor; }
            set { nomineefor = value; }
        }

        private static string nomineebankname;
        public string NomineeBankName
        {
            get { return nomineebankname; }
            set { nomineebankname = value; }
        }

        private static string nomineeaccountno;
        public string NomineeAccountNo
        {
            get { return nomineeaccountno; }
            set { nomineeaccountno = value; }
        }

        private static string nomineeifsccode;
        public string NomineeIFSCCode
        {
            get { return nomineeifsccode; }
            set { nomineeifsccode = value; }
        }

        private static string nomineemicrcode;
        public string NomineeMICRCode
        {
            get { return nomineemicrcode; }
            set { nomineemicrcode = value; }
        }

        private static string emergancycontactname;
        public string EmergancyContactName
        {
            get { return emergancycontactname; }
            set { emergancycontactname = value; }
        }

        private static string emergancycontactmobilenumber;
        public string EmergancyContactMobileNumber
        {
            get { return emergancycontactmobilenumber; }
            set { emergancycontactmobilenumber = value; }
        }

        private static string emergancycontactworkphone;
        public string EmergancyContactWorkPhone
        {
            get { return emergancycontactworkphone; }
            set { emergancycontactworkphone = value; }
        }

        private static string emergancycontactrelationship;
        public string EmergancyContactRelationship
        {
            get { return emergancycontactrelationship; }
            set { emergancycontactrelationship = value; }
        }

        private static string emergancycontacthomephone;
        public string EmergancyContactHomePhone
        {
            get { return emergancycontacthomephone; }
            set { emergancycontacthomephone = value; }
        }

        private static int employeequalificationid;
        public int EmployeeQualificationId
        {
            get { return employeequalificationid; }
            set { employeequalificationid = value; }
        }

        private static string qualification;
        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        private static string stream;
        public string Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        private static string college;
        public string College
        {
            get { return college; }
            set { college = value; }
        }


        private static string university;
        public string University
        {
            get { return university; }
            set { university = value; }
        }

        private static int yearofpassing;
        public int YearOfPassing
        {
            get { return yearofpassing; }
            set { yearofpassing = value; }
        }

        private static string gradequalification;
        public string GradeQualification
        {
            get { return gradequalification; }
            set { gradequalification = value; }
        }
        // Employee Experience

        private static int employeeexperienceid;
        public int EmployeeExperienceId
        {
            get { return employeeexperienceid; }
            set { employeeexperienceid = value; }
        }

        private static string organizationnameexperience;
        public string OrganizationNameExperience
        {
            get { return organizationnameexperience; }
            set { organizationnameexperience = value; }
        }

        private static string organizationaddressexperience;
        public string OrganizationAddressExperience
        {
            get { return organizationaddressexperience; }
            set { organizationaddressexperience = value; }
        }

        private static DateTime startdate;
        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        private static DateTime enddate;
        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        private static string designationexperience;
        public string DesignationExperience
        {
            get { return designationexperience; }
            set { designationexperience = value; }
        }

        private static string grosssalarypreviousexperience;
        public string GrossSalaryPreviousExperience
        {
            get { return grosssalarypreviousexperience; }
            set { grosssalarypreviousexperience = value; }
        }



        private static string qualificationeducation;
        public string QualificationEducation
        {
            get { return qualificationeducation; }
            set { qualificationeducation = value; }
        }

        private static string qualificationspeciazation;
        public string QualificationSpeciazation
        {
            get { return qualificationspeciazation; }
            set { qualificationspeciazation = value; }
        }

        private static DateTime qualificationstartdate;
        public DateTime QualificationStartDate
        {
            get { return qualificationstartdate; }
            set { qualificationstartdate = value; }
        }

        private static DateTime qualificationenddate;
        public DateTime QualificationEndDate
        {
            get { return qualificationenddate; }
            set { qualificationenddate = value; }
        }

        private static string qualificationscoreclass;
        public string QualificationScoreClass
        {
            get { return qualificationscoreclass; }
            set { qualificationscoreclass = value; }
        }

        private static string qualificationyear;
        public string QualificationYear
        {
            get { return qualificationyear; }
            set { qualificationyear = value; }
        }

        private static string qualificationremarks;
        public string QualificationRemarks
        {
            get { return qualificationremarks; }
            set { qualificationremarks = value; }
        }

        private static string experienceemployer;
        public string ExperienceEmployer
        {
            get { return experienceemployer; }
            set { experienceemployer = value; }
        }

        private static string experiencebranch;
        public string ExperienceBranch
        {
            get { return experiencebranch; }
            set { experiencebranch = value; }
        }

        private static string experiencelocation;
        public string ExperienceLocation
        {
            get { return experiencelocation; }
            set { experiencelocation = value; }
        }

        private static string experiencedesignation;
        public string ExperienceDesignation
        {
            get { return experiencedesignation; }
            set { experiencedesignation = value; }
        }

        private static string experiencectc;
        public string ExperienceCTC
        {
            get { return experiencectc; }
            set { experiencectc = value; }
        }

        private static string experiencegrosssalary;
        public string ExperienceGrossSalary
        {
            get { return experiencegrosssalary; }
            set { experiencegrosssalary = value; }
        }

        private static DateTime experiencestartdate;
        public DateTime ExperienceStartDate
        {
            get { return experiencestartdate; }
            set { experiencestartdate = value; }
        }

        private static DateTime experienceenddate;
        public DateTime ExperienceEndDate
        {
            get { return experienceenddate; }
            set { experienceenddate = value; }
        }

        private static string experiencemanager;
        public string ExperienceManager
        {
            get { return experiencemanager; }
            set { experiencemanager = value; }
        }

        private static string experiencemanagercontactno;
        public string ExperienceManagerContactNo
        {
            get { return experiencemanagercontactno; }
            set { experiencemanagercontactno = value; }
        }

        private static string experienceindustrytype;
        public string ExperienceIndustryType
        {
            get { return experienceindustrytype; }
            set { experienceindustrytype = value; }
        }

        private static string experienceremarks;
        public string ExperienceRemarks
        {
            get { return experienceremarks; }
            set { experienceremarks = value; }
        }

        private static string skilllanguage;
        public string SkillLanguage
        {
            get { return skilllanguage; }
            set { skilllanguage = value; }
        }

        private static string skillfluency;
        public string SkillFluency
        {
            get { return skillfluency; }
            set { skillfluency = value; }
        }

        private static string skillabilitywrite;
        public string SkillAbilityWrite
        {
            get { return skillabilitywrite; }
            set { skillabilitywrite = value; }
        }

        private static string skillabilityread;
        public string SkillAbilityRead
        {
            get { return skillabilityread; }
            set { skillabilityread = value; }
        }

        private static string skillabilityspeak;
        public string SkillAbilitySpeak
        {
            get { return skillabilityspeak; }
            set { skillabilityspeak = value; }
        }

        private static string skillabilityunderstand;
        public string SkillAbilityUnderstand
        {
            get { return skillabilityunderstand; }
            set { skillabilityunderstand = value; }
        }

        private static string skilltype;
        public string SkillType
        {
            get { return skilltype; }
            set { skilltype = value; }
        }

        private static int employeeskillid;
        public int EmployeeSkillId
        {
            get { return employeeskillid; }
            set { employeeskillid = value; }
        }

        private static string skills;
        public string Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        private static string yearsofexperience;
        public string YearsOfExperience
        {
            get { return yearsofexperience; }
            set { yearsofexperience = value; }
        }

        private static string comments;
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private static string costcenter;
        public string CostCenter
        {
            get { return costcenter; }
            set { costcenter = value; }
        }


        private static string salarymonthlybasic;
        public string SalaryMonthlyBasic
        {
            get { return salarymonthlybasic; }
            set { salarymonthlybasic = value; }
        }

        private static string salarymonthlyhra;
        public string SalaryMonthlyHRA
        {
            get { return salarymonthlyhra; }
            set { salarymonthlyhra = value; }
        }

        private static string salarymonthlyeducationallowance;
        public string SalaryMonthlyEducationAllowance
        {
            get { return salarymonthlyeducationallowance; }
            set { salarymonthlyeducationallowance = value; }
        }

        private static string salarymonthlyconveyanceallowance;
        public string SalaryMonthlyConveyanceAllowance
        {
            get { return salarymonthlyconveyanceallowance; }
            set { salarymonthlyconveyanceallowance = value; }
        }

        private static string salarymonthlyotherallowance;
        public string SalaryMonthlyOtherAllowance
        {
            get { return salarymonthlyotherallowance; }
            set { salarymonthlyotherallowance = value; }
        }

        private static string salarymonthlygrosssalary;
        public string SalaryMonthlyGrossSalary
        {
            get { return salarymonthlygrosssalary; }
            set { salarymonthlygrosssalary = value; }
        }

        private static string salaryMmonthlytaxdeducted;
        public string SalaryMonthlyTaxDeducted
        {
            get { return salaryMmonthlytaxdeducted; }
            set { salaryMmonthlytaxdeducted = value; }
        }

        private static string salarymonthlyprovidentfund;
        public string SalaryMonthlyProvidentFund
        {
            get { return salarymonthlyprovidentfund; }
            set { salarymonthlyprovidentfund = value; }
        }

        private static string salarymonthlynetsalary;
        public string SalaryMonthlyNetSalary
        {
            get { return salarymonthlynetsalary; }
            set { salarymonthlynetsalary = value; }
        }


        private static string salaryanualbasic;
        public string SalaryAnualBasic
        {
            get { return salaryanualbasic; }
            set { salaryanualbasic = value; }
        }

        private static string salaryanualhra;
        public string SalaryAnualHRA
        {
            get { return salaryanualhra; }
            set { salaryanualhra = value; }
        }

        private static string salaryanualeducationallowance;
        public string SalaryAnualEducationAllowance
        {
            get { return salaryanualeducationallowance; }
            set { salaryanualeducationallowance = value; }
        }

        private static string salaryanualconveyanceallowance;
        public string SalaryAnualConveyanceAllowance
        {
            get { return salaryanualconveyanceallowance; }
            set { salaryanualconveyanceallowance = value; }
        }

        private static string salaryanualotherallowance;
        public string SalaryAnualOtherAllowance
        {
            get { return salaryanualotherallowance; }
            set { salaryanualotherallowance = value; }
        }

        private static string salaryanualgrosssalary;
        public string SalaryAnualGrossSalary
        {
            get { return salaryanualgrosssalary; }
            set { salaryanualgrosssalary = value; }
        }

        private static string salaryanualtaxdeducted;
        public string SalaryAnualTaxDeducted
        {
            get { return salaryanualtaxdeducted; }
            set { salaryanualtaxdeducted = value; }
        }

        private static string salaryanualprovidentfund;
        public string SalaryAnualProvidentFund
        {
            get { return salaryanualprovidentfund; }
            set { salaryanualprovidentfund = value; }
        }

        private static string salaryanualnetsalary;
        public string SalaryAnualNetSalary
        {
            get { return salaryanualnetsalary; }
            set { salaryanualnetsalary = value; }
        }

        private static string salarypaymentmode;
        public string SalaryPaymentMode
        {
            get { return salarypaymentmode; }
            set { salarypaymentmode = value; }
        }

        private static string salarybank;
        public string SalaryBank
        {
            get { return salarybank; }
            set { salarybank = value; }
        }

        private static string salaryaccountno;
        public string SalaryAccountNo
        {
            get { return salaryaccountno; }
            set { salaryaccountno = value; }
        }

        private static string salarybranchname;
        public string SalaryBranchName
        {
            get { return salarybranchname; }
            set { salarybranchname = value; }
        }


        private static string salarymicrno;
        public string SalaryMICRNo
        {
            get { return salarymicrno; }
            set { salarymicrno = value; }
        }

        private static string salaryifsccode;
        public string SalaryIFSCCode
        {
            get { return salaryifsccode; }
            set { salaryifsccode = value; }
        }

        private static string salarypaymentmode1;
        public string SalaryPaymentMode1
        {
            get { return salarypaymentmode1; }
            set { salarypaymentmode1 = value; }
        }

        private static string salarybank1;
        public string SalaryBank1
        {
            get { return salarybank1; }
            set { salarybank1 = value; }
        }

        private static string salaryaccountno1;
        public string SalaryAccountNo1
        {
            get { return salaryaccountno1; }
            set { salaryaccountno1 = value; }
        }

        private static string salarybranchname1;
        public string SalaryBranchName1
        {
            get { return salarybranchname1; }
            set { salarybranchname1 = value; }
        }

        private static string salarymicrno1;
        public string SalaryMICRNo1
        {
            get { return salarymicrno1; }
            set { salarymicrno1 = value; }
        }

        private static string salaryifsccode1;
        public string SalaryIFSCCode1
        {
            get { return salaryifsccode1; }
            set { salaryifsccode1 = value; }
        }


        private static string pememberidno;
        public string PFMemberIDNo
        {
            get { return pememberidno; }
            set { pememberidno = value; }
        }

        private static string uannumber;
        public string UANNumber
        {
            get { return uannumber; }
            set { uannumber = value; }
        }

        private static string esicno;
        public string ESICNo
        {
            get { return esicno; }
            set { esicno = value; }
        }

        private static string lwflinno;
        public string LWFLINNo
        {
            get { return lwflinno; }
            set { lwflinno = value; }
        }

        private static string passporttype;
        public string PassportType
        {
            get { return passporttype; }
            set { passporttype = value; }
        }

        private static string passportno;
        public string PassportNo
        {
            get { return passportno; }
            set { passportno = value; }
        }

        private static DateTime issuesdate;
        public DateTime IssuesDate
        {
            get { return issuesdate; }
            set { issuesdate = value; }
        }

        private static DateTime renewaldate;
        public DateTime RenewalDate
        {
            get { return renewaldate; }
            set { renewaldate = value; }
        }

        private static DateTime dateofexpiry;
        public DateTime DateOfExpiry
        {
            get { return dateofexpiry; }
            set { dateofexpiry = value; }
        }

        private static string citizenship;
        public string Citizenship
        {
            get { return citizenship; }
            set { citizenship = value; }
        }

        private static DateTime dateofjoining;
        public DateTime DateOfJoining
        {
            get { return dateofjoining; }
            set { dateofjoining = value; }
        }

        private static DateTime confirmdate;
        public DateTime ConfirmDate
        {
            get { return confirmdate; }
            set { confirmdate = value; }
        }

        private static DateTime pfstartdate;
        public DateTime PFStartDate
        {
            get { return pfstartdate; }
            set { pfstartdate = value; }
        }

        private static DateTime dateofretirement;
        public DateTime DateOfRetirement
        {
            get { return dateofretirement; }
            set { dateofretirement = value; }
        }

        private static DateTime dateofexit;
        public DateTime DateOfExit
        {
            get { return dateofexit; }
            set { dateofexit = value; }
        }

        private static DateTime a1;
        public DateTime A1
        {
            get { return a1; }
            set { a1 = value; }
        }

        private static DateTime a2;
        public DateTime A2
        {
            get { return a2; }
            set { a2 = value; }
        }

        private static DateTime a3;
        public DateTime A3
        {
            get { return a3; }
            set { a3 = value; }
        }

        //Employee Master Opening Leave
        private static string openingleave;
        public string OpeningLeave
        {
            get { return openingleave; }
            set { openingleave = value; }
        }

        private static string totalleave;
        public string TotalLeave
        {
            get { return totalleave; }
            set { totalleave = value; }
        }

        private static double openingleave_count;
        public double OpeningLeave_Count
        {
            get { return openingleave_count; }
            set { openingleave_count = value; }
        }

        private static double totalleave_count;
        public double TotalLeave_Count
        {
            get { return totalleave_count; }
            set { totalleave_count = value; }
        }

        private static double balance_count;
        public double Balance_Count
        {
            get { return balance_count; }
            set { balance_count = value; }
        }

        private static double paidleave_count;
        public double PaidLeave_Count
        {
            get { return paidleave_count; }
            set { paidleave_count = value; }
        }

        private static double specialleave_count;
        public double SpecialLeave_Count
        {
            get { return specialleave_count; }
            set { specialleave_count = value; }
        }

        private static double currentleaves_count;
        public double CurrentLeave_Count
        {
            get { return currentleaves_count; }
            set { currentleaves_count = value; }
        }

        private static double totalapplicableLeave_count;
        public double TotalApplicableLeave_Count
        {
            get { return totalapplicableLeave_count; }
            set { totalapplicableLeave_count = value; }
        }

        private static double enjoyLeave_count;
        public double EnjoyLeave_Count
        {
            get { return enjoyLeave_count; }
            set { enjoyLeave_count = value; }
        }

        private static double revertleave_count;
        public double RevertLeave_Count
        {
            get { return revertleave_count; }
            set { revertleave_count = value; }
        }

        private static double compoff_count;
        public double CompOff_Count
        {
            get { return compoff_count; }
            set { compoff_count = value; }
        }

        private static double compoffused_count;
        public double CompOffUsed_Count
        {
            get { return compoffused_count; }
            set { compoffused_count = value; }
        }

        private static double compoffexpired_count;
        public double CompOffExpired_Count
        {
            get { return compoffexpired_count; }
            set { compoffexpired_count = value; }
        }

        //ExpiredCount

        private static double compoffbalance_count;
        public double CompOffBalance_Count
        {
            get { return compoffbalance_count; }
            set { compoffbalance_count = value; }
        }

        private static double compoffusedbalance_count;
        public double CompOffUsedBalance_Count
        {
            get { return compoffusedbalance_count; }
            set { compoffusedbalance_count = value; }
        }

        //Shift Master

        private static int shiftid;
        public int ShiftId
        {
            get { return shiftid; }
            set { shiftid = value; }
        }

        private static string shiftfname;
        public string ShiftFName
        {
            get { return shiftfname; }
            set { shiftfname = value; }
        }

        private static string shiftsname;
        public string ShiftSName
        {
            get { return shiftsname; }
            set { shiftsname = value; }
        }

        private static string begintime;
        public string BeginTime
        {
            get { return begintime; }
            set { begintime = value; }
        }

        private static string endtime;
        public string EndTime
        {
            get { return endtime; }
            set { endtime = value; }
        }

        private static string timeintervalhours;
        public string TimeIntervalHours
        {
            get { return timeintervalhours; }
            set { timeintervalhours = value; }
        }

        private static string timeintervalminutes;
        public string TimeIntervalMinutes
        {
            get { return timeintervalminutes; }
            set { timeintervalminutes = value; }
        }

        private static int break1;
        public int Break1
        {
            get { return break1; }
            set { break1 = value; }
        }

        private static int break2;
        public int Break2
        {
            get { return break2; }
            set { break2 = value; }
        }

        private static string break1begintime;
        public string Break1BeginTime
        {
            get { return break1begintime; }
            set { break1begintime = value; }
        }

        private static string break2begintime;
        public string Break2BeginTime
        {
            get { return break2begintime; }
            set { break2begintime = value; }
        }

        private static string break1endtime;
        public string Break1EndTime
        {
            get { return break1endtime; }
            set { break1endtime = value; }
        }

        private static string break2endtime;
        public string Break2EndTime
        {
            get { return break2endtime; }
            set { break2endtime = value; }
        }


        private static int break1duration;
        public int Break1Duration
        {
            get { return break1duration; }
            set { break1duration = value; }
        }

        private static int break2duration;
        public int Break2Duration
        {
            get { return break2duration; }
            set { break2duration = value; }
        }

        private static int shifttype;
        public int ShiftType
        {
            get { return shifttype; }
            set { shifttype = value; }
        }

        private static int punchbeginduration;
        public int PunchBeginDuration
        {
            get { return punchbeginduration; }
            set { punchbeginduration = value; }
        }

        private static int isgraceTimeapplicable;
        public int IsGraceTimeApplicable
        {
            get { return isgraceTimeapplicable; }
            set { isgraceTimeapplicable = value; }
        }

        private static int punchendduration;
        public int PunchEndDuration
        {
            get { return punchendduration; }
            set { punchendduration = value; }
        }

        private static int gracetime;
        public int GraceTime
        {
            get { return gracetime; }
            set { gracetime = value; }
        }

        private static int ispartialdayapplicable;
        public int IsPartialDayApplicable
        {
            get { return ispartialdayapplicable; }
            set { ispartialdayapplicable = value; }
        }

        private static string partialday;
        public string PartialDay
        {
            get { return partialday; }
            set { partialday = value; }
        }

        private static string partialdaybegintime;
        public string PartialDayBeginTime
        {
            get { return partialdaybegintime; }
            set { partialdaybegintime = value; }
        }

        private static string partialdayendtime;
        public string PartialDayEndTime
        {
            get { return partialdayendtime; }
            set { partialdayendtime = value; }
        }

        private static string issflexibleshift;
        public string IsFlexibleShift
        {
            get { return issflexibleshift; }
            set { issflexibleshift = value; }
        }

        //User Righat

        private static int userrightsid;
        public int UserRightsId
        {
            get { return userrightsid; }
            set { userrightsid = value; }
        }

        private static string menuname;
        public string MenuName
        {
            get { return menuname; }
            set { menuname = value; }
        }

        private static int addflag;
        public int AddFlag
        {
            get { return addflag; }
            set { addflag = value; }
        }

        private static int editflagur;
        public int EditFlagUR
        {
            get { return editflagur; }
            set { editflagur = value; }
        }

        private static int deleteflagur;
        public int DeleteFlagUR
        {
            get { return deleteflagur; }
            set { deleteflagur = value; }
        }

        private static int viewflag;
        public int ViewFlag
        {
            get { return viewflag; }
            set { viewflag = value; }
        }

        private static int approvalflag;
        public int ApprovalFlag
        {
            get { return approvalflag; }
            set { approvalflag = value; }
        }


        //Leave Application

        private static int leaveapplicationid;
        public int LeaveApplicationId
        {
            get { return leaveapplicationid; }
            set { leaveapplicationid = value; }
        }

        private static int tempdepartmentwisedesignationattendancereportid;
        public int TempDepartmentWiseDesignationAttendanceReportId
        {
            get { return tempdepartmentwisedesignationattendancereportid; }
            set { tempdepartmentwisedesignationattendancereportid = value; }
        }

        private static string reporttype;
        public string ReportType
        {
            get { return reporttype; }
            set { reporttype = value; }
        }


        private static DateTime fromdate;
        public DateTime FromDate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }

        private static DateTime todate;
        public DateTime ToDate
        {
            get { return todate; }
            set { todate = value; }
        }

        private static string databasename;
        public string DatabaseName
        {
            get { return databasename; }
            set { databasename = value; }
        }



        private static string datatype;
        public string DataType
        {
            get { return datatype; }
            set { datatype = value; }
        }

        private static string leavetype;
        public string LeaveType
        {
            get { return leavetype; }
            set { leavetype = value; }
        }

        private static int leavetypeid;
        public int LeaveTypeId
        {
            get { return leavetypeid; }
            set { leavetypeid = value; }
        }

        private static int referancecompoffleaveapplicationid;
        public int ReferanceCompOffLeaveApplicationId
        {
            get { return referancecompoffleaveapplicationid; }
            set { referancecompoffleaveapplicationid = value; }
        }

        private static bool leavetypeflag;
        public bool LeaveTypeFlag
        {
            get { return leavetypeflag; }
            set { leavetypeflag = value; }
        }

        private static string leavereason;
        public string LeaveReason
        {
            get { return leavereason; }
            set { leavereason = value; }
        }

        private static string leavestatus;
        public string LeaveStatus
        {
            get { return leavestatus; }
            set { leavestatus = value; }
        }

        private static string remarks;
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private static string remarksreply;
        public string RemarksReply
        {
            get { return remarksreply; }
            set { remarksreply = value; }
        }

        private static string otremarks;
        public string OTRemarks
        {
            get { return otremarks; }
            set { otremarks = value; }
        }

        private static string otapprovalstatus;
        public string OTApprovalStatus
        {
            get { return otapprovalstatus; }
            set { otapprovalstatus = value; }
        }

        private static string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        private static string otreply;
        public string OTReply
        {
            get { return otreply; }
            set { otreply = value; }
        }
         

        private static int editflag;
        public int EditFlag
        {
            get { return editflag; }
            set { editflag = value; }
        }

        private static int editflagtemp;
        public int EditFlagTemp
        {
            get { return editflagtemp; }
            set { editflagtemp = value; }
        }

        private static int overtimemanualflag;
        public int OverTimeManualFlag
        {
            get { return overtimemanualflag; }
            set { overtimemanualflag = value; }
        }

        private static string balanceleave;
        public string BalanceLeave
        {
            get { return balanceleave; }
            set { balanceleave = value; }
        }

        private static string balanceleaveprevious;
        public string BalanceLeavePrevious
        {
            get { return balanceleaveprevious; }
            set { balanceleaveprevious = value; }
        }

        private static int compoffusedflag;
        public int CompOffUsedFlag
        {
            get { return compoffusedflag; }
            set { compoffusedflag = value; }
        }

        private static int compoffapplicationid;
        public int CompOffApplicationId
        {
            get { return compoffapplicationid; }
            set { compoffapplicationid = value; }
        }

        private static bool comoffflag;
        public bool CompOffFlag
        {
            get { return comoffflag; }
            set { comoffflag = value; }
        }

        private static DateTime compoffduedate;
        public DateTime CompOffDueDate
        {
            get { return compoffduedate; }
            set { compoffduedate = value; }
        }

        private static string compstatus;
        public string CompStatus
        {
            get { return compstatus; }
            set { compstatus = value; }
        }

        private static string compusedstatus;
        public string CompUsedStatus
        {
            get { return compusedstatus; }
            set { compusedstatus = value; }
        }


        private static DateTime compoffdate;
        public DateTime CompOffDate
        {
            get { return compoffdate; }
            set { compoffdate = value; }
        }

        private static string compoffday;
        public string CompOffDay
        {
            get { return compoffday; }
            set { compoffday = value; }
        }

        private static string holidaytype;
        public string HolidayType
        {
            get { return holidaytype; }
            set { holidaytype = value; }
        }

        private static DateTime usedcompoffdate;
        public DateTime UsedCompOffDate
        {
            get { return usedcompoffdate; }
            set { usedcompoffdate = value; }
        }

        private static string usedcompoffday;
        public string UsedCompOffDay
        {
            get { return usedcompoffday; }
            set { usedcompoffday = value; }
        }

        private static int isrevertleave;
        public int IsRevertLeave
        {
            get { return isrevertleave; }
            set { isrevertleave = value; }
        }

        private static int iscompensationoff;
        public int IsCompensationOff
        {
            get { return iscompensationoff; }
            set { iscompensationoff = value; }
        }

        //Approval Level

        private static int approvallevelid;
        public int ApprovalLevelId
        {
            get { return approvallevelid; }
            set { approvallevelid = value; }
        }

        private static string departmentid_s;
        public string DepartmentId_S
        {
            get { return departmentid_s; }
            set { departmentid_s = value; }
        }

        private static string inchargeId_s;
        public string InchargeId_S
        {
            get { return inchargeId_s; }
            set { inchargeId_s = value; }
        }

        private static int plantheadid;
        public int PlantHeadId
        {
            get { return plantheadid; }
            set { plantheadid = value; }
        }

        private static int hrapprovalid;
        public int HRApprovalId
        {
            get { return hrapprovalid; }
            set { hrapprovalid = value; }
        }

        //Categories

        private static string categoryfname;
        public string CategoryFName
        {
            get { return categoryfname; }
            set { categoryfname = value; }
        }

        private static string categorysname;
        public string CategorySName
        {
            get { return categorysname; }
            set { categorysname = value; }
        }

        private static string otformula;
        public string OTFormula
        {
            get { return otformula; }
            set { otformula = value; }
        }

        private static string minot;
        public string MinOT
        {
            get { return minot; }
            set { minot = value; }
        }

        private static int maxot;
        public int MaxOT
        {
            get { return maxot; }
            set { maxot = value; }
        }

        private static string maxotmin;
        public string MaxOTMin
        {
            get { return maxotmin; }
            set { maxotmin = value; }
        }

        private static int consideronlyfirstandlastpunchinattcalculations;
        public int ConsiderOnlyFirstAndLastPunchInAttCalculations
        {
            get { return consideronlyfirstandlastpunchinattcalculations; }
            set { consideronlyfirstandlastpunchinattcalculations = value; }
        }

        private static string gracetimeforLatecomingmins;
        public string GraceTimeForLateComingMins
        {
            get { return gracetimeforLatecomingmins; }
            set { gracetimeforLatecomingmins = value; }
        }

        private static int neglectLastinpunchformissedoutpunch;
        public int NeglectLastInPunchForMissedOutPunch
        {
            get { return neglectLastinpunchformissedoutpunch; }
            set { neglectLastinpunchformissedoutpunch = value; }
        }


        private static string gracetimeforearlygoingmins;
        public string GraceTimeForEarlyGoingMins
        {
            get { return gracetimeforearlygoingmins; }
            set { gracetimeforearlygoingmins = value; }
        }


        private static int weeklyoff1;
        public int WeeklyOff1
        {
            get { return weeklyoff1; }
            set { weeklyoff1 = value; }
        }

        private static string weeklyoff1value;
        public string WeeklyOff1Value
        {
            get { return weeklyoff1value; }
            set { weeklyoff1value = value; }
        }

        private static int weeklyoff2;
        public int WeeklyOff2
        {
            get { return weeklyoff2; }
            set { weeklyoff2 = value; }
        }

        private static string weeklyoff2value;
        public string WeeklyOff2Value
        {
            get { return weeklyoff2value; }
            set { weeklyoff2value = value; }
        }

        private static int firstr;
        public int FirstR
        {
            get { return firstr; }
            set { firstr = value; }
        }

        private static int secondr;
        public int SecondR
        {
            get { return secondr; }
            set { secondr = value; }
        }

        private static int thirdr;
        public int ThirdR
        {
            get { return thirdr; }
            set { thirdr = value; }
        }

        private static int forthr;
        public int ForthR
        {
            get { return forthr; }
            set { forthr = value; }
        }

        private static int fiver;
        public int FiveR
        {
            get { return fiver; }
            set { fiver = value; }
        }

        private static int considerearlycomingpunch;
        public int ConsiderEarlyComingPunch
        {
            get { return considerearlycomingpunch; }
            set { considerearlycomingpunch = value; }
        }

        private static int considerlategoingpunch;
        public int ConsiderLateGoingPunch
        {
            get { return considerlategoingpunch; }
            set { considerlategoingpunch = value; }
        }

        private static int deductbreakhoursformworkduration;
        public int DeductBreakHoursFormWorkDuration
        {
            get { return deductbreakhoursformworkduration; }
            set { deductbreakhoursformworkduration = value; }
        }

        private static int calculateHalfdayifworkdurationislessthan;
        public int CalculateHalfDayifWorkDurationIsLessThan
        {
            get { return calculateHalfdayifworkdurationislessthan; }
            set { calculateHalfdayifworkdurationislessthan = value; }
        }

        private static string calculatehalfdayifworkdurationislessthanmins;
        public string CalculateHalfDayifWorkDurationIsLessThanMins
        {
            get { return calculatehalfdayifworkdurationislessthanmins; }
            set { calculatehalfdayifworkdurationislessthanmins = value; }
        }

        private static int calculationabsentifworkdurationislessthan;
        public int CalculationAbsentIfWorkDurationIsLessThan
        {
            get { return calculationabsentifworkdurationislessthan; }
            set { calculationabsentifworkdurationislessthan = value; }
        }

        private static string calculationabsentifworkdurationislessthanmins;
        public string CalculationAbsentIfWorkDurationIsLessThanMins
        {
            get { return calculationabsentifworkdurationislessthanmins; }
            set { calculationabsentifworkdurationislessthanmins = value; }
        }

        private static int onpartialdaycalculatehalfdayifworkdurationislessthan;
        public int OnPartialDayCalculateHalfDayifWorkDurationisLessThan
        {
            get { return onpartialdaycalculatehalfdayifworkdurationislessthan; }
            set { onpartialdaycalculatehalfdayifworkdurationislessthan = value; }
        }

        private static string onpartialdaycalculatehalfdayifworkdurationislessthanmins;
        public string OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins
        {
            get { return onpartialdaycalculatehalfdayifworkdurationislessthanmins; }
            set { onpartialdaycalculatehalfdayifworkdurationislessthanmins = value; }
        }

        private static int onpartialdaycalculateabsentdayifworkdurationislessthan;
        public int OnPartialDayCalculateAbsentDayifWorkDurationislessThan
        {
            get { return onpartialdaycalculateabsentdayifworkdurationislessthan; }
            set { onpartialdaycalculateabsentdayifworkdurationislessthan = value; }
        }

        private static string onpartialdaycalculateabsentdayifworkdurationislessthanmins;
        public string OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins
        {
            get { return onpartialdaycalculateabsentdayifworkdurationislessthanmins; }
            set { onpartialdaycalculateabsentdayifworkdurationislessthanmins = value; }
        }


        private static int markweeklyoffandholidayasabsentifprefixdayisabsent;
        public int MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent
        {
            get { return markweeklyoffandholidayasabsentifprefixdayisabsent; }
            set { markweeklyoffandholidayasabsentifprefixdayisabsent = value; }
        }

        private static int markweeklyoffandholidayasabsentifsuffixdayisabsent;
        public int MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent
        {
            get { return markweeklyoffandholidayasabsentifsuffixdayisabsent; }
            set { markweeklyoffandholidayasabsentifsuffixdayisabsent = value; }
        }

        private static int mwohabsentifbothprefixandsuffixdayisabsent;
        public int MWOHAbsentifBothPrefixandSuffixDayisAbsent
        {
            get { return mwohabsentifbothprefixandsuffixdayisabsent; }
            set { mwohabsentifbothprefixandsuffixdayisabsent = value; }
        }

        private static int mark;
        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        private static string markvalue;
        public string MarkValue
        {
            get { return markvalue; }
            set { markvalue = value; }
        }

        private static string absentwhenlateforvalue;
        public string AbsentWhenLateForValue
        {
            get { return absentwhenlateforvalue; }
            set { absentwhenlateforvalue = value; }
        }

        private static int markhalfdayiflateby;
        public int MarkHalfDayifLateBy
        {
            get { return markhalfdayiflateby; }
            set { markhalfdayiflateby = value; }
        }

        private static string markhalfdayiflatebymins;
        public string MarkHalfDayifLateByMins
        {
            get { return markhalfdayiflatebymins; }
            set { markhalfdayiflatebymins = value; }
        }

        private static int markhalfdayifearlygoingby;
        public int MarkHalfDayifEarlyGoingBy
        {
            get { return markhalfdayifearlygoingby; }
            set { markhalfdayifearlygoingby = value; }
        }

        private static string markhalfdayifearlygoingbymins;
        public string MarkHalfDayifEarlyGoingByMins
        {
            get { return markhalfdayifearlygoingbymins; }
            set { markhalfdayifearlygoingbymins = value; }
        }

        // Attendance Class

        private static string attendancedata;
        public string AttendanceData
        {
            get { return attendancedata; }
            set { attendancedata = value; }
        }




        private static int completeflag;
        public int CompleteFlag
        {
            get { return completeflag; }
            set { completeflag = value; }
        }

        private static int attendancelogid;
        public int AttendanceLogId
        {
            get { return attendancelogid; }
            set { attendancelogid = value; }
        }

        private static int hrid;
        public int HRId
        {
            get { return hrid; }
            set { hrid = value; }
        }

        //private static int attendancerecordmasterid;
        //public int AttendanceRecordMasterId
        //{
        //    get { return attendancerecordmasterid; }
        //    set { attendancerecordmasterid = value; }
        //}

        //private static int attendancehistoryid;
        //public int AttendanceHistoryId
        //{
        //    get { return attendancehistoryid; }
        //    set { attendancehistoryid = value; }
        //}

        private static int ernnumber;
        public int ERNNumber
        {
            get { return ernnumber; }
            set { ernnumber = value; }
        }

        private static int employeecode;
        public int EmployeeCode
        {
            get { return employeecode; }
            set { employeecode = value; }
        }

        private static string employeeprofile;
        public string EmployeeProfile
        {
            get { return employeeprofile; }
            set { employeeprofile = value; }
        }

        private static DateTime intime;
        public DateTime InTime
        {
            get { return intime; }
            set { intime = value; }
        }

        private static string indeviceid;
        public string InDeviceId
        {
            get { return indeviceid; }
            set { indeviceid = value; }
        }
        private static DateTime outtime;
        public DateTime OutTime
        {
            get { return outtime; }
            set { outtime = value; }
        }

        private static TimeSpan outtime_ts;
        public TimeSpan OutTime_TS
        {
            get { return outtime_ts; }
            set { outtime_ts = value; }
        }

        private static DateTime leavedate;
        public DateTime LeaveDate
        {
            get { return leavedate; }
            set { leavedate = value; }
        }

        private static string outdeviceid;
        public string OutDeviceId
        {
            get { return outdeviceid; }
            set { outdeviceid = value; }
        }

        private static string duration;
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private static float duration_float;
        public float Duration_Float
        {
            get { return duration_float; }
            set { duration_float = value; }
        }

        private static double lateby;
        public double LateBy
        {
            get { return lateby; }
            set { lateby = value; }
        }
        private static double earlyby;
        public double EarlyBy
        {
            get { return earlyby; }
            set { earlyby = value; }
        }

        private static string isonleave;
        public string IsOnLeave
        {
            get { return isonleave; }
            set { isonleave = value; }
        }

        private static int leaveduration;
        public int LeaveDuration
        {
            get { return leaveduration; }
            set { leaveduration = value; }
        }
        private static int weeklyoff;
        public int WeeklyOff
        {
            get { return weeklyoff; }
            set { weeklyoff = value; }
        }
        private static int holiday;
        public int Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }

        private static string leaveremarks;
        public string LeaveRemarks
        {
            get { return leaveremarks; }
            set { leaveremarks = value; }
        }

        private static string punchrecords;
        public string PunchRecords
        {
            get { return punchrecords; }
            set { punchrecords = value; }
        }

        private static double present;
        public double Present
        {
            get { return present; }
            set { present = value; }
        }

        private static double absent;
        public double Absent
        {
            get { return absent; }
            set { absent = value; }
        }

        private static int changedepartmentflag;
        public int ChangeDepartmentFlag
        {
            get { return changedepartmentflag; }
            set { changedepartmentflag = value; }
        }

        //private static int changedepartmentid;
        //public int ChangeDepartmentId
        //{
        //    get { return changedepartmentid; }
        //    set { changedepartmentid = value; }
        //}

        private static int changelocationtid;
        public int ChangeLocationtId
        {
            get { return changelocationtid; }
            set { changelocationtid = value; }
        }

        private static string statuscode;
        public string StatusCode
        {
            get { return statuscode; }
            set { statuscode = value; }
        }

        private static string p1status;
        public string P1Status
        {
            get { return p1status; }
            set { p1status = value; }
        }

        private static string p2status;
        public string P2Status
        {
            get { return p2status; }
            set { p2status = value; }
        }
        private static string p3status;
        public string P3Status
        {
            get { return p3status; }
            set { p3status = value; }
        }

        private static string isonspecialoff;
        public string IsonSpecialOff
        {
            get { return isonspecialoff; }
            set { isonspecialoff = value; }
        }

        private static string specialoffyype;
        public string SpecialOffType
        {
            get { return specialoffyype; }
            set { specialoffyype = value; }
        }

        private static string specialoffremark;
        public string SpecialOffRemark
        {
            get { return specialoffremark; }
            set { specialoffremark = value; }
        }

        private static string specialoffduration;
        public string SpecialOffDuration
        {
            get { return specialoffduration; }
            set { specialoffduration = value; }
        }

        private static string overtime;
        public string OverTime
        {
            get { return overtime; }
            set { overtime = value; }
        }


        private static int overtimee;
        public int OverTimeE
        {
            get { return overtimee; }
            set { overtimee = value; }
        }

        private static int missedoutpunch;
        public int MissedOutPunch
        {
            get { return missedoutpunch; }
            set { missedoutpunch = value; }
        }

        private static int changedepartmentid;
        public int ChangeDepartmentId
        {
            get { return changedepartmentid; }
            set { changedepartmentid = value; }
        }

        private static string transferremarks;
        public string TransferRemarks
        {
            get { return transferremarks; }
            set { transferremarks = value; }
        }
        

        private static string changelocation;
        public string ChangeLocation
        {
            get { return changelocation; }
            set { changelocation = value; }
        }

        private static string changedepartment;
        public string ChangeDepartment
        {
            get { return changedepartment; }
            set { changedepartment = value; }
        }




        private static int missedinpunch;
        public int MissedInPunch
        {
            get { return missedinpunch; }
            set { missedinpunch = value; }
        }

        private static string c1;
        public string C1
        {
            get { return c1; }
            set { c1 = value; }
        }
        private static string c2;
        public string C2
        {
            get { return c2; }
            set { c2 = value; }
        }
        private static string c3;
        public string C3
        {
            get { return c3; }
            set { c3 = value; }
        }
        private static string c4;
        public string C4
        {
            get { return c4; }
            set { c4 = value; }
        }
        private static string c5;
        public string C5
        {
            get { return c5; }
            set { c5 = value; }
        }
        private static string c6;
        public string C6
        {
            get { return c6; }
            set { c6 = value; }
        }
        private static string c7;
        public string C7
        {
            get { return c7; }
            set { c7 = value; }
        }

        private static int lossofhours;
        public int LossOfHours
        {
            get { return lossofhours; }
            set { lossofhours = value; }
        }

        private static int attendancehistoryid;
        public int AttendanceHistoryId
        {
            get { return attendancehistoryid; }
            set { attendancehistoryid = value; }
        }

        private static int newempcount;
        public int NewEmpCount
        {
            get { return newempcount; }
            set { newempcount = value; }
        }

        private static int esslattendanceLogsid;
        public int EsslAttendanceLogsId
        {
            get { return esslattendanceLogsid; }
            set { esslattendanceLogsid = value; }
        }

        private static int attendanceid;
        public int AttendanceId
        {
            get { return attendanceid; }
            set { attendanceid = value; }
        }

        private static int attendancerecordid;
        public int AttendanceRecordId
        {
            get { return attendancerecordid; }
            set { attendancerecordid = value; }
        }

        private static int outdoorentryflag;
        public int OutDoorEntryFlag
        {
            get { return outdoorentryflag; }
            set { outdoorentryflag = value; }
        }

        

        private static int attendancerecordmasterid;
        public int AttendanceRecordMasterId
        {
            get { return attendancerecordmasterid; }
            set { attendancerecordmasterid = value; }
        }

        //private static string workduration;
        //public string WorkDuration
        //{
        //    get { return workduration; }
        //    set { workduration = value; }
        //}

        //private static string overtime_hours;
        //public string OverTime_Hours
        //{
        //    get { return overtime_hours; }
        //    set { overtime_hours = value; }
        //}

        private static TimeSpan totalduration_ts;
        public TimeSpan TotalDuration_TS
        {
            get { return totalduration_ts; }
            set { totalduration_ts = value; }
        }

        private static TimeSpan duration_ts;
        public TimeSpan Duration_TS
        {
            get { return duration_ts; }
            set { duration_ts = value; }
        }

        private static TimeSpan othours_ts;
        public TimeSpan OTHours_TS
        {
            get { return othours_ts; }
            set { othours_ts = value; }
        }

        private static double totalhours_double;
        public double TotalOTHours_Double
        {
            get { return totalhours_double; }
            set { totalhours_double = value; }
        }

        private static double durationothours_double;
        public double DurationOTHours_Double
        {
            get { return durationothours_double; }
            set { durationothours_double = value; }
        }

        private static double durationhours_double;
        public double DurationHours_Double
        {
            get { return durationhours_double; }
            set { durationhours_double = value; }
        }

        private static TimeSpan lateby_ts;
        public TimeSpan LateBy_TS
        {
            get { return lateby_ts; }
            set { lateby_ts = value; }
        }

        private static string lateby_string;
        public string LateBy_String
        {
            get { return lateby_string; }
            set { lateby_string = value; }
        }

        private static TimeSpan earlyby_ts;
        public TimeSpan EarlyBy_TS
        {
            get { return earlyby_ts; }
            set { earlyby_ts = value; }
        }

        private static string earlyby_string;
        public string EarlyBy_String
        {
            get { return earlyby_string; }
            set { earlyby_string = value; }
        }

        private static double otbychange;
        public double OTByChange
        {
            get { return otbychange; }
            set { otbychange = value; }
        }

        private static string workingtransfer;
        public string WorkingTransfer
        {
            get { return workingtransfer; }
            set { workingtransfer = value; }
        }

        private static string inchargeremark;
        public string InchargeRemark
        {
            get { return inchargeremark; }
            set { inchargeremark = value; }
        }

        private static string leaveapplication;
        public string LeaveApplication
        {
            get { return leaveapplication; }
            set { leaveapplication = value; }
        }

        private static string latecomingearlygoingmark;
        public string LateComingEarlyGoingMark
        {
            get { return latecomingearlygoingmark; }
            set { latecomingearlygoingmark = value; }
        }

        private static string latecomming;
        public string LateComming
        {
            get { return latecomming; }
            set { latecomming = value; }
        }

        private static DateTime empshiftintime;
        public DateTime EmpShiftInTime
        {
            get { return empshiftintime; }
            set { empshiftintime = value; }
        }

        private static TimeSpan shifthours_ts;
        public TimeSpan ShiftHours_TS
        {
            get { return shifthours_ts; }
            set { shifthours_ts = value; }
        }

        private static string shiftduration;
        public string ShiftDuration
        {
            get { return shiftduration; }
            set { shiftduration = value; }
        }

        private static string shiftdurationhours;
        public string ShiftDurationHours
        {
            get { return shiftdurationhours; }
            set { shiftdurationhours = value; }
        }


        private static int shiftduration_int;
        public int ShiftDuration_Int
        {
            get { return shiftduration_int; }
            set { shiftduration_int = value; }
        }

        private static string gracetime_string;
        public string GraceTime_String
        {
            get { return gracetime_string; }
            set { gracetime_string = value; }
        }

        private static string sbegintimetime;
        public string SBeginTimeTime
        {
            get { return sbegintimetime; }
            set { sbegintimetime = value; }
        }

        private static string begintime_shift_string;
        public string BeginTime_Shift_String
        {
            get { return begintime_shift_string; }
            set { begintime_shift_string = value; }
        }

        private static string endtime_shift_string;
        public string EndTime_Shift_String
        {
            get { return endtime_shift_string; }
            set { endtime_shift_string = value; }
        }

        private static string intime_emp_string;
        public string InTime_Emp_String
        {
            get { return intime_emp_string; }
            set { intime_emp_string = value; }
        }

        private static TimeSpan intime_emp_ts;
        public TimeSpan InTime_Emp_TS
        {
            get { return intime_emp_ts; }
            set { intime_emp_ts = value; }
        }

        private static TimeSpan intime_shift_ts;
        public TimeSpan InTime_Shift_TS
        {
            get { return intime_shift_ts; }
            set { intime_shift_ts = value; }
        }

        private static TimeSpan outtime_shift_ts;
        public TimeSpan OutTime_Shift_TS
        {
            get { return outtime_shift_ts; }
            set { outtime_shift_ts = value; }
        }


        private static string intime_shift_string;
        public string InTime_Shift_String
        {
            get { return intime_shift_string; }
            set { intime_shift_string = value; }
        }

        private static string outtime_shift_string;
        public string OutTime_Shift_String
        {
            get { return outtime_shift_string; }
            set { outtime_shift_string = value; }
        }

        private static DateTime begintime_shift_dt;
        public DateTime BeginTime_Shift_DT
        {
            get { return begintime_shift_dt; }
            set { begintime_shift_dt = value; }
        }

        private static DateTime endtime_shift_dt;
        public DateTime EndTime_Shift_DT
        {
            get { return endtime_shift_dt; }
            set { endtime_shift_dt = value; }
        }

        private static DateTime begintimeshift;
        public DateTime BeginTimeShift
        {
            get { return begintimeshift; }
            set { begintimeshift = value; }
        }

        private static DateTime endtimeshift;
        public DateTime EndTimeShift
        {
            get { return endtimeshift; }
            set { endtimeshift = value; }
        }

        private static TimeSpan begintimeshift_ts;
        public TimeSpan BeginTimeShift_TS
        {
            get { return begintimeshift_ts; }
            set { begintimeshift_ts = value; }
        }

        private static TimeSpan endtimeshift_ts;
        public TimeSpan EndTimeShift_TS
        {
            get { return endtimeshift_ts; }
            set { endtimeshift_ts = value; }
        }

        private static TimeSpan gracecalculaton_ts;
        public TimeSpan GraceCalculaton_TS
        {
            get { return gracecalculaton_ts; }
            set { gracecalculaton_ts = value; }
        }

        private static TimeSpan graceless_ts;
        public TimeSpan GraceLess_TS
        {
            get { return graceless_ts; }
            set { graceless_ts = value; }
        }

        private static TimeSpan graceplus_ts;
        public TimeSpan GracePlus_TS
        {
            get { return graceplus_ts; }
            set { graceplus_ts = value; }
        }


        private static string shiftname;
        public string ShiftName
        {
            get { return shiftname; }
            set { shiftname = value; }
        }

        //Employees

        private static string stringcode;
        public string StringCode
        {
            get { return stringcode; }
            set { stringcode = value; }
        }

        private static int numericcode;
        public int NumericCode
        {
            get { return numericcode; }
            set { numericcode = value; }
        }


        private static string departmentname;
        public string DepartmentName
        {
            get { return departmentname; }
            set { departmentname = value; }
        }

        private static string categoryname;
        public string CategoryName
        {
            get { return categoryname; }
            set { categoryname = value; }
        }


        private static string employeedevicepassword;
        public string EmployeeDevicePassword
        {
            get { return employeedevicepassword; }
            set { employeedevicepassword = value; }
        }

        private static string residentialaddress;
        public string ResidentialAddress
        {
            get { return residentialaddress; }
            set { residentialaddress = value; }
        }

        private static string permanentaddress;
        public string PermanentAddress
        {
            get { return permanentaddress; }
            set { permanentaddress = value; }
        }

        private static string contactno;
        public string ContactNo
        {
            get { return contactno; }
            set { contactno = value; }
        }

        private static string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private static string placeofbirth;
        public string PlaceOfBirth
        {
            get { return placeofbirth; }
            set { placeofbirth = value; }
        }

        private static string nomenee1;
        public string Nomenee1
        {
            get { return nomenee1; }
            set { nomenee1 = value; }
        }

        private static string nomenee2;
        public string Nomenee2
        {
            get { return nomenee2; }
            set { nomenee2 = value; }
        }

        private static string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private static string workplace;
        public string WorkPlace
        {
            get { return workplace; }
            set { workplace = value; }
        }

        private static string loginname;
        public string LoginName
        {
            get { return loginname; }
            set { loginname = value; }
        }

        private static string loginpassword;
        public string LoginPassword
        {
            get { return loginpassword; }
            set { loginpassword = value; }
        }

        private static string team;
        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        private static int isrecievenotification;
        public int IsRecieveNotification
        {
            get { return isrecievenotification; }
            set { isrecievenotification = value; }
        }

        private static int holidaygroup;
        public int HolidayGroup
        {
            get { return holidaygroup; }
            set { holidaygroup = value; }
        }

        private static int shiftrosterid;
        public int ShiftRosterId
        {
            get { return shiftrosterid; }
            set { shiftrosterid = value; }
        }

        private static int lastmodifiedby;
        public int LastModifiedBy
        {
            get { return lastmodifiedby; }
            set { lastmodifiedby = value; }
        }

        private static string aadhaarnumber;
        public string AadhaarNumber
        {
            get { return aadhaarnumber; }
            set { aadhaarnumber = value; }
        }

        //image	Checked
        //       private static string employeephoto;
        //public string EmployeePhoto
        //{
        //    get { return aadhaarnumber; }
        //    set { aadhaarnumber = value; }
        //}

        private static int masterdeviceid;
        public int MasterDeviceId
        {
            get { return masterdeviceid; }
            set { masterdeviceid = value; }
        }

        private static string biophoto1;
        public string BIOPhoto1
        {
            get { return biophoto1; }
            set { biophoto1 = value; }
        }

        //private static string biophotopic;
        //public string BIOPhotoPic
        //{
        //    get { return biophotopic; }
        //    set { biophotopic = value; }
        //}

        //private static string biophotopic;
        //public string BIOPhotoPic
        //{
        //    get { return biophotopic; }
        //    set { biophotopic = value; }
        //}

        private static int deviceexpiryrule;
        public int DeviceExpiryRule
        {
            get { return deviceexpiryrule; }
            set { deviceexpiryrule = value; }
        }

        private static DateTime deviceexpirystartdate;
        public DateTime DeviceExpiryStartDate
        {
            get { return deviceexpirystartdate; }
            set { deviceexpirystartdate = value; }
        }

        private static DateTime deviceexpiryenddate;
        public DateTime DeviceExpiryEndDate
        {
            get { return deviceexpiryenddate; }
            set { deviceexpiryenddate = value; }
        }

        private static string devicename;
        public string DeviceName
        {
            get { return devicename; }
            set { devicename = value; }
        }

        private static DateTime enrolleddate;
        public DateTime EnrolledDate
        {
            get { return enrolleddate; }
            set { enrolleddate = value; }
        }

        private static int migratetoothercryptography;
        public int MigrateToOtherCryptography
        {
            get { return migratetoothercryptography; }
            set { migratetoothercryptography = value; }
        }

        private static int newflag;
        public int NewFlag
        {
            get { return newflag; }
            set { newflag = value; }
        }

        //Login Class

        private static int loginid;
        private static int usertypeid;
        private static string username;
        private static string password;
        private static string search;

        public int LoginId
        {
            get { return loginid; }
            set { loginid = value; }
        }

        public int UserTypeId
        {
            get { return usertypeid; }
            set { usertypeid = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Search
        {
            get { return search; }
            set { search = value; }
        }

        //Asset Master

        private static int assetmasterid;
        public int AssetMasterId
        {
            get { return assetmasterid; }
            set { assetmasterid = value; }
        }

        private static string commanmastertable;
        public string CommanMasterTable
        {
            get { return commanmastertable; }
            set { commanmastertable = value; }
        }


        //Asset

        private static string fixedassetcode;
        public string FixedAssetCode
        {
            get { return fixedassetcode; }
            set { fixedassetcode = value; }
        }

        private static int assettypeid;
        public int AssetTypeId
        {
            get { return assettypeid; }
            set { assettypeid = value; }
        }

        private static string modelno;
        public string ModelNo
        {
            get { return modelno; }
            set { modelno = value; }
        }

        private static string processorname;
        public string ProcessorName
        {
            get { return processorname; }
            set { processorname = value; }
        }

        private static string devicemanufracturer;
        public string DeviceManufracturer
        {
            get { return devicemanufracturer; }
            set { devicemanufracturer = value; }
        }

        private static string serialnumber;
        public string SerialNumber
        {
            get { return serialnumber; }
            set { serialnumber = value; }
        }
        private static string domainname;
        public string DomainName
        {
            get { return domainname; }
            set { domainname = value; }
        }

        // private static string username;
        //  public string UserName
        //{
        //    get { return username; }
        //    set { username = value; }
        //}

        // private static string devicemanufracturer;
        //  public string DeviceManufracturer
        //{
        //    get { return devicemanufracturer; }
        //    set { devicemanufracturer = value; }
        //}

        //private static string devicename;
        //public string DeviceName
        //{
        //    get { return devicename; }
        //    set { devicename = value; }
        //}

        private static string processor;
        public string Processor
        {
            get { return processor; }
            set { processor = value; }
        }

        private static string ram;
        public string RAM
        {
            get { return ram; }
            set { ram = value; }
        }

        private static string ramtype;
        public string RAMType
        {
            get { return ramtype; }
            set { ramtype = value; }
        }

        private static string motherboardserialno;
        public string MotherBoardSerialNo
        {
            get { return motherboardserialno; }
            set { motherboardserialno = value; }
        }

        private static string deviceid_s;
        public string DeviceID
        {
            get { return deviceid_s; }
            set { deviceid_s = value; }
        }

        private static string productid;
        public string ProductID
        {
            get { return productid; }
            set { productid = value; }
        }

        private static string hddmodel;
        public string HDDModel
        {
            get { return hddmodel; }
            set { hddmodel = value; }
        }
        private static string hddsize;
        public string HDDSize
        {
            get { return hddsize; }
            set { hddsize = value; }
        }

        private static string hddtype;
        public string HDDType
        {
            get { return hddtype; }
            set { hddtype = value; }
        }

        private static string ssdmodel;
        public string SSDModel
        {
            get { return ssdmodel; }
            set { ssdmodel = value; }
        }

        private static string ssdsize;
        public string SSDSize
        {
            get { return ssdsize; }
            set { ssdsize = value; }
        }

        private static string ssdtype;
        public string SSDType
        {
            get { return ssdtype; }
            set { ssdtype = value; }
        }

        private static string edition;
        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        private static string version;
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private static DateTime installedon;
        public DateTime InstalledOn
        {
            get { return installedon; }
            set { installedon = value; }
        }

        private static string osbuild;
        public string OSBuild
        {
            get { return osbuild; }
            set { osbuild = value; }
        }

        private static string experience;
        public string Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        private static string osmanufacturer;
        public string OSManufacturer
        {
            get { return osmanufacturer; }
            set { osmanufacturer = value; }
        }

        private static string macaddress;
        public string MACAddress
        {
            get { return macaddress; }
            set { macaddress = value; }
        }

        //private static string computername;
        //public string ComputerName
        //{
        //    get { return computername; }
        //    set { computername = value; }
        //}

        private static string ipaddress;
        public string IPAddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }

        private static string assetstatus;
        public string AssetStatus
        {
            get { return assetstatus; }
            set { assetstatus = value; }
        }

        private static string assetcode;
        public string AssetCode
        {
            get { return assetcode; }
            set { assetcode = value; }
        }

        private static int updateversion;
        public int UpdateVersion
        {
            get { return updateversion; }
            set { updateversion = value; }
        }

        private static int updateflag;
        public int UpdateFlag
        {
            get { return updateflag; }
            set { updateflag = value; }
        }

        private static int macaddresstableid;
        public int MacAddressTableID
        {
            get { return macaddresstableid; }
            set { macaddresstableid = value; }
        }

        private static int iseditattendance;
        public int IsEditAttendance
        {
            get { return iseditattendance; }
            set { iseditattendance = value; }
        }

        private static int iseditoverwrite;
        public int IsEditOverwrite
        {
            get { return iseditoverwrite; }
            set { iseditoverwrite = value; }
        }

        private static int iseditovertime;
        public int IsEditOvertime
        {
            get { return iseditovertime; }
            set { iseditovertime = value; }
        }

        private static int isleaveforce;
        public int IsLeaveForce
        {
            get { return isleaveforce; }
            set { isleaveforce = value; }
        }

        private static string hrediteemarks;
        public string HREditRemarks
        {
            get { return hrediteemarks; }
            set { hrediteemarks = value; }
        }

        private static string inchargeremarks;
        public string InchargeRemarks
        {
            get { return inchargeremarks; }
            set { inchargeremarks = value; }
        }

        private static string managerremarks;
        public string ManagerRemarks
        {
            get { return managerremarks; }
            set { managerremarks = value; }
        }

        private static string hrreply;
        public string HRReply
        {
            get { return hrreply; }
            set { hrreply = value; }
        }



        //"TIME_FORMAT(AL.InTime, '%H:%i') AS 'In Time'," +
        //"TIME_FORMAT(AL.OutTime, '%H:%i') AS 'Out Time'," +

        public string AttendanceLogsQuery = "select " +
                                                "AL.AttendanceLogId," +
                                                "DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
                                                "AL.LocationId," +
                                                "LM.LocationName as 'Location'," +
                                                "AL.DepartmentId, " +
                                                "DM.Department," +
                                                "L.LocationName AS 'Tran Location', " +
                                                "D.Department AS 'Tran Department', " +
                                                "AL.EmployeeId," +
                                                "AL.EmployeeCode as 'Emp Code'," +
                                                "E.EmployeeName as 'Employee Name'," +
                                                "E.Gender," +
                                                "AL.ContractorId," +
                                                "CM.ContractorName as 'Roll Name'," +
                                                "AL.CategoryId, " +
                                                "C.CategoryFName as 'Weekly Off'," +
                                                "AL.DesignationId, " +
                                                "DES.Designation, " +
                                                "AL.JobProfile, " +
                                                "AL.ShiftGroupId, " +
                                                "AL.OverTimeApplicable, " +
                                                "AL.ShiftId, " +
                                                "AL.ShiftFName as 'Shift Name'," +
                                                "TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin'," +
                                                "TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End'," +
                                                "TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration'," +
                                                "DATE_FORMAT(AL.InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
                                                "DATE_FORMAT(AL.OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
                                                //"AL.InTime AS 'In Time'," +
                                                //"AL.OutTime AS 'Out Time'," +
                                                "TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration," +
                                                //"TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OT," +
                                                //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime * 60) * 60), '%H:%i') AS OT,"+
                                                //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime) * 60), '%H:%i') AS OT,"+
                                                "TIME_FORMAT(SEC_TO_TIME(CEIL(TIME_TO_SEC(SEC_TO_TIME(AL.OverTime * 60)) / 3600) * 3600),'%H:%i') AS OT," +
                                                "AL.Status, " +
                                                "AL.Present, " +
                                                "AL.HalfDay, " +
                                                "AL.Absent, " +
                                                "AL.MissedInPunch, " +
                                                "AL.MissedOutPunch, " +
                                                "AL.LateBy as 'Late by', " +
                                                "AL.EarlyBy as 'Early by', " +
                                                "AL.LossOfHours as 'Loss', " +
                                                "AL.PunchRecords as 'Punch Records', " +
                                                "AL.LeaveTypeId, " +
                                                "AL.LeaveType, " +
                                                "AL.LeaveDuration, " +
                                                "AL.LeaveRemarks, " +
                                                "AL.IsCompOff, " +
                                                "AL.IsCompOffUsed, " +
                                                "AL.CompOffRemarks, " +
                                                "AL.CompOffUsedRemarks, " +
                                                "AL.IsEditAttendance, " +
                                                "AL.IsEditOverwrite, " +
                                                "AL.IsLeaveForce, " +
                                                "AL.HREditRemarks as 'HR Edit Remarks', " +
                                                "AL.InchargeRemarks, " +
                                                "AL.ManagerRemarks as 'Manager Remarks', " +
                                                "AL.HRReply as 'HR Reply', " +
                                                "AL.IsFlexibleHoursFlag, " +
                                                "AL.FinancialYearId, " +
                                                "AL.IsOutdoorEntry," +
                                                "AL.IsRoll, " +
                                                "AL.ChangeDepartmentFlag, " +
                                                "AL.ChangeLocationtId, " +
                                                "AL.ChangeDepartmentId, " +
                                                "AL.TransferRemarks, " +
                                                "AL.ApprovalStatusId, " +
                                                "AL.IsEditOvertime, " +
                                                "AL.OvertimePrevious, " +
                                                " CASE WHEN AL.OverTimeApplicable = 1 THEN 'Yes' WHEN AL.OverTimeApplicable = 0 THEN 'No' ELSE 'Unknown' END AS 'OT Applicable', " +
                                                " CASE "+
                                                " WHEN ChangeDepartmentFlag IS NOT NULL "+
                                                " AND ChangeDepartmentFlag= 1  " +
                                                " THEN  'Transfer' " +
                                                " WHEN @ChangeLocationtId IS NOT NULL " +
                                                        " AND @ChangeDepartmentId IS NOT NULL " +
                                                        " AND AL.ChangeDepartmentId IS NOT NULL " +
                                                        " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
                                                        " AND AL.ChangeLocationtId = @ChangeLocationtId " +
                                                        " AND AL.ChangeDepartmentId = @ChangeDepartmentId " +
                                                " THEN 'Transfer IN' " +
                                                " WHEN @ChangeLocationtId IS NOT NULL " +
                                                        " AND @ChangeDepartmentId IS NOT NULL " +
                                                        " AND AL.ChangeDepartmentId IS NOT NULL "+
                                                        " AND AL.ChangeDepartmentId<> AL.DepartmentId "+
                                                " THEN 'Transfer OUT' "+
                                                " ELSE 'Original' "+
                                            " END AS TransferDirection "+


                                                " from attendancelogs AL inner join employees E on AL.EmployeeId=E.EmployeeId " +
                                                " LEFT JOIN locationmaster L ON L.LocationId = AL.ChangeLocationtId " +
                                                " LEFT JOIN departmentmaster D ON D.DepartmentId = AL.ChangeDepartmentId " +
                                                " inner join locationmaster LM on LM.LocationId=AL.LocationId " +
                                                " inner join departmentmaster DM on DM.DepartmentId=AL.DepartmentId " +
                                                " inner join contractormaster CM on CM.ContractorId=AL.ContractorId " +
                                                " inner join categories C on C.CategoryId=AL.CategoryId " +
                                                " inner join designationmaster DES on DES.DesignationId=AL.DesignationId " +
                                                " where AL.CancelTag=0 and E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 ";
        //" and AND AL.ChangeLocationtId = AL.LocationId " +
        //" AND AL.ChangeDepartmentId = AL.DepartmentId " +
        //" AND( " +
        //" AL.ChangeLocationtId<> AL.LocationId " +
        //" OR AL.ChangeDepartmentId<> AL.DepartmentId) ";

        public static string AllCountQuery = string.Empty;
        public string Get_AttendanceLogs_Query(int LocationId,int DepartmentId)
        {
            string QueryReturn = string.Empty;
             
                  QueryReturn = "select " +
                        "AL.AttendanceLogId," +
                        "DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
                        "AL.LocationId," +
                        "LM.LocationName as 'Location'," +
                        "AL.DepartmentId, " +
                        "DM.Department," +
                        "L.LocationName AS 'Tran Location', " +
                        "D.Department AS 'Tran Department', " +
                        "AL.EmployeeId," +
                        "AL.EmployeeCode as 'Emp Code'," +
                        "E.EmployeeName as 'Employee Name'," +
                        "E.Gender," +
                        "AL.ContractorId," +
                        "CM.ContractorName as 'Roll Name'," +
                        "AL.CategoryId, " +
                        "C.CategoryFName as 'Weekly Off'," +
                        "AL.DesignationId, " +
                        "DES.Designation, " +
                        "AL.JobProfile, " +
                        "AL.ShiftGroupId, " +
                        "AL.OverTimeApplicable, " +
                        "AL.ShiftId, " +
                        "AL.ShiftFName as 'Shift Name'," +
                        "TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin'," +
                        "TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End'," +
                        "TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration'," +
                        "DATE_FORMAT(AL.InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
                        "DATE_FORMAT(AL.OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
                        //"AL.InTime AS 'In Time'," +
                        //"AL.OutTime AS 'Out Time'," +
                        "TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration," +
                        //"TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OT," +
                        //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime * 60) * 60), '%H:%i') AS OT,"+
                        //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime) * 60), '%H:%i') AS OT,"+
                        "TIME_FORMAT(SEC_TO_TIME(CEIL(TIME_TO_SEC(SEC_TO_TIME(AL.OverTime * 60)) / 3600) * 3600),'%H:%i') AS OT," +
                        "AL.Status, " +
                        "AL.Present, " +
                        "AL.HalfDay, " +
                        "AL.Absent, " +
                        "AL.MissedInPunch, " +
                        "AL.MissedOutPunch, " +
                        "AL.LateBy as 'Late by', " +
                        "AL.EarlyBy as 'Early by', " +
                        "AL.LossOfHours as 'Loss', " +
                        "AL.PunchRecords as 'Punch Records', " +
                        "AL.LeaveTypeId, " +
                        "AL.LeaveType, " +
                        "AL.LeaveDuration, " +
                        "AL.LeaveRemarks, " +
                        "AL.IsCompOff, " +
                        "AL.IsCompOffUsed, " +
                        "AL.CompOffRemarks, " +
                        "AL.CompOffUsedRemarks, " +
                        "AL.IsEditAttendance, " +
                        "AL.IsEditOverwrite, " +
                        "AL.IsLeaveForce, " +
                        "AL.HREditRemarks as 'HR Edit Remarks', " +
                        "AL.InchargeRemarks, " +
                        "AL.ManagerRemarks as 'Manager Remarks', " +
                        "AL.HRReply as 'HR Reply', " +
                        "AL.IsFlexibleHoursFlag, " +
                        "AL.FinancialYearId, " +
                        "AL.IsOutdoorEntry," +
                        "AL.IsRoll, " +
                        "AL.ChangeDepartmentFlag, " +
                        "AL.ChangeLocationtId, " +
                        "AL.ChangeDepartmentId, " +
                        "AL.TransferRemarks, " +
                        "AL.ApprovalStatusId, " +
                        "AL.IsEditOvertime, " +
                        "AL.OvertimePrevious, " +
                        " CASE WHEN AL.OverTimeApplicable = 1 THEN 'Yes' WHEN AL.OverTimeApplicable = 0 THEN 'No' ELSE 'Unknown' END AS 'OT Applicable', " +
                        " CASE " +
                        " WHEN ChangeDepartmentFlag IS NOT NULL " +
                        " AND ChangeDepartmentFlag= 1  " +
                        " THEN  'Transfer' " +
                        " WHEN " + LocationId + " IS NOT NULL AND  " + LocationId + " >0 " +
                                " AND " + DepartmentId + " IS NOT NULL AND  " + DepartmentId + " >0 " +
                                " AND AL.ChangeDepartmentId IS NOT NULL " +
                                " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
                                " AND AL.ChangeLocationtId = " + LocationId + " " +
                                " AND AL.ChangeDepartmentId =" + DepartmentId +
                        " THEN 'Transfer IN' " +
                        " WHEN " + LocationId + " IS NOT NULL AND  " + LocationId + " >0 " +
                               " AND " + DepartmentId + " IS NOT NULL AND  " + DepartmentId + " >0 " +
                                " AND AL.ChangeDepartmentId IS NOT NULL " +
                                " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
                        " THEN 'Transfer OUT' " +
                        " ELSE 'Original' " +
                    " END AS TransferDirection," +
                    " CASE WHEN AL.ApprovalStatusId = 1 THEN 'Pending' WHEN AL.ApprovalStatusId = 2 THEN 'Completed' WHEN AL.ApprovalStatusId = 3 THEN 'Remarks' WHEN AL.ApprovalStatusId = 6 THEN 'HR Approved' WHEN AL.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Approval Status', " +
                    " CASE WHEN AL.OutdoorApprovalStatusId = 1 THEN 'Pending' WHEN AL.OutdoorApprovalStatusId = 2 THEN 'Completed' WHEN AL.OutdoorApprovalStatusId = 3 THEN 'Remarks' WHEN AL.OutdoorApprovalStatusId = 6 THEN 'HR Approved' WHEN AL.OutdoorApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Outdoor Approval Status', " +
                    " AL.OutdoorApprovalStatusId "+
                        " from attendancelogs AL inner join employees E on AL.EmployeeId=E.EmployeeId " +
                        " LEFT JOIN locationmaster L ON L.LocationId = AL.ChangeLocationtId " +
                        " LEFT JOIN departmentmaster D ON D.DepartmentId = AL.ChangeDepartmentId " +
                        " inner join locationmaster LM on LM.LocationId=AL.LocationId " +
                        " inner join departmentmaster DM on DM.DepartmentId=AL.DepartmentId " +
                        " inner join contractormaster CM on CM.ContractorId=AL.ContractorId " +
                        " inner join categories C on C.CategoryId=AL.CategoryId " +
                        " inner join designationmaster DES on DES.DesignationId=AL.DesignationId " +
                        " where AL.CancelTag=0 and E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 ";


            AllCountQuery = "select Count(*) from attendancelogs where CancelTag=0 and " +
                              " AttendanceDate='" + AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' " +
                              " AND(LocationId = " + LocationId + " OR " + LocationId + " = 0) AND(DepartmentId = " + DepartmentId + " OR " + DepartmentId + " = 0)";
            return QueryReturn;
        }
    }
}

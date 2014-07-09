using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
namespace couplerWriter
{

    class studentUtility
    {
        // uses machine.config in the Framework64 directory
         // change this back when to XRAY for DEVELOPMENT
        static public String couplerDB = "csIDNovDB";
        //static public String couplerDB = "csIDXRAYDB";
     
        static public String XrayUtilDB = "csUtilsXrayDB";
        static public String NovUtilDB = "csUtilityNovDB";
        static String mLogFile = "c:\\temp\\googlecoupler.log";
        static String mNetName = "idmCoupler";

        static private bool putLog(String aCSName, String aSqlQuery)
        {
            DateTime dt = DateTime.Now;
            try
            {
                StreamWriter sw = new StreamWriter(mLogFile, true);
                sw.WriteLine(dt.ToString("yyyy-MM-dd HH:mm") + " " + mNetName);
                sw.WriteLine(aCSName);
                sw.WriteLine(aSqlQuery);
                sw.Close();
                return true;
            }
            catch (Exception ue)
            {
                String ueDesc = ue.Message;
                StreamWriter sw = new StreamWriter(mLogFile, true);
                sw.WriteLine(dt.ToString("yyyy-MM-dd HH:mm") + " " + mNetName);
                sw.WriteLine(aCSName);
                sw.WriteLine(aSqlQuery);
                sw.WriteLine(ueDesc);
                sw.Close();
                return false;
            }
        }

        static public String calculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static public String createGooglePassword(String ndsName)
        {
            String password;
            password = calculateMD5Hash(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(1, 4) + ndsName.Substring(ndsName.Length - 4, 4));
            if (password.Length > 11)
            {
                return password.Substring(0, 12);
            }
            else return password;
        }


        static public DataView readDataView(String aCSName, String aSqlQuery)
        {
            if (putLog(aCSName, aSqlQuery))
            {
                ConnectionStringSettingsCollection connections =
                    ConfigurationManager.ConnectionStrings;
                DataTable dt = new DataTable();
                SqlConnection connUtility = new SqlConnection(
                    connections[aCSName].ConnectionString
                    );
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(aSqlQuery, connUtility);
                    adp.SelectCommand = cmd;
                    try { adp.Fill(dt); }
                    catch (Exception ue) { putLog(aCSName + ":dataView Error", ue.Message); };
                }
                finally { connUtility.Close(); }
                return dt.DefaultView;
            }
            else
                return null;
        }

        static public void updateWcStaffIdentity(String aNDSName, String aSetString)
        {
            DataView wDV = readDataView(studentUtility.couplerDB,
                "UPDATE wcStaffIdentity " + aSetString + " " +
                "WHERE NDSName='" + aNDSName + "'"
            );
        }

        static public DataView couplerDV(String whereClause)
        {
            String sqlCMQ = "";
            sqlCMQ = "SELECT DISTINCT TOP 2600 w.*, w.exp_student_id as ndsname, w.course_title, rtrim(ltrim(audit_dat..sequence.PassCode)) as PassCode, rtrim(ltrim(dbo.FStudentHomeVol(w.context))) as MoveHomeArea, c.networkname, c.actionData, c.action, c.queueItem, c.attempts " +
                "FROM couplerMessageQueueStu c LEFT JOIN wcStudentPrimaryCourse w ON " +
                "  w.exp_student_ID=c.networkName left join audit_dat..sequence on w.Student_id=audit_dat..sequence.student_id " + whereClause;
            return readDataView(couplerDB,
                sqlCMQ //" order by c.whenSent" 
            );
        }

        static public int updateCouplerMessageQueueSet(String[] aQueueItemSet, String aSetString)
        {
            DataView wDV;
            // do we need to send e-mail to Line manager here?
            foreach (String qi in aQueueItemSet)
            {
                wDV = readDataView(couplerDB,
                    "UPDATE couplerMessageQueueStu " + aSetString + " " +
                    "WHERE queueItem=" + qi
                );
            }
            return aQueueItemSet.GetLength(0);
        }


        static public string updateCouplerMessageQueue(String aQueueItem, String aSetString)
        {
            DataView wDV;
            // 
                wDV = readDataView(couplerDB,
                    "UPDATE couplerMessageQueueStu " + aSetString + " " +
                    "WHERE queueItem=" + aQueueItem);
            return aQueueItem;
        }

        static public bool writeCouplerMessageQueue(String ndsName,String actionData,String action)
        {
            DataView wDV;
                String sqlInsert;
                sqlInsert = "wcIDMCMQinsert '" + ndsName.Trim().ToString() + "','" +  action + "', '" + actionData  + "'"; 

                wDV = readDataView(couplerDB, sqlInsert);
            return false;
        }

        static public bool writeCouplerMessageQueueStu(String ndsName, String actionData, String action)
        {
            DataView wDV;
            String sqlInsert;
            sqlInsert = "wcIDMCMQinsertStu '" + ndsName.Trim().ToString() + "','" + action + "', '" + actionData + "'";

            wDV = readDataView(couplerDB, sqlInsert);
            return false;
        }

        static public bool sendEmail(String aTo, String aFrom, String aSubject, String aText, String aCC)
        {
            bool wResult=true;
            try
            {
                DataView updateDV = studentUtility.readDataView(
                    "csQLSXrayDB",
                    "email..postEmail '" + aTo +"'" +
                    ", '" + aFrom +"'" +
                    ", '" + aSubject + "'" +
                    ", '" + aText + "'" +
                    ", '" + aCC + "'"
                );
                if (updateDV == null) wResult = false;
                if (updateDV.Count < 1) wResult = false;
            }
            catch (Exception ue) { String wM = ue.Message; wResult = false; }
            return wResult;
        }

    }

    class Program
    {


        static String EHDDB = "csEstatesDB";
        static String SHDDB = "csSiteHelpDeskDB";
        //change this back when to XRAY for DEVELOPMENT
        static String QLRDB = "csWcPortalNovDB";
        //static String QLRDB = "csWcPortalXRAYDB";
        //static String NDSTargetPath = "c:\\wcIdentities\\staff\\todo\\";
        
        static String NDSTargetPath = "c:\\wcIdentities\\student\\todo\\";

        static void Main(string[] args)
        {

            couplerWriter cw = new couplerWriter(EHDDB,SHDDB,QLRDB,NDSTargetPath);

            DataView wCouplerDV = studentUtility.couplerDV("WHERE (c.whenDone IS NULL) AND (action like '%google%') AND (attempts IS NOT NULL) AND len(rtrim(ltrim(w.birth_dt)))> 0");

            if (wCouplerDV != null) if (wCouplerDV.Count > 0)
                {
                    
                cw.testPhase(wCouplerDV);
                    int testedOKCount = 
                        studentUtility.updateCouplerMessageQueueSet(cw.testedOK(), "SET whenDone=getdate()");
                if (cw.failed().Length > 0)    
                {
                    bool wb = 
                            studentUtility.sendEmail(
                                "mis@warkscol.ac.uk",
                                "idm@warkscol.ac.uk",
                                "Student ID Coupler Fails : " + DateTime.Now.ToString("yyyyMMddHHmmss"),
                                "Coupler job " + String.Join(", ", cw.failed()),
                                 null
                            );
                }
                    int failedCount =
                        studentUtility.updateCouplerMessageQueueSet(cw.failed(), "SET attempts=0");
                }

            wCouplerDV =  studentUtility.readDataView(studentUtility.couplerDB,
                    "UPDATE couplerMessageQueueStu SET attempts=COALESCE(attempts+1,1) " +
                    "WHERE whenDone IS NULL"
                );

            // Do Phase
            wCouplerDV =
                studentUtility.couplerDV("WHERE (c.whenRead IS NULL) AND (action like '%google%') AND (whenDone IS null) AND len(rtrim(ltrim(w.birth_dt)))> 0");
            if (wCouplerDV != null) if (wCouplerDV.Count > 0)
                {
                    cw.doPhase(wCouplerDV);
                    int skippedCount =
                        studentUtility.updateCouplerMessageQueueSet(
                            cw.skipped(), 
                            "SET whenRead=getdate(), whenDone=getDate()"
                        );

                    int writtenCount =
                        studentUtility.updateCouplerMessageQueueSet(
                            cw.written(), 
                            "SET whenRead=getdate()"
                        );
                }

            
        }
    
    }
}

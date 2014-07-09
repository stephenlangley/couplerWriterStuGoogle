using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace couplerWriter
{
    public class studentSpec
    {
        public String
            NDSName, EmailAddress, Context, PreContext, QLId, 
            Forename, Surname,  /*Aka, */
            Department, Description, Password, MaxConnections, Telephone, VolumeRestrictions,
            HomeVol, ActionData
        ;
        public Boolean GWise = true;
        public int queueItem;
        public int attempts;
        public String action = "";
        public String courseTitle = "";

        public studentSpec(DataRowView aDRV)
        {
            
            // SJL 20090427
            // changed to allow for a DELETED wcStudentPrimaryCourse Record
            // If the wcStudentPrimaryCourse Record is deleted then get the QLid from the actiondata
            // and set the NDSname to the NetworkName of the Coupler job
            if (String.IsNullOrEmpty(aDRV["exp_student_id"].ToString()) | aDRV["exp_student_id"].ToString().Length < 1 | String.IsNullOrEmpty(aDRV["birth_dt"].ToString()))
            {
                ActionData = aDRV["actionData"].ToString().Trim();
                String[] AD = aDRV["actionData"].ToString().Trim().Split('=');
                if (AD[0].ToString().ToLower() == "student_id")
                {
                    QLId = AD[1].ToString();
                }
                else
                {
                    QLId = aDRV["exp_student_id"].ToString().Trim();
                }
                NDSName = aDRV["NetworkName"].ToString().Trim(); //Student_id
                EmailAddress = NDSName + "@stu.warkscol.ac.uk";
                Password = "Deleted";
                Forename = "Deleted";
                Surname = "Deleted";
                Department = "Deleted";
                Description = "DOB MISSING";
                MaxConnections = "";
                Telephone = "Deleted";
                VolumeRestrictions = "";
                if (!String.IsNullOrEmpty(aDRV["queueItem"].ToString())) queueItem = (int)aDRV["queueItem"];
                if (!String.IsNullOrEmpty(aDRV["attempts"].ToString())) attempts = (int)aDRV["attempts"];
                if (!String.IsNullOrEmpty(aDRV["action"].ToString())) action = aDRV["action"].ToString();


                Context = "users.students.lspa.wc";
                HomeVol = ".orion_student_home.lspa.wc";
            }
            else
            {
                String sid = aDRV["student_id"].ToString();
                String ac = aDRV["acad_period"].ToString();
                DataView wCouplerDV = studentUtility.readDataView(studentUtility.couplerDB, "wcStudentCourses '" + aDRV["student_id"].ToString() + "'" + ",'" + aDRV["acad_period"].ToString() + "'");

                Department = aDRV["dept_code"].ToString().Trim() + "/" + aDRV["course_id"].ToString().Trim() + "/" + aDRV["acad_period"].ToString().Trim() + "/" + aDRV["aos_period"].ToString().Trim();
                if (wCouplerDV.Count > 0)
                {
                    Department = wCouplerDV[0][0].ToString().Trim(); //field 1
                    Telephone = wCouplerDV[0][1].ToString().Trim(); //field 2
                }
                DateTime dob = Convert.ToDateTime( aDRV["birth_dt"].ToString());
                String day = "0" + dob.Day.ToString();
                String month = "0" + dob.Month.ToString();
                //String x = day.Substring(day.Length - 2);
                //String y = month.Substring(month.Length - 2);
                Password = day.Substring(day.Length - 2) + month.Substring(month.Length - 2) + aDRV["PassCode"].ToString(); // password = left(trim(replace(MySet.fields("DOB"),"/","")),len(trim(replace(MySet.fields("DOB"),"/","")))-4) & PassCode
                NDSName = aDRV["exp_student_id"].ToString().Trim();
                EmailAddress = NDSName + "@stu.warwickshire.ac.uk";
                QLId = aDRV["exp_student_id"].ToString().Trim();
                Forename = aDRV["forename"].ToString().Trim();
                Surname = aDRV["surname"].ToString().Trim();
                ActionData = aDRV["actionData"].ToString().Trim();
                courseTitle = aDRV["course_title"].ToString().Trim();
                if (!String.IsNullOrEmpty(aDRV["queueItem"].ToString())) queueItem = (int)aDRV["queueItem"];
                if (!String.IsNullOrEmpty(aDRV["attempts"].ToString())) attempts = (int)aDRV["attempts"];
                if (!String.IsNullOrEmpty(aDRV["action"].ToString())) action = aDRV["action"].ToString();

                Description = aDRV["course_title"].ToString().Trim();
                MaxConnections = "3";
                VolumeRestrictions = aDRV["homeserver"].ToString().Trim() + aDRV["volume_restrictions"].ToString().Trim();
                Context = aDRV["cur_namecontext"].ToString().Trim();
                PreContext = aDRV["pre_namecontext"].ToString().Trim();
                HomeVol = aDRV["homeserver"].ToString().Trim();
                }
            }
        }
    
    public class studentSpecSL : SortedList<String, studentSpec>
    {
        public studentSpecSL(DataView aDV, List<String> aSkipped)
            : base()
        {
            foreach (DataRowView drv in aDV)
            {
                if (this.ContainsKey(drv["NetworkName"].ToString()))
                    aSkipped.Add(drv["queueItem"].ToString());
                else
                    Add(drv["NetworkName"].ToString(), new studentSpec(drv));
            }
        }
    }
}

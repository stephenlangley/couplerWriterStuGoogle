using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;


namespace couplerWriter
{

    class jrbCoupler : coupler
    {
        protected String mJRBFilesPath = "";

        protected SortedList<String, List<String>> mAttributeValues;

        private void addAttributeValue(
            SortedList<String, List<String>> aAttributeSet,
            String aAttributeName, String aAttributeValue
        )
        {
            if (!aAttributeSet.ContainsKey(aAttributeName))
            {
                List<String> wAttributeList = new List<string>();
                aAttributeSet.Add(aAttributeName, wAttributeList);
            }
            aAttributeSet[aAttributeName].Add(aAttributeValue);
        }

        protected String attributeValue(String aAttributeName)
        {
            String wValue = "";
            try
            {
                if (mAttributeValues.ContainsKey(aAttributeName))
                    if (mAttributeValues[aAttributeName].Count > 0)
                        wValue = mAttributeValues[aAttributeName][0];
            }
            catch (Exception ue) 
            { 
                String wMsg = ue.Message; 
            }
            return wValue;
        }

  

        protected String [] attributeArray(String aAttributeName)
        {
            String [] wValue = null;
            try
            {
                if (mAttributeValues.ContainsKey(aAttributeName))
                    if (mAttributeValues[aAttributeName].Count > 0)
                        wValue = mAttributeValues[aAttributeName].ToArray();
            }
            catch (Exception ue)
            {
                String wMsg = ue.Message;
            }
            return wValue;
        }

        protected SortedList<String, List<String>> GetLDAPInfo(String aFilter)
        {
            SortedList<String, List<String>> wSL = null;

            String domainAndUsername = @"LDAP://212.219.42.19/o=WC";
            //use .89 until the .19 ldap server is resurrected.
            //String domainAndUsername = @"LDAP://212.219.42.89/o=WC";
            string userName = string.Empty;
            string passWord = string.Empty;
            AuthenticationTypes at = AuthenticationTypes.Anonymous;
            //Create the object necessary to read the info from the LDAP directory
            DirectoryEntry entry = new DirectoryEntry(domainAndUsername, userName, passWord, at);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            SearchResultCollection results;
            //mySearcher.f
            mySearcher.Filter = aFilter;

            try
            {
                results = mySearcher.FindAll();
                if (results.Count > 0)
                {
                    SearchResult resEnt = results[0];
                    {
                        wSL = new SortedList<String, List<String>>();
                        ResultPropertyCollection propcoll = resEnt.Properties;
                        String wKey = "";
                        foreach (string key in propcoll.PropertyNames)
                        {
                            wKey = key;
                            switch (key)
                            {
                                case "sn": wKey = "surname"; break;
                                case "l": wKey = "location"; break;
                                case "st": wKey = "state"; break;
                                case "ngwmailboxexpirationtime": wKey = "gwexpire"; break;
                                case "groupmembership": wKey = "grpmbr"; break;
                                case "uid": wKey = "userid"; break;
                                default: break;
                            }
                            if (key != "nsimhint")
                                if (key == "ndshomedirectory")
                                {
                                    String  HomeDir = "";
                                    foreach (Byte[] values in propcoll[key])
                                    {
                                        foreach (Byte b in values)
                                        {
                                            HomeDir = HomeDir + char.ConvertFromUtf32(b);
                                        } 
                                    }

                                        addAttributeValue(wSL, wKey, HomeDir.ToString());
                                }
                                else
                                {
                                    foreach (object values in propcoll[key])
                                        addAttributeValue(wSL, wKey, values.ToString());

                                }
                        }
                        //mResult.Add(wSL["cn"][0], wSL);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return wSL;
        }
        protected List<String> GetALLLDAPInfo(String aFilter, String sContext)
        {
            SortedList<String, List<String>> wSL = null;

            String domainAndUsername = @"LDAP://212.219.42.19/" + sContext.ToString();
            //use .89 until the .19 ldap server is resurrected.
            //String domainAndUsername = @"LDAP://212.219.42.89/o=WC";
            List<String> mResult = new List<String>();
            string userName = string.Empty;
            string passWord = string.Empty;
            AuthenticationTypes at = AuthenticationTypes.Anonymous;
            //Create the object necessary to read the info from the LDAP directory
            DirectoryEntry entry = new DirectoryEntry(domainAndUsername, userName, passWord, at);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            SearchResultCollection results;
            mySearcher.Filter = aFilter;

            try
            {
                
                results = mySearcher.FindAll();
                if (results.Count > 0)
                {
                   // SearchResult resEnt = results[0];
                    {
                        foreach (SearchResult resEnt in results)
                        {
                            wSL = new SortedList<String, List<String>>();
                            ResultPropertyCollection propcoll = resEnt.Properties;

                            String wKey = "";
                            foreach (string key in propcoll.PropertyNames)
                            {
                                wKey = key;
                                switch (key)
                                {
                                    case "sn": wKey = "surname"; break;
                                    case "l": wKey = "location"; break;
                                    case "st": wKey = "state"; break;
                                    case "ngwmailboxexpirationtime": wKey = "gwexpire"; break;
                                    case "groupmembership": wKey = "grpmbr"; break;
                                    case "uid": wKey = "userid"; break;
                                    default: break;
                                }
                                if (key != "nsimhint")
                                    if (key == "ndshomedirectory")
                                    {
                                        String HomeDir = "";
                                        foreach (Byte[] values in propcoll[key])
                                        {
                                            foreach (Byte b in values)
                                            {
                                                HomeDir = HomeDir + char.ConvertFromUtf32(b);
                                            }
                                        }

                                        addAttributeValue(wSL, wKey, HomeDir.ToString());
                                    }
                                    else
                                    {
                                        foreach (object values in propcoll[key])
                                            addAttributeValue(wSL, wKey, values.ToString());

                                    }
                            }

                            String x = wSL["cn"][0].ToString();
                            mResult.Add( wSL["cn"][0].ToString());
                            
                            //mResult.Add(wSL["cn"][0], wSL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return mResult;
        }


        public jrbCoupler() : base() { }

        public jrbCoupler(String aJRBFilesPath, String aActionName, int aTryCount)
        {
            mJRBFilesPath = aJRBFilesPath;
            mActionName = aActionName;
            mTryCount = aTryCount;
        }

        protected virtual String doSelectedItem(studentSpec aStudentSpec) { return ""; }

        protected override void doSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            if (aStudentSpecSL.Count > 0)
            {
                StreamWriter wNewNDSStream = new StreamWriter(
                    mJRBFilesPath + runDateTime.ToString("yyyyMMddHHmmss") + ".txt"
                    );
                foreach (studentSpec ss in aStudentSpecSL.Values) wNewNDSStream.WriteLine(doSelectedItem(ss));
                wNewNDSStream.Close();
            }
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime) { }

    }

    class jrbCouplerCreate : jrbCoupler
    {
        public jrbCouplerCreate
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                //String Password = "seaside";
                //String ExpireDate = "none";
                String Description = "Created on " + DateTime.Now;
                String wNewStaffJRBText =
                    // "!Template=" + aStudentSpec.Template + "\n" +
                    "!Name context = " + aStudentSpec.Context + "\n" +
                    "!Home directory volume=" + aStudentSpec.HomeVol + "\n" +
                    "!Home directory path=users\n" +
                    "!Use two passes=y\n";
                //if (aStudentSpec.GWise)
                //    wNewStaffJRBText +=
                //        "!Groupwise add users=y" + "\n" +
                //        "!Groupwise domain object=.students.groupwise.wc" + "\n" +
                //        "!Groupwise post office=po-students2" + "\n";
                wNewStaffJRBText +=
                    "\"" + aStudentSpec.NDSName + "\"" + "," + "\"" + aStudentSpec.Surname.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Forename.ToUpper() + "\"" + "," + "\"" + aStudentSpec.Password.ToString() + "\"" +
                    "," + "\"" + FullName.ToUpper() + "\"" + "," + "\"" + aStudentSpec.Department.ToUpper() + "\"" +
                    //"," + "\"" + aStudentSpec.Site.ToUpper() + "\"" + 
                    "," + "\"" + aStudentSpec.Description.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.MaxConnections.ToString() + "\"" + "," + "\"" + aStudentSpec.EmailAddress.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Telephone.ToString().Trim() + "\""; //  +
                   // "," + "\"" + aStudentSpec.VolumeRestrictions.ToString().Trim() + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                    if ((mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName)) != null)
                    {
                        String x = attributeValue("gwexpire").ToString();
                        if (attributeValue("logindisabled").ToLower() == "false")
                        {
                            //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 0");
                            mTestedOK.Add(ss.queueItem.ToString());
                        }
                        else
                            if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
                    }
                    else
                        if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerEnable : jrbCoupler
    {
        public jrbCouplerEnable
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                String ExpireDate = "none";
                String Password = ""; //default
                String[] AD = aStudentSpec.ActionData.Split('=');
                if (AD[0].ToString() == "Password")  // generated by StaffActivate
                {
                    Password = AD[1].ToString();
                }
                String Description = "Updated on " + DateTime.Now;
                String wNewStaffJRBText =
                    // "!Template=" + aStudentSpec.Template + "\n" +
                    "!Name context = " + "users" + aStudentSpec.Context + "\n";
                wNewStaffJRBText +=
                    "\"" + aStudentSpec.NDSName + "\"" + "," + "\"" + aStudentSpec.Surname.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Forename.ToUpper() + "\"" +
                    "," + "\"" + Password + "\"" +
                    "," + "\"" + FullName.ToUpper() + "\"" + 
                    "," + "\"" + aStudentSpec.Department.ToUpper() + "\"" +
                    //"," + "\"" + aStudentSpec.Site.ToUpper() + "\"" + 
                   //"," + "\"" + aStudentSpec.JobTitle.ToUpper() + "\"" +
                   // "," + "\"" + aStudentSpec.Tel + "\"" + "," + "\"" + aStudentSpec.EmailAddress.ToUpper() + "\"" +
                    "," + "\"" + Description + "\"" +
                   // "," + "\"" + aStudentSpec.StaffID + "\"" +
                    "," + "\"" + ExpireDate + "\"";
                //"," + "\"" + aStudentSpec.HomeVolRestrict + "\"" +
                //"," + "\"" + aStudentSpec.SharedVolRestrict + "\"" +
                //"," + "\"" + aStudentSpec.Vol1VolRestrict + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);

                if (attributeValue("logindisabled").ToLower() == "false")
                {
                    studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 0");
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerDisable : jrbCoupler
    {
        public jrbCouplerDisable
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String Password = ""; //default
                String Description = "Disabled on " + DateTime.Now;
                String[] AD = aStudentSpec.ActionData.Split('=');
                if (AD[0].ToString() == "Password")  // generated by StaffActivate
                {
                    Password = AD[1].ToString();
                    if (Password != "") Description = "Trashed on " + DateTime.Now;
                }
                String wNewStaffJRBText = 
                    "\"" + aStudentSpec.NDSName + "\"" +
                    "," + "\"" + Password + "\"" +
                    "," + "\"" + Description + "\"";
                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                if (attributeValue("logindisabled").ToLower() == "true")
                {
                    //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 1");
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }
    class jrbCouplerReconcile : jrbCoupler
    {
        public jrbCouplerReconcile
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String Password = ""; //default
                String Description = "Disabled on " + DateTime.Now;
                String[] AD = aStudentSpec.ActionData.Split('=');
                if (AD[0].ToString() == "Password")  // generated by StaffActivate
                {
                    Password = AD[1].ToString();
                    if (Password != "") Description = "Trashed on " + DateTime.Now;
                }
                String wNewStaffJRBText =
                    "\"" + aStudentSpec.NDSName + "\"" +
                    "," + "\"" + Password + "\"" +
                    "," + "\"" + Description + "\"";
                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {

            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
               //mAttributeValues = GetALLLDAPInfo("cn=" + ss.NDSName);
                List<String> mResult = GetALLLDAPInfo("objectclass=user","OU=staff,OU=per,o=wc");
                //List<String> mResult = GetALLLDAPInfo("ou=staff","o=wc");
                //List<String> mResult = GetALLLDAPInfo("organisationalunit=staff","o=wc");
                if (attributeValue("logindisabled").ToLower() == "true")
                {
                    //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 1");
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerDelete : jrbCoupler
    {
        public jrbCouplerDelete
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                //String Password = ""; //default
                //String Description = "Disabled on " + DateTime.Now;
                String[] AD = aStudentSpec.ActionData.Split('=');
                //if (AD[0].ToString() == "Password")  // generated by StaffActivate
                //{
                //    Password = AD[1].ToString();
                //    if (Password != "") Description = "Trashed on " + DateTime.Now;
                //}
                String wNewStaffJRBText =
                    "\"" + aStudentSpec.NDSName + "\"" ;
                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {

            //if nds account not exist then delete is true
            //write a defaultDelete job in the coupler with updateCouplerMessageQueueSet() ?
            //
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);

                if (mAttributeValues == null)
                //if (attributeValue("logindisabled").ToLower() == "true")
                {
                    studentUtility.writeCouplerMessageQueue(ss.NDSName,"EmpNum=" + ss.QLId.Trim(),"DeleteDefault");
                    studentUtility.updateWcStaffIdentity(ss.NDSName, "SET job_Title = DELETED NDS record");
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

}

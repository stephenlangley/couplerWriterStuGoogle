using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Google.GData.Apps;


namespace couplerWriter
{
    class defaultCoupler : coupler
    {
        protected String mCSSHDDB, mCSEHDDB, mCSQLRDB;

        public AppsService service;
        public AppsService serviceTEST;

        public defaultCoupler() : base() { }

        public defaultCoupler
            (String csEHDDB, String csSHDDB, String csQLRDB, String aActionName, int aTryCount)
        {
            mCSEHDDB = csEHDDB; mCSQLRDB = csQLRDB; mCSSHDDB = csSHDDB;
            mActionName = aActionName; mTryCount = aTryCount;
            try
            {
                service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
                serviceTEST = new AppsService("student.warwickshire.ac.uk", "system@warwickshire.ac.uk", "b4ckb34t");
                //MultiDomainManagementService service2 = new MultiDomainManagementService("warwickshire.ac.uk", "Google Apps");
                //service2.setUserCredentials("gadmin@warwickshire.ac.uk", "adcv325jemin");
                //service.CreateUser("HBANGBANG@warwickshire.ac.uk", "Harry", "Bangbang","c0v3ntry");
                //service2.CreateDomainUser("warwickshire.ac.uk","HBANGBANG@warwickshire.ac.uk","c0v3ntry","Harry","Bangbang",false);
                //service.Groups.AddMemberToGroup("HBANGBANG","STAFF-LSPA");
              
                
                

            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }


        }

        protected void updateSelectedItem(studentSpec aStaffSpec, String aEHDDBActiveFlag, String aSHDDBActiveFlag, String aQLRActiveFlag)
        {
            //String HDInsert =
            //    "wcIDMSTFCreateEHDAndSHD " +
            //    "'" + aStaffSpec.EmailAddress + "', " +
            //    "'" + aStaffSpec.Site + "', " +
            //    "'" + aStaffSpec.Forename.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.Surname.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.QLId + "', " +
            //    "'" + aStaffSpec.Department.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.Tel + "', " +
            //    "'" + aStaffSpec.EmpType + "', " +
            //    "'" + aEHDDBActiveFlag + "', " +
            //    "'" + aSHDDBActiveFlag + "'";
            //DataView wDV;
            ////EHDDB + SHDDB
            //wDV = staffUtility.readDataView(staffUtility.XrayUtilDB, HDInsert);
            ////QLR
            //wDV = staffUtility.readDataView(staffUtility.couplerDB,
            //    "wcIDMSTFCreateQLR " +
            //    "'" + aStaffSpec.NDSName + "', " +
            //    "'" + aStaffSpec.Site + "', " +
            //    "'" + aStaffSpec.QLId + "', " +
            //    "'" + aStaffSpec.DeptCode + "', " +
            //    "'" + aStaffSpec.EmpType + "', " +
            //    "'" + aQLRActiveFlag + "'"
            //);
            //mWritten.Add(aStaffSpec.queueItem.ToString());
        }

       // protected SortedList<String, String> testSelectedItemData(studentSpec aStaffSpec)
       // {
            //SortedList<String, String> wSL = new SortedList<String, String>();
            //DataView wDV;
            ////EHDDB + SHDDB
            //wDV = staffUtility.readDataView(staffUtility.XrayUtilDB,
            //    "wcIDMSTFTestEHDAndSHD " +
            //    "'" + aStaffSpec.EmailAddress + "', " +
            //    "'" + aStaffSpec.Site + "', " +
            //    "'" + aStaffSpec.Forename.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.Surname.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.QLId + "', " +
            //    "'" + aStaffSpec.Department.Replace("'", "''") + "', " +
            //    "'" + aStaffSpec.Tel + "', " +
            //    "'" + aStaffSpec.EmpType + "'"
            //    );
            ////QLR
            //wSL.Add("EHDDBActive", wDV[0]["EHDDBActive"].ToString());
            //wSL.Add("EHDDBData", wDV[0]["EHDDBData"].ToString());
            //wSL.Add("SHDDBActive", wDV[0]["SHDDBActive"].ToString());
            //wSL.Add("SHDDBData", wDV[0]["SHDDBData"].ToString());
            //wDV = staffUtility.readDataView(staffUtility.couplerDB,
            //    "wcIDMSTFTestQLR " +
            //    "'" + aStaffSpec.NDSName + "', " +
            //    "'" + aStaffSpec.Site + "', " +
            //    "'" + aStaffSpec.QLId + "', " +
            //    "'" + aStaffSpec.DeptCode + "', " +
            //    "'" + aStaffSpec.EmpType + "'"
            //);
            //wSL.Add("QLRActive", wDV[0]["QLRActive"].ToString());
            //wSL.Add("QLRData", wDV[0]["QLRData"].ToString());
            //return (wSL);
        //}

        //protected virtual Boolean testSelectedItem(studentSpec aStaffSpec, String aEHDDBActiveFlag, String aSHDDBActiveFlag, String aQLRActiveFlag)
       // {
            //SortedList<String, String> wSL = testSelectedItemData(aStaffSpec);
            //return (
            //    ((aEHDDBActiveFlag=="%")||(wSL["EHDDBActive"] == aEHDDBActiveFlag)) &&
            //    ((aSHDDBActiveFlag=="%")||(wSL["SHDDBActive"] == aSHDDBActiveFlag)) &&
            //    ((aQLRActiveFlag=="%")||(wSL["QLRActive"] == aQLRActiveFlag)) &&
            //    (wSL["EHDDBData"]=="OK") &&
            //    (wSL["SHDDBData"]=="OK") &&
            //    (wSL["QLRData"]=="OK")
            //  );
        //}

        protected virtual void doSelectedItem(studentSpec aStudentSpec) { }

        protected override void doSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            if (aStudentSpecSL.Count > 0)
                foreach (studentSpec aSS in aStudentSpecSL.Values)
                    doSelectedItem(aSS);
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime) { }
    }
    class defaultCouplerCreateGoogleGroup : defaultCoupler
    {
        public defaultCouplerCreateGoogleGroup
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }
        //  create a SP for returning ALL sites for a studentID hat ^ delimitted
        // or add extra column in wcStudentPrimaryCourse ?? maybe not.

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //try
            //{
            //    AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            //}
            //catch (AppsException uex)
            //{
            //    String msg = uex.Message;
            //    String sReason = uex.Reason.ToString();
            //}

            try
            {
                UserEntry ue = service.RetrieveUser(aStudentSpec.NDSName.ToString());
                //service.
                
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so create the user ?
                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }

            //user exists.
            bool rls = false;
            bool mm = false;
            bool trident = false;
            bool rugby = false;
            bool henley = false;
            bool pershore = false;
            bool googleRls = false;
            bool googleMM = false;
            bool googleTrident = false;
            bool googleRugby = false;
            bool googleHenley = false;
            bool googlePershore = false;
            try
            {
                // Add user to group 

                if (service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "broadcast") == false)
                    
                {
                    try
                    {
                        service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "broadcast");
                    }
                    catch (AppsException uex)
                    {
                        String msg = uex.Message;
                        String sReason = uex.Reason.ToString();
                    }
                    catch (System.Net.WebException webEx)
                    {
                        String webMsg = webEx.Message.ToString();
                    }
                    catch (Exception gEx)
                    {
                        String gMsg = gEx.Message.ToString();
                    }

                }
                //
                DataView wCouplerDV = studentUtility.readDataView(studentUtility.couplerDB, "wcStudentSites '" + aStudentSpec.NDSName.ToString() + "'");
                if (wCouplerDV.Count > 0)
                {
                    // start pershore
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("PER") >= 0) pershore = true;
                    googlePershore = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "pershore");
                    
                    if (googlePershore && !pershore)
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "pershore");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (pershore && !googlePershore)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "pershore");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end pershore

                    // start lspa
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("RLS") >= 0) rls = true;

                    googleRls = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "lspa");
                    if (googleRls && !rls )
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "lspa");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (rls && !googleRls)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "lspa");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end lspa

                    // start rugby
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("RUG") >= 0) rugby = true;

                    googleRugby = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "rugby");
                    if (googleRugby && !rugby)
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "rugby");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (rugby && !googleRugby)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "rugby");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end rugby
                    // start moreton morrell
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("MM") >= 0) mm = true;

                    googleMM = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "moreton");
                    if (googleMM && !mm)
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "moreton");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (mm && !googleMM)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "moreton");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end moreton morrell

                    // start trident
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("TP") >= 0) trident = true;

                    googleTrident = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "trident");
                    if (googleTrident && !trident)
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "trident");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (trident && !googleTrident)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "trident");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end trident
                    // start henley
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("HIA") >= 0) henley = true;

                    googleHenley = service.Groups.IsMember(aStudentSpec.NDSName.ToString(), "henley");
                    if (googleHenley && !henley)
                    {
                        try
                        {
                            service.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString(), "henley");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (henley && !googleHenley)
                        {
                            try
                            {
                                service.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString(), "henley");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end henley

                }

                mWritten.Add(aStudentSpec.queueItem.ToString());
                
            }
            catch (AppsException uexi)
            {
                String msgi = uexi.Message;
                String sReasoni = uexi.Reason.ToString();
                if (uexi.ErrorCode == AppsException.UserDeletedRecently)
                {
                    //User deleted recently - wait at least 5 days
                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }



            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }

        

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            // this is for the GROUP test phase
            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = service.RetrieveUser(wSS.NDSName.ToString());
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    bool rls = false;
                    bool mm = false;
                    bool trident = false;
                    bool rugby = false;
                    bool henley = false;
                    bool pershore = false;
                    bool groupsDone = true;
                    DataView wCouplerDV = studentUtility.readDataView(studentUtility.couplerDB, "wcStudentSites '" + wSS.NDSName.ToString() + "'" );
                    if (wCouplerDV.Count > 0)
                    {
                        bool googleBroadcast = service.Groups.IsMember(wSS.NDSName.ToString(), "broadcast");
                        if (googleBroadcast == false) groupsDone = false;

                        bool googleRLS = service.Groups.IsMember(wSS.NDSName.ToString(),"lspa");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("RLS") >= 0) rls = true;
                        if (googleRLS != rls) groupsDone = false;

                        bool googlePershore = service.Groups.IsMember(wSS.NDSName.ToString(), "pershore");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("PER") >= 0) pershore = true;
                        if (googlePershore != pershore) groupsDone = false;

                        bool googlemoreton = service.Groups.IsMember(wSS.NDSName.ToString(), "moreton");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("MM") >= 0) mm = true;
                        if (googlemoreton != mm) groupsDone = false;

                        bool googleTrident = service.Groups.IsMember(wSS.NDSName.ToString(), "trident");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("TP") >= 0) trident = true;
                        if (googleTrident != trident) groupsDone = false;

                        bool googleHenley = service.Groups.IsMember(wSS.NDSName.ToString(), "henley");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("HIA") >= 0) henley = true;
                        if (googleHenley != henley) groupsDone = false;

                        bool googleRugby = service.Groups.IsMember(wSS.NDSName.ToString(), "rugby");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("RUG") >= 0) rugby = true;
                        if (googleRugby != rugby) groupsDone = false;
                    }
                    if (groupsDone) mTestedOK.Add(wSS.queueItem.ToString());

                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                    }
                }
                catch (System.Net.WebException webEx)
                {
                    String webMsg = webEx.Message.ToString();
                }
                catch (Exception gEx)
                {
                    String gMsg = gEx.Message.ToString();
                }


                //if (testSelectedItem(wSS, "T", "T", "Y"))
                //    mTestedOK.Add(wSS.queueItem.ToString());
                //else
                //    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
            }
        }


    }
    class defaultCouplerCreateGoogle : defaultCoupler
    {
        public defaultCouplerCreateGoogle
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = service.RetrieveUser(aStudentSpec.NDSName.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                  //User does not exist in Google Apps so create the user
                    try
                    {
                        String password = studentUtility.createGooglePassword(aStudentSpec.NDSName);
                        // UserEntry ueCreate = service.CreateUser("atestLAN12347", "Steve", "Langley", "c0v3ntry");
                        UserEntry ueCreate = service.CreateUser(aStudentSpec.NDSName.ToString(), aStudentSpec.Forename.ToString(), aStudentSpec.Surname.ToString(),password);
                        mWritten.Add(aStudentSpec.queueItem.ToString());
                        String[] queueItem;
                        queueItem = new String[1];
                        queueItem[0] = aStudentSpec.queueItem.ToString();
                        int rowsChanged = studentUtility.updateCouplerMessageQueueSet(queueItem, " SET actionData='" + password + "'");
                    }
                    catch (AppsException uexi)
                    {
                        String msgi = uexi.Message;
                        String sReasoni = uexi.Reason.ToString();
                        if (uexi.ErrorCode == AppsException.UserDeletedRecently) 
                        {
                            studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(), "SET actionData = 'CMQ - User deleted recently - wait at least 5 days'");
                            //User deleted recently - wait at least 5 days ok
                        }
                    }
                    catch (System.Net.WebException webEx)
                    {
                        String webMsg = webEx.Message.ToString();
                    }
                    catch (Exception gEx)
                    {
                        String gMsg = gEx.Message.ToString();
                    }

                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                    try
                    {
                        //if this webservice fails ensure the proxy settings are st
                        // for the 'lan settings' in IE.
                        UserEntry ue = service.RetrieveUser(wSS.NDSName.ToString());
                        //ue.Login.Password = "seaside";
                        //ue.Update();
                        //UserEntry ue = service.RetrieveUser("atestlan12347");
                        studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                        mTestedOK.Add(wSS.queueItem.ToString());
                        //Write a coupler job for moveObject here
                        studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                    }
                    catch (AppsException uex)
                    {
                        String msg = uex.Message;
                        String sReason = uex.Reason.ToString();
                        if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                        if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                        {
                            //User does not exist in Google Apps
                        }
                    }
               
                    catch (System.Net.WebException webEx)
                    {
                        String webMsg = webEx.Message.ToString();
                    }
                    catch (Exception gEx)
                    {
                        String gMsg = gEx.Message.ToString();
                    }

                //if (testSelectedItem(wSS, "T", "T", "Y"))
                //    mTestedOK.Add(wSS.queueItem.ToString());
                //else
                //    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
            }
        }

    }

// ================================================================================================================
// New STUFF

    class defaultCouplerCreateGoogleLogin : defaultCoupler
    {
        public defaultCouplerCreateGoogleLogin
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = serviceTEST.RetrieveUser(aStudentSpec.NDSName.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so create the user
                    try
                    {
                        String password = studentUtility.createGooglePassword(aStudentSpec.NDSName);
                        // UserEntry ueCreate = service.CreateUser("atestLAN12347", "Steve", "Langley", "c0v3ntry");
                        UserEntry ueCreate = serviceTEST.CreateUser(aStudentSpec.NDSName.ToString(), aStudentSpec.Forename.ToString(), aStudentSpec.Surname.ToString(), password);
                        mWritten.Add(aStudentSpec.queueItem.ToString());
                        String[] queueItem;
                        queueItem = new String[1];
                        queueItem[0] = aStudentSpec.queueItem.ToString();
                        int rowsChanged = studentUtility.updateCouplerMessageQueueSet(queueItem, " SET actionData='" + password + "'");
                    }
                    catch (AppsException uexi)
                    {
                        String msgi = uexi.Message;
                        String sReasoni = uexi.Reason.ToString();
                        if (uexi.ErrorCode == AppsException.UserDeletedRecently)
                        {
                            studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(), "SET actionData = 'CMQ - User deleted recently - wait at least 5 days'");
                            //User deleted recently - wait at least 5 days ok
                        }
                    }
                    catch (System.Net.WebException webEx)
                    {
                        String webMsg = webEx.Message.ToString();
                    }
                    catch (Exception gEx)
                    {
                        String gMsg = gEx.Message.ToString();
                    }

                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    //if this webservice fails ensure the proxy settings are st
                    // for the 'lan settings' in IE.
                    UserEntry ue = serviceTEST.RetrieveUser(wSS.NDSName.ToString());
                    //ue.Login.Password = "seaside";
                    //ue.Update();
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                    mTestedOK.Add(wSS.queueItem.ToString());
                    //Write a coupler job for GoogleGroups management here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAddLogin");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                    }
                }

                catch (System.Net.WebException webEx)
                {
                    String webMsg = webEx.Message.ToString();
                }
                catch (Exception gEx)
                {
                    String gMsg = gEx.Message.ToString();
                }

                //if (testSelectedItem(wSS, "T", "T", "Y"))
                //    mTestedOK.Add(wSS.queueItem.ToString());
                //else
                //    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
            }
        }

    }

// -------------------------------------------------------------------------------------------------------------

    class defaultCouplerCreateGoogleGroupLogin : defaultCoupler
    {
        public defaultCouplerCreateGoogleGroupLogin
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }
        //  create a SP for returning ALL sites for a studentID hat ^ delimitted
        // or add extra column in wcStudentPrimaryCourse ?? maybe not.

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //try
            //{
            //    AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            //}
            //catch (AppsException uex)
            //{
            //    String msg = uex.Message;
            //    String sReason = uex.Reason.ToString();
            //}

            try
            {
                UserEntry ue = serviceTEST.RetrieveUser(aStudentSpec.NDSName.ToString().Trim());
                //service.

            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {   
                    //User does not exist in Google Apps so create the user ?
                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }

            //user exists.
            bool rls = false;
            bool mm = false;
            bool trident = false;
            bool rugby = false;
            bool henley = false;
            bool pershore = false;
            bool googleRls = false;
            bool googleMM = false;
            bool googleTrident = false;
            bool googleRugby = false;
            bool googleHenley = false;
            bool googlePershore = false;


            try
            {
                // Add user to group 
                //serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString().Trim() + "@test.warwickshire.ac.uk", "STUDENT-ARDN");

                if (serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "broadcast" + "@student.warwickshire.ac.uk") == false)
                {
                    try
                    {
                        serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString().Trim() + "@student.warwickshire.ac.uk", "broadcast" + "@student.warwickshire.ac.uk");
                    }
                    catch (AppsException uex)
                    {
                        String msg = uex.Message;
                        String sReason = uex.Reason.ToString();
                    }
                    catch (System.Net.WebException webEx)
                    {
                        String webMsg = webEx.Message.ToString();
                    }
                    catch (Exception gEx)
                    {
                        String gMsg = gEx.Message.ToString();
                    }

                }
                //
                DataView wCouplerDV = studentUtility.readDataView(studentUtility.couplerDB, "wcStudentSites '" + aStudentSpec.NDSName.ToString() + "'");
                if (wCouplerDV.Count > 0)
                {
                    // start pershore
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("PER") >= 0) pershore = true;
                    googlePershore = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "pershore" + "@student.warwickshire.ac.uk");

                    if (googlePershore && !pershore)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "pershore" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (pershore && !googlePershore)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "pershore" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end pershore

                    // start lspa
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("RLS") >= 0) rls = true;

                    googleRls = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "lspa" + "@student.warwickshire.ac.uk");
                    if (googleRls && !rls)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "lspa" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (rls && !googleRls)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "lspa" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end lspa

                    // start rugby
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("RUG") >= 0) rugby = true;

                    googleRugby = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "rugby" + "@student.warwickshire.ac.uk");
                    if (googleRugby && !rugby)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "rugby" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (rugby && !googleRugby)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "rugby" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end rugby
                    // start moreton morrell
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("MM") >= 0) mm = true;

                    googleMM = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "moreton" + "@student.warwickshire.ac.uk");
                    if (googleMM && !mm)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "moreton" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (mm && !googleMM)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "moreton" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end moreton morrell

                    // start trident
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("TP") >= 0) trident = true;

                    googleTrident = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "trident" + "@student.warwickshire.ac.uk");
                    if (googleTrident && !trident)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "trident" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (trident && !googleTrident)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "trident" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end trident
                    // start henley
                    if (wCouplerDV[0][0].ToString().Trim().IndexOf("HIA") >= 0) henley = true;

                    googleHenley = serviceTEST.Groups.IsMember(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "henley" + "@student.warwickshire.ac.uk");
                    if (googleHenley && !henley)
                    {
                        try
                        {
                            serviceTEST.Groups.RemoveMemberFromGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "henley" + "@student.warwickshire.ac.uk");
                        }
                        catch (AppsException uex)
                        {
                            String msg = uex.Message;
                            String sReason = uex.Reason.ToString();
                        }
                        catch (System.Net.WebException webEx)
                        {
                            String webMsg = webEx.Message.ToString();
                        }
                        catch (Exception gEx)
                        {
                            String gMsg = gEx.Message.ToString();
                        }

                    }
                    else
                    {
                        if (henley && !googleHenley)
                        {
                            try
                            {
                                serviceTEST.Groups.AddMemberToGroup(aStudentSpec.NDSName.ToString() + "@student.warwickshire.ac.uk", "henley" + "@student.warwickshire.ac.uk");
                            }
                            catch (AppsException uex)
                            {
                                String msg = uex.Message;
                                String sReason = uex.Reason.ToString();
                            }
                            catch (System.Net.WebException webEx)
                            {
                                String webMsg = webEx.Message.ToString();
                            }
                            catch (Exception gEx)
                            {
                                String gMsg = gEx.Message.ToString();
                            }

                        }
                    }
                    // end henley

                }

                mWritten.Add(aStudentSpec.queueItem.ToString());

            }
            catch (AppsException uexi)
            {
                String msgi = uexi.Message;
                String sReasoni = uexi.Reason.ToString();
                if (uexi.ErrorCode == AppsException.UserDeletedRecently)
                {
                    //User deleted recently - wait at least 5 days
                }
            }
            catch (System.Net.WebException webEx)
            {
                String webMsg = webEx.Message.ToString();
            }
            catch (Exception gEx)
            {
                String gMsg = gEx.Message.ToString();
            }



            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            // this is for the GROUP test phase
            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = serviceTEST.RetrieveUser(wSS.NDSName.ToString());
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    bool rls = false;
                    bool mm = false;
                    bool trident = false;
                    bool rugby = false;
                    bool henley = false;
                    bool pershore = false;
                    bool groupsDone = true;

                    bool googleBroadcast = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "broadcast" + "@student.warwickshire.ac.uk");
                    if (googleBroadcast == false) groupsDone = false;
                    DataView wCouplerDV = studentUtility.readDataView(studentUtility.couplerDB, "wcStudentSites '" + wSS.NDSName.ToString() + "'");
                    if (wCouplerDV.Count > 0)
                    {

                        bool googleRLS = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "lspa" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("RLS") >= 0) rls = true;
                        if (googleRLS != rls) groupsDone = false;

                        bool googlePershore = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "pershore" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("PER") >= 0) pershore = true;
                        if (googlePershore != pershore) groupsDone = false;

                        bool googlemoreton = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "moreton" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("MM") >= 0) mm = true;
                        if (googlemoreton != mm) groupsDone = false;

                        bool googleTrident = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "trident" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("TP") >= 0) trident = true;
                        if (googleTrident != trident) groupsDone = false;

                        bool googleHenley = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "henley" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("HIA") >= 0) henley = true;
                        if (googleHenley != henley) groupsDone = false;

                        bool googleRugby = serviceTEST.Groups.IsMember(wSS.NDSName.ToString() + "@student.warwickshire.ac.uk", "rugby" + "@student.warwickshire.ac.uk");
                        if (wCouplerDV[0][0].ToString().Trim().IndexOf("RUG") >= 0) rugby = true;
                        if (googleRugby != rugby) groupsDone = false;
                    
                    }
                    else // there are no sites for this student
                    {
                        rls = true;
                        pershore = true;
                        mm = true;
                        trident = true;
                        henley = true;
                        rugby    = true;
                    }
                    if (groupsDone) mTestedOK.Add(wSS.queueItem.ToString());

                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                    }
                }
                catch (System.Net.WebException webEx)
                {
                    String webMsg = webEx.Message.ToString();
                }
                catch (Exception gEx)
                {
                    String gMsg = gEx.Message.ToString();
                }


                //if (testSelectedItem(wSS, "T", "T", "Y"))
                //    mTestedOK.Add(wSS.queueItem.ToString());
                //else
                //    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
            }
        }

    }

// -------------------------------------------------------------------------------------------------------------

    class defaultCouplerSuspendGoogleLogin : defaultCoupler
    {
        public defaultCouplerSuspendGoogleLogin
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {

                UserEntry ue = serviceTEST.RetrieveUser(aStudentSpec.NDSName.ToString());
                serviceTEST.SuspendUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so we are done.
                    studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(), "SET actionData = 'CMQ.UserDoesNotExistInGoogle'");
                    //mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = serviceTEST.RetrieveUser(wSS.NDSName.ToString());
                    if (ue.Login.Suspended == true)
                    {
                        studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                        mTestedOK.Add(wSS.queueItem.ToString());

                    }
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        //mTestedOK.Add(wSS.queueItem.ToString());

                    }
                }

            }
        }

    }
    // --------------------------------------------------------------------------------------------------------
    class defaultCouplerRestoreGoogleLogin : defaultCoupler
    {
        public defaultCouplerRestoreGoogleLogin
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = serviceTEST.RetrieveUser(aStudentSpec.NDSName.ToString());
                serviceTEST.RestoreUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());

            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(), "SET actionData = 'CMQ.UserDoesNotExistInGoogle'");
                    //User does not exist in Google Apps so we are done.
                    //mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = serviceTEST.RetrieveUser(wSS.NDSName.ToString());
                    
                    // if fore name or surname need updating then do it here.

                    if ((String.Compare(ue.Name.FamilyName.ToLower().Trim().ToString(), wSS.Surname.ToLower().Trim().ToString()) != 0) || (String.Compare(ue.Name.GivenName.ToLower().Trim().ToString(), wSS.Forename.ToLower().Trim().ToString()) != 0))
                    {
                        ue.Name.FamilyName = wSS.Surname.Trim().ToString();
                        ue.Name.GivenName = wSS.Forename.Trim().ToString();
                        ue.Update();
                    }
                    //String gn2 = ue.Name.FamilyName.ToString();

                    if (ue.Login.Suspended == false)
                    {
                        studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                        mTestedOK.Add(wSS.queueItem.ToString());
                        //Write a coupler job for GoogleGroups management here
                        studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAddLogin");

                    }
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        //mTestedOK.Add(wSS.queueItem.ToString());

                    }
                }

            }
        }

    }
// -------------------------------------------------------------------------------------------------------------

    class defaultCouplerDeleteGoogleLogin : defaultCoupler
    {
        public defaultCouplerDeleteGoogleLogin
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = serviceTEST.RetrieveUser(aStudentSpec.NDSName.ToString());
                serviceTEST.DeleteUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so we are done.
                    mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = serviceTEST.RetrieveUser(wSS.NDSName.ToString());
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        if (wSS.courseTitle.ToString().ToLower().Trim() == "deleted nds record") // this means that the NDS record has been deleted
                        {
                            //create a coupler job to remove the wcStudentPrimaryCourse record
                            studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "DeleteWcSPCourse");
                            mTestedOK.Add(wSS.queueItem.ToString());
                        }

                    }
                }

            }
        }

    }


// End of NEW stuff
// ==============================================================================================================
    
    
    class defaultCouplerDeleteGoogle : defaultCoupler
    {
        public defaultCouplerDeleteGoogle
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = service.RetrieveUser(aStudentSpec.NDSName.ToString());
                service.DeleteUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so we are done.
                    mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = service.RetrieveUser(wSS.NDSName.ToString());
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        //if (wSS.courseTitle.ToString().ToLower().Trim() == "deleted nds record") // this means that the NDS record has been deleted
                        //{
                            //create a coupler job to remove the wcStudentPrimaryCourse record
                            //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "DeleteWcSPCourse");
                            mTestedOK.Add(wSS.queueItem.ToString());
                        //}

                    }
                }

            }
        }

    }
    class defaultCouplerSuspendGoogle : defaultCoupler
    {
        public defaultCouplerSuspendGoogle
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
               
                UserEntry ue = service.RetrieveUser(aStudentSpec.NDSName.ToString());
                service.SuspendUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    //User does not exist in Google Apps so we are done.
                    studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(),"SET actionData = 'CMQ.UserDoesNotExistInGoogle'");
                    //mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = service.RetrieveUser(wSS.NDSName.ToString());
                    if (ue.Login.Suspended == true)
                    {
                        studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                        mTestedOK.Add(wSS.queueItem.ToString());

                    }
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        //mTestedOK.Add(wSS.queueItem.ToString());

                    }
                }

            }
        }

    }
    class defaultCouplerRestoreGoogle : defaultCoupler
    {
        public defaultCouplerRestoreGoogle
            (String csSHDDB, String csEHDDB, String csQLRDB, String aActionName, int aTryCount)
            : base(csSHDDB, csEHDDB, csQLRDB, aActionName, aTryCount) { }

        protected override void doSelectedItem(studentSpec aStudentSpec)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");
            try
            {
                UserEntry ue = service.RetrieveUser(aStudentSpec.NDSName.ToString());
                service.RestoreUser(aStudentSpec.NDSName.ToString());
                mWritten.Add(aStudentSpec.queueItem.ToString());
                
            }
            catch (AppsException uex)
            {
                String msg = uex.Message;
                String sReason = uex.Reason.ToString();
                bool sitePershore = false;
                if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                {
                    studentUtility.updateCouplerMessageQueue(aStudentSpec.queueItem.ToString(), "SET actionData = 'CMQ.UserDoesNotExistInGoogle'");
                    //User does not exist in Google Apps so we are done.
                    //mWritten.Add(aStudentSpec.queueItem.ToString());
                }
            }


            //updateSelectedItem(aStudentSpec, "T", "T", "Y");
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            //AppsService service = new AppsService("stu.warwickshire.ac.uk", "gadmin@stu.warwickshire.ac.uk", "thebigpic7ure");

            foreach (studentSpec wSS in aStudentSpecSL.Values)
            {

                try
                {
                    UserEntry ue = service.RetrieveUser(wSS.NDSName.ToString());
                    // if fore name or surname need updating then do it here.

                    if ((String.Compare(ue.Name.FamilyName.ToLower().Trim().ToString(), wSS.Surname.ToLower().Trim().ToString()) != 0) || (String.Compare(ue.Name.GivenName.ToLower().Trim().ToString(), wSS.Forename.ToLower().Trim().ToString()) != 0))
                    {  
                        ue.Name.FamilyName = wSS.Surname.Trim().ToString();
                        ue.Name.GivenName = wSS.Forename.Trim().ToString();
                        ue.Update();
                    }
                    //String gn2 = ue.Name.FamilyName.ToString();

                    if (ue.Login.Suspended == false)
                    {
                        studentUtility.updateCouplerMessageQueue(wSS.queueItem.ToString(), "SET actionData = ''");
                        mTestedOK.Add(wSS.queueItem.ToString());

                    }
                    //UserEntry ue = service.RetrieveUser("atestlan12347");
                    //Write a coupler job for moveObject here
                    //studentUtility.writeCouplerMessageQueueStu(wSS.NDSName, "", "GoogleGroupAdd");

                }
                catch (AppsException uex)
                {
                    String msg = uex.Message;
                    String sReason = uex.Reason.ToString();
                    if (wSS.attempts > mTryCount) mFailed.Add(wSS.queueItem.ToString());
                    if (uex.ErrorCode == AppsException.EntityDoesNotExist)
                    {
                        //User does not exist in Google Apps
                        //mTestedOK.Add(wSS.queueItem.ToString());

                    }
                }

            }
        }

    }

}

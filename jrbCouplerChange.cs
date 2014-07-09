using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.DirectoryServices;

namespace couplerWriter
{

    class jrbCouplerChangeDetails : jrbCoupler
    {
        public jrbCouplerChangeDetails
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                //String Password = "seaside";
                //String ExpireDate = "none";
                String Description = "Changed on " + DateTime.Now;
                String wNewStaffJRBText = "";
                wNewStaffJRBText +=
                    "\"" + aStudentSpec.NDSName + "\"" + "," + "\"" + aStudentSpec.Surname.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Forename.ToUpper() + "\"" + 
                    "," + "\"" + FullName.ToUpper() + "\"" + "," + "\"" + aStudentSpec.Department.ToUpper() + "\"" +
                    //"," + "\"" + aStudentSpec.Site.ToUpper() + "\"" + 
                    "," + "\"" + aStudentSpec.Description.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.MaxConnections.ToString() + "\"" + "," + "\"" + aStudentSpec.EmailAddress.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Telephone.ToString().Trim() + "\""; //+
                    //"," + "\"" + aStudentSpec.VolumeRestrictions.ToString().Trim() + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected Boolean GetDescriptionChanged(String Desc)
        {
            // test for each Stucourse in NDScourses if exist then return true.
            //the NDS field telephonenumber holds the student courses.
            String[] NDSCourses = attributeArray("description");
            String[] Stucourses = Desc.Split('^');

            int i = Stucourses.Length;
            int k = 0;
            //String x = Stucourses[0].Replace("\"","");
            foreach (String sCourse in Stucourses)
            {
                if (NDSCourses != null)
                {
                    foreach (String Course in NDSCourses)
                    {
                        if (sCourse.ToString().ToUpper().Trim().Replace("\"", "") == Course.ToString().ToUpper().Trim()) k++;
                    }
                }
            }
            return k == i;
        }
        protected Boolean GetTelephoneChanged(String Tel)
        {
            // test for each Stucourse in NDScourses if exist then return true.
            //the NDS field telephonenumber holds the student courses.
            String[] NDSCourses = attributeArray("telephonenumber");
            String[] Stucourses = Tel.Split('^');

            int i = Stucourses.Length;
            int k = 0;
            //String x = Stucourses[0].Replace("\"","");
            foreach (String sCourse in Stucourses)
            {
                foreach (String Course in NDSCourses)
                {
                    if (sCourse.ToString().ToUpper().Trim().Replace("\"", "") == Course.ToString().ToUpper().Trim()) k++;
                }
            }
            return k == i;
        }


        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                    if ((mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName)) != null)
                    {
                        String x = attributeValue("gwexpire").ToString();
                        Boolean b = GetDescriptionChanged(ss.Description.ToString());
                        //Boolean c = GetTelephoneChanged(ss.Telephone.ToString());
                        if (attributeValue("logindisabled").ToLower() == "false" && GetDescriptionChanged(ss.Description.ToString()) == true)
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

    class jrbCouplerChangeDetailsForMoves : jrbCoupler
    {
        public jrbCouplerChangeDetailsForMoves
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {

            if (aStudentSpec.QLId != "")
            {
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                //String Password = "seaside";
                //String ExpireDate = "none";
                String Description = "Changed on " + DateTime.Now;
                String wNewStaffJRBText = "";
                wNewStaffJRBText +=
                    "\"" + aStudentSpec.NDSName + "\"" + "," + "\"" + aStudentSpec.Surname.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Forename.ToUpper() + "\"" +
                    "," + "\"" + FullName.ToUpper() + "\"" + "," + "\"" + aStudentSpec.Department.ToUpper() + "\"" +
                    //"," + "\"" + aStudentSpec.Site.ToUpper() + "\"" + 
                    "," + "\"" + aStudentSpec.Description.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.MaxConnections.ToString() + "\"" + "," + "\"" + aStudentSpec.EmailAddress.ToUpper() + "\"" +
                    "," + "\"" + aStudentSpec.Telephone.ToString().Trim() + "\""; // +
                    //"," + "\"" + aStudentSpec.VolumeRestrictions.ToString().Trim() + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            String NDScontext = "";
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                if ((mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName)) != null)
                {
                    String x = attributeValue("gwexpire").ToString();
                    if (attributeValue("logindisabled").ToLower() == "false")
                    {
                        //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 0");
                        
                        mTestedOK.Add(ss.queueItem.ToString());

                        //Write a coupler job for moveObject here
                        String[] aPath = attributeValue("adspath").Split('=');
                        if (aPath.Length > 0) NDScontext = aPath[2].Substring(0, aPath[2].IndexOf(',')) + "." + aPath[3].Substring(0, aPath[3].IndexOf(',')) + "." + aPath[4].Substring(0, aPath[4].IndexOf(',')) + "." + aPath[5].ToString();
                        if (NDScontext.ToUpper().Trim() != ss.Context.ToUpper().Trim())
                        {
                            studentUtility.writeCouplerMessageQueueStu(ss.NDSName, "", "MoveObjectNDS");
                        }
                    }
                    else
                        if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }
    }

    class jrbCouplerMoveObject : jrbCoupler
    {
        public jrbCouplerMoveObject
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                
                String wNewStaffJRBText =
                    "." + aStudentSpec.NDSName.Trim() + "." +
                     aStudentSpec.PreContext.Trim() + " " +
                    "." + aStudentSpec.Context.Trim() ;
                return wNewStaffJRBText;
            }
            else return "";
        }


        protected String GetHomeDirCouplerJob(String context)
        {
            string HomeDirCouplerJob = "MoveHomeNDStoRLS";
            // case statment returning the MoveHomeAction
            switch (context.ToUpper().Trim())
            {
            case "USERS.STUDENTS.LSPA.WC":
                HomeDirCouplerJob = "MoveHomeNDStoRLS";
                break;
            case "USERS.STUDENTS.RUG.WC":
                HomeDirCouplerJob = "MoveHomeNDStoRUG";
                break;
            case "USERS.STUDENTS.TRIDENT.WC":
                HomeDirCouplerJob = "MoveHomeNDStoTRI";
                break;
            case "USERS.STUDENTS.PER.WC":
                HomeDirCouplerJob = "MoveHomeNDStoPER";
                break;
            case "USERS.STUDENTS.MM.WC":
                HomeDirCouplerJob = "MoveHomeNDStoMM";
                break;
            case "USERS.STUDENTS.ARDN.WC":
                HomeDirCouplerJob = "MoveHomeNDStoARD";
                break;

            default:
                break;
        }
           
            
            return (HomeDirCouplerJob.ToString());


        }

 
        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            String NDScontext = "";
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                String [] aPath = attributeValue("adspath").Split('=');
                if (aPath.Length > 0) NDScontext = aPath[2].Substring(0, aPath[2].IndexOf(',')) + "." + aPath[3].Substring(0, aPath[3].IndexOf(',')) + "." + aPath[4].Substring(0, aPath[4].IndexOf(',')) + "." + aPath[5].ToString();
                if (NDScontext.ToUpper().Trim() == ss.Context.ToUpper().Trim())
                {
                    //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 1");

                    studentUtility.writeCouplerMessageQueueStu(ss.NDSName, "", GetHomeDirCouplerJob(ss.Context.ToUpper().Trim()));
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerMoveHomeDir : jrbCoupler
    {
        public jrbCouplerMoveHomeDir
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String wNewStaffJRBText =
                    "." + aStudentSpec.NDSName.Trim() + "." + aStudentSpec.Context ;
                return wNewStaffJRBText;
            }
            else return "";
        }

        protected String GetHomeDir(String context)
        {
            string HomeDir = "";
            // case statment returning the MoveHomeAction
            switch (context.ToUpper().Trim())
            {
                case "USERS.STUDENTS.LSPA.WC":
                    HomeDir = "ORION_STUDENT_HOME";
                    break;
                case "USERS.STUDENTS.RUG.WC":
                    HomeDir = "KA_STUDENT_HOME";
                    break;
                case "USERS.STUDENTS.TRIDENT.WC":
                    HomeDir = "ROVER_STUDENT_HOME";
                    break;
                case "USERS.STUDENTS.PER.WC":
                    HomeDir = "BRAVO_STUDENT_HOME";
                    break;
                case "USERS.STUDENTS.MM.WC":
                    HomeDir = "SIERRA_STUDENT_HOME";
                    break;
                case "USERS.STUDENTS.ARDN.WC":
                    HomeDir = "NOVA_STUDENT_HOME";
                    break;

                default:
                    break;
            }
            return (HomeDir.ToString());
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            String NDSHomeDir = "";
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                
                //Byte[] x = attributeValue("ndshomedirectory"); 
                String[] aPath = attributeValue("ndshomedirectory").Split('=');
                if (aPath.Length > 1)
                    if (aPath[1].IndexOf(',') > 0)
                    {
                        NDSHomeDir = aPath[1].Substring(0, aPath[1].IndexOf(','));
                    }
                if (NDSHomeDir.ToUpper().Trim() == GetHomeDir(ss.Context.ToUpper().Trim()))
                {
                    //studentUtility.updateWcStaffIdentity(ss.NDSName, "SET NDSdisabled = 1");
                    // don't need this as we are not using groupwise now.
                    //studentUtility.writeCouplerMessageQueueStu(ss.NDSName, "", "LinkStudentLogin");
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerLinkLogin : jrbCoupler
    {
        public jrbCouplerLinkLogin
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {

                String wNewStaffJRBText =
                    "." + aStudentSpec.NDSName.Trim() + ".po-students.students.groupwise.wc";
                return wNewStaffJRBText;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            String NDSPostOffice = "";
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);

                //Byte[] x = attributeValue("ndshomedirectory"); 
                String[] aPath = attributeValue("ngwpostoffice").Split('=');
                if(aPath.Length > 0) NDSPostOffice = aPath[1].Substring(0, aPath[1].IndexOf(',')) + "." + aPath[2].Substring(0, aPath[2].IndexOf(',')) + "." + aPath[3].ToString();
                if (NDSPostOffice.ToUpper().Trim() == "PO-STUDENTS.LSPA.WC")
                {
                    mTestedOK.Add(ss.queueItem.ToString());
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }

    class jrbCouplerAddToGroup : jrbCoupler
    {
        public jrbCouplerAddToGroup
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String Description = "User details changed on " + DateTime.Now;
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                String grpName = aStudentSpec.ActionData.Replace("Group=", "");
                String wNewStaffJRBText =
                    "\"" + aStudentSpec.NDSName + "\"" +
                   "," + "\"" + grpName.Trim() + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected String buildGroupContext(String grp)
        {
            string grpContext = "";
            String[] aItem = grp.Split(',');
            if (aItem.Length > 0 || aItem != null)
            {
                foreach (String aPart in aItem)
                {
                    grpContext = grpContext + "." + aPart.Substring(aPart.IndexOf('=') + 1);
                }
            }
            return (grpContext.ToString().ToUpper());

        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                string y = "";
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                foreach (String grp in attributeArray("grpmbr"))
                {
                    string x = buildGroupContext(grp);
                    if (buildGroupContext(grp) == ss.ActionData.Replace("Group=","").ToString().ToUpper())
                    { 
                        mTestedOK.Add(ss.queueItem.ToString());
                        break;
                    }
                }
                if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());                
            }
        }

    }

    class jrbCouplerRemoveFromGroup : jrbCoupler
    {
        public jrbCouplerRemoveFromGroup
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                String Description = "User details changed on " + DateTime.Now;
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                String grpName = aStudentSpec.ActionData.Replace("Group=", "");
                String wNewStaffJRBText =
                    "\"" + aStudentSpec.NDSName + "\"" +
                   "," + "\"" + grpName.Trim() + "\"";

                return wNewStaffJRBText;
            }
            else return "";
        }

        protected String buildGroupContext(String grp)
        {
            string grpContext = "";
            String[] aItem = grp.Split(',');
            foreach (String aPart in aItem)
            {
                grpContext = grpContext + "." + aPart.Substring(aPart.IndexOf('=') + 1);
            }
            return (grpContext.ToString().ToUpper());

        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                string y = "";
                mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                Boolean grpExists = false;
                foreach (String grp in attributeArray("grpmbr"))
                {
                    if (buildGroupContext(grp) == ss.ActionData.Replace("Group=", "").ToString().ToUpper())
                    {
                        grpExists = true;
                        break;
                    }
                }
                if (! grpExists) mTestedOK.Add(ss.queueItem.ToString());

                if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }



    class jrbCouplerChangeSite : jrbCoupler
    {
        public jrbCouplerChangeSite
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                /*
                 * Use site name, e.g. Rugby, Trident, henley in arden and check 
                 * coupler table for more recent un-processed ChangeSiteNDS messages
                 * for a move to any site. If there is one, ignore, as this is 
                 * probably a duplicate request.
                 */
                String wNewStaffJRBText = "Change site for " + aStudentSpec.NDSName;
                bool doChangeSite = true;
                DataView dv = studentUtility.couplerDV(
                    "WHERE " +
                    "(c.whenDone IS NOT NULL) AND " +
                    "(c.action='ChangeSiteNDS') AND " +
                    "(NDSName='" + aStudentSpec.NDSName + "') AND " +
                    "(c.queueItem=" + aStudentSpec.queueItem.ToString() + ")"
                    );
                if (dv != null) if (dv.Count > 0) doChangeSite = false;
                if (doChangeSite)
                {
                    String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                    bool wB = studentUtility.sendEmail(
                        "itservices@warkscol.ac.uk;" + aStudentSpec.EmailAddress,
                        "idm@warkscol.ac.uk",
                        "Staff Site Change : " + aStudentSpec.NDSName,
                        FullName + "( " + aStudentSpec.NDSName + " ) has indicated a need " +
                        "to change site to " + aStudentSpec.ActionData.Replace("NewSite=", "") + ". " +
                        "Please log a sitehelpdesk job for the network team (infra_op) for this and notify the user when complete. " +
                        "These jobs are normally expected to complete within 2 working days.",
                         null
                    );
                    return wNewStaffJRBText + ".";
                }
                return wNewStaffJRBText + " ignored.";
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                bool testChangeSite = true;
                DataView dv = studentUtility.couplerDV(
                    "WHERE " +
                    "(c.whenDone IS NULL) AND " +
                    "(c.action='" + mActionName + "') AND " +
                    "(NDSName='" + ss.NDSName + "') AND " +
                    "(c.queueItem>" + ss.queueItem.ToString() + ")"
                    );
                if (dv != null) if (dv.Count > 0) testChangeSite = false;
                if (testChangeSite)
                {
                    mAttributeValues = GetLDAPInfo("cn=" + ss.NDSName);
                    String wADSPath = attributeValue("adspath");
                    String wTargetSite = ss.ActionData.Replace("NewSite=", "");
                    Boolean wDoneIt = false;

                    switch (wTargetSite.ToUpper())
                    {
                        case "LEAMINGTON SPA":
                            wDoneIt = (wADSPath.IndexOf("ou=LSPA,o=WC") > 0); break;
                        case "RUGBY":
                            wDoneIt = (wADSPath.IndexOf("ou=RUG,o=WC") > 0); break;
                        case "TRIDENT PARK":
                            wDoneIt = (wADSPath.IndexOf("ou=TRIDENT,o=WC") > 0); break;
                        case "MORETON MORRELL":
                            wDoneIt = (wADSPath.IndexOf("ou=MM,o=WC") > 0); break;
                        case "HENLEY IN ARDEN":
                            wDoneIt = (wADSPath.IndexOf("ou=ARDN,o=WC") > 0); break;
                        case "PERSHORE":
                            wDoneIt = (wADSPath.IndexOf("ou=PER,o=WC") > 0); break;
                        default:
                            break;
                    }
                    if (wDoneIt)
                        mTestedOK.Add(ss.queueItem.ToString());
                    else
                        if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
                }
                else
                    mTestedOK.Add(ss.queueItem.ToString());
            }
        }

    }


    class jrbCouplerChangeLogin : jrbCoupler
    {
        public jrbCouplerChangeLogin
            (String aJRBFilesPath, String aActionName, int aTryCount)
            : base(aJRBFilesPath, aActionName, aTryCount) { }

        protected override String doSelectedItem(studentSpec aStudentSpec)
        {
            if (aStudentSpec.QLId != "")
            {
                /* 
                  Currently a stub procedure

                  1. Send email to IT Services advising
                     of need to change login.
                  2. Create pending wcStaffIdentity record 
                     by cloning current one but set 
                     IsPending='Y' and NDSName to new value.
                */
                String FullName = aStudentSpec.Forename + " " + aStudentSpec.Surname;
                String NewNDSName = "";
                String[] AD = aStudentSpec.ActionData.Split('=');
                if(AD[0].ToString() == "NewNDS") 
                  NewNDSName = AD[1].ToString();

                bool wB = studentUtility.sendEmail(
                    "itservices@warkscol.ac.uk;mis@warkscol.ac.uk;" + aStudentSpec.EmailAddress,
                    "idm@warkscol.ac.uk",
                    "Staff Login Change : " + aStudentSpec.NDSName,
                    FullName + "( " + aStudentSpec.NDSName + " ) has indicated a need " +
                    "to change login to " + NewNDSName + ". " +
                    "Please log a sitehelpdesk job for the network team (infra_op) for this and notify the user when complete. " +
                    "These jobs are normally expected to complete within 4 working days.",
                     null
                );

                return
                  "Change login processed for " + aStudentSpec.NDSName;
            }
            else return "";
        }

        protected override void testSelectedPhase(studentSpecSL aStudentSpecSL, DateTime runDateTime)
        {
            foreach (studentSpec ss in aStudentSpecSL.Values)
            {
                Boolean wNewLoginOk=false;
                String NewNDSName = "";
                String[] AD = ss.ActionData.Split('=');
                if(AD[0].ToString() == "NewNDS") 
                  NewNDSName = AD[1].ToString();
                // chect to see if the old nds name has been deleted
                mAttributeValues=GetLDAPInfo("cn=" + ss.NDSName);
                if (mAttributeValues == null)
                {
                    // check to see if new nds name has been created
                    mAttributeValues=GetLDAPInfo("cn=" + NewNDSName);
                    if(mAttributeValues.Count>0) wNewLoginOk=true;
                }
                if (wNewLoginOk)
                {
                    // maybe put this in its own coupler class?l
                    // Call staff identity NEW NDS login stored procedure here
                    if (ss.QLId.ToString().Trim().ToLower() != "deleted")
                    {
                        String IDM = "wcIDMupdateNewNDSname " + Convert.ToInt64(ss.QLId);
                        DataView wDV = studentUtility.readDataView(studentUtility.couplerDB, IDM);

                        if (wDV.Count > 0)
                        {
                            if (wDV[0][0].ToString() == "1")
                            {
                                // Success
                                mTestedOK.Add(ss.queueItem.ToString());
                            }
                            else
                            {
                                if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
                            }
                        }
                    }
                    // TEST the stored Procedure wcIDMupdateNewNDSname here
                    // then do the Application part in defaultCouplerUpdateUserName 
                    // maybe call the stored procedure wcIDMupdateNewNDSname to do this
                    /* Success processing 
                       1. Update NDSName on original
                          wcStaffIdentity record
                       2. Delete the IsPending='Y'    
                          wcStaffIdentity record
                       3. Add record to mTestedOk
                    */
                    
                }
                else
                    if (ss.attempts > mTryCount) mFailed.Add(ss.queueItem.ToString());
            }
        }

    }


}

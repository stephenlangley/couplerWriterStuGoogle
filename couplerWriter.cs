using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace couplerWriter
{
    public class couplerWriter
    {
        List<coupler> mCouplerList;
        List<String> mWritten, mSkipped, mTestedOK, mFailed;

        public couplerWriter(String aEHDDB, String aSHDDB, String aQLRDB, String aNDSTargetPath)
        {
            mCouplerList = new List<coupler>();
            mWritten = new List<String>();
            mTestedOK = new List<String>();
            mFailed = new List<String>();
            mSkipped = new List<String>();
            //// GOOGLE APPS ONLY - DO NOT USE ANY OTHERS
            //mCouplerList.Add(new jrbCouplerCreate(aNDSTargetPath + "NewStudentLogins", "CreateNDS", 9));
            //mCouplerList.Add(new jrbCouplerChangeDetails(aNDSTargetPath + "ChangeStudentLogins", "ChangeDetailsNDS", 9));
            //mCouplerList.Add(new jrbCouplerChangeDetailsForMoves(aNDSTargetPath + "ChangeStudentLoginsForMoves", "ChangeDetailsForMovesNDS", 9));
            //mCouplerList.Add(new jrbCouplerDisable(aNDSTargetPath + "DisableStudentLogins", "DisableNDS", 9));
            //mCouplerList.Add(new jrbCouplerMoveObject(aNDSTargetPath + "MveObjectStudentLogins", "MoveObjectNDS", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_Rls", "MoveHomeNDStoRLS", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_MM", "MoveHomeNDStoMM", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_Rug", "MoveHomeNDStoRUG", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_Tri", "MoveHomeNDStoTRI", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_Ard", "MoveHomeNDStoARD", 9));
            ////mCouplerList.Add(new jrbCouplerMoveHomeDir(aNDSTargetPath + "MoveHome_Per", "MoveHomeNDStoPER", 9));
            ////mCouplerList.Add(new jrbCouplerLinkLogin(aNDSTargetPath + "LinkLogins", "LinkStudentLogin", 9));
            ////mCouplerList.Add(new jrbCouplerReconcile(aNDSTargetPath + "Reconcile", "ReconcileNDS", 9));

            // un-comment these lines for going 'LIVE'
            //mCouplerList.Add(new defaultCouplerCreateGoogle(aEHDDB, aSHDDB, aQLRDB, "CreateGoogle", 9));
            //mCouplerList.Add(new defaultCouplerDeleteGoogle(aEHDDB, aSHDDB, aQLRDB, "DeleteGoogle", 9));
            //mCouplerList.Add(new defaultCouplerCreateGoogleGroup(aEHDDB, aSHDDB, aQLRDB, "GoogleGroupAdd", 9));
            //mCouplerList.Add(new defaultCouplerSuspendGoogle(aEHDDB, aSHDDB, aQLRDB, "SuspendGoogle", 9));
            //mCouplerList.Add(new defaultCouplerRestoreGoogle(aEHDDB, aSHDDB, aQLRDB, "RestoreGoogle", 9));
           

            //ONLY use the above lines for google 
            // new stuff for sub domain NOT IMPLEMENTED yet used for testing presently
            //mCouplerList.Add(new defaultCouplerCreateGoogleLogin(aEHDDB, aSHDDB, aQLRDB, "CreateGoogleLogin", 9));
            mCouplerList.Add(new defaultCouplerCreateGoogleGroupLogin(aEHDDB, aSHDDB, aQLRDB, "GoogleGroupAddLogin", 9));
            //mCouplerList.Add(new defaultCouplerSuspendGoogleLogin(aEHDDB, aSHDDB, aQLRDB, "SuspendGoogleLogin", 9));
            //mCouplerList.Add(new defaultCouplerRestoreGoogleLogin(aEHDDB, aSHDDB, aQLRDB, "RestoreGoogleLogin", 9));
            //mCouplerList.Add(new defaultCouplerDeleteGoogleLogin(aEHDDB, aSHDDB, aQLRDB, "DeleteGoogleLogin", 9));

            foreach (coupler c in mCouplerList) c.setResultLists(mWritten, mSkipped, mTestedOK, mFailed);
        }

        public String[] written() { return mWritten.ToArray(); }
        public String[] skipped() { return mSkipped.ToArray(); }
        public String[] testedOK() { return mTestedOK.ToArray(); }
        public String[] failed() { return mFailed.ToArray(); }

        public void doPhase(DataView aCouplerDV)
        {   foreach (coupler c in mCouplerList) c.doPhase(aCouplerDV, DateTime.Now);  }

        public void testPhase(DataView aCouplerDV)
        {   foreach (coupler c in mCouplerList) c.testPhase(aCouplerDV, DateTime.Now);  }

    }
}

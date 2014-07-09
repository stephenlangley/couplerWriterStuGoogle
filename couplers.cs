using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace couplerWriter
{
    class coupler
    {
        protected String mActionName = "";
        protected int mTryCount = 0;
        protected List<String> mWritten, mSkipped, mTestedOK, mFailed;

        public coupler() { }

        public void setResultLists(
            List<String> aWritten, List<String> aSkipped, 
            List<String> aTestedOK, List<String> aFailed)
        {
            mWritten = aWritten; mSkipped = aSkipped;
            mTestedOK = aTestedOK; mFailed = aFailed; 
        }

        protected virtual void doSelectedPhase(studentSpecSL aStaffSpecSL, DateTime runDateTime) { }

        protected virtual void testSelectedPhase(studentSpecSL aStaffSpecSL, DateTime runDateTime) { }

        public void doPhase(DataView aCouplerDV, DateTime runDateTime)
        {
            aCouplerDV.RowFilter = "action='" + mActionName + "'";
            aCouplerDV.Sort = "NDSName, queueItem desc";

            if (aCouplerDV.Count > 0)
            {
                studentSpecSL wSSL = new studentSpecSL(aCouplerDV, mSkipped);
                doSelectedPhase(wSSL, runDateTime);
                foreach (studentSpec aSS in wSSL.Values) 
                { 
                    mWritten.Add(aSS.queueItem.ToString()); 
                }
            }
        }

        public void testPhase(DataView aCouplerDV, DateTime runDateTime)
        {
            aCouplerDV.RowFilter = "action='" + mActionName + "'";
            if (aCouplerDV.Count > 0) testSelectedPhase(new studentSpecSL(aCouplerDV,mSkipped), runDateTime);
        }

    }
}

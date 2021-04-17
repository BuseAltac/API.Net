using System;

namespace WindowsFormsApp3
{
    internal class RestRequest
    {
        private object pOST;

        public RestRequest(object pOST, RestSharp.Method gET)
        {
            this.pOST = pOST;
        }

        internal void AddHeader(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void AddParameter(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
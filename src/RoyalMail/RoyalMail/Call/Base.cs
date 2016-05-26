
namespace RoyalMail.Call
{
    public abstract class Base
    {
        protected string _soapCall = "";
        public  abstract string GetSerializedObject();
        public abstract string SoapCall();
    }
}

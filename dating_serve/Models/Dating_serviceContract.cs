using System.ServiceModel;

namespace Models {
    public class Dating_serviceContract : IDating_service {
        [OperationContract]
        public string getMatch(string name, int age, bool gender) {
            if(!gender) {
                return "Jethro";
            } else {
                return "No match found, sorry";
            }
            
        }
    }
}
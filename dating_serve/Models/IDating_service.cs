using System.ServiceModel;

namespace Models
{
    [ServiceContract]
    public interface IDating_service
    {
        [OperationContract]
        public string getMatch(string name, int age, bool gender); //Gender 0:female 1:male
    }
}
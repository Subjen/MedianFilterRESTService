using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace MedianFilterRESTService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ISolverRESTService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IMedianFilterService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetMedianFilter/{data}.{windowSize}")]

        string GetMedianFilter(string data, string windowSize);
    }
}

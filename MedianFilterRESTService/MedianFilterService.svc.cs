using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MedianFilterRESTService.Link;
using MedianFilterRESTService.MedianFilter;

namespace MedianFilterRESTService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "SolverRESTService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы SolverRESTService.svc или SolverRESTService.svc.cs в обозревателе решений и начните отладку.
    public class MedianFilterService : IMedianFilterService
    {
        public string GetMedianFilter(string data, string windowSize)
        {
            try
            {
                var link =  LinkParser.Parse(data, windowSize);
                return string.Format($"y = ({ Join(Solver.GetMedianFilter(link.Data, link.WindowSize)) })");
                    
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private string Join(IEnumerable<int> enumerable) => string.Join(", ", enumerable);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace MedianFilterRESTService.MedianFilter
{
    public class Solver
    {      
        public static IEnumerable<int> GetMedianFilter(IEnumerable<int> data, int windowSize)
        {
            List<int> MedianFilter = new List<int>();
            var signal = data.ToArray();
            var middle = windowSize / 2;
            for (int i = 0; i < signal.Length; i++)
            {
                var window = new List<int>(windowSize);
                for (int j = i - middle; j < i - middle + windowSize; j++)
                {
                    // если зашли за границы сигнала, "отзеркаливаем" значения сигнала
                    if (j < 0)
                        window.Add(signal[Math.Abs(j + 1)]);
                    else if (j >= signal.Length)
                        window.Add(signal[signal.Length - (j - signal.Length) - 1]);
                    else
                        window.Add(signal[j]);
                }
                window.Sort();
                MedianFilter.Add(window[middle]);
            }
            return MedianFilter;
        }

        public static IEnumerable<int> GetMedianFilterStandartAlgorithm(IEnumerable<int> data, int windowSize)
        {
            List<int> MedianFilter = new List<int>();
            var signal = data.ToArray();
            var middle = windowSize / 2;

            for (int i = 0; i < signal.Length; i++)
            {
                var window = new int[windowSize];
                for (int j = i - middle, k=0; j < i - middle + windowSize; k++, j++)
                {
                    // если зашли за границы сигнала, "отзеркаливаем" значения сигнала
                    if (j < 0)
                        window[k] = signal[Math.Abs(j + 1)];
                    else if (j >= signal.Length)
                        window[k] = signal[signal.Length - (j - signal.Length) - 1];
                    else
                        window[k] = signal[j];
                }

                // сортировка половины массива
                for (int j = 0; j < middle + 1; ++j)
                {
                    int min = j;
                    for (int k = j + 1; k < windowSize; ++k)
                        if (window[k] < window[min])
                            min = k;
                    int temp = window[j];
                    window[j] = window[min];
                    window[min] = temp;
                }

                MedianFilter.Add(window[middle]);
            }

            return MedianFilter;
        }


    }
}
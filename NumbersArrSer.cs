using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW_Serilization
{
    internal static class NumbersArrSer
    {
        public static int[] Filt(int[] arr, bool prime = true)
        {
            int[] res;
            int countSize = 0;
            if (prime)
            {
                int[] temp = new int[arr.Length];
                foreach (int i in arr)
                {
                    int countPrime = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            countPrime++;
                        }
                    }
                    if (countPrime <= 2)
                    {
                        temp[countSize] = i;
                        countSize++;
                    }
                }
                res = new int[countSize];
                for(int i = 0; i < countSize; i++)
                {
                    res[i] = arr[i];
                }
                return res;
            }
            else
            {
                int[] temp = new int[arr.Length];
                int indx = 0;
                foreach (int i in arr)
                {
                    int fib_1 = 1; int fib_2 = 1; int fib_3 = 1;
                    bool isFib = false;
                    while(fib_3 <= i)
                    {
                        fib_1 = fib_2;
                        fib_2 = fib_3;
                        fib_3 = fib_1 + fib_2;
                        if (fib_3 == i)
                        {
                            isFib = true;
                        }
                    }
                    if (!isFib)
                    {
                        temp[indx] = i;
                        indx++;
                        countSize++;
                    }
                }
                res = new int[countSize];
                for (int i = 0; i < countSize; i++)
                {
                    res[i] = temp[i];
                }
                return res;
            }
        }
        public static string Serialize(int[] arr)
        {
            string res = JsonConvert.SerializeObject(arr);
            return res;
        }
        public static void Save(string arr)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter streamWriter = new StreamWriter("Array.Json"))
            {
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(writer, arr);
                }
            }
        }
        public static int[] Load()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamReader streamReader = new StreamReader("Array.Json"))
            {
                using (JsonReader reader = new JsonTextReader(streamReader))
                {
                    serializer.Serialize(writer, arr);
                }
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GroupageCore
{
    public class StorageMan<T> where T : new()
    {
        private string storageBaseDirectory
        {
            get
            {
                string dir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                return dir;
            }
        }

        private string storageFilePath
        {
            get
            {
                return System.IO.Path.Combine(storageBaseDirectory
                    , string.Format("{0}.{1}", typeof(T).Name, "json"));
            }
        }

        public void Save(T data)
        {
            using (StreamWriter sw = new StreamWriter(storageFilePath))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, data);
                }
            }
        }

        public T Read()
        {
            if (!System.IO.File.Exists(storageFilePath)) return new T();

            using (StreamReader sr = new StreamReader(storageFilePath))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    object obj = serializer.Deserialize<T>(reader);

                    return (obj != null ? (T)obj : new T());
                }
            }
        }


        public T StringToObject(string json)
        {
            using (StringReader sr = new StringReader(json))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    object obj = serializer.Deserialize<T>(reader);

                    return (obj != null ? (T)obj : new T());
                }
            }
        }
    }
}

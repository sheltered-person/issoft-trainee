using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Task1
{
    //Logs tracked attributes of entities into specified json file.
    public class Logger
    {
        private readonly string _file;

        public string JsonFile
        {
            get => _file;

            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Can't log data into " +
                                                "empty file.");
                }

                _file = value;
            }
        }

        public Logger(string jsonFile) => JsonFile = jsonFile;

        //If object marked as tracked, logs it's tracked fields and properties.
        public void Track<T>(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException("Can't track null " +
                                                "reference object.");
            }

            Type type = obj.GetType();
            TrackingEntityAttribute entityAttribute = type
                .GetCustomAttribute<TrackingEntityAttribute>();

            if (entityAttribute is not null)
            {
                Dictionary<string, object> info = CollectInfo(obj, type);

                JsonSerializerOptions options = new()
                {
                    WriteIndented = true
                };
                
                string json = JsonSerializer.Serialize(info, options);
                File.WriteAllText(JsonFile, json);
            }
        }

        //Collects information about tracked attributes.
        private Dictionary<string, object> CollectInfo<T>(T obj, Type type)
        {
            Dictionary<string, object> markedInfo = new();

            const BindingFlags flags = BindingFlags.Public | 
                                       BindingFlags.NonPublic | 
                                       BindingFlags.Instance | 
                                       BindingFlags.Static;
            
            foreach (FieldInfo fieldInfo in type.GetFields(flags))
            {
                TrackingPropertyAttribute propertyAttribute = fieldInfo
                    .GetCustomAttribute<TrackingPropertyAttribute>();

                if (propertyAttribute is not null)
                {
                    markedInfo.Add(propertyAttribute.PropertyName ?? fieldInfo.Name,
                        fieldInfo.GetValue(obj));
                }
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties(flags))
            {
                TrackingPropertyAttribute propertyAttribute = propertyInfo
                    .GetCustomAttribute<TrackingPropertyAttribute>();

                if (propertyAttribute is not null)
                {
                    markedInfo.Add(propertyAttribute.PropertyName ?? propertyInfo.Name,
                        propertyInfo.GetValue(obj));
                }
            }

            return markedInfo;
        }
    }
}

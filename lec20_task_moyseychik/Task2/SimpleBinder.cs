using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task2
{
    //Bind class with dictionary of fields and properties.
    public class SimpleBinder
    {
        //Provides singleton pattern.
        private static SimpleBinder _binder;

        private SimpleBinder() { }

        public static SimpleBinder GetBinder() 
            => _binder ??= new();

        //Constructs type instance with mentioned data in fields and properties.
        public T Bind<T>(Dictionary<string, string> data) 
            where T : new()
        {
            T instance = Activator.CreateInstance<T>();
            Type type = instance.GetType();

            const BindingFlags flags = BindingFlags.Public | 
                                       BindingFlags.NonPublic | 
                                       BindingFlags.Instance;

            //List is used here for it's Find method.
            List<FieldInfo> fields = new(type.GetFields(flags));
            List<PropertyInfo> properties = new(type.GetProperties(flags));

            foreach (KeyValuePair<string, string> pair in data)
            {
                bool Equality(MemberInfo member) 
                    => Equals(member.Name.ToLower(), pair.Key.ToLower());

                FieldInfo field = fields.Find(Equality);

                if (field is not null)
                {
                    BindMemberAndValue(o => field.SetValue(instance, o),
                        field.FieldType, pair.Value);

                    continue;
                }

                PropertyInfo property = properties.Find(Equality);

                if (property is not null && property.CanWrite)
                {
                    BindMemberAndValue(o => property.SetValue(instance, o), 
                        property.PropertyType, pair.Value);
                }
            }

            return instance;
        }

        //Binds field/property with value with type cast.
        private void BindMemberAndValue(Action<object> setValue, 
            Type memberType, string memberValue)
        {
            switch (memberType.Name)
            {
                case "Double":
                    setValue(double.Parse(memberValue));
                    break;
                case "Int32":
                    setValue(int.Parse(memberValue));
                    break;
                default:
                    setValue(memberValue);
                    break;
            }
        }
    }
}

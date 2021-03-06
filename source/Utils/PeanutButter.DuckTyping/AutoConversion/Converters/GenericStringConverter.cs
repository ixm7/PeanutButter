using System;
using System.Collections.Generic;
using Imported.PeanutButter.Utils;

namespace PeanutButter.DuckTyping.AutoConversion.Converters
{
    internal class GenericStringConverter<T>
        : GenericStringConverterBase<T>,
          IConverter<string, T>
    {
        public Type T1 => typeof(string);
        public Type T2 => typeof(T);

        public T Convert(string value)
        {
            var parameters = new object[] { value, null };
            var parsed = (bool) _tryParse.Invoke(null, parameters);
            return parsed
                ? (T) parameters[1]
                : default;
        }

        public string Convert(T value)
        {
            try
            {
                return value.ToString();
            }
            catch
            {
                return null;
            }
        }

        public bool CanConvert(Type t1, Type t2)
        {
            return CanConvert(t1, t2, T1, T2);
        }
    }
}
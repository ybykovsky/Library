using System;

namespace Library.Domain
{
    public static class ConverterExt
    {
        public static Guid ToGuid(this string value)
        {
            Guid result = Guid.Empty;
            Guid.TryParse(value, out result);
            return result;
        }
    }
}

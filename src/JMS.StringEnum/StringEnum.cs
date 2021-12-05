namespace JMS.StringEnum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class StringEnum<T> : IEquatable<StringEnum<T>>, IEquatable<string>
        where T : StringEnum<T>
    {
        private static readonly IEnumerable<string> AllFieldValues = typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(x => x.IsLiteral)
            .Select(x => x.GetValue(null).ToString())
            .ToList();

        private static readonly IEnumerable<string> AllPropertyValues = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(x => x.PropertyType == typeof(string) || x.PropertyType.BaseType?.IsGenericTypeDefinition == true)
            .Select(x => x.GetValue(null).ToString())
            .ToList();

        public static readonly IEnumerable<string> AllValues = AllFieldValues.Union(AllPropertyValues);

        protected StringEnum(string value)
        {
            var matching = GetMatchingValue(value);

            this.Value = matching ?? value;
        }

        private static string GetMatchingValue(string value) => AllValues?.SingleOrDefault(x => x.Equals(value, StringComparison.InvariantCultureIgnoreCase));


        /// <summary>
        /// Made public just in case the json serialization has not been configured correctly.
        /// Should not be used. Ensure that json serialization is configured to serialize this class using ToString.
        /// </summary>
        public string Value { get; }

        public static bool operator ==(StringEnum<T> left, StringEnum<T> right) => Equals(left, right);

        public static bool operator !=(StringEnum<T> left, StringEnum<T> right) => !Equals(left, right);

        public static bool IsKnownValue(string value) => AllValues.Any(x => x.Equals(GetMatchingValue(value) ?? value));

        public static bool IsKnownValue(T value) => IsKnownValue(value.ToString());

        public virtual bool IsKnownValue() => IsKnownValue(this.Value);

        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }

        public override string ToString() => this.Value;

        // Comparison

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case string s: return this.Equals(s);
                case StringEnum<T> e: return this.Equals(e);
                default: return false;
            }
        }

        public virtual bool Equals(StringEnum<T> obj) => this.Equals(obj.Value);

        public virtual bool Equals(string obj) => string.Equals(this.Value, obj, StringComparison.InvariantCultureIgnoreCase);



        // Implicit conversion operators
        
        // allows `string foo = new MyEnum("foo");`
        public static implicit operator string(StringEnum<T> val) => val.ToString();

        // add this to the enum class to allow `MyEnum foo = "foo";`
        //public static implicit operator MyEnum(string val) => new MyEnum(val);
    }
}

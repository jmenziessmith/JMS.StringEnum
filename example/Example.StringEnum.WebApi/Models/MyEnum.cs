using JMS.StringEnum;
using System;

namespace Example.StringEnum.WebApi
{
    public class MyEnum : StringEnum<MyEnum>
    {
        public const string Foo = "Foo";

        public const string Bar = "Bar";

        public MyEnum(string value)
         : base(value)
        {
        }

        public static implicit operator MyEnum(string val) => new MyEnum(val);
    }

}

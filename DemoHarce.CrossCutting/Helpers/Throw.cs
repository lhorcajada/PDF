using System;

namespace DemoHarce.CrossCutting.Helpers
{
    public static class Throw<TException> where TException : Exception, new()
    {
        public static DemoHarce.CrossCutting.Helpers.WhenNumber<TException> WhenNumber
        {
            get
            {
                return new DemoHarce.CrossCutting.Helpers.WhenNumber<TException>();
            }
        }

        public static DemoHarce.CrossCutting.Helpers.WhenString<TException> WhenString
        {
            get
            {
                return new DemoHarce.CrossCutting.Helpers.WhenString<TException>();
            }
        }

        public static DemoHarce.CrossCutting.Helpers.WhenObject<TException> WhenObject
        {
            get
            {
                return new DemoHarce.CrossCutting.Helpers.WhenObject<TException>();
            }
        }

        public static DemoHarce.CrossCutting.Helpers.WhenEnum<TException> WhenEnum
        {
            get
            {
                return new DemoHarce.CrossCutting.Helpers.WhenEnum<TException>();
            }
        }

        public static DemoHarce.CrossCutting.Helpers.WhenEnumerable<TException> WhenEnumerable
        {
            get
            {
                return new DemoHarce.CrossCutting.Helpers.WhenEnumerable<TException>();
            }
        }
    }
}

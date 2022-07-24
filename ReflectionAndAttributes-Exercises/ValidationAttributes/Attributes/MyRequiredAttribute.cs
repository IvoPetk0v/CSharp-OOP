using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }
            return obj != null;
        }
    }
}

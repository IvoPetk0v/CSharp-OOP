namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();
            foreach (var property in properties)
            {
                object propValue = property.GetValue(obj);
                foreach (var customAttributeData in property.CustomAttributes)
                {
                    Type customAttribType = customAttributeData.AttributeType;
                    object attributeInstance = property.GetCustomAttribute(customAttribType);
                   
                    MethodInfo validationMethod = customAttribType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");
                    bool result = (bool)validationMethod
                        .Invoke(attributeInstance, new object[] { propValue });
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

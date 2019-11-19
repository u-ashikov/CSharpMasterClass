using System;
using System.Dynamic;
using System.Reflection;

namespace DynamicExample
{
    public class ExposedObject : DynamicObject
    {
        private readonly object obj;
        private readonly Type type;

        public ExposedObject(object obj)
        {
            this.obj = obj;
            this.type = obj.GetType();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var propName = binder.Name;
            var property = this.type.GetProperty(propName, BindingFlags.Instance | BindingFlags.NonPublic);

            if (property == null)
            {
                var field = this.type.GetField(propName, BindingFlags.Instance | BindingFlags.NonPublic);

                if (field == null)
                {
                    return base.TryGetMember(binder, out result);
                }

                result = field.GetValue(this.obj);
            }
            else
            {
                result = property.GetValue(this.obj);
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    // https://stackoverflow.com/questions/3862226/how-to-dynamically-create-a-class
    // https://stackoverflow.com/questions/54074917/dynamic-class-with-deserializeobject-delivers-error-unable-to-find-a-default-co
    public class DynamicObjectClass : DynamicObject
    {
        private Dictionary<string, KeyValuePair<Type, object>> _fields;

        public DynamicObjectClass(List<Field> fields)
        {
            _fields = new Dictionary<string, KeyValuePair<Type, object>>();
            fields.ForEach(x => _fields.Add(x.FieldName,
                new KeyValuePair<Type, object>(x.FieldType, null)));
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_fields.ContainsKey(binder.Name))
            {
                var type = _fields[binder.Name].Key;
                if (value.GetType() == type)
                {
                    _fields[binder.Name] = new KeyValuePair<Type, object>(type, value);
                    return true;
                }
                else throw new Exception("Value " + value + " is not of type " + type.Name);
            }
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _fields[binder.Name].Value;
            return true;
        }
    }
    public class Field
    {
        public Field(string name, Type type)
        {
            this.FieldName = name;
            this.FieldType = type;
        }

        public string FieldName;

        public Type FieldType;
    }
}


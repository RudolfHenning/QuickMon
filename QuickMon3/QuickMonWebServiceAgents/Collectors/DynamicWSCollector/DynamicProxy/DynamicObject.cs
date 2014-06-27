using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

// based on class created by MSDN Community Support staff member - ' Haixia Xie'
// Could not find any more details on creator

namespace QuickMon.Collectors
{
    internal class DynamicObject
    {
        private Type objType;
        private object obj;

        private BindingFlags CommonBindingFlags =
            BindingFlags.Instance |
            BindingFlags.Public;

        public DynamicObject(Object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            this.obj = obj;
            this.objType = obj.GetType();
        }

        public DynamicObject(Type objType)
        {
            if (objType == null)
                throw new ArgumentNullException("objType");

            this.objType = objType;
        }

        public void CallConstructor()
        {
            CallConstructor(new Type[0], new object[0]);
        }

        public void CallConstructor(Type[] paramTypes, object[] paramValues)
        {
            ConstructorInfo ctor = this.objType.GetConstructor(paramTypes);
            if (ctor == null)
            {
                throw new DynamicProxyException(
                        DynamicProxyConstants.ErrorMessages.ProxyCtorNotFound);
            }

            this.obj = ctor.Invoke(paramValues);
        }

        public object GetProperty(string property)
        {
            object retval = this.objType.InvokeMember(
                property,
                BindingFlags.GetProperty | CommonBindingFlags,
                null /* Binder */,
                this.obj,
                null /* args */);

            return retval;
        }

        public object SetProperty(string property, object value)
        {
            object retval = this.objType.InvokeMember(
                property,
                BindingFlags.SetProperty | CommonBindingFlags,
                null /* Binder */,
                this.obj,
                new object[] { value });

            return retval;
        }

        public object GetField(string field)
        {
            object retval = this.objType.InvokeMember(
                field,
                BindingFlags.GetField | CommonBindingFlags,
                null /* Binder */,
                this.obj,
                null /* args */);

            return retval;
        }

        public object SetField(string field, object value)
        {
            object retval = this.objType.InvokeMember(
                field,
                BindingFlags.SetField | CommonBindingFlags,
                null /* Binder */,
                this.obj,
                new object[] { value });

            return retval;
        }

        public object CallMethod(string method, params object[] parameters)
        {
            object retval = this.objType.InvokeMember(
                method,
                BindingFlags.InvokeMethod | CommonBindingFlags,
                null /* Binder */,
                this.obj,
                parameters /* args */);

            return retval;
        }

        public object CallMethod(string method, Type[] types,
            object[] parameters)
        {
            if (types.Length != parameters.Length)
                throw new ArgumentException(
                    DynamicProxyConstants.ErrorMessages.ParameterValueMistmatch);

            MethodInfo mi = this.objType.GetMethod(method, types);
            if (mi == null)
                throw new ApplicationException(string.Format(
                    DynamicProxyConstants.ErrorMessages.MethodNotFound, method));

            object retval = mi.Invoke(this.obj, CommonBindingFlags, null,
                parameters, null);

            return retval;
        }

        public Type ObjectType
        {
            get
            {
                return this.objType;
            }
        }

        public object ObjectInstance
        {
            get
            {
                return this.obj;
            }
        }

        public BindingFlags BindingFlags
        {
            get
            {
                return this.CommonBindingFlags;
            }

            set
            {
                this.CommonBindingFlags = value;
            }
        }
    }
}

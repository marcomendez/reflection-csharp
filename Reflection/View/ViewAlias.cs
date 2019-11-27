using System;
namespace Reflection.View
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewAlias : Attribute
    {
        private readonly string _alias;

        public ViewAlias(string alias)
        {
            _alias = alias;
        }


        public string Name
        {
            get
            {
                return _alias;
            }
        }
        public override string ToString()
        {
            return _alias;
        }
    }
}

using System;
using System.Xml.Serialization;

namespace EzMacroS.Conditions
{
    [XmlInclude(typeof(PictureBaseCondition))]
    [Serializable]
    public abstract class BaseCondition
    {
        public abstract bool CalculateCondition();

        public string ConditionName { get; set; }
    }
}
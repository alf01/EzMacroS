using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EzMacroS
{
    public class MacroUnit
    {
        /// <summary>
        ///     Macro Activation Key
        /// </summary>
        public int BindInt { get; set; }

        /// <summary>
        ///     string variant of recorded commands
        /// </summary>
        public string Commands { get; set; }

        [XmlIgnore]
        public List<string> CommandList
        {
            get { return new List<string>(Commands.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)); }
        }

        /// <summary>
        ///     macro play speed
        /// </summary>
        public double PlaySpeed { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonOperation.CommonHelper
{
    /// <summary>
    /// This class contains properties related to FaultContract.
    /// </summary>
    [DataContract]
    public class FaultContract
    {
        /// <summary>
        /// Gets or sets the type of the fault.
        /// </summary>
        /// <value>
        /// The type of the fault.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public string FaultType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}

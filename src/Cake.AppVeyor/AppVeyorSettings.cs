using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core.Annotations;

namespace Cake.AppVeyor
{
    /// <summary>
    /// AppVeyor Settings
    /// </summary>
    public class AppVeyorSettings
    {
        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        /// <value>The API token.</value>
        public string ApiToken { get; set; }
    }
    
}

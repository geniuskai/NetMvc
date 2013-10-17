using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Mvc.Environment
{
    using System;
    using Autofac;

    /// <summary>
    /// MVC 宿主
    /// </summary>
    /// <remarks>from Orchard</remarks>
    public interface IHost
    {
        /// <summary>
        /// Called once on startup to configure app domain, and load/apply existing shell configuration
        /// </summary>
        void Initialize(Action<ContainerBuilder> registrations);

        /// <summary>
        /// Called externally when there is explicit knowledge that the list of installed
        /// modules/extensions has changed, and they need to be reloaded.
        /// </summary>
        void ReloadExtensions();

        /// <summary>
        /// Called each time a request begins to offer a just-in-time reinitialization point
        /// </summary>
        void BeginRequest();

        /// <summary>
        /// Called each time a request ends to deterministically commit and dispose outstanding activity
        /// </summary>
        void EndRequest();
    }
}

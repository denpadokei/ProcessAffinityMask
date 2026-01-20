
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ProcessAffinityMask.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        /// <summary>
        /// Gets or sets the list of CPU core numbers to be used for processing.
        /// </summary>
        /// <remarks>Each integer in the list represents the zero-based index of a CPU core. The specified
        /// cores will be used to control processor affinity for operations that support it. Modifying this list allows
        /// customization of which CPU cores are utilized.</remarks>
        [UseConverter(typeof(ListConverter<int>))]
        [NonNullable]
        public virtual List<int> UseCPUCoreNumbers { get; set; } = new List<int> { 0, 1, 2, 3 };
        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
        }
    }
}

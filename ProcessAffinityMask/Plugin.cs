using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace ProcessAffinityMask
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        

        #region BSIPA Config
        /// <summary>
        /// Initializes the plugin with the specified logger and configuration.s
        /// </summary>
        /// <remarks>This method should be called by the mod loader to set up logging and load the
        /// plugin's configuration before any other operations are performed.</remarks>
        /// <param name="logger">The logger instance used for recording informational and debug messages during initialization. Cannot be
        /// null.</param>
        /// <param name="conf">The configuration object containing plugin settings. Cannot be null.</param>
        [Init]
        public void InitWithConfig(IPALogger logger, Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("ProcessAffinityMask initialized.");

            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }

        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            try
            {
                var h = NativeMethods.GetCurrentProcess();
                var nums = Configuration.PluginConfig.Instance.UseCPUCoreNumbers;
                if (nums.Count == 0)
                {
                    Log.Info("No CPU core numbers specified in config; skipping setting process affinity mask.");
                    return;
                }
                UIntPtr mask = UIntPtr.Zero;
                foreach (var n in nums)
                {
                    if (n < 0 || n >= Environment.ProcessorCount)
                    {
                        Log.Warn($"CPU core number {n} is out of range (0 to {Environment.ProcessorCount - 1}); skipping.");
                        continue;
                    }
                    mask = (UIntPtr)((ulong)mask | (1UL << n));
                }
                if (NativeMethods.SetProcessAffinityMask(h, mask))
                {
                    Log.Info($"Successfully set process affinity mask to use CPU cores: {string.Join(", ", nums)}");
                }
                else
                {
                    uint error = NativeMethods.GetLastError();
                    Log.Error($"Failed to set process affinity mask. Error code: {error}");
                }
            }
            catch (Exception e)
            {
                Log.Error($"OnApplicationStart Exception: {e}");
            }
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");

        }
    }
}

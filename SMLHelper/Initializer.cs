﻿using SMLHelper.Handlers;

namespace SMLHelper
{
    using System;
    using System.Collections;
    using System.Reflection;
    using BepInEx;
    using HarmonyLib;
    using Patchers;
    using Utility;
    using UnityEngine;


    /// <summary>
    /// WARNING: This class is for use only by Bepinex.
    /// </summary>
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Initializer: BaseUnityPlugin
    {
        private const string
            MODNAME = "SMLHelper",
            GUID = "com.ahk1221.smlhelper",
            VERSION = "2.15.0.2";

        internal static readonly Harmony harmony = new(GUID);

        /// <summary>
        /// WARNING: This method is for use only by Bepinex.
        /// </summary>
        [Obsolete("This method is for use only by Bepinex.", true)]
        Initializer()
        {
            GameObject obj = UWE.Utils.GetEntityRoot(this.gameObject) ?? this.gameObject;
            obj.EnsureComponent<SceneCleanerPreserve>();

            InternalLogger.Initialize(Logger);
#if SUBNAUTICA
            InternalLogger.Info($"Loading v{VERSION} for Subnautica");
#elif BELOWZERO
            InternalLogger.Info($"Loading v{VERSION} for BelowZero");
#endif

            PrefabDatabasePatcher.PrePatch(harmony);
            StartCoroutine(InitializePatches());
        }


        private IEnumerator InitializePatches()
        {
            Type chainLoader = typeof(BepInEx.Bootstrap.Chainloader);

            FieldInfo _loaded = chainLoader.GetField("_loaded", BindingFlags.NonPublic | BindingFlags.Static);
            while(!(bool)_loaded.GetValue(null))
            {
                yield return null;
            }

            yield return new WaitForSecondsRealtime(2);

            EnumHandler.InitializeAll();
            EnumPatcher.Patch(harmony);

            CraftDataPatcher.Patch(harmony);
            CraftTreePatcher.Patch(harmony);
            ConsoleCommandsPatcher.Patch(harmony);
            LanguagePatcher.Patch(harmony);
            PrefabDatabasePatcher.PostPatch(harmony);
            SpritePatcher.Patch(harmony);
            KnownTechPatcher.Patch(harmony);
            OptionsPanelPatcher.Patch(harmony);
            ItemsContainerPatcher.Patch(harmony);
            PDALogPatcher.Patch(harmony);
            PDAPatcher.Patch(harmony);
            PDAEncyclopediaPatcher.Patch(harmony);
            ItemActionPatcher.Patch(harmony);
            LootDistributionPatcher.Patch(harmony);
            WorldEntityDatabasePatcher.Patch(harmony);
            LargeWorldStreamerPatcher.Patch(harmony);
            IngameMenuPatcher.Patch(harmony);
            TooltipPatcher.Patch(harmony);
            SurvivalPatcher.Patch(harmony);
            CustomSoundPatcher.Patch(harmony);
            EatablePatcher.Patch(harmony);
            MaterialUtils.Patch();
        }
    }
}

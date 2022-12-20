using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RestoreRugComfortLevel
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInProcess("valheim.exe")]
    public class RestoreRugComfortLevel : BaseUnityPlugin
    {
        private const string modGUID = "eaa98d97-2216-4fde-baf4-eae91191cff3";
        private const string modName = "Mod-RestoreRugComfortLevel";
        private const string modVersion = "1.0";
        private readonly Harmony harmony = new Harmony(modGUID);

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Piece), "Awake")]
        class RestoreRugComfortLevel_Piece_Awake
        {
            static void Postfix(Piece __instance)
            {
                if (__instance.m_name.StartsWith("$piece_rug_")){
                    __instance.m_comfortGroup = Piece.ComfortGroup.None;
                }
            }
        }
    }
}

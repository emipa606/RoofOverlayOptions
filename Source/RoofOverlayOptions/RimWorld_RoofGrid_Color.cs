using HarmonyLib;
using UnityEngine;
using Verse;

namespace RoofOverlayOptions;

[HarmonyPatch(typeof(RoofGrid), nameof(RoofGrid.Color), MethodType.Getter)]
internal static class RimWorld_RoofGrid_Color
{
    private static void Postfix(ref Color __result)
    {
        __result = Color.white;
        __result.a = RoofOverlayOptionsMain.Settings.alpha;
    }
}
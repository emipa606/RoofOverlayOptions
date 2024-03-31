using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace RoofOverlayOptions;

[HarmonyPatch(typeof(RoofGrid), nameof(RoofGrid.GetCellExtraColor))]
internal static class RimWorld_RoofGrid_GetCellExtraColor
{
    private static void Postfix(ref RoofDef[] ___roofGrid, int index, ref Color __result)
    {
        __result = Color.green;
        __result.a = RoofOverlayOptionsMain.Settings.alpha;
        var roof = ___roofGrid[index];

        if (RoofOverlayOptionsMain.Settings.highlightOverheadMountainInRedInOverlay &&
            RoofDefOf.RoofRockThick != null && roof == RoofDefOf.RoofRockThick)
        {
            __result = Color.red;
        }

        if (RoofOverlayOptionsMain.Settings.highlightConstructedRoofInYellowInOverlay && !roof.isNatural)
        {
            __result = Color.yellow;
        }
    }
}
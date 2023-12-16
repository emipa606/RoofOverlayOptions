using HarmonyLib;
using Verse;

namespace RoofOverlayOptions;

[StaticConstructorOnStartup]
public static class RoofOverlayOptionsMain
{
    public static RoofOverlayOptionsSettings Settings;

    static RoofOverlayOptionsMain()
    {
        Settings = LoadedModManager.GetMod<RoofOverlayOptionsMod>().GetSettings<RoofOverlayOptionsSettings>().Clone();
        new Harmony("nercury.RoofOverlayOptionsMod").PatchAll();
    }
}
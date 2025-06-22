using UnityEngine;
using Verse;

namespace RoofOverlayOptions;

public class RoofOverlayOptionsMod : Mod
{
    private readonly RoofOverlayOptionsSettings settings;

    public RoofOverlayOptionsMod(ModContentPack content)
        : base(content)
    {
        settings = GetSettings<RoofOverlayOptionsSettings>();
    }

    private static string RooOverlayConstructedRoofYellow =>
        !"RooOverlayConstructedRoofYellow".TryTranslate(out var result)
            ? "Yellow constructed roof in roof overlay"
            : result.RawText;

    private static string RooOverlayConstructedRoofYellowTip =>
        !"RooOverlayConstructedRoofYellowTip".TryTranslate(out var result)
            ? "Use yelow-ish color for constructed (not-natural) roof in roof overlay"
            : result.RawText;

    private static string RooOverlayThickRoofRed => !"RooOverlayThickRoofRed".TryTranslate(out var result)
        ? "Red overhead mountain in roof overlay"
        : result.RawText;

    private static string RooOverlayThickRoofRedTip => !"RooOverlayThickRoofRedTip".TryTranslate(out var result)
        ? "Use red color to show thick roof (overhead mountain) in roof overlay"
        : result.RawText;

    private static string RoofOverlayOptionsString =>
        !"RoofOverlayOptionsMod".TryTranslate(out var result) ? "Roof Overlay Options" : result.RawText;

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        listing_Standard.Label("RoofOverlayReload".Translate());
        listing_Standard.GapLine();
        listing_Standard.CheckboxLabeled(RooOverlayConstructedRoofYellow,
            ref settings.HighlightConstructedRoofInYellowInOverlay, RooOverlayConstructedRoofYellowTip);
        listing_Standard.CheckboxLabeled(RooOverlayThickRoofRed, ref settings.HighlightOverheadMountainInRedInOverlay,
            RooOverlayThickRoofRedTip);
        settings.Alpha = listing_Standard.SliderLabeled("RoofOverlayAlpha".Translate(settings.Alpha.ToStringPercent()),
            settings.Alpha, 0f, 1f);
        listing_Standard.GapLine(50f);
        var colorRect = listing_Standard.GetRect(75f);
        var green = Color.green;
        var yellow = Color.yellow;
        var red = Color.red;
        green.a = settings.Alpha;
        yellow.a = settings.Alpha;
        red.a = settings.Alpha;
        Widgets.DrawBoxSolidWithOutline(colorRect.LeftPart(0.2f).RightHalf(), green, Color.gray);
        if (settings.HighlightConstructedRoofInYellowInOverlay)
        {
            Widgets.DrawBoxSolidWithOutline(colorRect.LeftPart(0.2f).RightHalf().CenteredOnXIn(colorRect), yellow,
                Color.gray);
        }

        if (settings.HighlightOverheadMountainInRedInOverlay)
        {
            Widgets.DrawBoxSolidWithOutline(colorRect.RightPart(0.2f).LeftHalf(), red, Color.gray);
        }

        listing_Standard.End();
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return RoofOverlayOptionsString;
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        RoofOverlayOptionsMain.Settings = settings.Clone();
    }
}
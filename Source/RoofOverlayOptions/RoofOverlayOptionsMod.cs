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

    public static string RooOverlayConstructedRoofYellow =>
        !"RooOverlayConstructedRoofYellow".TryTranslate(out var result)
            ? "Yellow constructed roof in roof overlay"
            : result.RawText;

    public static string RooOverlayConstructedRoofYellowTip =>
        !"RooOverlayConstructedRoofYellowTip".TryTranslate(out var result)
            ? "Use yelow-ish color for constructed (not-natural) roof in roof overlay"
            : result.RawText;

    public static string RooOverlayThickRoofRed => !"RooOverlayThickRoofRed".TryTranslate(out var result)
        ? "Red overhead mountain in roof overlay"
        : result.RawText;

    public static string RooOverlayThickRoofRedTip => !"RooOverlayThickRoofRedTip".TryTranslate(out var result)
        ? "Use red color to show thick roof (overhead mountain) in roof overlay"
        : result.RawText;

    public static string RoofOverlayOptionsString =>
        !"RoofOverlayOptionsMod".TryTranslate(out var result) ? "Roof Overlay Options" : result.RawText;

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        listing_Standard.Label("RoofOverlayReload".Translate());
        listing_Standard.GapLine();
        listing_Standard.CheckboxLabeled(RooOverlayConstructedRoofYellow,
            ref settings.highlightConstructedRoofInYellowInOverlay, RooOverlayConstructedRoofYellowTip);
        listing_Standard.CheckboxLabeled(RooOverlayThickRoofRed, ref settings.highlightOverheadMountainInRedInOverlay,
            RooOverlayThickRoofRedTip);
        settings.alpha = listing_Standard.SliderLabeled("RoofOverlayAlpha".Translate(settings.alpha.ToStringPercent()),
            settings.alpha, 0f, 1f);
        listing_Standard.GapLine(50f);
        var colorRect = listing_Standard.GetRect(75f);
        var green = Color.green;
        var yellow = Color.yellow;
        var red = Color.red;
        green.a = settings.alpha;
        yellow.a = settings.alpha;
        red.a = settings.alpha;
        Widgets.DrawBoxSolidWithOutline(colorRect.LeftPart(0.2f).RightHalf(), green, Color.gray);
        if (settings.highlightConstructedRoofInYellowInOverlay)
        {
            Widgets.DrawBoxSolidWithOutline(colorRect.LeftPart(0.2f).RightHalf().CenteredOnXIn(colorRect), yellow,
                Color.gray);
        }

        if (settings.highlightOverheadMountainInRedInOverlay)
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
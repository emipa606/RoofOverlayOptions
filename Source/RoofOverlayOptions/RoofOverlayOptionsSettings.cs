using Verse;

namespace RoofOverlayOptions;

public class RoofOverlayOptionsSettings : ModSettings
{
    public float Alpha = 0.5f;
    public bool HighlightConstructedRoofInYellowInOverlay = true;
    public bool HighlightOverheadMountainInRedInOverlay = true;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref HighlightOverheadMountainInRedInOverlay, "RoofOverlayOptionsThickRoofRed", true);
        Scribe_Values.Look(ref Alpha, "alpha", 0.5f);
        Scribe_Values.Look(ref HighlightConstructedRoofInYellowInOverlay, "RoofOverlayOptionsConstructedRoofYellow",
            true);
        base.ExposeData();
    }

    public RoofOverlayOptionsSettings Clone()
    {
        return new RoofOverlayOptionsSettings
        {
            HighlightOverheadMountainInRedInOverlay = HighlightOverheadMountainInRedInOverlay,
            Alpha = Alpha,
            HighlightConstructedRoofInYellowInOverlay = HighlightConstructedRoofInYellowInOverlay
        };
    }
}
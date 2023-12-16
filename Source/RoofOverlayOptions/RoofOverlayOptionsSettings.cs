using Verse;

namespace RoofOverlayOptions;

public class RoofOverlayOptionsSettings : ModSettings
{
    public float alpha = 0.5f;
    public bool highlightConstructedRoofInYellowInOverlay = true;
    public bool highlightOverheadMountainInRedInOverlay = true;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref highlightOverheadMountainInRedInOverlay, "RoofOverlayOptionsThickRoofRed", true);
        Scribe_Values.Look(ref alpha, "alpha", 0.5f);
        Scribe_Values.Look(ref highlightConstructedRoofInYellowInOverlay, "RoofOverlayOptionsConstructedRoofYellow",
            true);
        base.ExposeData();
    }

    public RoofOverlayOptionsSettings Clone()
    {
        return new RoofOverlayOptionsSettings
        {
            highlightOverheadMountainInRedInOverlay = highlightOverheadMountainInRedInOverlay,
            alpha = alpha,
            highlightConstructedRoofInYellowInOverlay = highlightConstructedRoofInYellowInOverlay
        };
    }
}
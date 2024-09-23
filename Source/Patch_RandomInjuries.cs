using HarmonyLib;
using Verse;

namespace NoModernInjuries;
[HarmonyPatch]
public static class Patch_RandomInjuries {
    private static bool active = false;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(HealthUtility), nameof(HealthUtility.RandomPermanentInjuryDamageType))]
    public static void RandomPermanentInjuryDamageType_Pre() 
        => active = true;

    [HarmonyPostfix]
    [HarmonyPatch(typeof(HealthUtility), nameof(HealthUtility.RandomPermanentInjuryDamageType))]
    public static void RandomPermanentInjuryDamageType_Post() 
        => active = false;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(HealthUtility), nameof(HealthUtility.RandomViolenceDamageType))]
    public static void RandomViolenceDamageType_Pre() 
        => active = true;

    [HarmonyPostfix]
    [HarmonyPatch(typeof(HealthUtility), nameof(HealthUtility.RandomViolenceDamageType))]
    public static void RandomViolenceDamageType_Post() 
        => active = false;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(Rand), nameof(Rand.RangeInclusive))]
    public static void RangeInclusive(ref int minInclusive) {
        if (active) {
            minInclusive++;
        }
    }

}

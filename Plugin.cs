using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace FuckYouLocksYourDoors;

[BepInPlugin(Plugin.GUID, Plugin.NAME, Plugin.VERSION)]
public class Plugin : BaseUnityPlugin {
	const string GUID = "nikemitosis.lethal_company.fylyd";
	const string NAME = "Fuck you, *locks your doors*";
	const string VERSION = "1.0.0";
	
	internal static new ManualLogSource Logger;
	
	private readonly Harmony harmony = new Harmony(GUID);
	
	private void Awake() {
		Logger = base.Logger;
		harmony.PatchAll();
		
		Logger.LogInfo($"Retrieved the keys to lock your doors");
	}
}

[HarmonyPatch(typeof(DoorLock))]
class DoorPatch {

	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	static void AutoLock(DoorLock __instance) {
		__instance.LockDoor();
	}
}
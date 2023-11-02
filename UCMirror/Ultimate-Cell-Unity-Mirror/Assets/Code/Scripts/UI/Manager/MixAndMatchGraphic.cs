using Spine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MixAndMatchGraphic : MonoBehaviour
{
    #region Inspector
    [SpineSkin]
    public string baseSkinName = "base";
    public Material sourceMaterial;
    [Header("Weapon")]
    public Sprite gunSprite;
    [SpineSlot]
    public string gunSlot;
    [SpineAttachment(slotField: "gunSlot", skinField: "baseSkinName")]
    public string gunKey = "gun";
    [Header("Runtime Repack Required!!")]
    public bool repack = true;
    [Header("Do not assign")]
    public Texture2D runtimeAtlas;
    public Material runtimeMaterial;
    #endregion

    private SkeletonGraphic skeletonGraphic;
    private Skeleton skeleton;

    void Start()
    {
        StartCoroutine(ApplyCoroutine());
    }

    IEnumerator ApplyCoroutine()
    {
        yield return new WaitForSeconds(1f); // Delay for 1 second. For testing.

        Apply();
    }

    void Apply()
    {
        if (skeletonGraphic == null)
        {
            skeletonGraphic = GetComponent<SkeletonGraphic>();
            skeleton = skeletonGraphic.Skeleton;
        }

        Skin customSkin = new Skin("custom skin");
        Skin replaceSkin = new Skin("replace skin");
        Skin baseSkin = skeleton.Data.FindSkin(baseSkinName);

        int gunSlotIndex = skeleton.Data.FindSlot(gunSlot).Index;
        Attachment baseGun = baseSkin.GetAttachment(gunSlotIndex, gunKey); // STEP 1.1

        Attachment newGun = baseGun.GetRemappedClone(gunSprite, sourceMaterial); // STEP 1.2 - 1.3

        baseSkin.RemoveAttachment(gunSlotIndex, gunKey);

        if (newGun != null)
        {
            customSkin.SetAttachment(gunSlotIndex, gunKey, newGun); // STEP 1.4
        }

        replaceSkin.AddSkin(baseSkin);
        replaceSkin = replaceSkin.GetRepackedSkin("repacked skin", baseGun.GetMaterial(), out runtimeMaterial, out runtimeAtlas);

        skeleton.SetSkin(replaceSkin);
        skeleton.SetToSetupPose();

        skeletonGraphic.Update(0);
        skeletonGraphic.OverrideTexture = runtimeAtlas;

        AtlasUtilities.ClearCache();
        Resources.UnloadUnusedAssets();
    }
}

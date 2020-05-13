# TVRWMN_master
Master del proyecto The VR Whisper My Name

Error when SDK_OCULUS_AVATAR is checked
Had this issue today and in OvrAvatar on line 179, took AssetsDoneLoading line out of the #ifAVATAR_INTERNAL. It now looks like so:

#if AVATAR_INTERNAL
public AvatarControllerBlend BlendController;
#endif
public UnityEvent AssetsDoneLoading = new UnityEvent();
Had to add using UnityEngine.Events; at the top to make that work.

Now it works and haven't had any problems from that change.

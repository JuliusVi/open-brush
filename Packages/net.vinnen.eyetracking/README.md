# Eye Tracking with Vive Pro Eye

This package contains resources to provide some additional functionality to the ViveSRanipal software.

## Tutorial

1. To get the most basic functionality running, you have to first install this package via the package manager
2. Drag the *EyeTrackingManager* prefab into your current scene
3. If you have a working Vive Pro Eye connected and running, select *Eye* as tracking type, otherwise select *Head*. 
If you select Head, the software will just use your head forward ray as tracking source, this is intended for debug purposes.
If you select Eye, the software will only work if you built the program. Unfortunately eye tracking does not work in the unity player. 
4. To set up a spectator screen that can be recorded later on, drag the *SpectatorCamera* prefab into your scene and add it as a child of your VR Camera. Be careful, that is in the exact same position as your VRCamera
5. Drag the *EyeTrackingSpectatorOverlay* into your scene and select the previously added *Spectator Camera* as *Render Camera* in the Canvas Component
6. Add two Layers to your project and name them *EyeTrackingOverlay* and *EyeTrackingAoI*
7. Change the Layer of *EyeTrackingSpectatorOverlay/OffsetParent/EyeRayVisualisationPlane* to *EyeTrackingOverlay*
8. Remove the added Layers from the culling mask of your VrCamera if you dont want to see them from within VR.
9. Finally if you wand to define areas of interest (aoi) you can add the corresponding prefabs to your scene. You have to set their Layers to *EyeTrackingAoI*

If you want to implement custom behaviour that can be focused by the eyes, you can implement the *IFocusable* interface. The *Focus* function will be called every frame, the focusable object is focused.
The object needs a collider that is set as a trigger.

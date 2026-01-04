var Deserializers = {}
Deserializers["UnityEngine.JointSpring"] = function (request, data, root) {
  var i566 = root || request.c( 'UnityEngine.JointSpring' )
  var i567 = data
  i566.spring = i567[0]
  i566.damper = i567[1]
  i566.targetPosition = i567[2]
  return i566
}

Deserializers["UnityEngine.JointMotor"] = function (request, data, root) {
  var i568 = root || request.c( 'UnityEngine.JointMotor' )
  var i569 = data
  i568.m_TargetVelocity = i569[0]
  i568.m_Force = i569[1]
  i568.m_FreeSpin = i569[2]
  return i568
}

Deserializers["UnityEngine.JointLimits"] = function (request, data, root) {
  var i570 = root || request.c( 'UnityEngine.JointLimits' )
  var i571 = data
  i570.m_Min = i571[0]
  i570.m_Max = i571[1]
  i570.m_Bounciness = i571[2]
  i570.m_BounceMinVelocity = i571[3]
  i570.m_ContactDistance = i571[4]
  i570.minBounce = i571[5]
  i570.maxBounce = i571[6]
  return i570
}

Deserializers["UnityEngine.JointDrive"] = function (request, data, root) {
  var i572 = root || request.c( 'UnityEngine.JointDrive' )
  var i573 = data
  i572.m_PositionSpring = i573[0]
  i572.m_PositionDamper = i573[1]
  i572.m_MaximumForce = i573[2]
  i572.m_UseAcceleration = i573[3]
  return i572
}

Deserializers["UnityEngine.SoftJointLimitSpring"] = function (request, data, root) {
  var i574 = root || request.c( 'UnityEngine.SoftJointLimitSpring' )
  var i575 = data
  i574.m_Spring = i575[0]
  i574.m_Damper = i575[1]
  return i574
}

Deserializers["UnityEngine.SoftJointLimit"] = function (request, data, root) {
  var i576 = root || request.c( 'UnityEngine.SoftJointLimit' )
  var i577 = data
  i576.m_Limit = i577[0]
  i576.m_Bounciness = i577[1]
  i576.m_ContactDistance = i577[2]
  return i576
}

Deserializers["UnityEngine.WheelFrictionCurve"] = function (request, data, root) {
  var i578 = root || request.c( 'UnityEngine.WheelFrictionCurve' )
  var i579 = data
  i578.m_ExtremumSlip = i579[0]
  i578.m_ExtremumValue = i579[1]
  i578.m_AsymptoteSlip = i579[2]
  i578.m_AsymptoteValue = i579[3]
  i578.m_Stiffness = i579[4]
  return i578
}

Deserializers["UnityEngine.JointAngleLimits2D"] = function (request, data, root) {
  var i580 = root || request.c( 'UnityEngine.JointAngleLimits2D' )
  var i581 = data
  i580.m_LowerAngle = i581[0]
  i580.m_UpperAngle = i581[1]
  return i580
}

Deserializers["UnityEngine.JointMotor2D"] = function (request, data, root) {
  var i582 = root || request.c( 'UnityEngine.JointMotor2D' )
  var i583 = data
  i582.m_MotorSpeed = i583[0]
  i582.m_MaximumMotorTorque = i583[1]
  return i582
}

Deserializers["UnityEngine.JointSuspension2D"] = function (request, data, root) {
  var i584 = root || request.c( 'UnityEngine.JointSuspension2D' )
  var i585 = data
  i584.m_DampingRatio = i585[0]
  i584.m_Frequency = i585[1]
  i584.m_Angle = i585[2]
  return i584
}

Deserializers["UnityEngine.JointTranslationLimits2D"] = function (request, data, root) {
  var i586 = root || request.c( 'UnityEngine.JointTranslationLimits2D' )
  var i587 = data
  i586.m_LowerTranslation = i587[0]
  i586.m_UpperTranslation = i587[1]
  return i586
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.RectTransform"] = function (request, data, root) {
  var i588 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.RectTransform' )
  var i589 = data
  i588.pivot = new pc.Vec2( i589[0], i589[1] )
  i588.anchorMin = new pc.Vec2( i589[2], i589[3] )
  i588.anchorMax = new pc.Vec2( i589[4], i589[5] )
  i588.sizeDelta = new pc.Vec2( i589[6], i589[7] )
  i588.anchoredPosition3D = new pc.Vec3( i589[8], i589[9], i589[10] )
  i588.rotation = new pc.Quat(i589[11], i589[12], i589[13], i589[14])
  i588.scale = new pc.Vec3( i589[15], i589[16], i589[17] )
  return i588
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer"] = function (request, data, root) {
  var i590 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer' )
  var i591 = data
  i590.cullTransparentMesh = !!i591[0]
  return i590
}

Deserializers["UnityEngine.UI.Image"] = function (request, data, root) {
  var i592 = root || request.c( 'UnityEngine.UI.Image' )
  var i593 = data
  request.r(i593[0], i593[1], 0, i592, 'm_Sprite')
  i592.m_Type = i593[2]
  i592.m_PreserveAspect = !!i593[3]
  i592.m_FillCenter = !!i593[4]
  i592.m_FillMethod = i593[5]
  i592.m_FillAmount = i593[6]
  i592.m_FillClockwise = !!i593[7]
  i592.m_FillOrigin = i593[8]
  i592.m_UseSpriteMesh = !!i593[9]
  i592.m_PixelsPerUnitMultiplier = i593[10]
  request.r(i593[11], i593[12], 0, i592, 'm_Material')
  i592.m_Maskable = !!i593[13]
  i592.m_Color = new pc.Color(i593[14], i593[15], i593[16], i593[17])
  i592.m_RaycastTarget = !!i593[18]
  i592.m_RaycastPadding = new pc.Vec4( i593[19], i593[20], i593[21], i593[22] )
  return i592
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.GameObject"] = function (request, data, root) {
  var i594 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.GameObject' )
  var i595 = data
  i594.name = i595[0]
  i594.tagId = i595[1]
  i594.enabled = !!i595[2]
  i594.isStatic = !!i595[3]
  i594.layer = i595[4]
  return i594
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Texture2D"] = function (request, data, root) {
  var i596 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Texture2D' )
  var i597 = data
  i596.name = i597[0]
  i596.width = i597[1]
  i596.height = i597[2]
  i596.mipmapCount = i597[3]
  i596.anisoLevel = i597[4]
  i596.filterMode = i597[5]
  i596.hdr = !!i597[6]
  i596.format = i597[7]
  i596.wrapMode = i597[8]
  i596.alphaIsTransparency = !!i597[9]
  i596.alphaSource = i597[10]
  i596.graphicsFormat = i597[11]
  i596.sRGBTexture = !!i597[12]
  i596.desiredColorSpace = i597[13]
  i596.wrapU = i597[14]
  i596.wrapV = i597[15]
  return i596
}

Deserializers["UnityEngine.UI.Slider"] = function (request, data, root) {
  var i598 = root || request.c( 'UnityEngine.UI.Slider' )
  var i599 = data
  request.r(i599[0], i599[1], 0, i598, 'm_FillRect')
  request.r(i599[2], i599[3], 0, i598, 'm_HandleRect')
  i598.m_Direction = i599[4]
  i598.m_MinValue = i599[5]
  i598.m_MaxValue = i599[6]
  i598.m_WholeNumbers = !!i599[7]
  i598.m_Value = i599[8]
  i598.m_OnValueChanged = request.d('UnityEngine.UI.Slider+SliderEvent', i599[9], i598.m_OnValueChanged)
  i598.m_Navigation = request.d('UnityEngine.UI.Navigation', i599[10], i598.m_Navigation)
  i598.m_Transition = i599[11]
  i598.m_Colors = request.d('UnityEngine.UI.ColorBlock', i599[12], i598.m_Colors)
  i598.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i599[13], i598.m_SpriteState)
  i598.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i599[14], i598.m_AnimationTriggers)
  i598.m_Interactable = !!i599[15]
  request.r(i599[16], i599[17], 0, i598, 'm_TargetGraphic')
  return i598
}

Deserializers["UnityEngine.UI.Slider+SliderEvent"] = function (request, data, root) {
  var i600 = root || request.c( 'UnityEngine.UI.Slider+SliderEvent' )
  var i601 = data
  i600.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i601[0], i600.m_PersistentCalls)
  return i600
}

Deserializers["UnityEngine.Events.PersistentCallGroup"] = function (request, data, root) {
  var i602 = root || request.c( 'UnityEngine.Events.PersistentCallGroup' )
  var i603 = data
  var i605 = i603[0]
  var i604 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Events.PersistentCall')))
  for(var i = 0; i < i605.length; i += 1) {
    i604.add(request.d('UnityEngine.Events.PersistentCall', i605[i + 0]));
  }
  i602.m_Calls = i604
  return i602
}

Deserializers["UnityEngine.Events.PersistentCall"] = function (request, data, root) {
  var i608 = root || request.c( 'UnityEngine.Events.PersistentCall' )
  var i609 = data
  request.r(i609[0], i609[1], 0, i608, 'm_Target')
  i608.m_TargetAssemblyTypeName = i609[2]
  i608.m_MethodName = i609[3]
  i608.m_Mode = i609[4]
  i608.m_Arguments = request.d('UnityEngine.Events.ArgumentCache', i609[5], i608.m_Arguments)
  i608.m_CallState = i609[6]
  return i608
}

Deserializers["UnityEngine.UI.Navigation"] = function (request, data, root) {
  var i610 = root || request.c( 'UnityEngine.UI.Navigation' )
  var i611 = data
  i610.m_Mode = i611[0]
  i610.m_WrapAround = !!i611[1]
  request.r(i611[2], i611[3], 0, i610, 'm_SelectOnUp')
  request.r(i611[4], i611[5], 0, i610, 'm_SelectOnDown')
  request.r(i611[6], i611[7], 0, i610, 'm_SelectOnLeft')
  request.r(i611[8], i611[9], 0, i610, 'm_SelectOnRight')
  return i610
}

Deserializers["UnityEngine.UI.ColorBlock"] = function (request, data, root) {
  var i612 = root || request.c( 'UnityEngine.UI.ColorBlock' )
  var i613 = data
  i612.m_NormalColor = new pc.Color(i613[0], i613[1], i613[2], i613[3])
  i612.m_HighlightedColor = new pc.Color(i613[4], i613[5], i613[6], i613[7])
  i612.m_PressedColor = new pc.Color(i613[8], i613[9], i613[10], i613[11])
  i612.m_SelectedColor = new pc.Color(i613[12], i613[13], i613[14], i613[15])
  i612.m_DisabledColor = new pc.Color(i613[16], i613[17], i613[18], i613[19])
  i612.m_ColorMultiplier = i613[20]
  i612.m_FadeDuration = i613[21]
  return i612
}

Deserializers["UnityEngine.UI.SpriteState"] = function (request, data, root) {
  var i614 = root || request.c( 'UnityEngine.UI.SpriteState' )
  var i615 = data
  request.r(i615[0], i615[1], 0, i614, 'm_HighlightedSprite')
  request.r(i615[2], i615[3], 0, i614, 'm_PressedSprite')
  request.r(i615[4], i615[5], 0, i614, 'm_SelectedSprite')
  request.r(i615[6], i615[7], 0, i614, 'm_DisabledSprite')
  return i614
}

Deserializers["UnityEngine.UI.AnimationTriggers"] = function (request, data, root) {
  var i616 = root || request.c( 'UnityEngine.UI.AnimationTriggers' )
  var i617 = data
  i616.m_NormalTrigger = i617[0]
  i616.m_HighlightedTrigger = i617[1]
  i616.m_PressedTrigger = i617[2]
  i616.m_SelectedTrigger = i617[3]
  i616.m_DisabledTrigger = i617[4]
  return i616
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Animator"] = function (request, data, root) {
  var i618 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Animator' )
  var i619 = data
  request.r(i619[0], i619[1], 0, i618, 'animatorController')
  request.r(i619[2], i619[3], 0, i618, 'avatar')
  i618.updateMode = i619[4]
  i618.hasTransformHierarchy = !!i619[5]
  i618.applyRootMotion = !!i619[6]
  var i621 = i619[7]
  var i620 = []
  for(var i = 0; i < i621.length; i += 2) {
  request.r(i621[i + 0], i621[i + 1], 2, i620, '')
  }
  i618.humanBones = i620
  i618.enabled = !!i619[8]
  return i618
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material"] = function (request, data, root) {
  var i624 = root || new pc.UnityMaterial()
  var i625 = data
  i624.name = i625[0]
  request.r(i625[1], i625[2], 0, i624, 'shader')
  i624.renderQueue = i625[3]
  i624.enableInstancing = !!i625[4]
  var i627 = i625[5]
  var i626 = []
  for(var i = 0; i < i627.length; i += 1) {
    i626.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter', i627[i + 0]) );
  }
  i624.floatParameters = i626
  var i629 = i625[6]
  var i628 = []
  for(var i = 0; i < i629.length; i += 1) {
    i628.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter', i629[i + 0]) );
  }
  i624.colorParameters = i628
  var i631 = i625[7]
  var i630 = []
  for(var i = 0; i < i631.length; i += 1) {
    i630.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter', i631[i + 0]) );
  }
  i624.vectorParameters = i630
  var i633 = i625[8]
  var i632 = []
  for(var i = 0; i < i633.length; i += 1) {
    i632.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter', i633[i + 0]) );
  }
  i624.textureParameters = i632
  var i635 = i625[9]
  var i634 = []
  for(var i = 0; i < i635.length; i += 1) {
    i634.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag', i635[i + 0]) );
  }
  i624.materialFlags = i634
  return i624
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter"] = function (request, data, root) {
  var i638 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter' )
  var i639 = data
  i638.name = i639[0]
  i638.value = i639[1]
  return i638
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter"] = function (request, data, root) {
  var i642 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter' )
  var i643 = data
  i642.name = i643[0]
  i642.value = new pc.Color(i643[1], i643[2], i643[3], i643[4])
  return i642
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter"] = function (request, data, root) {
  var i646 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter' )
  var i647 = data
  i646.name = i647[0]
  i646.value = new pc.Vec4( i647[1], i647[2], i647[3], i647[4] )
  return i646
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter"] = function (request, data, root) {
  var i650 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter' )
  var i651 = data
  i650.name = i651[0]
  request.r(i651[1], i651[2], 0, i650, 'value')
  return i650
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag"] = function (request, data, root) {
  var i654 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag' )
  var i655 = data
  i654.name = i655[0]
  i654.enabled = !!i655[1]
  return i654
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.Scene"] = function (request, data, root) {
  var i656 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.Scene' )
  var i657 = data
  i656.name = i657[0]
  i656.index = i657[1]
  i656.startup = !!i657[2]
  return i656
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Camera"] = function (request, data, root) {
  var i658 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Camera' )
  var i659 = data
  i658.aspect = i659[0]
  i658.orthographic = !!i659[1]
  i658.orthographicSize = i659[2]
  i658.backgroundColor = new pc.Color(i659[3], i659[4], i659[5], i659[6])
  i658.nearClipPlane = i659[7]
  i658.farClipPlane = i659[8]
  i658.fieldOfView = i659[9]
  i658.depth = i659[10]
  i658.clearFlags = i659[11]
  i658.cullingMask = i659[12]
  i658.rect = i659[13]
  request.r(i659[14], i659[15], 0, i658, 'targetTexture')
  i658.usePhysicalProperties = !!i659[16]
  i658.focalLength = i659[17]
  i658.sensorSize = new pc.Vec2( i659[18], i659[19] )
  i658.lensShift = new pc.Vec2( i659[20], i659[21] )
  i658.gateFit = i659[22]
  i658.commandBufferCount = i659[23]
  i658.cameraType = i659[24]
  i658.enabled = !!i659[25]
  return i658
}

Deserializers["UnityEngine.Rendering.Universal.UniversalAdditionalCameraData"] = function (request, data, root) {
  var i660 = root || request.c( 'UnityEngine.Rendering.Universal.UniversalAdditionalCameraData' )
  var i661 = data
  i660.m_RenderShadows = !!i661[0]
  i660.m_RequiresDepthTextureOption = i661[1]
  i660.m_RequiresOpaqueTextureOption = i661[2]
  i660.m_CameraType = i661[3]
  var i663 = i661[4]
  var i662 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Camera')))
  for(var i = 0; i < i663.length; i += 2) {
  request.r(i663[i + 0], i663[i + 1], 1, i662, '')
  }
  i660.m_Cameras = i662
  i660.m_RendererIndex = i661[5]
  i660.m_VolumeLayerMask = UnityEngine.LayerMask.FromIntegerValue( i661[6] )
  request.r(i661[7], i661[8], 0, i660, 'm_VolumeTrigger')
  i660.m_VolumeFrameworkUpdateModeOption = i661[9]
  i660.m_RenderPostProcessing = !!i661[10]
  i660.m_Antialiasing = i661[11]
  i660.m_AntialiasingQuality = i661[12]
  i660.m_StopNaN = !!i661[13]
  i660.m_Dithering = !!i661[14]
  i660.m_ClearDepth = !!i661[15]
  i660.m_AllowXRRendering = !!i661[16]
  i660.m_AllowHDROutput = !!i661[17]
  i660.m_UseScreenCoordOverride = !!i661[18]
  i660.m_ScreenSizeOverride = new pc.Vec4( i661[19], i661[20], i661[21], i661[22] )
  i660.m_ScreenCoordScaleBias = new pc.Vec4( i661[23], i661[24], i661[25], i661[26] )
  i660.m_RequiresDepthTexture = !!i661[27]
  i660.m_RequiresColorTexture = !!i661[28]
  i660.m_Version = i661[29]
  i660.m_TaaSettings = request.d('UnityEngine.Rendering.Universal.TemporalAA+Settings', i661[30], i660.m_TaaSettings)
  return i660
}

Deserializers["UnityEngine.Rendering.Universal.TemporalAA+Settings"] = function (request, data, root) {
  var i666 = root || request.c( 'UnityEngine.Rendering.Universal.TemporalAA+Settings' )
  var i667 = data
  i666.m_Quality = i667[0]
  i666.m_FrameInfluence = i667[1]
  i666.m_JitterScale = i667[2]
  i666.m_MipBias = i667[3]
  i666.m_VarianceClampScale = i667[4]
  i666.m_ContrastAdaptiveSharpening = i667[5]
  return i666
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Canvas"] = function (request, data, root) {
  var i668 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Canvas' )
  var i669 = data
  i668.planeDistance = i669[0]
  i668.referencePixelsPerUnit = i669[1]
  i668.isFallbackOverlay = !!i669[2]
  i668.renderMode = i669[3]
  i668.renderOrder = i669[4]
  i668.sortingLayerName = i669[5]
  i668.sortingOrder = i669[6]
  i668.scaleFactor = i669[7]
  request.r(i669[8], i669[9], 0, i668, 'worldCamera')
  i668.overrideSorting = !!i669[10]
  i668.pixelPerfect = !!i669[11]
  i668.targetDisplay = i669[12]
  i668.overridePixelPerfect = !!i669[13]
  i668.enabled = !!i669[14]
  return i668
}

Deserializers["UnityEngine.UI.CanvasScaler"] = function (request, data, root) {
  var i670 = root || request.c( 'UnityEngine.UI.CanvasScaler' )
  var i671 = data
  i670.m_UiScaleMode = i671[0]
  i670.m_ReferencePixelsPerUnit = i671[1]
  i670.m_ScaleFactor = i671[2]
  i670.m_ReferenceResolution = new pc.Vec2( i671[3], i671[4] )
  i670.m_ScreenMatchMode = i671[5]
  i670.m_MatchWidthOrHeight = i671[6]
  i670.m_PhysicalUnit = i671[7]
  i670.m_FallbackScreenDPI = i671[8]
  i670.m_DefaultSpriteDPI = i671[9]
  i670.m_DynamicPixelsPerUnit = i671[10]
  i670.m_PresetInfoIsWorld = !!i671[11]
  return i670
}

Deserializers["UnityEngine.UI.GraphicRaycaster"] = function (request, data, root) {
  var i672 = root || request.c( 'UnityEngine.UI.GraphicRaycaster' )
  var i673 = data
  i672.m_IgnoreReversedGraphics = !!i673[0]
  i672.m_BlockingObjects = i673[1]
  i672.m_BlockingMask = UnityEngine.LayerMask.FromIntegerValue( i673[2] )
  return i672
}

Deserializers["SliderAnimator"] = function (request, data, root) {
  var i674 = root || request.c( 'SliderAnimator' )
  var i675 = data
  request.r(i675[0], i675[1], 0, i674, 'slider')
  request.r(i675[2], i675[3], 0, i674, 'handle')
  request.r(i675[4], i675[5], 0, i674, 'reward')
  request.r(i675[6], i675[7], 0, i674, 'animationConfig')
  i674.currentValue = i675[8]
  i674.maxValue = i675[9]
  return i674
}

Deserializers["VPopup.VCanvas"] = function (request, data, root) {
  var i676 = root || request.c( 'VPopup.VCanvas' )
  var i677 = data
  request.r(i677[0], i677[1], 0, i676, 'rectTransform')
  return i676
}

Deserializers["UnityEngine.UI.Button"] = function (request, data, root) {
  var i678 = root || request.c( 'UnityEngine.UI.Button' )
  var i679 = data
  i678.m_OnClick = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i679[0], i678.m_OnClick)
  i678.m_Navigation = request.d('UnityEngine.UI.Navigation', i679[1], i678.m_Navigation)
  i678.m_Transition = i679[2]
  i678.m_Colors = request.d('UnityEngine.UI.ColorBlock', i679[3], i678.m_Colors)
  i678.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i679[4], i678.m_SpriteState)
  i678.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i679[5], i678.m_AnimationTriggers)
  i678.m_Interactable = !!i679[6]
  request.r(i679[7], i679[8], 0, i678, 'm_TargetGraphic')
  return i678
}

Deserializers["UnityEngine.UI.Button+ButtonClickedEvent"] = function (request, data, root) {
  var i680 = root || request.c( 'UnityEngine.UI.Button+ButtonClickedEvent' )
  var i681 = data
  i680.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i681[0], i680.m_PersistentCalls)
  return i680
}

Deserializers["UnityEngine.Events.ArgumentCache"] = function (request, data, root) {
  var i682 = root || request.c( 'UnityEngine.Events.ArgumentCache' )
  var i683 = data
  request.r(i683[0], i683[1], 0, i682, 'm_ObjectArgument')
  i682.m_ObjectArgumentAssemblyTypeName = i683[2]
  i682.m_IntArgument = i683[3]
  i682.m_FloatArgument = i683[4]
  i682.m_StringArgument = i683[5]
  i682.m_BoolArgument = !!i683[6]
  return i682
}

Deserializers["TMPro.TextMeshProUGUI"] = function (request, data, root) {
  var i684 = root || request.c( 'TMPro.TextMeshProUGUI' )
  var i685 = data
  i684.m_hasFontAssetChanged = !!i685[0]
  request.r(i685[1], i685[2], 0, i684, 'm_baseMaterial')
  i684.m_maskOffset = new pc.Vec4( i685[3], i685[4], i685[5], i685[6] )
  i684.m_text = i685[7]
  i684.m_isRightToLeft = !!i685[8]
  request.r(i685[9], i685[10], 0, i684, 'm_fontAsset')
  request.r(i685[11], i685[12], 0, i684, 'm_sharedMaterial')
  var i687 = i685[13]
  var i686 = []
  for(var i = 0; i < i687.length; i += 2) {
  request.r(i687[i + 0], i687[i + 1], 2, i686, '')
  }
  i684.m_fontSharedMaterials = i686
  request.r(i685[14], i685[15], 0, i684, 'm_fontMaterial')
  var i689 = i685[16]
  var i688 = []
  for(var i = 0; i < i689.length; i += 2) {
  request.r(i689[i + 0], i689[i + 1], 2, i688, '')
  }
  i684.m_fontMaterials = i688
  i684.m_fontColor32 = UnityEngine.Color32.ConstructColor(i685[17], i685[18], i685[19], i685[20])
  i684.m_fontColor = new pc.Color(i685[21], i685[22], i685[23], i685[24])
  i684.m_enableVertexGradient = !!i685[25]
  i684.m_colorMode = i685[26]
  i684.m_fontColorGradient = request.d('TMPro.VertexGradient', i685[27], i684.m_fontColorGradient)
  request.r(i685[28], i685[29], 0, i684, 'm_fontColorGradientPreset')
  request.r(i685[30], i685[31], 0, i684, 'm_spriteAsset')
  i684.m_tintAllSprites = !!i685[32]
  request.r(i685[33], i685[34], 0, i684, 'm_StyleSheet')
  i684.m_TextStyleHashCode = i685[35]
  i684.m_overrideHtmlColors = !!i685[36]
  i684.m_faceColor = UnityEngine.Color32.ConstructColor(i685[37], i685[38], i685[39], i685[40])
  i684.m_fontSize = i685[41]
  i684.m_fontSizeBase = i685[42]
  i684.m_fontWeight = i685[43]
  i684.m_enableAutoSizing = !!i685[44]
  i684.m_fontSizeMin = i685[45]
  i684.m_fontSizeMax = i685[46]
  i684.m_fontStyle = i685[47]
  i684.m_HorizontalAlignment = i685[48]
  i684.m_VerticalAlignment = i685[49]
  i684.m_textAlignment = i685[50]
  i684.m_characterSpacing = i685[51]
  i684.m_wordSpacing = i685[52]
  i684.m_lineSpacing = i685[53]
  i684.m_lineSpacingMax = i685[54]
  i684.m_paragraphSpacing = i685[55]
  i684.m_charWidthMaxAdj = i685[56]
  i684.m_enableWordWrapping = !!i685[57]
  i684.m_wordWrappingRatios = i685[58]
  i684.m_overflowMode = i685[59]
  request.r(i685[60], i685[61], 0, i684, 'm_linkedTextComponent')
  request.r(i685[62], i685[63], 0, i684, 'parentLinkedComponent')
  i684.m_enableKerning = !!i685[64]
  i684.m_enableExtraPadding = !!i685[65]
  i684.checkPaddingRequired = !!i685[66]
  i684.m_isRichText = !!i685[67]
  i684.m_parseCtrlCharacters = !!i685[68]
  i684.m_isOrthographic = !!i685[69]
  i684.m_isCullingEnabled = !!i685[70]
  i684.m_horizontalMapping = i685[71]
  i684.m_verticalMapping = i685[72]
  i684.m_uvLineOffset = i685[73]
  i684.m_geometrySortingOrder = i685[74]
  i684.m_IsTextObjectScaleStatic = !!i685[75]
  i684.m_VertexBufferAutoSizeReduction = !!i685[76]
  i684.m_useMaxVisibleDescender = !!i685[77]
  i684.m_pageToDisplay = i685[78]
  i684.m_margin = new pc.Vec4( i685[79], i685[80], i685[81], i685[82] )
  i684.m_isUsingLegacyAnimationComponent = !!i685[83]
  i684.m_isVolumetricText = !!i685[84]
  request.r(i685[85], i685[86], 0, i684, 'm_Material')
  i684.m_Maskable = !!i685[87]
  i684.m_Color = new pc.Color(i685[88], i685[89], i685[90], i685[91])
  i684.m_RaycastTarget = !!i685[92]
  i684.m_RaycastPadding = new pc.Vec4( i685[93], i685[94], i685[95], i685[96] )
  return i684
}

Deserializers["TMPro.VertexGradient"] = function (request, data, root) {
  var i692 = root || request.c( 'TMPro.VertexGradient' )
  var i693 = data
  i692.topLeft = new pc.Color(i693[0], i693[1], i693[2], i693[3])
  i692.topRight = new pc.Color(i693[4], i693[5], i693[6], i693[7])
  i692.bottomLeft = new pc.Color(i693[8], i693[9], i693[10], i693[11])
  i692.bottomRight = new pc.Color(i693[12], i693[13], i693[14], i693[15])
  return i692
}

Deserializers["VPopup.VPopup"] = function (request, data, root) {
  var i694 = root || request.c( 'VPopup.VPopup' )
  var i695 = data
  i694.popupName = i695[0]
  request.r(i695[1], i695[2], 0, i694, 'animationHandler')
  request.r(i695[3], i695[4], 0, i694, 'canvasParent')
  request.r(i695[5], i695[6], 0, i694, 'overlayCanvasGroup')
  request.r(i695[7], i695[8], 0, i694, 'contentRectTransform')
  i694.disableOnAwake = !!i695[9]
  i694.enableOverlay = !!i695[10]
  i694.allowInterruptAnimation = !!i695[11]
  i694.disablePopupGameObjectOnAnimationOnHidden = !!i695[12]
  i694.onPopupOpenBeganEvent = request.d('UnityEngine.Events.UnityEvent', i695[13], i694.onPopupOpenBeganEvent)
  i694.onPopupOpenEndedEvent = request.d('UnityEngine.Events.UnityEvent', i695[14], i694.onPopupOpenEndedEvent)
  i694.onPopupCloseBeganEvent = request.d('UnityEngine.Events.UnityEvent', i695[15], i694.onPopupCloseBeganEvent)
  i694.onPopupCloseEndedEvent = request.d('UnityEngine.Events.UnityEvent', i695[16], i694.onPopupCloseEndedEvent)
  i694.contentInitialAnchorPos = new pc.Vec2( i695[17], i695[18] )
  i694.contentInitialScale = new pc.Vec3( i695[19], i695[20], i695[21] )
  i694.contentInitialAlpha = i695[22]
  request.r(i695[23], i695[24], 0, i694, 'contentCanvasGroup')
  return i694
}

Deserializers["UnityEngine.Events.UnityEvent"] = function (request, data, root) {
  var i696 = root || request.c( 'UnityEngine.Events.UnityEvent' )
  var i697 = data
  i696.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i697[0], i696.m_PersistentCalls)
  return i696
}

Deserializers["VPopup.Tween_Animation_Handler.PopupTweenAnimationHandler"] = function (request, data, root) {
  var i698 = root || request.c( 'VPopup.Tween_Animation_Handler.PopupTweenAnimationHandler' )
  var i699 = data
  request.r(i699[0], i699[1], 0, i698, 'tweenShowAnimationConfig')
  request.r(i699[2], i699[3], 0, i698, 'tweenHideAnimationConfig')
  i698.showAnimationDelay = i699[4]
  i698.hideAnimationDelay = i699[5]
  i698.onShowAnimationBeganEvent = request.d('UnityEngine.Events.UnityEvent', i699[6], i698.onShowAnimationBeganEvent)
  i698.onShowAnimationEndedEvent = request.d('UnityEngine.Events.UnityEvent', i699[7], i698.onShowAnimationEndedEvent)
  i698.onHideAnimationBeganEvent = request.d('UnityEngine.Events.UnityEvent', i699[8], i698.onHideAnimationBeganEvent)
  i698.onHideAnimationEndedEvent = request.d('UnityEngine.Events.UnityEvent', i699[9], i698.onHideAnimationEndedEvent)
  i698.overlayEase = i699[10]
  return i698
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasGroup"] = function (request, data, root) {
  var i700 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasGroup' )
  var i701 = data
  i700.m_Alpha = i701[0]
  i700.m_Interactable = !!i701[1]
  i700.m_BlocksRaycasts = !!i701[2]
  i700.m_IgnoreParentGroups = !!i701[3]
  i700.enabled = !!i701[4]
  return i700
}

Deserializers["VPopup.AnimatorPopupAnimationHandler"] = function (request, data, root) {
  var i702 = root || request.c( 'VPopup.AnimatorPopupAnimationHandler' )
  var i703 = data
  request.r(i703[0], i703[1], 0, i702, 'animator')
  i702.showStateName = i703[2]
  i702.hideStateName = i703[3]
  return i702
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer"] = function (request, data, root) {
  var i704 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer' )
  var i705 = data
  i704.color = new pc.Color(i705[0], i705[1], i705[2], i705[3])
  request.r(i705[4], i705[5], 0, i704, 'sprite')
  i704.flipX = !!i705[6]
  i704.flipY = !!i705[7]
  i704.drawMode = i705[8]
  i704.size = new pc.Vec2( i705[9], i705[10] )
  i704.tileMode = i705[11]
  i704.adaptiveModeThreshold = i705[12]
  i704.maskInteraction = i705[13]
  i704.spriteSortPoint = i705[14]
  i704.enabled = !!i705[15]
  request.r(i705[16], i705[17], 0, i704, 'sharedMaterial')
  var i707 = i705[18]
  var i706 = []
  for(var i = 0; i < i707.length; i += 2) {
  request.r(i707[i + 0], i707[i + 1], 2, i706, '')
  }
  i704.sharedMaterials = i706
  i704.receiveShadows = !!i705[19]
  i704.shadowCastingMode = i705[20]
  i704.sortingLayerID = i705[21]
  i704.sortingOrder = i705[22]
  i704.lightmapIndex = i705[23]
  i704.lightmapSceneIndex = i705[24]
  i704.lightmapScaleOffset = new pc.Vec4( i705[25], i705[26], i705[27], i705[28] )
  i704.lightProbeUsage = i705[29]
  i704.reflectionProbeUsage = i705[30]
  return i704
}

Deserializers["UnitA"] = function (request, data, root) {
  var i708 = root || request.c( 'UnitA' )
  var i709 = data
  request.r(i709[0], i709[1], 0, i708, 'sosEventChannel')
  return i708
}

Deserializers["UnitB"] = function (request, data, root) {
  var i710 = root || request.c( 'UnitB' )
  var i711 = data
  return i710
}

Deserializers["DefaultNamespace.SOSEventChannelListener"] = function (request, data, root) {
  var i712 = root || request.c( 'DefaultNamespace.SOSEventChannelListener' )
  var i713 = data
  request.r(i713[0], i713[1], 0, i712, 'EventChannel')
  i712.Response = request.d('UnityEngine.Events.UnityEvent`1[[HelpMeEventArgs, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]', i713[2], i712.Response)
  return i712
}

Deserializers["UnityEngine.Events.UnityEvent`1[[HelpMeEventArgs, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"] = function (request, data, root) {
  var i714 = root || new (UnityEngine.Events.UnityEvent$1( Bridge.ns( 'HelpMeEventArgs' ) ))
  var i715 = data
  i714.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i715[0], i714.m_PersistentCalls)
  return i714
}

Deserializers["UnitC"] = function (request, data, root) {
  var i716 = root || request.c( 'UnitC' )
  var i717 = data
  request.r(i717[0], i717[1], 0, i716, 'SosEventChannel')
  return i716
}

Deserializers["Game"] = function (request, data, root) {
  var i718 = root || request.c( 'Game' )
  var i719 = data
  i718.recycleAllByDefault = !!i719[0]
  i718.useSafeMode = !!i719[1]
  i718.logBehaviour = i719[2]
  request.r(i719[3], i719[4], 0, i718, 'character')
  return i718
}

Deserializers["UnityEngine.EventSystems.EventSystem"] = function (request, data, root) {
  var i720 = root || request.c( 'UnityEngine.EventSystems.EventSystem' )
  var i721 = data
  request.r(i721[0], i721[1], 0, i720, 'm_FirstSelected')
  i720.m_sendNavigationEvents = !!i721[2]
  i720.m_DragThreshold = i721[3]
  return i720
}

Deserializers["UnityEngine.EventSystems.StandaloneInputModule"] = function (request, data, root) {
  var i722 = root || request.c( 'UnityEngine.EventSystems.StandaloneInputModule' )
  var i723 = data
  i722.m_HorizontalAxis = i723[0]
  i722.m_VerticalAxis = i723[1]
  i722.m_SubmitButton = i723[2]
  i722.m_CancelButton = i723[3]
  i722.m_InputActionsPerSecond = i723[4]
  i722.m_RepeatDelay = i723[5]
  i722.m_ForceModuleActive = !!i723[6]
  i722.m_SendPointerHoverToParent = !!i723[7]
  return i722
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings"] = function (request, data, root) {
  var i724 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings' )
  var i725 = data
  i724.ambientIntensity = i725[0]
  i724.reflectionIntensity = i725[1]
  i724.ambientMode = i725[2]
  i724.ambientLight = new pc.Color(i725[3], i725[4], i725[5], i725[6])
  i724.ambientSkyColor = new pc.Color(i725[7], i725[8], i725[9], i725[10])
  i724.ambientGroundColor = new pc.Color(i725[11], i725[12], i725[13], i725[14])
  i724.ambientEquatorColor = new pc.Color(i725[15], i725[16], i725[17], i725[18])
  i724.fogColor = new pc.Color(i725[19], i725[20], i725[21], i725[22])
  i724.fogEndDistance = i725[23]
  i724.fogStartDistance = i725[24]
  i724.fogDensity = i725[25]
  i724.fog = !!i725[26]
  request.r(i725[27], i725[28], 0, i724, 'skybox')
  i724.fogMode = i725[29]
  var i727 = i725[30]
  var i726 = []
  for(var i = 0; i < i727.length; i += 1) {
    i726.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap', i727[i + 0]) );
  }
  i724.lightmaps = i726
  i724.lightProbes = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes', i725[31], i724.lightProbes)
  i724.lightmapsMode = i725[32]
  i724.mixedBakeMode = i725[33]
  i724.environmentLightingMode = i725[34]
  i724.ambientProbe = new pc.SphericalHarmonicsL2(i725[35])
  i724.referenceAmbientProbe = new pc.SphericalHarmonicsL2(i725[36])
  i724.useReferenceAmbientProbe = !!i725[37]
  request.r(i725[38], i725[39], 0, i724, 'customReflection')
  request.r(i725[40], i725[41], 0, i724, 'defaultReflection')
  i724.defaultReflectionMode = i725[42]
  i724.defaultReflectionResolution = i725[43]
  i724.sunLightObjectId = i725[44]
  i724.pixelLightCount = i725[45]
  i724.defaultReflectionHDR = !!i725[46]
  i724.hasLightDataAsset = !!i725[47]
  i724.hasManualGenerate = !!i725[48]
  return i724
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap"] = function (request, data, root) {
  var i730 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap' )
  var i731 = data
  request.r(i731[0], i731[1], 0, i730, 'lightmapColor')
  request.r(i731[2], i731[3], 0, i730, 'lightmapDirection')
  return i730
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes"] = function (request, data, root) {
  var i732 = root || new UnityEngine.LightProbes()
  var i733 = data
  return i732
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset"] = function (request, data, root) {
  var i740 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset' )
  var i741 = data
  i740.AdditionalLightsPerObjectLimit = i741[0]
  i740.AdditionalLightsRenderingMode = i741[1]
  i740.LightRenderingMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode', i741[2], i740.LightRenderingMode)
  i740.ColorGradingLutSize = i741[3]
  i740.ColorGradingMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.ColorGradingMode', i741[4], i740.ColorGradingMode)
  i740.MainLightRenderingMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode', i741[5], i740.MainLightRenderingMode)
  i740.MainLightRenderingModeValue = i741[6]
  i740.SupportsMainLightShadows = !!i741[7]
  i740.MixedLightingSupported = !!i741[8]
  i740.MsaaQuality = request.d('Luna.Unity.DTO.UnityEngine.Assets.MsaaQuality', i741[9], i740.MsaaQuality)
  i740.MSAA = i741[10]
  i740.OpaqueDownsampling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Downsampling', i741[11], i740.OpaqueDownsampling)
  i740.MainLightShadowmapResolution = request.d('Luna.Unity.DTO.UnityEngine.Assets.ShadowResolution', i741[12], i740.MainLightShadowmapResolution)
  i740.MainLightShadowmapResolutionValue = i741[13]
  i740.SupportsSoftShadows = !!i741[14]
  i740.SoftShadowQuality = request.d('Luna.Unity.DTO.UnityEngine.Assets.SoftShadowQuality', i741[15], i740.SoftShadowQuality)
  i740.SoftShadowQualityValue = i741[16]
  i740.ShadowDistance = i741[17]
  i740.ShadowCascadeCount = i741[18]
  i740.Cascade2Split = i741[19]
  i740.Cascade3Split = new pc.Vec2( i741[20], i741[21] )
  i740.Cascade4Split = new pc.Vec3( i741[22], i741[23], i741[24] )
  i740.CascadeBorder = i741[25]
  i740.ShadowDepthBias = i741[26]
  i740.ShadowNormalBias = i741[27]
  i740.RenderScale = i741[28]
  i740.RequireDepthTexture = !!i741[29]
  i740.RequireOpaqueTexture = !!i741[30]
  i740.SupportsHDR = !!i741[31]
  i740.SupportsTerrainHoles = !!i741[32]
  return i740
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode"] = function (request, data, root) {
  var i742 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode' )
  var i743 = data
  i742.Disabled = i743[0]
  i742.PerVertex = i743[1]
  i742.PerPixel = i743[2]
  return i742
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ColorGradingMode"] = function (request, data, root) {
  var i744 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ColorGradingMode' )
  var i745 = data
  i744.LowDynamicRange = i745[0]
  i744.HighDynamicRange = i745[1]
  return i744
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.MsaaQuality"] = function (request, data, root) {
  var i746 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.MsaaQuality' )
  var i747 = data
  i746.Disabled = i747[0]
  i746._2x = i747[1]
  i746._4x = i747[2]
  i746._8x = i747[3]
  return i746
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Downsampling"] = function (request, data, root) {
  var i748 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Downsampling' )
  var i749 = data
  i748.None = i749[0]
  i748._2xBilinear = i749[1]
  i748._4xBox = i749[2]
  i748._4xBilinear = i749[3]
  return i748
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ShadowResolution"] = function (request, data, root) {
  var i750 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ShadowResolution' )
  var i751 = data
  i750._256 = i751[0]
  i750._512 = i751[1]
  i750._1024 = i751[2]
  i750._2048 = i751[3]
  i750._4096 = i751[4]
  return i750
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.SoftShadowQuality"] = function (request, data, root) {
  var i752 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.SoftShadowQuality' )
  var i753 = data
  i752.UsePipelineSettings = i753[0]
  i752.Low = i753[1]
  i752.Medium = i753[2]
  i752.High = i753[3]
  return i752
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader"] = function (request, data, root) {
  var i754 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader' )
  var i755 = data
  var i757 = i755[0]
  var i756 = new (System.Collections.Generic.List$1(Bridge.ns('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError')))
  for(var i = 0; i < i757.length; i += 1) {
    i756.add(request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError', i757[i + 0]));
  }
  i754.ShaderCompilationErrors = i756
  i754.name = i755[1]
  i754.guid = i755[2]
  var i759 = i755[3]
  var i758 = []
  for(var i = 0; i < i759.length; i += 1) {
    i758.push( i759[i + 0] );
  }
  i754.shaderDefinedKeywords = i758
  var i761 = i755[4]
  var i760 = []
  for(var i = 0; i < i761.length; i += 1) {
    i760.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass', i761[i + 0]) );
  }
  i754.passes = i760
  var i763 = i755[5]
  var i762 = []
  for(var i = 0; i < i763.length; i += 1) {
    i762.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass', i763[i + 0]) );
  }
  i754.usePasses = i762
  var i765 = i755[6]
  var i764 = []
  for(var i = 0; i < i765.length; i += 1) {
    i764.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue', i765[i + 0]) );
  }
  i754.defaultParameterValues = i764
  request.r(i755[7], i755[8], 0, i754, 'unityFallbackShader')
  i754.readDepth = !!i755[9]
  i754.hasDepthOnlyPass = !!i755[10]
  i754.isCreatedByShaderGraph = !!i755[11]
  i754.disableBatching = !!i755[12]
  i754.compiled = !!i755[13]
  return i754
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError"] = function (request, data, root) {
  var i768 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError' )
  var i769 = data
  i768.shaderName = i769[0]
  i768.errorMessage = i769[1]
  return i768
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass"] = function (request, data, root) {
  var i774 = root || new pc.UnityShaderPass()
  var i775 = data
  i774.id = i775[0]
  i774.subShaderIndex = i775[1]
  i774.name = i775[2]
  i774.passType = i775[3]
  i774.grabPassTextureName = i775[4]
  i774.usePass = !!i775[5]
  i774.zTest = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[6], i774.zTest)
  i774.zWrite = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[7], i774.zWrite)
  i774.culling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[8], i774.culling)
  i774.blending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i775[9], i774.blending)
  i774.alphaBlending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i775[10], i774.alphaBlending)
  i774.colorWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[11], i774.colorWriteMask)
  i774.offsetUnits = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[12], i774.offsetUnits)
  i774.offsetFactor = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[13], i774.offsetFactor)
  i774.stencilRef = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[14], i774.stencilRef)
  i774.stencilReadMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[15], i774.stencilReadMask)
  i774.stencilWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i775[16], i774.stencilWriteMask)
  i774.stencilOp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i775[17], i774.stencilOp)
  i774.stencilOpFront = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i775[18], i774.stencilOpFront)
  i774.stencilOpBack = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i775[19], i774.stencilOpBack)
  var i777 = i775[20]
  var i776 = []
  for(var i = 0; i < i777.length; i += 1) {
    i776.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag', i777[i + 0]) );
  }
  i774.tags = i776
  var i779 = i775[21]
  var i778 = []
  for(var i = 0; i < i779.length; i += 1) {
    i778.push( i779[i + 0] );
  }
  i774.passDefinedKeywords = i778
  var i781 = i775[22]
  var i780 = []
  for(var i = 0; i < i781.length; i += 1) {
    i780.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup', i781[i + 0]) );
  }
  i774.passDefinedKeywordGroups = i780
  var i783 = i775[23]
  var i782 = []
  for(var i = 0; i < i783.length; i += 1) {
    i782.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i783[i + 0]) );
  }
  i774.variants = i782
  var i785 = i775[24]
  var i784 = []
  for(var i = 0; i < i785.length; i += 1) {
    i784.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i785[i + 0]) );
  }
  i774.excludedVariants = i784
  i774.hasDepthReader = !!i775[25]
  return i774
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value"] = function (request, data, root) {
  var i786 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value' )
  var i787 = data
  i786.val = i787[0]
  i786.name = i787[1]
  return i786
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending"] = function (request, data, root) {
  var i788 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending' )
  var i789 = data
  i788.src = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i789[0], i788.src)
  i788.dst = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i789[1], i788.dst)
  i788.op = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i789[2], i788.op)
  return i788
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp"] = function (request, data, root) {
  var i790 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp' )
  var i791 = data
  i790.pass = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i791[0], i790.pass)
  i790.fail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i791[1], i790.fail)
  i790.zFail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i791[2], i790.zFail)
  i790.comp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i791[3], i790.comp)
  return i790
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag"] = function (request, data, root) {
  var i794 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag' )
  var i795 = data
  i794.name = i795[0]
  i794.value = i795[1]
  return i794
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup"] = function (request, data, root) {
  var i798 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup' )
  var i799 = data
  var i801 = i799[0]
  var i800 = []
  for(var i = 0; i < i801.length; i += 1) {
    i800.push( i801[i + 0] );
  }
  i798.keywords = i800
  i798.hasDiscard = !!i799[1]
  return i798
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant"] = function (request, data, root) {
  var i804 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant' )
  var i805 = data
  i804.passId = i805[0]
  i804.subShaderIndex = i805[1]
  var i807 = i805[2]
  var i806 = []
  for(var i = 0; i < i807.length; i += 1) {
    i806.push( i807[i + 0] );
  }
  i804.keywords = i806
  i804.vertexProgram = i805[3]
  i804.fragmentProgram = i805[4]
  i804.exportedForWebGl2 = !!i805[5]
  i804.readDepth = !!i805[6]
  return i804
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass"] = function (request, data, root) {
  var i810 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass' )
  var i811 = data
  request.r(i811[0], i811[1], 0, i810, 'shader')
  i810.pass = i811[2]
  return i810
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue"] = function (request, data, root) {
  var i814 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue' )
  var i815 = data
  i814.name = i815[0]
  i814.type = i815[1]
  i814.value = new pc.Vec4( i815[2], i815[3], i815[4], i815[5] )
  i814.textureValue = i815[6]
  i814.shaderPropertyFlag = i815[7]
  return i814
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Sprite"] = function (request, data, root) {
  var i816 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Sprite' )
  var i817 = data
  i816.name = i817[0]
  request.r(i817[1], i817[2], 0, i816, 'texture')
  i816.aabb = i817[3]
  i816.vertices = i817[4]
  i816.triangles = i817[5]
  i816.textureRect = UnityEngine.Rect.MinMaxRect(i817[6], i817[7], i817[8], i817[9])
  i816.packedRect = UnityEngine.Rect.MinMaxRect(i817[10], i817[11], i817[12], i817[13])
  i816.border = new pc.Vec4( i817[14], i817[15], i817[16], i817[17] )
  i816.transparency = i817[18]
  i816.bounds = i817[19]
  i816.pixelsPerUnit = i817[20]
  i816.textureWidth = i817[21]
  i816.textureHeight = i817[22]
  i816.nativeSize = new pc.Vec2( i817[23], i817[24] )
  i816.pivot = new pc.Vec2( i817[25], i817[26] )
  i816.textureRectOffset = new pc.Vec2( i817[27], i817[28] )
  return i816
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip"] = function (request, data, root) {
  var i818 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip' )
  var i819 = data
  i818.name = i819[0]
  i818.wrapMode = i819[1]
  i818.isLooping = !!i819[2]
  i818.length = i819[3]
  var i821 = i819[4]
  var i820 = []
  for(var i = 0; i < i821.length; i += 1) {
    i820.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve', i821[i + 0]) );
  }
  i818.curves = i820
  var i823 = i819[5]
  var i822 = []
  for(var i = 0; i < i823.length; i += 1) {
    i822.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent', i823[i + 0]) );
  }
  i818.events = i822
  i818.halfPrecision = !!i819[6]
  i818._frameRate = i819[7]
  i818.localBounds = request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds', i819[8], i818.localBounds)
  i818.hasMuscleCurves = !!i819[9]
  var i825 = i819[10]
  var i824 = []
  for(var i = 0; i < i825.length; i += 1) {
    i824.push( i825[i + 0] );
  }
  i818.clipMuscleConstant = i824
  i818.clipBindingConstant = request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant', i819[11], i818.clipBindingConstant)
  return i818
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve"] = function (request, data, root) {
  var i828 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve' )
  var i829 = data
  i828.path = i829[0]
  i828.hash = i829[1]
  i828.componentType = i829[2]
  i828.property = i829[3]
  i828.keys = i829[4]
  var i831 = i829[5]
  var i830 = []
  for(var i = 0; i < i831.length; i += 1) {
    i830.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey', i831[i + 0]) );
  }
  i828.objectReferenceKeys = i830
  return i828
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey"] = function (request, data, root) {
  var i834 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey' )
  var i835 = data
  i834.time = i835[0]
  request.r(i835[1], i835[2], 0, i834, 'value')
  return i834
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent"] = function (request, data, root) {
  var i838 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent' )
  var i839 = data
  i838.functionName = i839[0]
  i838.floatParameter = i839[1]
  i838.intParameter = i839[2]
  i838.stringParameter = i839[3]
  request.r(i839[4], i839[5], 0, i838, 'objectReferenceParameter')
  i838.time = i839[6]
  return i838
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds"] = function (request, data, root) {
  var i840 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds' )
  var i841 = data
  i840.center = new pc.Vec3( i841[0], i841[1], i841[2] )
  i840.extends = new pc.Vec3( i841[3], i841[4], i841[5] )
  return i840
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant"] = function (request, data, root) {
  var i844 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant' )
  var i845 = data
  var i847 = i845[0]
  var i846 = []
  for(var i = 0; i < i847.length; i += 1) {
    i846.push( i847[i + 0] );
  }
  i844.genericBindings = i846
  var i849 = i845[1]
  var i848 = []
  for(var i = 0; i < i849.length; i += 1) {
    i848.push( i849[i + 0] );
  }
  i844.pptrCurveMapping = i848
  return i844
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font"] = function (request, data, root) {
  var i850 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font' )
  var i851 = data
  i850.name = i851[0]
  i850.ascent = i851[1]
  i850.originalLineHeight = i851[2]
  i850.fontSize = i851[3]
  var i853 = i851[4]
  var i852 = []
  for(var i = 0; i < i853.length; i += 1) {
    i852.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo', i853[i + 0]) );
  }
  i850.characterInfo = i852
  request.r(i851[5], i851[6], 0, i850, 'texture')
  i850.originalFontSize = i851[7]
  return i850
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo"] = function (request, data, root) {
  var i856 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo' )
  var i857 = data
  i856.index = i857[0]
  i856.advance = i857[1]
  i856.bearing = i857[2]
  i856.glyphWidth = i857[3]
  i856.glyphHeight = i857[4]
  i856.minX = i857[5]
  i856.maxX = i857[6]
  i856.minY = i857[7]
  i856.maxY = i857[8]
  i856.uvBottomLeftX = i857[9]
  i856.uvBottomLeftY = i857[10]
  i856.uvBottomRightX = i857[11]
  i856.uvBottomRightY = i857[12]
  i856.uvTopLeftX = i857[13]
  i856.uvTopLeftY = i857[14]
  i856.uvTopRightX = i857[15]
  i856.uvTopRightY = i857[16]
  return i856
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController"] = function (request, data, root) {
  var i858 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController' )
  var i859 = data
  i858.name = i859[0]
  var i861 = i859[1]
  var i860 = []
  for(var i = 0; i < i861.length; i += 1) {
    i860.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer', i861[i + 0]) );
  }
  i858.layers = i860
  var i863 = i859[2]
  var i862 = []
  for(var i = 0; i < i863.length; i += 1) {
    i862.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter', i863[i + 0]) );
  }
  i858.parameters = i862
  i858.animationClips = i859[3]
  i858.avatarUnsupported = i859[4]
  return i858
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer"] = function (request, data, root) {
  var i866 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer' )
  var i867 = data
  i866.name = i867[0]
  i866.defaultWeight = i867[1]
  i866.blendingMode = i867[2]
  i866.avatarMask = i867[3]
  i866.syncedLayerIndex = i867[4]
  i866.syncedLayerAffectsTiming = !!i867[5]
  i866.syncedLayers = i867[6]
  i866.stateMachine = request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine', i867[7], i866.stateMachine)
  return i866
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine"] = function (request, data, root) {
  var i868 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine' )
  var i869 = data
  i868.id = i869[0]
  i868.name = i869[1]
  i868.path = i869[2]
  var i871 = i869[3]
  var i870 = []
  for(var i = 0; i < i871.length; i += 1) {
    i870.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState', i871[i + 0]) );
  }
  i868.states = i870
  var i873 = i869[4]
  var i872 = []
  for(var i = 0; i < i873.length; i += 1) {
    i872.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine', i873[i + 0]) );
  }
  i868.machines = i872
  var i875 = i869[5]
  var i874 = []
  for(var i = 0; i < i875.length; i += 1) {
    i874.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition', i875[i + 0]) );
  }
  i868.entryStateTransitions = i874
  var i877 = i869[6]
  var i876 = []
  for(var i = 0; i < i877.length; i += 1) {
    i876.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition', i877[i + 0]) );
  }
  i868.exitStateTransitions = i876
  var i879 = i869[7]
  var i878 = []
  for(var i = 0; i < i879.length; i += 1) {
    i878.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition', i879[i + 0]) );
  }
  i868.anyStateTransitions = i878
  i868.defaultStateId = i869[8]
  return i868
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState"] = function (request, data, root) {
  var i882 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState' )
  var i883 = data
  i882.id = i883[0]
  i882.name = i883[1]
  i882.cycleOffset = i883[2]
  i882.cycleOffsetParameter = i883[3]
  i882.cycleOffsetParameterActive = !!i883[4]
  i882.mirror = !!i883[5]
  i882.mirrorParameter = i883[6]
  i882.mirrorParameterActive = !!i883[7]
  i882.motionId = i883[8]
  i882.nameHash = i883[9]
  i882.fullPathHash = i883[10]
  i882.speed = i883[11]
  i882.speedParameter = i883[12]
  i882.speedParameterActive = !!i883[13]
  i882.tag = i883[14]
  i882.tagHash = i883[15]
  i882.writeDefaultValues = !!i883[16]
  var i885 = i883[17]
  var i884 = []
  for(var i = 0; i < i885.length; i += 2) {
  request.r(i885[i + 0], i885[i + 1], 2, i884, '')
  }
  i882.behaviours = i884
  var i887 = i883[18]
  var i886 = []
  for(var i = 0; i < i887.length; i += 1) {
    i886.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition', i887[i + 0]) );
  }
  i882.transitions = i886
  return i882
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition"] = function (request, data, root) {
  var i892 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition' )
  var i893 = data
  i892.fullPath = i893[0]
  i892.canTransitionToSelf = !!i893[1]
  i892.duration = i893[2]
  i892.exitTime = i893[3]
  i892.hasExitTime = !!i893[4]
  i892.hasFixedDuration = !!i893[5]
  i892.interruptionSource = i893[6]
  i892.offset = i893[7]
  i892.orderedInterruption = !!i893[8]
  i892.destinationStateId = i893[9]
  i892.isExit = !!i893[10]
  i892.mute = !!i893[11]
  i892.solo = !!i893[12]
  var i895 = i893[13]
  var i894 = []
  for(var i = 0; i < i895.length; i += 1) {
    i894.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition', i895[i + 0]) );
  }
  i892.conditions = i894
  return i892
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition"] = function (request, data, root) {
  var i900 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition' )
  var i901 = data
  i900.destinationStateId = i901[0]
  i900.isExit = !!i901[1]
  i900.mute = !!i901[2]
  i900.solo = !!i901[3]
  var i903 = i901[4]
  var i902 = []
  for(var i = 0; i < i903.length; i += 1) {
    i902.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition', i903[i + 0]) );
  }
  i900.conditions = i902
  return i900
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition"] = function (request, data, root) {
  var i906 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition' )
  var i907 = data
  i906.mode = i907[0]
  i906.parameter = i907[1]
  i906.threshold = i907[2]
  return i906
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter"] = function (request, data, root) {
  var i910 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter' )
  var i911 = data
  i910.defaultBool = !!i911[0]
  i910.defaultFloat = i911[1]
  i910.defaultInt = i911[2]
  i910.name = i911[3]
  i910.nameHash = i911[4]
  i910.type = i911[5]
  return i910
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorOverrideController"] = function (request, data, root) {
  var i912 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorOverrideController' )
  var i913 = data
  i912.name = i913[0]
  request.r(i913[1], i913[2], 0, i912, '_runtimeAnimatorController')
  var i915 = i913[3]
  var i914 = []
  for(var i = 0; i < i915.length; i += 2) {
  request.r(i915[i + 0], i915[i + 1], 2, i914, '')
  }
  i912._originalAnimationClips = i914
  var i917 = i913[4]
  var i916 = []
  for(var i = 0; i < i917.length; i += 2) {
  request.r(i917[i + 0], i917[i + 1], 2, i916, '')
  }
  i912._overrideAnimationClips = i916
  var i919 = i913[5]
  var i918 = []
  for(var i = 0; i < i919.length; i += 2) {
  request.r(i919[i + 0], i919[i + 1], 2, i918, '')
  }
  i912._animationClips = i918
  var i921 = i913[6]
  var i920 = []
  for(var i = 0; i < i921.length; i += 1) {
    i920.push( request.d('UnityEngine.AnimationClipPair', i921[i + 0]) );
  }
  i912._animationClipPairs = i920
  return i912
}

Deserializers["UnityEngine.AnimationClipPair"] = function (request, data, root) {
  var i926 = root || request.c( 'UnityEngine.AnimationClipPair' )
  var i927 = data
  request.r(i927[0], i927[1], 0, i926, 'originalClip')
  request.r(i927[2], i927[3], 0, i926, 'overrideClip')
  return i926
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.TextAsset"] = function (request, data, root) {
  var i928 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.TextAsset' )
  var i929 = data
  i928.name = i929[0]
  i928.bytes64 = i929[1]
  i928.data = i929[2]
  return i928
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.SpriteAtlas"] = function (request, data, root) {
  var i930 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.SpriteAtlas' )
  var i931 = data
  var i933 = i931[0]
  var i932 = []
  for(var i = 0; i < i933.length; i += 2) {
  request.r(i933[i + 0], i933[i + 1], 2, i932, '')
  }
  i930.sprites = i932
  i930.name = i931[1]
  i930.isVariant = !!i931[2]
  i930.tag = i931[3]
  return i930
}

Deserializers["AnimateSliderConfigSO"] = function (request, data, root) {
  var i936 = root || request.c( 'AnimateSliderConfigSO' )
  var i937 = data
  i936.moveDuration = i937[0]
  i936.moveRewardDuration = i937[1]
  i936.scaleRewardDuration = i937[2]
  i936.rotateRewardDuration = i937[3]
  i936.rotateRewardStartTime = i937[4]
  i936.rewardRotateCycle = i937[5]
  i936.scaleRewardValue = i937[6]
  i936.moveCurve = new pc.AnimationCurve( { keys_flow: i937[7] } )
  i936.rewardMoveCurve = new pc.AnimationCurve( { keys_flow: i937[8] } )
  i936.rewardScaleCurve = new pc.AnimationCurve( { keys_flow: i937[9] } )
  i936.rewardRotateCurve = new pc.AnimationCurve( { keys_flow: i937[10] } )
  return i936
}

Deserializers["TMPro.TMP_FontAsset"] = function (request, data, root) {
  var i938 = root || request.c( 'TMPro.TMP_FontAsset' )
  var i939 = data
  request.r(i939[0], i939[1], 0, i938, 'atlas')
  i938.normalStyle = i939[2]
  i938.normalSpacingOffset = i939[3]
  i938.boldStyle = i939[4]
  i938.boldSpacing = i939[5]
  i938.italicStyle = i939[6]
  i938.tabSize = i939[7]
  i938.hashCode = i939[8]
  request.r(i939[9], i939[10], 0, i938, 'material')
  i938.materialHashCode = i939[11]
  i938.m_Version = i939[12]
  i938.m_SourceFontFileGUID = i939[13]
  request.r(i939[14], i939[15], 0, i938, 'm_SourceFontFile_EditorRef')
  request.r(i939[16], i939[17], 0, i938, 'm_SourceFontFile')
  i938.m_AtlasPopulationMode = i939[18]
  i938.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i939[19], i938.m_FaceInfo)
  var i941 = i939[20]
  var i940 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.Glyph')))
  for(var i = 0; i < i941.length; i += 1) {
    i940.add(request.d('UnityEngine.TextCore.Glyph', i941[i + 0]));
  }
  i938.m_GlyphTable = i940
  var i943 = i939[21]
  var i942 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Character')))
  for(var i = 0; i < i943.length; i += 1) {
    i942.add(request.d('TMPro.TMP_Character', i943[i + 0]));
  }
  i938.m_CharacterTable = i942
  var i945 = i939[22]
  var i944 = []
  for(var i = 0; i < i945.length; i += 2) {
  request.r(i945[i + 0], i945[i + 1], 2, i944, '')
  }
  i938.m_AtlasTextures = i944
  i938.m_AtlasTextureIndex = i939[23]
  i938.m_IsMultiAtlasTexturesEnabled = !!i939[24]
  i938.m_ClearDynamicDataOnBuild = !!i939[25]
  var i947 = i939[26]
  var i946 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i947.length; i += 1) {
    i946.add(request.d('UnityEngine.TextCore.GlyphRect', i947[i + 0]));
  }
  i938.m_UsedGlyphRects = i946
  var i949 = i939[27]
  var i948 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i949.length; i += 1) {
    i948.add(request.d('UnityEngine.TextCore.GlyphRect', i949[i + 0]));
  }
  i938.m_FreeGlyphRects = i948
  i938.m_fontInfo = request.d('TMPro.FaceInfo_Legacy', i939[28], i938.m_fontInfo)
  i938.m_AtlasWidth = i939[29]
  i938.m_AtlasHeight = i939[30]
  i938.m_AtlasPadding = i939[31]
  i938.m_AtlasRenderMode = i939[32]
  var i951 = i939[33]
  var i950 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Glyph')))
  for(var i = 0; i < i951.length; i += 1) {
    i950.add(request.d('TMPro.TMP_Glyph', i951[i + 0]));
  }
  i938.m_glyphInfoList = i950
  i938.m_KerningTable = request.d('TMPro.KerningTable', i939[34], i938.m_KerningTable)
  i938.m_FontFeatureTable = request.d('TMPro.TMP_FontFeatureTable', i939[35], i938.m_FontFeatureTable)
  var i953 = i939[36]
  var i952 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i953.length; i += 2) {
  request.r(i953[i + 0], i953[i + 1], 1, i952, '')
  }
  i938.fallbackFontAssets = i952
  var i955 = i939[37]
  var i954 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i955.length; i += 2) {
  request.r(i955[i + 0], i955[i + 1], 1, i954, '')
  }
  i938.m_FallbackFontAssetTable = i954
  i938.m_CreationSettings = request.d('TMPro.FontAssetCreationSettings', i939[38], i938.m_CreationSettings)
  var i957 = i939[39]
  var i956 = []
  for(var i = 0; i < i957.length; i += 1) {
    i956.push( request.d('TMPro.TMP_FontWeightPair', i957[i + 0]) );
  }
  i938.m_FontWeightTable = i956
  var i959 = i939[40]
  var i958 = []
  for(var i = 0; i < i959.length; i += 1) {
    i958.push( request.d('TMPro.TMP_FontWeightPair', i959[i + 0]) );
  }
  i938.fontWeights = i958
  return i938
}

Deserializers["UnityEngine.TextCore.FaceInfo"] = function (request, data, root) {
  var i960 = root || request.c( 'UnityEngine.TextCore.FaceInfo' )
  var i961 = data
  i960.m_FaceIndex = i961[0]
  i960.m_FamilyName = i961[1]
  i960.m_StyleName = i961[2]
  i960.m_PointSize = i961[3]
  i960.m_Scale = i961[4]
  i960.m_UnitsPerEM = i961[5]
  i960.m_LineHeight = i961[6]
  i960.m_AscentLine = i961[7]
  i960.m_CapLine = i961[8]
  i960.m_MeanLine = i961[9]
  i960.m_Baseline = i961[10]
  i960.m_DescentLine = i961[11]
  i960.m_SuperscriptOffset = i961[12]
  i960.m_SuperscriptSize = i961[13]
  i960.m_SubscriptOffset = i961[14]
  i960.m_SubscriptSize = i961[15]
  i960.m_UnderlineOffset = i961[16]
  i960.m_UnderlineThickness = i961[17]
  i960.m_StrikethroughOffset = i961[18]
  i960.m_StrikethroughThickness = i961[19]
  i960.m_TabWidth = i961[20]
  return i960
}

Deserializers["UnityEngine.TextCore.Glyph"] = function (request, data, root) {
  var i964 = root || request.c( 'UnityEngine.TextCore.Glyph' )
  var i965 = data
  i964.m_Index = i965[0]
  i964.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i965[1], i964.m_Metrics)
  i964.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i965[2], i964.m_GlyphRect)
  i964.m_Scale = i965[3]
  i964.m_AtlasIndex = i965[4]
  i964.m_ClassDefinitionType = i965[5]
  return i964
}

Deserializers["UnityEngine.TextCore.GlyphMetrics"] = function (request, data, root) {
  var i966 = root || request.c( 'UnityEngine.TextCore.GlyphMetrics' )
  var i967 = data
  i966.m_Width = i967[0]
  i966.m_Height = i967[1]
  i966.m_HorizontalBearingX = i967[2]
  i966.m_HorizontalBearingY = i967[3]
  i966.m_HorizontalAdvance = i967[4]
  return i966
}

Deserializers["UnityEngine.TextCore.GlyphRect"] = function (request, data, root) {
  var i968 = root || request.c( 'UnityEngine.TextCore.GlyphRect' )
  var i969 = data
  i968.m_X = i969[0]
  i968.m_Y = i969[1]
  i968.m_Width = i969[2]
  i968.m_Height = i969[3]
  return i968
}

Deserializers["TMPro.TMP_Character"] = function (request, data, root) {
  var i972 = root || request.c( 'TMPro.TMP_Character' )
  var i973 = data
  i972.m_ElementType = i973[0]
  i972.m_Unicode = i973[1]
  i972.m_GlyphIndex = i973[2]
  i972.m_Scale = i973[3]
  return i972
}

Deserializers["TMPro.FaceInfo_Legacy"] = function (request, data, root) {
  var i978 = root || request.c( 'TMPro.FaceInfo_Legacy' )
  var i979 = data
  i978.Name = i979[0]
  i978.PointSize = i979[1]
  i978.Scale = i979[2]
  i978.CharacterCount = i979[3]
  i978.LineHeight = i979[4]
  i978.Baseline = i979[5]
  i978.Ascender = i979[6]
  i978.CapHeight = i979[7]
  i978.Descender = i979[8]
  i978.CenterLine = i979[9]
  i978.SuperscriptOffset = i979[10]
  i978.SubscriptOffset = i979[11]
  i978.SubSize = i979[12]
  i978.Underline = i979[13]
  i978.UnderlineThickness = i979[14]
  i978.strikethrough = i979[15]
  i978.strikethroughThickness = i979[16]
  i978.TabWidth = i979[17]
  i978.Padding = i979[18]
  i978.AtlasWidth = i979[19]
  i978.AtlasHeight = i979[20]
  return i978
}

Deserializers["TMPro.TMP_Glyph"] = function (request, data, root) {
  var i982 = root || request.c( 'TMPro.TMP_Glyph' )
  var i983 = data
  i982.id = i983[0]
  i982.x = i983[1]
  i982.y = i983[2]
  i982.width = i983[3]
  i982.height = i983[4]
  i982.xOffset = i983[5]
  i982.yOffset = i983[6]
  i982.xAdvance = i983[7]
  i982.scale = i983[8]
  return i982
}

Deserializers["TMPro.KerningTable"] = function (request, data, root) {
  var i984 = root || request.c( 'TMPro.KerningTable' )
  var i985 = data
  var i987 = i985[0]
  var i986 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.KerningPair')))
  for(var i = 0; i < i987.length; i += 1) {
    i986.add(request.d('TMPro.KerningPair', i987[i + 0]));
  }
  i984.kerningPairs = i986
  return i984
}

Deserializers["TMPro.KerningPair"] = function (request, data, root) {
  var i990 = root || request.c( 'TMPro.KerningPair' )
  var i991 = data
  i990.xOffset = i991[0]
  i990.m_FirstGlyph = i991[1]
  i990.m_FirstGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i991[2], i990.m_FirstGlyphAdjustments)
  i990.m_SecondGlyph = i991[3]
  i990.m_SecondGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i991[4], i990.m_SecondGlyphAdjustments)
  i990.m_IgnoreSpacingAdjustments = !!i991[5]
  return i990
}

Deserializers["TMPro.TMP_FontFeatureTable"] = function (request, data, root) {
  var i992 = root || request.c( 'TMPro.TMP_FontFeatureTable' )
  var i993 = data
  var i995 = i993[0]
  var i994 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_GlyphPairAdjustmentRecord')))
  for(var i = 0; i < i995.length; i += 1) {
    i994.add(request.d('TMPro.TMP_GlyphPairAdjustmentRecord', i995[i + 0]));
  }
  i992.m_GlyphPairAdjustmentRecords = i994
  return i992
}

Deserializers["TMPro.TMP_GlyphPairAdjustmentRecord"] = function (request, data, root) {
  var i998 = root || request.c( 'TMPro.TMP_GlyphPairAdjustmentRecord' )
  var i999 = data
  i998.m_FirstAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i999[0], i998.m_FirstAdjustmentRecord)
  i998.m_SecondAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i999[1], i998.m_SecondAdjustmentRecord)
  i998.m_FeatureLookupFlags = i999[2]
  return i998
}

Deserializers["TMPro.FontAssetCreationSettings"] = function (request, data, root) {
  var i1002 = root || request.c( 'TMPro.FontAssetCreationSettings' )
  var i1003 = data
  i1002.sourceFontFileName = i1003[0]
  i1002.sourceFontFileGUID = i1003[1]
  i1002.pointSizeSamplingMode = i1003[2]
  i1002.pointSize = i1003[3]
  i1002.padding = i1003[4]
  i1002.packingMode = i1003[5]
  i1002.atlasWidth = i1003[6]
  i1002.atlasHeight = i1003[7]
  i1002.characterSetSelectionMode = i1003[8]
  i1002.characterSequence = i1003[9]
  i1002.referencedFontAssetGUID = i1003[10]
  i1002.referencedTextAssetGUID = i1003[11]
  i1002.fontStyle = i1003[12]
  i1002.fontStyleModifier = i1003[13]
  i1002.renderMode = i1003[14]
  i1002.includeFontFeatures = !!i1003[15]
  return i1002
}

Deserializers["TMPro.TMP_FontWeightPair"] = function (request, data, root) {
  var i1006 = root || request.c( 'TMPro.TMP_FontWeightPair' )
  var i1007 = data
  request.r(i1007[0], i1007[1], 0, i1006, 'regularTypeface')
  request.r(i1007[2], i1007[3], 0, i1006, 'italicTypeface')
  return i1006
}

Deserializers["VPopup.Tween_Animation_Handler.JoinTweenConfig"] = function (request, data, root) {
  var i1008 = root || request.c( 'VPopup.Tween_Animation_Handler.JoinTweenConfig' )
  var i1009 = data
  var i1011 = i1009[0]
  var i1010 = []
  for(var i = 0; i < i1011.length; i += 2) {
  request.r(i1011[i + 0], i1011[i + 1], 2, i1010, '')
  }
  i1008.tweenList = i1010
  i1008.startDelay = i1009[1]
  return i1008
}

Deserializers["VPopup.Tween_Animation_Handler.FadeFromTweenConfig"] = function (request, data, root) {
  var i1014 = root || request.c( 'VPopup.Tween_Animation_Handler.FadeFromTweenConfig' )
  var i1015 = data
  i1014.fadeFrom = i1015[0]
  i1014.startDelay = i1015[1]
  i1014.duration = i1015[2]
  i1014.ease = i1015[3]
  return i1014
}

Deserializers["VPopup.Tween_Animation_Handler.ScaleFromTweenConfig"] = function (request, data, root) {
  var i1016 = root || request.c( 'VPopup.Tween_Animation_Handler.ScaleFromTweenConfig' )
  var i1017 = data
  i1016.scaleFrom = new pc.Vec3( i1017[0], i1017[1], i1017[2] )
  i1016.startDelay = i1017[3]
  i1016.duration = i1017[4]
  i1016.ease = i1017[5]
  return i1016
}

Deserializers["VPopup.Tween_Animation_Handler.MoveFromEdgeTweenConfig"] = function (request, data, root) {
  var i1018 = root || request.c( 'VPopup.Tween_Animation_Handler.MoveFromEdgeTweenConfig' )
  var i1019 = data
  i1018.fromEdge = i1019[0]
  i1018.startDelay = i1019[1]
  i1018.duration = i1019[2]
  i1018.additionalFromOffset = new pc.Vec2( i1019[3], i1019[4] )
  i1018.ease = i1019[5]
  return i1018
}

Deserializers["VPopup.Tween_Animation_Handler.MoveToEdgeTweenConfig"] = function (request, data, root) {
  var i1020 = root || request.c( 'VPopup.Tween_Animation_Handler.MoveToEdgeTweenConfig' )
  var i1021 = data
  i1020.fromEdge = i1021[0]
  i1020.startDelay = i1021[1]
  i1020.duration = i1021[2]
  i1020.additionalFromOffset = new pc.Vec2( i1021[3], i1021[4] )
  i1020.ease = i1021[5]
  return i1020
}

Deserializers["VPopup.Tween_Animation_Handler.ScaleToTweenConfig"] = function (request, data, root) {
  var i1022 = root || request.c( 'VPopup.Tween_Animation_Handler.ScaleToTweenConfig' )
  var i1023 = data
  i1022.scaleTo = new pc.Vec3( i1023[0], i1023[1], i1023[2] )
  i1022.startDelay = i1023[3]
  i1022.duration = i1023[4]
  i1022.ease = i1023[5]
  return i1022
}

Deserializers["VPopup.Tween_Animation_Handler.FadeToTweenConfig"] = function (request, data, root) {
  var i1024 = root || request.c( 'VPopup.Tween_Animation_Handler.FadeToTweenConfig' )
  var i1025 = data
  i1024.fadeTo = i1025[0]
  i1024.startDelay = i1025[1]
  i1024.duration = i1025[2]
  i1024.ease = i1025[3]
  return i1024
}

Deserializers["SOSEventChannel"] = function (request, data, root) {
  var i1026 = root || request.c( 'SOSEventChannel' )
  var i1027 = data
  return i1026
}

Deserializers["DG.Tweening.Core.DOTweenSettings"] = function (request, data, root) {
  var i1028 = root || request.c( 'DG.Tweening.Core.DOTweenSettings' )
  var i1029 = data
  i1028.useSafeMode = !!i1029[0]
  i1028.safeModeOptions = request.d('DG.Tweening.Core.DOTweenSettings+SafeModeOptions', i1029[1], i1028.safeModeOptions)
  i1028.timeScale = i1029[2]
  i1028.unscaledTimeScale = i1029[3]
  i1028.useSmoothDeltaTime = !!i1029[4]
  i1028.maxSmoothUnscaledTime = i1029[5]
  i1028.rewindCallbackMode = i1029[6]
  i1028.showUnityEditorReport = !!i1029[7]
  i1028.logBehaviour = i1029[8]
  i1028.drawGizmos = !!i1029[9]
  i1028.defaultRecyclable = !!i1029[10]
  i1028.defaultAutoPlay = i1029[11]
  i1028.defaultUpdateType = i1029[12]
  i1028.defaultTimeScaleIndependent = !!i1029[13]
  i1028.defaultEaseType = i1029[14]
  i1028.defaultEaseOvershootOrAmplitude = i1029[15]
  i1028.defaultEasePeriod = i1029[16]
  i1028.defaultAutoKill = !!i1029[17]
  i1028.defaultLoopType = i1029[18]
  i1028.debugMode = !!i1029[19]
  i1028.debugStoreTargetId = !!i1029[20]
  i1028.showPreviewPanel = !!i1029[21]
  i1028.storeSettingsLocation = i1029[22]
  i1028.modules = request.d('DG.Tweening.Core.DOTweenSettings+ModulesSetup', i1029[23], i1028.modules)
  i1028.createASMDEF = !!i1029[24]
  i1028.showPlayingTweens = !!i1029[25]
  i1028.showPausedTweens = !!i1029[26]
  return i1028
}

Deserializers["DG.Tweening.Core.DOTweenSettings+SafeModeOptions"] = function (request, data, root) {
  var i1030 = root || request.c( 'DG.Tweening.Core.DOTweenSettings+SafeModeOptions' )
  var i1031 = data
  i1030.logBehaviour = i1031[0]
  i1030.nestedTweenFailureBehaviour = i1031[1]
  return i1030
}

Deserializers["DG.Tweening.Core.DOTweenSettings+ModulesSetup"] = function (request, data, root) {
  var i1032 = root || request.c( 'DG.Tweening.Core.DOTweenSettings+ModulesSetup' )
  var i1033 = data
  i1032.showPanel = !!i1033[0]
  i1032.audioEnabled = !!i1033[1]
  i1032.physicsEnabled = !!i1033[2]
  i1032.physics2DEnabled = !!i1033[3]
  i1032.spriteEnabled = !!i1033[4]
  i1032.uiEnabled = !!i1033[5]
  i1032.textMeshProEnabled = !!i1033[6]
  i1032.tk2DEnabled = !!i1033[7]
  i1032.deAudioEnabled = !!i1033[8]
  i1032.deUnityExtendedEnabled = !!i1033[9]
  i1032.epoOutlineEnabled = !!i1033[10]
  return i1032
}

Deserializers["TMPro.TMP_Settings"] = function (request, data, root) {
  var i1034 = root || request.c( 'TMPro.TMP_Settings' )
  var i1035 = data
  i1034.m_enableWordWrapping = !!i1035[0]
  i1034.m_enableKerning = !!i1035[1]
  i1034.m_enableExtraPadding = !!i1035[2]
  i1034.m_enableTintAllSprites = !!i1035[3]
  i1034.m_enableParseEscapeCharacters = !!i1035[4]
  i1034.m_EnableRaycastTarget = !!i1035[5]
  i1034.m_GetFontFeaturesAtRuntime = !!i1035[6]
  i1034.m_missingGlyphCharacter = i1035[7]
  i1034.m_warningsDisabled = !!i1035[8]
  request.r(i1035[9], i1035[10], 0, i1034, 'm_defaultFontAsset')
  i1034.m_defaultFontAssetPath = i1035[11]
  i1034.m_defaultFontSize = i1035[12]
  i1034.m_defaultAutoSizeMinRatio = i1035[13]
  i1034.m_defaultAutoSizeMaxRatio = i1035[14]
  i1034.m_defaultTextMeshProTextContainerSize = new pc.Vec2( i1035[15], i1035[16] )
  i1034.m_defaultTextMeshProUITextContainerSize = new pc.Vec2( i1035[17], i1035[18] )
  i1034.m_autoSizeTextContainer = !!i1035[19]
  i1034.m_IsTextObjectScaleStatic = !!i1035[20]
  var i1037 = i1035[21]
  var i1036 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i1037.length; i += 2) {
  request.r(i1037[i + 0], i1037[i + 1], 1, i1036, '')
  }
  i1034.m_fallbackFontAssets = i1036
  i1034.m_matchMaterialPreset = !!i1035[22]
  request.r(i1035[23], i1035[24], 0, i1034, 'm_defaultSpriteAsset')
  i1034.m_defaultSpriteAssetPath = i1035[25]
  i1034.m_enableEmojiSupport = !!i1035[26]
  i1034.m_MissingCharacterSpriteUnicode = i1035[27]
  i1034.m_defaultColorGradientPresetsPath = i1035[28]
  request.r(i1035[29], i1035[30], 0, i1034, 'm_defaultStyleSheet')
  i1034.m_StyleSheetsResourcePath = i1035[31]
  request.r(i1035[32], i1035[33], 0, i1034, 'm_leadingCharacters')
  request.r(i1035[34], i1035[35], 0, i1034, 'm_followingCharacters')
  i1034.m_UseModernHangulLineBreakingRules = !!i1035[36]
  return i1034
}

Deserializers["TMPro.TMP_GlyphAdjustmentRecord"] = function (request, data, root) {
  var i1038 = root || request.c( 'TMPro.TMP_GlyphAdjustmentRecord' )
  var i1039 = data
  i1038.m_GlyphIndex = i1039[0]
  i1038.m_GlyphValueRecord = request.d('TMPro.TMP_GlyphValueRecord', i1039[1], i1038.m_GlyphValueRecord)
  return i1038
}

Deserializers["TMPro.TMP_GlyphValueRecord"] = function (request, data, root) {
  var i1040 = root || request.c( 'TMPro.TMP_GlyphValueRecord' )
  var i1041 = data
  i1040.m_XPlacement = i1041[0]
  i1040.m_YPlacement = i1041[1]
  i1040.m_XAdvance = i1041[2]
  i1040.m_YAdvance = i1041[3]
  return i1040
}

Deserializers["TMPro.TMP_SpriteAsset"] = function (request, data, root) {
  var i1042 = root || request.c( 'TMPro.TMP_SpriteAsset' )
  var i1043 = data
  request.r(i1043[0], i1043[1], 0, i1042, 'spriteSheet')
  var i1045 = i1043[2]
  var i1044 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Sprite')))
  for(var i = 0; i < i1045.length; i += 1) {
    i1044.add(request.d('TMPro.TMP_Sprite', i1045[i + 0]));
  }
  i1042.spriteInfoList = i1044
  var i1047 = i1043[3]
  var i1046 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteAsset')))
  for(var i = 0; i < i1047.length; i += 2) {
  request.r(i1047[i + 0], i1047[i + 1], 1, i1046, '')
  }
  i1042.fallbackSpriteAssets = i1046
  i1042.hashCode = i1043[4]
  request.r(i1043[5], i1043[6], 0, i1042, 'material')
  i1042.materialHashCode = i1043[7]
  i1042.m_Version = i1043[8]
  i1042.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i1043[9], i1042.m_FaceInfo)
  var i1049 = i1043[10]
  var i1048 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteCharacter')))
  for(var i = 0; i < i1049.length; i += 1) {
    i1048.add(request.d('TMPro.TMP_SpriteCharacter', i1049[i + 0]));
  }
  i1042.m_SpriteCharacterTable = i1048
  var i1051 = i1043[11]
  var i1050 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteGlyph')))
  for(var i = 0; i < i1051.length; i += 1) {
    i1050.add(request.d('TMPro.TMP_SpriteGlyph', i1051[i + 0]));
  }
  i1042.m_SpriteGlyphTable = i1050
  return i1042
}

Deserializers["TMPro.TMP_Sprite"] = function (request, data, root) {
  var i1054 = root || request.c( 'TMPro.TMP_Sprite' )
  var i1055 = data
  i1054.name = i1055[0]
  i1054.hashCode = i1055[1]
  i1054.unicode = i1055[2]
  i1054.pivot = new pc.Vec2( i1055[3], i1055[4] )
  request.r(i1055[5], i1055[6], 0, i1054, 'sprite')
  i1054.id = i1055[7]
  i1054.x = i1055[8]
  i1054.y = i1055[9]
  i1054.width = i1055[10]
  i1054.height = i1055[11]
  i1054.xOffset = i1055[12]
  i1054.yOffset = i1055[13]
  i1054.xAdvance = i1055[14]
  i1054.scale = i1055[15]
  return i1054
}

Deserializers["TMPro.TMP_SpriteCharacter"] = function (request, data, root) {
  var i1060 = root || request.c( 'TMPro.TMP_SpriteCharacter' )
  var i1061 = data
  i1060.m_Name = i1061[0]
  i1060.m_HashCode = i1061[1]
  i1060.m_ElementType = i1061[2]
  i1060.m_Unicode = i1061[3]
  i1060.m_GlyphIndex = i1061[4]
  i1060.m_Scale = i1061[5]
  return i1060
}

Deserializers["TMPro.TMP_SpriteGlyph"] = function (request, data, root) {
  var i1064 = root || request.c( 'TMPro.TMP_SpriteGlyph' )
  var i1065 = data
  request.r(i1065[0], i1065[1], 0, i1064, 'sprite')
  i1064.m_Index = i1065[2]
  i1064.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i1065[3], i1064.m_Metrics)
  i1064.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i1065[4], i1064.m_GlyphRect)
  i1064.m_Scale = i1065[5]
  i1064.m_AtlasIndex = i1065[6]
  i1064.m_ClassDefinitionType = i1065[7]
  return i1064
}

Deserializers["TMPro.TMP_StyleSheet"] = function (request, data, root) {
  var i1066 = root || request.c( 'TMPro.TMP_StyleSheet' )
  var i1067 = data
  var i1069 = i1067[0]
  var i1068 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Style')))
  for(var i = 0; i < i1069.length; i += 1) {
    i1068.add(request.d('TMPro.TMP_Style', i1069[i + 0]));
  }
  i1066.m_StyleList = i1068
  return i1066
}

Deserializers["TMPro.TMP_Style"] = function (request, data, root) {
  var i1072 = root || request.c( 'TMPro.TMP_Style' )
  var i1073 = data
  i1072.m_Name = i1073[0]
  i1072.m_HashCode = i1073[1]
  i1072.m_OpeningDefinition = i1073[2]
  i1072.m_ClosingDefinition = i1073[3]
  i1072.m_OpeningTagArray = i1073[4]
  i1072.m_ClosingTagArray = i1073[5]
  i1072.m_OpeningTagUnicodeArray = i1073[6]
  i1072.m_ClosingTagUnicodeArray = i1073[7]
  return i1072
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources"] = function (request, data, root) {
  var i1074 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources' )
  var i1075 = data
  var i1077 = i1075[0]
  var i1076 = []
  for(var i = 0; i < i1077.length; i += 1) {
    i1076.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Resources+File', i1077[i + 0]) );
  }
  i1074.files = i1076
  i1074.componentToPrefabIds = i1075[1]
  return i1074
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources+File"] = function (request, data, root) {
  var i1080 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources+File' )
  var i1081 = data
  i1080.path = i1081[0]
  request.r(i1081[1], i1081[2], 0, i1080, 'unityObject')
  return i1080
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings"] = function (request, data, root) {
  var i1082 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings' )
  var i1083 = data
  var i1085 = i1083[0]
  var i1084 = []
  for(var i = 0; i < i1085.length; i += 1) {
    i1084.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder', i1085[i + 0]) );
  }
  i1082.scriptsExecutionOrder = i1084
  var i1087 = i1083[1]
  var i1086 = []
  for(var i = 0; i < i1087.length; i += 1) {
    i1086.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer', i1087[i + 0]) );
  }
  i1082.sortingLayers = i1086
  var i1089 = i1083[2]
  var i1088 = []
  for(var i = 0; i < i1089.length; i += 1) {
    i1088.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer', i1089[i + 0]) );
  }
  i1082.cullingLayers = i1088
  i1082.timeSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings', i1083[3], i1082.timeSettings)
  i1082.physicsSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings', i1083[4], i1082.physicsSettings)
  i1082.physics2DSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings', i1083[5], i1082.physics2DSettings)
  i1082.qualitySettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i1083[6], i1082.qualitySettings)
  i1082.enableRealtimeShadows = !!i1083[7]
  i1082.enableAutoInstancing = !!i1083[8]
  i1082.enableStaticBatching = !!i1083[9]
  i1082.enableDynamicBatching = !!i1083[10]
  i1082.lightmapEncodingQuality = i1083[11]
  i1082.desiredColorSpace = i1083[12]
  var i1091 = i1083[13]
  var i1090 = []
  for(var i = 0; i < i1091.length; i += 1) {
    i1090.push( i1091[i + 0] );
  }
  i1082.allTags = i1090
  return i1082
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder"] = function (request, data, root) {
  var i1094 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder' )
  var i1095 = data
  i1094.name = i1095[0]
  i1094.value = i1095[1]
  return i1094
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer"] = function (request, data, root) {
  var i1098 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer' )
  var i1099 = data
  i1098.id = i1099[0]
  i1098.name = i1099[1]
  i1098.value = i1099[2]
  return i1098
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer"] = function (request, data, root) {
  var i1102 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer' )
  var i1103 = data
  i1102.id = i1103[0]
  i1102.name = i1103[1]
  return i1102
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings"] = function (request, data, root) {
  var i1104 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings' )
  var i1105 = data
  i1104.fixedDeltaTime = i1105[0]
  i1104.maximumDeltaTime = i1105[1]
  i1104.timeScale = i1105[2]
  i1104.maximumParticleTimestep = i1105[3]
  return i1104
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings"] = function (request, data, root) {
  var i1106 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings' )
  var i1107 = data
  i1106.gravity = new pc.Vec3( i1107[0], i1107[1], i1107[2] )
  i1106.defaultSolverIterations = i1107[3]
  i1106.bounceThreshold = i1107[4]
  i1106.autoSyncTransforms = !!i1107[5]
  i1106.autoSimulation = !!i1107[6]
  var i1109 = i1107[7]
  var i1108 = []
  for(var i = 0; i < i1109.length; i += 1) {
    i1108.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask', i1109[i + 0]) );
  }
  i1106.collisionMatrix = i1108
  return i1106
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask"] = function (request, data, root) {
  var i1112 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask' )
  var i1113 = data
  i1112.enabled = !!i1113[0]
  i1112.layerId = i1113[1]
  i1112.otherLayerId = i1113[2]
  return i1112
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings"] = function (request, data, root) {
  var i1114 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings' )
  var i1115 = data
  request.r(i1115[0], i1115[1], 0, i1114, 'material')
  i1114.gravity = new pc.Vec2( i1115[2], i1115[3] )
  i1114.positionIterations = i1115[4]
  i1114.velocityIterations = i1115[5]
  i1114.velocityThreshold = i1115[6]
  i1114.maxLinearCorrection = i1115[7]
  i1114.maxAngularCorrection = i1115[8]
  i1114.maxTranslationSpeed = i1115[9]
  i1114.maxRotationSpeed = i1115[10]
  i1114.baumgarteScale = i1115[11]
  i1114.baumgarteTOIScale = i1115[12]
  i1114.timeToSleep = i1115[13]
  i1114.linearSleepTolerance = i1115[14]
  i1114.angularSleepTolerance = i1115[15]
  i1114.defaultContactOffset = i1115[16]
  i1114.autoSimulation = !!i1115[17]
  i1114.queriesHitTriggers = !!i1115[18]
  i1114.queriesStartInColliders = !!i1115[19]
  i1114.callbacksOnDisable = !!i1115[20]
  i1114.reuseCollisionCallbacks = !!i1115[21]
  i1114.autoSyncTransforms = !!i1115[22]
  var i1117 = i1115[23]
  var i1116 = []
  for(var i = 0; i < i1117.length; i += 1) {
    i1116.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask', i1117[i + 0]) );
  }
  i1114.collisionMatrix = i1116
  return i1114
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask"] = function (request, data, root) {
  var i1120 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask' )
  var i1121 = data
  i1120.enabled = !!i1121[0]
  i1120.layerId = i1121[1]
  i1120.otherLayerId = i1121[2]
  return i1120
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.QualitySettings"] = function (request, data, root) {
  var i1122 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.QualitySettings' )
  var i1123 = data
  var i1125 = i1123[0]
  var i1124 = []
  for(var i = 0; i < i1125.length; i += 1) {
    i1124.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i1125[i + 0]) );
  }
  i1122.qualityLevels = i1124
  var i1127 = i1123[1]
  var i1126 = []
  for(var i = 0; i < i1127.length; i += 1) {
    i1126.push( i1127[i + 0] );
  }
  i1122.names = i1126
  i1122.shadows = i1123[2]
  i1122.anisotropicFiltering = i1123[3]
  i1122.antiAliasing = i1123[4]
  i1122.lodBias = i1123[5]
  i1122.shadowCascades = i1123[6]
  i1122.shadowDistance = i1123[7]
  i1122.shadowmaskMode = i1123[8]
  i1122.shadowProjection = i1123[9]
  i1122.shadowResolution = i1123[10]
  i1122.softParticles = !!i1123[11]
  i1122.softVegetation = !!i1123[12]
  i1122.activeColorSpace = i1123[13]
  i1122.desiredColorSpace = i1123[14]
  i1122.masterTextureLimit = i1123[15]
  i1122.maxQueuedFrames = i1123[16]
  i1122.particleRaycastBudget = i1123[17]
  i1122.pixelLightCount = i1123[18]
  i1122.realtimeReflectionProbes = !!i1123[19]
  i1122.shadowCascade2Split = i1123[20]
  i1122.shadowCascade4Split = new pc.Vec3( i1123[21], i1123[22], i1123[23] )
  i1122.streamingMipmapsActive = !!i1123[24]
  i1122.vSyncCount = i1123[25]
  i1122.asyncUploadBufferSize = i1123[26]
  i1122.asyncUploadTimeSlice = i1123[27]
  i1122.billboardsFaceCameraPosition = !!i1123[28]
  i1122.shadowNearPlaneOffset = i1123[29]
  i1122.streamingMipmapsMemoryBudget = i1123[30]
  i1122.maximumLODLevel = i1123[31]
  i1122.streamingMipmapsAddAllCameras = !!i1123[32]
  i1122.streamingMipmapsMaxLevelReduction = i1123[33]
  i1122.streamingMipmapsRenderersPerFrame = i1123[34]
  i1122.resolutionScalingFixedDPIFactor = i1123[35]
  i1122.streamingMipmapsMaxFileIORequests = i1123[36]
  i1122.currentQualityLevel = i1123[37]
  return i1122
}

Deserializers["TMPro.GlyphValueRecord_Legacy"] = function (request, data, root) {
  var i1130 = root || request.c( 'TMPro.GlyphValueRecord_Legacy' )
  var i1131 = data
  i1130.xPlacement = i1131[0]
  i1130.yPlacement = i1131[1]
  i1130.xAdvance = i1131[2]
  i1130.yAdvance = i1131[3]
  return i1130
}

Deserializers.fields = {"Luna.Unity.DTO.UnityEngine.Components.RectTransform":{"pivot":0,"anchorMin":2,"anchorMax":4,"sizeDelta":6,"anchoredPosition3D":8,"rotation":11,"scale":15},"Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer":{"cullTransparentMesh":0},"Luna.Unity.DTO.UnityEngine.Scene.GameObject":{"name":0,"tagId":1,"enabled":2,"isStatic":3,"layer":4},"Luna.Unity.DTO.UnityEngine.Textures.Texture2D":{"name":0,"width":1,"height":2,"mipmapCount":3,"anisoLevel":4,"filterMode":5,"hdr":6,"format":7,"wrapMode":8,"alphaIsTransparency":9,"alphaSource":10,"graphicsFormat":11,"sRGBTexture":12,"desiredColorSpace":13,"wrapU":14,"wrapV":15},"Luna.Unity.DTO.UnityEngine.Components.Animator":{"animatorController":0,"avatar":2,"updateMode":4,"hasTransformHierarchy":5,"applyRootMotion":6,"humanBones":7,"enabled":8},"Luna.Unity.DTO.UnityEngine.Assets.Material":{"name":0,"shader":1,"renderQueue":3,"enableInstancing":4,"floatParameters":5,"colorParameters":6,"vectorParameters":7,"textureParameters":8,"materialFlags":9},"Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag":{"name":0,"enabled":1},"Luna.Unity.DTO.UnityEngine.Scene.Scene":{"name":0,"index":1,"startup":2},"Luna.Unity.DTO.UnityEngine.Components.Camera":{"aspect":0,"orthographic":1,"orthographicSize":2,"backgroundColor":3,"nearClipPlane":7,"farClipPlane":8,"fieldOfView":9,"depth":10,"clearFlags":11,"cullingMask":12,"rect":13,"targetTexture":14,"usePhysicalProperties":16,"focalLength":17,"sensorSize":18,"lensShift":20,"gateFit":22,"commandBufferCount":23,"cameraType":24,"enabled":25},"Luna.Unity.DTO.UnityEngine.Components.Canvas":{"planeDistance":0,"referencePixelsPerUnit":1,"isFallbackOverlay":2,"renderMode":3,"renderOrder":4,"sortingLayerName":5,"sortingOrder":6,"scaleFactor":7,"worldCamera":8,"overrideSorting":10,"pixelPerfect":11,"targetDisplay":12,"overridePixelPerfect":13,"enabled":14},"Luna.Unity.DTO.UnityEngine.Components.CanvasGroup":{"m_Alpha":0,"m_Interactable":1,"m_BlocksRaycasts":2,"m_IgnoreParentGroups":3,"enabled":4},"Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer":{"color":0,"sprite":4,"flipX":6,"flipY":7,"drawMode":8,"size":9,"tileMode":11,"adaptiveModeThreshold":12,"maskInteraction":13,"spriteSortPoint":14,"enabled":15,"sharedMaterial":16,"sharedMaterials":18,"receiveShadows":19,"shadowCastingMode":20,"sortingLayerID":21,"sortingOrder":22,"lightmapIndex":23,"lightmapSceneIndex":24,"lightmapScaleOffset":25,"lightProbeUsage":29,"reflectionProbeUsage":30},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings":{"ambientIntensity":0,"reflectionIntensity":1,"ambientMode":2,"ambientLight":3,"ambientSkyColor":7,"ambientGroundColor":11,"ambientEquatorColor":15,"fogColor":19,"fogEndDistance":23,"fogStartDistance":24,"fogDensity":25,"fog":26,"skybox":27,"fogMode":29,"lightmaps":30,"lightProbes":31,"lightmapsMode":32,"mixedBakeMode":33,"environmentLightingMode":34,"ambientProbe":35,"referenceAmbientProbe":36,"useReferenceAmbientProbe":37,"customReflection":38,"defaultReflection":40,"defaultReflectionMode":42,"defaultReflectionResolution":43,"sunLightObjectId":44,"pixelLightCount":45,"defaultReflectionHDR":46,"hasLightDataAsset":47,"hasManualGenerate":48},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap":{"lightmapColor":0,"lightmapDirection":2},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes":{"bakedProbes":0,"positions":1,"hullRays":2,"tetrahedra":3,"neighbours":4,"matrices":5},"Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset":{"AdditionalLightsPerObjectLimit":0,"AdditionalLightsRenderingMode":1,"LightRenderingMode":2,"ColorGradingLutSize":3,"ColorGradingMode":4,"MainLightRenderingMode":5,"MainLightRenderingModeValue":6,"SupportsMainLightShadows":7,"MixedLightingSupported":8,"MsaaQuality":9,"MSAA":10,"OpaqueDownsampling":11,"MainLightShadowmapResolution":12,"MainLightShadowmapResolutionValue":13,"SupportsSoftShadows":14,"SoftShadowQuality":15,"SoftShadowQualityValue":16,"ShadowDistance":17,"ShadowCascadeCount":18,"Cascade2Split":19,"Cascade3Split":20,"Cascade4Split":22,"CascadeBorder":25,"ShadowDepthBias":26,"ShadowNormalBias":27,"RenderScale":28,"RequireDepthTexture":29,"RequireOpaqueTexture":30,"SupportsHDR":31,"SupportsTerrainHoles":32},"Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode":{"Disabled":0,"PerVertex":1,"PerPixel":2},"Luna.Unity.DTO.UnityEngine.Assets.ColorGradingMode":{"LowDynamicRange":0,"HighDynamicRange":1},"Luna.Unity.DTO.UnityEngine.Assets.MsaaQuality":{"Disabled":0,"_2x":1,"_4x":2,"_8x":3},"Luna.Unity.DTO.UnityEngine.Assets.Downsampling":{"None":0,"_2xBilinear":1,"_4xBox":2,"_4xBilinear":3},"Luna.Unity.DTO.UnityEngine.Assets.ShadowResolution":{"_256":0,"_512":1,"_1024":2,"_2048":3,"_4096":4},"Luna.Unity.DTO.UnityEngine.Assets.SoftShadowQuality":{"UsePipelineSettings":0,"Low":1,"Medium":2,"High":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader":{"ShaderCompilationErrors":0,"name":1,"guid":2,"shaderDefinedKeywords":3,"passes":4,"usePasses":5,"defaultParameterValues":6,"unityFallbackShader":7,"readDepth":9,"hasDepthOnlyPass":10,"isCreatedByShaderGraph":11,"disableBatching":12,"compiled":13},"Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError":{"shaderName":0,"errorMessage":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass":{"id":0,"subShaderIndex":1,"name":2,"passType":3,"grabPassTextureName":4,"usePass":5,"zTest":6,"zWrite":7,"culling":8,"blending":9,"alphaBlending":10,"colorWriteMask":11,"offsetUnits":12,"offsetFactor":13,"stencilRef":14,"stencilReadMask":15,"stencilWriteMask":16,"stencilOp":17,"stencilOpFront":18,"stencilOpBack":19,"tags":20,"passDefinedKeywords":21,"passDefinedKeywordGroups":22,"variants":23,"excludedVariants":24,"hasDepthReader":25},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value":{"val":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending":{"src":0,"dst":1,"op":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp":{"pass":0,"fail":1,"zFail":2,"comp":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup":{"keywords":0,"hasDiscard":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant":{"passId":0,"subShaderIndex":1,"keywords":2,"vertexProgram":3,"fragmentProgram":4,"exportedForWebGl2":5,"readDepth":6},"Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass":{"shader":0,"pass":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue":{"name":0,"type":1,"value":2,"textureValue":6,"shaderPropertyFlag":7},"Luna.Unity.DTO.UnityEngine.Textures.Sprite":{"name":0,"texture":1,"aabb":3,"vertices":4,"triangles":5,"textureRect":6,"packedRect":10,"border":14,"transparency":18,"bounds":19,"pixelsPerUnit":20,"textureWidth":21,"textureHeight":22,"nativeSize":23,"pivot":25,"textureRectOffset":27},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip":{"name":0,"wrapMode":1,"isLooping":2,"length":3,"curves":4,"events":5,"halfPrecision":6,"_frameRate":7,"localBounds":8,"hasMuscleCurves":9,"clipMuscleConstant":10,"clipBindingConstant":11},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve":{"path":0,"hash":1,"componentType":2,"property":3,"keys":4,"objectReferenceKeys":5},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey":{"time":0,"value":1},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent":{"functionName":0,"floatParameter":1,"intParameter":2,"stringParameter":3,"objectReferenceParameter":4,"time":6},"Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds":{"center":0,"extends":3},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant":{"genericBindings":0,"pptrCurveMapping":1},"Luna.Unity.DTO.UnityEngine.Assets.Font":{"name":0,"ascent":1,"originalLineHeight":2,"fontSize":3,"characterInfo":4,"texture":5,"originalFontSize":7},"Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo":{"index":0,"advance":1,"bearing":2,"glyphWidth":3,"glyphHeight":4,"minX":5,"maxX":6,"minY":7,"maxY":8,"uvBottomLeftX":9,"uvBottomLeftY":10,"uvBottomRightX":11,"uvBottomRightY":12,"uvTopLeftX":13,"uvTopLeftY":14,"uvTopRightX":15,"uvTopRightY":16},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController":{"name":0,"layers":1,"parameters":2,"animationClips":3,"avatarUnsupported":4},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer":{"name":0,"defaultWeight":1,"blendingMode":2,"avatarMask":3,"syncedLayerIndex":4,"syncedLayerAffectsTiming":5,"syncedLayers":6,"stateMachine":7},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine":{"id":0,"name":1,"path":2,"states":3,"machines":4,"entryStateTransitions":5,"exitStateTransitions":6,"anyStateTransitions":7,"defaultStateId":8},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState":{"id":0,"name":1,"cycleOffset":2,"cycleOffsetParameter":3,"cycleOffsetParameterActive":4,"mirror":5,"mirrorParameter":6,"mirrorParameterActive":7,"motionId":8,"nameHash":9,"fullPathHash":10,"speed":11,"speedParameter":12,"speedParameterActive":13,"tag":14,"tagHash":15,"writeDefaultValues":16,"behaviours":17,"transitions":18},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition":{"fullPath":0,"canTransitionToSelf":1,"duration":2,"exitTime":3,"hasExitTime":4,"hasFixedDuration":5,"interruptionSource":6,"offset":7,"orderedInterruption":8,"destinationStateId":9,"isExit":10,"mute":11,"solo":12,"conditions":13},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition":{"destinationStateId":0,"isExit":1,"mute":2,"solo":3,"conditions":4},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition":{"mode":0,"parameter":1,"threshold":2},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter":{"defaultBool":0,"defaultFloat":1,"defaultInt":2,"name":3,"nameHash":4,"type":5},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorOverrideController":{"name":0,"_runtimeAnimatorController":1,"_originalAnimationClips":3,"_overrideAnimationClips":4,"_animationClips":5,"_animationClipPairs":6},"Luna.Unity.DTO.UnityEngine.Assets.TextAsset":{"name":0,"bytes64":1,"data":2},"Luna.Unity.DTO.UnityEngine.Assets.SpriteAtlas":{"sprites":0,"name":1,"isVariant":2,"tag":3},"Luna.Unity.DTO.UnityEngine.Assets.Resources":{"files":0,"componentToPrefabIds":1},"Luna.Unity.DTO.UnityEngine.Assets.Resources+File":{"path":0,"unityObject":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings":{"scriptsExecutionOrder":0,"sortingLayers":1,"cullingLayers":2,"timeSettings":3,"physicsSettings":4,"physics2DSettings":5,"qualitySettings":6,"enableRealtimeShadows":7,"enableAutoInstancing":8,"enableStaticBatching":9,"enableDynamicBatching":10,"lightmapEncodingQuality":11,"desiredColorSpace":12,"allTags":13},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer":{"id":0,"name":1,"value":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer":{"id":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings":{"fixedDeltaTime":0,"maximumDeltaTime":1,"timeScale":2,"maximumParticleTimestep":3},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings":{"gravity":0,"defaultSolverIterations":3,"bounceThreshold":4,"autoSyncTransforms":5,"autoSimulation":6,"collisionMatrix":7},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings":{"material":0,"gravity":2,"positionIterations":4,"velocityIterations":5,"velocityThreshold":6,"maxLinearCorrection":7,"maxAngularCorrection":8,"maxTranslationSpeed":9,"maxRotationSpeed":10,"baumgarteScale":11,"baumgarteTOIScale":12,"timeToSleep":13,"linearSleepTolerance":14,"angularSleepTolerance":15,"defaultContactOffset":16,"autoSimulation":17,"queriesHitTriggers":18,"queriesStartInColliders":19,"callbacksOnDisable":20,"reuseCollisionCallbacks":21,"autoSyncTransforms":22,"collisionMatrix":23},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.QualitySettings":{"qualityLevels":0,"names":1,"shadows":2,"anisotropicFiltering":3,"antiAliasing":4,"lodBias":5,"shadowCascades":6,"shadowDistance":7,"shadowmaskMode":8,"shadowProjection":9,"shadowResolution":10,"softParticles":11,"softVegetation":12,"activeColorSpace":13,"desiredColorSpace":14,"masterTextureLimit":15,"maxQueuedFrames":16,"particleRaycastBudget":17,"pixelLightCount":18,"realtimeReflectionProbes":19,"shadowCascade2Split":20,"shadowCascade4Split":21,"streamingMipmapsActive":24,"vSyncCount":25,"asyncUploadBufferSize":26,"asyncUploadTimeSlice":27,"billboardsFaceCameraPosition":28,"shadowNearPlaneOffset":29,"streamingMipmapsMemoryBudget":30,"maximumLODLevel":31,"streamingMipmapsAddAllCameras":32,"streamingMipmapsMaxLevelReduction":33,"streamingMipmapsRenderersPerFrame":34,"resolutionScalingFixedDPIFactor":35,"streamingMipmapsMaxFileIORequests":36,"currentQualityLevel":37}}

Deserializers.requiredComponents = {"52":[53],"54":[53],"55":[53],"56":[53],"57":[53],"58":[53],"59":[60],"61":[10],"62":[63],"64":[63],"65":[63],"66":[63],"67":[63],"68":[63],"69":[63],"70":[71],"72":[71],"73":[71],"74":[71],"75":[71],"76":[71],"77":[71],"78":[71],"79":[71],"80":[71],"81":[71],"82":[71],"83":[71],"84":[10],"85":[86],"87":[88],"89":[88],"14":[0],"17":[5],"90":[0],"91":[92],"93":[94],"95":[10],"96":[0],"97":[86,0],"22":[0,1],"98":[0],"99":[1,0],"100":[86],"101":[1,0],"102":[0],"103":[10],"13":[10],"104":[105],"106":[92],"107":[31],"108":[0],"109":[0],"16":[14],"3":[1,0],"110":[0],"15":[14],"111":[0],"112":[0],"113":[0],"114":[0],"115":[0],"116":[0],"117":[0],"118":[0],"119":[0],"120":[1,0],"121":[0],"122":[0],"123":[0],"5":[0],"124":[1,0],"125":[0],"126":[37],"127":[37],"38":[37],"128":[37],"129":[10],"130":[10],"131":[92]}

Deserializers.types = ["UnityEngine.RectTransform","UnityEngine.CanvasRenderer","UnityEngine.EventSystems.UIBehaviour","UnityEngine.UI.Image","UnityEngine.Sprite","UnityEngine.UI.Slider","UnityEngine.Animator","UnityEngine.AnimatorOverrideController","UnityEngine.Shader","UnityEngine.Texture2D","UnityEngine.Camera","UnityEngine.AudioListener","UnityEngine.MonoBehaviour","UnityEngine.Rendering.Universal.UniversalAdditionalCameraData","UnityEngine.Canvas","UnityEngine.UI.CanvasScaler","UnityEngine.UI.GraphicRaycaster","SliderAnimator","AnimateSliderConfigSO","VPopup.VCanvas","UnityEngine.UI.Button","VPopup.VPopup","TMPro.TextMeshProUGUI","TMPro.TMP_FontAsset","UnityEngine.Material","VPopup.Tween_Animation_Handler.PopupTweenAnimationHandler","UnityEngine.CanvasGroup","VPopup.Tween_Animation_Handler.JoinTweenConfig","VPopup.AnimatorPopupAnimationHandler","UnityEditor.Animations.AnimatorController","UnitA","UnityEngine.SpriteRenderer","SOSEventChannel","UnitB","DefaultNamespace.SOSEventChannelListener","UnitC","Game","UnityEngine.EventSystems.EventSystem","UnityEngine.EventSystems.StandaloneInputModule","UnityEngine.AnimationClip","VPopup.Tween_Animation_Handler.FadeFromTweenConfig","VPopup.Tween_Animation_Handler.ScaleFromTweenConfig","VPopup.Tween_Animation_Handler.MoveFromEdgeTweenConfig","VPopup.Tween_Animation_Handler.MoveToEdgeTweenConfig","VPopup.Tween_Animation_Handler.ScaleToTweenConfig","VPopup.Tween_Animation_Handler.FadeToTweenConfig","DG.Tweening.Core.DOTweenSettings","TMPro.TMP_Settings","TMPro.TMP_SpriteAsset","TMPro.TMP_StyleSheet","UnityEngine.TextAsset","UnityEngine.Font","UnityEngine.AudioLowPassFilter","UnityEngine.AudioBehaviour","UnityEngine.AudioHighPassFilter","UnityEngine.AudioReverbFilter","UnityEngine.AudioDistortionFilter","UnityEngine.AudioEchoFilter","UnityEngine.AudioChorusFilter","UnityEngine.Cloth","UnityEngine.SkinnedMeshRenderer","UnityEngine.FlareLayer","UnityEngine.ConstantForce","UnityEngine.Rigidbody","UnityEngine.Joint","UnityEngine.HingeJoint","UnityEngine.SpringJoint","UnityEngine.FixedJoint","UnityEngine.CharacterJoint","UnityEngine.ConfigurableJoint","UnityEngine.CompositeCollider2D","UnityEngine.Rigidbody2D","UnityEngine.Joint2D","UnityEngine.AnchoredJoint2D","UnityEngine.SpringJoint2D","UnityEngine.DistanceJoint2D","UnityEngine.FrictionJoint2D","UnityEngine.HingeJoint2D","UnityEngine.RelativeJoint2D","UnityEngine.SliderJoint2D","UnityEngine.TargetJoint2D","UnityEngine.FixedJoint2D","UnityEngine.WheelJoint2D","UnityEngine.ConstantForce2D","UnityEngine.StreamingController","UnityEngine.TextMesh","UnityEngine.MeshRenderer","UnityEngine.Tilemaps.TilemapRenderer","UnityEngine.Tilemaps.Tilemap","UnityEngine.Tilemaps.TilemapCollider2D","UnityEngine.Rendering.UI.UIFoldout","Unity.VisualScripting.ScriptMachine","Unity.VisualScripting.Variables","UnityEngine.U2D.SpriteShapeController","UnityEngine.U2D.SpriteShapeRenderer","UnityEngine.U2D.PixelPerfectCamera","TMPro.TextContainer","TMPro.TextMeshPro","TMPro.TMP_Dropdown","TMPro.TMP_SelectionCaret","TMPro.TMP_SubMesh","TMPro.TMP_SubMeshUI","TMPro.TMP_Text","UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera","UnityEngine.Rendering.Universal.UniversalAdditionalLightData","UnityEngine.Light","Unity.VisualScripting.SceneVariables","UnityEngine.U2D.Animation.SpriteSkin","UnityEngine.UI.Dropdown","UnityEngine.UI.Graphic","UnityEngine.UI.AspectRatioFitter","UnityEngine.UI.ContentSizeFitter","UnityEngine.UI.GridLayoutGroup","UnityEngine.UI.HorizontalLayoutGroup","UnityEngine.UI.HorizontalOrVerticalLayoutGroup","UnityEngine.UI.LayoutElement","UnityEngine.UI.LayoutGroup","UnityEngine.UI.VerticalLayoutGroup","UnityEngine.UI.Mask","UnityEngine.UI.MaskableGraphic","UnityEngine.UI.RawImage","UnityEngine.UI.RectMask2D","UnityEngine.UI.Scrollbar","UnityEngine.UI.ScrollRect","UnityEngine.UI.Text","UnityEngine.UI.Toggle","UnityEngine.EventSystems.BaseInputModule","UnityEngine.EventSystems.PointerInputModule","UnityEngine.EventSystems.TouchInputModule","UnityEngine.EventSystems.Physics2DRaycaster","UnityEngine.EventSystems.PhysicsRaycaster","Unity.VisualScripting.StateMachine"]

Deserializers.unityVersion = "2022.3.62f3";

Deserializers.productName = "Playable Ads 2D";

Deserializers.lunaInitializationTime = "01/01/2026 04:21:44";

Deserializers.lunaDaysRunning = "3.4";

Deserializers.lunaVersion = "7.0.0";

Deserializers.lunaSHA = "3bcc3e343f23b4c67e768a811a8d088c7f7adbc5";

Deserializers.creativeName = "";

Deserializers.lunaAppID = "35844";

Deserializers.projectId = "619f95f871277aa4cbb7e08521bcb88f";

Deserializers.packagesInfo = "com.unity.render-pipelines.universal: 14.0.12\ncom.unity.textmeshpro: 3.0.7\ncom.unity.ugui: 1.0.0";

Deserializers.externalJsLibraries = "";

Deserializers.androidLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.androidLink?window.$environment.packageConfig.androidLink:'Empty';

Deserializers.iosLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.iosLink?window.$environment.packageConfig.iosLink:'Empty';

Deserializers.base64Enabled = "False";

Deserializers.minifyEnabled = "True";

Deserializers.isForceUncompressed = "False";

Deserializers.isAntiAliasingEnabled = "False";

Deserializers.isRuntimeAnalysisEnabledForCode = "False";

Deserializers.runtimeAnalysisExcludedClassesCount = "1720";

Deserializers.runtimeAnalysisExcludedMethodsCount = "4221";

Deserializers.runtimeAnalysisExcludedModules = "physics3d, physics2d, particle-system";

Deserializers.isRuntimeAnalysisEnabledForShaders = "True";

Deserializers.isRealtimeShadowsEnabled = "False";

Deserializers.isReferenceAmbientProbeBaked = "False";

Deserializers.isLunaCompilerV2Used = "False";

Deserializers.companyName = "DefaultCompany";

Deserializers.buildPlatform = "StandaloneWindows64";

Deserializers.applicationIdentifier = "com.DefaultCompany.Playable-Ads-2D";

Deserializers.disableAntiAliasing = true;

Deserializers.graphicsConstraint = 24;

Deserializers.linearColorSpace = true;

Deserializers.buildID = "7ae8d197-07fc-4959-9505-2147c8c0cd91";

Deserializers.runtimeInitializeOnLoadInfos = [[["UnityEngine","Rendering","DebugUpdater","RuntimeInit"],["UnityEngine","Experimental","Rendering","ScriptableRuntimeReflectionSystemSettings","ScriptingDirtyReflectionSystemInstance"]],[["Unity","VisualScripting","RuntimeVSUsageUtility","RuntimeInitializeOnLoadBeforeSceneLoad"]],[["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"]],[["UnityEngine","Experimental","Rendering","XRSystem","XRSystemInit"]],[]];

Deserializers.typeNameToIdMap = function(){ var i = 0; return Deserializers.types.reduce( function( res, item ) { res[ item ] = i++; return res; }, {} ) }()


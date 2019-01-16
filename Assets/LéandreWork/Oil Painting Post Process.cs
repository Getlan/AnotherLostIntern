﻿using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
 
[Serializable]
[PostProcess(typeof(GrayscaleRenderer), PostProcessEvent.AfterStack, "Custom/Grayscale")]
public sealed class Grayscale : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Grayscale effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.5f };
    [Range(0, 30), Tooltip("Radius.")]
    public IntParameter radius = new IntParameter { value = 5 };
}
 
public sealed class GrayscaleRenderer : PostProcessEffectRenderer<Grayscale>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Grayscale"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetInt("_Radius", settings.radius);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;
 
[Serializable]
[PostProcess(typeof(ASCIIRenderer), PostProcessEvent.AfterStack, "Custom/ASCIIShader")]
public sealed class ASCII : PostProcessEffectSettings {

			//values for the shader
	[Tooltip("ASCII Texture")] public TextureParameter CharTex = new TextureParameter { value = null };
	[Range(10f, 200f), Tooltip("how many characters are displayed horizontally")] public FloatParameter tilesX = new FloatParameter { value = 160f };
	[Range(10f, 200f), Tooltip("how many characters are displayed vertically")] public FloatParameter tilesY = new FloatParameter { value = 50f };
	[Range(0f, 1f), Tooltip("brightness")] public FloatParameter darkness = new FloatParameter { value = .8f };
}

public sealed class ASCIIRenderer : PostProcessEffectRenderer<ASCII>
{
	public override void Render(PostProcessRenderContext context)
	{
		var sheet = context.propertySheets.Get(Shader.Find("Custom/ASCIIShader"));
		sheet.properties.SetTexture("_CharTex", settings.CharTex);
		sheet.properties.SetFloat("_tilesX", settings.tilesX);
		sheet.properties.SetFloat("_tilesY", settings.tilesY);
		sheet.properties.SetFloat("_tileW", 1f / settings.tilesX);
		sheet.properties.SetFloat("_tileH", 1f / settings.tilesY);
		sheet.properties.SetFloat("_darkness", settings.darkness);
		context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
	}
}

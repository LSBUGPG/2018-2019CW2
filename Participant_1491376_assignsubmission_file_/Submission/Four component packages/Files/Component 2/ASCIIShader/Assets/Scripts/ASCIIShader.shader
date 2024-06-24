	Shader "Custom/ASCIIShader"
{
    HLSLINCLUDE

        #include "PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        TEXTURE2D_SAMPLER2D(_CharTex, sampler_CharTex);
        float _tilesX;
        float _tilesY;
        float _tileW;
        float _tileH;
        float _darkness;

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            //float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			half2 uv = half2((int)(i.texcoord.x / _tileW) * _tileW + _tileW / 2, (int)(i.texcoord.y / _tileH) * _tileH + _tileH / 2); //pixelates the screen
			float4 c = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv); //pixelates the screen

			int b = (int)((c.r*2+c.g*5+c.b*1)/_darkness); //brightness //simplified Luminance formula

			float onSpriteX = (i.texcoord.x % _tileW) * _tilesX;
			float onSpriteY = (i.texcoord.y % _tileH) * _tilesY; //old (puts the values upside down) //float onSpriteY = -(i.texcoord.y % _tileH) * _tilesY;

			half2 charCoords = half2((b * 31.0f / 300.0f)+(onSpriteX*31.0f/300.0f), (onSpriteY));
			float4 charMask = SAMPLE_TEXTURE2D(_CharTex, sampler_CharTex, charCoords);
			if(charMask.r == 1.0){
				return c;
			}else{
				//Darken Color relative to tile darkness, offset by 2 so it never equals 0
				c *= (b+2)/10.0f;
				return c;
			}
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}


////Shader "Custom/ASCIIShader" {
//		Properties {
//			_MainTex ("Base", 2D) = "white" {}
//				_CharTex ("Character Map", 2D) = "white" {}
//				_tilesX ("X Characters", Int) = 160
//				_tilesY ("Y Characters", Int) = 50
//				_tileW ("Character Width", Float) = 0.0
//				_tileH ("Character Height", Float) = 0.0
//				_darkness ("Darkness", Float) = 0.0
//		}
//
//		SubShader {
//			Pass{
//				CGPROGRAM
//				#pragma fragment frag
//				#pragma vertex vert_img
//				#pragma target 3.0
//				#include "UnityCG.cginc"
//
//
//				struct v2f {
//					float4 pos : SV_POSITION;
//					float2 uv  : TEXCOORD0;
//				};
//
//				sampler2D _MainTex;
//				sampler2D _CharTex;
//				int _tilesX;
//				int _tilesY;
//				float _tileW;
//				float _tileH;
//				float _darkness;
//
//
//				float4 frag(v2f i) : COLOR{
//					half2 uv = half2((int)(i.uv.x / _tileW) * _tileW + _tileW / 2, (int)(i.uv.y / _tileH) * _tileH + _tileH / 2); //pixelates the screen
//					float4 c = tex2D(_MainTex, uv); //pixelates the screen
//
//					int b = (int)((c.r*2+c.g*5+c.b*1)/_darkness); //brightness //simplified Luminance formula
//
//					float onSpriteX = (i.uv.x % _tileW) * _tilesX; //
//					float onSpriteY = -(i.uv.y % _tileH) * _tilesY; //
//
//					half2 charCoords = half2((b * 31.0f / 300.0f)+(onSpriteX*31.0f/300.0f), (onSpriteY));
//					float4 charMask = tex2D(_CharTex, charCoords);
//					if(charMask.r == 1.0){
//						return c;
//					}else{
//						//Darken Color relative to tile darkness, offset by 2 so it never equals 0
//						c *= (b+2)/10.0f;
//						return c;
//					}
//				}
//				ENDCG
//			}
//		}
//		FallBack off
//	}

﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/GreyScale" 
{
Properties
{
	_MainTex("MainTex", 2D) = "white" {}
	_Color("Tint Color", Color) = (1,1,1,1)
}

SubShader
{
	Tags{ "Queue" = "Transparent" }

	Pass
{
	ZWrite On
	ColorMask 0
}
Blend DstColor SrcColor
BlendOp Add

Pass
{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		sampler2D _MainTex;

	struct v2f {
		float4  pos : SV_POSITION;
		float2  uv : TEXCOORD0;
	};

	float4 _MainTex_ST;

	v2f vert(appdata_base v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		return o;
	}

	half4 frag(v2f i) : COLOR
	{
		half4 texcol = tex2D(_MainTex, i.uv);
		texcol.rgb = dot(texcol.rgb, float3(0.3, 0.59, 0.11));
		return float4(float3(0.3, 0.59, 0.11),1);
	}
		ENDCG
}
}
}
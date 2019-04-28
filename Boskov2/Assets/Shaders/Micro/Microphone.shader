// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/Microphone"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_MicroInput("MicrophoneVolume", Float) = 0
		_IsRed("ISRed", Range(0.0, 1.0)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
			#define PI 3.141592654
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float _MicroInput;
			float _IsRed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			float plot(float uvy, float liney) {
				return smoothstep(uvy - 0.1, uvy, liney) - smoothstep(uvy, uvy + 0.1, liney);
			}


            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

				// Start Micro //
				float centerPoint = i.uv.x / i.uv.y;

				i.uv.y *= 10. ; i.uv.y -= 5.;

				float f = tex2D(_MainTex, float2(i.uv.x, 0.75)).x;
				float a = tex2D(_MainTex, float2(i.uv.x , 0.25) / centerPoint + _MicroInput).x;

				float c = 1. - clamp(1., 10., pow(abs(i.uv.y / (_MicroInput * 100)- sin(10. * PI * (i.uv.x * (_MicroInput * 100) + (_MicroInput * 100)) / f) * sin(a) ), 0.1));
				float xUp = plot(i.uv.y *2, 5.0);
				float xDown = plot(i.uv.y * 2, -5.0);

				float4 Output = float4(float3(xUp + xDown, 2.0 * c, c), 1.0);

				/*if (c < i.uv.y- 2.2 || i.uv.y + 2.5 < c)
				{_IsRed = 1;}
				else
				{_IsRed = 0;}*/

				if (_IsRed == 1)
				{Output = float4(xUp + xDown + c, 0.1 * c, c, 1.0);}
				if (_IsRed == 0)
				{Output = float4(float3(xUp + xDown, 2.0 * c, c), 1.0);}

				return Output;
            }
            ENDCG
        }
    }
}

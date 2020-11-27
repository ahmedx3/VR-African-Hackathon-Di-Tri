Shader "VR-app/CoronaX-Ray"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

		/*_HandContact ("Hand Contact", Vector) = (0.0, 0.0, 0.0, 0.0)
		_HandContactFwd ("Hand Contact forward", Vector) = (0.0, 0.0, 0.0, 0.0)
		_HandContactRight ("Hand Contact right", Vector) = (0.0, 0.0, 0.0, 0.0)*/

		_HandTex("Hand Texture", 2D) = "white" {}
		_UV_Offset("UV Offset", Vector) = (0,0,0,0)
		_UV_Devisor ("UV Devisor", float) = 0.0

		[HDR]_HandColor("Hand Color", Color) = (0,1,0,1)

		_MaxDistance ("Max distance", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _HandTex;

        struct Input
        {
            float2 uv_MainTex;
			float3 worldPos;
			float3 worldNormal;
        };

        half _Glossiness;
        half _Metallic;
		fixed4 _Color;
		fixed4 _HandColor;

		half4 _HandContact[6];
		half4 _HandContactFwd[6];
		half4 _HandContactRight[6];

		half2 _UV_Offset;
		half _UV_Devisor;
		half _MaxDistance;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			/*half distanceToPoint = length(IN.worldPos - _HandContact) / _MaxDistance;
			half distanceToPointClamped = step(distanceToPoint, 1.0f);*/

			for (int i = 0; i < 6; i++) {
				_HandContactFwd[i] = _HandContact[i] + normalize(_HandContactFwd[i] - _HandContact[i]);
				_HandContactRight[i] = _HandContact[i] + normalize(_HandContactRight[i] - _HandContact[i]);

				float crossDataY = (cross(normalize(_HandContact[i] - IN.worldPos), normalize(_HandContactFwd[i] - IN.worldPos)).g);
				float crossDataZ = (cross(normalize(_HandContact[i] - IN.worldPos), normalize(_HandContactRight[i] - IN.worldPos)).g);

				float2 maskedUV = fixed2(crossDataY, crossDataZ) * _UV_Devisor;
				maskedUV.xy += _UV_Offset.xy;

				half mask = step(0.05f, dot(IN.worldNormal, normalize(_HandContact[i] - IN.worldPos)));
				fixed4 textureAlpha = tex2D(_HandTex, maskedUV) * mask;

				c = textureAlpha * _HandColor * textureAlpha.a + (1 - textureAlpha.a) * c;
			}
			//c.rg = maskedUV;

			//c.rgb *= c.a;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
			c.a = 1;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

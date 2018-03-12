// Upgrade NOTE: upgraded instancing buffer 'AmplifyOutline' to new syntax.

Shader "StandardOutline"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_ASEOutlineColor( "Outline Color", Color ) = (1,0.716,0,0)
		_ASEOutlineWidth( "Outline Width", Float ) = 0.06
		_Albedo("Albedo", 2D) = "white" {}
		_AlbedoTint("AlbedoTint", Color) = (0,0,0,0)
		[Normal]_Normal("Normal", 2D) = "white" {}
		_AO("AO", 2D) = "white" {}
		_Metallic("Metallic", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ }
		Cull Front
		CGPROGRAM
		#pragma target 3.0
		#pragma surface outlineSurf Outline keepalpha noshadow noambient novertexlights nolightmap nodynlightmap nodirlightmap nofog nometa noforwardadd vertex:outlineVertexDataFunc
		#pragma multi_compile_instancing
		struct Input
		{
			fixed filler;
		};
		UNITY_INSTANCING_BUFFER_START(AmplifyOutline)
			UNITY_DEFINE_INSTANCED_PROP( fixed4, _ASEOutlineColor )
#define _ASEOutlineColor_arr AmplifyOutline
			UNITY_DEFINE_INSTANCED_PROP(fixed, _ASEOutlineWidth)
#define _ASEOutlineWidth_arr AmplifyOutline
		UNITY_INSTANCING_BUFFER_END(AmplifyOutline)
		void outlineVertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			v.vertex.xyz += ( v.normal * UNITY_ACCESS_INSTANCED_PROP( _ASEOutlineWidth_arr, _ASEOutlineWidth ) );
		}
		inline fixed4 LightingOutline( SurfaceOutput s, half3 lightDir, half atten ) { return fixed4 ( 0,0,0, s.Alpha); }
		void outlineSurf( Input i, inout SurfaceOutput o ) { o.Emission = UNITY_ACCESS_INSTANCED_PROP( _ASEOutlineColor_arr, _ASEOutlineColor ).rgb; o.Alpha = 1; }
		ENDCG
		

		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 5.0
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _Metallic;
		uniform float4 _Metallic_ST;
		uniform sampler2D _AO;
		uniform float4 _AO_ST;

		UNITY_INSTANCING_BUFFER_START(AmplifyOutline)
			UNITY_DEFINE_INSTANCED_PROP(float4, _AlbedoTint)
#define _AlbedoTint_arr AmplifyOutline
		UNITY_INSTANCING_BUFFER_END(AmplifyOutline)

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = tex2D( _Normal, uv_Normal ).rgb;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 _AlbedoTint_Instance = UNITY_ACCESS_INSTANCED_PROP(_AlbedoTint_arr, _AlbedoTint);
			o.Albedo = ( tex2D( _Albedo, uv_Albedo ) * _AlbedoTint_Instance ).rgb;
			float2 uv_Metallic = i.uv_texcoord * _Metallic_ST.xy + _Metallic_ST.zw;
			o.Metallic = tex2D( _Metallic, uv_Metallic ).r;
			float2 uv_AO = i.uv_texcoord * _AO_ST.xy + _AO_ST.zw;
			o.Occlusion = tex2D( _AO, uv_AO ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
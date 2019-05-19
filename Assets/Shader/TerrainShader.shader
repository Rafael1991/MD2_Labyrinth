// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TerrainShader" {
	Properties {
		_bottom_layer ("bottom_layer", 2D) = "white" {}
		_first_layer ("first_layer", 2D) = "white" {}
		_Grass ("second_layer", 2D) = "white" {}

		//_second_layer ("second_layer", 2D) = "white" {}


		_bottom_layerLevel ("bottom_layer Level", Float) = 0
		_LayerSize ("Layer Size", Float) = 20
		_BlendRange ("Blend Range", Range(0, 0.5)) = 0
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
     
            uniform sampler2D _bottom_layer;
            uniform sampler2D _first_layer;
          	uniform sampler2D _second_layer;

            uniform float _bottom_layerLevel;
            uniform float _LayerSize;
            uniform float _BlendRange;

			struct fragmentInput {
				float4 pos : SV_POSITION;
                float4 texcoord : TEXCOORD0;
				float4 blend: COLOR;
			};
      
			fragmentInput vert (appdata_base v)
			{
				float NumOfTextures = 3;
				fragmentInput o;
				o.pos = UnityObjectToClipPos (v.vertex);
                o.texcoord = v.texcoord;

				//  |-----------|--------|--------|------------------|
				//  +   bottom_layer   first_layer   second_layer    0
				//     |--------|--------|--------|--------|
				//     0                                   1

				float MinValue = _bottom_layerLevel - (NumOfTextures - 1) * _LayerSize; 
				float MaxValue = (_bottom_layerLevel + _LayerSize); 
				float Blend = MaxValue - v.vertex.z;
				Blend = clamp(Blend / (NumOfTextures *_LayerSize), 0, 1);

				o.blend.xyz = 0;
				o.blend.w = Blend;
				return o;
			}
			

			inline float CalculateBlend(float TextureFloat)
			{
				return  1 - clamp((1 - TextureFloat) / _BlendRange, 0 , 1);
			}

			inline float4 DoBlending(float TextureID, float TextureFloat, fixed4 BaseTexture, fixed4 BlendTexture)
			{
				float Blend = CalculateBlend(clamp(TextureFloat - TextureID, 0 , 1));
				if (_BlendRange == 0){
					return BaseTexture;
				}else{
					return lerp(BaseTexture, BlendTexture, Blend);
				}
			} 

			float4 frag (fragmentInput i) : COLOR0 
			{ 	
				float NumOfTextures = 3;
				float TextureFloat = i.blend.w * NumOfTextures;

				if(TextureFloat < 1)
				{

					fixed4 bottom_color = tex2D(_bottom_layer, i.texcoord);
					return bottom_color;

				}
				else if(TextureFloat < 2)
				{

					fixed4 first_color = tex2D(_first_layer, i.texcoord);
					return first_color;

				}
				
				fixed4 second_color = tex2D(_second_layer, i.texcoord);

				return second_color;

				fixed4 bottom_color = tex2D(_bottom_layer, i.texcoord);
				fixed4 first_color = tex2D(_first_layer, i.texcoord);

				return lerp(bottom_color, first_color, i.blend.w);

				//return i.texcoord;	
                //return tex2D(_bottom_layer, i.texcoord);
			}
      		ENDCG
    	}
  	} 
	FallBack "Diffuse"
}

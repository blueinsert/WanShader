#version 440 core

uniform vec3 iResolution;
uniform float iTime;
uniform int iFrame;
uniform vec4 iMouse;
uniform vec4 iDate;
uniform float iTimeDelta;
uniform sampler2D iChannel0;
uniform sampler2D iChannel1;
uniform sampler2D iChannel2;
uniform sampler2D iChannel3;

in vec2 pass_fragCoord;
out vec4 out_fragColor;

$passData.Code

void main(void) {
	mainImage(out_fragColor, (pass_fragCoord*iResolution.xy).xy);
}

#version 150 core

out vec4 out_fragColor;
uniform sampler2D iChannel0;
uniform sampler2D iChannel1;

void main(void) {
	out_fragColor = texture(iChannel0,vec2(0.5,0.5));
}
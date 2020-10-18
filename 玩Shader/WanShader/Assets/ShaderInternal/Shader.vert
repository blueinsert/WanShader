#version 440 core

in vec3 in_position;
out vec2 pass_fragCoord;

void main(void) {
	gl_Position = vec4(in_position*2.0, 1.0);//[-0.5,0.5] -> [-1,1]
	pass_fragCoord = in_position.xy + vec2(0.5);//[-0.5,0.5] -> [0,1]
}
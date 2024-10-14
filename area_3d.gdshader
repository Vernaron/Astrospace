shader_type spatial;

float fresnel(float amount, vec3 normal, vec3 view)
{
	return pow((1.0 - clamp(dot(normalize(normal), normalize(view)), 0.0, 1.0 )), amount);
}

void fragment()
{
	float basic_fresnel = fresnel(3.0, NORMAL, VIEW);
	CLEARCOAT_ROUGHNESS = basic_fresnel;
	CLEARCOAT=1.0;
}

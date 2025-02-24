void RectSDF(float2 uv, float2 a, out float color)
{
  float2 q = abs(uv) - a;
  color = length(max(q, 0)) + min(max(q.x, q.y), 0.0);
}
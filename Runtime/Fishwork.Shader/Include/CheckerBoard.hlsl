// 二值棋盘格
void BinaryCheckerBoard_float(float2 uv, float2 scale, out float color)
{
  float2 scaledUV = scale * uv;
  float pattern = fmod(floor(scaledUV.x) + floor(scaledUV.y), 2.0);
  color = pattern;
}

// 可旋转的 二值棋盘格
void BinaryCheckerBoard_float(float2 uv, float2 scale, float angle, out float color)
{
  float rad = radians(angle);
  float cosA = cos(rad);
  float sinA = sin(rad);

  // 以中心 (0.5, 0.5) 为旋转原点
  float2 centeredUV = uv - 0.5;

  // 旋转 UV 坐标
  float2 rotatedUV;
  rotatedUV.x = cosA * centeredUV.x - sinA * centeredUV.y;
  rotatedUV.y = sinA * centeredUV.x + cosA * centeredUV.y;

  // 复原中心
  rotatedUV += 0.5;
  color = rotatedUV;
  
  float2 scaledUV = scale * rotatedUV;
  float pattern = fmod(floor(scaledUV.x) + floor(scaledUV.y), 2.0);
  color = pattern;
}

// 
void CheckerBoard_float(float2 uv, float2 scale, out float color)
{
  float2 scaledUV = scale * uv;
  float pattern = fmod(floor(scaledUV.x) + floor(scaledUV.y), 2.0);
  color = pattern;
}
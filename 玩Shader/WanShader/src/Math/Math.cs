using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bluebean.ShaderToyOffline
{
    public struct Vec2{
        public float x;
        public float y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(float x, float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

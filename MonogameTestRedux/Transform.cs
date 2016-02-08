using System;
using Microsoft.Xna.Framework;

namespace BoltMonoGame
{
	public class Transform
	{
		public Transform parent { get; set; }
        public float x { get; set; }
        public float y { get; set; }

        public Vector2 origin { get; set; } = new Vector2(0, 0);

        public float angle { get; set; }
		public float angleDeg {
			get {
				return MathHelper.ToDegrees(angle);
			}
			set {
				angle = MathHelper.ToRadians(value);
			}
		}
        public float scaleX { get; set; } = 1;
        public float scaleY { get; set; } = 1;

        public Matrix localTransform {
            get
            {
				var mat = 
                	Matrix.CreateScale(scaleX, scaleY, 1) *
					Matrix.CreateFromYawPitchRoll(0, 0, angle) *
					Matrix.CreateTranslation(x, y, 0);

                return mat;
            }
        }

        public Vector2 globalOrigin {
        	get {
				if (parent != null)
                {
					return origin + parent.globalOrigin;
                } else {
                    return origin;
                }
        	}
        }

        public Matrix globalTransform {
            get
            {
                if (parent != null)
                {
					return localTransform * parent.globalTransform;
                } else {
                    return localTransform;
                }
            }
        }

        public Vector2 renderPosition {
        	get {
        		Vector3 scale;
        		Vector3 position;
        		Quaternion rotation;

				globalTransform.Decompose(out scale, out rotation, out position);

				return new Vector2(position.X, position.Y);
        	}
        }

		public Vector2 renderScale {
        	get {
        		Vector3 scale;
        		Vector3 position;
        		Quaternion rotation;
				globalTransform.Decompose(out scale, out rotation, out position);


				return new Vector2(scale.X, scale.Y);;
        	}
        }

		public float renderRotation {
        	get {
        		Vector3 scale;
        		Vector3 position;
        		Quaternion q;
				globalTransform.Decompose(out scale, out q, out position);

				return (float)Math.Atan2(2.0*(q.X*q.Y + q.W*q.Z), q.W*q.W + q.X*q.X - q.Y*q.Y - q.Z*q.Z);
        	}
        }

        public Transform()
        {

        }
	}
}


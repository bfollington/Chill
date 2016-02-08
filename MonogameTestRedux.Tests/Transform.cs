using NUnit.Framework;
using System;
using Chill;

namespace Chill
{
    [TestFixture ()]
    public class TransformTests
    {
        [Test ()]
        public void BasicPositionIsCorrect ()
        {
            var t = new Transform() {
                x = 12,
                y = 16
            };

            Assert.AreEqual(12, t.renderPosition.X);
            Assert.AreEqual(16, t.renderPosition.Y);
        }

        [Test ()]
        public void BasicRotationIsCorrect()
        {
            var t = new Transform() {
                angle = (float)Math.PI / 2
            };

            // Have to round due to rounding in Matrices
            Assert.AreEqual(Math.Round(Math.PI / 2, 4), Math.Round(t.renderRotation, 4));
        }

        [Test ()]
        public void BasicScaleTest() {
            var t = new Transform() {
                scaleX = 2,
                scaleY = 1.5f
            };

            Assert.AreEqual(2, t.renderScale.X);
            Assert.AreEqual(1.5f, t.renderScale.Y);
        }

        [Test ()]
        public void ParentPositionTest() {
            var t = new Transform() {
                x = 12,
                y = 16
            };

            var parent = new Transform() {
                x = 18,
                y = 24
            };

            t.parent = parent;
            Assert.AreEqual(t.x + parent.x, t.renderPosition.X);
            Assert.AreEqual(t.y + parent.y, t.renderPosition.Y);
        }

        [Test ()]
        public void ParentScaleTest() {
            var t = new Transform() {
                scaleX = 2,
                scaleY = 2
            };

            var parent = new Transform() {
                scaleX = 1.5f,
                scaleY = 0.75f
            };

            t.parent = parent;
            Assert.AreEqual(t.scaleX * parent.scaleX, t.renderScale.X);
            Assert.AreEqual(t.scaleY * parent.scaleY, t.renderScale.Y);
        }

        [Test ()]
        public void SimpleParentRotationTest() {
            var t = new Transform() {
                angle = (float)Math.PI / 2
            };

            var parent = new Transform() {
                angle = (float)Math.PI / 2
            };

            t.parent = parent;

            Assert.AreEqual(Math.Round(Math.PI, 4), Math.Round(t.renderRotation, 4));
        }

        [Test ()]
        public void PositionRotationTest() {
            var t = new Transform() {
                x = 0,
                y = 5
            };

            var parent = new Transform() {
                angle = (float)Math.PI / 2
            };

            t.parent = parent;

            Assert.AreEqual(-5, Math.Round(t.renderPosition.X));
            Assert.AreEqual(0, Math.Round(t.renderPosition.Y));
        }

        [Test ()]
        public void OriginPositionRotationTest() {
            var t = new Transform() {
                x = 0,
                y = 5,
                origin = new Microsoft.Xna.Framework.Vector2(32, 32)
            };

            var parent = new Transform() {
                angle = (float)Math.PI / 2
            };

            t.parent = parent;

            Assert.AreEqual(-5, Math.Round(t.renderPosition.X));
            Assert.AreEqual(0, Math.Round(t.renderPosition.Y));
        }

        [Test ()]
        public void CombinedTest() {
            var t = new Transform() {
                x = 0,
                y = 5,
                angle = (float)Math.PI / 2,
                scaleX = 2,
                scaleY = 0.5f,
                origin = new Microsoft.Xna.Framework.Vector2(32, 32)
            };

            var parent = new Transform() {
                angle = (float)Math.PI / 2,
                x = 32,
                y = 64,
                scaleX = 0.5f,
                scaleY = 2,
                origin = new Microsoft.Xna.Framework.Vector2(16, 16)
            };

            t.parent = parent;

            Assert.AreEqual(22, Math.Round(t.renderPosition.X));
            Assert.AreEqual(64, Math.Round(t.renderPosition.Y));
            Assert.AreEqual(Math.Round(Math.PI, 4), Math.Round(t.renderRotation, 4));
            Assert.AreEqual(4, Math.Round(t.renderScale.X));
            Assert.AreEqual(0.25, Math.Round(t.renderScale.Y, 2));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpDX.Direct2D1;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Mathematics.Interop;

namespace Endless_Development_Project_Studio.SharpDXControl
{
    public class Sample2DRenderer : Direct2DComponent
    {
        private Vector2 _position;
        private Vector2 _speed;
        private SolidColorBrush _circleColor;

        public Sample2DRenderer()
        {
            _position = new Vector2(30, 30);
            _speed = new Vector2(5, 2);
        }

        protected override void InternalInitialize()
        {
            base.InternalInitialize();
            
            _circleColor = new SolidColorBrush(RenderTarget2D,Color.Orange);
        }

        protected override void InternalUninitialize()
        {
            Utilities.Dispose(ref _circleColor);

            base.InternalUninitialize();
        }

        protected override void Render()
        {
            UpdatePosition();

           
            RenderTarget2D.Clear(Color.Orange);
            RenderTarget2D.FillEllipse(new Ellipse(_position, 20, 20), _circleColor);
        }

        private void UpdatePosition()
        {
            _position += _speed;

            if (_position.X > SurfaceWidth)
            {
                _position.X = SurfaceWidth;
                _speed.X = -_speed.X;
            }
            else if (_position.X < 0)
            {
                _position.X = 0;
                _speed.X = -_speed.X;
            }

            if (_position.Y > SurfaceHeight)
            {
                _position.Y = SurfaceHeight;
                _speed.Y = -_speed.Y;
            }
            else if (_position.Y < 0)
            {
                _position.Y = 0;
                _speed.Y = -_speed.Y;
            }
        }
    }
}

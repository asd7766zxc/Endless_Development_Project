using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.RenderBackground
{
    /// <summary>
    /// BackgroundContainer.xaml 的互動邏輯
    /// </summary>
    public partial class BackgroundContainer : UserControl
    {
        private readonly ParticleSystemManager _pm;
        private readonly Random _rand;
        private int _currentTick;
        private double _elapsed;
        private int _frameCount;
        private double _frameCountTime;
        private int _frameRate;
        private int _lastTick;
        private Point3D _spawnPoint;
        private double _totalElapsed;

        public BackgroundContainer()
        {
            InitializeComponent();
            var frameTimer = new DispatcherTimer();
            frameTimer.Tick += OnFrame;
            frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 240.0);
            frameTimer.Start();

            _spawnPoint = new Point3D(0.0, 0.0, 0.0);
            _lastTick = Environment.TickCount;

            _pm = new ParticleSystemManager();

              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Kuro)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Karmir)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Kijani)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Ruskea)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Nila)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Zambarau)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Vadali)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Argia)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Ykri)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Ruzova)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Asveste)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Kitrino)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Galazio)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Kurauri)));
              //WorldModels.Children.Add(_pm.CreateParticleSystem(10, ChromaticraftColorGenerator.GetColor(Rune.Portokali)));
              WorldModels.Children.Add(_pm.CreateParticleSystem(1000, ChromaticraftColorGenerator.GetColor(Rune.Tahara)));

            _rand = new Random(GetHashCode());

            KeyDown += Window1_KeyDown;

        }

        private void Window1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void OnFrame(object sender, EventArgs e)
        {
            // Calculate frame time;
            _currentTick = Environment.TickCount;
            _elapsed = (_currentTick - _lastTick) / 1000.0;
            _totalElapsed += _elapsed;
            _lastTick = _currentTick;

            _frameCount++;
            _frameCountTime += _elapsed;
            if (_frameCountTime >= 1.0)
            {
                _frameCountTime -= 1.0;
                _frameRate = _frameCount;
                _frameCount = 0;

            }

            int x = 5;
            _pm.Update((float)_elapsed);
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Kuro), _rand.NextDouble() * x,      10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Karmir), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Kijani), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Ruskea), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Nila), _rand.NextDouble() * x,      10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Zambarau), _rand.NextDouble() * x,  10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Vadali), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Argia), _rand.NextDouble() * x,     10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Ykri), _rand.NextDouble() * x,      10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Ruzova), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Asveste), _rand.NextDouble() * x,   10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Kitrino), _rand.NextDouble() * x,   10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Galazio), _rand.NextDouble() * x,   10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Kurauri), _rand.NextDouble() * x,   10.5 * _rand.NextDouble());
            //_pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Portokali), _rand.NextDouble() * x, 10.5 * _rand.NextDouble());
            _pm.SpawnParticle(_spawnPoint, 50.0, ChromaticraftColorGenerator.GetColor(Rune.Tahara), _rand.NextDouble() * x,    10.5 * _rand.NextDouble());
  
  


            var s = Math.Cos(6.28 * _rand.NextDouble());
            var c = Math.Sin(6.28 * _rand.NextDouble());
            var r = 1f - _rand.NextDouble() * 2f;
            var t = 1f - _rand.NextDouble() * 2f;
            _spawnPoint = new Point3D(c * 100 * r, -75 , 0.0);
        }
    }
}

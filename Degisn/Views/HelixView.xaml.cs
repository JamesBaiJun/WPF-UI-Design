using HelixToolkit.Wpf;
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

namespace Degisn.Views
{
    /// <summary>
    /// HelixView.xaml 的交互逻辑
    /// </summary>
    public partial class HelixView : UserControl
    {
        private readonly ModelVisual3D model;

        public HelixView()
        {
            InitializeComponent();

            model = new ModelVisual3D();

            const int rows = 4;
            const int columns = 5;
            const double distance = 120;

            var turbine = new WindTurbine();
            var r = new Random();
            for (int i = 0; i < rows; i++)
            {
                double y = i * distance;
                for (int j = 0; j + (i % 2) * 0.5 <= columns - 1; j++)
                {
                    double x = (j + (i % 2) * 0.5) * distance;
                    var visual = new WindTurbineVisual3D
                    {
                        RotationAngle = r.Next(360),
                        RotationSpeed = r.Next(5,10),
                        WindTurbine = turbine,
                        Transform = new TranslateTransform3D(x, y, 0)
                    };
                    model.Children.Add(visual);
                }
            }

            var seasurface = new RectangleVisual3D
            {
                DivWidth = 100,
                DivLength = 100,
                Origin = new Point3D((rows - 2) * distance * 0.5, (columns) * distance * 0.5, 0),
                Width = rows * distance * 8,
                Length = columns * distance * 8
            };
            seasurface.Material = seasurface.BackMaterial = MaterialHelper.CreateMaterial((Color)ColorConverter.ConvertFromString("#FF003F5C"), 0.3);

            model.Children.Add(new GridLinesVisual3D() { Center = seasurface.Origin, Fill = Brushes.Gray, Width = seasurface.Width, Length = seasurface.Length });

            model.Children.Add(seasurface);
            view1.Children.Add(model);
            Animation();
        }

        async void Animation()
        {
            await Task.Delay(1000);
            var position = new Point3D(677, 439, 102);
            var lookDirection = new Vector3D(-159, -90, -43);
            var upDirection = new Vector3D(-0.2, -0.1, 0.9);
            camera.AnimateTo(position, lookDirection, upDirection, 3000);
        }
    }
}

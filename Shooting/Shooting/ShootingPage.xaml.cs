using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shooting
{
    /// <summary>
    /// Логика взаимодействия для Shooting.xaml
    /// </summary>
    public partial class ShootingPage : Page
    {
        private int radiusInner;
        private int radiusOuter;

        private int hits = 0;
        private int missed = 0;
        private int leftShots = 5;

        private GeometryGroup shotsMissedGroup = new GeometryGroup();
        private GeometryGroup shotsHitGroup = new GeometryGroup();
        private Path pathTarget;
        private double bulletRadius;
        private const double TargetToBulletRatio = 12;
        

        public ShootingPage(int radiusInner, int radiusOuter)
        {
            InitializeComponent();
            this.radiusInner = radiusInner;
            this.radiusOuter = radiusOuter;
            bulletRadius = (radiusOuter - radiusInner) / TargetToBulletRatio;

            shotsHitGroup.FillRule = FillRule.Nonzero;
            CombinedGeometry combinedGeometry = new CombinedGeometry();
            combinedGeometry.GeometryCombineMode = GeometryCombineMode.Exclude;
            combinedGeometry.Geometry1 = CreateTarget();
            combinedGeometry.Geometry2 = shotsHitGroup;

            pathTarget = new Path();
            pathTarget.Data = combinedGeometry;
            pathTarget.Stroke = new SolidColorBrush(Colors.Red);
            pathTarget.Fill = new SolidColorBrush(Colors.Orange);
            pathTarget.MouseDown += Path_MouseDown;
            
            gridView.Children.Add(pathTarget);                      
            gridView.IsHitTestVisible = true;
            gridView.MinWidth = radiusOuter * MainWindow.minSizeFactor;
            gridView.MinHeight = radiusOuter * MainWindow.minSizeFactor;
            view.MinHeight = radiusOuter * MainWindow.minSizeFactor;
            view.MinWidth = radiusOuter * MainWindow.minSizeFactor;
            

            shotsMissedGroup.FillRule = FillRule.Nonzero;
            pathMissed.Data = shotsMissedGroup;
            pathMissed.Fill = new SolidColorBrush(Colors.Red);

            shotsMissedGroup.Children.Add(new EllipseGeometry(new Point(0, 0), 1, 1)); //Debug
        }

        private void GridView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (leftShots > 0)
            {
                SoundPlayer player = new SoundPlayer(@"Resources/pock.wav");
                player.Load();
                player.Play();
                Point mouse = Mouse.GetPosition(pathMissed);
                EllipseGeometry ellipse = new EllipseGeometry(mouse, bulletRadius, bulletRadius);
                shotsMissedGroup.Children.Add(ellipse);

                lblNumLeft.Content = --leftShots;
                lblNumMissed.Content = ++missed;
            }
            e.Handled = true;
        }

        private void Path_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (leftShots > 0)
            {
                SoundPlayer player = new SoundPlayer(@"Resources/bang.wav");
                player.Load();
                player.Play();
                Point mouse = Mouse.GetPosition(pathTarget);
                EllipseGeometry ellipse = new EllipseGeometry(mouse, bulletRadius, bulletRadius);
                shotsHitGroup.Children.Add(ellipse);

                lblNumLeft.Content = --leftShots;
                lblNumHits.Content = ++hits;
            }
            e.Handled = true;
        }

        private PathGeometry CreateTarget()
        {

            PathGeometry path = new PathGeometry();
            path.FillRule = FillRule.Nonzero;

            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(0, -radiusInner);
            pf.IsClosed = true;
            pf.Segments.Add(new LineSegment(new Point(0, -radiusOuter), true));
            pf.Segments.Add(new ArcSegment(new Point(radiusOuter, 0), new Size(radiusOuter, radiusOuter), 0.0, false, SweepDirection.Clockwise ,true));
            pf.Segments.Add(new LineSegment(new Point(radiusInner, 0), true));
            pf.Segments.Add(new ArcSegment(new Point(0, -radiusInner), new Size(radiusInner, radiusInner), 0.0, false, SweepDirection.Counterclockwise, true));
            path.Figures.Add(pf);

            PathFigure pf2 = new PathFigure();
            pf2.StartPoint = new Point(0, radiusInner);
            pf2.IsClosed = true;
            pf2.Segments.Add(new LineSegment(new Point(0, radiusOuter), true));
            pf2.Segments.Add(new ArcSegment(new Point(-radiusOuter, 0), new Size(radiusOuter, radiusOuter), 0.0, false, SweepDirection.Clockwise, true));
            pf2.Segments.Add(new LineSegment(new Point(-radiusInner, 0), true));
            pf2.Segments.Add(new ArcSegment(new Point(0, radiusInner), new Size(radiusInner, radiusInner), 0.0, false, SweepDirection.Counterclockwise, true));
            path.Figures.Add(pf2);

            return path;
        }

        private void gridView_Loaded(object sender, RoutedEventArgs e)
        {
            pathTarget.RenderTransform = new TranslateTransform(gridView.ActualWidth / 2, gridView.ActualHeight / 2);
            pathMissed.Width = gridView.ActualWidth;
            pathMissed.Height = gridView.ActualHeight;
            
        }
    }
}

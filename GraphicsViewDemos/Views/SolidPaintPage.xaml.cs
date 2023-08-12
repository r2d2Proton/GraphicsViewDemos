namespace GraphicsViewDemos.Views
{
    public partial class SolidPaintPage : ContentPage
    {
        public SolidPaintPage()
        {
            InitializeComponent();
            graphicsView.Invalidate();
        }

        public void OnLoaded(object sender, EventArgs args)
        {
            solidPaintDrawable.SetGraphicsView(graphicsView);
            solidPaintDrawable.StartQuickTimer();
        }

        public void OnUnloaded(object sender, EventArgs args)
        {
            solidPaintDrawable.StopQuickTimer();
        }
    }
}

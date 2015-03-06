using DirectoryScaner.Contracts;

namespace DirectoryScaner.WFUI
{
    public sealed class TreeVisualizer : IVisualizer
    {
        // As interaction with form controls allowed only in form class
        // and in main thread, we make callback to form class
        private readonly MainForm.TreeVisualizeCallBack _visualizeCallBack;

        public TreeVisualizer(MainForm.TreeVisualizeCallBack visualizeCallBack) {
            _visualizeCallBack = visualizeCallBack;
        }

        public void Visualize() {
            while (true) {
                MainForm.TreeAwaiter.WaitOne();
                MainForm.TreeAwaiter.Reset();

                _visualizeCallBack();

                MainForm.MainAwaiter.WaitOne();
                MainForm.MainAwaiter.Reset();

                MainForm.WriterAwaiter.Set();
            }
        }
    }
}

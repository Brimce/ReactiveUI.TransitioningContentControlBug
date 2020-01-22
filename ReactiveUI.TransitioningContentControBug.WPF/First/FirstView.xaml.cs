using System;
using System.Reactive.Disposables;

namespace ReactiveUI.TransitioningContentControlBug.WPF.First
{
    public partial class FirstView : ReactiveUserControl<FirstViewModel>
    {
        public FirstView()
        {
            InitializeComponent();
            Console.WriteLine("Create FirstView");

            this.WhenActivated(disposables =>
            {
                Console.WriteLine("Active FirstView");

                this.OneWayBind(ViewModel, x => x.UrlPathSegment, x => x.PathTextBlock.Text)
                    .DisposeWith(disposables);
            });
        }
    }
}
using System;
using System.Reactive.Disposables;
using Splat;

namespace ReactiveUI.TransitioningContentControlBug.WPF.First
{
    public class FirstViewModel : ReactiveObject, IRoutableViewModel, IActivatableViewModel
    {
        public string UrlPathSegment => "first";
    
        public IScreen HostScreen { get; }

        public FirstViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.WhenActivated(disposable =>
            {
                Console.WriteLine("Active FirstViewModel");
                Disposable.Create(() =>
                    {
                        Console.WriteLine("Dispose FirstViewModel");
                    })
                    .DisposeWith(disposable);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}
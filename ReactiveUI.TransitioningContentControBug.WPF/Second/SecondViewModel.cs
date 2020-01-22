using System;
using System.Reactive.Disposables;
using Splat;

namespace ReactiveUI.TransitioningContentControBug.WPF.Second
{
    public class SecondViewModel : ReactiveObject, IRoutableViewModel, IActivatableViewModel
    {
        public string UrlPathSegment => "second";
    
        public IScreen HostScreen { get; }

        public SecondViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.WhenActivated(disposable =>
            {
                Console.WriteLine("Active SecondViewModel");
                Disposable.Create(() =>
                    {
                        Console.WriteLine("Dispose SecondViewModel");
                    })
                    .DisposeWith(disposable);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}
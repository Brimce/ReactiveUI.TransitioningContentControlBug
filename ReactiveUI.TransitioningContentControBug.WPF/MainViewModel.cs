using System.Reactive;
using ReactiveUI.TransitioningContentControlBug.WPF.First;
using ReactiveUI.TransitioningContentControlBug.WPF.Second;
using Splat;

namespace ReactiveUI.TransitioningContentControlBug.WPF
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; }
        
        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        private readonly ObservableAsPropertyHelper<IRoutableViewModel> _currentVM;
        public IRoutableViewModel CurrentVM => _currentVM.Value;
        public MainViewModel()
        {
            // Initialize the Router.
            Router = new RoutingState();

            _currentVM = Router.CurrentViewModel.ToProperty(this, nameof(CurrentVM));
            // Router uses Splat.Locator to resolve views for
            // view models, so we need to register our views
            // using Locator.CurrentMutable.Register* methods.
            //
            // Instead of registering views manually, you 
            // can use custom IViewLocator implementation,
            // see "View Location" section for details.
            //
            Locator.CurrentMutable.Register(() => new FirstView(), typeof(IViewFor<FirstViewModel>));
            Locator.CurrentMutable.Register(() => new SecondView(), typeof(IViewFor<SecondViewModel>));

            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            GoNext = ReactiveCommand.CreateFromObservable(() => 
                CurrentVM is FirstViewModel 
                 ? Router.Navigate.Execute(new SecondViewModel())
                 : Router.Navigate.Execute(new FirstViewModel())
            );

            // You can also ask the router to go back.
            GoBack = Router.NavigateBack;

        }
    }
}
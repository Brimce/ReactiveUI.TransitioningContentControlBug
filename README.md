# ReactiveUI.TransitioningContentControlBug
Show the many calls to WhenActivated 

Console on second call to GoToNext:
Create SecondView
DefaultViewLocator: Resolved service type 'ReactiveUI.IViewFor`1[[ReactiveUI.TransitioningContentControBug.WPF.Second.SecondViewModel, ReactiveUI.TransitioningContentControBug.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]'
Dispose FirstViewModel
Active FirstViewModel
Active FirstView
Active SecondViewModel
Active SecondView
POCOObservableForProperty: The class ReactiveUI.TransitioningContentControBug.WPF.Second.SecondView property PathTextBlock is a POCO type and won't send change notifications, WhenAny will only return a single value!
Dispose FirstViewModel

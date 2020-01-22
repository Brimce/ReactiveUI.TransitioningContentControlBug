# ReactiveUI.TransitioningContentControlBug
Show the many calls to WhenActivated 

Console on second call to GoToNext:

Create SecondView

...

Dispose FirstViewModel

Active FirstViewModel

Active FirstView

Active SecondViewModel

Active SecondView

...

Dispose FirstViewModel

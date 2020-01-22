# ReactiveUI.TransitioningContentControlBug
Show the many calls to WhenActivated 

Console on navigation from FirstView to SecondView:

Create SecondView

...

Dispose FirstViewModel (bug)

Active FirstViewModel (bug)

Active FirstView (bug)

Active SecondViewModel

Active SecondView

...

Dispose FirstViewModel

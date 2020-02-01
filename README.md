# ReactiveUI.TransitioningContentControlBug
Shows the behavior of the TransitioningContentControl during the transition between two views
The old view (and associated view model) is disposed before the transition starts then created again.

Here is an example of a log when navigating between FirstView and SecondView :

Create SecondView  
...  
Dispose FirstViewModel (bug)  
Active FirstViewModel (bug)  
Active FirstView (bug)  
Active SecondViewModel  
Active SecondView  
...  
Dispose FirstViewModel

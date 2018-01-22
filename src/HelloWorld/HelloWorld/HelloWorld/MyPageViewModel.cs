using System;
using Xamarin.Forms;

namespace HelloWorld
{
    public class MyPageViewModel : BindableBase
    {
        private string _message;

        public string Message
        {
            get => _message; 
            set => SetProperty(ref _message, value); 
        }

        private bool _canExecute;

        public bool CanExecute
        {
            get => _canExecute;
            set
            {
                SetProperty(ref _canExecute, value);
                NowCommand.ChangeCanExecute();
            }
        }

        public Command NowCommand { get; }

        public MyPageViewModel()
        {
            NowCommand = new Command(
                x => Message = DateTime.Now.ToString((string)x),
                _ => CanExecute);
        }
    }
}

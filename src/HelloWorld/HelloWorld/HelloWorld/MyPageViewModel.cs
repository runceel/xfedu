using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HelloWorld
{
    public class MyPageViewModel : BindableBase
    {
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public MyPageViewModel()
        {
            var r = new Random();
            Device.StartTimer(
                TimeSpan.FromSeconds(1),
                () =>
                {
                    People.Add(new Person { Name = $"tanaka {r.Next()}" });
                    return true;
                });
        }
    }
}

namespace HelloWorld
{
    public class MyPageViewModel : BindableBase
    {
        private double _sliderValue;

        public double SliderValue
        {
            get { return _sliderValue; }
            set { SetProperty(ref _sliderValue, value); OnPropertyChanged(nameof(LabelValue)); }
        }

        public string LabelValue => $"This is slider value '{SliderValue.ToString("000")}'";
    }
}

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();
		_viewModel = DI.GetMainPageViewModel();
		BindingContext = _viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.FetchWorkouts();
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var workout = (WorkoutEntity)e.CurrentSelection.FirstOrDefault();
		await Shell.Current.GoToAsync($"DetailsPage?name={workout.Name}");
	}
}


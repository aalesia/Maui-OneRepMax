namespace MauiApp1;

[QueryProperty(nameof(Name), "name")]
public partial class DetailsPage : ContentPage
{
	private readonly DetailsPageViewModel _viewModel;

	private string _name;
	public string Name
	{
		get => _name;
		set
		{
			_name = value;
		}
	}

	public DetailsPage()
	{
    	InitializeComponent();
		_viewModel = DI.GetDetailsPageViewModel();
		BindingContext = _viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.FetchWorkout(Name);
	}
}
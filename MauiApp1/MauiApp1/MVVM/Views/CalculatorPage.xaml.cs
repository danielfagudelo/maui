using MauiApp1.MVVM.ViewModels;
using MauiApp1.MVVM.Views;

namespace MauiApp1.MVVM.Views;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
        
        var viewModel = new CalculatorViewModel();

        BindingContext = viewModel;

    }
}

using Tarea_1._3.ViewModels;

namespace Tarea_1._3.Views
{
    public partial class Lista_Autores : ContentPage
    {
        ViewModels.ListaAutoresViewModel _viewModel;

        public Lista_Autores()
        {
            InitializeComponent();
            _viewModel = new ListaAutoresViewModel();
            BindingContext = _viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CargarPersonas();
        }
    }
}

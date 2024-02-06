// ListaAutoresViewModel.cs

using System.Collections.ObjectModel;
using Tarea_1._3.Controllers;
using Tarea_1._3.Models;

namespace Tarea_1._3.ViewModels
{
    public class ListaAutoresViewModel : BindableObject
    {
        private ObservableCollection<DateBase> _Autorlist;

        public ObservableCollection<DateBase> PersonasList
        {
            get { return _Autorlist; }
            set
            {
                _Autorlist = value;
                OnPropertyChanged(nameof(PersonasList));
            }
        }   
        private FormularioController _formularioController;

        public ListaAutoresViewModel()
        {
            _Autorlist = new ObservableCollection<DateBase>();
            _formularioController = new FormularioController();
        }

        public async Task CargarPersonas()
        {
            await _formularioController.Init();
            var personas = await _formularioController.ObtenerTodasLasPersonas();
            PersonasList = new ObservableCollection<DateBase>(personas);
        }

    }
}

using System;
using Microsoft.Maui.Controls;
using Tarea_1._3.Controllers;
using Tarea_1._3.Models;


namespace Tarea_1._3.Views
{
    public partial class Formulario : ContentPage
    {
        Controllers.FormularioController authorC;
        public Formulario()
        {
            InitializeComponent();
            authorC = new Controllers.FormularioController();
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            // Recuperar los valores del Entry y Picker
            string nombre = NombreEntry.Text;
            string pais = PaisPicker.SelectedItem as string;

            // Validar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombre))
            {
                DisplayAlert("Error", "Por favor, ingrese un nombre v�lido", "OK");
                return;
            }

            // Validar que se haya seleccionado un pa�s
            if (string.IsNullOrWhiteSpace(pais))
            {
                DisplayAlert("Error", "Por favor, seleccione un pa�s v�lido", "OK");
                return;
            }

            try
            {
                // Crear una nueva instancia del modelo DateBase con los valores
                var nuevoAutor = new DateBase
                {
                    Nombre = nombre,
                    Pais = pais
                };

                // Mostrar un mensaje de �xito

                if (await authorC.StoreAutor(nuevoAutor) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Ingresado con �xito!!", "ok");

                    // Despu�s de guardar, navega a la p�gina de listado
                }
                else
                {
                    await DisplayAlert("Aviso", "Error al almacenar la persona", "ok");
                }

                await Navigation.PushAsync(new Lista_Autores());

            }
            catch (Exception ex)
            {
                // Manejar errores en la operaci�n de guardado
                DisplayAlert("Error", $"Ocurri� un error: {ex.Message}", "OK");
            }
        }
        async void VerListado(System.Object sender, System.EventArgs e)
        {
            // Navegar a la p�gina de listado
            await Navigation.PushAsync(new Lista_Autores());
        }
    }
}

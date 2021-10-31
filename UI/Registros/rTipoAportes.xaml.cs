using GestionPersonas.BLL;
using GestionPersonas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionPersonas.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rTipoAportes.xaml
    /// </summary>
    public partial class rTipoAportes : Window
    {
        private TipoAportes TAporte = new TipoAportes();
        public rTipoAportes()
        {
            InitializeComponent();
            this.DataContext = TAporte;
        }

        private void Limpiar()
        {
            this.TAporte = new TipoAportes();
            this.DataContext = TAporte;

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (TipoAporteIDTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un ID", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese una descripcion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = TipoAportesBLL.Guardar(TAporte);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(TipoAporteIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var TAportes = TipoAportesBLL.Buscar(Utilidades.ToInt(TipoAporteIDTextBox.Text));

            if (TAportes != null)
                this.TAporte = TAportes;
            else
                this.TAporte = new TipoAportes();

            this.DataContext = this.TAporte;
        }
        public void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = TAporte;
        }

    }
}


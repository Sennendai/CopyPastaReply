using System.Windows.Forms;

namespace CPR
{
    public class cprMenuItem : ContextMenu
    {
        public string copyPasta;

        public string titulo;

        public MenuItem menuItem;

        public cprMenuItem()
        {
            this.menuItem = new MenuItem("Editar", (s, e) => { new Principal(this).Show(); });
        }

        public cprMenuItem(string titulo, string texto)
        {
            this.titulo = titulo;
            this.copyPasta = texto;
            this.menuItem = new MenuItem("Editar", (s, e) => { new Principal(this).Show(); });
        }
    }
}

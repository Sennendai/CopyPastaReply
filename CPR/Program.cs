using CPR.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CPR
{
    static class Program
    {
        private static NotifyIcon notifyIcon;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon icon = new NotifyIcon(new System.ComponentModel.Container())
            {
                Icon = Resources.clipboard,
                Text = "CopyPasteReply",
                ContextMenu = AsignarContextMenu(),
                //ContextMenuStrip = AsignarContextMenu();
                Visible = true
            };

            notifyIcon = icon;
            Application.Run();

            Application.ApplicationExit += (s, e) => RefreshTrayArea();
        }

        private static ContextMenu AsignarContextMenu()
        {
            MenuItem verticalBar = new MenuItem() { BarBreak = true };

            // esto te genera automaticamente una barra horizontal que ocupa todo el ancho
            MenuItem horizontalBar = new MenuItem("-");

            List<SerializableMenuItem> elementos = new List<SerializableMenuItem>();
            elementos = Utilidades.UtilidadesGenerales.CargarDocumento(elementos);

            ContextMenu menu = new ContextMenu();

            foreach (var elemento in elementos)
            {
                //cprMenuItem elementoCPR = new cprMenuItem { Name = elemento.titulo, titulo = elemento.titulo, copyPasta = elemento.copyPasta };
                //elementoCPR.Click += (s, e) => CopiarTexto(elemento.copyPasta);
                //elementoCPR.MenuItems.Add(new MenuItem("Editar", (s, e) => { new Principal(elementoCPR).Show(); }));
                //menu.MenuItems.Add(elementoCPR);                
                menu.MenuItems.Add(new MenuItem(elemento.titulo, (s, e) => CopiarTexto(elemento.copyPasta)));
            }

            MenuItem nuevoElemento = new MenuItem("Nuevo", (s, e) => { new Principal().Show(); }) { OwnerDraw = true }; 
            nuevoElemento.DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);

            MenuItem editar =  new MenuItem("Editar", (s, e) => { new Principal(true).Show(); });
            MenuItem salir = new MenuItem("Salir", (s, e) => { Application.Exit(); });

            menu.MenuItems.AddRange( new MenuItem[]
            {
                horizontalBar,
                nuevoElemento,
                editar,
                salir
            });

            return menu;
        }

        private static void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
        {
            MenuItem customItem = (MenuItem)sender;

            var rect = new Rectangle(e.Bounds.X, e.Bounds.Y, (int)(Resources.add.Width), (int)(Resources.add.Height));
            //height 0....
            e.Graphics.DrawImage(Resources.add, rect);
        }

        public static void RefrescarNotifyIcon()
        {
            notifyIcon.ContextMenu = AsignarContextMenu();
        }

        private static void CopiarTexto(string text)
        {
            if (!string.IsNullOrEmpty(text)) Clipboard.SetText(text);
        }

        // TODO: Analizar este codigo, copiado de http://maruf-dotnetdeveloper.blogspot.com/2012/08/c-refreshing-system-tray-icon.html
        // Se supone que debería de solucionar el bug de que se quede el icono en la barra de abajo pero no funciona
        #region "Refresh Notification Area Icons"

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        public static void RefreshTrayArea()
        {
            IntPtr systemTrayContainerHandle = FindWindow("Shell_TrayWnd", null);
            IntPtr systemTrayHandle = FindWindowEx(systemTrayContainerHandle, IntPtr.Zero, "TrayNotifyWnd", null);
            IntPtr sysPagerHandle = FindWindowEx(systemTrayHandle, IntPtr.Zero, "SysPager", null);
            IntPtr notificationAreaHandle = FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32", "Notification Area");
            if (notificationAreaHandle == IntPtr.Zero)
            {
                notificationAreaHandle = FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32", "User Promoted Notification Area");
                IntPtr notifyIconOverflowWindowHandle = FindWindow("NotifyIconOverflowWindow", null);
                IntPtr overflowNotificationAreaHandle = FindWindowEx(notifyIconOverflowWindowHandle, IntPtr.Zero, "ToolbarWindow32", "Overflow Notification Area");
                RefreshTrayArea(overflowNotificationAreaHandle);
            }
            RefreshTrayArea(notificationAreaHandle);
        }

        private static void RefreshTrayArea(IntPtr windowHandle)
        {
            const uint wmMousemove = 0x0200;
            RECT rect;
            GetClientRect(windowHandle, out rect);
            for (var x = 0; x < rect.right; x += 5)
                for (var y = 0; y < rect.bottom; y += 5)
                    SendMessage(windowHandle, wmMousemove, 0, (y << 16) + x);
        }
        #endregion

    }
}

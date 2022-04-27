using CPR.Properties;
using System;
using System.Collections.Generic;
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

            notifyIcon = new NotifyIcon(new System.ComponentModel.Container())
            {
                Icon = Resources.clipboard,
                Text = "CopyPasteReply",
                ContextMenuStrip = AsignarContextMenu(),
                Visible = true
            };

            Application.Run();
            Application.ApplicationExit += (s, e) => RefreshTrayArea();
        }

        private static ContextMenuStrip AsignarContextMenu()
        {
            List<SerializableMenuItem> elementos = new List<SerializableMenuItem>();
            elementos = Utilidades.UtilidadesGenerales.CargarDocumento(elementos);

            ContextMenuStrip menu = new ContextMenuStrip();

            foreach (var elemento in elementos)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(elemento.titulo, Resources.clipboard1, (s, e) => CopiarTexto(elemento.copyPasta));
                // Para añadir un desplegable a la derecha de cada elemento pero queda feo
                //item.DropDownItems.Add(new ToolStripMenuItem("Editar", Resources.edit, (s, e) => { new Principal(true).Show(); }));
                menu.Items.Add(item);
            }

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(new ToolStripMenuItem("Nuevo", Resources.add, (s, e) => { new Principal().Show(); }));
            menu.Items.Add(new ToolStripMenuItem("Editar", Resources.edit, (s, e) => { new Principal(true).Show(); }));
            menu.Items.Add(new ToolStripMenuItem("Salir", Resources.exit, (s, e) => { Application.Exit(); }));

            return menu;
        }

        public static void RefrescarNotifyIcon()
        {
            notifyIcon.ContextMenuStrip = AsignarContextMenu();
        }

        private static void CopiarTexto(string text)
        {
            if (!string.IsNullOrEmpty(text)) Clipboard.SetText(text);
        }

        // TODO: Analizar este codigo, copiado de http://maruf-dotnetdeveloper.blogspot.com/2012/08/c-refreshing-system-tray-icon.html
        // Se supone que debería de solucionar el bug de que se quede el icono en la barra de abajo cuando se cierra la aplicacion
        // pero no funciona
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

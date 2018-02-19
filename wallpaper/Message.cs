using System.Windows.Forms;

namespace wallpaper
{
    class Message
    {
        public static void MpvMessage()
        {
            string mpvMessage = Language.GetString("mpvMessage");
            string error = Language.GetString("error");
            MessageBox.Show(mpvMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FileMessage()
        {
            string fileMessage = Language.GetString("fileMessage");
            string error = Language.GetString("error");
            MessageBox.Show(fileMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System.Windows.Forms;

namespace wallpapersetting
{
    class Message
    {
        public static DialogResult ExitMessage()
        {
            string warning = Language.GetString("warning");
            string exitMessage = Language.GetString("exitMessage");
            DialogResult dialogResult = MessageBox.Show(exitMessage, warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return dialogResult;
        }

        public static void ExitDone()
        {
            string information = Language.GetString("information");
            string exitDone = Language.GetString("exitDone");
            MessageBox.Show(exitDone, information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult CloseMessage()
        {
            string information = Language.GetString("information");
            string closeMessage = Language.GetString("closeMessage");
            DialogResult dialogResult = MessageBox.Show(closeMessage, information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return dialogResult;
        }
    }
}

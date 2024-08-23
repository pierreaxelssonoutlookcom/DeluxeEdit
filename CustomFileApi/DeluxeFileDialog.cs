using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomFileApiFile
{
     public class DeluxeFileDialog
    {
        public EncodingPath? ShowFileOpenDialog(string? initDir = null)
        {
            EncodingPath? result = null;
            using var dialog = new MyOpenFileDialogControl(initDir);
            var dummyForm = new Form();
            var dialogResult = dialog.ShowDialog(dummyForm);

            if (dialogResult == DialogResult.OK)
            {
                result = new EncodingPath { Path = dialog.MSDialog.FileName };
                result.Encoding = dialog.WantedEncoding != null ? (Encoding?)(Encoding.GetEncoding(dialog.WantedEncoding)) : null;
            }

            return result;

        }
        public EncodingPath? ShowFileSaveDialog(string? initDir = null)
        {
            EncodingPath? result = null;
            using var dialog = new MySaveDialogControl(initDir);
            var dummyForm = new Form();
            var dialogResult = dialog.ShowDialog(dummyForm);

            if (dialogResult == DialogResult.OK)
            {
                result = new EncodingPath { Path = dialog.MSDialog.FileName };
                result.Encoding = dialog.WantedEncoding != null ? (Encoding?)(Encoding.GetEncoding(dialog.WantedEncoding)) : null;
            }

            return result;

        }
    }
}

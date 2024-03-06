using System.Windows.Controls;

namespace DeluxeEdit.DefaultPlugins
{

    public class WPFUtil
    {
        public static bool TabÉxist(string header, TabControl control)
        {
            bool result = false;
            foreach (TabItem x in control.Items)
            {
                if (x.Header == header)
                {
                    result = true;
                    break;
                }

            }
            return result;
        }
        }
    }
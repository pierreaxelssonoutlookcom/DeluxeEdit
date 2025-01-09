using Extensions;
using Model;
using System;

namespace ViewModel
{
    public class DoWhenTextChange
    {
        public void Load()
        {
            InterlSetHeader(false);
        }
        public void ResetChange()
        {
            InterlSetHeader(true);
        }

        private void InterlSetHeader(bool resetChange)
        {
            string? headerString;

            if (MyEditFiles.Current != null)
            {
                var tab = MyEditFiles.Current.Tab;
                if (tab != null)
                {
                    var header = tab.Header;
                    MyEditFiles.Current.TextHasChanged = true;
                    if (header != null)
                    {
                        headerString = header.ToString();
                        if (headerString!=null)
                        {
                            if (resetChange==false &&  headerString.EndsWith("*") == false)
                            {
                                headerString = String.Concat(headerString, "*");
                                tab.Header = headerString;
                            }
                            else if (resetChange  && headerString.EndsWith("*"))
                            {
                                headerString = headerString.Trim('*');
                                tab.Header = headerString;

                            }


                        }
                    }
                }
            }
        }
        }

}

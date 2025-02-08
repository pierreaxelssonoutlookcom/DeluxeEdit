using Extensions;
using Model;
using System;

namespace ViewModel.MainActions
{
    public class DoWhenTextChange
    {
        public void Load()
        {
            InternalSetHeader(false);
        }
        public void ResetChange()
        {
            InternalSetHeader(true);
        }

        private void InternalSetHeader(bool resetChange)
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

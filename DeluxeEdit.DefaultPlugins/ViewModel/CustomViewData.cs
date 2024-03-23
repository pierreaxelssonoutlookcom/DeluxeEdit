using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public enum EventType { NewFileType, LoadFile }

    public class CustomViewData
    {

        public delegate void ChangedHandler(EventType type);

        public event ChangedHandler Changed;


        public static ContentPath OldLastNewFile { get; set; }
        public static ContentPath NewFile { get; set; }
        public static ContentPath EditFile{ get; set; }

        private  bool IsNewFile { get; set; }

        protected  void RaiseEvent(EventArgs e)
        {
         
            
//            Changed.Invoke

        }
        public void PublishNewFile(ContentPath path)
        {
            NewFile = path;
        }
        public void PublishLoadFile(ContentPath path)
        {
            EditFile = path;
        }





        public void subscrile(ChangedHandler handler)
        {
            Changed += handler;
        }

  
        
    }
}
using Model;
using System;
using System.CodeDom;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public class EventData
    {
        public delegate void Cust(EventType type, ContentPath path);
        public event EventHandler<CustomEventArgs> Changed;
       public MyEditFile? EditFile { get; set; }
       public MyEditFile? OldEditFile { get; set; }


        private EventType? CurrentType = null;
        private EventType? OldType = null;
        
        
        
        public void CheckToRaiseEvent()
        {
            if (CurrentType.HasValue && EditFile != null)
            {
                if (OldEditFile != EditFile || OldType!=CurrentType)
                    Changed.Invoke(this, new CustomEventArgs { Type = CurrentType.Value, Data = EditFile });


                OldType = CurrentType;
                OldEditFile = EditFile;
            }
        }
        
            
        public EventData()
        {

     
                Changed += EventData_Changed; 
        }

        private void EventData_Changed(object? sender, CustomEventArgs e)
        {
            throw new NotImplementedException();
        }

         
 
         public void PublishNewFile(MyEditFile path)
        {
            if (path == null) return;

            CurrentType = EventType.NewFile;
            
          

                CheckToRaiseEvent();
           
        }
            public void PublishEditFile(MyEditFile path)
            {

                if (path == null) return;

                CurrentType = EventType.EditFile; ;

                CheckToRaiseEvent();

            }






                public void subscrile(EventHandler<CustomEventArgs> handler)
        {
            Changed += handler;
        }

  
        
    }
}
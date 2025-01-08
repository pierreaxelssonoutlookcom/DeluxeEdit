using DefaultPlugins;
using Model;
using System.Windows.Controls;

namespace ViewModel
{
    public class SetupMenuActions
    {
        private MainEditViewModel model;
        private TabControl tabFiles;
        private ProgressBar progressBar;
        private LoadFile loadFile;
        private SaveFile saveFile;
        private HexView hex;
        private NewFile newFile;

        public SetupMenuActions(MainEditViewModel model, TabControl tabControl, ProgressBar progress)
            {
                this.model=model;
            this.tabFiles=tabControl;
            this.progressBar=progress;
            this.loadFile=new LoadFile(this.model,  this.progressBar, this.tabFiles);
            this.saveFile = new SaveFile(this.model, this.progressBar);
            this.hex = new HexView(this.model, this.progressBar, tabControl);
            newFile = new NewFile(model, tabControl);

        }


        public void SetMenuAction(CustomMenuItem item)
            {
                if (item !=null && model!=null && item.Plugin is FileNewPlugin)
                    item.MenuActon = () => newFile.Load();
                else if (item != null && model != null && item.Plugin is FileOpenPlugin)
                    item.MenuActon = () => loadFile.Load();
                else if (item != null && model != null && item.Plugin is FileSavePlugin)
                    item.MenuActon = () => saveFile.Save();
                else if (item != null && model != null && item.Plugin  is FileSaveAsPlugin)
                    item.MenuActon = () => saveFile.SaveAs();
                else if (item != null && model != null && item.Plugin is HexPlugin)
                    item.MenuActon = () => hex.Load();
                

            }

        }

        } 
    

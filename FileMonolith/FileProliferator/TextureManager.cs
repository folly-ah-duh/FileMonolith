using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FtexTool;


namespace FileProliferator
{
    class TextureManager
    {
        public void ConvertDdsToFtex()
        {
            string[] ftexToolArgs = { "",""};
            FtexTool.Program.Main(ftexToolArgs);
        }
    }
}

using clby_ufop.Core;
using clby_ufop.Core.Func;
using Microsoft.AspNetCore.Mvc;
using NPOI.XWPF.UserModel;
using System;
using System.IO;

namespace clby_ufop_NPOI.Funcs
{
    public class Func_doc : IFunc
    {

        public IActionResult Do(byte[] fileContents, HandlerArgs args)
        {
            var dirpath = Path.Combine(AppContext.BaseDirectory, "files");
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            var filepath = Path.Combine(dirpath, $"{Guid.NewGuid().ToString()}.docx");

            using (var fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XWPFDocument doc = new XWPFDocument();
                var p0 = doc.CreateParagraph();
                p0.Alignment = ParagraphAlignment.CENTER;
                XWPFRun r0 = p0.CreateRun();
                r0.FontFamily = "microsoft yahei";
                r0.FontSize = 18;
                r0.IsBold = true;
                r0.SetText("This is title");

                var p1 = doc.CreateParagraph();
                p1.Alignment = ParagraphAlignment.LEFT;
                p1.IndentationFirstLine = 500;
                XWPFRun r1 = p1.CreateRun();
                r1.FontFamily = "·ÂËÎ";
                r1.FontSize = 12;
                r1.IsBold = true;
                r1.SetText("This is content, content content content content content content content content content");

                doc.Write(fs);
                
            }
            
            return new PhysicalFileResult(filepath, "application/octet-stream");

        }
    }
}

using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServer.DB.Content
{
    public class FileMessage
    {
        [Key]
        public int FileID { get; set; }

        // Внешний ключ на сообщение, с которым связан файл
        [ForeignKey("Message")]
        public int MessageID { get; set; }
        public virtual Message Message { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public byte[] FileContent { get; set; }
    }
}

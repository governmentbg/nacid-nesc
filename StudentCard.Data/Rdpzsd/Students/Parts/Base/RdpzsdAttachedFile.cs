﻿using StudentCard.Data.Rdpzsd.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Parts.Base
{
    public class RdpzsdAttachedFile : EntityVersion
    {
        public Guid Key { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public int DbId { get; set; }
    }
}

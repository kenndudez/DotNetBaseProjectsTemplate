using DOTNET.BaseProjectTemplate.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTNET.BaseProjectTemplate.Entities
{
    public class FileUpload : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string ContentType { get; set; }
    }
}

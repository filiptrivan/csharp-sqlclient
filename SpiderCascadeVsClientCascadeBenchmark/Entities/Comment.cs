using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCascadeVsClientCascadeBenchmark.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Points { get; set; }

        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public People Owner { get; set; }

        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Blog Blog { get; set; }
    }
}

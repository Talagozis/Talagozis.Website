using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Talagozis.Website.Models.Blocks
{
    [BlockType(Name = "Code", Category = "Content", Icon = "fas fa-code")]
    public class CodeBlock : Block
    {
        /// <summary>
        /// Gets/sets the text body.
        /// </summary>
        public TextField Body { get; set; }
    }
}
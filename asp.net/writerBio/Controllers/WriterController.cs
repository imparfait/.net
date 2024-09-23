using Microsoft.AspNetCore.Mvc;
using writerBio.Models;

namespace writerBio.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Biography()
        {
            var writer = GetWriterData();
            return View(writer);
        }

        public IActionResult Life()
        {
            var writer = GetWriterData();
            return View(writer);
        }

        public IActionResult Works()
        {
            var writer = GetWriterData();
            return View(writer);
        }
        private Writer GetWriterData()
        {
            return new Writer
            {
                Name = "Stephen King",
                Biography = "Stephen King is an American author of horror, supernatural fiction, suspense, crime, and fantasy novels. He has published more than 60 novels and 200 short stories.",
                Life = "Stephen King was born on September 21, 1947, in Portland, Maine. His early life was shaped by his love of books and storytelling. Over the years, he has become one of the most famous authors in the world, known for works like 'Carrie', 'The Shining', and 'It'.",
                Works = new List<string>
                {
                    "Carrie (1974)",
                    "The Shining (1977)",
                    "It (1986)",
                    "Misery (1987)",
                    "The Dark Tower series (1982-2012)"
                }
            };
        }
    }
}

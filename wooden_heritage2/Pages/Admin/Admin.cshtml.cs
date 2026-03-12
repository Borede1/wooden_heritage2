using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wooden_heritage2.Pages.Admin
{
    [Authorize]
    public class AdminModel : PageModel
    {
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        [BindProperty]
        public string AltText { get; set; }

        [BindProperty]
        public int ImageId { get; set; }

        public string ImageSuccessMessage { get; set; }

        public List<ImageItem> Images { get; set; } = new List<ImageItem>();

        public void OnGet()
        {
            Images = GetImages();
        }

        public async Task<IActionResult> OnPostUploadImageAsync()
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                ImageSuccessMessage = "Image uploaded successfully!";
            }

            Images = GetImages();
            return Page();
        }

        public IActionResult OnPostDeleteImage()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            var images = GetImages();
            var image = images.FirstOrDefault(i => i.Id == ImageId);

            if (image != null)
            {
                var filePath = Path.Combine(folder, image.FileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            Images = GetImages();
            return Page();
        }

        private List<ImageItem> GetImages()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            var images = new List<ImageItem>();
            int id = 1;

            if (Directory.Exists(folder))
            {
                foreach (var file in Directory.GetFiles(folder))
                {
                    images.Add(new ImageItem
                    {
                        Id = id,
                        FileName = Path.GetFileName(file),
                        AltText = Path.GetFileNameWithoutExtension(file)
                    });
                    id++;
                }
            }

            return images;
        }
    }

    public class ImageItem
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string AltText { get; set; }
    }
}
﻿using BookStore.Enums;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {        
        public int Id { get; set; }

        //[StringLength(100, MinimumLength =5)]
        //[Required(ErrorMessage = "Please enter the title of your book")]
        [MyCustomValidation("azure")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Plese enter the author name")]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage ="Please choose the language for your book")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage ="Please enter the total pages")]
        [Display(Name = "Total Pages of Book")]
        public int? TotalPages { get; set; }

        [Required]
        [Display(Name = "Choose the cover photo of your book")]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Required]
        [Display(Name = "Choose the gallery images of your book")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Required]
        [Display(Name = "Upload your book in pdf format")]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }

    }
}

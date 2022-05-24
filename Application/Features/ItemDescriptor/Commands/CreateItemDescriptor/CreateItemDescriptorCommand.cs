using System;
using System.Collections.Generic;
using Domain.AggregateRoots;

namespace Application.Features.ItemDescriptor.Commands.CreateItemDescriptor
{
    public class CreateItemDescriptorCommand : ICommand
    {
        public int Year { get; private set; }
        public String Author { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public String Publisher { get; private set; }
        public List<Dto.ItemDto> Items { get; private set; }
        public Borrow_Type BorrowType { get; private set; }
        public ItemDescriptorType ItemDescriptorType { get; private set; }
        public String Subject { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int ISBN { get; private set; }
        public int Edition { get; private set; }


        // for map
        public CreateItemDescriptorCommand(int year, String author, String title,
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = new List<Dto.ItemDto>();
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
        }

        public CreateItemDescriptorCommand(int year, String author, String title, 
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType,
            List<Dto.ItemDto> items)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = items;
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
        }

        // for article
        public CreateItemDescriptorCommand(int year, String author, String title,
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType,
            String subject, DateTime releaseDate)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = new List<Dto.ItemDto>();
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
            this.Subject = subject;
            this.ReleaseDate = releaseDate;
        }

        public CreateItemDescriptorCommand(int year, String author, String title,
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType,
            List<Dto.ItemDto> items, String subject, DateTime releaseDate)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = items;
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
            this.Subject = subject;
            this.ReleaseDate = releaseDate;
        }

        // for book
        public CreateItemDescriptorCommand(int year, String author, String title,
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType,
            String subject, int ISBN, int edition)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = new List<Dto.ItemDto>();
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
            this.Subject = subject;
            this.ISBN = ISBN;
            this.Edition = edition;
        }

        public CreateItemDescriptorCommand(int year, String author, String title,
            String description, String publisher, Borrow_Type borrowType, ItemDescriptorType itemType,
            List<Dto.ItemDto> items, String subject, int ISBN, int edition)
        {
            this.Year = year;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Publisher = publisher;
            this.Items = items;
            this.BorrowType = borrowType;
            this.ItemDescriptorType = itemType;
            this.Subject = subject;
            this.ISBN = ISBN;
            this.Edition = edition;
        }

    }

}

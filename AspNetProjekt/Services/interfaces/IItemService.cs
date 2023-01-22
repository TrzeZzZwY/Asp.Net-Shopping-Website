﻿using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public interface IItemService
    {
        public Guid? Save(Item item);

        public bool Delete(Guid? id);

        public bool Update(Item item);

        public Item? FindBy(Guid? id);

        public ICollection<Item> FindAll();

        public ICollection<Item> FindPage(int page, int size);
        public bool Like(Item item);
        public bool Wish(Item item);

        public int? GetLikes(Guid? id);
        public int? GetWishes(Guid? id);
    }
}
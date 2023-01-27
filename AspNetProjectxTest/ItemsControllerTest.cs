using AspNetProjekt.Controllers;
using AspNetProjekt.Services;
using AspNetProjekt.Models;
using Xunit;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProjectxTest
{
    public class ItemsControllerTest
    {
        private readonly ItemsController _controller;
        private readonly IItemService _service = new ItemServiceTest();
        private Dictionary<int, Guid?> keys = new Dictionary<int, Guid?>();

        public ItemsControllerTest()
        {
            _controller = new ItemsController(_service);
            var id = _service.Save(
                new Item()
                {
                    ItemName = "Czerwona Czapka",
                    ItemDescription = "Bardzo ciep³a czerwona Czapka, wykonana rêcznie",
                    ItemAvalibility = 10,
                    ItemPrice = 100,
                    ItemDiscount = 0
                });
            keys.Add(1, id);
            id = _service.Save(
                 new Item()
                 {
                     ItemName = "Zielony Szalik",
                     ItemDescription = "Bardzo ciep³y zielony szalik, wykonany rêcznie",
                     ItemAvalibility = 5,
                     ItemPrice = 160,
                     ItemDiscount = 10
                 });
            keys.Add(2, id);
            id = _service.Save(
                 new Item()
                 {
                     ItemName = "Miœ",
                     ItemDescription = "Du¿y miœ",
                     ItemAvalibility = 2,
                     ItemPrice = 80,
                     ItemDiscount = 0,
                 });
            keys.Add(3, id);
            id = _service.Save(
                 new Item()
                 {
                     ItemName = "Bia³a czapka",
                     ItemDescription = "Modna i ciep³a damska czapka",
                     ItemAvalibility = 2,
                     ItemPrice = 100,
                     ItemDiscount = 5
                 });
            keys.Add(4, id);
            id = _service.Save(
                  new Item()
                  {
                      ItemName = "Czarny szalik",
                      ItemDescription = "Elegancki czarny mêski szalik",
                      ItemAvalibility = 1,
                      ItemPrice = 150,
                      ItemDiscount = 15
                  });
            keys.Add(5, id);
        }
        [Fact]
        public void GetTest()
        {
            var actionResult = _controller.Get().Value;
            List<ItemDto> items = new List<ItemDto>(actionResult);
            Assert.Equal(keys.Count, items.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void GetByIdTest(int keyId)
        {
            ItemDto? itemDto = _controller.Get(keys[keyId]).Value;
            Assert.NotNull(itemDto);
            Assert.Equal(keys[keyId].ToString(), itemDto.ItemId);
        }
        [Fact]
        public void PostTest()
        {
            ItemDto itemDto = new ItemDto()
            {
                ItemName = "Czarna czapka",
                ItemDescription = "Ciep³a czapka",
                ItemAvalibility = 3,
                ItemPrice = 100,
                ItemDiscout = 0,
            };
            var action = _controller.Add(itemDto);
            Assert.IsType<CreatedResult>(action);
        }
        [Fact]
        public void DeleteTest()
        {
            var a = _controller.Delete((Guid)keys[1]);
            var b = _controller.Delete((Guid)keys[1]);
            keys.Remove(1);
            Assert.IsType<NoContentResult>(a);
            Assert.IsType<NotFoundResult>(b);
        }
        [Fact]
        public void PutTest()
        {
            ItemDto? itemDto = _controller.Get(keys[5]).Value;
            string itemName = itemDto.ItemName;
            itemDto.ItemName = "Szary szalik";
            _controller.Put((Guid)keys[5], itemDto);
            ItemDto? itemDtoUpdated = _controller.Get(keys[5]).Value;

            Assert.NotEqual(itemName, itemDtoUpdated.ItemName);
            Assert.Equal("Szary szalik", itemDtoUpdated.ItemName);

        }
    }
}
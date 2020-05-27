using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IStoresRepository _storesRepository;
        private readonly IGoodsRepository _goodRepository;

        public StoreController(IUserRepository userRepository,
                               IStoresRepository storeRepository,
                               IGoodsRepository goodRepository)
        {
            _userRepository = userRepository;
            _storesRepository = storeRepository;
            _goodRepository = goodRepository;
        }
        #region GET

        [HttpGet(nameof(GetGoodsFromStoreById))]
        public IActionResult GetGoodsFromStoreById([FromQuery] int storeId)
        {
            var rawGoods = _goodRepository.GetAllGoodsFromStoreById(storeId);
            var goods = new List<GoodsVmOut>();
            foreach (var item in rawGoods)
            {
                var good = new GoodsVmOut()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Cost = item.Cost,
                    Description = item.Description,
                    Good_name = item.Good_name,
                    StoreId = item.StoreId,
                    Type = item.Type
                };
                goods.Add(good);
            }

            return Ok(new { success = true, goods });
        }

        [HttpGet(nameof(SearchGoods))]
        public IActionResult SearchGoods([FromQuery] string searchName)
        {
            var rawGoods = _goodRepository.SearchAllGoodsFromStoreByString(searchName);
            var goods = new List<GoodsVmOut>();
            foreach (var item in rawGoods)
            {
                var good = new GoodsVmOut()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Cost = item.Cost,
                    Description = item.Description,
                    Good_name = item.Good_name,
                    StoreId = item.StoreId,
                    Type = item.Type
                };
                goods.Add(good);
            }

            return Ok(new { success = true, goods });
        }


        #endregion
        #region POST
        [HttpPost(nameof(CreateStore))]
        public IActionResult CreateStore([FromBody] StoresVM storeVm)
        {
            if (storeVm == null || string.IsNullOrEmpty(storeVm.Store_name) || string.IsNullOrEmpty(storeVm.Token))
                return Ok(new { success = false, message = "Недопустимый формат" });

            var userId = _userRepository.GetByToken(storeVm.Token);

            var store = new Stores
            {
                UserId = userId.Id,
                Store_name = storeVm.Store_name,
                Description = storeVm.Description,
                Type = storeVm.Type
            };
            _storesRepository.Add(store);
            return Ok(new { success = true, message = "Новый магазин успешно создан" });
        }

        [HttpPost(nameof(AddGoodIntoStoreId))]
        public IActionResult AddGoodIntoStoreId([FromBody] GoodsVmIn goodsVM)
        {
            if (goodsVM == null || string.IsNullOrEmpty(goodsVM.Good_name) || goodsVM.StoreId == null)
                return Ok(new { success = false, message = "Недопустимый формат" });

            var good = new Goods
            {
                StoreId = (int)goodsVM.StoreId,
                Good_name = goodsVM.Good_name,
                Description = goodsVM.Description,
                Type = goodsVM.Type,
                Amount = goodsVM.Amount,
                Cost = goodsVM.Cost
            };
            _goodRepository.Add(good);
            return Ok(new { success = true, message = "Товар успешно добавлен в магазин" });
        }


        #endregion
    }
}
